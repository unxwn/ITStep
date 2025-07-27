using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();
    .Build();

string connStr = config.GetConnectionString("AzureStorageAccount")!;
string dbPath = config.GetConnectionString("DefaultSQLiteConnection")!;

string queueNam = config["QueueSettings:QueueName"]!;
string origCont = config["BlobSettings:OriginalContainer"]!;
string compCont = config["BlobSettings:CompressedContainer"]!;

var blobSvc = new BlobServiceClient(connStr);
var origContainer = blobSvc.GetBlobContainerClient(origCont);
var compContainer = blobSvc.GetBlobContainerClient(compCont);
var queueClient = new QueueClient(connStr, queueNam);

origContainer.CreateIfNotExists();
compContainer.CreateIfNotExists();
queueClient.CreateIfNotExists();

var cts = new CancellationTokenSource();
bool paused = false;
int width = config.GetValue<int>("Compression:DefaultWidth");
int height = config.GetValue<int>("Compression:DefaultHeight");
bool preserve = config.GetValue<bool>("Compression:PreserveAspect");

var processor = Task.Run(ProcessLoopAsync);
var menu = Task.Run(MenuLoop);

await Task.WhenAll(processor, menu);

async Task ProcessLoopAsync()
{
    while (!cts.IsCancellationRequested)
    {
        if (paused)
        {
            await Task.Delay(500, cts.Token);
            continue;
        }

        QueueMessage[] msgs = await queueClient.ReceiveMessagesAsync(
            maxMessages: 3,
            visibilityTimeout: TimeSpan.FromMinutes(5),
            cancellationToken: cts.Token);

        if (msgs.Length == 0)
        {
            await Task.Delay(500, cts.Token);
            continue;
        }

        foreach (var msg in msgs)
        {
            string blobName = msg.MessageText;

            try
            {
                var origBlob = origContainer.GetBlobClient(blobName);
                await using var inStream = await origBlob.OpenReadAsync(new Azure.Storage.Blobs.Models.BlobOpenReadOptions(false), cts.Token);

                using var image = Image.Load(inStream);
                if (preserve)
                    image.Mutate(x => x.Resize(new ResizeOptions { Mode = ResizeMode.Max, Size = new(width, height) }));
                else
                    image.Mutate(x => x.Resize(width, height));

                var compBlob = compContainer.GetBlobClient(blobName);
                await using var outStream = new MemoryStream();
                await image.SaveAsJpegAsync(outStream, cts.Token);
                outStream.Position = 0;
                await compBlob.UploadAsync(outStream, new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders
                    {
                        ContentType = "image/jpeg"
                    }
                }, cancellationToken: cts.Token);


                await queueClient.DeleteMessageAsync(msg.MessageId, msg.PopReceipt, cts.Token);

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] ✔ Compressed {blobName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] ❌ Error {blobName}: {ex.Message}");
            }
        }
    }
}

async Task MenuLoop()
{
    while (!cts.IsCancellationRequested)
    {
        Console.WriteLine();
        Console.WriteLine("=== MENU ===");
        Console.WriteLine($"[P] Pause/Resume  (now {(paused ? "PAUSED" : "RUNNING")})");
        Console.WriteLine("[S] Settings");
        Console.WriteLine("[Y] Sync queue with DB");
        Console.WriteLine("[Q] Quit");
        Console.Write("Choice: ");

        var key = Console.ReadKey(intercept: true).Key;
        Console.WriteLine();

        switch (key)
        {
            case ConsoleKey.P:
                paused = !paused;
                Console.WriteLine(paused ? "-- PAUSED --" : "-- RESUMED --");
                break;

            case ConsoleKey.S:
                Console.Write($"Width [{width}]: ");
                if (int.TryParse(Console.ReadLine(), out var w)) width = w;

                Console.Write($"Height [{height}]: ");
                if (int.TryParse(Console.ReadLine(), out var h)) height = h;

                Console.Write($"Preserve aspect? (y/n) [{(preserve ? "y" : "n")}]: ");
                var p = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(p)) preserve = p.Trim().StartsWith("y", StringComparison.OrdinalIgnoreCase);

                Console.WriteLine($"→ Updated: {width}x{height}, preserve={preserve}");
                break;

            case ConsoleKey.Y:
                await SyncQueueAsync();
                break;

            case ConsoleKey.Q:
                cts.Cancel();
                return;

            default:
                Console.WriteLine("Unknown.");
                break;
        }
    }
}

async Task SyncQueueAsync()
{
    Console.WriteLine("=== Sync started ===");

    var compressedSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    await foreach (var b in compContainer.GetBlobsAsync(cancellationToken: cts.Token))
        compressedSet.Add(b.Name);

    // db request
    int enqueued = 0;
    await using var sqlite = new SqliteConnection(dbPath);
    await sqlite.OpenAsync(cts.Token);

    var cmd = sqlite.CreateCommand();
    cmd.CommandText = "SELECT BlobName, ContentType FROM Files WHERE ContentType LIKE 'image/%'";
    await using var reader = await cmd.ExecuteReaderAsync(cts.Token);

    while (await reader.ReadAsync(cts.Token))
    {
        string blobName = reader.GetString(0);
        if (!compressedSet.Contains(blobName))
        {
            await queueClient.SendMessageAsync(blobName, cancellationToken: cts.Token);
            enqueued++;
        }
    }

    Console.WriteLine($"Sync complete. Enqueued {enqueued} new items.");
}

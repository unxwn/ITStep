namespace ImageAnalyzerAI.Web.Services.Implementation
{
    using Azure.Storage.Blobs;
    using Azure.Storage.Queues;
    using ImageAnalyzerAI.Web.Models;
    using ImageAnalyzerAI.Web.Services.Abstraction;
    using Microsoft.Extensions.Options;
    using System.Text.Json;

    public class AzureStorageOptions
    {
        public string ConnectionString { get; set; } = default!;
        public string ImagesContainer { get; set; } = "images";
        public string MetadataContainer { get; set; } = "metadata";
        public string QueueName { get; set; } = "images-analysis-queue";
    }

    public class AzureStorageService : IStorageService
    {
        private readonly AzureStorageOptions _opts;
        private readonly BlobContainerClient _imagesContainer;
        private readonly BlobContainerClient _metadataContainer;
        private readonly QueueClient _queueClient;

        public AzureStorageService(IOptions<AzureStorageOptions> opts)
        {
            _opts = opts.Value;
            var blobService = new BlobServiceClient(_opts.ConnectionString);
            _imagesContainer = blobService.GetBlobContainerClient(_opts.ImagesContainer);
            _metadataContainer = blobService.GetBlobContainerClient(_opts.MetadataContainer);
            _imagesContainer.CreateIfNotExists();
            _metadataContainer.CreateIfNotExists();

            _queueClient = new QueueClient(_opts.ConnectionString, _opts.QueueName);
            _queueClient.CreateIfNotExists();
        }

        public async Task<string> UploadFileAsync(Stream stream, string fileName, string contentType, CancellationToken ct = default)
        {
            var blobClient = _imagesContainer.GetBlobClient(fileName);
            stream.Position = 0;
            await blobClient.UploadAsync(stream, new Azure.Storage.Blobs.Models.BlobHttpHeaders { ContentType = contentType }, cancellationToken: ct);
            return blobClient.Name;
        }

        public async Task EnqueueMessageAsync(string blobName, CancellationToken ct = default)
        {
            var message = JsonSerializer.Serialize(new { blobName });
            await _queueClient.SendMessageAsync(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message)), cancellationToken: ct);
        }

        public async Task<IEnumerable<ImageItem>> ListImagesAsync(string? search = null, CancellationToken ct = default)
        {
            var result = new List<ImageItem>();
            await foreach (var blob in _imagesContainer.GetBlobsAsync(cancellationToken: ct))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    if (!blob.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                        continue;
                }

                var blobClient = _imagesContainer.GetBlobClient(blob.Name);

                // build URL - using blobClient.Uri
                var url = blobClient.Uri.ToString();

                // try to read metadata json from metadata container
                string? description = null;
                bool analyzed = false;
                var metaBlobClient = _metadataContainer.GetBlobClient(blob.Name + ".json");
                if (await metaBlobClient.ExistsAsync(ct))
                {
                    var metaResponse = await metaBlobClient.DownloadContentAsync(ct);
                    try
                    {
                        var json = metaResponse.Value.Content.ToString();
                        using var doc = JsonDocument.Parse(json);
                        if (doc.RootElement.TryGetProperty("description", out var desc))
                            description = desc.GetString();
                        analyzed = true;
                    }
                    catch { /* ignore parse errors */ }
                }

                result.Add(new ImageItem
                {
                    BlobName = blob.Name,
                    Url = url,
                    Analyzed = analyzed,
                    Description = description,
                    UploadedAt = blob.Properties.CreatedOn ?? DateTimeOffset.UtcNow
                });
            }

            return result.OrderByDescending(i => i.UploadedAt);
        }
    }

}

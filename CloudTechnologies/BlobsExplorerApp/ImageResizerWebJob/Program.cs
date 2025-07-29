// See https://aka.ms/new-console-template for more information
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using ImageResizerWebJob;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureAppConfiguration((ctx, cfg) =>
    {
        cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
    })
    .ConfigureWebJobs(b =>
    {
        b.AddAzureStorageBlobs();
        b.AddAzureStorageQueues();
    })
    .ConfigureLogging((ctx, log) =>
    {
        log.AddConsole();
        string aIConnStr = ctx.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]
            ?? throw new InvalidOperationException("You should provide 'ApplicationInsights' in app configuration!");

        if (!string.IsNullOrWhiteSpace(aIConnStr))
        {
            log.AddApplicationInsights(
                configureTelemetryConfiguration: (TelemetryConfiguration tC) =>
                {
                    tC.ConnectionString = aIConnStr;
                },
                configureApplicationInsightsLoggerOptions: options =>
                {
                    options.TrackExceptionsAsExceptionTelemetry = true;
                }
            );
        }

        //log.ClearProviders();
        //log.AddConsole();
        //log.AddApplicationInsights();
    })
    .ConfigureServices((ctx, services) =>
    {
        //// ApplicationInsights + logging
        //string aIConnStr = ctx.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]
        //    ?? throw new InvalidOperationException("You should provide 'ApplicationInsights' in app configuration!");

        //services.AddApplicationInsightsTelemetryWorkerService(o =>
        //{
        //    o.ConnectionString = aIConnStr;
        //    o.EnableQuickPulseMetricStream = true; // Live Metrics
        //});

        // Storage account
        string storageConn = ctx.Configuration.GetConnectionString("AzureStorageAccount")
                             ?? throw new InvalidOperationException("You should provide 'AzureStorageAccount' in app configuration!");

        if (string.IsNullOrWhiteSpace(storageConn)) return;

        var blobServiceClient = new BlobServiceClient(storageConn);
        services.AddSingleton(blobServiceClient);

        // НЕ МОЖНА ТОМУ ЩО ОДНАКОВІ КЛАСИ ІН'ЄКТУЮТЬСЯ В DI CONTAINNER І ПЛУТАЮТЬСЯ!!!!!
        //var inputContainerName = ctx.Configuration["BlobSettings:InputContainerName"]
        //                         ?? throw new InvalidOperationException("You should provide 'InputContainerName' in app configuration!");
        //var outputContainerName = ctx.Configuration["BlobSettings:OutputContainerName"]
        //                          ?? throw new InvalidOperationException("You should provide 'OutputContainerName' in app configuration!");

        //var inputContainer = blobServiceClient.GetBlobContainerClient(inputContainerName);
        //var outputContainer = blobServiceClient.GetBlobContainerClient(outputContainerName);

        //services.AddSingleton(inputContainer);
        //services.AddSingleton(outputContainer);

        services.AddHostedService<StorageInitializerService>();

        var queueName = ctx.Configuration["QueueTrigger:QueueName"]
                        ?? throw new InvalidOperationException("You should provide 'QueueName' in app configuration!");

        var queueClient = new QueueClient(storageConn, queueName);

        services.AddSingleton(queueClient);
    })
    .Build();

await host.RunAsync();

using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ImageResizerWebJob;

public class StorageInitializerService : IHostedService
{
    private readonly BlobContainerClient _inputContainerClient;
    private readonly BlobContainerClient _outputContainerClient;
    private readonly QueueClient _queueClient;

    public StorageInitializerService(BlobServiceClient blobServiceClient, QueueClient queueClient, IConfiguration config)
    {
        //_inputContainerClient = inputContainerClient;
        //_outputContainerClient = outputContainerClient;
        _queueClient = queueClient;

        var inputContainerName = config["BlobSettings:InputContainerName"]
            ?? throw new InvalidOperationException("Input container name not configured");

        var outputContainerName = config["BlobSettings:OutputContainerName"]
            ?? throw new InvalidOperationException("Output container name not configured");

        _inputContainerClient = blobServiceClient.GetBlobContainerClient(inputContainerName);
        _outputContainerClient = blobServiceClient.GetBlobContainerClient(outputContainerName);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _inputContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        await _outputContainerClient.CreateIfNotExistsAsync(cancellationToken:  cancellationToken);
        await _queueClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

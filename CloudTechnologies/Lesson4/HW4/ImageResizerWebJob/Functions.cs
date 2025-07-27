using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace ImageResizerWebJob;

public class Functions
{
    private readonly int _width;
    private readonly int _height;
    private readonly BlobContainerClient _inputContainerClient;
    private readonly BlobContainerClient _outputContainerClient;
    //private readonly BlobServiceClient _blobServiceClient;

    public Functions(IConfiguration config, BlobServiceClient blobServiceClient)
    {
        _width = config.GetValue<int>("ImageSettings:Width");
        _height = config.GetValue<int>("ImageSettings:Height");
        //_blobServiceClient = blobServiceClient;
        //_inputContainer = inputContainer;
        //_outputContainer = outputContainer;

        var inputContainerName = config["BlobSettings:InputContainerName"]
            ?? throw new InvalidOperationException("Input container name not configured");

        var outputContainerName = config["BlobSettings:OutputContainerName"]
            ?? throw new InvalidOperationException("Output container name not configured");

        _inputContainerClient = blobServiceClient.GetBlobContainerClient(inputContainerName);
        _outputContainerClient = blobServiceClient.GetBlobContainerClient(outputContainerName);
    }

    [FunctionName("ResizeImageFromQueue")]
    public async Task RunAsync(
        [QueueTrigger("%QueueTrigger:QueueName%")] string blobName,
        ILogger logger
        )
    {
        logger.LogInformation("Received message at {Time} UTC. File name: '{BlobName}'",
            DateTime.UtcNow.ToString("o"), blobName);

        var inputBlobClient = _inputContainerClient.GetBlobClient(blobName);
        var outputBlobClient = _outputContainerClient.GetBlobClient(blobName);

        if (!await inputBlobClient.ExistsAsync())
        {
            logger.LogWarning("Blob '{BlobName}' not found in '{Container}' container.", blobName, _inputContainerClient.Name);
            return;
        }

        await using var inputStream = await inputBlobClient.OpenReadAsync();
        using var image = Image.Load(inputStream);
        image.Mutate(x => x.Resize(_width, _height));

        await using var outputStream = new MemoryStream();
        await image.SaveAsync(outputStream, new JpegEncoder());
        outputStream.Position = 0;

        await outputBlobClient.UploadAsync(outputStream, overwrite: true);
        logger.LogInformation("{Blob} | Successfully resized to {W}x{H} and uploaded to {Container}",
            blobName, _width, _height, _outputContainerClient.Name);
    }
}
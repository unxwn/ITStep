using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace HW2WebApp.Services
{
    public class BlobStorageService
    {
        private readonly BlobContainerClient _container;

        public BlobStorageService(BlobServiceClient client, IConfiguration config)
        {
            var containerName = config["BlobSettings:ContainerName"] ?? "home";
            _container = client.GetBlobContainerClient(containerName);
            _container.CreateIfNotExists();
        }

        public async Task<(string BlobName, string Url)> UploadAsync(IFormFile file)
        {
            var blobName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var blob = _container.GetBlobClient(blobName);

            await using var stream = file.OpenReadStream();
            await blob.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });

            return (blobName, blob.Uri.ToString());
        }

        public BlobClient GetBlobClient(string blobName)
        {
            return _container.GetBlobClient(blobName);
        }

        public Uri GetUri(string blobName)
            => _container.GetBlobClient(blobName).Uri;
    }
}

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace HW2WebApp.Services
{
    public class BlobStorageService
    {
        private readonly BlobContainerClient _filesContainer;
        private readonly BlobContainerClient _compressedImagesContainer;

        public BlobStorageService(BlobServiceClient blobServiceClient, IConfiguration config)
        {
            var originalContainerName = config["BlobSettings:OriginalContainer"] ?? "original-files";
            _filesContainer = blobServiceClient.GetBlobContainerClient(originalContainerName);
            _filesContainer.CreateIfNotExists();

            var compressedContainerName = config["BlobSettings:CompressedContainer"] ?? "compressed-images";
            _compressedImagesContainer = blobServiceClient.GetBlobContainerClient(compressedContainerName);
            _compressedImagesContainer.CreateIfNotExists();
        }

        public async Task<(string BlobName, string Url, string ContentType)> UploadOriginalAsync(IFormFile file)
        {
            var blobName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var blob = _filesContainer.GetBlobClient(blobName);

            await using var stream = file.OpenReadStream();
            await blob.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });

            return (blobName, blob.Uri.ToString(), file.ContentType);
        }

        public BlobClient GetBlobClient(string blobName, string contentType)
        {
            if (contentType.StartsWith("image/"))
            {
                return _compressedImagesContainer.GetBlobClient(blobName);
            }
            return _filesContainer.GetBlobClient(blobName);
        }

        public Uri GetUri(string blobName)
            => _filesContainer.GetBlobClient(blobName).Uri;
    }
}

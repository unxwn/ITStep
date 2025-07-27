# ImageResizerWebJob

A simple .NET WebJob that listens to an Azure Queue, resizes images from one Blob container, and uploads them to another.

## Features

- Listens to messages from `images-processing-queue`
- Downloads images from `original-files` container
- Resizes them (default: 700x400)
- Uploads to `compressed-images` container
- Logs activity to Application Insights

## Configuration

Set these values in `appsettings.json` or User Secrets:

```json
{
  "ConnectionStrings": {
    "AzureStorageAccount": "<your-azure-storage-connection-string>"
  },
  "APPLICATIONINSIGHTS_CONNECTION_STRING": "<your-app-insights-connection-string>",
  "AzureWebJobsStorage": "<your-web-jobs-storage-connection-string(storage account)>",
  "BlobSettings": {
    "InputContainerName": "original-files",
    "OutputContainerName": "compressed-images"
  },
  "QueueTrigger": {
    "QueueName": "images-processing-queue"
  },
  "ImageSettings": {
    "Width": 700,
    "Height": 400
  }
}

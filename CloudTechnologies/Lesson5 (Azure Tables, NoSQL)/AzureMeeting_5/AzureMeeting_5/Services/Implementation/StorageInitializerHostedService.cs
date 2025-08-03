using Azure.Data.Tables;

namespace AzureMeeting_5.Services.Implementation
{
    public class StorageInitializerHostedService(
        TableServiceClient tableServiceClient,
        IConfiguration configuration,
        ILogger<StorageInitializerHostedService> logger) : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            string tableName = configuration.GetValue<string>("AzureTableStorage:TableName") ??
                throw new InvalidOperationException("AzureTableStorage:TableName must be configured.");

            TableClient _tableClient = tableServiceClient.GetTableClient(tableName);

            logger.LogInformation("Ensuring table '{TableName}' exists...", tableName);
            await _tableClient.CreateIfNotExistsAsync(cancellationToken);
            logger.LogInformation("Table '{TableName}' is ready.", tableName);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

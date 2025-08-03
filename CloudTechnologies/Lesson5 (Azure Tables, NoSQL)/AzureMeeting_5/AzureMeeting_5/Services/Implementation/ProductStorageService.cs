using Azure.Data.Tables;
using AzureMeeting_5.Models;
using AzureMeeting_5.Services.Abstract;

namespace AzureMeeting_5.Services.Implementation
{
    public class ProductStorageService(TableClient tableClient) : ITableStorageService<Product>, IProductStorageService
    {
        public async Task<IEnumerable<Product>> GetEntitiesAsync(string? category)
        {
            var entities = category is not null
                ? tableClient.QueryAsync<Product>(t => t.PartitionKey == category)
                : tableClient.QueryAsync<Product>();

            List<Product> products = [];
            await foreach (var entity in entities)
            {
                products.Add(entity);
            }
            return products;
        }

        public async Task<Product> GetEntityAsync(string category, string rowKey)
        {
            return await tableClient.GetEntityAsync<Product>(category, rowKey);
        }

        public async Task<Product> UpsertEntityAsync(Product entity)
        {
            await tableClient.UpsertEntityAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteEntityAsync(Product entity)
        {
            var response = await tableClient.DeleteEntityAsync(entity);
            return !response.IsError;
        }

        public async Task<bool> DeleteEntityAsync(string rowKey, string category)
        {
            Product product = await GetEntityAsync(category, rowKey);
            var response = await tableClient.DeleteEntityAsync(product);
            return !response.IsError;
        }

        //private async Task<TableClient> GetTableClientAsync()
        //{
        //    string tableName = _configuration.GetValue<string>("AzureTableStorage:TableName")
        //        ?? throw new InvalidOperationException("You should set table name!");
        //    TableClient _tableClient = _tableService.GetTableClient(tableName);
        //    await _tableClient.CreateIfNotExistsAsync();
        //    return _tableClient;
        //}
    }
}

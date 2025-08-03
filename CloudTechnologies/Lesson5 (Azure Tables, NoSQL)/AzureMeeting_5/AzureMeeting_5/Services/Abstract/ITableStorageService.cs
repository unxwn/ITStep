using Azure.Data.Tables;

namespace AzureMeeting_5.Services.Abstract
{
    public interface ITableStorageService<T> where T : ITableEntity, new()
    {
        Task<IEnumerable<T>> GetEntitiesAsync(string? category);

        Task<T> GetEntityAsync(string category, string rowkey);

        Task<T> UpsertEntityAsync(T entity);

        Task<bool> DeleteEntityAsync(T entity);

        Task<bool> DeleteEntityAsync(string rowKey, string category);
    }
}

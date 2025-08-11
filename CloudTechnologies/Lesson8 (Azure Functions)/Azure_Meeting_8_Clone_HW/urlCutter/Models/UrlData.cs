using Azure;
using Azure.Data.Tables;

namespace urlCutter.Models
{
    public class UrlData : ITableEntity
    {
        public string Url { get; set; } = default!;
        public int Count { get; set; }
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}

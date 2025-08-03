using Azure;
using Azure.Data.Tables;

namespace AzureMeeting_5.Models
{
    public class Product : ITableEntity
    {
        public string Name { get; set; } = default!;

        public string Category { get; set; } = default!;

        public double Price { get; set; }
        public string PartitionKey { get; set; } = default!;
        public string RowKey { get ; set ; } = default!;
        public DateTimeOffset? Timestamp { get; set ; }
        public ETag ETag { get ; set; }
    }
}

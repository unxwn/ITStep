using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Meeting_8.Models
{
    public class UrlKey : ITableEntity
    {
        public int Id { get; set; } // 1024
        public string PartitionKey { get; set; } = default!; // "1"
        public string RowKey { get; set; } = default!; //  "Key"
        public DateTimeOffset? Timestamp { get ; set ; }
        public ETag ETag { get ; set ; }
    }
}

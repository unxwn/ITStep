namespace HW2WebApp.Models
{
    public class FileRecord
    {
        public int Id { get; set; }
        public string BlobName { get; set; } = string.Empty;
        public string OriginalName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}

using System.Text.Json.Serialization;

namespace CosmosUniversitiesApp.Models
{
    public class Course
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("credits")]
        public int Credits { get; set; }
    }
}

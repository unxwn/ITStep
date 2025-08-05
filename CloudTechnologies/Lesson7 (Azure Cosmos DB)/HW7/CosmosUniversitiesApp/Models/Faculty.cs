using Newtonsoft.Json;

namespace CosmosUniversitiesApp.Models
{
    public class Faculty
    {
        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("courses")]
        public List<Course> Courses { get; set; } = new();
    }
}

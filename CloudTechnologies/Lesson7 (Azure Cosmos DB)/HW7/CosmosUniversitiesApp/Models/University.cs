using Newtonsoft.Json;
using System.Text.Json;

namespace CosmosUniversitiesApp.Models
{
    public class University
    {
        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("faculty")]
        public Faculty Faculty { get; set; } = new();

        public override string ToString()
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            return System.Text.Json.JsonSerializer.Serialize(this, opts);
        }
    }
}

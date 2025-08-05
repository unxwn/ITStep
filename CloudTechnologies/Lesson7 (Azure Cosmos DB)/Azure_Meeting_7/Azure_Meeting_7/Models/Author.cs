using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure_Meeting_7.Models
{
    public class Author
    {
        [JsonProperty("id")]
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public Country Country { get; set; } = default!;

        public IList<Book> Books { get; set; } = default!;

        public int YearOfBirth { get; set; }

        public override string ToString()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string text = System.Text.Json.JsonSerializer.Serialize(this, options);
            return text;
        }
    }
}

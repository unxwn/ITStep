using Newtonsoft.Json;
using WebApplication1.Services.Abstraction;

namespace WebApplication1.Services.Implementation
{
    public class JsonOutputService : IOutputService
    {
        public string OutputMode => "json";
        private List<string> _lines = new List<string>();
        public void AppendLine(string text) => _lines.Add(text);
        public string GetOutput() => JsonConvert.SerializeObject(_lines, Formatting.Indented);
    }
}

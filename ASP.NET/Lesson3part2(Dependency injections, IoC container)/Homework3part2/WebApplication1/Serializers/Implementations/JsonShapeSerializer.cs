using Newtonsoft.Json;
using WebApplication1.Models.Abstractions;
using WebApplication1.Serializers.Abstractions;

namespace WebApplication1.Serializers.Implementations
{
    public class JsonShapeSerializer : IShapeSerializer
    {
        public string Format => "json";

        public void SaveShapes(IEnumerable<Shape> shapes, string filePath)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string json = JsonConvert.SerializeObject(shapes, Formatting.Indented, settings);
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<Shape> LoadShapes(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.DeserializeObject<IEnumerable<Shape>>(json, settings);
        }
  
    }
}

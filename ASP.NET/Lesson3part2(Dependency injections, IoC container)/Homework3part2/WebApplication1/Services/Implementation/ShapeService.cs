using WebApplication1.Models.Abstractions;
using WebApplication1.Serializers.Abstractions;
using WebApplication1.Services.Abstraction;

namespace WebApplication1.Services.Implementation
{
    public class ShapeService : IShapeService
    {
        private readonly IEnumerable<IShapeSerializer> _serializers;

        public ShapeService(IEnumerable<IShapeSerializer> serializers)
        {
            _serializers = serializers;
        }

        private IShapeSerializer GetSerializer(string format)
        {
            var serializer = _serializers.FirstOrDefault(s =>
                s.Format.Equals(format, StringComparison.OrdinalIgnoreCase));
            if (serializer == null)
                throw new Exception($"Serializer for format '{format}' not found.");
            return serializer;
        }
        public void SaveShapes(IEnumerable<Shape> shapes, string filePath, string format)
        {
            var serializer = GetSerializer(format);
            serializer.SaveShapes(shapes, filePath);
        }
        public IEnumerable<Shape> LoadShapes(string filePath, string format)
        {
            var serializer = GetSerializer(format);
            return serializer.LoadShapes(filePath);
        }
    }
}

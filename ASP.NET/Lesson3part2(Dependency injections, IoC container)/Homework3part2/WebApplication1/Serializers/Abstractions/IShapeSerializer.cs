using WebApplication1.Models.Abstractions;

namespace WebApplication1.Serializers.Abstractions
{
    public interface IShapeSerializer
    {
        string Format { get; }
        void SaveShapes(IEnumerable<Shape> shapes, string filePath);
        IEnumerable<Shape> LoadShapes(string filePath);
    }
}

using WebApplication1.Models.Abstractions;

namespace WebApplication1.Services.Abstraction
{
    public interface IShapeService
    {
        void SaveShapes(IEnumerable<Shape> shapes, string filePath, string format);
        IEnumerable<Shape> LoadShapes(string filePath, string format);
    }
}

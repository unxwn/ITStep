using WebApplication1.Models.Abstractions;
using WebApplication1.Models.Implementations;
using WebApplication1.Serializers.Abstractions;

namespace WebApplication1.Serializers.Implementations
{
    public class TxtShapeSerializer : IShapeSerializer
    {
        public string Format => "txt";
        public void SaveShapes(IEnumerable<Shape> shapes, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var shape in shapes)
                {
                    if (shape is Circle c)
                        writer.WriteLine($"Circle|{c.Radius}");
                    else if (shape is Square s)
                        writer.WriteLine($"Square|{s.Side}");
                    else if (shape is Triangle t)
                        writer.WriteLine($"Triangle|{t.BaseLength},{t.Height}");
                }
            }
        }
        public IEnumerable<Shape> LoadShapes(string filePath)
        {
            var list = new List<Shape>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length != 2) continue;
                    string type = parts[0];
                    var props = parts[1].Split(',');
                    if (type == "Circle" && props.Length == 1 && double.TryParse(props[0], out double radius))
                        list.Add(new Circle(radius));
                    else if (type == "Square" && props.Length == 1 && double.TryParse(props[0], out double side))
                        list.Add(new Square(side));
                    else if (type == "Triangle" && props.Length == 2 &&
                             double.TryParse(props[0], out double b) &&
                             double.TryParse(props[1], out double h))
                        list.Add(new Triangle(b, h));
                }
            }
            return list;
        }
    }
}

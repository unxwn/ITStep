using WebApplication1.Models.Abstractions;

namespace WebApplication1.Models.Implementations
{
    public class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }
        public override string Name => "Triangle";

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override string Draw() => $"Triangle with base {BaseLength} and height {Height}.";
    }
}

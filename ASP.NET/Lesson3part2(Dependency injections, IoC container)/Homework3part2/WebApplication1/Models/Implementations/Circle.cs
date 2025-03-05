using WebApplication1.Models.Abstractions;

namespace WebApplication1.Models.Implementations
{
    public class Circle : Shape
    {
        public override string Name => "Circle";
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string Draw() => $"Circle with radius {Radius}.";
    }
}

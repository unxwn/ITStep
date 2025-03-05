using WebApplication1.Models.Abstractions;

namespace WebApplication1.Models.Implementations
{
    public class Square : Shape
    {
        public double Side { get; set; }
        public override string Name => "Square";

        public Square(double side)
        {
            Side = side;
        }

        public override string Draw() => $"Square with side {Side}.";
    }
}

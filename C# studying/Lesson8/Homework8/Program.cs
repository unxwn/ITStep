using System;

namespace Homework8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DecimalNumber number = new DecimalNumber(17164);
            Console.WriteLine("Decimal: " + number);
            Console.WriteLine("Binary: " + number.ToBinary());
            Console.WriteLine("Octal: " + number.ToOctal());
            Console.WriteLine("Hexadecimal: " + number.ToHexadecimal());

            Console.WriteLine("\n\n**Vectors**");
            Vector3D v1 = new Vector3D(-1, 2, -3);
            Vector3D v2 = new Vector3D(4, -5, 6);

            Vector3D result1 = v1 * 2;
            Vector3D result2 = v1 + v2;
            Vector3D result3 = v1 - v2;

            Console.WriteLine($"v1 = {v1}");
            Console.WriteLine($"v2 = {v2}\n");
            Console.WriteLine($"v1 * 2 = {result1}");
            Console.WriteLine($"v1 + v2 = {result2}");
            Console.WriteLine($"v1 - v2 = {result3}");
        }
    }
}

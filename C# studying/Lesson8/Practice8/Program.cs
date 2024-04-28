using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**Fractions**");

            Fraction fraction1 = new Fraction(5, 7);
            Fraction fraction2 = new Fraction(15, 5);

            Console.WriteLine($"Fraction1 = {fraction1}");
            Console.WriteLine($"Fraction2 = {fraction2}\n");

            Fraction sum = fraction1.Add(fraction2);
            Fraction difference = fraction1.Subtract(fraction2);
            Fraction product = fraction1.Multiply(fraction2);
            Fraction division = fraction1.Divide(fraction2);

            Console.WriteLine($"{fraction1} + {fraction2} = {sum}");
            Console.WriteLine($"{fraction1} - {fraction2} = {difference}");
            Console.WriteLine($"{fraction1} * {fraction2} = {product}");
            Console.WriteLine($"{fraction1} / {fraction2} = {division}");


            Console.WriteLine("\n**Complex numbers**");
              
            ComplexNumber z1 = new ComplexNumber(1, 2);
            ComplexNumber z2 = new ComplexNumber(3, -4);

            Console.WriteLine($"z1 = {z1}");
            Console.WriteLine($"z2 = {z2}\n");

            Console.WriteLine($"z1 + z2 = {ComplexNumber.Add(z1, z2)}"); 
            Console.WriteLine($"z1 - z2 = {ComplexNumber.Subtract(z1, z2)}"); 
            Console.WriteLine($"z1 * z2 = {ComplexNumber.Multiply(z1, z2)}"); 
            Console.WriteLine($"z1 / z2 = {ComplexNumber.Divide(z1, z2)}"); 
        }
    }
}

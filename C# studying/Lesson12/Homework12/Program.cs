using System;
using System.IO;
using Newtonsoft.Json;

namespace Homework12
{
    internal struct Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Add(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Denominator + fraction.Numerator * Denominator;
            int newDenominator = Denominator * fraction.Denominator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public Fraction Subtract(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Denominator - fraction.Numerator * Denominator;
            int newDenominator = Denominator * fraction.Denominator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public Fraction Multiply(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Numerator;
            int newDenominator = Denominator * fraction.Denominator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public Fraction Divide(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Denominator;
            int newDenominator = Denominator * fraction.Numerator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public int GetGreatestCommonDivisor(int a, int b) // 25, 10
        {
            if (a < b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            while (b != 0)
            {
                int temp = b; // 10 // 5 
                b = a % b; // 5 // 0
                a = temp; // 10 // 5
            }
            return a; // 5
        }

        public Fraction Simplify()
        {
            int gcd = GetGreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
            return new Fraction(Numerator, Denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    internal class FractionArray
    {
        private Fraction[] fractions;

        public FractionArray(int size)
        {
            fractions = new Fraction[size];
        }

        public void InputFractions()
        {
            for (int i = 0; i < fractions.Length; i++)
            {
                Console.WriteLine($"Enter fraction {i + 1} (numerator/denominator):");
                string[] input = Console.ReadLine().Split('/');
                int numerator = int.Parse(input[0]);
                int denominator = int.Parse(input[1]);
                fractions[i] = new Fraction(numerator, denominator);
            }
        }

        public void SerializeAndSaveToFile(string filename)
        {
            string json = JsonConvert.SerializeObject(fractions, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(json);
            }
        }

        public void LoadAndDeserializeFromFile(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string json = sr.ReadToEnd();
                fractions = JsonConvert.DeserializeObject<Fraction[]>(json);
            }
        }

        public void DisplayFractions()
        {
            foreach (var fraction in fractions)
            {
                Console.WriteLine(fraction.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of fractions: ");
            int size = int.Parse(Console.ReadLine());
            FractionArray fractionArray = new FractionArray(size);
            fractionArray.InputFractions();

            fractionArray.SerializeAndSaveToFile("fractions.json");

            Console.WriteLine("Serialized and saved to file.");

            fractionArray.LoadAndDeserializeFromFile("fractions.json");

            Console.WriteLine("Loaded and deserialized from file:");
            fractionArray.DisplayFractions();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Library;
using Task3Library;

namespace Practice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Console.WriteLine("Task 1");

            Console.WriteLine("Even nums: ");

            int[] EvenNumber = Task1Library.Task.EvenNums(-17, -12);

            foreach (int el in EvenNumber)
            {
                Console.Write($"{el} ");
            }

            Console.WriteLine("\nOdd nums: ");

            int[] OddNumber = Task1Library.Task.OddNums(-18, 0);

            foreach (int el in OddNumber)
            {
                Console.Write($"{el} ");
            }

            Console.WriteLine("\nSimple nums: ");

            int[] primeNums = Task1Library.Task.PrimeNums(2, 100);

            foreach (int el in primeNums)
            {
                Console.Write($"{el} ");
            }

            Console.WriteLine("\nFibonacci nums: ");

            int[] FibonacciNums = Task1Library.Task.FibonacciNums(10, 100);

            foreach (int el in FibonacciNums)
            {
                Console.Write($"{el} ");
            }

            // Task 3
            Console.WriteLine("\n\nTask 3");

            Task3Library.Task game = new Task3Library.Task();
            game.Start(31);
        }
    }
}

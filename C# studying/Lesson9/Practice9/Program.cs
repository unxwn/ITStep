using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Tasks<int>.GetSum(new int[] { 1, 2, 3333}));
            Console.WriteLine(Tasks<double>.GetMaxValue(3, 2, 3.00000000000001));
            Console.WriteLine(Tasks<double>.GetMinValue(3, 1.999999999999999, 2));

            Console.WriteLine("\n\n**Stack**");
            Stack<int> intStack = new Stack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            intStack.Push(4);
            intStack.Push(5);
            intStack.Push(6);
            intStack.Push(7);
            intStack.Push(21);

            Console.WriteLine("Count: " + intStack.Count);
            Console.WriteLine("Pop: " + intStack.Pop());
            Console.WriteLine("Peek: " + intStack.Peek());
            Console.WriteLine("Count: " + intStack.Count);
            intStack.DisplayStack();
        }
    }
}

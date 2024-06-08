using System;

namespace HW14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 111, 90, 82, 43, 22, 1111 };

            Array.Sort(numbers, (a, b) => SumOfDigits(a).CompareTo(SumOfDigits(b)));
            Console.WriteLine("Sorting by ascending sum of digits of num: " + string.Join(", ", numbers));

            Array.Sort(numbers, (a, b) => SumOfDigits(b).CompareTo(SumOfDigits(a)));
            Console.WriteLine("Sorting by descending sum of digits of num: " + string.Join(", ", numbers));

            int SumOfDigits(int number)
            {
                int sum = 0;
                while (number != 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                return sum;
            }
        }
    }
}

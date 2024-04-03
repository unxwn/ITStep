using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); 

            // Завдання: 2, 3, 6

            // Завдання 2
            Console.WriteLine("Task 2");

            double[,] matrix = new double[2, 3];

            int[] minNumIndex = {0, 0}, maxNumIndex = {0, 0};

            double sum = 0;

            Console.WriteLine("Matrix:");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-100, 100) + Math.Round(rnd.NextDouble(), 2);
                    //matrix[i, j] = rnd.Next(1) + 99;
                    Console.Write($"{matrix[i, j], 6}  ");

                    if (matrix[i, j] < matrix[minNumIndex[0], minNumIndex[1]])
                    {
                        minNumIndex[0] = i;
                        minNumIndex[1] = j;
                    }
                    else if (matrix[i, j] > matrix[maxNumIndex[0], maxNumIndex[1]])
                    {
                        maxNumIndex[0] = i;
                        maxNumIndex[1] = j;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"min num: i = {minNumIndex[0]}, j = {minNumIndex[1]}");
            Console.WriteLine($"max num: i = {maxNumIndex[0]}, j = {maxNumIndex[1]}");

            int minRow = Math.Min(minNumIndex[0], maxNumIndex[0]);
            int maxRow = Math.Max(minNumIndex[0], maxNumIndex[0]);
            int minCol = Math.Min(minNumIndex[1], maxNumIndex[1]);
            int maxCol = Math.Max(minNumIndex[1], maxNumIndex[1]);

            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = (i == minRow ? minCol + 1 : 0); j <= (i == maxRow ? maxCol - 1 : matrix.GetLength(1) - 1); j++)
                {
                    sum += matrix[i, j];
                }

            }
            
            Console.WriteLine("Sum = " + sum);
        }
    }
}

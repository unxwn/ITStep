using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Завдання: 3, 4, 5, 7 (поєднав із 6), 9

            // Завдання 3
            Console.WriteLine("Task 3");
            int[] array = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5, 7, 8, 6, 5 };

            int[] inputNumsArr = new int[3];

            Console.Write($"\nArray:");
            foreach (int el in array) { Console.Write($" {el}"); }

            Console.WriteLine();

            for (int i = 0; i < inputNumsArr.Length; i++)
            {
                Console.Write($"Write num{i + 1}: ");
                inputNumsArr[i] = int.Parse(Console.ReadLine());
            }

            int repeatitCounter = 0;
            bool isStreak;

            for (int i = 0; i < array.Length; i++)
            {
                isStreak = false;

                if (array[i] == inputNumsArr[0])
                {
                    isStreak = true;

                    for (int j = 1; j < 3; j++)
                    {
                        if (array[i + j] != inputNumsArr[j])
                        {
                            isStreak = false;
                        }
                    }
                }

                if (isStreak)
                {
                    repeatitCounter++;
                }
            }

            Console.Write($"User write:");
            foreach (int el in inputNumsArr) { Console.Write($" {el}"); }


            Console.WriteLine($"\nRepetition quantity: {repeatitCounter}");

            // Завдання 4
            int[] arrM = { 1, 2, 3, 4, 5, 1, 6, 7 };
            int[] arrN = { 1, 4, 6, 9, 1, 9, 3 };
            int[] arrIntersection = new int[(arrM.Length + arrN.Length) / 2];

            int indexIntersect = 0;

            bool skip;

            foreach (int elM in arrM)
            {
                skip = false;

                foreach (int elIntersect in arrIntersection)
                {
                    if (elIntersect == elM)
                    {
                        skip = true;
                    }
                }

                if (skip) { continue; }

                foreach (int elN in arrN)
                {
                    if (elM == elN)
                    {
                        arrIntersection[indexIntersect++] = elM;
                        break;
                    }
                }
            }

            Console.Write("\n\nTask4\nArray M:");
            foreach (int elM in arrM) { Console.Write($" {elM}"); }

            Console.Write("\nArray N:");
            foreach (int elN in arrN) { Console.Write($" {elN}"); }

            Console.Write("\nItem from arrM in arrN:");
            for (int i = 0; i < indexIntersect; i++) { Console.Write($" {arrIntersection[i]}"); }

            // Завдання 5
            Random random = new Random();

            int[,] matrix = new int[3, 3];


            Console.WriteLine("\n\n\nTask 5\nMatrix:");

            // Matrix filling
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    matrix[i, j] = random.Next(10);

                    Console.Write($"{matrix[i, j]}  ");
                }
                Console.WriteLine();
            }

            int minNum = matrix[0, 0], maxNum = matrix[0, 0];

            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    int el = matrix[i, j];
                    if (el < minNum) { minNum = el; }
                    if (el > maxNum) { maxNum = el; }
                }
            }

            Console.WriteLine($"Min num: {minNum}\nMax num: {maxNum}");

            // Завдання 7
            string testStr = "sun cat dogs, cup tea";

            int wordsCounter = 0;

            string[] arr = testStr.Split(new[] { ' ', ',' });

            Console.WriteLine($"\n\nTask 7\nInput str: {testStr}");

            Console.Write($"Output str: ");

            foreach (string str in arr)
            {
                if (str != "")
                {
                    wordsCounter++;

                    Console.Write($"{String.Join("", str.Reverse())} ");
                }
            }

            Console.WriteLine("\nNum of words in str: " + wordsCounter);

            // Завдання 9. Трохи накостиляв :) 
            string testString = "Why she had to go. I don't know, she wouldn't say";

            string substring;

            string tempStr;

            Console.WriteLine("\n\nTask 9\nString: " + testString);
            Console.Write("Write subtring to looking for: ");
            substring = Console.ReadLine();

            int substrCounter = 0;

            int indexOfFirst = testString.IndexOf(substring);

            while (indexOfFirst != -1)
            {
                substrCounter++;

                tempStr = testString.Substring(0, indexOfFirst);

                testString = tempStr + testString.Substring(indexOfFirst + substring.Length);

                indexOfFirst = testString.IndexOf(substring);
            }

            Console.WriteLine("Find result: " + substrCounter);
        }
    }
}

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

            // Завдання: 2, 3

            // Завдання 2
            Console.WriteLine("Task 2");

            double[,] matrix = new double[2, 5];

            int[] minNumIndex = { 0, 0 }, maxNumIndex = { 0, 0 };

            double sum = 0;

            Console.WriteLine("Matrix:");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-100, 100) + Math.Round(rnd.NextDouble(), 2);
                    //matrix[i, j] = rnd.Next(1) + 99;
                    Console.Write($"{matrix[i, j],6}  ");

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

            int[] minNumI = { 0, 0 };
            int[] maxNumI = { 0, 0 };

            int row1 = minNumIndex[0];
            int row2 = maxNumIndex[0];

            if (row1 == row2)
            {
                minNumI[0] = row1;
                minNumI[1] = Math.Min(minNumIndex[1], maxNumIndex[1]);
                maxNumI[0] = row2;
                maxNumI[1] = Math.Max(minNumIndex[1], maxNumIndex[1]);
            }
            else if (row1 > row2)
            {
                minNumI[0] = row2;
                minNumI[1] = maxNumIndex[1];
                maxNumI[0] = row1;
                maxNumI[1] = minNumIndex[1];
            }
            else
            {
                minNumI[0] = minNumIndex[0];
                minNumI[1] = minNumIndex[1];
                maxNumI[0] = maxNumIndex[0];
                maxNumI[1] = maxNumIndex[1];
            }

            for (int i = minNumI[0]; i <= maxNumI[0]; i++)
            {
                for (int j = (i == minNumI[0] ? minNumI[1] + 1 : 0); j <= (i == maxNumI[0] ? maxNumI[1] - 1 : matrix.GetLength(1) - 1); j++)
                {
                    sum += matrix[i, j];
                }

            }

            Console.WriteLine("Sum of elements between min and max elements = " + sum);

            // Завдання 3
            // encoding
            string strToEncode;
            int keyToEncode;

            Console.Write("\n\nTask 3\nWrite encryption key for the Caesar Cipher: ");
            keyToEncode = int.Parse(Console.ReadLine());

            Console.WriteLine("Write string to encode: ");
            strToEncode = Console.ReadLine();

            string encodedStr = "";

            foreach (char el in strToEncode)
            {
                if (char.IsLetter(el))
                {
                    if (char.IsUpper(el))
                    {
                        int indexWithCipher = ((el - 'A') + keyToEncode) % 26;
                        char newChar = (char)('A' + indexWithCipher);
                        encodedStr += newChar;
                    }
                    else if (char.IsLower(el))
                    {
                        int indexWithCipher = ((el - 'a') + keyToEncode) % 26;
                        char newChar = (char)('a' + indexWithCipher);
                        encodedStr += newChar;
                    }
                }
                else
                {
                    encodedStr += el;
                }
            }

            Console.WriteLine($"Your encoded str:\n{encodedStr}");

            // decoding
            string strToDecode;
            int keyToDecode;

            Console.Write("\nDecoding\nWrite decryption key for the Caesar Cipher: ");
            keyToDecode = int.Parse(Console.ReadLine());

            Console.WriteLine("Write your string to decode: ");
            strToDecode = Console.ReadLine();

            string decodedStr = "";

            foreach (char el in strToDecode)
            {
                if (char.IsLetter(el))
                {
                    if (char.IsUpper(el))
                    {
                        int indexWithCipher = ((el - 'A') - keyToEncode + 26) % 26;
                        char newChar = (char)('A' + indexWithCipher);
                        decodedStr += newChar;
                    }
                    else if (char.IsLower(el))
                    {
                        int indexWithCipher = ((el - 'a') - keyToEncode + 26) % 26;
                        char newChar = (char)('a' + indexWithCipher);
                        decodedStr += newChar;
                    }
                }
                else
                {
                    decodedStr += el;
                }
            }

            Console.WriteLine($"Your string decoded by program:\n{decodedStr}");

            // Task 6
            string text = "sentece, one... sentence; 2.\n sentece 51. sentece last.\n";

            string[] sentences = text.Split(new string[] { "... ", "\n ", ". ", "." }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentences.Length; i++)
            {
                sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
            }

            string outStr = String.Join(". ", sentences);

            Console.WriteLine("\n\nTask 6");

            Console.WriteLine(outStr);
        }
    }
}

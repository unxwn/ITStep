using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    internal class Practice
    {
        static void Main(string[] args)
        {
            // Завдання 1. Виведіть на екран цитату Б'ярна Страуструпа
            Console.WriteLine("It's easy to win forgiveness for being wrong;\n" +
                "being right is what gets you into real trouble.\n" +
                "Bjarne Stroustrup\n\n");

            /*Завдання 2. Користувач вводить з клавіатури п'ять чисел. 
            Необхідно знайти суму чисел, максимум і мінімум з п'яти чисел,
            добуток чисел. Результат обчислень вивести на екран.*/
            const int arrSize = 5;
            int[] numbers = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                Console.WriteLine($"Enter num {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Your numbers:");
            foreach (int el in numbers)
            {
                Console.Write($"{el} ");
            }

            Console.WriteLine("\n\nResults:");

            // sum
            int sum = 0;

            foreach (int i in numbers)
            {
                sum += i;
            }

            Console.WriteLine($"Sum = {sum}");

            // max num
            int maxNum = numbers[0];

            foreach (int el in numbers)
            {
                if (el > maxNum) { maxNum = el; };
            }

            Console.WriteLine($"Max = {maxNum}");

            // min num
            int minNum = numbers[0];

            foreach (int el in numbers)
            {
                if (el < minNum) { minNum = el; };
            }

            Console.WriteLine($"Min = {minNum}");

            // product
            int product = 1;

            foreach (int el in numbers)
            {
                product *= el;
            }

            Console.WriteLine($"Product = {product}");

            /*Завдання 3. Користувач з клавіатури вводить шестизначне число.
            Необхідно перевернути число і відобразити результат.
            Наприклад, якщо введено 341256, результат 652143.*/
            Console.Write("\n");
            string numStr;
            do
            {
                Console.Write("\nEnter your number: ");
                numStr = Console.ReadLine();
            } while (numStr.Length != 6);

            string resultNum = "";

            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                resultNum += numStr[i];
            }

            Console.Write("Reversed number: ");

            foreach (char el in resultNum)
            {
                Console.Write(el);
            }
            Console.WriteLine();

            /*Завдання 4. Числа Фібоначчі*/
            int prevNum = 0, currNum = 0, nextNum = 1;
            int downLim, upLim; // діапазон

            Console.Write("\n\nWrite down limit of range: ");
            downLim = int.Parse(Console.ReadLine());
            while (downLim < 0)
            {
                Console.Write("Write correct down limit of range: ");
                downLim = int.Parse(Console.ReadLine());
            }

            Console.Write("Write up limit of range: ");
            upLim = int.Parse(Console.ReadLine());
            while (upLim <= downLim)
            {
                Console.Write("Write correct up limit of range: ");
                upLim = int.Parse(Console.ReadLine());
            }

            Console.Write($"Fibonacci sequence in your range ({downLim}-{upLim}):\n");

            while (nextNum <= upLim)
            {
                if (currNum >= downLim) Console.Write($"{currNum}, ");

                prevNum = currNum;
                currNum = nextNum;
                nextNum = prevNum + currNum;
            }

            Console.Write($"{currNum}\n\n\n");

            /*Завданян 5. Дано цілі додатні числа A і B (A < B). Вивести усі цілі
            числа від A до B включно; кожне число має виводитися у
            новому рядку; при цьому кожне число має виводитися у
            кількість разів, рівну його значенню*/
            uint A, B;

            Console.WriteLine("Write A: ");
            A = uint.Parse(Console.ReadLine());

            Console.WriteLine("Write B: ");
            B = uint.Parse(Console.ReadLine());

            Console.WriteLine();

            for (uint i = A; i <= B; i++)
            {
                for (uint j = 0; j < i; j++)
                {
                    Console.Write($"{i} ");
                }

                Console.WriteLine();
            }

            /*Завдання 6. Користувач з клавіатури вводить довжину лінії, символ
            заповнювач, напрямок лінії (горизонтальна, вертикальна).*/
            uint lineLenght;
            char placeholder;
            bool direct; // true - horizontal, false vertical

            Console.WriteLine("\n\nWrite length of line: ");
            lineLenght = uint.Parse(Console.ReadLine());

            Console.WriteLine("Write placeholdaer: ");
            placeholder = char.Parse(Console.ReadLine());

            Console.WriteLine("Write direct (true - horizontal, false - vertical): ");
            direct = bool.Parse(Console.ReadLine());

            for (uint i = 0; i < lineLenght; i++)
            {
                switch (direct)
                {
                    case true:
                        Console.Write(placeholder);
                        break;
                    case false:
                        Console.WriteLine(placeholder);
                        break;
                }
            }
        }
    }
}

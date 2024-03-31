using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Homework
    {
        static void Main(string[] args)
        {
            /*Користувач вводить з клавіатури число від 1 до 100.
            Якщо число кратне 3 (ділиться на 3 без залишку), потрібно
            вивести слово Fizz. Якщо число кратне 5, потрібно вивести
            слово Buzz. Якщо число кратне 3 і 5, потрібно вивести Fizz
            Buzz. Якщо число не кратне ні 3, ані 5, потрібно вивести
            тільки число.
            Якщо користувач ввів значення не в діапазоні від 1
            до 100, потрібно вивести повідомлення про помилку.*/
            Console.WriteLine("Task 1");

            int num = 0;

            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());

            if (num < 1 || num > 100) Console.WriteLine("Wrong number!");

            if (num % 3 == 0 && num % 5 == 0) Console.WriteLine("Fizz Buzz");
            else if (num % 3 == 0) Console.WriteLine("Fizz");
            else if (num % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(num);

            /*Завдання 2. Користувач вводить з клавіатури два числа. Перше
            число — це значення, друге число — відсоток, який необхідно підрахувати.*/
            Console.WriteLine("\n\nTask 2");
            double inputtedNum, percent, result;

            Console.Write("Enter number: ");
            inputtedNum = int.Parse(Console.ReadLine());

            Console.Write("Enter percent: ");
            percent = int.Parse(Console.ReadLine());

            result = inputtedNum * percent / 100;

            Console.WriteLine($"Result = {result}");

            /*Завдання 3. Користувач вводить з клавіатури чотири цифри. 
             * Необхідно створити число, яке містить ці цифри. 
             * Наприклад, якщо з клавіатури введено 1, 5, 7, 8
             * тоді потрібно сформувати число 1578*/
            Console.WriteLine("\n\nTask 3");
            const int arrSize = 4;
            int[] numbers = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                Console.WriteLine($"Enter num {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Your number:");
            foreach (int el in numbers)
            {
                Console.Write($"{el}");
            }

            /*Завдання 4. Користувач вводить шестизначне число. 
            Потім, користувач вводить номери розрядів для заміни цифр.
            Наприклад, якщо користувач ввів 1 і 6 — це означає, що
            треба поміняти місцями першу та шосту цифри.
            Число 723895 має перетворитися на 523897.
            Якщо користувач ввів не шестизначне число, потрібно
            вивести повідомлення про помилку*/
            Console.WriteLine("\n\n\nTask 4");

            string inputtedStr, ResultStr = "";
            char tempChar;

            Console.WriteLine("Write a six-digit num: ");
            inputtedStr = Console.ReadLine();

            if (inputtedStr.Length == 6)
            {
                tempChar = inputtedStr[0];

                ResultStr += inputtedStr[inputtedStr.Length - 1];

                for (int i = 1; i < inputtedStr.Length - 1; i++) // до передостанього включно, а останій запвонимо першим з inputtedStr
                {
                    ResultStr += inputtedStr[i];
                }

                ResultStr += tempChar;

                Console.WriteLine($"Result string: {ResultStr}");
            }
            else Console.WriteLine("You write wrong num");

            /*Завданян 5. Користувач вводить з клавіатури дату. Додаток має
            відобразити назву пори року і дня тижня. Наприклад,
            якщо введено 22.12.2021, додаток має відобразити Winter
            Wednesday*/
            Console.WriteLine("\n\nTask 5");
            string inputtedString;
            Console.WriteLine("Enter date in dd.mm.yyyy format:");
            inputtedString = Console.ReadLine();

            string[] dateParts = inputtedString.Split('.');
            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            DateTime date = new DateTime(year, month, day);

            string season;
            if (month == 12 || month <= 2) season = "Winter";
            else if (month >= 3 && month <= 5) season = "Spring";
            else if (month >= 6 && month <= 8) season = "Summer";
            else season = "Autumn";

            string dayOfWeek = date.DayOfWeek.ToString();

            Console.WriteLine($"{season} {dayOfWeek}");

            /*Завдання 6. Користувач вводить з клавіатури показання температури. 
            Залежно від вибору користувача, додаток конвертує
            температуру з Фаренгейта в Цельсій, або навпаки. */
            Console.WriteLine("\n\nTask 6");
            double inputtedTemperture, resultTemp;
            string unit;

            Console.WriteLine("Write temperture: ");
            inputtedTemperture = double.Parse(Console.ReadLine());

            Console.WriteLine("Write unit\nc - Celsius\nf - Fahrenheit");
            unit = Console.ReadLine();

            if (unit.Equals("f"))
            {
                resultTemp = (inputtedTemperture - 32) / 1.8;
                Console.WriteLine($"Temperture in Celsius = {resultTemp}");
            }
            else if (unit.Equals("c"))
            {
                resultTemp = (inputtedTemperture * 1.8) + 32;
                Console.WriteLine($"Temperture in Fahrenheit = {resultTemp}");
            }

            /*Завдання 7. Користувач вводить з клавіатури два числа. Потрібно 
            показати усі парні числа у вказаному діапазоні. Якщо
            межі діапазону вказані неправильно, потрібно провести
            нормалізацію кордонів*/
            Console.WriteLine("\n\nTask 7");
            int downLim, upLim;

            Console.WriteLine("Write downLim: ");
            downLim = int.Parse(Console.ReadLine());

            Console.WriteLine("Write upLim:");
            upLim = int.Parse(Console.ReadLine());

            if (downLim > upLim)
            {
                int temp = downLim;
                downLim = upLim;
                upLim = temp;
            }

            if (downLim % 2 != 0) downLim++;

            for (int i = downLim; i <= upLim; i += 2) Console.Write($"{i} ");

            Console.WriteLine();
        }
    }
}

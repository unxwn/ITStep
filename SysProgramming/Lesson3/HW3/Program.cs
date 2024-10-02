using System;
using System.Diagnostics;
using System.Threading;

namespace HW3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the 'Reaction time' game!");
            Console.WriteLine("Press the spacebar when you see text 'NOW!' in console");
            Console.WriteLine("Press Enter to start...");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                Console.WriteLine("Get ready...");

                Random rand = new Random();
                int delay = rand.Next(2000, 5001);
                Stopwatch preparationTime = new Stopwatch();
                preparationTime.Start();

                bool falseStart = false;
                while (preparationTime.ElapsedMilliseconds < delay)
                {
                    if (Console.KeyAvailable)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                        {
                            falseStart = true;
                            break;
                        }
                    }
                    Thread.Sleep(10);
                }

                if (falseStart)
                {
                    Console.Clear();
                    Console.WriteLine("FALSE START!");
                    Thread.Sleep(2000);
                    continue;
                }

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("NOW!");
                Console.ResetColor();

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"\nYour reaction time: {stopwatch.ElapsedMilliseconds} ms");
                }
                else
                {
                    Console.WriteLine("\nYou didn't press the spacebar. Try again.");
                }

                Console.WriteLine("\nPress Enter to try again, or 'q' to quit.");
                if (Console.ReadLine().ToLower() == "q")
                {
                    break;
                }
            }

            Console.WriteLine("Thank you for playing!");
        }
    }
}

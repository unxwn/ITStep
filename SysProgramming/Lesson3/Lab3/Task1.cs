using System;
using System.Collections.Generic;
using System.Threading;

namespace Lesson3
{
    internal class Task1
    {
        static void Main()
        {
            Console.WriteLine("Main thread is started");
            Console.WriteLine("Task1:");
            List<object> collection = new List<object>
            {
                "Hello World",
                00000,
                DateTime.Now
            };

            ParameterizedThreadStart TS = new ParameterizedThreadStart(PerformToString);
            Thread T = new Thread(TS);
            T.Start(collection);
            //T.Join();

            Console.WriteLine("Task2:");
            Bank myBank = new Bank();
            myBank.UpdateName("MyAcc");
            myBank.UpdateMoney(1000000);
            myBank.UpdatePercent(5);

            myBank.UpdateMoney(1500000);
            myBank.UpdatePercent(6);

            Console.WriteLine("Main thread is ended");
        }

        static void PerformToString(object obj)
        {
            Console.WriteLine("Performing ToString():");
            if (obj is IEnumerable<object> collection)
            {
                foreach (var item in collection)
                {
                    string result = item.ToString();
                    Console.WriteLine(result);
                }
            }
        }
    }
}

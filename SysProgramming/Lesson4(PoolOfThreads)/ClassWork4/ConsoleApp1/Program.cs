using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ThreadsCount;
            int StreamsCount;
            ThreadPool.GetAvailableThreads(out ThreadsCount, out StreamsCount);
            Console.WriteLine($"{ThreadsCount}\t{StreamsCount}");

            Console.WriteLine("Main thread started");
            Random rand = new Random();
            ThreadPool.GetAvailableThreads(out ThreadsCount, out StreamsCount);
            Console.WriteLine($"{ThreadsCount}\t{StreamsCount}");

            ThreadPool.QueueUserWorkItem((object obj) =>
            {
                for (int i = 0; i < 1123123123; i++)
                {
                    //ThreadPool.QueueUserWorkItem(Method1, rand.Next(-10, 10));
                    ThreadPool.QueueUserWorkItem(DoLoad, rand.Next(0, 3));
                }
            }, rand.Next(-10, 10));

            Thread.Sleep(5000);
            Console.ReadKey();
            ThreadPool.GetAvailableThreads(out ThreadsCount, out StreamsCount);
            Console.WriteLine($"{ThreadsCount}\t{StreamsCount}");
            //ThreadPool.GetAvailableThreads(out ThreadsCount, out StreamsCount);
            //Console.WriteLine($"{ThreadsCount}\t{StreamsCount}");
            //Thread.Sleep(3000);
            //Console.WriteLine("Main thread stopped");
            //ThreadPool.GetAvailableThreads(out ThreadsCount, out StreamsCount);
            //Console.WriteLine($"{ThreadsCount}\t{StreamsCount}");
            //Console.ReadLine();
        }
        static void Method1(object obj) {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} - {obj}");
            Thread.Sleep(500);
        }

        static void DoLoad(object obj)
        {
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}

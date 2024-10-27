using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6_TaskAboutPhilosophes_
{
    internal class Program
    {
        static readonly int NUM_OF_PHILOSOPHERS = 5;
        static readonly object[] Forks = new object[NUM_OF_PHILOSOPHERS];
        static readonly Random Random = new Random();

        static void Main()
        {
            for (int i = 0; i < NUM_OF_PHILOSOPHERS; i++)
            {
                Forks[i] = new object();
            }

            Thread[] philosophers = new Thread[NUM_OF_PHILOSOPHERS];
            for (int i = 0; i < NUM_OF_PHILOSOPHERS; i++)
            {
                int philosopherNum = i;
                philosophers[i] = new Thread(() => Philosopher(philosopherNum));
                philosophers[i].Start();
            }

            foreach (Thread philosopher in philosophers)
            {
                philosopher.Join();
            }
        }

        static void Philosopher(int philosopherNum)
        {
            while (true)
            {
                Think(philosopherNum);
                Eat(philosopherNum);
            }
        }

        static void Think(int philosopherNum)
        {
            Console.WriteLine($"Philosopher {philosopherNum} is thinking.");
            Thread.Sleep(Random.Next(5000, 20000));
        }

        static void Eat(int philosopherNum)
        {
            int leftFork = philosopherNum;
            int rightFork = (philosopherNum + 1) % NUM_OF_PHILOSOPHERS;

            if (Monitor.TryEnter(Forks[leftFork], 1000))
            {
                try
                {
                    Console.WriteLine($"Philosopher {philosopherNum} picked up left fork {leftFork}.");

                    if (Monitor.TryEnter(Forks[rightFork], 1000))
                    {
                        try
                        {
                            Console.WriteLine($"Philosopher {philosopherNum} picked up right fork {rightFork}.");
                            Console.WriteLine($"Philosopher {philosopherNum} is eating.");
                            Thread.Sleep(Random.Next(5000, 8000));
                            Console.WriteLine($"Philosopher {philosopherNum} finished eating.");
                        }
                        finally
                        {
                            Monitor.Exit(Forks[rightFork]);
                            Console.WriteLine($"Philosopher {philosopherNum} put down right fork {rightFork}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Philosopher {philosopherNum} couldn't pick up right fork {rightFork}.");
                    }
                }
                finally
                {
                    Monitor.Exit(Forks[leftFork]);
                    Console.WriteLine($"Philosopher {philosopherNum} put down left fork {leftFork}.");
                }
            }
            else
            {
                Console.WriteLine($"Philosopher {philosopherNum} couldn't pick up left fork {leftFork}.");
            }
        }
    }
}

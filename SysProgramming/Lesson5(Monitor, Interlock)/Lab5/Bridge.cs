using System;
using System.Threading;

namespace Lab5
{
    internal class Bridge
    {
        private bool isCrossing = false;

        public void EnterBridge(int carId)
        {
            lock (this)
            {
                while (isCrossing)
                {
                    Console.WriteLine($"Car {carId} is waiting to cross the bridge.");
                    Monitor.Wait(this);
                }
                isCrossing = true;
                Console.WriteLine($"Car {carId} is crossing the bridge.");
            }
        }

        public void ExitBridge(int carId)
        {
            lock (this)
            {
                isCrossing = false;
                Console.WriteLine($"Car {carId} has crossed the bridge.");
                Monitor.Pulse(this);
            }
        }
    }
}

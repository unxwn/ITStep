using System;
using System.Threading;

namespace Lab5
{
    internal class Program
    {
        static Random rand = new Random();
        static Bridge bridge = new Bridge();

        static void CarCrossing(object carId)
        {
            bridge.EnterBridge((int)carId);
            Thread.Sleep(rand.Next(1000, 5000));
            bridge.ExitBridge((int)carId);
        }

        public static void Main()
        {
            for (int i = 1; i <= 5; i++)
            {
                new Thread(CarCrossing).Start(i);
                Thread.Sleep(rand.Next(10, 5000));
            }
        }
    }
}

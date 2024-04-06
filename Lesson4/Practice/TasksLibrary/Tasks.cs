using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Library
{
    public class Task
    {
        public static int[] EvenNums(int downLim, int upLim)
        {
            downLim = downLim % 2 == 0 ? downLim : downLim + 1;
            upLim = upLim % 2 == 0 ? upLim : upLim - 1;

            int size = (upLim - downLim) / 2 + 1;

            int[] result = new int[size];

            for (int i = 0, num = downLim; num <= upLim; i++, num += 2)
            {
                result[i] = num;
            }

            return result;
        }

        public static int[] OddNums(int downLim, int upLim)
        {
            downLim = downLim % 2 != 0 ? downLim : downLim + 1;
            upLim = upLim % 2 != 0 ? upLim : upLim - 1;

            int size = (upLim - downLim) / 2 + 1;

            int[] result = new int[size];

            for (int i = 0, num = downLim; num <= upLim; i++, num += 2)
            {
                result[i] = num;
            }

            return result;
        }

        public static int[] PrimeNums(int downLim, int upLim)
        {
            if (downLim <= 1 || upLim <= 1) throw new Exception("Lims must be greater than 1");

            int[] result = new int[upLim - downLim + 1];

            int amount = 0;

            bool isSimple;

            for (int num = downLim; num <= upLim; num++)
            {
                isSimple = true;

                for (int j = 2; j <= Math.Sqrt(num); j++)
                {
                    if (num % j == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }

                if (isSimple)
                {
                    result[amount++] = num;
                }
            }

            int[] primeNums = new int[amount];

            Array.Copy(result, primeNums, amount);

            return primeNums;
        }

        public static int[] FibonacciNums(int downLim, int upLim)
        {
            if (downLim < 0 || upLim < 0) throw new Exception("Lims must not be negative");

            int[] result = new int[upLim - downLim];

            int prevNum = 0, currNum = 0, nextNum = 1;

            int amount = 0;

            while (nextNum <= upLim)
            {
                if (currNum >= downLim) result[amount++] = currNum;

                prevNum = currNum;
                currNum = nextNum;
                nextNum = prevNum + currNum;
            }

            result[amount++] = currNum;

            int[] FibonacciSeq = new int[amount];

            Array.Copy(result, FibonacciSeq, amount);

            return FibonacciSeq;
        }
    }
}

namespace Task3Library
{
    public class Task
    {
        public int DownLim { get; set; }
        public int UpLim { get; set; }

        public Task()
        {
            DownLim = 0;
            UpLim = 100;
        }

        public Task(int downLim, int upLim)
        {
            DownLim += downLim;
            UpLim = upLim;
        }

        public void Start(int userNum)
        {
            int botNum = (DownLim + UpLim) / 2;
            string userChoice;

            while (botNum != userNum)
            {
                Console.Write($"Is your number less or greater than {botNum}? (l/g): ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "l":
                        UpLim = botNum;
                        break;
                    case "g":
                        DownLim = botNum;
                        break;
                    default:
                        Console.WriteLine($"Your character '{userChoice}' is wrong!");
                        break;
                }

                botNum = (DownLim + UpLim) / 2;
            }

            Console.WriteLine("Computer guessed. Your number is: " + botNum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Task1
    {
        public int DownLim { get; }
        public int UpLim { get; }

        public Task1(int downLim, int upLim)
        {
            this.DownLim = downLim;
            this.UpLim = upLim;
        }

        public int GetProdBetweenLims()
        {
            int product = 1;

            for (int i = DownLim; i <= UpLim; i++) { product *= i; }

            return product;
        }
    }

    class Task2
    {
        public int UserNum { get; }

        public Task2(int userNum) { this.UserNum = userNum; }

        public bool IsFibonacci()
        {
            if (UserNum < 0) { return false; }
            else if (UserNum == 0 || UserNum == 1 ) { return true;}

            int prevNum = 1;
            int currNum = 2;
            int tempNum;

            while (currNum <= UserNum)
            {
                if (UserNum == currNum) return true;
                tempNum = currNum;
                currNum += prevNum;
                prevNum = tempNum;
            }

            return false;
        }
    }

    class Task3
    {
        bool Reversed;
        
        public Task3() { }

        static public void SortArr(ref int[] arr, bool Reversed = false)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = arr.Length - 1; j >= 1; j--)
                {
                    if (!Reversed)
                    {
                        if (arr[j] < arr[j - 1])
                        {
                            int tempEl = arr[j - 1];
                            arr[j - 1] = arr[j];
                            arr[j] = tempEl;
                        }
                    } else
                    {
                        if (arr[j] > arr[j - 1])
                        {
                            int tempEl = arr[j - 1];
                            arr[j - 1] = arr[j];
                            arr[j] = tempEl;
                        }
                    }
                }
            }
        }
    }
     
    class Aircraft
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Role { get; set; }

        public Aircraft (string Model, string Manufacturer, DateTime ReleaseDate, string Role)
        {
            this.Model = Model;
            this.Manufacturer = Manufacturer;
            this.ReleaseDate = ReleaseDate;
            this.Role = Role;
        }

        public Aircraft() : this(String.Empty, String.Empty, DateTime.MinValue, String.Empty) { }

        public Aircraft(string Model) : this(Model, String.Empty, DateTime.MinValue, String.Empty) { }

        public void PrintInfo()
        {
            string format = "|{0,-15}|{1,-40}|{2,-15}|{3,-40}|";
            string header = String.Format(format, "Model", "Manufacturer", "Release date", "Role");
            string separator = new string('-', header.Length);

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);
            Console.WriteLine(String.Format(format, Model, Manufacturer, ReleaseDate.Year, Role));
            Console.WriteLine(separator);
        }


        public void DeleteAircraft()
        {
            this.Model = String.Empty;
            this.Manufacturer = String.Empty;
            this.ReleaseDate = DateTime.MinValue;
            this.Role = String.Empty;
        }
    }
    class Matrix
    {
        private Random rand = new Random();

        public int[,] MatrixData { get; }
        public int Rows { get; }
        public int Cols { get; }
        public int UpLim { get; } // uppest value does`not include
        public int DownLim { get; } // lowest value include

        public Matrix(int rows, int cols, bool RandGenereted = true, int DataRangeDownLim = -10, int DataRangeUpLim = 11)
        {
            MatrixData = new int[rows, cols];

            this.Rows = rows;
            this.Cols = cols;
            UpLim = DataRangeUpLim;
            DownLim = DataRangeDownLim;

            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (RandGenereted)
                    {
                        MatrixData[i, j] = rand.Next(DownLim, UpLim);
                    } else
                    {
                        Console.Write($"Write matrix[{i}, {j}]: ");
                        MatrixData[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
        }

        public Matrix() : this(3, 3)
        {
            Console.WriteLine("By default, a randomly generated 3x3 matrix is used");
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"{MatrixData[i, j], 4}");
                }
                Console.WriteLine();
            }
        }

        public int FindMax()
        {
            int max = MatrixData[0, 0];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if ((MatrixData[i, j] > max)) max = MatrixData[i, j];
                }
            }

            return max;
        }

        public int FindMin()
        {
            int min = MatrixData[0, 0];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if ((MatrixData[i, j] < min)) min = MatrixData[i, j];
                }
            }

            return min;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Task1 task1 = new Task1(1, 5);
            Console.WriteLine($"Task 1\nProduct in range {task1.DownLim} and {task1.UpLim} = {task1.GetProdBetweenLims()}");

            // Task 2 | Числа Фібоначчі - 0, 1, 1, 2, 3, 5, 8 ... То так і зробив завдання, бо в умові не зрозрозуміло, пише про прості числа ＼（〇_ｏ）／
            Task2 task2 = new Task2(7);
            Console.WriteLine("\n\nTask 2");
            if (task2.IsFibonacci())
                Console.WriteLine($"{task2.UserNum} is Fibonacci number");
            else Console.WriteLine($"{task2.UserNum} isn`t Fibonacci number");

            // Task 3
            Console.WriteLine("\n\nTask 3\nSorted array:");
            int[] userArr = { 12, 6, 5, 4, 9, 0, 11, 0 };
            Task3.SortArr(ref userArr, true);

            foreach (int el in userArr)  
                Console.Write($"{el} ");

            // Task 4, 5 пропустив
            // Task 6 
            Console.WriteLine("\n\nTask 6");
            
            Aircraft aircraft1 = new Aircraft("An-225 Mriya", "Antonov Serial Production Plant", new DateTime(1985, 01, 01), "Outsize cargo freight aircraft");
            Aircraft aircraft2 = new Aircraft("MQ-9 Reaper", "General Atomics Aeronautical Systems", new DateTime(2001, 1, 1), "Unmanned combat aerial vehicle");

            aircraft1.PrintInfo();
            aircraft2.PrintInfo();

            // Task 7
            Console.WriteLine("\n\nTask 7");

            Matrix matrix = new Matrix();

            matrix.PrintMatrix( );

            Console.WriteLine($"Min num = {matrix.FindMin()}\nMax num = {matrix.FindMax()}");
        }
    }
}

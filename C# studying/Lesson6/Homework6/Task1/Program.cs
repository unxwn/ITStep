using System;

namespace Task1
{
    class Money
    {
        public string CurrencyType { get; protected set; } = "Not specified";
        public int MainPart { get; protected set; }
        public int FractionalPart { get; protected set; }

        public Money() { }

        public Money(string currencyType, int  mainPart, int fractionalPart)
        {
            if (currencyType == null || currencyType == "" || mainPart < 0 || fractionalPart < 0 || mainPart <= 0 && fractionalPart <= 0)
                throw new ArgumentException("Invalid currency type or value");

            CurrencyType = currencyType;
            MainPart = mainPart;
            FractionalPart = fractionalPart;
        }

        public void SetCurrencyType(string currencyType)
        {
            if (currencyType == null || currencyType == "")
            {
                throw new ArgumentException("Currency type cannot be null or empty");
            }

            CurrencyType = currencyType;
        }

        public void SetMainPart(int mainPart)
        {
            if (mainPart < 0)
            {
                throw new ArgumentException("Main part cannot be negative");
            }

            MainPart = mainPart;
        }

        public void SetFractionalPart(int fractionalPart)
        {
            if (fractionalPart < 0)
            {
                throw new ArgumentException("Fractional part cannot be negative");
            }

            FractionalPart = fractionalPart;
        }

        public void ShowCost()
        {
            Console.WriteLine($"{MainPart}.{FractionalPart} {CurrencyType}");
        }
    }

    class Product : Money
    {
        public string Name { get; }

        public Product(string name, int costMainPart, int costFractPart, string currencyType)
        {
            Name = name;
            CurrencyType = currencyType;
            MainPart = costMainPart;
            FractionalPart = costFractPart;
        }

        public void ReduceMainPart(int value)
        {
            if (value < 0)
            { 
                Console.WriteLine("Value must be positive");
                return;
            }

            MainPart -= value;
        }

        public void ReduceFractPart(int value)
        {
            if (value < 0)
            {
                Console.WriteLine("Value must be positive");
                return;
            }

            FractionalPart -= value;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Money class:");
            Money money = new Money();
            money.SetCurrencyType("USD");
            money.SetMainPart(99);
            money.SetFractionalPart(99);
            money.ShowCost();

            Console.WriteLine("\nTesting Product class:");
            Product product = new Product("Pear", 10, 75, "UAH");
            product.ShowCost();
            product.ReduceMainPart(5);
            product.ReduceFractPart(25);
            product.ShowCost();
        }
    }
}

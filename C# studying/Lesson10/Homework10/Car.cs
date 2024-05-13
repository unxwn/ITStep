using Homework10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework10
{
    internal class Car
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Car(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }
    }

    internal class Comp : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            if (x.Price < y.Price)
            {
                return -1;
            }
            else if (x.Price > y.Price)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

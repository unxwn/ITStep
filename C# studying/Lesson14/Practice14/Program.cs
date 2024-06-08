using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice14
{
    internal class Car
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] cars1 = new Car[]
            {
                new Car { Name = "Dodge Charger R/T", Manufacturer = "Dodge", Year = 1968 },
                new Car { Name = "Ford Mustang GT-350", Manufacturer = "Ford", Year = 1967 },
                new Car { Name = "Sapphire", Manufacturer = "Lucid", Year = 2024 },
                new Car { Name = "Camaro Z/28", Manufacturer = "Chevrolet", Year = 1969 },
                new Car { Name = "Pontiac GTO", Manufacturer = "Pontiac", Year = 1964 },
                new Car { Name = "Cobra 427", Manufacturer = "Shelby", Year = 1965 },
                new Car { Name = "Sapphire", Manufacturer = "Lucid", Year = 2024 },
                new Car { Name = "250 GTO", Manufacturer = "Ferrari", Year = 1963 },
                new Car { Name = "Cybertrack", Manufacturer = "Tesla", Year = 2024 },
                new Car { Name = "Aston Martin DB5", Manufacturer = "Aston Martin", Year = 1963 },
                new Car { Name = "Porsche 911", Manufacturer = "Porsche", Year = 1963 },
                new Car { Name = "Cybertrack", Manufacturer = "Tesla", Year = 2024 },
                new Car { Name = "Jaguar E-Type", Manufacturer = "Jaguar", Year = 1961 },
                new Car { Name = "300 SL Gullwing", Manufacturer = "Mercedes-Benz", Year = 1954 },
            };

            Car[] cars2 = new Car[]
            {
                new Car { Name = "Air Touring", Manufacturer = "Lucid", Year = 2023 },
                new Car { Name = "250 GTO", Manufacturer = "Ferrari", Year = 1963 },
                new Car { Name = "250 GTO", Manufacturer = "Ferrari", Year = 1963 },
                new Car { Name = "Pure AWD", Manufacturer = "Lucid", Year = 2024 },
                new Car { Name = "Jaguar E-Type", Manufacturer = "Jaguar", Year = 1961 },
                new Car { Name = "Sapphire", Manufacturer = "Lucid", Year = 2024 },
                new Car { Name = "Model Y", Manufacturer = "Tesla", Year = 2022 },
                new Car { Name = "Jaguar E-Type", Manufacturer = "Jaguar", Year = 1961 },
                new Car { Name = "Cybertrack", Manufacturer = "Tesla", Year = 2024 },
                new Car { Name = "250 GTO", Manufacturer = "Ferrari", Year = 1963 },
            };

            Car[] except = cars1.Except(cars2, new CarManufecturerComparer()).ToArray();
            Car[] intersection = cars1.Intersect(cars2, new CarManufecturerComparer()).ToArray();
            Car[] union = cars1.Union(cars2, new CarManufecturerComparer()).ToArray();

            Console.WriteLine("Difference");
            foreach (Car car in except)
            {
                Console.WriteLine($"{car.Name}, {car.Manufacturer}, {car.Year}");
            }

            Console.WriteLine("\n\nIntersection");
            foreach (Car car in intersection)
            {
                Console.WriteLine($"{car.Name}, {car.Manufacturer}, {car.Year}");
            }

            Console.WriteLine("\n\nUnion");
            foreach (Car car in union)
            {
                Console.WriteLine($"{car.Name}, {car.Manufacturer}, {car.Year}");
            }
        }
    }

    internal class CarManufecturerComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.Manufacturer == y.Manufacturer;
        }

        public int GetHashCode(Car car)
        {
            return car.Manufacturer.GetHashCode();
        }
    }
}
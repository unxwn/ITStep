using System;
using System.Collections.Generic;

namespace Homework10
{
    class Program
    {
        static void Main(string[] args)
        {
            FootballTeam team = new FootballTeam();

            team.AddPlayer(new Player("Bill", 22));
            team.AddPlayer(new Player("John", 23));
            team.AddPlayer(new Player("Mike", 25));

            foreach (Player player in team)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            List<Car> cars = new List<Car>
            {
                new Car("Tesla", 90000),
                new Car("BMW", 60000),
                new Car("Audi", 70000),
                new Car("Mercedes", 80000)
            };

            cars.Sort(new Comp());

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

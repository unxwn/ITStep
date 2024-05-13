using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> d04686ce36a3f3720cbb6285d6e3e33a2525f5cf

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
<<<<<<< HEAD

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
=======
>>>>>>> d04686ce36a3f3720cbb6285d6e3e33a2525f5cf
        }
    }
}

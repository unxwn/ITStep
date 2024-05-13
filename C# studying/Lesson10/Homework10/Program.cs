using System;

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
        }
    }
}

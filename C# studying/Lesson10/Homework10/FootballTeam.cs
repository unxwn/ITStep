using System.Collections;
using System.Collections.Generic;

namespace Homework10
{
    internal class FootballTeam : IEnumerable
    {
        private List<Player> players = new List<Player>();

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        
        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public IEnumerator GetEnumerator()
        {      
            return players.GetEnumerator();
        }
    }
}

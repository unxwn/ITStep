namespace Homework10
{
    internal class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Player(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Name} (№{Number})";
        }
    }
}

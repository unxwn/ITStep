namespace DomainClassLibrary.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StudioId { get; set; }
        public Studio Studio { get; set; } = default!;
        public string[] Genre { get; set; } = default!;
        public int ReleaseYear { get; set; }
        public bool Multiplayer { get; set; }
        public int CopiesSold { get; set; } = 0;
    }
}

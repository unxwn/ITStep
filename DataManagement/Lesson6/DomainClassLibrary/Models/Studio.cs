﻿namespace DomainClassLibrary.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}

using DomainClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataClassLibrary.Data
{
    public class GamesLibraryContext : DbContext
    {
        private readonly string _connStr = "Server=(localdb)\\MSSQLLocalDB;Database=GamesLibraryDb;Trusted_Connection=True;";

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Studio> Studios { get; set; }

        public GamesLibraryContext(DbContextOptions<GamesLibraryContext> options) : base(options) { }

        public GamesLibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(g => g.Genre)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}

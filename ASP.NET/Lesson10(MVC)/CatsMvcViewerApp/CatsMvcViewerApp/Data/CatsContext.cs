using CatsMvcViewerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatsMvcViewerApp.Data
{
    public class CatsContext : DbContext
    {
        public CatsContext(DbContextOptions<CatsContext> options):
            base(options){
            //Database.EnsureCreated();
        }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Cat> Cats { get; set; }
    }
}

using ASP_Meeting_7.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Meeting_7.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):
            base(options){
            Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
    }
}

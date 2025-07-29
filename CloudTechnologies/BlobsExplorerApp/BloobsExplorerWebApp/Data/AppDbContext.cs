using HW2WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HW2WebApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<FileRecord> Files { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}

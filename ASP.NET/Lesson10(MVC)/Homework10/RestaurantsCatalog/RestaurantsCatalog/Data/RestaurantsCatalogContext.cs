using Microsoft.EntityFrameworkCore;
using RestaurantsCatalog.Models;

namespace RestaurantsCatalog.Data
{
    public class RestaurantsCatalogContext : DbContext
    {
        public RestaurantsCatalogContext(DbContextOptions<RestaurantsCatalogContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

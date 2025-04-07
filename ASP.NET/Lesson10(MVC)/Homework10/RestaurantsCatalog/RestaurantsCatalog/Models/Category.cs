using System.ComponentModel.DataAnnotations;

namespace RestaurantsCatalog.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(3)]
        public required string Name { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}

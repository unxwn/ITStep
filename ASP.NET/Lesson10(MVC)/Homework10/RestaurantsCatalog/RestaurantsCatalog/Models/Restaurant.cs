namespace RestaurantsCatalog.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required string WorkingHours { get; set; }

        public required int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

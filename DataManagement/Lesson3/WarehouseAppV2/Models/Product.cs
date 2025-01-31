namespace WarehouseApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int CategoryId { get; set; } = default!;
        public int SupplierId { get; set; } = default!;
        public decimal CostPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime SupplyDate { get; set; }
    }
}

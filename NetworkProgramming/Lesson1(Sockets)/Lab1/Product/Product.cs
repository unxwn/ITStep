namespace ProductNamespace
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }

        public Product(int id, string name, decimal price, string manufacturer)
        {
            Id = id;
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
        }
    }
}

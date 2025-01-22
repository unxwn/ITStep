using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class CarContext : DbContext
    {
        public CarContext() : base("CarDB") { }

        public DbSet<Car> Cars { get; set; }

        public void SeedData()
        {
            if (!Cars.Any())
            {
                Cars.AddRange(new[]
                {
                    new Car { Brand = "Toyota", Model = "Camry", Price = 30000, IsAvailable = true },
                    new Car { Brand = "Honda", Model = "Civic", Price = 20000, IsAvailable = true },
                    new Car { Brand = "Tesla", Model = "Model 3", Price = 50000, IsAvailable = true },
                    new Car { Brand = "Tesla", Model = "Model S", Price = 20000, IsAvailable = false },
                    new Car { Brand = "Tesla", Model = "Model U", Price = 100000, IsAvailable = false }

                });
                SaveChanges();
            }
        }

        public void ClearData()
        {
            foreach (var car in Cars)
                Cars.Remove(car);

            SaveChanges();
        }
    }
}

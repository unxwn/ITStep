using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework13
{
    internal class Firm
    {
        public string Name { get; set; }
        public DateTime FoundedDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorName { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }

        public Firm(string name, DateTime foundedDate, string businessProfile, string directorName, int numberOfEmployees, string address)
        {
            Name = name;
            FoundedDate = foundedDate;
            BusinessProfile = businessProfile;
            DirectorName = directorName;
            NumberOfEmployees = numberOfEmployees;
            Address = address;
        }
    }

    internal class Program
    {
        static void Main()
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm("TechCorp", new DateTime(2020, 1, 1), "IT", "John White", 150, "123 Tech Street, London"),
                new Firm("Foodies", new DateTime(2019, 5, 15), "Food Industry", "Jane Smith", 200, "456 Culinary Road, London"),
                new Firm("MarketGurus", new DateTime(2021, 3, 10), "Marketing", "Mike Johnson", 50, "789 Business Blvd, Manchester"),
                new Firm("IT Solutions", new DateTime(2018, 7, 30), "IT", "Emily White", 400, "101 Tech Avenue, London"),
                new Firm("White & Black", new DateTime(2022, 11, 5), "Marketing", "Michael Black", 80, "202 Business St, Birmingham"),
                new Firm("Food Network", new DateTime(2021, 12, 25), "Food Industry", "Peter Parker", 90, "303 Culinary Lane, Liverpool")
            };

            firms.ForEach(f => Console.WriteLine(f.Name));
            Console.WriteLine();

            firms.Where(f => f.Name.Contains("Food")).ToList()
                .ForEach(f => Console.WriteLine(f.Name));
            Console.WriteLine();

            firms.Where(f => f.BusinessProfile == "Marketing").ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Profile: {f.BusinessProfile}"));
            Console.WriteLine();

            firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT").ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Profile: {f.BusinessProfile}"));
            Console.WriteLine();

            firms.Where(f => f.NumberOfEmployees > 100).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Employees: {f.NumberOfEmployees}"));
            Console.WriteLine();

            firms.Where(f => f.NumberOfEmployees >= 100 && f.NumberOfEmployees <= 300).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Employees: {f.NumberOfEmployees}"));
            Console.WriteLine();

            firms.Where(f => f.Address.EndsWith("London")).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Address: {f.Address}"));
            Console.WriteLine();

            firms.Where(f => f.DirectorName.EndsWith("White")).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Director: {f.DirectorName}"));
            Console.WriteLine();

            firms.Where(f => (DateTime.Now - f.FoundedDate).TotalDays > 365 * 2).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Founded: {f.FoundedDate.ToShortDateString()}"));
            Console.WriteLine();

            firms.Where(f => (DateTime.Now - f.FoundedDate).TotalDays >= 123).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Founded: {f.FoundedDate.ToShortDateString()}"));
            Console.WriteLine();

            firms.Where(f => f.DirectorName.EndsWith("Black") && f.Name.Contains("White")).ToList()
                .ForEach(f => Console.WriteLine($"{f.Name}, Director: {f.DirectorName}"));
            Console.WriteLine();
        }
    }
}
using System;

namespace task2
{
    internal class Passport
    {
        public virtual string PassportType { get; } = "Passport";

        public string PassportID { get; }
        public string FirstName { get;  }
        public string LastName { get; }
        public string BirthDate { get; }
        public string ExpiryDate { get; }

        public Passport() { }

        public Passport(string id, string firstName, string lastName, string birthDate, string expiryDate)
        {
            PassportID = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ExpiryDate = expiryDate;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"**{PassportType}**");
            Console.WriteLine($"Passport ID: {PassportID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Date of Birth: {BirthDate}");
            Console.WriteLine($"Expiry Date: {ExpiryDate}");
        }
    }

    internal class ForeignPassport : Passport
    {
        public override string PassportType { get; } = "Foreign Passport";
        public string[] Visas { get; } = new string[10];

        public ForeignPassport(string foreignPassportID, string firstName, string lastName, string birthDate, string expiryDate)
            : base(foreignPassportID, firstName, lastName, birthDate, expiryDate) { }

        public void AddVisa(string visa)
        {
            for (int i = 0; i < Visas.Length; i++)
            {
                if (Visas[i] == null)
                {
                    Visas[i] = visa;
                    return;
                }
            }
            Console.WriteLine("No more space for visas!");
        }

        public void RemoveVisa(string visa)
        {
            for (int i = 0; i < Visas.Length; i++) {
                if (Visas[i] == visa)
                {
                    Visas[i] = null;
                    Console.WriteLine($"Visa ({visa}) removed successfully.");
                    return;
                }
            }

            Console.WriteLine("There is no such visa in the foreign passport.");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Visas:");
            foreach (string visa in Visas)
            {
                if (visa != null)
                    Console.WriteLine(visa);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Passport ukrainianPassport = new Passport("123456789", "Іван", "Петров", "01.01.2001", "05.05.2035");
            ukrainianPassport.DisplayInfo();

            Console.WriteLine();

            ForeignPassport foreignPassport = new ForeignPassport("AB1234567", "Ivan", "Petrov", "01.01.2001", "01.01.2031");
            foreignPassport.AddVisa("USA");
            foreignPassport.AddVisa("UK");
            foreignPassport.AddVisa("Canada");
            foreignPassport.DisplayInfo();

            Console.WriteLine("\nDeleting visa: ");
            foreignPassport.RemoveVisa("Canada");

            Console.WriteLine();
            foreignPassport.DisplayInfo();
        }
    }
}

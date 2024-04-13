using System;

namespace Task1
{
    internal abstract class Human
    {
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string WorkPlace { get; set; }

        public abstract int RetirementAge { get; }

        public Human() { }

        public Human(string role, string firstName, string lastName, int age, string workPlace)
        {
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            WorkPlace = workPlace;
        }

        public abstract void DoWork();
        public abstract void ShowYearsToRetireInfo();
    }

    internal class Builder : Human
    {
        public override int RetirementAge { get; } = 65;

        public string ObjectOfWork { get; set; }

        public Builder() { }

        public Builder(string role, string firstName, string lastName, int age, string workPlace, string objectOfWork)
            : base(role, firstName, lastName, age, workPlace)
        {
            ObjectOfWork = objectOfWork;
        }

        public override void DoWork()
        {
            Console.WriteLine($"{Role} {FirstName} {LastName} is building the {ObjectOfWork}");
        }

        public override void ShowYearsToRetireInfo()
        {
            int yearsToRetire = RetirementAge - Age;
            if (yearsToRetire > 0)
                Console.WriteLine($"Retirement age: {RetirementAge}, {yearsToRetire} years left until retirement");
            else
                Console.WriteLine($"Retirement age: {RetirementAge}, eligible for retirement");
        }
    }

    internal class Sailor : Human
    {
        public override int RetirementAge { get; } = 55;
        public string ShipName { get; set; }

        public Sailor() { }

        public Sailor(string role, string firstName, string lastName, int age, string workPlace, string shipName)
            : base(role, firstName, lastName, age, workPlace)
        {
            ShipName = shipName;
        }

        public override void DoWork()
        {
            Console.WriteLine($"{Role} {FirstName} {LastName} is sailing the ship \"{ShipName}\" for {WorkPlace}");
        }
        public override void ShowYearsToRetireInfo()
        {
            int yearsToRetire = RetirementAge - Age;
            if (yearsToRetire > 0)
                Console.WriteLine($"Retirement age: {RetirementAge}, {yearsToRetire} years left until retirement");
            else
                Console.WriteLine($"Retirement age: {RetirementAge}, eligible for retirement");
        }
    }

    internal class Pilot : Human
    {
        public override int RetirementAge { get; } = 50;

        public string Aircraft { get; set; }
        public string Rank { get; set; }

        public Pilot() { }

        public Pilot(string role, string rank, string firstName, string lastName, int age, string workPlace, string aircraft)
            : base(role, firstName, lastName, age, workPlace)
        {
            Aircraft = aircraft;
            Rank = rank;
        }

        public override void DoWork()
        {
            Console.WriteLine($"{Role} {Rank} {FirstName} {LastName} is flying the {Aircraft} for {WorkPlace}");
        }
        public override void ShowYearsToRetireInfo()
        {
            int yearsToRetire = RetirementAge - Age;
            if (yearsToRetire > 0)
                Console.WriteLine($"Retirement age: {RetirementAge}, {yearsToRetire} years left until retirement");
            else
                Console.WriteLine($"Retirement age: {RetirementAge}, eligible for retirement");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new Builder("Builder", "Ivan", "Petrovych", 65, "Building Company", "Mall");
            Pilot pilot = new Pilot("Pilot", "Major", "Mykola", "Kamysh", 30, "Armed Forces of Ukraine", "MiG-29MU2");
            Sailor sailor = new Sailor("Sailor", "Sponge", "Bob", 40, "Travel Company", "Snail");

            Human[] humans = new Human[3];
            humans[0] = new Builder("Builder", "Ivan", "Petrovych", 65, "Building Company", "Mall");
            humans[1] = new Pilot("Pilot", "Major", "Mykola", "Kamysh", 30, "Armed Forces of Ukraine", "MiG-29MU2");
            humans[2] = new Sailor("Sailor", "Sponge", "Bob", 40, "Travel Company", "Snail");

            humans[0].DoWork();
            humans[0].ShowYearsToRetireInfo();

            Console.WriteLine();

            humans[1].DoWork();
            humans[1].ShowYearsToRetireInfo();

            Console.WriteLine();

            humans[2].DoWork();
            humans[2].ShowYearsToRetireInfo();
        }
    }
}

using System;
class Device
{
    protected string Name { get; set; }
    protected string Sound { get; set; }

    public Device(string name, string sound)
    {
        Name = name;
        Sound = sound;
    }
    
    public virtual void GetSound()
    {
        Console.WriteLine($"Sound of the {Name}: {Sound}");
    }

    public void Show()
    {
        Console.WriteLine($"Device name: {Name}");
    }

    public virtual void ShowDesc()
    {
        Console.WriteLine($"Description of {Name}: ...");
    }
}

class Kettle : Device
{
    public Kettle(string name, string sound) : base(name, sound) { }

    public override void GetSound()
    {
        Console.WriteLine("The kettle is whistling");
    }

    public override void ShowDesc()
    {
        Console.WriteLine("Desc: Very hot kettle");
    }
}

class Microwave : Device
{
    public Microwave(string name, string sound) : base(name, sound)
    {
    }

    public override void GetSound()
    {
        Console.WriteLine("The microwave is humming");
    }

    public override void ShowDesc()
    {
        Console.WriteLine("Desc: Just a microwave");
    }
}

class Car : Device
{
    public Car(string name, string sound) : base(name, sound) { }

    public override void GetSound()
    {
        Console.WriteLine("The car makes noise");
    }

    public override void ShowDesc()
    {
        Console.WriteLine("Desc: Exspensive and fast car");
    }
}

class Steamboat : Device
{
    public Steamboat(string name, string sound) : base(name, sound)
    {
    }

    public override void GetSound()
    {
        Console.WriteLine("The steamboat is whistling (not like a kettle)");
    }

    public override void ShowDesc()
    {
        Console.WriteLine("Desc: Huge steamer");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Kettle kettle = new Kettle("Kettle", "Fizz");
        Microwave microwave = new Microwave("Microwave", "Hum");
        Car car = new Car("Car", "Buzz");
        Steamboat steamboat = new Steamboat("Steamboat", "Whlist");

        kettle.Show();
        kettle.GetSound();
        kettle.ShowDesc();

        Console.WriteLine();

        microwave.Show();
        microwave.GetSound();
        microwave.ShowDesc();

        Console.WriteLine();

        car.Show();
        car.GetSound();
        car.ShowDesc();

        Console.WriteLine();

        steamboat.Show();
        steamboat.GetSound();
        steamboat.ShowDesc();
    }
}

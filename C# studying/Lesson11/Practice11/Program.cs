using System;
using System.IO;

public class ArrayFileManager
{
    public int[] ReadArrayFromUser()
    {
        Console.Write("Enter the number of array elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            array[i] = int.Parse(Console.ReadLine());
        }

        return array;
    }

    public void SaveArrayToFile(int[] array, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (int value in array)
            {
                writer.WriteLine(value);
            }
        }
        Console.WriteLine("Array saved to file.");
    }

    public int[] LoadArrayFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int[] array = new int[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            array[i] = int.Parse(lines[i]);
        }

        return array;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArrayFileManager manager = new ArrayFileManager();

        int[] array = manager.ReadArrayFromUser();

        Console.Write("Save array to file? (y/n): ");
        string saveToFile = Console.ReadLine();

        if (saveToFile.ToLower() == "y")
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            manager.SaveArrayToFile(array, fileName);
        }

        Console.Write("Load array from file? (y/n): ");
        string loadFromFile = Console.ReadLine();

        if (loadFromFile.ToLower() == "y")
        {
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            array = manager.LoadArrayFromFile(fileName);
            Console.Write("Array elements: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
}
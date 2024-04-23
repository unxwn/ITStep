using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

interface IMath
{
    int Max();
    int Min();
    float Avg();
    bool Search(int valueToSearch);
}

interface ISort
{
    void SortAsc();
    void SortDesc();
    void SortByParam(bool reversed = false);
}

interface ICalc2
{
    int CountDistinct();
    int EqualToValue(int value);
}

class Array : IMath, ISort, ICalc2
{
    private int[] Arr { get; set; }

    public Array(int size)
    {
        Arr = new int[size];
    }

    public int this[int index]
    {
        get { return Arr[index]; }
        set { Arr[index] = value; }
    }

    public void DisplayArray()
    {
        foreach (int el in Arr)
        {
            Console.Write($"{el} ");
        }
    }

    public int Max()
    {
        if (Arr.Length == 0)
            throw new InvalidOperationException("Array is empty");

        int max = Arr[0];
        for (int i = 1; i < Arr.Length; ++i)
        {
            if (Arr[i] > max)
                max = Arr[i];
        }

        return max;
    }

    public int Min()
    {
        if (Arr.Length == 0)
            throw new InvalidOperationException("Array is empty");

        int min = Arr[0];
        for (int i = 0; i < Arr.Length; ++i)
        {
            if (Arr[i] < min)
                min = Arr[i];
        }

        return min;
    }

    public float Avg()
    {
        if (Arr.Length == 0)
            throw new InvalidOperationException("Array is empty");

        int sum = 0;
        foreach (int num in Arr)
        {
            sum += num;
        }

        return (float)sum / Arr.Length;
    }

    public bool Search(int valueToSearch)
    {
        foreach (int num in Arr)
        {
            if (num == valueToSearch)
                return true;
        }

        return false;
    }

    public void SortAsc()
    {
        for (int i = 0; i < Arr.Length - 1; i++)
        {
            for (int j = 0; j < Arr.Length - i - 1; j++)
            {
                if (Arr[j] > Arr[j + 1])
                {
                    int temp = Arr[j];
                    Arr[j] = Arr[j + 1];
                    Arr[j + 1] = temp;
                }
            }
        }
    }

    public void SortDesc()
    {
        for (int i = 0; i < Arr.Length - 1; i++)
        {
            for (int j = 0; j < Arr.Length - i - 1; j++)
            {
                if (Arr[j] < Arr[j + 1])
                {
                    int temp = Arr[j];
                    Arr[j] = Arr[j + 1];
                    Arr[j + 1] = temp;
                }
            }
        }
    }

    public void SortByParam(bool reversed = false)
    {
        switch (reversed)
        {
            case false:
                SortAsc();
                break;
            case true:
                SortDesc();
                break;
        }
    }

    public int CountDistinct()
    {
        int count = 0;

        for (int i = 0; i < Arr.Length; ++i)
        {
            bool isDistinct = true;
            for (int j = 0; j < Arr.Length; ++j)
            {
                if (i == j) continue;
                if (Arr[i] == Arr[j]) { 
                    isDistinct = false;
                    break;
                }
            }
            if (isDistinct) ++count;
        }

        return count;
    }

    public int EqualToValue(int value) 
    {
        int count = 0;
        foreach (int el in Arr) 
        {
            if (el == value) 
                ++count;
        }

        return count;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Array myArray = new Array(9);
        myArray[0] = 1;
        myArray[1] = 2;
        myArray[2] = 3;
        myArray[3] = 4;
        myArray[4] = 5;
        myArray[5] = 0;
        myArray[6] = 3;
        myArray[7] = -1;
        myArray[8] = 0;

        Console.Write($"Array: ");
        myArray.DisplayArray();

        Console.WriteLine($"\nMax value: {myArray.Max()}");
        Console.WriteLine($"Min value: {myArray.Min()}");
        Console.WriteLine($"Average: {myArray.Avg()}");
        Console.WriteLine($"Search for 3: {myArray.Search(3)}");
        Console.WriteLine($"Search for 10: {myArray.Search(10)}");

        myArray.SortAsc();
        myArray.DisplayArray();

        Console.WriteLine();

        myArray.SortByParam(true);
        myArray.DisplayArray();

        Console.WriteLine();

        Console.WriteLine($"Count of distinct items: {myArray.CountDistinct()}");
        Console.WriteLine($"Count of equal to value items: {myArray.EqualToValue(0)}");
    }
}

using System;
using System.Collections.Generic;

public class Stack<T>
{
    private List<T> list = new List<T>();

    public int Count { get { return list.Count; } }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        int lastI = list.Count - 1;
        T lastEl = list[list.Count - 1];
        list.RemoveAt(lastI);
        return lastEl;
    }

    public void Push(T element)
    {
        list.Add(element);
    }

    public T Peek()
    {
        if (Count == 0)
        {
            
        }

        return list[list.Count - 1];
    }

    public void DisplayStack()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            Console.Write("|");
            Console.Write(list[i]);
            Console.WriteLine("|");
        }
        Console.WriteLine("---");
    }
}

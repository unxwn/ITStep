using System;
using System.Collections.Generic;

namespace Homework9
{
    internal class PriorityQueue<T>
    {
        private List<T> values = new List<T>();
        private List<int> priorities = new List<int>();

        public int Count { get { return values.Count; } }

        public void Enqueue(T item, int priority)
        {
            values.Add(item);
            priorities.Add(priority);
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            int minPriorityIndex = GetMinPriorityIndex();
            T item = values[minPriorityIndex];
            values.RemoveAt(minPriorityIndex);
            priorities.RemoveAt(minPriorityIndex);
            return item;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            int minPriorityIndex = GetMinPriorityIndex();
            return values[minPriorityIndex];
        }

        public void Display()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            Console.Write("Values:".PadRight(15));
            foreach (T el in values)
            {
                Console.Write(el.ToString().PadRight(15));
            }

            Console.Write("\nPriorities:".PadRight(16));
            foreach (int el in priorities)
            {
                Console.Write(el.ToString().PadRight(15));
            }
            Console.WriteLine();
        }

        public void Clear()
        {
            values.Clear();
            priorities.Clear();
        }

        private int GetMinPriorityIndex()
        {
            int i = 0;
            int minPriorityIndex = i;
            int minPriority = priorities[minPriorityIndex];
            for (i = 1; i < priorities.Count; i++)
            {
                if (priorities[i] < minPriority)
                {
                    minPriority = priorities[i];
                    minPriorityIndex = i;
                }
            }
            return minPriorityIndex;
        }
    }
}

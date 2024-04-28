using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    class Task1<T>
    {
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "First str";
            string str2 = "Second str";
            Task1<string>.Swap(ref str1, ref str2);
            Console.WriteLine(str1);
            Console.WriteLine(str2);

            Console.WriteLine("\n\n**Priority queue**");

            PriorityQueue<string> priorityQueue = new PriorityQueue<string>();

            priorityQueue.Enqueue("Person 1", 3);
            priorityQueue.Enqueue("Person 2", 1);
            priorityQueue.Enqueue("Person 3", 2);

            priorityQueue.Display();

            Console.WriteLine("\nNext person: " + priorityQueue.Peek() + "\n");

            while (priorityQueue.Count > 0)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }

            Console.WriteLine("\n\n**Linked list**");

            LinkedList<string> myList = new LinkedList<string>();

            myList.Append("One");
            myList.Append("Two");
            myList.Append("3");

            myList.AddFirst("Zoroo");
            myList.AddLast("Lastoo");
            myList.AddFirst("One more Zoroo");
            myList.AddLast("One more Lastoo");

            myList.PrintAll();
            LinkedList<string>.Node node = myList.Find("3");
            myList.AddAfter("Three", node);

            myList.PrintAll();

            myList.Remove(node);

            myList.PrintAll();
        } 
    }
}

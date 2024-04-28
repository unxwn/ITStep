using System;

namespace Homework9
{
    public class LinkedList<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public LinkedList() { }

        public void Append(T value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            if (Head != null)
            {
                Head.Prev = newNode;
            }
            else
            {
                Tail = newNode;
            }
            Head = newNode;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);
            newNode.Prev = Tail;
            if (Tail != null)
            {
                Tail.Next = newNode;
            }
            else
            {
                Head = newNode;
            }
            Tail = newNode;
        }

        public void AddAfter(T value, Node afterNode)
        {
            if (afterNode == null)
            {
                throw new ArgumentException("The node after which the new node should be inserted cannot be null", nameof(afterNode));
            }

            Node newNode = new Node(value);

            newNode.Next = afterNode.Next;
            newNode.Prev = afterNode;

            if (afterNode.Next != null)
            {
                afterNode.Next.Prev = newNode;
            }
            else
            {
                Tail = newNode;
            }

            afterNode.Next = newNode;
        }

        public Node Find(T value)
        {
            for (Node current = Head; current != null; current = current.Next)
            {
                if (current.Value.Equals(value))
                {
                    Console.WriteLine($"Item '{value}' found");
                    return current;
                }
            }

            return null;
        }

        public void PrintAll(bool reversed = false)
        {
            Console.WriteLine("Linked list:");

            Node current = !reversed ? Head : Tail;
            while (current != null)
            {
                Console.Write(current.Value + (!reversed ? (current.Next != null ? " >> " : "") : (current.Prev != null ? " << " : "")));
                current = !reversed ? current.Next : current.Prev;
            }
            Console.WriteLine();
        }

        public void Remove(Node nodeToDelete)
        {
            Node node = nodeToDelete;

            if (node == null)
            {
                return;
            }

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                Head = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                Tail = node.Prev;
            }

            node = null;
        }

        public void Clear()
        {
            Node current = Tail;
            while (current != null)
            {
                Node next = current.Prev;
                current = null;
                current = next;
            }
            Head = Tail = null;
        }
    }
}

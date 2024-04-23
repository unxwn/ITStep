using System;
using System.Diagnostics;

public class BooksToRead
{
    private string[] booksList;
    public int Size { get; private set; } = 0;

    public BooksToRead(int listCapacity)
    {
        booksList = new string[listCapacity];

        for (int i = 0; i < listCapacity; i++)
        {
            booksList[i] = "Empty place";
        }
    }

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < booksList.Length)
                return booksList[index];
            else
                throw new IndexOutOfRangeException();
        }
        set
        {
            if (index >= 0 && index < booksList.Length)
                booksList[index] = value;
            else
                throw new IndexOutOfRangeException();
        }
    }

    public bool ContainsBook(string book)
    {
        for (int i = 0; i < booksList.Length; i++)
        {
            if (booksList[i] == book)
                return true;
        }
        return false;
    }

    public int GetNumOfBooks()
    {
        int counter = 0;
        for (int i = 0; i < booksList.Length; i++)
        {
            if (booksList[i] != "Empty place")
                counter++;
        }

        return counter;
    }

    public void DisplayBooks()
    {
        for (int i = 0; i < booksList.Length; i++)
        {
            Console.WriteLine($"Book {i + 1}: \"{booksList[i]}\"");
        }
    }

    public static BooksToRead operator +(BooksToRead booksToRead, string bookName)
    {
        if (booksToRead.Size < booksToRead.booksList.Length)
        {
            booksToRead.booksList[booksToRead.Size++] = bookName;
        }
        else
        {
            Console.WriteLine("The list is full. Cannot add more books.");
        }
        return booksToRead;
    }

    public static BooksToRead operator -(BooksToRead booksToRead, string bookName)
    {
        for (int i = 0; i < booksToRead.booksList.Length; i++)
        {
            if (booksToRead.booksList[i] == bookName)
            {
                booksToRead.booksList[i] = "Empty place";
                return booksToRead;
            }
        }

        Console.WriteLine("There is no such book in the list");

        return booksToRead;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BooksToRead books = new BooksToRead(5);

        books += "Book1";
        books += "Book2";
        books += "Book3";
        books[3] = "Book4";
        books[4] = "Book5";

        Console.WriteLine("Books in the list:");
        books.DisplayBooks();

        Console.WriteLine("Contains \"Book2\": " + books.ContainsBook("Book2"));
        Console.WriteLine("Contains \"Book6\": " + books.ContainsBook("Book6"));

        books -= "Book3";

        Console.WriteLine("\nBooks in the list after removing Book3:");
        books.DisplayBooks();

        Console.WriteLine("\nNumber of books: " + books.GetNumOfBooks());
        Console.WriteLine($"Size: {books.Size}");
    }
}

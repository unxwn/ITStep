using System;
using System.Collections.Generic;

namespace Practice10
{
    class Program
    {
        static void Main(string[] args)
        {
            Alphabet alphabet = new Alphabet();

            foreach (char letter in alphabet)
            {
                Console.Write(letter);
            }

            Console.WriteLine(alphabet.GetLetterByNumber(0));
            Console.WriteLine(alphabet.GetPreviousLetter('Z'));
            Console.WriteLine(alphabet.GetNextLetter('A'));

            Console.WriteLine();
            Console.WriteLine();

            House house = new House();

            Flat flat1 = new Flat();
            flat1.AddResident("Bill");
            flat1.AddResident("Bo");

            Flat flat2 = new Flat();
            flat2.AddResident("John");
            flat2.AddResident("Emilia");

            house.AddFlat(1, flat1);
            house.AddFlat(2, flat2);

            foreach (KeyValuePair<int, Flat> el in house)
            {
                Console.WriteLine($"Flat {el.Key}: {el.Value}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorseCodeLib;

namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // To Morse Code
            Console.WriteLine("Enter the text to be encrypted in Morse Code:");
            string inputText1 = Console.ReadLine();

            string morseCode = MorseCode.ConvertToMorseCode(inputText1);
            Console.WriteLine("Encrypting result:");
            Console.WriteLine(morseCode);

            // To normal alphabet
            Console.WriteLine("\nEnter the text to be decrypted from Morse Code:");
            string inputText2 = Console.ReadLine();

            string text = MorseCode.ConvertFromMorseCode(inputText2);
            Console.WriteLine("Decrypting result:");
            Console.WriteLine(text);
        }
    }
}

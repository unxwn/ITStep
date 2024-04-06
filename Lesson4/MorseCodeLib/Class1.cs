using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeLib
{
    public class MorseCode
    {
        private static char[] normalAlphabet = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            ' ', ',', '.'
        };

        private static string[] morseAlphabet = {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--",
            "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..",
            "/", "--..--", ".-.-.-"
        };

        public static string ConvertToMorseCode(string text)
        {
            text = text.Trim().ToLower();
            string result = "";

            foreach (char c in text)
            {
                int index = Array.IndexOf(normalAlphabet, c);

                if (index != -1)
                {
                    result += morseAlphabet[index] + " ";
                }
            }

            return result;
        }

        public static string ConvertFromMorseCode(string text)
        {
            string[] morseCode = text.Trim().ToLower().Split(' ');

            string result = "";

            foreach (string str in morseCode)
            {
                int index = Array.IndexOf(morseAlphabet, str);

                if (index != -1)
                {
                    result += normalAlphabet[index];
                }
            }

            return result;
        }
    }
}

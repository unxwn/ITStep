using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice10
{
    public class Alphabet : IEnumerable
    {
        private readonly List<char> letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public IEnumerator GetEnumerator()
        {
            return letters.GetEnumerator();
        }

        public char GetLetterByNumber(int number)
        {
            if (number >= 0 && number < letters.Count)
            {
                return letters[number];
            }
            throw new ArgumentException();
        }

        public char GetPreviousLetter(char letter)
        {
            int index = letters.IndexOf(letter);
            if (index > 0)
            {
                return letters[index - 1];
            }
            throw new ArgumentException();
        }

        public char GetNextLetter(char letter)
        {
            int index = letters.IndexOf(letter);
            if (index >= 0 && index < letters.Count - 1)
            {
                return letters[index + 1];
            }
            throw new ArgumentException();
        }
    }
}

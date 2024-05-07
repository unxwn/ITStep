using System.Collections;
using System.Collections.Generic;

namespace Practice10
{
    internal class Flat : IEnumerable
    {
        private readonly List<string> residents = new List<string>();

        public void AddResident(string resident)
        {
            residents.Add(resident);
        }

        public override string ToString() { return string.Join(", ", residents); }

        public IEnumerator GetEnumerator()
        {
            return residents.GetEnumerator();
        }
    }
}

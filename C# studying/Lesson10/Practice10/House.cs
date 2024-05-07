using System.Collections;
using System.Collections.Generic;

namespace Practice10
{
    public class House : IEnumerable
    {
        private readonly Dictionary<int, Flat> flats = new Dictionary<int, Flat>();

        public void AddFlat (int number, Flat flat)
        {
            flats[number] = flat;
        }

        public IEnumerator GetEnumerator()
        {
            return flats.GetEnumerator();
        }
    }
}

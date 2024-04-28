using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice9
{
    internal class Tasks<T> where T : IComparable<T> // 1, 2, 3
    {
        public static T GetMaxValue(T a, T b, T c)
        {
            T maxValue = a;
            maxValue = b.CompareTo(maxValue) > 0 ? b : maxValue;
            maxValue = c.CompareTo(maxValue) > 0 ? c : maxValue;
            return maxValue;
        }

        public static T GetMinValue(T a, T b, T c)
        {
            T minValue = a;
            minValue = b.CompareTo(minValue) < 0 ? b : minValue;
            minValue = c.CompareTo(minValue) < 0 ? c : minValue;
            return minValue;
        }

        public static T GetSum(T[] arr)
        {
            dynamic sum = default(T);
            foreach (T el in arr)
            {
                sum += el;
            }

            return sum;
        }

    }
}

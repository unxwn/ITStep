using System;

namespace Homework8
{
    internal struct DecimalNumber
    {
        public int Value { get; set; }

        public DecimalNumber(int value)
        {
            Value = value;
        }

        public string ToBinary()
        {
            return Convert.ToString(Value, 2);
        }

        public string ToOctal()
        {
            return Convert.ToString(Value, 8);
        }

        public string ToHexadecimal()
        {
            return Convert.ToString(Value, 16).ToUpperInvariant();
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}

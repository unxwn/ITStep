namespace Practice8
{
    internal struct Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Add(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Denominator + fraction.Numerator * Denominator;
            int newDenominator = Denominator * fraction.Denominator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public Fraction Subtract(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Denominator - fraction.Numerator * Denominator;
            int newDenominator = Denominator * fraction.Denominator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public Fraction Multiply(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Numerator;
            int newDenominator = Denominator * fraction.Denominator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public Fraction Divide(Fraction fraction)
        {
            int newNumerator = Numerator * fraction.Denominator;
            int newDenominator = Denominator * fraction.Numerator;
            return new Fraction(newNumerator, newDenominator).Simplify();
        }

        public int GetGreatestCommonDivisor(int a, int b) // 25, 10
        {
            if (a < b)
            {
                int temp = a;
                a = b;
                b = temp;
            }

            while (b != 0)
            {
                int temp = b; // 10 // 5 
                b = a % b; // 5 // 0
                a = temp; // 10 // 5
            }
            return a; // 5
        }

        public Fraction Simplify()
        {
            int gcd = GetGreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
            return new Fraction(Numerator, Denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}

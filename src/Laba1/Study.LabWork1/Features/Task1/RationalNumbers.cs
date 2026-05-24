using System;

namespace Study.LabWork1.Features.Task1
{
    public class RationalNumber
    {
        public int Numerator { get; }
        public int Denominator { get; }
        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть нулевым.");
            }

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            int a = Math.Abs(numerator);
            int b = denominator;
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            int gcd = a;

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
        }

        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            return r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator;
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1 == r2);
        }

        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            return r1.Numerator * r2.Denominator < r2.Numerator * r1.Denominator;
        }

        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            return r1.Numerator * r2.Denominator <= r2.Numerator * r1.Denominator;
        }

        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            return r1.Numerator * r2.Denominator > r2.Numerator * r1.Denominator;
        }

        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            return r1.Numerator * r2.Denominator >= r2.Numerator * r1.Denominator;
        }

        public override string ToString()
        {
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }
            return $"{Numerator}/{Denominator}";
        }
    }
}

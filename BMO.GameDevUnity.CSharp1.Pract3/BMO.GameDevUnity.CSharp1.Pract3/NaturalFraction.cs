using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMO.GameDevUnity.CSharp1.Pract3
{
    class NaturalFraction
    {
        private long numerator;
        private long denominator;

        public NaturalFraction(long numerator, long denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public long GetNumerator()
        {
            return numerator;
        }

        public long GetDenominator()
        {
            return denominator;
        }

        public static NaturalFraction Sum(NaturalFraction a, NaturalFraction b)
        {
            long NOK = FindNOK(a.denominator, b.denominator);
            long aNum = a.numerator;
            long bNum = b.numerator;
            aNum *= (NOK / a.denominator);
            bNum *= (NOK / b.denominator);
            return new NaturalFraction(aNum + bNum, NOK);
        }

        public static NaturalFraction Difference(NaturalFraction a, NaturalFraction b)
        {
            long NOK = FindNOK(a.denominator, b.denominator);
            long aNum = a.numerator;
            long bNum = b.numerator;
            aNum *= (NOK / a.denominator);
            bNum *= (NOK / b.denominator);
            return new NaturalFraction(aNum - bNum, NOK);
        }

        public static NaturalFraction Multiplication(NaturalFraction a, NaturalFraction b)
        {            
            return new NaturalFraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static NaturalFraction Division(NaturalFraction a, NaturalFraction b)
        {
            return new NaturalFraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public void Print()
        {
            Console.WriteLine($"Значение дроби равно = {numerator} / {denominator}");
        }

        private static long FindNOD(long a, long b)
        {
            if (a == b)
            {
                return a;
            }
            if (a > b)
            {
                long tmp = a;
                a = b;
                b = tmp;
            }
            return FindNOD(a, b - a);
        }

        private static long FindNOK(long a, long b)
        {
            return ((a * b) / FindNOD(a, b));
        }
    }
}

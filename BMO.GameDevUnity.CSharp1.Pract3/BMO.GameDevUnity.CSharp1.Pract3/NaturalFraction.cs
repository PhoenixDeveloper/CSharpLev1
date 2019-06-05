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
        public readonly double DecimalFraction;

        public NaturalFraction(long numerator, long denominator)
        {
            SetNumerator(numerator);
            SetDenominator(denominator);
            DecimalFraction = (double)numerator / (double)denominator;
    }

        /// <summary>
        /// Метод для получения числителя
        /// </summary>
        public long GetNumerator()
        {
            return numerator;
        }

        /// <summary>
        /// Метод для изменения числителя
        /// </summary>
        public void SetNumerator(long numerator)
        {
            this.numerator = numerator;
        }

        /// <summary>
        /// Метод для получения знаменателя
        /// </summary>
        public long GetDenominator()
        {
            return denominator;
        }

        /// <summary>
        /// Метод для изменения знаменателя
        /// </summary>
        public void SetDenominator(long denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            else
            {
                if (denominator < 0)
                {
                    this.numerator = -this.numerator;
                    this.denominator = -denominator;
                }
                else
                {
                    this.denominator = denominator;
                }
            }
        }

        /// <summary>
        /// Метод возврающий сумму двух натуральных дробей
        /// </summary>
        public static NaturalFraction Sum(NaturalFraction a, NaturalFraction b)
        {
            long NOK = FindNOK(a.denominator, b.denominator);
            long aNum = a.numerator;
            long bNum = b.numerator;
            aNum *= (NOK / a.denominator);
            bNum *= (NOK / b.denominator);
            return new NaturalFraction(aNum + bNum, NOK);
        }

        /// <summary>
        /// Метод возврающий разность двух натуральных дробей
        /// </summary>
        public static NaturalFraction Difference(NaturalFraction a, NaturalFraction b)
        {
            long NOK = FindNOK(a.denominator, b.denominator);
            long aNum = a.numerator;
            long bNum = b.numerator;
            aNum *= (NOK / a.denominator);
            bNum *= (NOK / b.denominator);
            return new NaturalFraction(aNum - bNum, NOK);
        }

        /// <summary>
        /// Метод возврающий перемножение двух натуральных дробей
        /// </summary>
        public static NaturalFraction Multiplication(NaturalFraction a, NaturalFraction b)
        {            
            return new NaturalFraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        /// <summary>
        /// Метод возврающий результат деления двух натуральных дробей
        /// </summary>
        public static NaturalFraction Division(NaturalFraction a, NaturalFraction b)
        {
            return new NaturalFraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        /// <summary>
        /// Метод выводящий в консоль значение дроби
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Значение дроби равно = {numerator} / {denominator}");
        }
        
        /// <summary>
        /// Метод для перевода дроби в string
        /// </summary>
        public override string ToString()
        {
            return $"({numerator} / {denominator})";
        }
        
        /// <summary>
        /// Метод для сокращения дроби
        /// </summary>
        public void FractionReduction()
        {
            long NOD = FindNOD(numerator, denominator);
            numerator /= NOD;
            denominator /= NOD;
        }

        /// <summary>
        /// Метод для нахождения наибольшего общего делителя
        /// </summary>
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

        /// <summary>
        /// Метод для нахождения наименьшего общего кратного
        /// </summary>
        private static long FindNOK(long a, long b)
        {
            return ((a * b) / FindNOD(a, b));
        }
    }
}

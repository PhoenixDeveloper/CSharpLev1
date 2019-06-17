using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMO.GameDevUnity.CSharp1.Pract6
{
    public delegate double Fun(double a, double x);

    class Program
    {
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- a ----------- x ----- F(a, x)-");
            for (int i = 0; i < b; i++)
            {
                Console.WriteLine("| {0,8:0.000} | | {1,8:0.000} | {2,8:0.000} |", a, x, F(a, x));
                a++; x++;
            }
            Console.WriteLine("------------------------------------");
        }

        public static double FuncFirst(double a, double x)
        {
            return a*Math.Pow(x, 2);
        }

        public static double FuncSecond(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Таблица функции a*x^2:");

            Table(new Fun(FuncFirst), -2, 2, 10);

            Console.WriteLine("Таблица функции a*sin(x):");

            Table(new Fun(FuncSecond), -2, 2, 10);

            Console.ReadKey();
        }
    }
}

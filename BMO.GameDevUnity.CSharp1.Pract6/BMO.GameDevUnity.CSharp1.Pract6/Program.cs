using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMO.GameDevUnity.CSharp1.Pract6
{
    public delegate double Fun(double a, double x);
    public delegate double FunMin(double x);

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

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static void SaveFunc(string fileName, FunMin fun, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(fun(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }

        static void Main(string[] args)
        {
            #region Первое задание
            Console.WriteLine("Первое задание: ");

            Console.WriteLine("Таблица функции a*x^2:");

            Table(new Fun(FuncFirst), -2, 2, 10);

            Console.WriteLine("Таблица функции a*sin(x):");

            Table(new Fun(FuncSecond), -2, 2, 10);
            #endregion

            #region Второе задание
            Console.WriteLine("Минимум функции (x * x - 50 * x + 10) на промежутке [-100, 100]:");
            SaveFunc("data.bin", F, -100, 100, 0.5);
            Console.WriteLine(Load("data.bin"));
            #endregion

            Console.ReadKey();
        }
    }
}

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

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * Math.Sin(x);
        }

        public static double F3(double x)
        {
            return (Math.Pow(x,2)-10)*Math.Pow(x, 3);
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
            Console.WriteLine("Второе задание:");
            while (true)
            {
                Console.WriteLine(@"
                            Выберите одну из представленных функций:
                            1: x * x - 50 * x + 10
                            2: x * sin(x)
                            3: (x^2 - 10) * x^3
                            8: Exit");
                int key;
                int a, b;
                int.TryParse(Console.ReadLine(), out key);
                if (key == 8)
                {
                    return;
                }
                Console.Write("Введите начало отрезка: ");
                int.TryParse(Console.ReadLine(), out a);
                Console.Write("Введите конец отрезка: ");
                int.TryParse(Console.ReadLine(), out b);
                switch (key)
                {
                    case 1:
                        Console.WriteLine($"Минимум функции (x * x - 50 * x + 10) на промежутке [{a}, {b}]:");
                        SaveFunc("data.bin", F1, a, b, 0.5);
                        Console.WriteLine(Load("data.bin"));
                        break;
                    case 2:
                        Console.WriteLine($"Минимум функции (x * sin(x)) на промежутке [{a}, {b}]:");
                        SaveFunc("data.bin", F2, a, b, 0.5);
                        Console.WriteLine(Load("data.bin"));
                        break;
                    case 3:
                        Console.WriteLine($"Минимум функции ((x^2 - 10) * x^3) на промежутке [{a}, {b}]:");
                        SaveFunc("data.bin", F3, a, b, 0.5);
                        Console.WriteLine(Load("data.bin"));
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
                
            }            
            
            #endregion

            Console.ReadKey();
        }
    }
}

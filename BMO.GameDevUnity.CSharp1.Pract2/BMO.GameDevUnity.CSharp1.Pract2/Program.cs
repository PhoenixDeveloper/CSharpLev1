using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMO.GameDevUnity.CSharp1.Pract2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите номер задания(введите exit для выхода): ");
                string task = Console.ReadLine();
                switch (task)
                {
                    case "1":
                        Console.Write("Введите первое число: ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        double b = double.Parse(Console.ReadLine());
                        Console.Write("Введите третье число: ");
                        double c = double.Parse(Console.ReadLine());
                        Console.WriteLine("Минимальным является число {0}", MinNum(a, b, c));
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Введены некорректные данные");
                        break;
                }
            }
            
        }

        static double MinNum(double a, double b, double c)
        {
            if (a<b && a<c)
            {
                return a;
            }
            else if (b<c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }
    }
}

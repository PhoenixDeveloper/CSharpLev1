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
                    case "2":
                        Console.Write("Введите целочисленное число: ");
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Количество цифр в числе = {0}", AmountNumber(number));
                        break;
                    case "3":
                        int[] numbers = new int[1];
                        int numberCirle;
                        while (true)
                        {
                            Console.Write("Введите целочисленное число(при вводе нуля ввод останавливается): ");
                            numberCirle = int.Parse(Console.ReadLine());
                            if (numberCirle == 0)
                            {
                                break;
                            }
                            Array.Resize(ref numbers, numbers.Length + 1);
                            numbers[numbers.Length - 1] = numberCirle;
                        }
                        Console.WriteLine("Сумма нечетных положительных чисел равна {0}", SumOddPositiveNumbers(numbers));
                        break;
                    case "4":
                        int amountAuthentication = 0;
                        do
                        {
                            Console.Write("Введите логин: ");
                            string login = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            string password = Console.ReadLine();
                            if (Authentication(login,password))
                            {
                                Console.WriteLine("Добро пожаловать!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверная связка логин/пароль");
                            }
                            amountAuthentication++;
                        }
                        while (amountAuthentication < 3);
                        if (amountAuthentication == 3)
                        {
                            Console.WriteLine("Превышено количество попыток аутентификации");
                        }
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

        static int AmountNumber(int number)
        {
            int amount = 0;
            while (number!=0)
            {
                amount++;
                number /= 10;
            }
            return amount;
        }

        static int SumOddPositiveNumbers(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]>0 && numbers[i]%2==1)
                {
                    sum += numbers[i];
                }
            }
            return sum;
        }

        static bool Authentication(string login, string password)
        {
            return (login == "root" && password == "GeekBrains") ? true : false;           
        }
    }
}

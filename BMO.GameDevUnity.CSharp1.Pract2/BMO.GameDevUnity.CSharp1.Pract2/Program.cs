using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMO.GameDevUnity.CSharp1.Pract2
{
    class Program
    {
        static long sum = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(@"© (Беленко Михаил Олегович),
                               Задания:
                               1. Написать метод, возвращающий минимальное из трёх чисел.
                               2. Написать метод подсчета количества цифр числа.
                               3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечётных положительных чисел.
                               4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
                               5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме. 
                                  б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
                               6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
                               7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
                                  б) *Разработать рекурсивный метод, который считает сумму чисел от a до b."
                             );
            while (true)
            {                
                Console.Write("Введите номер задания(введите exit для выхода): ");
                string task = Console.ReadLine();
                switch (task)
                {
                    case "1":
                        Console.Write("Введите первое число: ");
                        InsertDouble(out double a);
                        Console.Write("Введите второе число: ");
                        InsertDouble(out double b);
                        Console.Write("Введите третье число: ");
                        InsertDouble(out double c);
                        Console.WriteLine("Минимальным является число {0}", MinNum(a, b, c));
                        break;
                    case "2":
                        Console.Write("Введите целочисленное число: ");
                        InsertInt64(out long number);
                        Console.WriteLine("Количество цифр в числе = {0}", AmountNumber(number));
                        break;
                    case "3":                        
                        char lastSymbol = '\t';
                        string textLine = "";
                        ConsoleKeyInfo cki;

                        Console.Write("Введите ряд целочисленных чисел(при вводе нуля ввод останавливается): ");
                        while (true)
                        {
                            cki = Console.ReadKey();

                            if (cki.KeyChar == '0' && (lastSymbol == ' ' || lastSymbol == '\t' || lastSymbol == '\n' || lastSymbol == '\r'))
                            {
                                break;
                            }
                            textLine += cki.KeyChar;
                            lastSymbol = cki.KeyChar;
                        }

                        string[] textLineArray = textLine.Split(' ', '\t', '\n', '\r');
                        int[] numbers = new int[textLineArray.Length - 1];
                        for (int i = 0; i < textLineArray.Length-1; i++)
                        {
                            int.TryParse(textLineArray[i], out numbers[i]);                            
                        }

                        Console.WriteLine("\nСумма нечетных положительных чисел равна {0}", SumOddPositiveNumbers(numbers));
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
                    case "5":
                        Console.Write("Введите рост в сантиметрах: ");
                        double height = InsertDouble();
                        Console.Write("Введите вес в килограммах: ");
                        double weight = InsertDouble();
                        Console.WriteLine(BMI(height / 100, weight));
                        break;
                    case "6":
                        DateTime startTime;
                        DateTime endTime;
                        TimeSpan resultTime;
                        Console.Write("Введите начальное число: ");
                        long start = InsertInt64();
                        Console.Write("Введите конечное число: ");
                        long end = InsertInt64();
                        startTime = DateTime.Now;
                        Console.WriteLine($"Количество 'хороших' чисел равно = {AmountGoodNumbres(start, end)}");
                        endTime = DateTime.Now;
                        resultTime = endTime - startTime;
                        Console.WriteLine($"Время выполнения программы в секундах = {resultTime.Seconds}");
                        break;
                    case "7":
                        Console.Write("Введите начальное число: ");
                        long startNum = long.Parse(Console.ReadLine());
                        Console.Write("Введите конечное число: ");
                        long endNum = long.Parse(Console.ReadLine());
                        ShowLineNumber(startNum, endNum);
                        Console.WriteLine($"Сумма введенных чисел равна = {SumLineNumber(startNum, endNum)}");
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

        static int AmountNumber(long number)
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

        static string BMI(double height, double weight)
        {
            double BMI = weight / (Math.Pow(height, 2));
            if (BMI < 18.5)
            {
                return $"ИМТ ({BMI}) ниже нормы, для нормализации показателя необходимо набрать {(18.5-BMI)*Math.Pow(height, 2)} кг";
            }
            else if (BMI > 24.99)
            {
                return $"ИМТ ({BMI}) выше нормы, для нормализации показателя необходимо сбросить {(BMI - 24.99) * Math.Pow(height, 2)} кг";
            }
            else
            {
                return $"ИМТ ({BMI}) в пределах нормальных значений";
            }
        }

        static int AmountGoodNumbres(long start, long end)
        {
            int amount = 0;
            long sum = 0;
            long number;
            Console.WriteLine("Хорошие числа:");
            for (long i = start; i <= end; i++)
            {
                number = i;
                for (int j = AmountNumber(i); j > 1; j--)
                {
                    sum += number / Convert.ToInt64(Math.Pow(10, (j - 1)));
                    number = number % Convert.ToInt64(Math.Pow(10, (j - 1)));
                }
                sum += number;
                if (i % sum == 0)
                {
                    Console.WriteLine(i);
                    amount++;
                }
                sum = 0;
            }
            return amount;
        }

        static void ShowLineNumber(long start, long end)
        {
            Console.WriteLine(start);
            if (start < end) ShowLineNumber(start + 1, end);            
        }

        static long SumLineNumber(long start, long end)
        {            
            if (start < end)
            {
                sum += start;
                return SumLineNumber(start + 1, end);
            }
            long result = sum;
            sum = 0;
            return result;
        }
        
        static void InsertInt32(out int output)
        {
            int.TryParse(Console.ReadLine(), out output);
        }

        static int InsertInt32()
        {
            int output;
            int.TryParse(Console.ReadLine(), out output);
            return output;
        }

        static void InsertInt64(out long output)
        {
            long.TryParse(Console.ReadLine(), out output);
        }

        static long InsertInt64()
        {
            long output;
            long.TryParse(Console.ReadLine(), out output);
            return output;
        }

        static void InsertDouble(out double output)
        {
            double.TryParse(Console.ReadLine(), out output);
        }

        static double InsertDouble()
        {
            double output;
            double.TryParse(Console.ReadLine(), out output);
            return output;
        }
    }
}

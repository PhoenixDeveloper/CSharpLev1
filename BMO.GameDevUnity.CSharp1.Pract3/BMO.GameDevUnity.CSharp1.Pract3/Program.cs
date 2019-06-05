using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
 * Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
 * Написать программу, демонстрирующую все разработанные элементы класса.
* Добавить свойства типа int для доступа к числителю и знаменателю;
* Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException* 
* ("Знаменатель не может быть равен 0");
*** Добавить упрощение дробей. */

namespace BMO.GameDevUnity.CSharp1.Pract3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NaturalFraction> naturalFractionList = new List<NaturalFraction>();
            Console.WriteLine(@"
                                1. Вывести список натуральных дробей.
                                2. Ввести новую натуральную дробь.
                                3. Удалить натуральную дробь по индексу.");
            while (true)
            {
                Console.Write("Введите номер действия: ");
                string task = Console.ReadLine();
                switch (task)
                {
                    case "1":
                        for (int i = 0; i < naturalFractionList.Count; i++)
                        {
                            Console.WriteLine($"{i} : {naturalFractionList[i].ToString()}");
                        }
                        break;
                    case "2":
                        Console.Write("Введите числитель: ");
                        long numerator = InsertInt64();
                        Console.Write("Введите знаменатель: ");
                        long denominator = InsertInt64();
                        naturalFractionList.Add(new NaturalFraction(numerator, denominator));
                        break;
                    case "3":
                        int index;
                        while (true)
                        {
                            Console.Write("Введите индекс дроби: ");                            
                            InsertInt32(out index);
                            if (index >= 0 && index < naturalFractionList.Count)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Индекс вышел за зону списка!");
                            }
                        }
                        naturalFractionList.RemoveAt(index);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Введены некорректные данные");
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.ReadKey();
        }


        /// <summary>
        /// Метод позволяет вводить через консоль данные типа integer
        /// </summary>
        /// <param name="output">Введеное через консоль число, преобразованное в тип integer</param>
        static void InsertInt32(out int output)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введены некоректные данные!/nПопробуйте снова: ");
                }
            }
        }

        /// <summary>
        /// Метод позволяет вводить через консоль данные типа integer
        /// </summary>
        /// <returns>Введеное через консоль число, преобразованное в тип integer</returns>
        static int InsertInt32()
        {
            int output;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введены некоректные данные!/nПопробуйте снова: ");
                }
            }
            return output;
        }

        /// <summary>
        /// Метод позволяет вводить через консоль данные типа long
        /// </summary>
        /// <param name="output">Введеное через консоль число, преобразованное в тип long</param>
        static void InsertInt64(out long output)
        {
            while (true)
            {
                if (long.TryParse(Console.ReadLine(), out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введены некоректные данные!\nПопробуйте снова: ");
                }
            }
        }

        /// <summary>
        /// Метод позволяет вводить через консоль данные типа long
        /// </summary>
        /// <returns>Введеное через консоль число, преобразованное в тип long</returns>
        static long InsertInt64()
        {
            long output;
            while (true)
            {
                if (long.TryParse(Console.ReadLine(), out output))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введены некоректные данные!\nПопробуйте снова: ");
                }
            }
            return output;
        }
    }
}

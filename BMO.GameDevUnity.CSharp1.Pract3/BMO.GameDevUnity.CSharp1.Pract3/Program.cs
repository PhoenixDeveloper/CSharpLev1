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
                                3. Удалить натуральную дробь по индексу.
                                4. Суммирование двух натуральных дробей.
                                5. Вычитание двух натуральных дробей.
                                6. Перемножение двух натуральных дробей.
                                7. Деление двух натуральных дробей.
                                8. Замена числителя у натуральной дроби.
                                9. Замена знаменателя у натуральной дроби.
                                10. Перевод натуральной дроби в десятичную
                                11. Сокращение дроби.");
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
                    case "4":
                        Console.Write("Введите индекс первой дроби: ");
                        InsertInt32(out index);
                        Console.Write("Введите индекс второй дроби: ");
                        InsertInt32(out int index2);
                        NaturalFraction result = NaturalFraction.Sum(naturalFractionList[index], naturalFractionList[index2]);
                        Console.WriteLine($"{naturalFractionList[index].ToString()} + {naturalFractionList[index2].ToString()} = " +
                            $"{result}");
                        Console.WriteLine("Сохранить дробь в список? (yes/no)");
                        string choise;
                        while (true)
                        {
                            choise = Console.ReadLine();
                            if (choise == "yes")
                            {
                                naturalFractionList.Add(result);
                                break;
                            }
                            else if (choise == "no")
                            {
                                break;
                            }
                        }
                        break;
                    case "5":
                        Console.Write("Введите индекс первой дроби: ");
                        InsertInt32(out index);
                        Console.Write("Введите индекс второй дроби: ");
                        InsertInt32(out index2);
                        result = NaturalFraction.Difference(naturalFractionList[index], naturalFractionList[index2]);
                        Console.WriteLine($"{naturalFractionList[index].ToString()} - {naturalFractionList[index2].ToString()} = " +
                            $"{result}");
                        Console.WriteLine("Сохранить дробь в список? (yes/no)");                        
                        while (true)
                        {
                            choise = Console.ReadLine();
                            if (choise == "yes")
                            {
                                naturalFractionList.Add(result);
                                break;
                            }
                            else if (choise == "no")
                            {
                                break;
                            }
                        }
                        break;
                    case "6":
                        Console.Write("Введите индекс первой дроби: ");
                        InsertInt32(out index);
                        Console.Write("Введите индекс второй дроби: ");
                        InsertInt32(out index2);
                        result = NaturalFraction.Multiplication(naturalFractionList[index], naturalFractionList[index2]);
                        Console.WriteLine($"{naturalFractionList[index].ToString()} * {naturalFractionList[index2].ToString()} = " +
                            $"{result}");
                        Console.WriteLine("Сохранить дробь в список? (yes/no)");                        
                        while (true)
                        {
                            choise = Console.ReadLine();
                            if (choise == "yes")
                            {
                                naturalFractionList.Add(result);
                                break;
                            }
                            else if (choise == "no")
                            {
                                break;
                            }
                        }
                        break;
                    case "7":
                        Console.Write("Введите индекс первой дроби: ");
                        InsertInt32(out index);
                        Console.Write("Введите индекс второй дроби: ");
                        InsertInt32(out index2);
                        result = NaturalFraction.Division(naturalFractionList[index], naturalFractionList[index2]);
                        Console.WriteLine($"{naturalFractionList[index].ToString()} / {naturalFractionList[index2].ToString()} = " +
                            $"{result}");
                        Console.WriteLine("Сохранить дробь в список? (yes/no)");                        
                        while (true)
                        {
                            choise = Console.ReadLine();
                            if (choise == "yes")
                            {
                                naturalFractionList.Add(result);
                                break;
                            }
                            else if (choise == "no")
                            {
                                break;
                            }
                        }
                        break;
                    case "8":
                        Console.Write("Введите индекс дроби: ");
                        InsertInt32(out index);
                        Console.WriteLine($"Вы желаете изменить данную дробь - {naturalFractionList[index].ToString()} ? (yes/no)");
                        while (true)
                        {
                            choise = Console.ReadLine();
                            if (choise == "yes")
                            {
                                Console.Write("Введите новый числитель: ");
                                InsertInt64(out numerator);
                                naturalFractionList[index].SetNumerator(numerator);
                                break;
                            }
                            else if (choise == "no")
                            {
                                break;
                            }                            
                        }
                        break;
                    case "9":
                        Console.Write("Введите индекс дроби: ");
                        InsertInt32(out index);
                        Console.WriteLine($"Вы желаете изменить данную дробь - {naturalFractionList[index].ToString()} ? (yes/no)");
                        while (true)
                        {
                            choise = Console.ReadLine();
                            if (choise == "yes")
                            {
                                Console.Write("Введите новый знаменатель: ");
                                InsertInt64(out denominator);
                                naturalFractionList[index].SetDenominator(denominator);
                                break;
                            }
                            else if (choise == "no")
                            {
                                break;
                            }
                        }
                        break;
                    case "10":
                        Console.Write("Введите индекс дроби: ");
                        InsertInt32(out index);
                        Console.WriteLine($"Натуральная дробь {naturalFractionList[index].ToString()} в десятичном виде = " +
                            $"{naturalFractionList[index].DecimalFraction}");
                        break;
                    case "11":
                        Console.Write("Введите индекс дроби: ");
                        InsertInt32(out index);
                        Console.WriteLine($"Вы желаете сократить данную дробь - {naturalFractionList[index].ToString()} ? (yes/no)");
                        while (true)
                        {
                            choise = Console.ReadLine();
                            if (choise == "yes")
                            {
                                naturalFractionList[index].FractionReduction();
                                break;
                            }
                            else if (choise == "no")
                            {
                                break;
                            }
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

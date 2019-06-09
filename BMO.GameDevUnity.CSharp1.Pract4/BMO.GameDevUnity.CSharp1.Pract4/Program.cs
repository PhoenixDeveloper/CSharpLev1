using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibraries;

namespace BMO.GameDevUnity.CSharp1.Pract4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                                1. Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
                                2. Реализуйте задачу 1 в виде статического класса StaticClass;
                                    а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
                                    б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
                                    в)**Добавьте обработку ситуации отсутствия файла на диске.
                                3.  а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
                                    б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
                                    в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
                                4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
                                5.  *а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
                                    **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
                                    **в) Обработать возможные исключительные ситуации при работе с файлами.
                              ");
            while (true)
            {
                Console.Write("Введите номер задания(введите exit для выхода): ");
                string task = Console.ReadLine();
                switch (task)
                {
                    case "1":
                        int[] arrayNumber = new int[20];
                        int countThreeNumber = 0;
                        string countThreeNumberPrint = "";
                        Random randomNumber = new Random();
                        arrayNumber[0] = randomNumber.Next(-10000, 10000);
                        Console.Write($"{arrayNumber[0]} ");
                        for (int i = 1; i < arrayNumber.Length; i++)
                        {
                            arrayNumber[i] = randomNumber.Next(-10000, 10000);
                            if (arrayNumber[i] != 0 && arrayNumber[i-1] != 0)
                            {
                                if (((arrayNumber[i] % 3 == 0) ^ (arrayNumber[i - 1] % 3 == 0)))
                                {
                                    countThreeNumber++;
                                    countThreeNumberPrint += ($"{countThreeNumber} пара = {arrayNumber[i - 1]} - {arrayNumber[i]}\n");
                                }
                            }                            
                            Console.Write($"{arrayNumber[i]} ");
                        }
                        Console.Write($"\n{countThreeNumberPrint}");
                        Console.WriteLine($"Количество пар элементов массива, в которых только одно число делится на 3 = {countThreeNumber}");
                        break;
                    case "2":
                        arrayNumber = StaticClass.ArrayReadFile(@"ArrayNumber.txt");
                        Console.WriteLine($"Количество пар элементов массива, в которых только одно число делится на 3 = {StaticClass.CountThreeNumber(arrayNumber)}");
                        break;
                    case "3":
                        CoolArray array = new CoolArray(10, -10, 4);
                        array[3] = 26;
                        Console.WriteLine($"Сумма элементов массива равна = {array.Sum}");
                        Console.WriteLine($"Максимальный элемент = {array.Max}, количество = {array.MaxCount}");
                        int[] b = array.Inverse();
                        for (int i = 0; i < b.Length; i++)
                        {
                            Console.WriteLine($"{i} элемементы - {array[i]} : {b[i]}");
                        }
                        array.Multi(5);
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.WriteLine($"{i} элемент array = {array[i]}");
                        }
                        Dictionary<int, int> keys = array.NumberElelementsArray();                        
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Введены некорректные данные");
                        break;
                }
            }
        }
    }
}

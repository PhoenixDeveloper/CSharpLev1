using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMO.GameDevUnity.CSharp1.Pract5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                                1. Задача ЕГЭ.
                                    На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
                                    <Фамилия> <Имя> <оценки>,
                                    где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
                                    Иванов Петр 4 5 3
                                    Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
                                2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
                                    а) Вывести только те слова сообщения,  которые содержат не более n букв.
                                    б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
                                    в) Найти самое длинное слово сообщения.
                                    г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
                                    д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary."
                              );
            Console.WriteLine("Первое задание: ");
            TaskExam("Students.txt");
            Console.WriteLine("Второе задание: ");
            string message = "Милый свитер носит мальчик, милый милый, что нельзя. Есть у мальчика собачка, больше всех ему нужна";
            string[] arrayWords = new string[3] { "милый", "мальчик", "нужна" };
            Console.WriteLine($"Первоначальное сообщение: {message}");
            Message.NoMore(message, 5);
            Message.MoreLength(message);
            Message.FrequencyAnalysis(arrayWords, message);
            Message.Delete(ref message, 'й');            
            Console.ReadKey();
        }

        static void TaskExam(string path)
        {
            string[] fileData = File.ReadAllLines(path);
            string[,] lineSeparate = new string[int.Parse(fileData[0]), 5];
            string[] buffer = new string[5];
            Student[] students = new Student[int.Parse(fileData[0])];

            //Проверка корректности введенных данных
            try
            {
                if (!((int.Parse(fileData[0]) >= 10) && (int.Parse(fileData[0]) <= 100) && (int.Parse(fileData[0]) == fileData.Length - 1)))
                {
                    Console.WriteLine("Неверно указано количество учеников");
                    return;
                }
                for (int i = 1; i < fileData.Length - 1; i++)
                {
                    buffer = fileData[i].Split();
                    for (int j = 0; j < 5; j++)
                    {
                        lineSeparate[i, j] = buffer[j];
                    }
                    if (!(lineSeparate[i, 0].Length <= 20) && (lineSeparate[i, 1].Length <= 15))
                    {
                        Console.WriteLine($"Неверно указаны Фамилия\\Имя ученика {i}");
                        return;
                    }
                    for (int g = 2; g < 5; g++)
                    {
                        if (!((int.Parse(lineSeparate[i, g]) >= 1) && (int.Parse(lineSeparate[i, g]) <= 5)))
                        {
                            Console.WriteLine($"Некорректные оценки ученика {i}");
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Некорректные данные в файле");
                return;
            }
            

            for (int i = 0; i < int.Parse(fileData[0]); i++)
            {
                students[i] = new Student(fileData[i + 1]);
            }

            Student[] worstStudents = Student.WorstStudents(students);

            Console.WriteLine("Худшие студенты:");
            for (int i = 0; i < worstStudents.Length; i++)
            {
                Console.WriteLine($"{worstStudents[i].LastName} {worstStudents[i].FirstName} : Средний балл: {worstStudents[i].AverageRating}");
            }
        }
    }
}

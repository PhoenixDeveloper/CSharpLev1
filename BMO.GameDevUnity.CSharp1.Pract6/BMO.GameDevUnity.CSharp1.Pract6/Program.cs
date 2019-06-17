using System;
using System.IO;
using System.Collections.Generic;
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

        static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {

            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }


        static void Main(string[] args)
        {
            #region Первое задание
            //Console.WriteLine("Первое задание: ");

            //Console.WriteLine("Таблица функции a*x^2:");

            //Table(new Fun(FuncFirst), -2, 2, 10);

            //Console.WriteLine("Таблица функции a*sin(x):");

            //Table(new Fun(FuncSecond), -2, 2, 10);
            #endregion

            #region Второе задание
            //Console.WriteLine("Второе задание:");
            //while (true)
            //{
            //    Console.WriteLine(@"
            //                Выберите одну из представленных функций:
            //                1: x * x - 50 * x + 10
            //                2: x * sin(x)
            //                3: (x^2 - 10) * x^3
            //                8: Exit");
            //    int key;
            //    int a, b;
            //    int.TryParse(Console.ReadLine(), out key);
            //    if (key == 8)
            //    {
            //        return;
            //    }
            //    Console.Write("Введите начало отрезка: ");
            //    int.TryParse(Console.ReadLine(), out a);
            //    Console.Write("Введите конец отрезка: ");
            //    int.TryParse(Console.ReadLine(), out b);
            //    switch (key)
            //    {
            //        case 1:
            //            Console.WriteLine($"Минимум функции (x * x - 50 * x + 10) на промежутке [{a}, {b}]:");
            //            SaveFunc("data.bin", F1, a, b, 0.5);
            //            Console.WriteLine(Load("data.bin"));
            //            break;
            //        case 2:
            //            Console.WriteLine($"Минимум функции (x * sin(x)) на промежутке [{a}, {b}]:");
            //            SaveFunc("data.bin", F2, a, b, 0.5);
            //            Console.WriteLine(Load("data.bin"));
            //            break;
            //        case 3:
            //            Console.WriteLine($"Минимум функции ((x^2 - 10) * x^3) на промежутке [{a}, {b}]:");
            //            SaveFunc("data.bin", F3, a, b, 0.5);
            //            Console.WriteLine(Load("data.bin"));
            //            break;
            //        case 8:
            //            return;
            //        default:
            //            Console.WriteLine("Неверный ввод");
            //            break;
            //    }

            //}            

            #endregion

            #region Третье задание

            int bakalavr = 0;
            int magistr = 0;
            int count = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            Dictionary<int, List<Student>> ageCourseStudent = new Dictionary<int, List<Student>>()
            {
                { 18, new List<Student>() },
                { 19, new List<Student>() },
                { 20, new List<Student>() }
            };
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_1.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                    // Также подсчитываем количество студентов разных курсов от 18 до 20 лет
                    switch (s[5])
                    {
                        case "18":
                            ageCourseStudent[18].Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                            break;
                        case "19":
                            ageCourseStudent[19].Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                            break;
                        case "20":
                            ageCourseStudent[20].Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров(они же студенты 5 и 6 курсов): {0}", magistr);
            Console.WriteLine("Бакалавров: {0}", bakalavr);
            for (int i = 18; i < 21; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    foreach (var student in ageCourseStudent[i])
                    {
                        if (student.course==j)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"Количество студентов {i} лет на {j} курсе = {count}");
                    count = 0;
                }
                Console.WriteLine();
            }

            string fileWrite = " ";
            Console.WriteLine("Первые и последние 20 студентов до сортировки по возрасту:");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].age}");
            }
            Console.WriteLine("...");
            for (int i = list.Count - 1; i > list.Count - 21; i--)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].age}");
            }
            foreach (var student in list)
            {
                fileWrite += $"{student.lastName} {student.firstName} - {student.age} \n";
            }
            File.WriteAllText("BeforeSortByAge.txt", fileWrite);
            fileWrite = " ";
            Console.WriteLine();

            Student.SortByAge(ref list);

            Console.WriteLine("Первые и последние 20 студентов после сортировки по возрасту:");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].age}");
            }
            Console.WriteLine("...");
            for (int i = list.Count - 1; i > list.Count - 21; i--)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].age}");
            }
            foreach (var student in list)
            {
                fileWrite += $"{student.lastName} {student.firstName} - {student.age} \n";
            }
            File.WriteAllText("AfterSortByAge.txt", fileWrite);
            fileWrite = " ";
            Console.WriteLine();


            Console.WriteLine("Первые и последние 20 студентов до сортировки по курсу и возрасту:");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].course}, {list[i].age}");
            }
            Console.WriteLine("...");
            for (int i = list.Count - 1; i > list.Count - 21; i--)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].course}, {list[i].age}");
            }
            foreach (var student in list)
            {
                fileWrite += $"{student.lastName} {student.firstName} - {student.course}, {student.age} \n";
            }
            File.WriteAllText("BeforeSortByCourseAndAge.txt", fileWrite);
            fileWrite = " ";
            Console.WriteLine();

            Student.SortByCourseAndAge(ref list);

            Console.WriteLine("Первые и последние 20 студентов после сортировки по курсу и возрасту:");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].course}, {list[i].age}");
            }
            Console.WriteLine("...");
            for (int i = list.Count - 1; i > list.Count - 21; i--)
            {
                Console.WriteLine($"{list[i].lastName} {list[i].firstName} - {list[i].course}, {list[i].age}");
            }
            foreach (var student in list)
            {
                fileWrite += $"{student.lastName} {student.firstName} - {student.course}, {student.age} \n";
            }
            File.WriteAllText("AfterSortByCourseAndAge.txt", fileWrite);
            fileWrite = " ";
            Console.WriteLine();

            Console.WriteLine(DateTime.Now - dt);

            #endregion
            Console.ReadKey();
        }
    }
}

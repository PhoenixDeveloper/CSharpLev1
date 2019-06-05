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
            NaturalFraction naturalFraction1 = new NaturalFraction(1, 3);
            NaturalFraction naturalFraction2 = new NaturalFraction(2, 5);

            NaturalFraction naturalFraction3 = NaturalFraction.Sum(naturalFraction1, naturalFraction2);
            naturalFraction3.Print();

            naturalFraction3 = NaturalFraction.Difference(naturalFraction1, naturalFraction2);
            naturalFraction3.Print();

            naturalFraction3 = NaturalFraction.Multiplication(naturalFraction1, naturalFraction2);
            naturalFraction3.Print();

            naturalFraction3 = NaturalFraction.Division(naturalFraction1, naturalFraction2);
            naturalFraction3.Print();
            Pause();
        }

        static void Pause()
        {
            Console.ReadKey();
        }
    }
}

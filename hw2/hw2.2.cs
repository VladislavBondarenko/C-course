using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, result;

            Console.WriteLine("Вводите только числа (дробные через запятую)\n");

            Console.WriteLine("Введите радиус круга: ");
            a = Convert.ToDouble(Console.ReadLine());
            result = Math.PI * a * a;
            Console.WriteLine("Его площадь = " + result);

            Console.WriteLine("\nВведите радиус шара: ");
            a = Convert.ToDouble(Console.ReadLine());
            result = 4 * Math.PI * Math.Pow(a, 3) / 3;
            Console.WriteLine("Его объем = " + result);

            Console.WriteLine("\nВведите стороны прямоугольника: ");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            result = a * b;
            Console.WriteLine("Его площадь = " + result);

            Console.WriteLine("\nВведите стороны прямогульного параллелепипеда: ");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());
            result = a * b * c;
            Console.WriteLine("Его объем = " + result);

            Console.ReadKey();
        }
    }
}

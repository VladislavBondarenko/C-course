using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();
            decimal Num1;
            decimal Num2;
            string options;

            while (true)
            {
                Console.Clear();
                Num1 = Tools.InputNumber("Первое число: ");
                Num2 = Tools.InputNumber("Второе число: ");
                Console.WriteLine("1: +");
                Console.WriteLine("2: -");
                Console.WriteLine("3: /");
                Console.WriteLine("4: *");
                Console.WriteLine("0. Выйти");
                Console.WriteLine();
                Console.WriteLine("Выберите действия: ");
                options = Console.ReadLine();
                foreach (char symbol in options)
                {
                    if (char.IsDigit(symbol) && symbol >= '0' && symbol <= '4')
                    {
                        switch (symbol)
                        {
                            case '1': calc.CountEvent += calc.plus; break;
                            case '2': calc.CountEvent += calc.minus; break;
                            case '3': calc.CountEvent += calc.mul; break;
                            case '4': calc.CountEvent += calc.div; break;
                            case '0': return;
                        }
                    }
                }
                Console.WriteLine();
                calc.Count(Num1, Num2);
                calc.ClearOperations();
                Console.ReadKey();
            }
        }
    }
}

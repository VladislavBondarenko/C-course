using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11
{
    class Program
    {
        static void Main(string[] args)
        {
            Tools tools = new Tools();

            Console.WriteLine("Введите чило или текст: ");
            string buf = Console.ReadLine();
            Console.WriteLine("1. Вывести в консоль");
            Console.WriteLine("2. Вывести в файл");
            byte point = tools.InputNumber("Ваш выбор: ", 1, 2);

            switch (point)
            {
                case 1: tools.Show = text => Console.WriteLine(text); break;
                case 2: tools.Show = text => System.IO.File.WriteAllText(@"../../WriteText.txt", text); break;
            }

            tools.Output(buf);
            Console.ReadKey();
        }
    }
}
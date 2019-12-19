using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    class Tools
    {
        public static decimal InputNumber(string field)
        {
            decimal result;
            while (true)
            {
                Console.Write(field);
                string buf = Console.ReadLine();
                if (decimal.TryParse(buf, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некорректное значение. Введите число");
                }
            }
        }
    }
}

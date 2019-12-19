using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw12
{
    static class Tools
    {
        static public byte InputNumber(string field, int min, int max)
        {
            byte result;
            while (true)
            {
                Console.Write(field);
                string buf = Console.ReadLine();
                if (byte.TryParse(buf, out result) && (result <= max) && (result >= min))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некорректное значение. Попробуйте еще раз");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Tools
    {
        public static int InputNumber(string field, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(field);
                string buf = Console.ReadLine();
                if (Int32.TryParse(buf, out result) && (result <= max) && (result >= min))
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

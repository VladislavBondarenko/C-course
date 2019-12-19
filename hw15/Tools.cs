using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    static class Tools
    {
        static public int InputNumber(string field, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(field);
                string buf = Console.ReadLine();
                if (int.TryParse(buf, out result) && (result <= max) && (result >= min))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Incorrect value. Try again");
                }
            }
        }
        static public decimal InputNumber(string field, decimal min, decimal max)
        {
            decimal result;
            while (true)
            {
                Console.Write(field);
                string buf = Console.ReadLine();
                if (decimal.TryParse(buf, out result) && (result <= max) && (result >= min))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Incorrect value. Try again");
                }
            }
        }
    }
}

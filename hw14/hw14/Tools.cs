using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14
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
    }
}

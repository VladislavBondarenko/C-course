using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11
{
    class Tools
    {
        public MyDelegate Show;

        public void Output(string text)
        {
            if (Show != null)
            {
                Show.Invoke(CheckNumber(text));
            }
        }

        private string CheckNumber(string text)
        {
            double number;
            if (double.TryParse(text, out number))
            {
                text = (number * number).ToString();
            }
            return text;
        }

        public byte InputNumber(string field, byte min, byte max)
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

    delegate void MyDelegate(string text);
}

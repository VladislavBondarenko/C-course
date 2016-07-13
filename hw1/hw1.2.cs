using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello world!";
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine("Char " + text[i] + ": dec " + Convert.ToInt32(text[i]) + ", hex " + Convert.ToInt32(text[i]).ToString("X") + "\n");
            }
            Console.ReadKey();
        }
    }
}

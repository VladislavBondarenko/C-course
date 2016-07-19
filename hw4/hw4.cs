using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple calculator\n");
            Console.WriteLine("Please, enter data in the following sequence:");
            Console.WriteLine("First number + 'Enter', operation symbol + 'Enter',\n" +
                              "next number + 'Enter',  operation symbol + 'Enter',\n" +
                              "next number + 'Enter' etc.\n");
            Console.WriteLine("The fractional part of number separated by a comma, not a point");
            Console.WriteLine("You can use next operations: + - / * % pow\n");

            double num1;
            double num2;
            string[] operations = new string[6] { "+","-","/","*","%","pow"};

            num1 = InputNumber();
            while (true)
            { 
                byte numberOperation = InputOperationSymbol(operations);
                num2 = InputNumber();

                num1 = PerformOperation(num1, num2, operations, numberOperation);

                Console.WriteLine(num1);
            };
        }

        static double PerformOperation(double num1, double num2, string[] operations, byte numberOperation)
        {
            switch (numberOperation)
            {
                case 0: return Sum(num1, num2);
                case 1: return Sub(num1, num2);
                case 2: return Div(num1, num2);
                case 3: return Mul(num1, num2);
                case 4: return Mod(num1, num2);
                case 5: return Pow(num1, num2);
            }
            return 0;
        }

        static double Sum(double num1, double num2)
        {
            return num1 + num2;
        }
        static double Sub(double num1, double num2)
        {
            return num1 - num2;
        }
        static double Div(double num1, double num2)
        {
            return num1 / num2;
        }
        static double Mul(double num1, double num2)
        {
            return num1 * num2;
        }
        static double Mod(double num1, double num2)
        {
            return num1 - Convert.ToInt32(num1 / num2 - 0.5) * num2;
        }
        static double Pow(double num, double power)
        {
            double result = 1;
            if (power < 0)
            {
                for (int i = 0; i > power; i--)
                {
                    result /= num;
                }
            }
            else
            {
                for (int i = 0; i < power; i++)
                    result *= num;
            }
            return result;
        }

        static double InputNumber()
        {
            double result;
            string buf;
            while (true)
            {
                buf = Console.ReadLine();
                if (Double.TryParse(buf, out result))
                {
                    return result;
                } else
                {
                    Console.WriteLine("Incorrect value. Try again");
                }
            }
        }

        static byte InputOperationSymbol(string[] operations)
        {
            byte i;
            string buf;
            while (true)
            {
                buf = Console.ReadLine();
                for (i = 0; i < operations.Length; i++)
                {
                    if (buf.Equals(operations[i]))
                    {
                        return i;
                    }
                }
                Console.WriteLine("You can use next operations: + - / * % pow. Try again");
            }
        }
    }
}

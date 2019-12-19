using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10
{
    class Calc
    {
        private MyDelegate operations;
        public event MyDelegate CountEvent
        {
            add
            {
                operations += value;
            }
            remove
            {
                operations -= value;
            }
        }

        public void Count(decimal num1, decimal num2)
        {
            if (operations != null)
            {
                operations.Invoke(num1, num2);
            }
        }

        public void ClearOperations()
        {
            operations = null;
        }
        
        public decimal plus(decimal num1, decimal num2)
        {
            decimal result = num1 + num2;
            Console.WriteLine("{0} + {1} = {2}", num1, num2, result);
            return result;
        }
        public decimal minus(decimal num1, decimal num2)
        {
            decimal result = num1 - num2;
            Console.WriteLine("{0} - {1} = {2}", num1, num2, result);
            return result;
        }
        public decimal mul(decimal num1, decimal num2)
        {
            decimal result = num1 * num2;
            Console.WriteLine("{0} * {1} = {2}", num1, num2, result);
            return result;
        }
        public decimal div(decimal num1, decimal num2)
        {
            decimal result = num1 / num2;
            Console.WriteLine("{0} / {1} = {2}", num1, num2, result);
            return result;
        }
    }

    delegate decimal MyDelegate(decimal num1, decimal num2);
}

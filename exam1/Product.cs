using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    class Product
    {
        public string Name { set; get; }
        public int Number { set; get; }
        public decimal Price { set; get; }

        public Product(string NameArg, int NumberArg, decimal PriceArg)
        {
            Name = NameArg;
            Number = NumberArg;
            Price = PriceArg;
        }

        public Product()
        {
            Name = "";
            Number = 0;
            Price = 0;
        }
    }
}

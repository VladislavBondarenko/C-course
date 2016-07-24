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
        public int NumberBought { set; get; }
        public decimal Price { private set; get; }

        public Product(string NameArg, decimal PriceArg)
        {
            Name = NameArg;
            Price = PriceArg;
        }
    }
}

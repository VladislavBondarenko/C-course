using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14
{
    class Repository
    {
        public List<Sale> Sales { get; set; }

        public Repository()
        {
            Sales = new List<Sale>()
            {
                new Sale() { Id = 1, Ware = "new phone", Number = 3, Price = 100, Discount = 20, Sum = 280 },
                new Sale() { Id = 2, Ware = "computer", Number = 3, Price = 1100, Discount = 300, Sum = 3000 },
                new Sale() { Id = 3, Ware = "guitar", Number = 1, Price = 300, Discount = 50, Sum = 250 },
                new Sale() { Id = 4, Ware = "new violin", Number = 4, Price = 600, Discount = 0, Sum = 2400 },
                new Sale() { Id = 5, Ware = "new keyboard", Number = 5, Price = 20, Discount = 10, Sum = 90 },
                new Sale() { Id = 6, Ware = "new mouse", Number = 8, Price = 10, Discount = 10, Sum = 70 },
                new Sale() { Id = 7, Ware = "camera", Number = 4, Price = 10, Discount = 10, Sum = 30 },
            };
        }
    }
}

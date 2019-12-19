using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    partial class Store
    {
        public List<Product> productsList = new List<Product>();
        public int ExitPoint { private set; get; }
        public int DirectorPoint { private set; get; }
        private string DirectorPassword { set; get; }

        public Store()
        {
            this.ExitPoint = 0;
            this.DirectorPoint = -1;
            this.DirectorPassword = "1111";

            this.productsList.Add(new Product("Apple", 100, 0.8m));
            this.productsList.Add(new Product("Watermelon", 100, 1m));
            this.productsList.Add(new Product("Banana", 100, 1.2m));
            this.productsList.Add(new Product("Meat", 100, 2.5m));
            this.productsList.Add(new Product("Chips", 100, 0.6m));
        }

        public void ShowStore()
        {
            Console.WriteLine("Welcome to our store!\n");
            Console.Write(new string('-', 10));
            Console.Write("Products");
            Console.WriteLine(new string('-', 10));

            for (int i = 0; i < this.productsList.Count; i++)
                Console.WriteLine("{0}. {1,-13} : $ {2:N2} : {3} pcs",
                    i + 1,
                    this.productsList[i].Name,
                    this.productsList[i].Price,
                    this.productsList[i].Number);

            Console.WriteLine(new string('-', 28));
            Console.WriteLine(this.ExitPoint + ". Exit");
            Console.WriteLine(this.DirectorPoint + ". Enter as a administrator");
            Console.WriteLine(new string('-', 28));
            Console.WriteLine();
        }

        public int ChooseProduct()
        {
            int point;
            string buf;
            while (true)
            {
                Console.Write("Point: ");
                buf = Console.ReadLine();
                if (Int32.TryParse(buf, out point))
                    if ((point >= -1) && (point <= this.productsList.Count))
                        return point;
                Console.WriteLine("Incorrect value. Try again");
            }
        }

        public int InputNumber()
        {
            int result;
            string buf;
            while (true)
            {
                Console.Write("Count: ");
                buf = Console.ReadLine();
                if (Int32.TryParse(buf, out result))
                {
                    return result;
                } else
                {
                    Console.WriteLine("Incorrect value. Try again");
                }  
            }
        }

        public void GetCheck(Buyer buyer)
        {
            if (buyer.productsBuy.Count > 0)
            {
                decimal costProduct = 0;
                decimal result = 0;
                decimal discountPercentage = InputDiscount();

                Console.WriteLine();
                Console.Write(new string('-', 11));
                Console.Write("Check");
                Console.WriteLine(new string('-', 11));
                foreach (Product product in buyer.productsBuy)
                {
                    costProduct = product.Number * product.Price;
                    result += costProduct;
                    Console.WriteLine("{0,-13} $ {1:N2}\n{4,17} {2} = $ {3:N2}",
                        product.Name,
                        product.Price,
                        product.Number,
                        costProduct,
                        "x");
                }
                Console.WriteLine();

                decimal discount = discountPercentage / 100 * result;
                if (discountPercentage != 0)
                {
                    Console.WriteLine("Discount = $ " + discount);
                }
                Console.WriteLine("For payment: $ {0:N2}", result - discount);
                Console.WriteLine(new string('-', 28));
            }
            Console.WriteLine("\nThank you for your visit!");
        }

        private decimal InputDiscount()
        {
            Console.Write("Have you discount? (yes,no): ");
            decimal discount;
            while (true)
            {
                string buf = Console.ReadLine();
                if (buf == "yes")
                {
                    while (true)
                    {
                        Console.Write("Enter a value of discount (in percentage): ");
                        buf = Console.ReadLine();
                        if (decimal.TryParse(buf, out discount))
                        {
                            if ((discount >= 0) && (discount <= 100))
                            {
                                return discount;
                            }
                        }
                        Console.WriteLine("Incorrect value. Try again");
                    }
                }
                else
                {
                    if (buf == "no")
                    {
                        return 0;
                    }
                    else
                    {
                        Console.Write("Repeat, please: ");
                    }
                }
            };
        }
    }
}

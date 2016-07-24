using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    partial class Store
    {
        private System.Collections.Generic.List<Product> productsList = new System.Collections.Generic.List<Product>();
        public int ExitPoint { private set; get; }
        public int DirectorPoint { private set; get; }
        private string DirectorPassword { set; get; }

        public Store()
        {
            ExitPoint = 0;
            DirectorPoint = -1;
            DirectorPassword = "1111";

            productsList.Add(new Product("Apple", 0.8m));
            productsList.Add(new Product("Watermelon", 1m));
            productsList.Add(new Product("Banana", 1.2m));
            productsList.Add(new Product("Meat", 2.5m));
            productsList.Add(new Product("Chips", 0.6m));
        }

        public void ShowStore()
        {
            Console.WriteLine("Welcome to our store!\n");
            Console.Write(new string('-', 10));
            Console.Write("Procucts");
            Console.WriteLine(new string('-', 10));

            for (int i = 0; i < productsList.Count; i++)
                Console.WriteLine("{0}. {1,-13} : $ {2:N2}", i + 1, productsList[i].Name, productsList[i].Price);

            Console.WriteLine(new string('-', 28));
            Console.WriteLine(ExitPoint + ". Exit");
            Console.WriteLine(DirectorPoint + ". Enter as a director");
            Console.WriteLine(new string('-', 28));
            Console.WriteLine();
        }

        public void BuyProduct(int pointArg, int countArg)
        {
            productsList[pointArg - 1].NumberBought += countArg;
        }

        public int InputPoint()
        {
            int point;
            string buf;
            while (true)
            {
                Console.Write("Point: ");
                buf = Console.ReadLine();
                if (Int32.TryParse(buf, out point))
                    if ((point >= -1) && (point <= productsList.Count))
                        return point;
                Console.WriteLine("Incorrect value. Try again");
            }
        }

        public int InputCount(int pointArg)
        {
            int result;
            string buf;
            while (true)
            {
                Console.Write("Count: ");
                buf = Console.ReadLine();
                if (Int32.TryParse(buf, out result))
                    if (productsList[pointArg - 1].NumberBought + result >= 0)
                        return result;
                    else
                    {
                        Console.WriteLine("You have laid out all. you can not lay out more than you have");
                        return -productsList[pointArg - 1].NumberBought;
                    }
                else
                    Console.WriteLine("Incorrect value. Try again");
            }
        }

        public void GetCheck()
        {
            decimal costProduct = 0;
            decimal result = 0;

            int discountPercentage = InputDiscount();

            Console.WriteLine();
            Console.Write(new string('-', 11));
            Console.Write("Check");
            Console.WriteLine(new string('-', 11));
            foreach (Product product in productsList)
            {
                if (product.NumberBought > 0)
                {
                    costProduct = product.NumberBought * product.Price;
                    result += costProduct;
                    Console.WriteLine("{0,-13} $ {1:N2}\n{4,17} {2} = $ {3:N2}",
                        product.Name,
                        product.Price,
                        product.NumberBought,
                        costProduct,
                        "x");
                }
            }
            Console.WriteLine();
            if (result > 0)
            {
                decimal discount = discountPercentage / 100 * result;
                if (discountPercentage != 0)
                    Console.WriteLine("Discount = $ " + discount);
                Console.WriteLine("For payment: $ {0:N2}", result - discount);
                Console.WriteLine(new string('-', 28));
            }
            Console.WriteLine("\nThank you for your visit!");

        }

        private int InputDiscount()
        {
            Console.Write("Have you discount? (yes,no): ");
            int discount;
            do
            {
                string buf = Console.ReadLine();
                if (buf == "yes")
                {
                    while (true)
                    {
                        Console.Write("Enter a value of discount (in integer percentage): ");
                        buf = Console.ReadLine();
                        if (Int32.TryParse(buf, out discount))
                            if ((discount >= 0) && (discount <= 100))
                                return discount;
                        Console.WriteLine("Incorrect value. Try again");
                    }
                }
                else
                if (buf == "no")
                    return 0;
                else
                    Console.Write("Repeat, please: ");
            } while (true);
        }
    }
}

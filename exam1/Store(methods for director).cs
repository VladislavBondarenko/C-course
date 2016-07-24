using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    partial class Store
    {
        private void AddProduct()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            decimal price;
            while (true)
            {
                Console.Write("Price: ");
                string buf = Console.ReadLine();
                if (Decimal.TryParse(buf, out price))
                    if (price >= 0)
                        break;
                    else
                        Console.WriteLine("Incorrect value. Try again");
            }
            productsList.Add(new Product(name, price));
        }

        private void RemoveProduct()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            foreach (Product product in productsList)
                if (product.Name == name)
                {
                    productsList.Remove(product);
                    Console.WriteLine("Done");
                    return;
                }
            Console.WriteLine("There is no this product");
        }

        public void EnterDirector()
        {
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (password == DirectorPassword)
            {
                Console.WriteLine("\nWe're glad to see you, director!\n");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. Remove a product");
                Console.WriteLine("0. Exit");

                while (true)
                {
                    int point;
                    Console.Write("\nPoint: ");
                    string buf = Console.ReadLine();
                    if (Int32.TryParse(buf, out point))
                        switch (point)
                        {
                            case 0: return;
                            case 1: AddProduct(); break;
                            case 2: RemoveProduct(); break;
                            default: Console.WriteLine("Incorrect value. Try again"); continue;
                        }
                    else
                        Console.WriteLine("Incorrect value. Try again");
                }
            }
            else
                Console.WriteLine("Unfortunately, we can not let pass you to the warehouse");
        }
    }
}

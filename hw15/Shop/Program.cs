using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thisThread = System.Threading.Thread.CurrentThread;
            thisThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); 
            //uk-UA -> en-US  =>  decimal 0,00 -> 0.00

            ShopUserInterface shop = new ShopUserInterface();
            
            byte point;
            bool cont = true;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("1. Show all products");
                Console.WriteLine("2. Show all sales");
                Console.WriteLine("3. Add new product");
                Console.WriteLine("4. Add new sale");
                Console.WriteLine("5. Show products by Name and Price");
                Console.WriteLine("6. Get product by Id");
                Console.WriteLine("7. Get sale by Id");
                Console.WriteLine("8. Change a product");
                Console.WriteLine("9. Delete product by Id");
                Console.WriteLine("10. Delete sale by Id");
                Console.WriteLine("11. Delete all products");
                Console.WriteLine("12. Delete all sales");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                point = (byte)Tools.InputNumber("Point: ", 0, 12);
                Console.WriteLine();
                switch (point)
                {
                    case 1:
                        Console.Clear();
                        shop.ShowAllProducts();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        shop.ShowAllSales();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        shop.AddNewProduct();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        shop.AddNewSale();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        shop.ShowProductsByNameAndPrice();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        shop.GetProductById();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        shop.GetSaleById();
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        shop.ChangeProduct();
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.Clear();
                        shop.DeleteProductById();
                        Console.ReadKey();
                        break;
                    case 10:
                        Console.Clear();
                        shop.DeleteSaleById();
                        Console.ReadKey();
                        break;
                    case 11:
                        Console.Clear();
                        shop.DeleteAllProducts();
                        Console.ReadKey();
                        break;
                    case 12:
                        Console.Clear();
                        shop.DeleteAllSales();
                        Console.ReadKey();
                        break;
                    case 0: cont = false; break;
                }
            }
        }
    }
}

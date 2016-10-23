using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ShopUserInterface
    {
        protected IManagementShop ManagementShop { get; set; }

        public ShopUserInterface()
        {
            this.ManagementShop = new ManagementShopSQL();
        }

        public void ShowAllProducts()
        {
            this.ShowProducts(this.ManagementShop.GetAllProducts());
        }

        public void ShowAllSales()
        {
            this.ShowSales(this.ManagementShop.GetAllSales());
        }

        public void AddNewProduct()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            decimal price = Tools.InputNumber("Price: ", 0, decimal.MaxValue);
            if (this.ManagementShop.AddProduct(name, price))
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void AddNewSale()
        {
            List<Product> productList = this.ManagementShop.GetAllProducts();
            this.ShowProducts(productList);
            int lastId = productList.Last().ProductId;
            if (productList.Count > 0)
            {
                int productId = Tools.InputNumber("Choose product id: ", 1, lastId);
                Console.Write("Buyer's name: ");
                string buyer = Console.ReadLine();
                int quantity = Tools.InputNumber("Quantity: ", 0, int.MaxValue);
                if (this.ManagementShop.AddSale(buyer, productId, quantity))
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Error. Product not found");
                }
            }
        }

        public void ShowProductsByNameAndPrice()
        {
            Console.Write("Full or partial name of product: ");
            string name = Console.ReadLine();
            decimal maxPrice = Tools.InputNumber("Maximal price: ", 0, decimal.MaxValue);
            this.ShowProducts(this.ManagementShop.GetProductsByNameAndPrice(name, maxPrice));
        }

        public void GetProductById()
        {
            int lastId = this.ManagementShop.GetAllProducts().Last().ProductId;
            int productId = Tools.InputNumber("Choose product id: ", 1, lastId);
            Product product = this.ManagementShop.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                List<Product> result = new List<Product>();
                result.Add(product);
                this.ShowProducts(result);
            }
        }

        public void GetSaleById()
        {
            int lastId = this.ManagementShop.GetAllSales().Last().SaleId;
            int saleId = Tools.InputNumber("Choose sale id: ", 1, lastId);
            Sale sale = this.ManagementShop.GetSaleById(saleId);
            if (sale == null)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                List<Sale> result = new List<Sale>();
                result.Add(sale);
                this.ShowSales(result);
            }
        }

        public void ChangeProduct()
        {
            int lastId = this.ManagementShop.GetAllProducts().Last().ProductId;
            int productId = Tools.InputNumber("Choose product id: ", 1, lastId);
            Product product = this.ManagementShop.GetProductById(productId);
            if (product != null)
            {
                Console.Write("New name (empty string equals original name): ");
                string name = Console.ReadLine();
                decimal price = Tools.InputNumber("New price (-1 equals original price): ", -1, decimal.MaxValue);
                if (name == "")
                {
                    name = product.Name;
                }
                if (price == -1)
                {
                    price = product.Price;
                }
                if (this.ManagementShop.ChangeProduct(productId, name, price))
                {
                    Console.WriteLine("Done");
                    return;
                }
            }
            Console.WriteLine("Error. Product not found");
        }

        public void DeleteProductById()
        {
            int lastId = this.ManagementShop.GetAllProducts().Last().ProductId;
            int productId = Tools.InputNumber("Choose product id: ", 1, lastId);
            if (this.ManagementShop.DeleteProductById(productId))
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public void DeleteSaleById()
        {
            int lastId = this.ManagementShop.GetAllSales().Last().SaleId;
            int saleId = Tools.InputNumber("Choose sale id: ", 1, lastId);
            if (this.ManagementShop.DeleteSaleById(saleId))
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public void DeleteAllProducts()
        {
            if (this.ManagementShop.DeleteAllProducts())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public void DeleteAllSales()
        {
            if (this.ManagementShop.DeleteAllSales())
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        protected void ShowProducts(List<Product> products)
        {
            if (products.Count != 0)
            {
                Console.WriteLine("{0,-3} {1,-20} {2,-10}", "Id", "Product", "Price");
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.ProductId,2}. {p.Name,-20} {p.Price,-10}");
                }
            }
            else
            {
                Console.WriteLine("Product list empty");
            }
        }

        protected void ShowSales(List<Sale> sales)
        {
            if (sales.Count != 0)
            {
                Console.WriteLine("{0,-3} {1,-20} {2,-20} {3,-4} {4,-10}", "Id", "Buyer", "Product", "Num", "Sum");
                foreach (Sale s in sales)
                {
                    if (s.Product != null)
                    {
                        Console.WriteLine($"{s.SaleId,2}. {s.BuyerName,-20} {s.Product.Name,-20} {s.Quantity,-4} {s.Sum,-10}");
                    }
                    else
                    {
                        Console.WriteLine($"{s.SaleId,2}. {s.BuyerName,-20} {s.ProductId,-20} {s.Quantity,-4} {s.Sum,-10}");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Sales list empty");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ManagementShopEF : IManagementShop
    {
        public List<Product> GetAllProducts()
        {
            using (ShopDB db = new ShopDB())
            {
                return db.Products.ToList();
            }
        }

        public List<Sale> GetAllSales()
        {
            using (ShopDB db = new ShopDB())
            {
                return db.Sales.Include("Product").ToList();
            }
        }

        public bool AddProduct(string name, decimal price)
        {
            using (ShopDB db = new ShopDB())
            {
                db.Products.Add(new Product { Name = name, Price = price });
                return Convert.ToBoolean(db.SaveChanges());
            }
        }

        public bool AddSale(string buyer, int productId, int quantity)
        {
            using (ShopDB db = new ShopDB())
            {
                Product prod = db.Products.Find(productId);
                if (prod == null)
                {
                    return false;
                }
                db.Sales.Add(new Sale { BuyerName = buyer, Quantity = quantity, Product = prod, Sum = prod.Price*quantity });
                return Convert.ToBoolean(db.SaveChanges());
            }
        }

        public List<Product> GetProductsByNameAndPrice(string namePart, decimal maxPrice)
        {
            using (ShopDB db = new ShopDB())
            {
                IQueryable<Product> results = from p in db.Products
                              where p.Name.Contains(namePart)
                              where p.Price <= maxPrice
                              select p;
                return results.ToList();
            }
        }

        public Product GetProductById(int id)
        {
            using (ShopDB db = new ShopDB())
            {
                return db.Products.Find(id);
            }
        }

        public Sale GetSaleById(int id)
        {
            using (ShopDB db = new ShopDB())
            {
                Sale sale = db.Sales.Find(id);
                db.Entry(sale).Reference("Product").Load();
                return sale;
            }
        }

        public bool ChangeProduct(int id, string name, decimal price)
        {
            using (ShopDB db = new ShopDB())
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return false;
                }
                product.Name = name;
                product.Price = price;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteProductById(int id)
        {
            using (ShopDB db = new ShopDB())
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return false;
                }
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteSaleById(int id)
        {
            using (ShopDB db = new ShopDB())
            {
                Sale sale = db.Sales.Find(id);
                if (sale == null)
                {
                    return false;
                }
                db.Sales.Remove(sale);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteAllProducts()
        {
            using (ShopDB db = new ShopDB())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE Products");
                return !Convert.ToBoolean(db.Products.Count());
            }
        }

        public bool DeleteAllSales()
        {
            using (ShopDB db = new ShopDB())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE Sales");
                return !Convert.ToBoolean(db.Sales.Count());
            }
        }
    }
}

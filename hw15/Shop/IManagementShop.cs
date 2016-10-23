using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface IManagementShop
    {
        List<Product> GetAllProducts();
        List<Sale> GetAllSales();
        bool AddProduct(string name, decimal price);
        bool AddSale(string buyer, int productId, int quantity);
        List<Product> GetProductsByNameAndPrice(string name, decimal price);
        Product GetProductById(int Id);
        Sale GetSaleById(int Id);
        bool ChangeProduct(int id, string name, decimal price);
        bool DeleteProductById(int Id);
        bool DeleteSaleById(int Id);
        bool DeleteAllProducts();
        bool DeleteAllSales();
    }
}

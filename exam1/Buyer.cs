using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    class Buyer
    {
        public List<Product> productsBuy = new List<Product>();

        public void BuyProduct(Store storeArg, int pointArg, int numberArg)
        {
            Product productStore = storeArg.productsList[pointArg - 1];

            if (numberArg > productStore.Number)
            {
                Console.WriteLine("You took entire quantity, you can not take more");
                numberArg = productStore.Number;
            }

            productStore.Number -= numberArg;

            foreach (Product product in this.productsBuy)
            {
                if (product.Name == productStore.Name)
                {
                    product.Number += numberArg;
                    return;
                }
            }
            this.productsBuy.Add(new Product(productStore.Name, numberArg, productStore.Price));
        }

        public void LayOutProduct(Store storeArg, int pointArg, int numberArg)
        {
            Product productStore = storeArg.productsList[pointArg - 1];
            Product productBuyer = new Product();

            foreach (Product product in this.productsBuy)
            {
                if (product.Name == productStore.Name)
                {
                    productBuyer = product;
                    break;
                }
            }

            if (numberArg > productBuyer.Number)
            {
                Console.WriteLine("You have laid out all. You can not lay out more than you have");
                numberArg = productBuyer.Number;
                this.productsBuy.Remove(productBuyer);
            } else
            {
                productBuyer.Number -= numberArg;
            }
            productStore.Number += numberArg;
        }
    }
}

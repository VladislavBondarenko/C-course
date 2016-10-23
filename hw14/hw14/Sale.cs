using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14
{
    class Sale : IPageItem
    {
        public int Id { set; get; }
        public string Ware { set; get; }
        public decimal Price { set; get; }
        public int Number { set; get; }
        public int Discount { set; get; }
        public int Sum { set; get; }
        public string ReturnContent()
        {
            return ("Id: " + Id
                + "\nWare: " + Ware
                + "\nPrice: " + Price
                + "\nNumber: " + Number
                + "\nDiscount: " + Discount
                + "\nSum: " + Sum);
        }
    }
}

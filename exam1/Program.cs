using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Buyer buyer = new Buyer();

            store.ShowStore();

            while (true)
            {
                int point = store.ChooseProduct();
                if (point == store.ExitPoint)
                {
                    store.GetCheck(buyer);
                    break;
                }
                if (point == store.DirectorPoint)
                {
                    store.EnterAdmin();
                    Console.WriteLine();
                    store.ShowStore();
                    continue;
                }
                int number = store.InputNumber();
                if (number > 0)
                {
                    buyer.BuyProduct(store, point, number);
                } else
                {
                    buyer.LayOutProduct(store, point, -number);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

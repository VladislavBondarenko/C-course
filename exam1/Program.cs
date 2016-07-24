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
            Store myStore = new Store();

            myStore.ShowStore();

            while (true)
            {
                int point = myStore.InputPoint();
                if (point == myStore.ExitPoint)
                {
                    myStore.GetCheck();
                    break;
                }
                if (point == myStore.DirectorPoint)
                {
                    myStore.EnterDirector();
                    Console.WriteLine();
                    myStore.ShowStore();
                    continue;
                }
                int count = myStore.InputCount(point);
                myStore.BuyProduct(point, count);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14
{
    class QueriesLINQSyntax : IQueriesSales
    {
        public void SomeQuery(IList<Sale> sales)
        {
            var query = from sale in sales
                        where sale.Discount > 0 &&
                        sale.Price <= 1000 &&
                        sale.Number > 2 &&
                        sale.Ware.Contains("new")
                        select new
                        {
                            sale.Id,
                            sale.Sum
                        };
            Console.WriteLine("Sales with Discount > 0, Price <= 1000, Number > 2, new:\n");
            foreach (var item in query)
            {
                Console.WriteLine("Id: {0}, Sum: {1}", item.Id, item.Sum);
            }
        }

        public void Search(IList<Sale> sales)
        {
            Console.Write("Your query: ");
            string query = Console.ReadLine();
            string[] words = query.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = (from sale in sales
                          from word in words
                          where sale.Ware.Contains(word)
                          select new
                          {
                              sale.Id,
                              sale.Ware
                          }).Distinct();
            foreach (var item in result)
            {
                Console.WriteLine("Id: {0}, Ware: {1}", item.Id, item.Ware);
            }
            if (result.Count() == 0)
            {
                Console.WriteLine("No matches");
            }
        }
    }
}

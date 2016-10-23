using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            IQueriesSales ToolsQuery = new QueriesLambdaSyntax();
            Paginator<Sale> paginator = new Paginator<Sale>();
            
            byte point;
            bool cont = true;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("1. Query");
                Console.WriteLine("2. Pagination");
                Console.WriteLine("3. Search by words");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                point = (byte)Tools.InputNumber("Point: ", 0, 3);
                Console.WriteLine();
                switch (point)
                {
                    case 1:
                        Console.Clear();
                        ToolsQuery.SomeQuery(repository.Sales);
                        Console.ReadKey();
                        break;
                    case 2:
                        paginator.Pagination(repository.Sales, 2);
                        break;
                    case 3:
                        Console.Clear();
                        ToolsQuery.Search(repository.Sales);
                        Console.ReadKey();
                        break;
                    case 0: cont = false; break;
                }
            }
        }
    }
}

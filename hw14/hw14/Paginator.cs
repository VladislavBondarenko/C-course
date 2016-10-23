using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw14
{
    class Paginator<T> where T: IPageItem
    {
        PageInfo pageInfo { get; set; }
        
        public void Pagination(List<T> list, int pageSize, int pageStart = 1)
        {
            int pageCur = pageStart;
            while (true)
            {
                this.pageInfo = new PageInfo { PageNumber = pageCur, PageSize = pageSize, TotalItems = list.Count };
                this.ShowPage(list, this.pageInfo);
                pageCur = Tools.InputNumber("Choose page: ", 0, this.pageInfo.TotalPages);
                if (pageCur == 0)
                {
                    return;
                }
            }
        }

        protected void ShowPage(List<T> list, PageInfo pageInfo)
        {
            Console.Clear();
            for (int i = (pageInfo.PageNumber - 1) * pageInfo.PageSize; i < pageInfo.PageNumber * pageInfo.PageSize; i++)
            {
                if (i < list.Count)
                {

                    Console.WriteLine(list[i].ReturnContent());
                    Console.WriteLine(new string('-', 20) + "\n");
                }
            }
            Console.WriteLine("Page: {0}/{1} (0 - exit from pagination)", pageInfo.PageNumber, pageInfo.TotalPages);
        }
    }

    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}

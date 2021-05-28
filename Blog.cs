using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Blog : IBlog
    {
        public readonly BlogContext _context;     
        public Blog(BlogContext context)
        {
            _context = context;
        }

        public async Task<GetBlogPagination> GetBlogPagination(int userId, string search, string viewOrder, long PageNo, long PageSize)
        {
            var data = await Task.FromResult((from b in _context.BlogPost
                                              join c in _context.BlogCommnets on b.BlogId equals c.BlogId
                                              join u in _context.User on b.BlogId equals u.BlogId
                                              where u.UserId == userId
                                              select new GetBlogReport
                                              {
                                                  BlogId = b.BlogId,
                                                  BlogTitle = b.Body,
                                                  Commnets = c.CommentsBody,
                                                  Date = b.Dt,
                                                  UserName = u.UserName
                                              }));

            if(search != null)
            {
                data = data.Where(x => x.BlogTitle.Contains(search));
            }

            var counts = data.Count();
            if (data == null)
                throw new Exception("Employee Professional Info Not Found.");
            else
            {
                if (viewOrder.ToUpper() == "ASC")
                    data = data.OrderBy(o => o.BlogId);
                else if (viewOrder.ToUpper() == "DESC")
                    data = data.OrderByDescending(o => o.BlogId);
            }

            if (PageNo <= 0)
                PageNo = 1;
            var itemdata = PagingList<GetBlogReport>.CreateAsync(data, PageNo, PageSize);
            long index = (int)(1 + ((PageNo - 1) * PageSize));
            foreach (var item in itemdata)
            {
                item.Sl = index++;
            }
            GetBlogPagination itm = new GetBlogPagination();

            itm.data = itemdata;
            itm.currentPage = PageNo;
            itm.totalCount = counts;
            itm.pageSize = PageSize;

            return itm;
        }
    }
}

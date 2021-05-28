using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;

namespace WebApplication1
{
   public interface IBlog
    {
        public Task<GetBlogPagination> GetBlogPagination(int userId, string search,string viewOrder, long PageNo, long PageSize);
    }
}

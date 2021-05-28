using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTO
{
    public class GetBlogPagination
    {
        public List<GetBlogReport> data { get; set; }
        public long currentPage { get; set; }
        public long totalCount { get; set; }
        public long pageSize { get; set; }
    }
}

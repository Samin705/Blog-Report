using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTO
{
    public class GetBlogReport
    {
        public long Sl { get; set; }
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
      
        public string UserName { get; set; }

        public DateTime Date { get; set; }
        public string Commnets { get; set; }
    }
}

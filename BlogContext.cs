using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<BlogCommnets> BlogCommnets { get; set; }
        public DbSet<User> User { get; set; }
    }
}

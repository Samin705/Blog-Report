using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("blog/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly BlogContext _context;
        private readonly IBlog _IRepo;
        public BlogController(BlogContext context, IBlog IRepo)
        {
            _context = context;
            _IRepo = IRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogPagination(int userId, string search, string viewOrder, long PageNo, long PageSize)
        {
            try
            {
                var dt = await _IRepo.GetBlogPagination(userId,search,viewOrder,PageNo,PageSize);
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

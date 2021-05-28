using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BlogCommnets
    {
		[Key]
		public int CommnetsId { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int BlogId { get; set; }

		[Required]
		public string CommentsBody { get; set; }

		
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class BlogDetaills:BaseModel
    {
        public string Content { get; set; }

        public string ImageUrl { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? Content2 { get; set; }
        public  string? Tag { get; set; }
        public string? ImageUrl4 { get; set; }
        public int BlogCategoryId { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }

     
    }
}

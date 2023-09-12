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

        public string Tags { get; set; }

    

        public int BlogCategoryId { get; set; }
        public virtual  BlogCategory BlogCategory { get; set; }
    }
}

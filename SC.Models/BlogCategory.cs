using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class BlogCategory:BaseModel
    {
        public virtual ICollection<BlogDetaills> BlogDetaills { get; set; }

    }
}

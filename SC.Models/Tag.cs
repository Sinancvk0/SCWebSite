using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Tag:BaseModel
    {
        public int BlogDetaillsId { get; set; }
        public virtual BlogDetaills? BlogDetaills { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Skılls:BaseModel
    {

        public string? Value { get; set; }
        public int AboutId { get; set; }
        public virtual About About  { get; set; }
    }
}

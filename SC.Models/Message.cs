using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Message:BaseModel
    {

        public string Mail { get; set; }
        public string? Content { get; set; }
        
    }
}

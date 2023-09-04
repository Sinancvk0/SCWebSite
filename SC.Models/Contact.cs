using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Contact:BaseModel
    {
        public string Title { get; set; }

        public string Desciription { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }


    }
}

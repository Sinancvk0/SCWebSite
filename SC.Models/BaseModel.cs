using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; } = true;
        public bool isDeleted { get; set; } = false;
        public bool isActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateModified { get; set; }


    }
}

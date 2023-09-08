using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; } = false;
        public bool isActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateModified { get; set; }


    }
}

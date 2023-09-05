using SC.DataLayer.Abstract;
using SC.DataLayer.Repository;
using SC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.DataLayer.EntityFramework
{
    public class EfExperienceDal : GenericRepository<Experinece>, IExperineceDal
    {
        public EfExperienceDal(AppDbContext db) : base(db)
        {
        }
    }
}

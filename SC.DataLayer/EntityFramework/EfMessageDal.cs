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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(AppDbContext db) : base(db)
        {
        }
    }
}

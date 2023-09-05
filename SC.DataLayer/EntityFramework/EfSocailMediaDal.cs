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
    public class EfSocailMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public EfSocailMediaDal(AppDbContext db) : base(db)
        {
        }
    }
}

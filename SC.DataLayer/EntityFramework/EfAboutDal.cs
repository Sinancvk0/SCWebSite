using Microsoft.EntityFrameworkCore;
using SC.DataLayer.Abstract;
using SC.DataLayer.Repository;
using SC.Models;

namespace SC.DataLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(AppDbContext db) : base(db)
        {
        }
    }
}

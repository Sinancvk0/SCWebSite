using Microsoft.EntityFrameworkCore;
using SC.DataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.DataLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly AppDbContext _db;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Delete(T t)
        {
            _db.Remove(t);
            _db.SaveChanges();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

      

        public List<T> GetList()
        {
         return _db.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _db.Add(t);
            _db.SaveChanges();
        }

        public void Update(T t)
        {
            _db.Update(t);
            _db.SaveChanges();
        }
    }
}

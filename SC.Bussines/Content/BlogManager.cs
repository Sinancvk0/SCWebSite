using SC.Bussines.Services;
using SC.DataLayer.Abstract;
using SC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Bussines.Content
{
    public class BlogManager : IGenericService<BlogCategory>, IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void TAdd(BlogCategory t)
        {
           _blogDal.Insert(t);  
        }

        public void TDelete(BlogCategory t)
        {
            _blogDal.Delete(t);
        }

        public BlogCategory TGetById(int id)
        {
         return _blogDal.GetById(id);
        }

        public List<BlogCategory> TGetList()
        {
           return _blogDal.GetList();   
        }

        public void TUpdate(BlogCategory t)
        {
            _blogDal.Update(t);
        }
    }
}

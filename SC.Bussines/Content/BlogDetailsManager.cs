using SC.Bussines.Services;
using SC.DataLayer.Abstract;
using SC.Models;

namespace SC.Bussines.Content
{
    public class BlogDetailsManager : IGenericService<BlogDetaills>, IBlogDetailsService
    {

        private readonly IBlogDetailsDal _blogDetailsDal;

        public BlogDetailsManager(IBlogDetailsDal blogDetailsDal)
        {
            _blogDetailsDal = blogDetailsDal;
        }

        public void TAdd(BlogDetaills t)
        {
          _blogDetailsDal.Insert(t);
        }

        public void TDelete(BlogDetaills t)
        {
            _blogDetailsDal.Delete(t);
        }

        public BlogDetaills TGetById(int id)
        {
            return _blogDetailsDal.GetById(id);
        }

        public List<BlogDetaills> TGetList()
        {
          return _blogDetailsDal.GetList();
        }

        public void TUpdate(BlogDetaills t)
        {
            _blogDetailsDal.Update(t);  
        }
    }
}

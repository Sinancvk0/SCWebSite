using SC.Bussines.Services;
using SC.DataLayer.Abstract;
using SC.Models;

namespace SC.Bussines.Content
{
    public class AboutManager : IGenericService<About>,IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About t)
        {
          _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
           _aboutDal.Delete(t);
        }

        public About TGetById(int id)
        {
          return  _aboutDal.GetById(id);  
        }


        public List<About> TGetList()
        {
         return _aboutDal.GetList();
        }

        public void TUpdate(About t)
        {
           _aboutDal.Update(t);
        }
    }
}

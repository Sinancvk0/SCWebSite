using SC.Bussines.Services;
using SC.DataLayer.Abstract;
using SC.Models;

namespace SC.Bussines.Content
{
    public class SkıllsManager : ISkıllsService
    {
        private readonly ISkıllsDal _skıllsDal;

        public SkıllsManager(ISkıllsDal skıllsDal)
        {
            _skıllsDal = skıllsDal;
        }

        public void TAdd(Skılls t)
        {
          _skıllsDal.Insert(t);
        }

        public void TDelete(Skılls t)
        {
            _skıllsDal.Delete(t);
        }

        public Skılls TGetById(int id)
        {
         return _skıllsDal.GetById(id);
        }

     

        public List<Skılls> TGetList()
        {
           return _skıllsDal.GetList();
        }

        public void TUpdate(Skılls t)
        {
           _skıllsDal.Update(t);    
        }
    }
}

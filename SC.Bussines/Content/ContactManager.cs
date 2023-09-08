using SC.Bussines.Services;
using SC.DataLayer.Abstract;
using SC.Models;

namespace SC.Bussines.Content
{
    public class ContactManager : IGenericService<Contact>, IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TAdd(Contact t)
        {
           _contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
           _contactDal.Delete(t);
        }

        public Contact TGetById(int id)
        {
          return _contactDal.GetById(id);
        }

       

        public List<Contact> TGetList()
        {
           return _contactDal.GetList();
        }

        public void TUpdate(Contact t)
        {
           _contactDal.Update(t);
        }
    }
}

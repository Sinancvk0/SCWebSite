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
    public class ServiceManager : IGenericService<Service>,IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TAdd(Service t)
        {
            _serviceDal.Insert(t);
           
        }

        public void TDelete(Service t)
        {
          _serviceDal.Delete(t);
        }

        public Service TGetById(int id)
        {
           return _serviceDal.GetById(id);  
        }

      

        public List<Service> TGetList()
        {
          return _serviceDal.GetList();
        }

        public void TUpdate(Service t)
        {
          _serviceDal.Update(t);
        }
    }
}

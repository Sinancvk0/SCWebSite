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
    public class WorkManager : IGenericService<Work>, IWorkService
    {
        private readonly IWorkDal _workDal;

        public WorkManager(IWorkDal workDal)
        {
            _workDal = workDal;
        }

        public void TAdd(Work t)
        {
            _workDal.Insert(t);
        }

        public void TDelete(Work t)
        {
            _workDal.Delete(t);
        }

        public Work TGetById(int id)
        {
            return _workDal.GetById(id);
        }

        public List<Work> TGetList()
        {
            return _workDal.GetList();
        }

        public void TUpdate(Work t)
        {
            _workDal.Update(t);
        }
    }
}

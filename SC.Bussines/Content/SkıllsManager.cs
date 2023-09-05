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
    public class SkıllsManager : ISkıllsService
    {
        private readonly ISkıllsDal _skıllsDal;

        public SkıllsManager(ISkıllsDal skıllsDal)
        {
            _skıllsDal = skıllsDal;
        }

        public void TAdd(Skılls t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Skılls t)
        {
            throw new NotImplementedException();
        }

        public Skılls TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skılls> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Skılls t)
        {
            throw new NotImplementedException();
        }
    }
}

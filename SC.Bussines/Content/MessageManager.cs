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
    public class MessageManager : IGenericService<Message>, IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public void TUpdate(Message t)
        {
         _messageDal.Update(t);
        }
    }
}

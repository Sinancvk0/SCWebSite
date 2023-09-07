using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;

namespace SCPersonalProject.ViewComponents.SendMessage
{
    public class SendMessage:ViewComponent
    {
        private readonly IMessageService _messageService;

        public SendMessage(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IViewComponentResult Invoke()
        {

            return View();
        }

        //[HttpPost]
        //public IViewComponentResult Invoke(Message message)
        //{
        //    message.DateCreated = Convert.ToDateTime( DateTime.Now.ToShortDateString());
        //    message.isActive = true;    
        //    _messageService.TAdd(message);
        //    return View();
        //}
    }
}

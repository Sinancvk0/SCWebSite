using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
           var values= _messageService.TGetList();

            return View(values);
        }
    }
}

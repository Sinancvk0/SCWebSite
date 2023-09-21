using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;
using System.Drawing.Text;

namespace SCPersonalProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IMessageService _messageService;

        public DefaultController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {

            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {

            return PartialView();
        }

        public PartialViewResult HeroSectionPartial()
        {

            return PartialView();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {

            return Ok();
        }
        [HttpPost]
        public IActionResult SendMessage(Message m)
        {

            m.DateCreated = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m.isActive = true;
            _messageService.TAdd(m);
            return Ok();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;
using System.Drawing.Text;

namespace SCPersonalProject.Controllers
{
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
        public PartialViewResult SendMessage()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SendMessage(Message m)
        {
            bool isMessageSent = true;
            m.DateCreated = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                m.isActive = true;
                _messageService.TAdd(m);
  

            if (isMessageSent)
            {
                ViewBag.SuccessMessage = "Mesajınız başarıyla gönderildi.";
            }
            else
            {
                ViewBag.ErrorMessage = "Mesaj gönderme işlemi başarısız oldu.";
            }


            return PartialView();
        }
    }
}

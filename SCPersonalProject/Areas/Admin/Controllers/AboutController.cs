﻿using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _aboutService.TGetList();

            return Json(values);
        }

        [HttpGet]

        public IActionResult AddAbout()
        {
            return View();

        }
        [HttpPost]

        public IActionResult AddAbout(About about)
        {
            _aboutService.TAdd(about);
            return Ok();

        }

        [HttpPost]

        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);

            _aboutService.TDelete(values);

            return Ok();
        }


    }
}

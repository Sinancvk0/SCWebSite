using Microsoft.AspNetCore.Mvc;

using SC.Bussines.Content;
using SC.Bussines.Services;
using SC.DataLayer.EntityFramework;

namespace SCPersonalProject.ViewComponents.About
{
    public class AboutList : ViewComponent
    { 
       private readonly IAboutService _aboutService;

        public AboutList(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_aboutService.TGetList();    
            
            return View(values);
        }
    }
}


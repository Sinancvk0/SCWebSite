using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.Bussines.Content;
using SC.Bussines.Services;
using SC.DataLayer;
using SC.DataLayer.EntityFramework;

namespace SCPersonalProject.ViewComponents.About
{
    public class AboutList : ViewComponent
    { 
       private readonly IAboutService _aboutService;
        private readonly AppDbContext _appDbContext;

        public AboutList(IAboutService aboutService, AppDbContext appDbContext = null)
        {
            _aboutService = aboutService;
            _appDbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var values=_aboutService.TGetList();    
            var aboutWithSkills=_appDbContext.Abouts.Include(a=>a.Skılls).ToList(); 
            
            return View(aboutWithSkills);
        }
    }
}


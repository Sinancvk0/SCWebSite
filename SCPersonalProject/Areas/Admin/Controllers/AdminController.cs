using Microsoft.AspNetCore.Mvc;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        public PartialViewResult PartialHead()
        {

            return PartialView();   
        }

        public PartialViewResult PartialSideBar()
        {

            return PartialView();
        }
       
    }
}

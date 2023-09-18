using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace SCPersonalProject.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;



        public WorkController(IWorkService workService)
        {
            _workService = workService;
 
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult GetList()
        {
            var values=_workService.TGetList(); 

            return Json(values);    
        
        }
        [HttpGet]

        public IActionResult AddWork()
        {

            return View();
        }
        [HttpPost]

        public IActionResult AddWork(Work work,IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

         
                work.ImageURL = "/images/" + fileName;
            }


            _workService.TAdd(work);

            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteWork(int id)
        {
            var values = _workService.TGetById(id);

            _workService.TUpdate(values);
            return Ok();
        
        }
        [HttpGet]   

        public IActionResult EditWork(int id)
        {
            var values=_workService.TGetById(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult EditWork(Work work)
        {

            _workService.TUpdate(work);

            return RedirectToAction("Index");
        }
    }
}

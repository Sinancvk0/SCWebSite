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

        private readonly IWebHostEnvironment _webHostEnvironment;

        public WorkController(IWorkService workService, IWebHostEnvironment webHostEnvironment)
        {
            _workService = workService;
            _webHostEnvironment = webHostEnvironment;
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

        public IActionResult AddWork(Work work, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                // Resim yükleme işlemi burada gerçekleştirilecek
                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                // Resim yolu veritabanına kaydedilebilir
                work.ImageURL = "/uploads/" + fileName;
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
    }
}

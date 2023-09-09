using Microsoft.AspNetCore.Mvc;
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

        public IActionResult AddAbout(About about,IFormFile image)
        {

            if (image != null && image.Length > 0)
            {
                // Dosya yükleme işlemini burada yapabilirsiniz.
                // Örneğin, dosyayı kaydedebilir veya işleyebilirsiniz.
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // İşleme tamamlandıktan sonra dosya adını veritabanına kaydedebilirsiniz.
                about.ImageURl = "/images/" + fileName;
            }
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

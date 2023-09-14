using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogDetailsController : Controller
    {

        private readonly IBlogDetailsService _blogDetailsService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BlogDetailsController(IBlogDetailsService blogDetailsService, IWebHostEnvironment webHostEnvironment)
        {
            _blogDetailsService = blogDetailsService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _blogDetailsService.TGetList();

            return Json(values);
        }

        [HttpPost]

        public IActionResult DeleteDetails(int id)
        {
            var values = _blogDetailsService.TGetById(id);

            _blogDetailsService.TDelete(values);

            return Ok();

        }

        [HttpGet]
        public IActionResult AddDetails()
        {

            return View();
        }


        [HttpPost]
        public IActionResult AddDetails(BlogDetaills blogDetaills, IFormFile ImageUrl, IFormFile ImageUrl2, IFormFile ImageUrl3)
        {
            if (ImageUrl != null && ImageUrl.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageUrl.CopyTo(stream);
                }

                blogDetaills.ImageUrl = "/images/" + fileName;
            }

            if (ImageUrl2 != null && ImageUrl2.Length > 0)
            {
                var fileName2 = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl2.FileName);
                var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName2);

                using (var stream2 = new FileStream(filePath2, FileMode.Create))
                {
                    ImageUrl2.CopyTo(stream2);
                }

                blogDetaills.ImageUrl2 = "/images/" + fileName2;
            }

            if (ImageUrl3 != null && ImageUrl3.Length > 0)
            {
                var fileName3 = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl3.FileName);
                var filePath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName3);

                using (var stream3 = new FileStream(filePath3, FileMode.Create))
                {
                    ImageUrl3.CopyTo(stream3);
                }

                blogDetaills.ImageUrl3 = "/images/" + fileName3;
            }

            _blogDetailsService.TAdd(blogDetaills);

            return RedirectToAction("Index");
        }




    }
}

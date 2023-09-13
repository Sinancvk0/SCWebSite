using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogDetailsController : Controller
    {

        private readonly IBlogDetailsService _blogDetailsService;


        public BlogDetailsController(IBlogDetailsService blogDetailsService)
        {
            _blogDetailsService = blogDetailsService;

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
        public IActionResult AddDetails(BlogDetaills blogDetaills, List<IFormFile> images)
        {
            //Blog ImagerUrl 
            for (int i = 0; i < images.Count; i++)
            {
                var image = images[i];
                if (image != null && image.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }


                    if (i == 0)
                    {
                        blogDetaills.ImageUrl = "/images/" + fileName;
                    }
                    else if (i == 1)
                    {
                        blogDetaills.ImageUrl2 = "/images/" + fileName;
                    }
                    else if (i == 2)
                    {
                        blogDetaills.ImageUrl3 = "/images/" + fileName;
                    }
         
                }
            }

            _blogDetailsService.TAdd(blogDetaills);
            return RedirectToAction("Index");
        }


    }
}

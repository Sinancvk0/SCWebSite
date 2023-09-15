using Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.Bussines.Services;
using SC.DataLayer;
using SC.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogDetailsController : Controller
    {

        private readonly IBlogDetailsService _blogDetailsService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _appDbContext;
        private readonly FileUpload _fileUpload;


        public BlogDetailsController(IBlogDetailsService blogDetailsService, IWebHostEnvironment webHostEnvironment, FileUpload fileUpload, AppDbContext appDbContext)
        {
            _blogDetailsService = blogDetailsService;
            _webHostEnvironment = webHostEnvironment;

            _fileUpload = fileUpload;
            _appDbContext = appDbContext;
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
        public IActionResult AddDetails(BlogDetaills blogDetaills, IFormFile ImageUrl, IFormFile ImageUrl2, IFormFile ImageUrl3, IFormFile ImageUrl4)
        {

            var uploadedImageUrl = FileUpload.UploadFile(ImageUrl);
            var uploadedImageUrl2 = FileUpload.UploadFile(ImageUrl2);
            var uploadedImageUrl3 = FileUpload.UploadFile(ImageUrl3);
            var uploadedImageUrl4 = FileUpload.UploadFile(ImageUrl4);
            blogDetaills.ImageUrl = uploadedImageUrl;
            blogDetaills.ImageUrl2 = uploadedImageUrl2;
            blogDetaills.ImageUrl3 = uploadedImageUrl3;
            blogDetaills.ImageUrl4 = uploadedImageUrl4;


            _blogDetailsService.TAdd(blogDetaills);

            return RedirectToAction("Index");
        }




    }
}

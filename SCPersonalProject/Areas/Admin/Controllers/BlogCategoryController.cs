using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.DataLayer.Abstract;
using SC.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogService _blogservice;

        public BlogCategoryController(IBlogService blogservice)
        {
            _blogservice = blogservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {

                var BlogCategory = _blogservice.TGetList();
                return Json(BlogCategory);
            }
            catch (Exception ex)
            {
                return BadRequest("Veriler alınamadı: " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory( BlogCategory blogCategory)
        {
            _blogservice.TAdd(blogCategory);

            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {

           var values=_blogservice.TGetById(id);    

            _blogservice.TDelete(values);   

            return Ok();
        }
    }
}

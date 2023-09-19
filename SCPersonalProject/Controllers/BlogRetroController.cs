using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.Bussines.Services;
using SC.DataLayer;
using SC.Models;

namespace SCPersonalProject.Controllers
{
    [AllowAnonymous]
    public class BlogRetroController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _appDbContext;
        private readonly IBlogDetailsService _blogDetailsService;

        public BlogRetroController(IBlogService blogService, AppDbContext appDbContext, IBlogDetailsService blogDetailsService)
        {
            _blogService = blogService;
            _appDbContext = appDbContext;
            _blogDetailsService = blogDetailsService;
        }
        //Inculude ile Categoryden Details ulaştık 
        public IActionResult Index()
        {
            var values = _blogService.TGetList();

            var blogvalue = _appDbContext.GetBlogCategories.Include(x => x.BlogDetaills).ToList();

            return View(blogvalue);
        }

        [HttpGet]
        public IActionResult Details(int id)

        //Blog detay Idsine göre Blog sayfa detayına gittik
        {
            var blogDetail = _blogDetailsService.TGetById(id);

            if (blogDetail == null)
            {
                return NotFound();
            }

            blogDetail = _appDbContext.BlogDetaills
            .Include(bd => bd.BlogCategory)
            .FirstOrDefault(bd => bd.Id == id);

         


            return View(blogDetail);

        }
        [HttpGet]
        public IActionResult CategoryDetails(int id, int page = 1) 
        {
            int pageSize = 5;


           

            var blogsInCategory = _appDbContext.BlogDetaills
                .Where(blog => blog.BlogCategoryId == id)
                .ToList();

            var pagedCategory = blogsInCategory
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)blogsInCategory.Count / pageSize);

            return View(pagedCategory); 
        }



    }
}

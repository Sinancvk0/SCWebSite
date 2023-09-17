using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.Bussines.Services;
using SC.DataLayer;

namespace SCPersonalProject.Controllers
{
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
        public IActionResult CategoryDetails(int id)
        {
       

            var values = _blogService.TGetList();

            var blogsInCategory = _appDbContext.BlogDetaills.Where(blog => blog.BlogCategoryId == id).ToList();

            return View(blogsInCategory);
        }


    }
}

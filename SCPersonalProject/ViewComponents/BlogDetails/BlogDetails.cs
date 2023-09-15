using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.Bussines.Services;
using SC.DataLayer;

namespace SCPersonalProject.ViewComponents.BlogDetails
{
    public class BlogDetails:ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _appDbContext;
        public BlogDetails(IBlogService blogService, AppDbContext appDbContext)
        {
            _blogService = blogService;
            _appDbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.TGetList();

            var blogvalue = _appDbContext.GetBlogCategories.Include(x => x.BlogDetaills).ToList();
            return View(blogvalue);  

        }

    }
}

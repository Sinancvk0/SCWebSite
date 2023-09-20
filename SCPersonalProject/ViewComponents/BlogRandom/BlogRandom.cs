using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;

namespace SCPersonalProject.ViewComponents.BlogRandom
{
    public class BlogRandom : ViewComponent
    {
        IBlogDetailsService _blogDetails;

        public BlogRandom(IBlogDetailsService blogDetails)
        {
            _blogDetails = blogDetails;
        }

        public IViewComponentResult Invoke()
        {
             var  value=_blogDetails.TGetList().OrderBy(p=>p.Id).Take(3).ToList();

            return View(value);
        }
    }
}

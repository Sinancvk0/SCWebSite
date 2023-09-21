using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;

namespace SCPersonalProject.ViewComponents.Slider
{
    public class SliderList :ViewComponent
    {
        private readonly IBlogDetailsService _blogDetails;

        public SliderList(IBlogDetailsService blogDetails)
        {
            _blogDetails = blogDetails;
        }

        public IViewComponentResult Invoke()
        {
            var blogDetails = _blogDetails.TGetList();

            var latestPostsByCategory = blogDetails
                .GroupBy(x => x.BlogCategoryId)
                .Select(group => group.OrderByDescending(x => x.DateCreated).FirstOrDefault())
                .ToList();

            return View(latestPostsByCategory);
        }
    }
}

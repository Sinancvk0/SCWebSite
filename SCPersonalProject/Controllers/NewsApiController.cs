using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace SCPersonalProject.Controllers
{
    [AllowAnonymous]
    public class NewsApiController : Controller
    {
        private readonly string _apiKey = "8f6a5cbce9c24e7b991efbb5c20285db"; 
        private readonly NewsApiClient _newsApiClient;

        public NewsApiController(NewsApiClient newsApiClient)
        {
            _newsApiClient = newsApiClient;
        }

        public IActionResult Index()
        {
            var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "software",
                SortBy = SortBys.Popularity,
                Language = Languages.TR
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                var articles = articlesResponse.Articles;
                return View(articles); 
            }
            else
            {
                return View("Error"); 
            }
        }
    }
}


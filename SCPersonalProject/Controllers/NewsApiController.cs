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

        public IActionResult Index(int page = 1, int pageSize = 100)
        {
            // Calculate the offset based on the page and page size
            int offset = (page - 1) * pageSize;

            var articlesResponse = _newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "technology",
                SortBy = SortBys.Popularity,
                Language = Languages.TR,
                Page = 1,           // Always fetch the first page of results
                PageSize = pageSize // Set the number of articles per page
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                var allArticles = articlesResponse.Articles;
                var articles = allArticles.Skip(offset).Take(pageSize).ToList();

                ViewBag.Page = page;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalPages = (int)Math.Ceiling((double)allArticles.Count / pageSize);

                return View(articles);
            }
            else
            {
                return View("Error");
            }
        }


    }
}


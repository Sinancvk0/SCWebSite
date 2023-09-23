using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using SCPersonalProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SCPersonalProject.Controllers
{
    [AllowAnonymous]
    public class MovieController : Controller
    {

        private readonly string TMDbApiKey = "8c20f37d7dfa18ad6ac7b6c940a6e684";

        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                int pageSize = 10;
                var client = new RestClient("https://api.themoviedb.org/3");
                var request = new RestRequest("/movie/popular");
                request.Method = Method.Get;
                request.AddParameter("api_key", TMDbApiKey);
                request.AddParameter("language", "tr-TR");
                request.AddParameter("page", page);
                request.AddParameter("items_per_page", pageSize);

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var movieViewModel = JsonConvert.DeserializeObject<MovieViewModel>(response.Content);
                    int totalPages = (int)Math.Ceiling((double)movieViewModel.TotalResults / pageSize);

                    ViewBag.TotalPages = totalPages;
                    ViewBag.CurrentPage = page;

                    return View(movieViewModel);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }


        }

        public async Task<IActionResult> Details(int id)
        {
         
                var client = new RestClient("https://api.themoviedb.org/3");
                var request = new RestRequest($"/movie/{id}");
                request.Method = Method.Get;
                request.AddParameter("api_key", TMDbApiKey);
                request.AddParameter("language", "tr-TR");

                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    var movieDetails = JsonConvert.DeserializeObject<MovieDetailsModel>(response.Content);

                    return View(movieDetails);
                }
                else
                {
                    return View("Error");
                }
           
           
        }


    }
}

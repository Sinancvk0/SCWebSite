using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCPersonalProject.Models;

namespace SCPersonalProject.Controllers
{
    public class Imdb100MovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Imdb100MovieModel> apiMovies = new List<Imdb100MovieModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "47bb07bd8amsha87e4eed96d29a9p153ff0jsn000fc9f9555d" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies = JsonConvert.DeserializeObject<List<Imdb100MovieModel>>(body);
                return View(apiMovies);
            }
   
        }
    }
}

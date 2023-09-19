using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SCPersonalProject.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SCPersonalProject.Controllers
{
    [AllowAnonymous]

    public class DateLineController : Controller
    {
        public async Task<IActionResult> Index(string eventDate)
        {
            var client = new HttpClient();
            var apiUrl = $"https://world-history-timeline.p.rapidapi.com/History-By-Year?year={eventDate}"; // eventDate'i API URL'sine ekleyin

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(apiUrl), // Güncellenmiş URL kullanılıyor
                Headers =
        {
            { "X-RapidAPI-Key", "47bb07bd8amsha87e4eed96d29a9p153ff0jsn000fc9f9555d" },
            { "X-RapidAPI-Host", "world-history-timeline.p.rapidapi.com" },
        },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var dateLineModel = JsonConvert.DeserializeObject<DateLineModel>(body);

                return View(dateLineModel.results);
            }
        }

    }
}

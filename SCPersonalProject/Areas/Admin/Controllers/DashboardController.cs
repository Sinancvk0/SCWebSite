using Microsoft.AspNetCore.Mvc;
using SC.DataLayer;
using SC.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        private readonly AppDbContext _db;

        public DashboardController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var now = DateTime.Now;
            var dateTime = DateTime.Now;

            var visitorCount = new VisitorCount
            {
                DataDate = dateTime,
                IpAdress = ipAddress

            };
            _db.VisitorCounts.Add(visitorCount);
            _db.SaveChanges();

            var count = _db.VisitorCounts.Where(x => x.DataDate == dateTime).Count();
            var visitorCounts = _db.VisitorCounts.ToList();

            ViewData["VisitorCounts"] = visitorCounts;

            return View(count);



            return View(count);
        }

        private string GetIPAddress(string defaultValue = "UNKNOWN")
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? defaultValue;
            return ipAddress;
        }


    }
}

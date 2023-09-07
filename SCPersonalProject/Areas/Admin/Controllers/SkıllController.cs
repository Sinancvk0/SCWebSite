using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SC.Bussines.Services;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkıllController : Controller
    {
        private readonly ISkıllsService _sk;

        public SkıllController(ISkıllsService sk)
        {
            _sk = sk;
        }

        public IActionResult Index()
        {
         

            return View();
        }
        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                var skills = _sk.TGetList();
                return Json(skills);
            }
            catch (Exception ex)
            {
                return BadRequest("Veriler alınamadı: " + ex.Message);
            }
        }

    }
}

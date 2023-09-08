using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SC.Bussines.Services;
using SC.Models;

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
        [HttpGet]
        public IActionResult AddSkill()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skılls skılls)
        {
           
            _sk.TAdd(skılls);

            return Ok();
        }

        [HttpPost]

        public IActionResult DeleteSkill(int id)
        {
            var values = _sk.TGetById(id);
            _sk.TDelete(values);


            return Ok();
        }


        [HttpGet]

        public IActionResult UpdateSkill(int id)
        {
           var values=_sk.TGetById(id);
            if (values == null)
            {
                return NotFound();
            }

            return View(values);


        }
        [HttpPost]

        public IActionResult UpdateSkill(Skılls skılls)
        {
            _sk.TUpdate(skılls);

            return Ok();

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;
using SC.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _service.TGetList();

            return Json(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _service.TAdd(service);

            return Ok();

        }
        [HttpPost]
        public IActionResult DeleteService (int id)
        {
            var values=_service.TGetById(id);
            _service.TDelete(values);

            return Ok();

        }



    }
}

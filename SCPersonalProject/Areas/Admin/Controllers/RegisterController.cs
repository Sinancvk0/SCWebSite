using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SC.Models;
using SCPersonalProject.Areas.Admin.Models;

namespace SCPersonalProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterVeiwModel p)
        {

            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.SurName,
                Email = p.Email,
                UserName = p.UserName,

            };
            var result = await _userManager.CreateAsync(appUser, p.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");

            }
            else
            {
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError("", item.Description);

                }

            }

            return View(p);
        }
    }
}

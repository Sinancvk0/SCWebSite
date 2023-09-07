using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;

namespace SCPersonalProject.ViewComponents.Skıll
{
    public class SkıllList:ViewComponent
    {
        private readonly ISkıllsService _sk;

        public SkıllList(ISkıllsService sk)
        {
            _sk = sk;
        }

        public  IViewComponentResult Invoke()
        {
            var values=_sk.TGetList();

            return View(values);

        }
    }
}

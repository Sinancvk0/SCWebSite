using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;

namespace SCPersonalProject.ViewComponents.Portfolio
{
    public class PortfolioList:ViewComponent
    {
        private readonly IWorkService _workService;

        public PortfolioList(IWorkService workService)
        {
            _workService = workService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_workService.TGetList(); 
            return View(values);

        }
    }
}

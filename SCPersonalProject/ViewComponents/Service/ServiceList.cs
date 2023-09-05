using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;

namespace SCPersonalProject.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        private readonly IServiceService _serviceService;

        public ServiceList(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_serviceService.TGetList();

            return View(values);
        }

    }
}

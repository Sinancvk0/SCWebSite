using Microsoft.AspNetCore.Mvc;
using SC.Bussines.Services;

namespace SCPersonalProject.ViewComponents.Contact
{
    public class ContactList:ViewComponent
    {
        private readonly IContactService _contactService;

        public ContactList(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_contactService.TGetList();
            return View(values);

        }

    }
}

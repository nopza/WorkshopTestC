using Microsoft.AspNetCore.Mvc;
using WorkshopTest.Session;
using WorkshopTest.ViewModels;

namespace WorkshopTest.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ISessionContext _sessionContext;
        public MenuViewComponent(ISessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }
        public IViewComponentResult Invoke()
        {
            var model = new MenuViewModel
            {
                Username = _sessionContext.CurrentUser.Name
            };

            return View(model);
        }
    }
}

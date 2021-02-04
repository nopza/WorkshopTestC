using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopTest.Models;
using WorkshopTest.Session;
using WorkshopTest.ViewModels;

namespace WorkshopTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISessionContext _sessionContext;

        public AccountController(ISessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = new UserSessionModel
            {
                UserId = 1,
                Name = model.Username
            };

            _sessionContext.CurrentUser = user;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            _sessionContext.Logout();

            return View(nameof(Login));
        }
    }
}

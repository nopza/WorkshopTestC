using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorkshopTest.Configurations;
using WorkshopTest.Extenstions;
using WorkshopTest.Filters;
using WorkshopTest.Models;
using WorkshopTest.Session;
using WorkshopTest.ViewModels;

namespace WorkshopTest.Controllers
{
    [LoginFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfigurationContext _configurationContext;

        private readonly ISessionContext _sessionContext;

        public readonly List<ProductModel> _product = new List<ProductModel>
        {
            new ProductModel {
            Idp = 1,
            ProductName = "Oishi Green Tea",
            Price = 20,
            ExpDate = new DateTime(2030,1,3)
            },

            new ProductModel {
            Idp = 2,
            ProductName = "Coke",
            Price = 18,
            ExpDate = new DateTime(2040,11,8)
            },

            new ProductModel {
            Idp = 3,
            ProductName = "Dozo Cheese Flavored",
            Price = 10,
            ExpDate = new DateTime(2024,12,12)
            },
        };

        public HomeController(ILogger<HomeController> logger,
            IConfigurationContext configurationContext,
            ISessionContext sessionContext)
        {
            _logger = logger;
            _configurationContext = configurationContext;
            _sessionContext = sessionContext;
        }


        public IActionResult Index()
        {
            //var sessionModel = new UserSessionModel { UserId = 1, Name = "Nopza" };
            //_sessionContext.SetCurrentUser(sessionModel);
            //var currentUser = _sessionContext.GetCurrentUser();
            var days = _configurationContext.GetCachingDays();

            var siteLocale = _configurationContext.GetSiteLocale();

            //ProductViewModel productViewModel = new ProductViewModel();
            //productViewModel.ProductModelList = _product;

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Days = days.ToString(),
                ProductModelList = _product
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel product)
        {
            var productName = product.SearchProductName ?? string.Empty;

            product.ProductModelList = _product.Where(a => a.ProductName.Contains(productName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return View(product);
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

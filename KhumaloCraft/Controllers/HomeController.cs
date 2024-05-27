using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KhumaloCraft.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Work()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Products()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            List<productDisplay> products = productDisplay.SelectProducts();
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            if (userID == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        //public IActionResult Transactions(int userID)
        //{
        //    List<transactionDisplay> transactions = SelectOrders(userID);
        //    return View(transactions);
        //}

        public IActionResult Transactions()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            ViewData["UserID"] = userID;
            List<transactionDisplay> transactions = transactionDisplay.SelectOrders();
            ViewData["Transactions"] = transactions;
            List<productDisplay> products = productDisplay.SelectProducts();
            ViewData["Products"] = products;
            if (userID == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

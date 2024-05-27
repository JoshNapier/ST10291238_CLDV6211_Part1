using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpPost]
        public ActionResult Products()
        {
            var products = productDisplay.SelectProducts();
            return View(products);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}

using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class ProductController : Controller
    {
        public productTable prdtbl = new productTable();

        [HttpPost]
        public ActionResult Work(productTable p)
        {
            prdtbl.insert_Product(p);
            return RedirectToAction("Products", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

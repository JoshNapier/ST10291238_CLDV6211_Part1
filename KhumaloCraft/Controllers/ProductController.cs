using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

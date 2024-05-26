using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class UserController : Controller
    {
        public userTable usrtbl = new userTable();

        [HttpPost]
        public ActionResult Register(userTable m)
        {
            usrtbl.insert_User(m);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}

using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class LoginController : Controller
    {
        //private readonly LoginModel login;

        //public LoginController()
        //{
        //    login = new LoginModel();
        //}

        [HttpPost]
        public ActionResult Login(string email, string name)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, name);
            if (userID != 0)
            {
                HttpContext.Session.SetInt32("userID", userID);

                return RedirectToAction("Products", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return RedirectToAction("Login", "Home");
            }
        }
    }
}

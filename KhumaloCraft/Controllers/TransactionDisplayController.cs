using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class TransactionDisplayController : Controller
    {
        [HttpPost]
        public ActionResult Transactions()
        {
            var transactions = transactionDisplay.SelectOrders();
            return View(transactions);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

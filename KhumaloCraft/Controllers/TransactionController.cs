using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace KhumaloCraft.Controllers
{
    public class TransactionController : Controller
    {
        //public transactionTable trnstbl = new transactionTable();

        //[HttpPost]
        //public ActionResult Product(transactionTable t)
        //{
        //    trnstbl.insert_order(t);
        //    return RedirectToAction("Transactions", "Home");
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID, bool productAvailability)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(productTable.con_string))
                {
                    string sql = "INSERT INTO transactionTable (userID, productID) VALUES (@UserID, @ProductID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0 )
                        {
                            return RedirectToAction("Transactions", "Home");
                        }
                        else
                        {
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}

using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class transactionDisplay
    {
        public static string con_string = "Server=tcp:josh-sql-server.database.windows.net,1433;Initial Catalog=josh-sql-DB;Persist Security Info=False;User ID=joshnapier21;Password=Metroplex65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int OrderID { get; set; }
        public int UserID { get; set;}
        public int ProductID { get; set; }

        public static List<transactionDisplay> SelectOrders()
        {
            List<transactionDisplay> transactions = new List<transactionDisplay>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT transactionTable.OrderID, transactionTable.ProductID FROM transactionTable INNER JOIN productTable ON transactionTable.ProductID = productTable.ProductID";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transactionDisplay transaction = new transactionDisplay();
                    transaction.OrderID = Convert.ToInt32(reader["OrderID"]);
                    transaction.ProductID = Convert.ToInt32(reader["productID"]);
                    transactions.Add(transaction);
                }
                reader.Close();
                con.Close();
            }
            return transactions;

        }
    }
}

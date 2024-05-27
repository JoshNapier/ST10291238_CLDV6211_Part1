using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class transactionTable
    {
        public static string con_string = "Server=tcp:josh-sql-server.database.windows.net,1433;Initial Catalog=josh-sql-DB;Persist Security Info=False;User ID=joshnapier21;Password=Metroplex65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        //string sql1 = "SELECT OrderID, userID FROM transactionTable INNER JOIN userTable ON transactionTable.OrderID = userTable.OrderID;";
        //string sql2 = "SELECT OrderID, productID FROM transactionTable INNER JOIN productTable ON transactionTable.OrderID = productTable.OrderID;";



        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }

        public int insert_order(transactionTable t)
        {
            string sql = "INSERT INTO transactionTable (userID, productID) SELECT userTable.userID, productTable.productID FROM userTable INNER JOIN productTable ON userTable.OrderID = productTable.OrderID";
            SqlConnection con = new SqlConnection(con_string);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userID", t.UserID);
            cmd.Parameters.AddWithValue("@productID", t.ProductID);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }


    }
}

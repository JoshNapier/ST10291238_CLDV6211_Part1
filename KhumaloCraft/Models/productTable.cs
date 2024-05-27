using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class productTable
    {
        public static string con_string = "Server=tcp:josh-sql-server.database.windows.net,1433;Initial Catalog=josh-sql-DB;Persist Security Info=False;User ID=joshnapier21;Password=Metroplex65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }

        public int insert_Product(productTable p)
        {
            string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Availability", p.Availability);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}

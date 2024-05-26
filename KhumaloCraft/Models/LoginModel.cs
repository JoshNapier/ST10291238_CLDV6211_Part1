using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:josh-sql-server.database.windows.net,1433;Initial Catalog=josh-sql-DB;Persist Security Info=False;User ID=joshnapier21;Password=Metroplex65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int SelectUser(string email, string name)
        {
            int userID = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    userID = Convert.ToInt32(result);
                }
                con.Close();
            }
            return userID;
        }
    }
}

using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class userTable
    {
        public static string con_string = "Server=tcp:josh-sql-server.database.windows.net,1433;Initial Catalog=josh-sql-DB;Persist Security Info=False;User ID=joshnapier21;Password=Metroplex65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int insert_User(userTable m)
        {
            string sql = "INSERT INTO userTable (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Surname", m.Surname);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
    }
}

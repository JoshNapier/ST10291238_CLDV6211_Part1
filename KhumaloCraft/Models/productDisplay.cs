using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class productDisplay
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        public productDisplay() { }

        //Parameterized Constructor: This constructor takes five parameters (id, name, price, category, availability) and initializes the corresponding properties of ProductDisplayModel with the provided values.
        public productDisplay(int id, string name, decimal price, string category, bool availability)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
        }

        public static List<productDisplay> SelectProducts()
        {
            List<productDisplay> products = new List<productDisplay>();

            string con_string = "Server=tcp:josh-sql-server.database.windows.net,1433;Initial Catalog=josh-sql-DB;Persist Security Info=False;User ID=joshnapier21;Password=Metroplex65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productID, productName, productPrice, productCategory, productAvailability FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productDisplay product = new productDisplay();
                    product.ProductID = Convert.ToInt32(reader["productID"]);
                    product.ProductName = Convert.ToString(reader["productName"]);
                    product.ProductPrice = Convert.ToDecimal(reader["productPrice"]);
                    product.ProductCategory = Convert.ToString(reader["productCategory"]);
                    product.ProductAvailability = Convert.ToBoolean(reader["productAvailability"]);
                    products.Add(product);
                }
                reader.Close();
                con.Close();
            }
            return products;
        }

    }
}

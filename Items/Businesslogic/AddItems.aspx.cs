using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

using System.Web.Services;
using System.Web.Script.Services;

namespace MicroErp
{
    public partial class AddItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string AddNewItems(string item_code, string item_name, string item_type, int price, int discount, string uom)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // item_code,item_name,item_type,price,current_discount,uom
            try
            {
                string query = "INSERT INTO item VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", item_code);
                    command.Parameters.AddWithValue("@Value2", item_name);
                    command.Parameters.AddWithValue("@Value3", item_type);
                    command.Parameters.AddWithValue("@Value4", price);
                    command.Parameters.AddWithValue("@Value5", discount);
                    command.Parameters.AddWithValue("@Value6", uom);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        connection.Close();
                        return "Success";
                    }
                    else
                    {
                        connection.Close();
                        return "Failure";
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
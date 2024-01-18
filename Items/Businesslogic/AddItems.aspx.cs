using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

namespace MicroErp
{
    public partial class AddItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddNewItems(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // item_code,item_name,item_type,price,current_discount,uom
            string query = "INSERT INTO item VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["ItemCodeTxt"]);
                command.Parameters.AddWithValue("@Value2", Request.Form["ItemNameTxt"]);
                command.Parameters.AddWithValue("@Value3", Request.Form["ItemTypeTxt"]);
                command.Parameters.AddWithValue("@Value4", Request.Form["PriceTxt"]);
                command.Parameters.AddWithValue("@Value5", Request.Form["CurrentDiscountTxt"]);
                command.Parameters.AddWithValue("@Value6", Request.Form["UOMTxt"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddItems.aspx");
                }
                else
                {
                    Response.Write("Failed to insert record.");
                }
            }
            connection.Close();
        }
    }
}
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
    public partial class AddPlants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddNewPlant(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO plants VALUES (@Value1, @Value2,@Value3)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["PlantIdTxt"]);
                command.Parameters.AddWithValue("@Value2", Request.Form["PlantNameTxt"]);
                command.Parameters.AddWithValue("@Value3", Request.Form["AddressTxt"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddPlants.aspx");
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
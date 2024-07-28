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
    public partial class AddStores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select * from plants";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        PlantIdTxt.DataSource = reader;
                        PlantIdTxt.DataTextField = "plant_id";
                        PlantIdTxt.DataValueField = "plant_id";
                        PlantIdTxt.DataBind();
                    }
                    else
                    {
                        PlantIdTxt.DataSource = null;
                        PlantIdTxt.DataBind();
                    }
                    reader.Close();
                }
            }
        }

        protected void AddNewStore(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO stores VALUES (@Value1, @Value2,@Value3)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["StoreIdTxt"]);
                command.Parameters.AddWithValue("@Value2", PlantIdTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value3", Request.Form["StoreNameTxt"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddStores.aspx");
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
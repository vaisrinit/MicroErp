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
    public partial class Plants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM plants";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    PlantsGrid.DataSource = reader;
                    PlantsGrid.DataBind();
                }
                else
                {
                    PlantsGrid.DataSource = null;
                    PlantsGrid.DataBind();
                    // NoDataDiv.InnerHtml = "No Data Found!";
                }
                reader.Close();
            }
            connection.Close();
        }
    }
}
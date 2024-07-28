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
    public partial class Vendors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM vendor";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    VendorsGrid.DataSource = reader;
                    VendorsGrid.DataBind();
                }
                else
                {
                    VendorsGrid.DataSource = null;
                    VendorsGrid.DataBind();
                    // NoDataDiv.InnerHtml = "No Data Found!";
                }
                reader.Close();
            }
            connection.Close();
        }
    }
}
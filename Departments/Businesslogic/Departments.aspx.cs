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
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM departments";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    DepartmentsGrid.DataSource = reader;
                    DepartmentsGrid.DataBind();
                }
                else
                {
                    DepartmentsGrid.DataSource = null;
                    DepartmentsGrid.DataBind();
                    // NoDataDiv.InnerHtml = "No Data Found!";
                }
                reader.Close();
            }
            connection.Close();
        }
    }
}
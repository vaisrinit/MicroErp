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
    public partial class AddRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select * from departments";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        // DepartmentIdTxt.DataSource = reader;
                        // DepartmentIdTxt.DataTextField = "department_id";
                        // DepartmentIdTxt.DataValueField = "department_id";
                        // DepartmentIdTxt.DataBind();
                    }
                    else
                    {
                        // DepartmentIdTxt.DataSource = null;
                        // DepartmentIdTxt.DataBind();
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }

        [WebMethod]
        public static string GetDepartments()
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string result = "";
            string query = "select * from departments for json auto";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = reader[0].ToString();
                }
                reader.Close();
            }
            connection.Close();
            return result;
        }
        [WebMethod]
        public static string  AddNewRole(string role_id,string department_id,string role_name)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO roles VALUES (@Value1, @Value2,@Value3)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", role_id);
                command.Parameters.AddWithValue("@Value2", department_id);
                command.Parameters.AddWithValue("@Value3", role_name);

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
    
    }
}
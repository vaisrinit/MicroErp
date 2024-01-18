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
    public partial class AddEmployees : System.Web.UI.Page
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
                        DepartmentTxt.DataSource = reader;
                        DepartmentTxt.DataTextField = "department_id";
                        DepartmentTxt.DataValueField = "department_id";
                        DepartmentTxt.DataBind();
                    }
                    else
                    {
                        DepartmentTxt.DataSource = null;
                        DepartmentTxt.DataBind();
                    }
                    reader.Close();
                }
                query = "select * from roles";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        RoleTxt.DataSource = reader;
                        RoleTxt.DataTextField = "role_id";
                        RoleTxt.DataValueField = "role_id";
                        RoleTxt.DataBind();
                    }
                    else
                    {
                        RoleTxt.DataSource = null;
                        RoleTxt.DataBind();
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

        protected void AddNewEmployee(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO employees(employee_id,name, phone,address, email, date_of_birth, date_of_joining, role_id) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["EmployeeIdTxt"]);
                command.Parameters.AddWithValue("@Value2", Request.Form["NameTxt"]);
                command.Parameters.AddWithValue("@Value3", Request.Form["PhoneTxt"]);
                command.Parameters.AddWithValue("@Value4", Request.Form["AddressTxt"]);
                command.Parameters.AddWithValue("@Value5", Request.Form["EmailTxt"]);
                command.Parameters.AddWithValue("@Value6", Request.Form["DOBTxt"]);
                command.Parameters.AddWithValue("@Value7", Request.Form["DOJTxt"]);
                command.Parameters.AddWithValue("@Value8", RoleTxt.SelectedValue);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddEmployees.aspx");
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
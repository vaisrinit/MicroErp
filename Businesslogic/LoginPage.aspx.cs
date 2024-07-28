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

    public partial class LoginPage : System.Web.UI.Page
    {
        // protected void Page_Init(object sender, EventArgs e)
        // {
        //     Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //     Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        //     Response.Cache.SetNoStore();
        // }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM employees where employee_id = '" + Request.Form["UserNameTxt"]+"'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string password = reader["password"].ToString();
                    if (password == Request.Form["PasswordTxt"])
                    {
                        Session["emp_id"] = Request.Form["UserNameTxt"];
                        Session["role"] = reader["role_id"].ToString();
                        Response.Redirect("HomePage.aspx");
                    }
                }
                else
                {
                    Response.Write("Data Not Found");
                }
                reader.Close();
            }
            connection.Close();
        }
    }
}
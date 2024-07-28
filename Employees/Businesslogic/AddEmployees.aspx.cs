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
    public partial class AddEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        [WebMethod]
        public static string GetDepartments()
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT distinct department_id from roles for json auto";
            connection.Open();
            string result = "";
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
        public static string GetRoles(string department_id)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT role_id from roles where department_id ='"+ department_id+"' for json auto";
            connection.Open();
            string result = "";
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

        protected void AddNewEmployee(object sender, EventArgs e)
        {
            // string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            // SqlConnection connection = new SqlConnection(connectionString);
            // string query = ConfigurationManager.AppSettings["spAddEmployee"];
            // query += Request.Form["EmployeeIdTxt"] + "," + Request.Form["NameTxt"] + "," + Request.Form["PhoneTxt"] + "," + Request.Form["AddressTxt"] + "," + Request.Form["EmailTxt"] + ",'" + Request.Form["DOBTxt"] + "','" + Request.Form["DOJTxt"] + "'," + RoleTxt.SelectedValue;
            // Response.Write(query);
            // connection.Open();
            // using (SqlCommand command = new SqlCommand(query, connection))
            // {
            //     SqlDataReader reader = command.ExecuteReader();
            //     if (reader.Read())
            //     {
            //         string result = reader["Msg"].ToString();
            //         Response.Write(result);
            //     }
            //     reader.Close();
            // }
            // connection.Close();
        }
    }
}
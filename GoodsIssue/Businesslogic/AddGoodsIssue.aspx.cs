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
    public partial class AddGoodsIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IssuedByTxt.Value = (string)Session["emp_id"];

            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select department_id from departments";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        IssueToDeptTxt.DataSource = reader;
                        IssueToDeptTxt.DataTextField = "department_id";
                        IssueToDeptTxt.DataValueField = "department_id";
                        IssueToDeptTxt.DataBind();
                    }
                    else
                    {
                        IssueToDeptTxt.DataSource = null;
                        IssueToDeptTxt.DataBind();
                    }
                    reader.Close();
                }
                query = "select item_code from item";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        ItemCodeTxt.DataSource = reader;
                        ItemCodeTxt.DataTextField = "item_code";
                        ItemCodeTxt.DataValueField = "item_code";
                        ItemCodeTxt.DataBind();
                    }
                    else
                    {
                        ItemCodeTxt.DataSource = null;
                        ItemCodeTxt.DataBind();
                    }
                    reader.Close();
                }
                query = "select employee_id from employees";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        IssueToTxt.DataSource = reader;
                        IssueToTxt.DataTextField = "employee_id";
                        IssueToTxt.DataValueField = "employee_id";
                        IssueToTxt.DataBind();
                    }
                    else
                    {
                        IssueToTxt.DataSource = null;
                        IssueToTxt.DataBind();
                    }
                    reader.Close();
                }
                connection.Close();
            }
            
        }

        protected void AddNewIssue(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO goods_issue_notes(gis_id,issued_by,issued_on,issued_to,item_code,quantity,comments,edited_by,created_by) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["GISIDTxt"]);
                command.Parameters.AddWithValue("@Value2", Request.Form["IssuedByTxt"]);
                command.Parameters.AddWithValue("@Value3", Request.Form["IssuedOnTxt"]);
                command.Parameters.AddWithValue("@Value4", IssueToTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value5", ItemCodeTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value6", Request.Form["QuantityTxt"]);
                command.Parameters.AddWithValue("@Value7", Request.Form["CommentsTxt"]);
                command.Parameters.AddWithValue("@Value8", Request.Form["IssuedByTxt"]);
                command.Parameters.AddWithValue("@Value9", Request.Form["IssuedByTxt"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddGoodsIssue.aspx");
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
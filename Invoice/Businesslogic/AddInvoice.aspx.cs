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
    public partial class AddInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RaisedByTxt.Value = (string)Session["emp_id"];
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select grn_id from goods_receipt_note";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        GRNIdTxt.DataSource = reader;
                        GRNIdTxt.DataTextField = "grn_id";
                        GRNIdTxt.DataValueField = "grn_id";
                        GRNIdTxt.DataBind();
                    }
                    else
                    {
                        GRNIdTxt.DataSource = null;
                        GRNIdTxt.DataBind();
                    }
                    reader.Close();
                }
            }
        }

        protected void AddNewGI(object sender, EventArgs e)
        {
            // ,,,,created_on,created_by,edited_on,edited_by
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO invoice (invoice_id,invoice_date,raised_by,grn_id,created_by,edited_by) VALUES (@Value1,@Value2, @Value3,@Value4,@Value5,@Value6)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["InvoiceIdTxt"]);
                command.Parameters.AddWithValue("@Value2", Request.Form["InvoiceDateTimeTxt"]);
                command.Parameters.AddWithValue("@Value3", Request.Form["RaisedByTxt"]);
                command.Parameters.AddWithValue("@Value4", GRNIdTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value5", Request.Form["RaisedByTxt"]);
                command.Parameters.AddWithValue("@Value6", Request.Form["RaisedByTxt"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddInvoice.aspx");
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
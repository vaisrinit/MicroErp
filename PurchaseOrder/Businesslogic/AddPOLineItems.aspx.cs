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
    public partial class AddPOLineItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select * from purchase_order";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        PoNumberTxt.DataSource = reader;
                        PoNumberTxt.DataTextField = "po_number";
                        PoNumberTxt.DataValueField = "po_number";
                        PoNumberTxt.DataBind();
                    }
                    else
                    {
                        PoNumberTxt.DataSource = null;
                        PoNumberTxt.DataBind();
                    }
                    reader.Close();
                }
                query = "select * from item";
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
                connection.Close();
            }
        }

        protected void AddNewPOLineItem(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // item_code,item_name,item_type,price,current_discount,uom
            string query = "INSERT INTO po_line_items(po_number,item_code,tax,quantity,created_by,edited_by) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", PoNumberTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value2", ItemCodeTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value3", Request.Form["TaxTxt"]);
                command.Parameters.AddWithValue("@Value4", Request.Form["QuantityTxt"]);
                command.Parameters.AddWithValue("@Value5", (string)Session["emp_id"]);
                command.Parameters.AddWithValue("@Value6", (string)Session["emp_id"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddPOLineItems.aspx");
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
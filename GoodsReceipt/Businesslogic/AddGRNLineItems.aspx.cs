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
    public partial class AddGRNLineItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select item_code from item";
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
                string grn_id = (string)Session["grn_id"];
                GrnIdTxt.Value = grn_id;
                query = "SELECT po_number,item.item_code,price,tax,quantity,uom FROM po_line_items join item on item.item_code = po_line_items.item_code where po_number = (select po_number from goods_receipt_note where grn_id =" + grn_id + ")";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        PoLIGrid.DataSource = reader;
                        PoLIGrid.DataBind();
                    }
                    else
                    {
                        PoLIGrid.DataSource = null;
                        PoLIGrid.DataBind();
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }

        protected void AddNewGRNLineItem(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = ConfigurationManager.AppSettings["spAddGrnLi"];
            query += Request.Form["GrnIdTxt"] + ",'" + Request.Form["ItemCodeTxt"] + "'," + Request.Form["QuantityTxt"];
            string result = "";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = reader["msg"].ToString();
                }
                reader.Close();
            }
            // item_code,item_name,item_type,price,current_discount,uom
            if (result == "Can add")
            {
                query = "INSERT INTO grn_line_items(grn_id,item_code,quantity_supplied,created_by,edited_by) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", Request.Form["GrnIdTxt"]);
                    command.Parameters.AddWithValue("@Value2", Request.Form["ItemCodeTxt"]);
                    command.Parameters.AddWithValue("@Value3", Request.Form["QuantityTxt"]);
                    command.Parameters.AddWithValue("@Value4", (string)Session["emp_id"]);
                    command.Parameters.AddWithValue("@Value5", (string)Session["emp_id"]);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("Record inserted successfully!");
                        Response.Redirect("AddGRNLineItems.aspx");
                    }
                    else
                    {
                        Response.Write("Failed to insert record.");
                    }
                }
            }
            else{
                Response.Write("<script>alert('Cannot add more than the quantity ordered')</script>");
            }

            connection.Close();
        }
    }
}
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
    public partial class AddInvoiceLineItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gi_id = (string)Session["gi_id"];
            GiIdTxt.Value = gi_id;
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT grn_id,item.item_code,quantity_supplied,uom FROM grn_line_items join item on item.item_code = grn_line_items.item_code where grn_id = (select grn_id from goods_inspection_note where gi_id ='" + gi_id + "')";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    GrnLIGrid.DataSource = reader;
                    GrnLIGrid.DataBind();
                }
                else
                {
                    GrnLIGrid.DataSource = null;
                    GrnLIGrid.DataBind();
                }
                reader.Close();
            }
            connection.Close();
        }

        protected void AddNewGILineItem(object sender, EventArgs e)
        {
            string gi_id = (string)Session["gi_id"];
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // gili_id,gi_id,item_code,quantity_accepted,quantity_rejected,comments,created_on,created_by,edited_on,edited_by
            string query = "INSERT INTO gi_line_items(gi_id,item_code,quantity_accepted,comments,created_by,edited_by) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["GiIdTxt"]);
                command.Parameters.AddWithValue("@Value2", Request.Form["ItemCodeTxt"]);
                command.Parameters.AddWithValue("@Value3", Request.Form["QuantityTxt"]);
                command.Parameters.AddWithValue("@Value4", Request.Form["CommentsTxt"]);
                command.Parameters.AddWithValue("@Value5", (string)Session["emp_id"]);
                command.Parameters.AddWithValue("@Value6", (string)Session["emp_id"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    query = "update gi_line_items set quantity_rejected = (select quantity_supplied from grn_line_items where grn_id = (select grn_id from goods_inspection_note where gi_id ='" + gi_id + "') and item_code = '" + Request.Form["ItemCodeTxt"] + "')- quantity_accepted where gi_id ='" + gi_id + "' and item_code = '" + Request.Form["ItemCodeTxt"] + "'";
                    using (SqlCommand command2 = new SqlCommand(query, connection))
                    {
                        rowsAffected = command2.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("Record inserted successfully!");
                            Response.Redirect("AddGILineItems.aspx");
                        }
                    }
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
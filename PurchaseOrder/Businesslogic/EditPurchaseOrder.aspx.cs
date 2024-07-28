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
    public partial class EditPurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string po_number = (string)Session["po_number"];
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM purchase_order where po_number = '" + po_number + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // po_number,po_date,vendor_id,materials_required_before,expected_delivery_place,status,comment,created_on,created_by,edited_on,edited_by
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if ((string)Session["role"] == "EXECPURC")
                        {
                            PoNumberTxt.Value = reader.GetValue(reader.GetOrdinal("po_number")).ToString();
                            PoDateTxt.Value = reader.GetDateTime(reader.GetOrdinal("po_date")).ToString("yyyy-MM-dd");
                            VendorIdTxt.Value = reader.GetValue(reader.GetOrdinal("vendor_id")).ToString();
                            RequiredBeforeTxt.Value = reader.GetDateTime(reader.GetOrdinal("materials_required_before")).ToString("yyyy-MM-dd");
                            DeliveryPlaceTxt.Value = reader.GetValue(reader.GetOrdinal("expected_delivery_place")).ToString();
                        }
                        else if ((string)Session["role"] == "MGRPURC")
                        {
                            MPoNumberTxt.Value = reader.GetValue(reader.GetOrdinal("po_number")).ToString();
                            MPoDateTxt.Value = reader.GetDateTime(reader.GetOrdinal("po_date")).ToString("yyyy-MM-dd");
                            MVendorIdTxt.Value = reader.GetValue(reader.GetOrdinal("vendor_id")).ToString();
                            MRequiredBeforeTxt.Value = reader.GetDateTime(reader.GetOrdinal("materials_required_before")).ToString("yyyy-MM-dd");
                            MDeliveryPlaceTxt.Value = reader.GetValue(reader.GetOrdinal("expected_delivery_place")).ToString();
                        }

                    }
                    else
                    {
                        Response.Write("Data Not Found");
                    }
                    reader.Close();
                }
                query = "SELECT po_number,item.item_code,price,tax,quantity,uom FROM po_line_items join item on item.item_code = po_line_items.item_code where po_number = '" + po_number + "'";

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
                connection.Close();

            }
        }

        protected void EditPO(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "";
            if ((string)Session["role"] == "EXECPURC")
            {
                query = "update purchase_order set po_date = @Value2,vendor_id = @Value3 ,materials_required_before = @Value4,expected_delivery_place = @Value5,edited_on = getdate() where po_number = @Value1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", Request.Form["PoNumberTxt"]);
                    command.Parameters.AddWithValue("@Value2", Request.Form["PoDateTxt"]);
                    command.Parameters.AddWithValue("@Value3", Request.Form["VendorIdTxt"]);
                    command.Parameters.AddWithValue("@Value4", Request.Form["RequiredBeforeTxt"]);
                    command.Parameters.AddWithValue("@Value5", Request.Form["DeliveryPlaceTxt"]);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("Record inserted successfully!");
                        Response.Redirect("PurchaseOrder.aspx");
                    }
                    else
                    {
                        Response.Write("Failed to insert record.");
                    }
                }
            }

            else if ((string)Session["role"] == "MGRPURC")
            {
                query = "update purchase_order set po_date = @Value2,vendor_id = @Value3 ,materials_required_before = @Value4,expected_delivery_place = @Value5,status = @Value6,comment = @Value7,edited_by =@Value8,edited_on = getdate() where po_number = @Value1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", Request.Form["MPoNumberTxt"]);
                    command.Parameters.AddWithValue("@Value2", Request.Form["MPoDateTxt"]);
                    command.Parameters.AddWithValue("@Value3", Request.Form["MVendorIdTxt"]);
                    command.Parameters.AddWithValue("@Value4", Request.Form["MRequiredBeforeTxt"]);
                    command.Parameters.AddWithValue("@Value5", Request.Form["MDeliveryPlaceTxt"]);
                    command.Parameters.AddWithValue("@Value6", Request.Form["MStatusTxt"]);
                    command.Parameters.AddWithValue("@Value7", Request.Form["MCommentsTxt"]);
                    command.Parameters.AddWithValue("@Value8", (string)Session["emp_id"]);


                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("Record inserted successfully!");
                        Response.Redirect("PurchaseOrder.aspx");
                    }
                    else
                    {
                        Response.Write("Failed to insert record.");
                    }
                }
            }



            connection.Close();
        }
    }
}
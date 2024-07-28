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
    public partial class EditGoodsReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string grn_id = (string)Session["grn"];
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM goods_receipt_note join stores on stores.store_id = goods_receipt_note.supplied_store and grn_id = '" + grn_id + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // grn_id,vendor_id,po_number,supplied_on,supplied_store,gatepass_number,status,comment,created_on,created_by,edited_on,edited_by
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if ((string)Session["role"] == "EXECSTOR")
                        {
                            VendorIdTxt.Value = reader.GetValue(reader.GetOrdinal("vendor_id")).ToString();
                            PoNumberTxt.Value = reader.GetValue(reader.GetOrdinal("po_number")).ToString();
                            SuppliedDateTxt.Value = reader.GetDateTime(reader.GetOrdinal("supplied_on")).ToString("yyyy-MM-dd");
                            SuppliedPlantTxt.Value = reader.GetValue(reader.GetOrdinal("plant_id")).ToString();
                            SuppliedStoreTxt.Value = reader.GetValue(reader.GetOrdinal("supplied_store")).ToString();
                            GatepassTxt.Value = reader.GetValue(reader.GetOrdinal("gatepass_number")).ToString();
                        }
                        else if ((string)Session["role"] == "MGRSTOR")
                        {
                            MVendorIdTxt.Value = reader.GetValue(reader.GetOrdinal("vendor_id")).ToString();
                            MPoNumberTxt.Value = reader.GetValue(reader.GetOrdinal("po_number")).ToString();
                            MSuppliedDateTxt.Value = reader.GetDateTime(reader.GetOrdinal("supplied_on")).ToString("yyyy-MM-dd");
                            MSuppliedPlantTxt.Value = reader.GetValue(reader.GetOrdinal("plant_id")).ToString();
                            MSuppliedStoreTxt.Value = reader.GetValue(reader.GetOrdinal("supplied_store")).ToString();
                            MGatepassTxt.Value = reader.GetValue(reader.GetOrdinal("gatepass_number")).ToString();
                        }

                    }
                    else
                    {
                        Response.Write("Data Not Found");
                    }
                    reader.Close();
                }
                query = "SELECT grn_id,item.item_code,quantity_supplied,uom FROM grn_line_items join item on item.item_code = grn_line_items.item_code where grn_id =" + grn_id;

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
        }

        protected void EditGRN(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "";
            if ((string)Session["role"] == "EXECSTOR")
            {

                query = "update goods_receipt_note set vendor_id = @Value2,po_number = @Value3 ,supplied_on = @Value4,supplied_store = @Value5,gatepass_number = @Value6,edited_on = getdate() where grn_id = @Value1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", (string)Session["grn"]);
                    command.Parameters.AddWithValue("@Value2", Request.Form["VendorIdTxt"]);
                    command.Parameters.AddWithValue("@Value3", Request.Form["PoNumberTxt"]);
                    command.Parameters.AddWithValue("@Value4", Request.Form["SuppliedDateTxt"]);
                    command.Parameters.AddWithValue("@Value5", Request.Form["SuppliedStoreTxt"]);
                    command.Parameters.AddWithValue("@Value6", Request.Form["GatepassTxt"]);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("Record inserted successfully!");
                        Response.Redirect("GoodsReceipt.aspx");
                    }
                    else
                    {
                        Response.Write("Failed to insert record.");
                    }
                }
            }

            else if ((string)Session["role"] == "MGRSTOR")
            {

                query = "update goods_receipt_note set vendor_id = @Value2,po_number = @Value3 ,supplied_on = @Value4,supplied_store = @Value5,gatepass_number = @Value6,status = @Value7,comment = @Value8,edited_by =@Value9,edited_on = getdate() where grn_id = @Value1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", (string)Session["grn"]);
                    command.Parameters.AddWithValue("@Value2", Request.Form["MVendorIdTxt"]);
                    command.Parameters.AddWithValue("@Value3", Request.Form["MPoNumberTxt"]);
                    command.Parameters.AddWithValue("@Value4", Request.Form["MSuppliedDateTxt"]);
                    command.Parameters.AddWithValue("@Value5", Request.Form["MSuppliedStoreTxt"]);
                    command.Parameters.AddWithValue("@Value6", Request.Form["MGatepassTxt"]);
                    command.Parameters.AddWithValue("@Value7", Request.Form["MStatusTxt"]);
                    command.Parameters.AddWithValue("@Value8", Request.Form["MCommentsTxt"]);
                    command.Parameters.AddWithValue("@Value9", (string)Session["emp_id"]);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("Record inserted successfully!");
                        Response.Redirect("GoodsReceipt.aspx");
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
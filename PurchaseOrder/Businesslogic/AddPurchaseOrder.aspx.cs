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
    public partial class AddPurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GivenByTxt.Value = (string)Session["emp_id"];
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select * from vendor";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        VendorIdTxt.DataSource = reader;
                        VendorIdTxt.DataTextField = "vendor_id";
                        VendorIdTxt.DataValueField = "vendor_id";
                        VendorIdTxt.DataBind();
                    }
                    else
                    {
                        VendorIdTxt.DataSource = null;
                        VendorIdTxt.DataBind();
                    }
                    reader.Close();
                }
                query = "select * from plants";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        DeliveryPlaceTxt.DataSource = reader;
                        DeliveryPlaceTxt.DataTextField = "plant_id";
                        DeliveryPlaceTxt.DataValueField = "plant_id";
                        DeliveryPlaceTxt.DataBind();
                    }
                    else
                    {
                        DeliveryPlaceTxt.DataSource = null;
                        DeliveryPlaceTxt.DataBind();
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }

        protected void AddNewPO(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // item_code,item_name,item_type,price,current_discount,uom
            string query = "INSERT INTO purchase_order(po_number,po_date,vendor_id,materials_required_before,expected_delivery_place,status,created_by,edited_by) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", Request.Form["PoNumberTxt"]);
                command.Parameters.AddWithValue("@Value2", Request.Form["PoDateTxt"]);
                command.Parameters.AddWithValue("@Value3", VendorIdTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value4", Request.Form["RequiredBeforeTxt"]);
                command.Parameters.AddWithValue("@Value5", DeliveryPlaceTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value6", "Submitted");
                command.Parameters.AddWithValue("@Value7", Request.Form["GivenByTxt"]);
                command.Parameters.AddWithValue("@Value8", Request.Form["GivenByTxt"]);


                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddPurchaseOrder.aspx");
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
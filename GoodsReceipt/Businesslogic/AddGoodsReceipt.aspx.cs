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
    public partial class AddGoodsReceipt : System.Web.UI.Page
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
                query = "select po_number from purchase_order";
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
                query = "select plant_id from plants";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        SuppliedPlantTxt.DataSource = reader;
                        SuppliedPlantTxt.DataTextField = "plant_id";
                        SuppliedPlantTxt.DataValueField = "plant_id";
                        SuppliedPlantTxt.DataBind();
                    }
                    else
                    {
                        SuppliedPlantTxt.DataSource = null;
                        SuppliedPlantTxt.DataBind();
                    }
                    reader.Close();
                }
                query = "select store_id from stores";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        SuppliedStoreTxt.DataSource = reader;
                        SuppliedStoreTxt.DataTextField = "store_id";
                        SuppliedStoreTxt.DataValueField = "store_id";
                        SuppliedStoreTxt.DataBind();
                    }
                    else
                    {
                        SuppliedStoreTxt.DataSource = null;
                        SuppliedStoreTxt.DataBind();
                    }
                    reader.Close();
                }
                connection.Close();
            }
        }

        protected void AddNewGRN(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO goods_receipt_note(vendor_id,po_number,supplied_on,supplied_store,gatepass_number,status,created_by,edited_by) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", VendorIdTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value2", PoNumberTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value3", Request.Form["SuppliedDateTxt"]);
                command.Parameters.AddWithValue("@Value4", SuppliedStoreTxt.SelectedValue);
                command.Parameters.AddWithValue("@Value5", Request.Form["GatepassTxt"]);
                command.Parameters.AddWithValue("@Value6", "Submitted");
                command.Parameters.AddWithValue("@Value7", Request.Form["GivenByTxt"]);
                command.Parameters.AddWithValue("@Value8", Request.Form["GivenByTxt"]);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("Record inserted successfully!");
                    Response.Redirect("AddGoodsReceipt.aspx");
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
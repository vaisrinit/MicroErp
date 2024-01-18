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
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "";
                if ((string)Session["role"] == "MGRPURC")
                    query = "SELECT * FROM purchase_order";
                else if ((string)Session["role"] == "EXECPURC")
                    query = "SELECT * FROM purchase_order where created_by = '" + (string)Session["emp_id"] + "'";

                if (query != "")
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            PoGrid.DataSource = reader;
                            PoGrid.DataBind();
                        }
                        else
                        {
                            PoGrid.DataSource = null;
                            PoGrid.DataBind();
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

        }

        protected void ViewLineItems(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string po_number = btn.CommandArgument;
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT po_number,item.item_code,price,tax,quantity,uom FROM po_line_items join item on item.item_code = po_line_items.item_code where po_number = '" + po_number + "'";

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

        protected void EditPO(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["po_number"] = btn.CommandArgument;
            Response.Redirect("EditPurchaseOrder.aspx");
        }
    }
}
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
    public partial class GoodsReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "";
                if ((string)Session["role"] == "MGRSTOR")
                    query = "SELECT * FROM goods_receipt_note";
                else if ((string)Session["role"] == "EXECSTOR")
                    query = "SELECT * FROM goods_receipt_note where created_by = '" + (string)Session["emp_id"] + "'";

                if (query != "")
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            GrnGrid.DataSource = reader;
                            GrnGrid.DataBind();
                        }
                        else
                        {
                            GrnGrid.DataSource = null;
                            GrnGrid.DataBind();
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
            string grn_id = btn.CommandArgument;
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT grn_id,item.item_code,quantity_supplied,uom FROM grn_line_items join item on item.item_code = grn_line_items.item_code where grn_id =" + grn_id;

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

        protected void EditGRN(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["grn"] = btn.CommandArgument;
            Response.Redirect("EditGoodsReceipt.aspx");
        }
        
        protected void AddLineItems(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["grn_id"] = btn.CommandArgument;
            Response.Redirect("AddGRNLineItems.aspx");
        }
    }
}
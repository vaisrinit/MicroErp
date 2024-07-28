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
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "";
                if ((string)Session["role"] == "OUTVEND")
                    query = "SELECT * FROM invoice where created_by = '" + (string)Session["emp_id"] + "'";

                if (query != "")
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            InvGrid.DataSource = reader;
                            InvGrid.DataBind();
                        }
                        else
                        {
                            InvGrid.DataSource = null;
                            InvGrid.DataBind();
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
            string query = "select gi_line_items.item_code,uom,quantity quantity_ordered,quantity_supplied , quantity_accepted,price,quantity_accepted*price cost_before_tax,tax,(quantity_accepted*price)+(tax/100)*quantity_accepted*price price_after_tax from gi_line_items join item on item.item_code = gi_line_items.item_code join goods_inspection_note on goods_inspection_note.gi_id = gi_line_items.gi_id join grn_line_items on grn_line_items.grn_id = goods_inspection_note.grn_id and gi_line_items.item_code = grn_line_items.item_code join goods_receipt_note on grn_line_items.grn_id = goods_receipt_note.grn_id join purchase_order on purchase_order.po_number = goods_receipt_note.po_number join po_line_items on po_line_items.po_number = purchase_order.po_number and gi_line_items.item_code = po_line_items.item_code where gi_line_items.gi_id =(select gi_id from goods_inspection_note where goods_inspection_note.grn_id = "+grn_id+")";
            
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    InvLIGrid.DataSource = reader;
                    InvLIGrid.DataBind();
                }
                else
                {
                    InvLIGrid.DataSource = null;
                    InvLIGrid.DataBind();
                }
                reader.Close();
            }
            connection.Close();
        }
    }
}
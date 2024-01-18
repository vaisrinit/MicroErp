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
    public partial class GoodsInspection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "";
                if ((string)Session["role"] == "MGRQC")
                    query = "SELECT * FROM goods_inspection_note";
                else if ((string)Session["role"] == "EXECQC")
                    query = "SELECT * FROM goods_inspection_note where created_by = '" + (string)Session["emp_id"] + "'";

                if (query != "")
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            GiGrid.DataSource = reader;
                            GiGrid.DataBind();
                        }
                        else
                        {
                            GiGrid.DataSource = null;
                            GiGrid.DataBind();
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
            string gi_id = btn.CommandArgument;
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select gin.gi_id,gli.item_code,quantity_supplied,quantity_accepted,quantity_rejected,gli.comments from gi_line_items gli join goods_inspection_note gin on gli.gi_id = gin.gi_id and gli.gi_id = '" + gi_id + "' join grn_line_items grnli on grnli.grn_id = gin.grn_id and grnli.item_code = gli.item_code";
            
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    GiLIGrid.DataSource = reader;
                    GiLIGrid.DataBind();
                }
                else
                {
                    GiLIGrid.DataSource = null;
                    GiLIGrid.DataBind();
                }
                reader.Close();
            }
            connection.Close();
        }

        protected void EditGI(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["gi"] = btn.CommandArgument;
            Response.Redirect("EditGoodsInspection.aspx");
        }

        protected void AddLineItems(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["gi_id"] = btn.CommandArgument;
            Response.Redirect("AddGILineItems.aspx");
        }
    }
}
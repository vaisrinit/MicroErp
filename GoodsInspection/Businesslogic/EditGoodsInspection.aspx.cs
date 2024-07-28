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
    public partial class EditGoodsInspection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string gi_id = (string)Session["gi"];
                string connectionString = ConfigurationManager.AppSettings["MicroErp"];
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM goods_inspection_note where gi_id = '" + gi_id + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if ((string)Session["role"] == "EXECQC")
                        {
                            GiIdTxt.Value = reader.GetValue(reader.GetOrdinal("gi_id")).ToString();
                            GRNIdTxt.Value = reader.GetValue(reader.GetOrdinal("grn_id")).ToString();
                            InspectedByTxt.Value = reader.GetValue(reader.GetOrdinal("created_by")).ToString();
                        }
                        else if ((string)Session["role"] == "MGRQC")
                        {
                            MGiIdTxt.Value = reader.GetValue(reader.GetOrdinal("gi_id")).ToString();
                            MGRNIdTxt.Value = reader.GetValue(reader.GetOrdinal("grn_id")).ToString();
                            MInspectedByTxt.Value = reader.GetValue(reader.GetOrdinal("created_by")).ToString();
                        }

                    }
                    else
                    {
                        Response.Write("Data Not Found");
                    }
                    reader.Close();
                }
                query = "select gin.gi_id,gli.item_code,quantity_supplied,quantity_accepted,quantity_rejected,gli.comments from gi_line_items gli join goods_inspection_note gin on gli.gi_id = gin.gi_id and gli.gi_id = '" + gi_id + "' join grn_line_items grnli on grnli.grn_id = gin.grn_id and grnli.item_code = gli.item_code";

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
        }

        protected void EditGI(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "";
            if ((string)Session["role"] == "MGRQC")
            {

                query = "update goods_inspection_note set status = @Value2,comment = @Value3,edited_by =@Value4,edited_on = getdate() where gi_id = @Value1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value1", (string)Session["gi"]);
                    command.Parameters.AddWithValue("@Value2", Request.Form["MStatusTxt"]);
                    command.Parameters.AddWithValue("@Value3", Request.Form["MCommentsTxt"]);
                    command.Parameters.AddWithValue("@Value4", (string)Session["emp_id"]);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("Record inserted successfully!");
                        Response.Redirect("GoodsInspection.aspx");
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
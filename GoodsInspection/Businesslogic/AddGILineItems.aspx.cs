using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

using System.Web.Services;
using System.Web.Script.Services;
namespace MicroErp
{
    public partial class AddGILineItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gi_id = (string)Session["gi_id"];
            GiIdTxt.Value = gi_id;
            string emp_id = (string)Session["emp_id"];
            AddedByTxt.Value = emp_id;
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

        [WebMethod]
        public static string GetItems(string gi_id)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string result = "";
            string query = "select item_code,quantity_supplied from grn_line_items where grn_id = (select grn_id from goods_inspection_note where gi_id = '" + gi_id + "') for json auto";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = reader[0].ToString();
                }
                reader.Close();
            }
            connection.Close();
            return result;
        }
        [WebMethod]
        public static string AddNewGILineItem(string gi_id, string item_code, int quantity_accepted, int quantity_rejected, string comments, string created_by)
        {
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO gi_line_items(gi_id,item_code,quantity_accepted,quantity_rejected,comments,created_by,edited_by) VALUES (@Value1, @Value2,@Value3,@Value4,@Value5,@Value6,@Value7)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value1", gi_id);
                command.Parameters.AddWithValue("@Value2", item_code);
                command.Parameters.AddWithValue("@Value3", quantity_accepted);
                command.Parameters.AddWithValue("@Value4", quantity_rejected);
                command.Parameters.AddWithValue("@Value5", comments);
                command.Parameters.AddWithValue("@Value6", created_by);
                command.Parameters.AddWithValue("@Value7", created_by);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    connection.Close();
                    return "success";
                }
                else
                {
                    connection.Close();
                    return "failure";
                }
            }
        }
    }
}
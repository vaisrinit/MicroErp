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
    public partial class GoodsIssue : System.Web.UI.Page
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
                    query = "SELECT gis_id,issued_by,issued_on,issued_to,goods_issue_notes.item_code,quantity,comments,department_id,uom FROM goods_issue_notes join employees on issued_to = employee_id join roles on employees.role_id = roles.role_id join item on item.item_code = goods_issue_notes.item_code";
                else if ((string)Session["role"] == "EXECSTOR")
                    query = "SELECT gis_id,issued_by,issued_on,issued_to,goods_issue_notes.item_code,quantity,comments,department_id,uom FROM goods_issue_notes join employees on issued_to = employee_id join roles on employees.role_id = roles.role_id join item on item.item_code = goods_issue_notes.item_code where goods_issue_notes.created_by = '" + (string)Session["emp_id"] + "'";

                if (query != "")
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            GISGrid.DataSource = reader;
                            GISGrid.DataBind();
                        }
                        else
                        {
                            GISGrid.DataSource = null;
                            GISGrid.DataBind();
                        }
                        reader.Close();
                    }
                }

                connection.Close();
            }

        }
    }
}
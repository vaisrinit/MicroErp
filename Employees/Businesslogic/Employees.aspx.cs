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
    public partial class Employees : System.Web.UI.Page
    {
        [WebMethod]
        public static string Paginate(int page)
        {
            int count = 5;
            int offset = (page - 1) * count;
            string connectionString = ConfigurationManager.AppSettings["MicroErp"];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "select * from employees order by employee_id offset " + offset + " rows fetch next " + count + " rows only for json auto";
            string result = "";
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
    }

}
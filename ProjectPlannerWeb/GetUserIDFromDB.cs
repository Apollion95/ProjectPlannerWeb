using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectPlannerWeb
{
    public class GetUserIDFromDB
    {
        public string GetUserIDFromDatabase(string Login) //to get Role , 3= Admin, 2=Moderator, 1=User
        {
            string UserIDVisible = "";
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "SELECT UserID FROM Users WHERE Login = @Login";
                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@Login", Login);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            UserIDVisible = result.ToString();
                        }
                    }
                }
            }
            return UserIDVisible;
        }
    }
}


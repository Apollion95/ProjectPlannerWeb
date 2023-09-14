using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services.Description;
using System.Data.SqlTypes;

namespace ProjectPlannerWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
         
        }

        protected void LoginRegister_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtPasswordRegister_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtConfirmPasswordRegister_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {

        }

        protected void Login_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectPlannerWeb; Integrated Security = True"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE login=@login AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@login", Login2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                 int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["login"] = Login2.Text.Trim();
                    Response.Redirect("MainBoard.aspx");
                }
                else { ErrorLogin.Visible = true; }
               // else { Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "alert('Incorrect Username or password');"); }
                sqlCon.Close();
            }
        }
    }
}
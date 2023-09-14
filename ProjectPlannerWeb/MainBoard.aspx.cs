using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ProjectPlannerWeb
{
    public partial class MainBoard : System.Web.UI.Page
    {
      
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
                Response.Redirect("WebForm1.aspx");
            LoggedAs.Text = "Login: " + Session["Login"];
            GVbind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("WebForm1.aspx");
        }
        void clear()
        {
            LoginAdmin.Text =
            PasswordAdmin.Text =
            EmailAdmin.Text =
            DescriptionAdmin.Text = "";
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectPlannerWeb; Integrated Security = True"))
            {

                sqlCon.Open();
                SqlCommand getMaxUserIDCmd = new SqlCommand("SELECT MAX(UserID) FROM Users", sqlCon);
                int maxUserID = (int)getMaxUserIDCmd.ExecuteScalar();
                int newUserID = maxUserID + 1;
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserID, Login, Password, Email, Description, Role) VALUES (@UserID, @Login, @Password, @Email, @Description, @Role)", sqlCon);


                cmd.Parameters.AddWithValue("@UserID", newUserID);
                cmd.Parameters.AddWithValue("@Login", LoginAdmin.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordAdmin.Text);
                cmd.Parameters.AddWithValue("@Email", EmailAdmin.Text);
                cmd.Parameters.AddWithValue("@Description", DescriptionAdmin.Text);
                cmd.Parameters.AddWithValue("@Role", RoleList.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
              
            }
        }

        protected void LoginAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void PasswordAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void EmailAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DescriptionAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RoleAdmin_TextChanged(object sender, EventArgs e)
        {

        }
        protected void GVbind()
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectPlannerWeb; Integrated Security = True"))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select *from Users", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView2.DataSource = dr;
                    GridView2.DataBind();
                }
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GVbind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPlannerWeb
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                //using (SqlConnection sqlCon = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectPlannerWeb; Integrated Security = True"))
                //{
                //using (SqlCommand cmd = new SqlCommand("Select *from Users", sqlCon))
                //{
                //    sqlCon.Open();
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    UserIdDropDown.DataSource = reader;
                //    UserIdDropDown.DataTextField = "UserID"; // Displayed text
                //    UserIdDropDown.DataValueField = "UserID"; // Corresponding value
                //    UserIdDropDown.DataBind();
                //    sqlCon.Close();
                //}
                //not needed but cool feature
                //}
            }
            //Checker - if not logged then go to start page
            if (Session["login"] == null)
                Response.Redirect("WebForm1.aspx");
            //displaying current username
            string currentUsername = Session["Login"] as string;
            GetRoleFromDB roleGetter = new GetRoleFromDB();
            string role = roleGetter.GetRoleFromDatabase(currentUsername);
            LoggedAs.Text = "Login: " + currentUsername;
            MoveToAdmin.Visible = true;
            GVbind();
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
        protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GVbind();
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.RowIndex];
            int userID = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            string login = ((TextBox)row.FindControl("Login")).Text.Trim();
            string password = ((TextBox)row.FindControl("Password")).Text.Trim();
            string email = ((TextBox)row.FindControl("Email")).Text.Trim();
            string description = ((TextBox)row.FindControl("Description")).Text.Trim();
            DropDownList ddlRole = (DropDownList)row.FindControl("RoleDropdown");
            string selectedRole = ddlRole.SelectedValue;


            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE Users SET Login = @Login, Password = @Password, Email = @Email, Description = @Description, Role=@Role WHERE UserID = @UserID";
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Role", selectedRole);
                        int t = cmd.ExecuteNonQuery();
                        if (t > 0) // notification to user
                        {
                            Response.Write("<Script>alert('Data updated')</script");
                        }
                    }
                    sqlCon.Close();
                }
                GridView2.EditIndex = -1;
                GVbind();
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            GVbind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int userID = (int)GridView2.DataKeys[rowIndex].Value;
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.ExecuteNonQuery();
                    }
                    sqlCon.Close();
                    GVbind();
                }
            }
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            GVbind();
        }
        protected void GVbind()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
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
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
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
                    GVbind();
                }
            }
        }

        protected void refresh_Click(object sender, EventArgs e)
        {
            GVbind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string selectedValue = UserIdDropDown.SelectedValue;
            //not needed at the moment
        }
        protected void MoveToProjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("Projects.aspx");
        }
        protected void MoveToMainBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainBoard.aspx");
        }
        protected void MoveToAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
        protected void MoveToWebForm_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("WebForm1.aspx"); //it should be named start page
            //logout
        }
    }
}
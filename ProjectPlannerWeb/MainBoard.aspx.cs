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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectPlannerWeb; Integrated Security = True"))
            {
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
            }
            if (Session["login"] == null)
                Response.Redirect("WebForm1.aspx");

            string currentUsername = Session["Login"] as string;
            LoggedAs.Text = "Login: " + currentUsername;
            if (!IsPostBack)
            {
                GVbind();
            }
            if (GetRoleFromDatabase(currentUsername) == "3")
            {
                AdminPanel.Visible = true;
            }

        }
        private string GetRoleFromDatabase(string Login) //to get Role , 3= Admin, 2=Moderator, 1=User
        {
            string roleVisible = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectPlannerWeb; Integrated Security = True"))
            {
                sqlCon.Open();
                string query = "SELECT Role FROM Users WHERE Login = @Login";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Login", Login);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        roleVisible = result.ToString();
                    }
                }
            }
            return roleVisible;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("WebForm1.aspx");
            //logout
        }
        void clear() //clear textboxes
        {
            LoginAdmin.Text =
            PasswordAdmin.Text =
            EmailAdmin.Text =
            DescriptionAdmin.Text = "";
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
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GVbind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string selectedValue = UserIdDropDown.SelectedValue;
            //not needed at the moment
        }
        protected void Submit_Click(object sender, EventArgs e) //adding new user as admin
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
                GVbind();
            }
        }
        protected void refresh_Click(object sender, EventArgs e)
        {
            GVbind();
        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            GVbind();
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //problem with editing to be fixed later
            int userID = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value.ToString());
            string login = ((TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("Login")).Text;
            string password = ((TextBox)GridView2.Rows[e.RowIndex].Cells[2].FindControl("Password")).Text;
            string email = ((TextBox)GridView2.Rows[e.RowIndex].Cells[3].FindControl("Email")).Text;
            string description = ((TextBox)GridView2.Rows[e.RowIndex].Cells[4].FindControl("Description")).Text;

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjectPlannerWeb;Integrated Security=True"))
            {
                string updateQuery = "UPDATE Users SET Login = @Login, Password = @Password, Email = @Email, Description = @Description WHERE UserID = @UserID";
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand(updateQuery, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.ExecuteNonQuery();
                }
                sqlCon.Close();
                GVbind();
            }
        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int userID = (int)GridView2.DataKeys[rowIndex].Value;

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProjectPlannerWeb;Integrated Security=True"))
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
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            GVbind();
        }
    }
}
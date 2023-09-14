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
                using (SqlCommand cmd = new SqlCommand("Select *from Users", sqlCon))
                {
                    sqlCon.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    UserIdDropDown.DataSource = reader;
                    UserIdDropDown.DataTextField = "UserID"; // Displayed text
                    UserIdDropDown.DataValueField = "UserID"; // Corresponding value
                    UserIdDropDown.DataBind();
                    sqlCon.Close();
                }
            }
            if (Session["login"] == null)
                Response.Redirect("WebForm1.aspx");
            LoggedAs.Text = "Login: " + Session["Login"];

            if (!IsPostBack)
            {
                GVbind();
            }
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("WebForm1.aspx");
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
            string selectedValue = UserIdDropDown.SelectedValue;
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
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value.ToString());
            string login = ((TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBoxID")).Text;
            string password = ((TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBoxID")).Text;
            string email = ((TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBoxID")).Text;
            string description = ((TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBoxID")).Text;
            string role = ((TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("TextBoxID")).Text;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = ProjectPlannerWeb; Integrated Security = True"))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users (UserID, Login, Password, Email, Description, Role) VALUES (@UserID, @Login, @Password, @Email, @Description, @Role)", sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                GVbind();
            }
        }
    }
}

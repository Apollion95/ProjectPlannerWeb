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
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GVbind();
            }
            if (Session["login"] == null)
                Response.Redirect("WebForm1.aspx");
            //displaying current username
            string currentUsername = Session["Login"] as string;
            GetRoleFromDB roleGetter = new GetRoleFromDB();
            string role = roleGetter.GetRoleFromDatabase(currentUsername);
            LoggedAs.Text = "Login: " + currentUsername;
            if (role == "3")
            {
                MoveToAdmin.Visible = true;
            }
            GVbind();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    SqlCommand cmd = new SqlCommand("Select *from Project", sqlCon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        GridView1.DataSource = dr;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //problem with updating
            //should add data validation
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int projectID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string projectStart = ((TextBox)row.FindControl("Login")).Text.Trim();
            string projectEnd = ((TextBox)row.FindControl("Password")).Text.Trim();
            string description = ((TextBox)row.FindControl("Description")).Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE Users SET ProjectID = @ProjectID, ProjectStart = @ProjectStart, ProjectEnd = @ProjectEnd, Description = @Description WHERE ProjectID = @ProjectID";
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@ProjectID", projectID); // to do 
                        cmd.Parameters.AddWithValue("@UserID", userID); //userid 
                        cmd.Parameters.AddWithValue("@ProjectStartDate", projectStart);
                        cmd.Parameters.AddWithValue("@ProjectEndDate", projectEnd);
                        cmd.Parameters.AddWithValue("@Description", description);
                        int t = cmd.ExecuteNonQuery();
                        if (t > 0) // notification to user
                        {
                            Response.Write("<Script>alert('Data updated')</script");
                        }
                    }
                    sqlCon.Close();
                }
                GridView1.EditIndex = -1;
                GVbind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {   
            // problem with deleteing, something wrong with index
            int rowIndex = e.RowIndex;
            int ProjectID = (int)GridView1.DataKeys[rowIndex].Value;
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Project WHERE ProjectID = @ProjectID", sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                        cmd.ExecuteNonQuery();
                    }
                    sqlCon.Close();
                    GVbind();
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GVbind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GVbind();
        }

        protected void SubmitProjectButton1_Click(object sender, EventArgs e)
        {
            //add timeline validation 
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string currentUsername = Session["Login"] as string;
                    GetUserIDFromDB userIDGetter = new GetUserIDFromDB();
                    string userIDGet = userIDGetter.GetUserIDFromDatabase(currentUsername);
                    sqlCon.Open();
                    SqlCommand getMaxProjectIDCmd = new SqlCommand("SELECT MAX(ProjectID) FROM Project", sqlCon);
                    int maxProjectID = (int)getMaxProjectIDCmd.ExecuteScalar();
                    int newProjectID = maxProjectID + 1;
                    SqlCommand cmd = new SqlCommand("INSERT INTO Project (ProjectID, UserID, ProjectStart, ProjectEnd, Description) VALUES (@ProjectID, @UserID, @ProjectStart, @ProjectEnd, @Description)", sqlCon);
                    cmd.Parameters.AddWithValue("@ProjectID", newProjectID); // to do 
                    cmd.Parameters.AddWithValue("@UserID", userIDGet); //userid 
                    cmd.Parameters.AddWithValue("@ProjectStart", ProposeProjectStartDate.Text);
                    cmd.Parameters.AddWithValue("@ProjectEnd", ProposeProjectEndDate.Text);
                    cmd.Parameters.AddWithValue("@Description", ProposeDescription.Text);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    GVbind();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
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
            string currentUsername = Session["Login"] as string;
            GetRoleFromDB roleGetter = new GetRoleFromDB();
            string role = roleGetter.GetRoleFromDatabase(currentUsername);
            LoggedAs.Text = "Login: " + currentUsername;
            if (role == "3")
            {
                MoveToAdmin.Visible = true;
            }
            GVbind();
            //start date
            Calendar1.Caption = "Calender";
            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Monday;
            Calendar1.NextPrevFormat = NextPrevFormat.ShortMonth;
            Calendar1.TitleFormat = TitleFormat.Month;
            Calendar1.ShowGridLines = true;
            Calendar1.DayStyle.Height = new Unit(50);
            Calendar1.DayStyle.Width = new Unit(150);
            Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            Calendar1.DayStyle.VerticalAlign = VerticalAlign.Middle;
            Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
            //end date
            Calendar2.Caption = "Calender";
            Calendar2.FirstDayOfWeek = FirstDayOfWeek.Monday;
            Calendar2.NextPrevFormat = NextPrevFormat.ShortMonth;
            Calendar2.TitleFormat = TitleFormat.Month;
            Calendar2.ShowGridLines = true;
            Calendar2.DayStyle.Height = new Unit(50);
            Calendar2.DayStyle.Width = new Unit(150);
            Calendar2.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            Calendar2.DayStyle.VerticalAlign = VerticalAlign.Middle;
            Calendar2.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
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
            Session.Abandon(); //logout
            Response.Redirect("WebForm1.aspx"); //it should be named start page
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

            //GridViewRow row = GridView1.Rows[e.RowIndex];
            //int projectID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
            //int userID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
            //int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            GridViewRow row = GridView1.Rows[e.RowIndex];
            string projectIDCellText = row.Cells[0].Text;
            string userIDCellText = row.Cells[1].Text;
            int projectID, userID;
            int.TryParse(projectIDCellText, out projectID);
            int.TryParse(userIDCellText, out userID);


            string projectStart = ((TextBox)row.FindControl("ProjectStartDate")).Text.Trim();
            string projectEnd = ((TextBox)row.FindControl("ProjectEndDate")).Text.Trim();
            string description = ((TextBox)row.FindControl("Description")).Text.Trim();
            DateTime projectStartDateParase;
            DateTime projectEndDateParase;
            DateTime.TryParse(projectStart, out projectStartDateParase);
            DateTime.TryParse(projectEnd, out projectEndDateParase);

            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE Users SET ProjectID = @ProjectID, UserID = @UserID, ProjectStart = @ProjectStart, ProjectEnd = @ProjectEnd, Description = @Description WHERE ProjectID = @ProjectID";
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@ProjectID", projectID); // to do 
                        cmd.Parameters.AddWithValue("@UserID", userID); //userid 
                        cmd.Parameters.AddWithValue("@ProjectStartDate", projectStartDateParase);
                        cmd.Parameters.AddWithValue("@ProjectEndDate", projectEndDateParase);
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
            int projectIDnum = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
            if (!string.IsNullOrEmpty(connectionString))
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Project WHERE ProjectID = @ProjectID", sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@ProjectID", projectIDnum);
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
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            StartLabel.Text = "Project Start Date changed to :" + Calendar1.SelectedDate.ToShortDateString();
        }
        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            StartLabel.Text = "Project Start Month changed to :" + e.NewDate.ToShortDateString();
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            EndLabel.Text = "Project End Date changed to :" + Calendar2.SelectedDate.ToShortDateString();
        }
        protected void Calendar2_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            EndLabel.Text = "Project End Month changed to :" + e.NewDate.ToShortDateString();
        }
    }
}
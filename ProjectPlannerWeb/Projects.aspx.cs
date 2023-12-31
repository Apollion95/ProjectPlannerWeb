﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
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
            Calendar1.Caption = "Project Start Date";
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
            Calendar2.Caption = "Project End Date";
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

            string currentUsername = Session["Login"] as string;
            GetRoleFromDB roleGetter = new GetRoleFromDB();
            string role = roleGetter.GetRoleFromDatabase(currentUsername);
            LoggedAs.Text = "Login: " + currentUsername;
            if (role == "2" || role == "3")
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                string projectIDCellText = row.Cells[0].Text;
                int projectID;
                int.TryParse(projectIDCellText, out projectID);
                string description = ((TextBox)row.FindControl("Description")).Text.Trim();
                string projectStartText = row.Cells[2].Text;
                string projectEndText = row.Cells[3].Text;
                DateTime projectStartDate = DateTime.Parse(projectStartText);
                DateTime projectEndDate = DateTime.Parse(projectEndText);
                DateTime dbProjectStartDate;
                DateTime dbProjectEndDate;
                if (Calendar1.SelectedDate != projectStartDate)
                    dbProjectStartDate = Calendar1.SelectedDate;
                else dbProjectStartDate = projectStartDate;
                if (Calendar2.SelectedDate != projectEndDate)
                    dbProjectEndDate = Calendar2.SelectedDate;
                else dbProjectEndDate = projectEndDate;
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectPlannerWebConnectionString"].ConnectionString;
                if (!string.IsNullOrEmpty(connectionString))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        string updateQuery = "UPDATE Project SET ProjectID = @ProjectID, ProjectStart = @ProjectStart, ProjectEnd = @ProjectEnd, Description = @Description WHERE ProjectID = @ProjectID";
                        sqlCon.Open();
                        using (SqlCommand cmd = new SqlCommand(updateQuery, sqlCon))
                        {
                            cmd.Parameters.AddWithValue("@ProjectID", projectID);
                            cmd.Parameters.AddWithValue("@ProjectStart", dbProjectStartDate);
                            cmd.Parameters.AddWithValue("@ProjectEnd", dbProjectEndDate);
                            cmd.Parameters.AddWithValue("@Description", description);
                            int t = cmd.ExecuteNonQuery();
                            if (t > 0)
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
            else
                Response.Write("<Script>alert('Access Denied')</script");
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string currentUsername = Session["Login"] as string;
            GetRoleFromDB roleGetter = new GetRoleFromDB();
            string role = roleGetter.GetRoleFromDatabase(currentUsername);
            LoggedAs.Text = "Login: " + currentUsername;
            if (role == "2" || role == "3")
            {
                int projectIDnum = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text); //problem if we remove all projects
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
            else
                Response.Write("<Script>alert('Access Denied')</script");
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            string projectStartText = row.Cells[2].Text;
            string projectEndText = row.Cells[3].Text;
            DateTime projectStartDate = DateTime.Parse(projectStartText);
            DateTime projectEndDate = DateTime.Parse(projectEndText);
            Calendar1.SelectedDate = projectStartDate;
            Calendar2.SelectedDate = projectEndDate;
            StartLabel.Text = projectStartDate.ToString();
            EndLabel.Text = projectEndDate.ToString();
            GVbind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GVbind();
        }
        protected void SubmitProjectButton1_Click(object sender, EventArgs e)
        {
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
                    int newProjectID = 0;
                    try
                    {
                        int maxProjectID = (int)getMaxProjectIDCmd.ExecuteScalar();
                        newProjectID = maxProjectID + 1;
                    }
                    catch (Exception ex)
                    {
                        newProjectID = 1;
                    }
                    GetRoleFromDB roleGetter = new GetRoleFromDB();
                    string role = roleGetter.GetRoleFromDatabase(currentUsername);
                    LoggedAs.Text = "Login: " + currentUsername;
                    if (role == "2" || role == "3")
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Project (ProjectID, UserID, ProjectStart, ProjectEnd, Description) VALUES (@ProjectID, @UserID, @ProjectStart, @ProjectEnd, @Description)", sqlCon);
                        cmd.Parameters.AddWithValue("@ProjectID", newProjectID); // to do 
                        cmd.Parameters.AddWithValue("@UserID", userIDGet); //userid 
                        cmd.Parameters.AddWithValue("@ProjectStart", Calendar1.SelectedDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@ProjectEnd", Calendar2.SelectedDate.ToShortDateString());
                        cmd.Parameters.AddWithValue("@Description", ProposeDescription.Text);
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                    else
                        Response.Write("<Script>alert('Access Denied')</script");
                    GVbind();
                }
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;
            string formattedDate = selectedDate.ToString("dd MMM yyyy");
            StartLabel.Text = "Project Start Date changed to :" + formattedDate;
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar2.SelectedDate;
            string formattedSelectedDate = selectedDate.ToString("dd MMM yyyy");
            EndLabel.Text = "Project End Date changed to: " + formattedSelectedDate;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //add better colors for calendar 
        }
    }
}


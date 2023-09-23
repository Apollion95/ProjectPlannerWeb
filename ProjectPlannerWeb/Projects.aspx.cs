﻿using System;
using System.Collections.Generic;
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
            if (Session["login"] == null)
                Response.Redirect("WebForm1.aspx");
            //displaying current username
            string currentUsername = Session["Login"] as string;
            GetRoleFromDB roleGetter = new GetRoleFromDB();
            string role = roleGetter.GetRoleFromDatabase(currentUsername);
            LoggedAs.Text = "Login: " + currentUsername;
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
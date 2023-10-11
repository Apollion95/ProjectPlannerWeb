<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainBoard.aspx.cs" Inherits="ProjectPlannerWeb.MainBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project Planner</title>
    <style>
        body {
            background-color: hsl(120, 11.33%, 87.45%);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px; margin-top: 40px">
            <asp:Label ID="LoggedAs" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="MoveToWebForm" runat="server" Text="LogOut" OnClick="MoveToWebForm_Click" />
            <asp:Button ID="MoveToProjects" runat="server" Text="Projects" OnClick="MoveToProjects_Click" />
            <asp:Button ID="MoveToMainBoard" runat="server" Text="MainBoard" OnClick="MoveToMainBoard_Click" Width="83px" />
            <asp:Button ID="MoveToAdmin" runat="server" Text="Admin" OnClick="MoveToAdmin_Click" Visible="false" />
        </div>
        <panel runat="server" id="UserPanel" visible="True">
            <div style="margin-left: 40px; margin-top: 40px; margin-left: 40px">
                <h3>Welcome to ProjectPlanner </h3>
                <br />
                This tool allows you to easly manage your project timelines using simple calendar view.
                <br />
                <b>Projects</b> tab allows you to review current projects, modify them and add new ones. Each project is assigned to user, start and end date are not mandatory fields due to long projects. 
                <br />
                You are currently located at <b>MainBoard</b>.
                <br />
                <asp:Label ID="AdminDescriptionLabel" runat="server" Text=" <b>Admin</b> tab is hidden for users and allows you to manage, add, remove and modify existing accounts." Visible="false"></asp:Label>
            </div>
        </panel>
    </form>
</body>
</html>

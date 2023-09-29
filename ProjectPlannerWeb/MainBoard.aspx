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
        <div>
               <asp:Label ID="LoggedAs" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="MoveToWebForm" runat="server" Text="LogOut" OnClick="MoveToWebForm_Click" />
            <asp:Button ID="MoveToProjects" runat="server" Text="Projects" OnClick="MoveToProjects_Click" />
            <asp:Button ID="MoveToMainBoard" runat="server" Text="MainBoard" OnClick="MoveToMainBoard_Click" Width="83px" />
            <asp:Button ID="MoveToAdmin" runat="server" Text="Admin" OnClick="MoveToAdmin_Click" visible="false"/>
        </div>


        <panel runat="server" id="UserPanel" visible="True">
            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="#663399" ShowGridLines="True" OnSelectionChanged="Calendar1_SelectionChanged"
                OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            </asp:Calendar>
            <asp:Label ID="LabelAction" runat="server"></asp:Label><br />
        </panel>
    </form>
</body>
</html>

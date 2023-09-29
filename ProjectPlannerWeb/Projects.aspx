<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="ProjectPlannerWeb.Projects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            <asp:Button ID="MoveToAdmin" runat="server" Text="Admin" OnClick="MoveToAdmin_Click" visible="false" />
        </div>
    </form>

</body>
</html>

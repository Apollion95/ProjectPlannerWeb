<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainBoard.aspx.cs" Inherits="ProjectPlannerWeb.MainBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LoggedAs" runat="server" Text="Label"></asp:Label>
            <p>
                <asp:Button ID="Button1" runat="server" Text="LogOut" OnClick="Button1_Click" />
            </p>

        </div>
        <div>
            Add New user

        </div>
    </form>
</body>
</html>

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
        <h3>Admin Panel</h3>
        <div>
            <asp:TextBox ID="LoginAdmin" runat="server" placeholder="Login" OnTextChanged="LoginAdmin_TextChanged"></asp:TextBox>
            <asp:TextBox ID="PasswordAdmin" runat="server" placeholder="NewPassword" OnTextChanged="PasswordAdmin_TextChanged"></asp:TextBox>
            <asp:TextBox ID="EmailAdmin" runat="server" placeholder="Email" OnTextChanged="EmailAdmin_TextChanged"></asp:TextBox>
            <asp:TextBox ID="DescriptionAdmin" runat="server" placeholder="Description" OnTextChanged="DescriptionAdmin_TextChanged"></asp:TextBox>
             <asp:DropDownList id="RoleList" runat="server">
                  <asp:ListItem Selected="True" Value="1"> 1-User </asp:ListItem>
                  <asp:ListItem Value="2"> 2-Moderator </asp:ListItem>
                  <asp:ListItem Value="3"> 3-Admin </asp:ListItem>
               </asp:DropDownList>
            <br />
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
            <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"></asp:GridView> </div>
    </form>
</body>
</html>

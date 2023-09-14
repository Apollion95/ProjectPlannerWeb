﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainBoard.aspx.cs" Inherits="ProjectPlannerWeb.MainBoard" %>

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
            <asp:DropDownList ID="UserIdDropDown" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="false"></asp:DropDownList>
            <asp:TextBox ID="LoginAdmin" runat="server" placeholder="Login" OnTextChanged="LoginAdmin_TextChanged"></asp:TextBox>
            <asp:TextBox ID="PasswordAdmin" runat="server" placeholder="NewPassword" OnTextChanged="PasswordAdmin_TextChanged"></asp:TextBox>
            <asp:TextBox ID="EmailAdmin" runat="server" placeholder="Email" OnTextChanged="EmailAdmin_TextChanged"></asp:TextBox>
            <asp:TextBox ID="DescriptionAdmin" runat="server" placeholder="Description" OnTextChanged="DescriptionAdmin_TextChanged"></asp:TextBox>
            <asp:DropDownList ID="RoleList" runat="server">
                <asp:ListItem Selected="True" Value="1"> 1-User </asp:ListItem>
                <asp:ListItem Value="2"> 2-Moderator </asp:ListItem>
                <asp:ListItem Value="3"> 3-Admin </asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
            <asp:Button ID="Refresh" runat="server" Text="Refresh" OnClick="refresh_Click" />
            <asp:Label ID="test" runat="server" Text="test"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" DataKeyNames="UserID" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

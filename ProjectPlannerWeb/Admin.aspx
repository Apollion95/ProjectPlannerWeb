<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ProjectPlannerWeb.Admin" %>

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
        <div style="margin-left: 40px; margin-top: 40px; margin-left: 40px">
            <asp:Label ID="LoggedAs" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="MoveToWebForm" runat="server" Text="LogOut" OnClick="MoveToWebForm_Click" />
            <asp:Button ID="MoveToProjects" runat="server" Text="Projects" OnClick="MoveToProjects_Click" />
            <asp:Button ID="MoveToMainBoard" runat="server" Text="MainBoard" OnClick="MoveToMainBoard_Click" Width="83px" />
            <asp:Button ID="MoveToAdmin" runat="server" Text="Admin" OnClick="MoveToAdmin_Click" Visible="false" />
            <asp:Panel runat="server" ID="AdminPanel">
                <h3>Admin Panel</h3>
                <br />
                <div>
                    <%--<asp:DropDownList ID="UserIdDropDown" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="false"></asp:DropDownList>--%>
                    <asp:TextBox ID="LoginAdmin" runat="server" placeholder="New Login" OnTextChanged="LoginAdmin_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="PasswordAdmin" runat="server" placeholder="New Password" OnTextChanged="PasswordAdmin_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="EmailAdmin" runat="server" placeholder="Email" OnTextChanged="EmailAdmin_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="DescriptionAdmin" runat="server" placeholder="Description" OnTextChanged="DescriptionAdmin_TextChanged"></asp:TextBox>
                    <asp:DropDownList ID="RoleList" runat="server" OnSelectedIndexChanged="RoleList_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1"> 1-User </asp:ListItem>
                        <asp:ListItem Value="2"> 2-Moderator </asp:ListItem>
                        <asp:ListItem Value="3"> 3-Admin </asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
                    <asp:Button ID="Refresh" runat="server" Text="Refresh" OnClick="refresh_Click" />
                    <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" DataKeyNames="UserID" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" AutoGenerateColumns="False" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDeleting="GridView2_RowDeleting" EnableViewState="False">
                        <Columns>
                            <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Login">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Login" runat="server" Text='<%# Bind("Login") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LoginLabel" runat="server" Text='<%# Eval("Login") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Password" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Email" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Description" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="RoleDropdown" runat="server">
                                        <asp:ListItem Text="1-User" Value="1" />
                                        <asp:ListItem Text="2-Moderator" Value="2" />
                                        <asp:ListItem Text="3-Admin" Value="3" />
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="RoleLabel" runat="server" Text='<%# Eval("Role") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

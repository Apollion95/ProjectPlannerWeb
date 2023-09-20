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
        <asp:Panel runat="server" ID="AdminPanel" Visible="false">
            <h3>Admin Panel</h3>
            <br />
            <div>
                <%--<asp:DropDownList ID="UserIdDropDown" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="false"></asp:DropDownList>--%>
                <asp:TextBox ID="LoginAdmin" runat="server" placeholder="New Login" OnTextChanged="LoginAdmin_TextChanged"></asp:TextBox>
                <asp:TextBox ID="PasswordAdmin" runat="server" placeholder="New Password" OnTextChanged="PasswordAdmin_TextChanged"></asp:TextBox>
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
                <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" DataKeyNames="UserID" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" AutoGenerateColumns="False" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDeleting="GridView2_RowDeleting">
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

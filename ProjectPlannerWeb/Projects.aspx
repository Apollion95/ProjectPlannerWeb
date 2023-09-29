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
            <asp:Button ID="MoveToAdmin" runat="server" Text="Admin" OnClick="MoveToAdmin_Click" Visible="false" />
        </div>
        <div>
            <asp:TextBox ID="ProposeProjectStartDate" runat="server" placeholder="New Project Start Date MM/dd/yyyy"></asp:TextBox>
            <asp:TextBox ID="ProposeProjectEndDate" runat="server" placeholder="New Project End Date MM/dd/yyyy"></asp:TextBox>
            <asp:TextBox ID="ProposeDescription" runat="server" placeholder="New Project Description"></asp:TextBox>
            <asp:Button ID="SubmitProjectButton1" runat="server" Text="Submit Project" OnClick="SubmitProjectButton1_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" EnableViewState="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="ProjectID" HeaderText="Project ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="UserID">
                        <EditItemTemplate>
                            <asp:TextBox ID="UserID" runat="server" Text='<%# Bind("UserID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProjectStartDate">
                        <EditItemTemplate>
                            <asp:TextBox ID="ProjectStartDate" runat="server" Text='<%# Bind("ProjectStartDate") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ProjectStartDateLabel" runat="server" Text='<%# Bind("ProjectStart", "{0:MM/dd/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ProjectEndDate">
                        <EditItemTemplate>
                            <asp:TextBox ID="ProjectEndDate" runat="server" Text='<%# Bind("ProjectEndDate") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ProjectEndDateLabel" runat="server" Text='<%# Eval("ProjectEnd", "{0:MM/dd/yyyy}") %>'></asp:Label>
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
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>

</body>
</html>

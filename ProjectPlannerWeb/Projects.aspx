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
        <div style="margin-left: 40px; margin-top: 40px; margin-left: 40px">
            <asp:Label ID="LoggedAs" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="MoveToWebForm" runat="server" Text="LogOut" OnClick="MoveToWebForm_Click" />
            <asp:Button ID="MoveToProjects" runat="server" Text="Projects" OnClick="MoveToProjects_Click" />
            <asp:Button ID="MoveToMainBoard" runat="server" Text="MainBoard" OnClick="MoveToMainBoard_Click" Width="83px" />
            <asp:Button ID="MoveToAdmin" runat="server" Text="Admin" OnClick="MoveToAdmin_Click" Visible="false" />
        </div>
        <p>
        </p>
        <div style="margin-left: 40px; margin-top: 40px; margin-left: 40px">
            This is project tab, here you can review, edit, remove and add new project. <br />
            If you want to add new project select select project start date on left calendar and project end date on right calendar. <br />
            Keep in mind to provide project description. Once you are done click button "Submit New Project". Once you click it you will be assigned to project as owner. <br />
            If you want to edit existing project, click Edit <br />
            <br />
            <asp:TextBox ID="ProposeDescription" runat="server" placeholder="New Project Description" textmode="MultiLine" Height="20px" Width="350px"></asp:TextBox>
            <asp:Button ID="SubmitProjectButton1" runat="server" Text="Submit New Project" OnClick="SubmitProjectButton1_Click" />
        </div>
        <div style="margin-left: 40px; margin-top: 40px; margin-left: 40px">
           
            <asp:GridView ID="GridView1" runat="server" EnableViewState="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="ProjectID" HeaderText="Project ID" ReadOnly="True" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" />
                    <asp:BoundField DataField="ProjectStart" HeaderText="Project Start" ReadOnly="True" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="ProjectEnd" HeaderText="Project End" ReadOnly="True"  DataFormatString="{0:MM/dd/yyyy}" />
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
            <asp:Calendar ID="Calendar1" runat="server" Style="float: left; margin-right: 10px;" BackColor="#FFFFCC" BorderColor="#FFCC66"
                BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="#663399" ShowGridLines="True" OnSelectionChanged="Calendar1_SelectionChanged" Height="200px" Width="300px">
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            </asp:Calendar>
            <asp:Calendar ID="Calendar2" runat="server" Style="float: left" BackColor="#FFFFCC" BorderColor="#FFCC66"
                BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="#663399" ShowGridLines="True" OnSelectionChanged="Calendar2_SelectionChanged" Height="200px" Width="300px">
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            </asp:Calendar>
            <br />
            <asp:Label ID="StartLabel" runat="server"></asp:Label><br />
            <asp:Label ID="EndLabel" runat="server"></asp:Label><br />
        </div>
    </form>
</body>
</html>

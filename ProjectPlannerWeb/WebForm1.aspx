<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjectPlannerWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project Scheduler</title>
    <style>
        body {
            background-color: ghostwhite;
        }

        #form1 {
            width: 1034px;
            height: 437px;
        }
    </style>
</head>
<body style="height: 600px; width: 800px;">
    <form id="form1" runat="server">
        <h2>Welcome to Project Scheduler Site</h2>
        <table>
            <h3> Sign in</h3>
            <asp:TextBox ID="Login2" runat="server" OnTextChanged="Login_TextChanged" placeholder="Login"></asp:TextBox>
            <p>
                 <asp:TextBox ID="Password" TextMode="Password" runat="server" placeholder="Password" OnTextChanged="Password_TextChanged"></asp:TextBox>
                <p>
                   <asp:Label ID="ErrorLogin" runat="server" Text="Incorrect Username and/or Password" Visible="False"></asp:Label>
                    </p>
                <p>
                    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Button2_Click" />
                 
                </p>
            </p>
        </table>
    </form>
</body>
</html>

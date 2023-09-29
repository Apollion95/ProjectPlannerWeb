<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjectPlannerWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project Scheduler</title>
    <style>
        body {
            background-color: hsl(120, 11.33%, 87.45%);
        }
    </style>
</head>
<body style="top: 24px; width: 600px; height: 100%; background-image: url(Background2.png); background-repeat: no-repeat">
    <form id="form1" runat="server">
        <table>
            <h3 style="width: 300px">Sign in</h3>
            <asp:TextBox ID="Login2" runat="server" OnTextChanged="Login_TextChanged" placeholder="Login" Width="200px"></asp:TextBox>
            <p>
                <asp:TextBox ID="Password" TextMode="Password" runat="server" placeholder="Password" OnTextChanged="Password_TextChanged" Width="200px"></asp:TextBox>
                <p>
                    <asp:Label ID="ErrorLogin" runat="server" Text="Incorrect Username and/or Password" Visible="False"></asp:Label>
                    <script type="text/javascript">
                        setTimeout(function () {
                            var label = document.getElementById('<%= ErrorLogin.ClientID %>');
                            if (label) {
                                label.style.display = 'none';
                            }
                        }, 5000); 
                    </script>
                </p>
            </p>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Button2_Click" />
        </table>
    </form>
</body>
</html>

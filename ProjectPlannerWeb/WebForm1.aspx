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
<body>
    <div style="margin-left: 40%; margin-top: 300px; background-repeat: no-repeat">
        <form id="form1" runat="server">
            <table class="centered-table">
                <h3 style="width: 300px">Sign in</h3>
                <asp:TextBox ID="Login2" runat="server" OnTextChanged="Login_TextChanged" placeholder="Login" Width="200px"></asp:TextBox>
                <p>
                    <asp:TextBox ID="Password" TextMode="Password" runat="server" placeholder="Password" OnTextChanged="Password_TextChanged" Width="200px"></asp:TextBox>
                    <p>
                        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Button2_Click" />
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
                         <asp:Label ID="NoAccount" runat="server" Text="If you do not have account, please contact system administrator"></asp:Label>
            </table>
        </form>
    </div>
    <div style="margin-right: 85%; margin-top: 200px; display: flex">
        <img src="asp.net-logo-MSA-Technosoft.png" style="height: 180px; width: 350px; margin-left: 10px" />
        <img src="SQLlogo4.png" style="height: 170px; width: 350px" />
    </div>
</body>
</html>

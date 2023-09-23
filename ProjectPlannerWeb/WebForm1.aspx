<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjectPlannerWeb.WebForm1" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Project Scheduler</title>
        <style>
            body {
                background-color: ghostwhite;
            }
        </style>
    </head>

    <body style="top: 24px;width: 800px; height: 100%;">
        <form id="form1" runat="server">
            <h2>Welcome to Project Scheduler Site</h2>
            <panel>

            </panel>
            <table>
                <div id="centered-script">
                    <h3> Sign in</h3>
                    <asp:TextBox ID="Login2" runat="server" OnTextChanged="Login_TextChanged" placeholder="Login">
                    </asp:TextBox>
                    <p>
                        <asp:TextBox ID="Password" TextMode="Password" runat="server" placeholder="Password"
                            OnTextChanged="Password_TextChanged"></asp:TextBox>
                    <p>
                        <asp:Label ID="ErrorLogin" runat="server" Text="Incorrect Username and/or Password"
                            Visible="False"></asp:Label>
                    </p>
                    <p>
                        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Button2_Click" />

                    </p>
                    </p>
                </div>
            </table>
        </form>
    </body>

    </html>
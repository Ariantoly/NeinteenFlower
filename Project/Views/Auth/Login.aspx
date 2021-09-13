<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project.Views.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
</head>
<body>
    <h1>Log In</h1>
    <form id="form1" runat="server">
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:CheckBox ID="rememberChck" runat="server" Text="Remember Me"/>
        <br />
        <br />
        <asp:Button ID="submitBtn" runat="server" Text="Log In" OnClick="submitBtn_Click" />
        <br />
        <asp:Label ID="lblErrMsg" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Have any problem?"></asp:Label>
        <br />
        <asp:Button ID="RegisBtn" runat="server" Text="Sign Up" OnClick="RegisBtn_Click" />
        <asp:Label ID="Label2" runat="server" Text="Or"></asp:Label>
        <asp:Button ID="ForgetBtn" runat="server" Text="Reset Password" OnClick="ForgetBtn_Click" />

    </form>
</body>
</html>

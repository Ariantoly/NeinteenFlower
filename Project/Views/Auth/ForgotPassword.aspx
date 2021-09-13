<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Project.Views.Auth.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Change Password</h1>
    <form id="form1" runat="server">
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        <asp:Label ID="lblCaptcha" runat="server" Text="Captcha: "></asp:Label>
        <asp:Label ID="lblRandom" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="New Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblErrMsg" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Change Password" OnClick="btnSubmit_Click"/>
    </form>
</body>
</html>

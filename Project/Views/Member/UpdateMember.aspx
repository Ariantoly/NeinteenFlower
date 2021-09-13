<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMember.aspx.cs" Inherits="Project.Views.UpdateMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Update Member</h1>

        <asp:Label ID="emailLbl" runat="server" Text="E-mail:"></asp:Label>
        <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="passwordLbl" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="passwordTxt" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="nameLbl" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth:"></asp:Label>
        <asp:TextBox ID="DOBTxt" TextMode="Date" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="genderLbl" runat="server" Text="Gender:"></asp:Label>
        <asp:RadioButtonList ID="RBGender" runat="server">
            <asp:ListItem Text="Male" Value="male" />
            <asp:ListItem Text="Female" Value="female" />
        </asp:RadioButtonList>

        <asp:Label ID="phoneNumberLbl" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="phoneTxt" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="addressLbl" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="addressTxt" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="errLbl" runat="server" Text=""></asp:Label>
        <br />

        <asp:Button ID="updateBtn" runat="server" Text="Update Member" OnClick="updateBtn_Click" />
    </form>
</body>
</html>

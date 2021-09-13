<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Preorder.aspx.cs" Inherits="Project.Views.Member.Preorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Preorder</h1>
        <asp:Image ID="imageFlower" runat="server" ImageUrl="" Height="200px"/> </asp:Image> 
        <br />
        <asp:Label ID="nameFlower" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="descFlower" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="priceFlower" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="qtyBuy" runat="server" Text="Input your quantity: "></asp:Label>
        <asp:TextBox ID="qtyValue" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="submitbtn" runat="server" Text="Submit" OnClick="submitbtn_Click" />
        <br />
        <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

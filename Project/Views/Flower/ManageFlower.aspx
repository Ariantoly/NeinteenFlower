<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManageFlower.aspx.cs" Inherits="Project.Views.ManageFlower" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Flower</h1>
    <asp:GridView ID="gvFlower" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvFlower_RowDeleting" OnRowEditing="gvFlower_RowEditing">
        <Columns>
            <asp:BoundField DataField="FlowerID" HeaderText="ID" />
            <asp:BoundField DataField="FlowerName" HeaderText="Name" />
            <asp:BoundField DataField="MsFlowerType.FlowerTypeName" HeaderText="Type" />
            <asp:BoundField DataField="FlowerDescription" HeaderText="Description" />
            <asp:BoundField DataField="FlowerPrice" HeaderText="Price" />
            <asp:ImageField HeaderText="Image" DataImageUrlField="FlowerImage" ControlStyle-Width="100px"></asp:ImageField>
            <asp:CommandField HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <a href="./InsertFlower.aspx">Insert Flower</a>
</asp:Content>

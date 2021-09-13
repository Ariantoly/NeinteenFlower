<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>Home</h1>
        <asp:Label ID="WelcomeMsg" runat="server" Text=""></asp:Label>
        <%-- tombol dan gridview nanti pertamanya visiblenya == false --%>
        <%-- nanti bikin welcome <nama> buat member dan employee menggunakan data dari session --%>
        <%-- member --%>
        <asp:GridView ID="gvFlower" runat="server" AutoGenerateColumns="False" OnRowCommand="gvFlower_RowCommand">
            <Columns>
                <asp:BoundField DataField="FlowerID" HeaderText="ID" />
                <asp:BoundField DataField="FlowerName" HeaderText="Name" />
                <asp:BoundField DataField="MsFlowerType.FlowerTypeName" HeaderText="Type" />
                <asp:BoundField DataField="FlowerDescription" HeaderText="Description" />
                <asp:BoundField DataField="FlowerPrice" HeaderText="Price" />
                <asp:ImageField HeaderText="Image" DataImageUrlField="FlowerImage" ControlStyle-Width="100px">
<ControlStyle Width="100px"></ControlStyle>
                </asp:ImageField>
                <asp:ButtonField CommandName="Preorder" HeaderText="Action" Text="Preorder" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="historyBtn" runat="server" Text="View Transaction History" OnClick="historyBtn_Click" />
        
        <%-- employee --%>
        <asp:Button ID="flowerBtn" runat="server" Text="Manage Flower" OnClick="flowerBtn_Click" />

        <%-- admin --%>
        <asp:Button ID="memberBtn" runat="server" Text="Manage Member" OnClick="memberBtn_Click" />
        <asp:Button ID="employeeBtn" runat="server" Text="Manage Employee" OnClick="employeeBtn_Click" />

    </div>

</asp:Content>

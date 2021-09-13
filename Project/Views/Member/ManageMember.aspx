<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManageMember.aspx.cs" Inherits="Project.Views.ManageMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Manage Member</h1>
        <asp:GridView ID="GVMember" runat="server" AutoGenerateColumns="False" OnRowDeleting="GVMember_RowDeleting" OnRowEditing="GVMember_RowEditing">
            <Columns>
                <asp:BoundField DataField="MemberId" HeaderText="ID" />
                <asp:BoundField DataField="MemberName" HeaderText="Name" />
                <asp:BoundField DataField="MemberDOB" HeaderText="DOB" DataFormatString="{0:d}"/>
                <asp:BoundField DataField="MemberGender" HeaderText="Gender" />
                <asp:BoundField DataField="MemberAddress" HeaderText="Address" />
                <asp:BoundField DataField="MemberPhone" HeaderText="Phone" />
                <asp:BoundField DataField="MemberEmail" HeaderText="Email" />
                <asp:BoundField DataField="MemberPassword" HeaderText="Password" />
                <asp:CommandField HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <a href="./InsertMember.aspx">Insert Member</a>
</asp:Content>


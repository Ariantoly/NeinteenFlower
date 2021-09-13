<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="Project.Views.ManageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Employee</h1>
    <asp:GridView ID="GVEmployee" runat="server" AutoGenerateColumns="False" OnRowDeleting="GVEmployee_RowDeleting" OnRowEditing="GVEmployee_RowEditing">
        <Columns>
            <asp:BoundField DataField="EmployeeId" HeaderText="ID" />
            <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
            <asp:BoundField DataField="EmployeeDOB" HeaderText="DOB" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="EmployeeGender" HeaderText="Gender" />
            <asp:BoundField DataField="EmployeeAddress" HeaderText="Address" />
            <asp:BoundField DataField="EmployeePhone" HeaderText="Phone" />
            <asp:BoundField DataField="EmployeeEmail" HeaderText="Email" />
            <asp:BoundField DataField="EmployeePassword" HeaderText="Password" />
            <asp:BoundField DataField="EmployeeSalary" HeaderText="Salary" />
            <asp:CommandField HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <a href="./InsertEmployee.aspx">Insert Employee</a>
</asp:Content>

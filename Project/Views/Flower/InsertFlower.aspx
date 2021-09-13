<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertFlower.aspx.cs" Inherits="Project.Views.Flower.InsertFlower" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        .forms{
            display: flex;
            align-items: center;
        }

        .label{
            width: 100px;
        }
    </style>
    <form id="form1" runat="server">
        <h1>Insert Flower</h1>
        <div class="forms">
            <div class="label">
                <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class="forms">
            <div class="label">
                <asp:Label ID="lblImage" runat="server" Text="Image: "></asp:Label>
            </div>
            <div>
                <asp:FileUpload ID="fileImage" runat="server" />
            </div>
        </div>

        <br />
        
        <div class="forms">
            <div class="label">
                <asp:Label ID="lblDesc" runat="server" Text="Description: "></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
        </div>
        
        <br />
        
        <div class="forms">
            <div class="label">
                <asp:Label ID="lblType" runat="server" Text="Flower Type: "></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
            </div>
        </div>

        <br />
        
        <div class="forms">
            <div class="label">
                <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <br />
        <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
    </form>
</body>
</html>

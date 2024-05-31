<%@ Page Title="Create Supplement Page" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="CreateSupplementPage.aspx.cs" Inherits="GymMe.Views.Admin.Supplement.CreateSupplementPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fw-bold fs-2 text-center">Create Supplement</p>

    <div class="d-flex flex-column">
        <div class="d-flex flex-column gap-2 mb-3">
            <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-flex flex-column gap-2 mb-3">
            <asp:Label ID="LblExpiryDate" runat="server" Text="Expiry Date"></asp:Label>
            <asp:TextBox ID="TxtExpiryDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-flex flex-column gap-2 mb-3">
            <asp:Label ID="LblPrice" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="TxtPrice" runat="server" TextMode="number" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-flex flex-column gap-2 mb-3">
            <asp:Label ID="LblSupplementType" runat="server" Text="Supplement Type"></asp:Label>
            <asp:DropDownList ID="DDLSupplementType" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
        </div>
        <div class="mb-3">
            <asp:Button ID="BtnCreate" runat="server" Text="Create" OnClick="BtnCreate_Click" CssClass="btn btn-primary" />
            <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" CssClass="btn btn-secondary"/>
        </div>
    </div>
</asp:Content>

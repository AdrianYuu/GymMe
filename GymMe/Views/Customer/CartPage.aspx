<%@ Page Title="Cart Page" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="GymMe.Views.User.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fw-bold fs-2 text-center">My Cart</p>

    <asp:GridView ID="GVCartData" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered table-condensed">
        <Columns>
            <asp:BoundField DataField="MsSupplement.SupplementName" HeaderText="Name" SortExpression="MsSupplement.SupplementName" />
            <asp:BoundField DataField="MsSupplement.SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="MsSupplement.SupplementExpiryDate" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="MsSupplement.SupplementPrice" HeaderText="Price" SortExpression="MsSupplement.SupplementPrice" />
            <asp:BoundField DataField="MsSupplement.MsSupplementType.SupplementTypeName" HeaderText="Type" SortExpression="MsSupplement.MsSupplementType.SupplementTypeName" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>

    <div>
        <asp:Button ID="BtnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" CssClass="btn btn-primary"/>
        <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" CssClass="btn btn-danger"/>
    </div>
</asp:Content>

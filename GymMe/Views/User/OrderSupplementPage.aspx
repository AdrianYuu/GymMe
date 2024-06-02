<%@ Page Title="Order Supplement Page" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderSupplementPage.aspx.cs" Inherits="GymMe.Views.OrderSupplementPage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fw-bold fs-2 text-center">Order Supplement</p>
    <asp:Label ID="LblStatus" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GVSupplementData" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered table-condensed" OnRowCommand="GVSupplementData_RowCommand" DataKeyNames="SupplementID">
        <Columns>
            <asp:BoundField DataField="SupplementID" HeaderText="Name" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Type" SortExpression="MsSupplementType.SupplementTypeName" />
            <asp:TemplateField HeaderText="Order">
                <ItemTemplate>
                    <div class="d-flex align-items-center gap-2">
                        <asp:TextBox ID="TxtQuantity" placeholder="Insert the quantity..." runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        <asp:Button ID="BtnOrder" runat="server" Text="Order" CommandName="Order" CssClass="btn btn-primary" UseSubmitBehavior="false" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>

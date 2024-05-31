<%@ Page Title="Manage Supplement Page" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageSupplementPage.aspx.cs" Inherits="GymMe.Views.ManageSupplementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fw-bold fs-2 text-center">Supplement List</p>
    <div class="mb-4">
        <asp:LinkButton ID="LBCreateSupplement" runat="server" CssClass="btn btn-secondary" OnClick="LBCreateSupplement_Click">Create Supplement</asp:LinkButton>
    </div>
    <asp:GridView ID="GVSupplementData" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered table-condensed" OnRowDeleting="GVSupplementData_RowDeleting" OnRowEditing="GVSupplementData_RowEditing">
        <Columns>
            <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" SortExpression="SupplementID"/>
            <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Type" SortExpression="MsSupplementType.SupplementTypeName" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="BtnEdit" runat="server" Text="Edit" UseSubmitBehavior="false" CommandName="Edit" CssClass="btn btn-warning"/>
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" UseSubmitBehavior="false" CommandName="Delete" CssClass="btn btn-danger"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

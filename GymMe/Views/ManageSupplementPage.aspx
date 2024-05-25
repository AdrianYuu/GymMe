<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="ManageSupplementPage.aspx.cs" Inherits="GymMe.Views.ManageSupplementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Supplement Page</h1>

    <br /><br />

    <asp:GridView ID="GVSupplementData" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered table-condensed" OnRowDeleting="GVSupplementData_RowDeleting" OnRowEditing="GVSupplementData_RowEditing">
        <Columns>
            <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Type" SortExpression="MsSupplementType.SupplementTypeName" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="BtnEdit" runat="server" Text="Edit" UseSubmitBehavior="false" CommandName="Edit"/>
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" UseSubmitBehavior="false" CommandName="Delete"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>

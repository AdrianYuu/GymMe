<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="GymMe.Views.TransasctionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <p class="fw-bold fs-2 text-center">Transaction Detail</p>
  <asp:Label ID="LblStatus" runat="server" Text="" CssClass="m-2 fs-6"></asp:Label>
 <asp:GridView ID="GVTransactionDetailData" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered table-condensed">
     <Columns>
         <asp:BoundField DataField="MsSupplement.SupplementName" HeaderText="Name" SortExpression="MsSupplement.SupplementName" />
         <asp:BoundField DataField="MsSupplement.SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="MsSupplement.SupplementExpiryDate" DataFormatString="{0:dd/MM/yyyy}"/>
         <asp:BoundField DataField="MsSupplement.SupplementPrice" HeaderText="Price" SortExpression="MsSupplement.SupplementPrice" />
         <asp:BoundField DataField="MsSupplement.MsSupplementType.SupplementTypeName" HeaderText="Type" SortExpression="MsSupplement.MsSupplementType.SupplementTypeName" />
         <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
     </Columns>
 </asp:GridView>
</asp:Content>

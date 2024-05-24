<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderSupplementPage.aspx.cs" Inherits="GymMe.Views.OrderSupplementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Order Supplement</h1>
     <br />
     <form runat="server">
         <asp:GridView ID="GVSupplementData" runat="server" AutoGenerateColumns="False"
             CellPadding="6" CssClass="table table-striped table-bordered table-condensed"
             >
             <Columns>
                 <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                 <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                 <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                 <asp:BoundField DataField="MsSupplementType.SupplementTypeName" HeaderText="Type" SortExpression="MsSupplementType.SupplementTypeName" />
                 <asp:TemplateField HeaderText="Order">
                     <ItemTemplate>
                         <asp:TextBox ID="QuantityTxt" placeholder="Quantity" runat="server"></asp:TextBox>
                         <asp:Button ID="OrderBtn" runat="server" Text="Order" />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
            
         </asp:GridView>
     </form>
</asp:Content>

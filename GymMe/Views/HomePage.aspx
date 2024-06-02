<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GymMe.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-end">
        <asp:Label ID="LblRole" runat="server" Text="" CssClass="fw-2 fs-6"></asp:Label>
    </div>

    <asp:Panel ID="PanelAdmin" runat="server" Visible="false">
        <p class="fw-bold fs-2">Customer Data</p>
        <asp:GridView ID="GVCustomerData" AutoGenerateColumns="False" runat="server" CellPadding="6" CssClass="table table-striped table-bordered table-condensed">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserDOB" HeaderText="Date Of Birth" SortExpression="UserDOB" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>

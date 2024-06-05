<%@ Page Title="History Page" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="GymMe.Views.HistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fw-bold fs-2 text-center">History</p>
    <asp:GridView ID="GVHistoryData" runat="server" AutoGenerateColumns="False" CellPadding="6" CssClass="table table-striped table-bordered table-condensed" OnRowCommand="GVHistoryData_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:TemplateField HeaderText="Transaction Detail">
                <ItemTemplate>
                    <div class="d-flex align-items-center">
                        <asp:Button ID="BtnTransactionDetail" runat="server" Text="View Detail" CommandName="ViewDetail" CssClass="btn btn-primary" UseSubmitBehavior="false" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

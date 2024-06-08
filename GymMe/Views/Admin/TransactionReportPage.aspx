<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionReportPage.aspx.cs" Inherits="GymMe.Views.Admin.TransactionReportPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="true" />
    </div>
</asp:Content>

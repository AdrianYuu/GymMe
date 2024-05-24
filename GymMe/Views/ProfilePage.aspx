<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="GymMe.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile Page</h1>
    <h4 id="UserName" runat="server"></h4>
    <h4 id="UserEmail" runat="server"></h4>
    <h4 id="UserDOB" runat="server"></h4>
    <h4 id="UserGender" runat="server"></h4>
</asp:Content>

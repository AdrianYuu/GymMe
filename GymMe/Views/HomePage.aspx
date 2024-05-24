<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GymMe.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Home Page</h1>
        <br />
        
        <h3>Role: <%=UserRole%></h3>
        <br />

        <% if (UserRole == "Admin") { %>
            <h3>Customer Data:</h3>
            <br />
            <form runat="server">
                <asp:GridView ID="GVCustomerData" AutoGenerateColumns="False" runat="server"
                    CellPadding="6" CssClass="table table-striped table-bordered table-condensed"
                    >
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" />
                        <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                        <asp:BoundField DataField="UserDOB" HeaderText="Date Of Birth" SortExpression="UserDOB"  DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                        <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                    </Columns>
                </asp:GridView>
            </form>
        <% } %>
</asp:Content>

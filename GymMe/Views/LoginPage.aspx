<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GymMe.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login Page</h1>
        <div>
            <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:CheckBox ID="CBRememberMe" runat="server" Text="Remember Me"/>
        </div>
        <div>
            <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click"/>
        </div>
        <div>
            <asp:LinkButton ID="LBRegister" runat="server" OnClick="LBRegister_Click">Don't have an account? Register here!</asp:LinkButton>
        </div>
    </form>
</body>
</html>

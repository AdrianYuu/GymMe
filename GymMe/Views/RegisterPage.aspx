<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="GymMe.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Register Page</h1>

        <div>
            <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="RBGender" runat="server">
                <asp:ListItem Text="Male" Value="Male" ></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female" ></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblDOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="TxtDOB" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click"/>
        </div>
        <div>
            <asp:LinkButton ID="LBLogin" runat="server" OnClick="LBLogin_Click">Already have an account? Login here!</asp:LinkButton>
        </div>
    </form>
</body>
</html>

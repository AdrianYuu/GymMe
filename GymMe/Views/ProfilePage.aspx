<%@ Page Title="" Language="C#" MasterPageFile="~/Views/NavBar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="GymMe.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile Page</h1>

    <br /><br />

    <div>
        <h4>Update User Profile</h4>
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
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="LblDOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="TxtDOB" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblErrorProfile" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="BtnUpdateUserInformation" runat="server" Text="Update User" OnClick="BtnUpdateUserInformation_Click"/>
        </div>
    </div>

    <br /><br />

    <div>
        <h4>Update User Password</h4>
        <div>
            <asp:Label ID="LblOldPassword" runat="server" Text="Old Password"></asp:Label>
            <asp:TextBox ID="TxtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblNewPassword" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblErrorPassword" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="BtnUpdatePassword" runat="server" Text="Update Password" OnClick="BtnUpdatePassword_Click"/>
        </div>
    </div>
    

</asp:Content>

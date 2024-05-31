<%@ Page Title="Profile Page" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="GymMe.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="fw-bold fs-2 text-center">Profile Page</p>
    <div class="d-flex gap-5 justify-content-center">
        <div>
            <p class="fs-4">Update Profile Information</p>
            <div class="d-flex flex-column gap-2 mb-2">
                <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="d-flex flex-column gap-2 mb-2">
                <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="d-flex flex-column gap-2 mb-2">
                <asp:Label ID="LblGender" runat="server" Text="Gender"></asp:Label>
                <asp:RadioButtonList ID="RBGender" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="d-flex flex-column gap-2 mb-2">
                <asp:Label ID="LblDOB" runat="server" Text="Date of Birth"></asp:Label>
                <asp:TextBox ID="TxtDOB" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:Label ID="LblErrorProfile" runat="server" Text=""></asp:Label>
            </div>
            <div class="mb-2">
                <asp:Button ID="BtnUpdateUserInformation" runat="server" Text="Update User" OnClick="BtnUpdateUserInformation_Click" CssClass="btn btn-primary" />
            </div>
        </div>

        <div>
            <p class="fs-4">Update Profile Information</p>
            <div class="d-flex flex-column gap-2 mb-2">
                <asp:Label ID="LblOldPassword" runat="server" Text="Old Password"></asp:Label>
                <asp:TextBox ID="TxtOldPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="d-flex flex-column gap-2 mb-2">
                <asp:Label ID="LblNewPassword" runat="server" Text="New Password"></asp:Label>
                <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:Label ID="LblErrorPassword" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Button ID="BtnUpdatePassword" runat="server" Text="Update Password" OnClick="BtnUpdatePassword_Click" CssClass="btn btn-primary" />
            </div>
        </div>


    </div>
</asp:Content>

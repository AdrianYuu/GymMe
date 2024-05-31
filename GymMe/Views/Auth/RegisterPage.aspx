<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="GymMe.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server" class="d-flex flex-column justify-content-center align-items-center text-light w-100 min-vh-100">
        <div class="bg-dark p-5">
            <p class="fs-3 fw-bold text-center">Register</p>
            <div class="d-flex gap-5">
                <div>
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
                </div>
                <div>
                    <div class="d-flex flex-column gap-2 mb-2">
                        <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="d-flex flex-column gap-2 mb-2">
                        <asp:Label ID="LblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                        <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="d-flex flex-column gap-2 mb-2">
                        <asp:Label ID="LblDOB" runat="server" Text="Date of Birth"></asp:Label>
                        <asp:TextBox ID="TxtDOB" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="mb-2">
                <asp:Label ID="LblError" runat="server" Text=""></asp:Label>
            </div>
            <div class="mb-2">
                <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click" CssClass="btn btn-primary" />
            </div>
            <div class="mb-2 d-flex justify-content-center">
                <asp:LinkButton ID="LBLogin" runat="server" OnClick="LBLogin_Click" CssClass="text-light nav-link">Already have an account? Login here!</asp:LinkButton>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>

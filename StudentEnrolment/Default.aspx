<%@ Page Title="Log into your account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentEnrolment.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login">
        <div class="row">
            <div class="col-12 text-center">
                <div class="login-logo">
                    <img src="assets/img/user.png" alt="Company Logo" class="img-fluid login-img"/>
                </div>
            </div>
            <div class="col-12 login-progress mb-3 mt-4"></div>
            <div class="col-12 text-center">
                <p class="login-text text-uppercase text-decoration-underline">Student enrollment</p>
            </div>
            <div class="col-12">
                <asp:Label ID="lblError" runat="server" Text="" CssClass="glow"></asp:Label>
            </div>
            <div class="col-12 login-form">
                <div class="form-group mb-2">
                    <label class="mb-1">Email</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>
                </div>
                <div class="form-group mb-2">
                    <label class="mb-1">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="col-12 text-center mt-3 mb-2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success text-uppercase login-btn" OnClick="btnLogin_Click"/>
            </div>
            <div class="col-12 text-center mb-2 mt-1">
                <asp:LinkButton ID="btnForgot" runat="server" CssClass="text-decoration-none" OnClick="btnForgot_Click">Forgot Password?</asp:LinkButton>
            </div>
             <div class="col-12 text-center">
                 <p>Do not have an account? <asp:LinkButton ID="btnCreate" runat="server" CssClass="text-decoration-none" OnClick="btnCreate_Click">Click here.</asp:LinkButton></p>
            </div>
        </div>
    </div>
</asp:Content>
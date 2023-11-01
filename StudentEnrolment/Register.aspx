<%@ Page Title="Create an account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudentEnrolment.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container register">
        <div class="row">
            <div class="col-12 mb-2">
                <h2>Create Account</h2>
            </div>
            <div class="col-12 mb-3 mt-3">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Username</label>
                <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" placeholder="john"></asp:TextBox>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Full Names</label>
                <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server" placeholder="John Doe"></asp:TextBox>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="john@example.com" TextMode="Email"></asp:TextBox>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Phone Number</label>
                <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="+254720300300"></asp:TextBox>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Date of Birth</label>
                <asp:TextBox ID="dtDateofBirth" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-sm-12 mb-2">
                <label class="mb-1">Address</label>
                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine" placeholder="Enter Address"></asp:TextBox>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Gender</label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control select2">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Country</label>
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <!-- Panel for Kenya -->
            <asp:Panel ID="panelKenya" runat="server" CssClass="col-12" Visible="false">
                <div class="row">
                    <div class="col-sm-6 mb-2">
                        <label class="mb-1">County</label>
                        <asp:DropDownList ID="ddlCounty" runat="server" CssClass="form-control select2"></asp:DropDownList>
                    </div>
                    <div class="col-sm-6 mb-2">
                        <label class="mb-1">Postal Address</label>
                        <asp:TextBox ID="txtPostalAddress" CssClass="form-control" runat="server" placeholder="P.O BOX 23 - 20100"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 mb-2">
                        <label class="mb-1">ID Number</label>
                        <asp:TextBox ID="txtIdNumber" CssClass="form-control" runat="server" placeholder="ID Number"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 mb-2">
                        <label class="mb-1">Birth Certificate Number</label>
                        <asp:TextBox ID="txtBirthCertificate" CssClass="form-control" runat="server" placeholder="Birth Certificate Number"></asp:TextBox>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Passport Number</label>
                <asp:TextBox ID="txtPassport" CssClass="form-control" runat="server" placeholder="Passport Number"></asp:TextBox>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Profile Picture</label>
                <asp:FileUpload ID="fuProfilePicture" runat="server" CssClass="form-control" ToolTip="Upload files with .png, .jpeg, .jpg and .svg extensions only"/>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Password</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col-sm-6 mb-2">
                <label class="mb-1">Confirm Password</label>
                <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-6">
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-warning text-white" OnClick="btnRegister_Click"/>
                <asp:LinkButton ID="btnHome" runat="server" CssClass="btn btn-danger" OnClick="btnHome_Click"><i class="fa-solid fa-house"></i> Home</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

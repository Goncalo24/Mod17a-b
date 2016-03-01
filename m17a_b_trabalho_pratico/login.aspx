<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="m17a_b_trabalho_pratico.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="background-color: #C0C0C0; opacity: 0.9" >
        <br />
        <asp:Label ID="Label" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtpass" runat="server" TextMode="password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblerro" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" class="btn btn-primary"/>
        <br />
        <br />
    </div>
</asp:Content>

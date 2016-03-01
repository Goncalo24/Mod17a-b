<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="vendascliente.aspx.cs" Inherits="m17a_b_trabalho_pratico.vendascliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="table">
        </asp:GridView>
        <br />
    </div>
</asp:Content>

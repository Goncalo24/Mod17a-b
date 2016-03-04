<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="m17a_b_trabalho_pratico.Comprar" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        Quantidade disponivel: <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        Quantidade que pretende adequirir: <asp:TextBox ID="txtquantidade" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btncomprar" runat="server" Text="Comprar" OnClick="btncomprar_Click" />
        <br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <br />
    </div>
</asp:Content>

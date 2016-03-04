<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="removerprodutos.aspx.cs" Inherits="m17a_b_trabalho_pratico.removerprodutos" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <br />
        <asp:Label ID="lbId" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbDesc" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbPreco" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbQuant" runat="server" Text=""></asp:Label>
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Remover" CssClass="btn btn-danger" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click"/>
        <br />
        <br />
    </div>
</asp:Content>

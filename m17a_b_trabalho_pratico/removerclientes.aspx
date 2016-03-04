<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="removerclientes.aspx.cs" Inherits="m17a_b_trabalho_pratico.removerclientes" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <br />
        <asp:Label ID="lbId" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbMorada" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbCP" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbData" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbPass" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbTipo" runat="server" Text=""></asp:Label><br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Remover" CssClass="btn btn-danger" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click"/>
        <br />
        <br />
    </div>
</asp:Content>

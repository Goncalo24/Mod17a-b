<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="editarcategoria.aspx.cs" Inherits="m17a_b_trabalho_pratico.editarcategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Categoria: "></asp:Label> <asp:TextBox ID="txtcat" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Atualizar" CssClass="btn btn-danger" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click"/>
        <br />
        <br />
    </div>
</asp:Content>

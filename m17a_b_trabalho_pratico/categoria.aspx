<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="categoria.aspx.cs" Inherits="m17a_b_trabalho_pratico.categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="background-color: #C0C0C0; opacity: 0.9" aria-busy="False">
        <br />
        <div class="table col-sm-4">
             <asp:GridView ID="GridView1" runat="server" CssClass="table active">
             </asp:GridView>
        </div>
        <br />
        Adicionar categoria: <asp:TextBox ID="tbCategoria" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Adicionar" class="btn btn-primary" OnClick="Button1_Click"/>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>

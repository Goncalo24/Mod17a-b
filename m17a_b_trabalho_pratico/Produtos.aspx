<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="m17a_b_trabalho_pratico.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Class="table">
        </asp:GridView>
        <br />
        <br />
        <div class="container2 text-center" style="background-color: #C0C0C0">
            Nome: <asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
            <br />
            Descrição: <asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
            <br />
            Categoria: <asp:DropDownList ID="ddlCat" runat="server" DataValueField="Categoria">
            </asp:DropDownList>
            <br />
            Quantidade: <asp:TextBox ID="tbQuant" runat="server"></asp:TextBox>
            <br />
            Preço: <asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="center-block" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Adicionar" OnClick="Button1_Click" class="btn btn-primary"/>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
    </div>
</asp:Content>

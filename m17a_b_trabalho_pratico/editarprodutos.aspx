<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="editarprodutos.aspx.cs" Inherits="m17a_b_trabalho_pratico.editarprodutos" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <asp:Label ID="lbId" runat="server" Text=""></asp:Label>
        <br />
        Nome:<asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
        <br />
        Descrição:<asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
        <br />
        Categoria:<asp:TextBox ID="tbCat" runat="server"></asp:TextBox>
        <br />
        Preço:<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
        <br />
        Quantidade:<asp:TextBox ID="tbQuant" runat="server"></asp:TextBox>
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        Imagem: <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-file"/>
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Atualizar" CssClass="btn btn-danger" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click"/>
        <br />
        <br />
    </div>
</asp:Content>

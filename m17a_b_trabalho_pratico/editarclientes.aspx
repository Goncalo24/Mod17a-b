<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="editarclientes.aspx.cs" Inherits="m17a_b_trabalho_pratico.editarclientes" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label> <asp:TextBox ID="txtnome" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label> <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Morada: "></asp:Label> <asp:TextBox ID="txtmorada" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Código Postal: "></asp:Label> <asp:TextBox ID="txtcp" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Data Nascimento: "></asp:Label> <asp:TextBox ID="txtdata" runat="server" TextMode="Date" ></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Password: "></asp:Label> <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Confirmar Password: "></asp:Label> <asp:TextBox ID="txtpass2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Tipo de utilizador: "></asp:Label> <asp:TextBox ID="txttipo" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="">
        <br />
        <asp:Button ID="Button1" runat="server" Text="Atualizar" CssClass="btn btn-danger" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click"/>
        <br />
        <br />
    </div>
</asp:Content>

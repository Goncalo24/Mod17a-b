﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="removercategoria.aspx.cs" Inherits="m17a_b_trabalho_pratico.removercategoria" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <br />
        <asp:Label ID="lbId" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbCat" runat="server" Text=""></asp:Label><br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Remover" CssClass="btn btn-danger" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click"/>
        <br />
        <br />
    </div>
</asp:Content>

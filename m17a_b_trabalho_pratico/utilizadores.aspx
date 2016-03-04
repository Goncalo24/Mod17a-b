<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="utilizadores.aspx.cs" Inherits="m17a_b_trabalho_pratico.utilizadores" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color: #C0C0C0; opacity: 0.9">
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Class="table">
        </asp:GridView>
        <br />
        <br />
    </div>
</asp:Content>

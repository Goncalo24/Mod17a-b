<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="m17a_b_trabalho_pratico.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="background-color: #C0C0C0; opacity: 0.9">
         <h1 style="text-align:center;"> Bem Vindo! </h1>
         <br />
         <h5>Algumas Novidades</h5>
         <br />
         <asp:GridView ID="GridView1" runat="server" CssClass="table">
        </asp:GridView>
     </div>
</asp:Content>

<%@ Page Title="GamerStore" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="loja.aspx.cs" Inherits="m17a_b_trabalho_pratico.loja" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container" style="background-color: #C0C0C0; opacity: 0.9" aria-busy="False">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Procurar: "></asp:Label><asp:TextBox ID="txtPesquisa" runat="server" AutoPostBack="True" OnTextChanged="txtPesquisa_TextChanged" ViewStateMode="Enabled" CssClass="active"></asp:TextBox>
        &nbsp; Categorias: <asp:DropDownList ID="ddlpesquisa" runat="server" OnSelectedIndexChanged="ddlpesquisa_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <div class="table col-sm-4">
             <asp:GridView ID="GridView1" runat="server" CssClass="table active" AllowPaging="True" PageSize="3" OnPageIndexChanging="GridView1_PageIndexChanging">
                 <PagerStyle HorizontalAlign="Right" /> 
             </asp:GridView>
        </div>
    </div>
</asp:Content>

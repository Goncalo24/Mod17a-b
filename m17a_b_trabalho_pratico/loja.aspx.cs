using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class loja : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            atualizaGrelha();
            if (!IsPostBack)
            {
                ListItem primeiro = new ListItem("Selecione uma categoria", "-1");
                ddlpesquisa.Items.Add(primeiro);
                //Actulizar a lista de categorias
                DataTable categorias = bd.DevolveConsulta("SELECT Categoria FROM Categorias");
                if (categorias == null || categorias.Rows.Count == 0) return;
                foreach (DataRow linha in categorias.Rows)
                {
                    ListItem novo = new ListItem(linha[0].ToString(), linha[0].ToString());
                    ddlpesquisa.Items.Add(novo);
                }
            }
        }

        private void atualizaGrelha()
        {
            DataTable dados = bd.DevolveConsulta("SELECT * FROM produto");
            if (ddlpesquisa.SelectedIndex!=-1 && ddlpesquisa.SelectedValue!="-1")
            {
                string cat = Server.HtmlEncode(ddlpesquisa.SelectedItem.Text);
                dados = bd.DevolveConsulta("SELECT * FROM produto WHERE categoria = '" + cat + "'"); ;
            }
           
            //limpar grelha
            GridView1.Columns.Clear();

            if (dados == null) return;
            //adicionar coluna comprar
            DataColumn cComprar = new DataColumn();
            cComprar.ColumnName = "Comprar";
            cComprar.DataType = Type.GetType("System.String");
            dados.Columns.Add(cComprar);

            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "id";
            bfId.HeaderText = "ID";
            bfId.Visible = false;
            GridView1.Columns.Add(bfId);

            //imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/imagens/{0}.jpg";
            imagem.DataImageUrlField = "id";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //nome
            BoundField bfNome = new BoundField();
            bfNome.DataField = "nome";
            bfNome.HeaderText = "Nome";
            GridView1.Columns.Add(bfNome);

            //descrição
            BoundField bfDesc = new BoundField();
            bfDesc.DataField = "descricao";
            bfDesc.HeaderText = "Descrição";
            GridView1.Columns.Add(bfDesc);

            //preço
            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "preco";
            bfPreco.HeaderText = "Preço";
            GridView1.Columns.Add(bfPreco);

            //quantidade
            BoundField bfQuant = new BoundField();
            bfQuant.DataField = "quantidade";
            bfQuant.HeaderText = "Quantidade";
            GridView1.Columns.Add(bfQuant);

            //comprar
            HyperLinkField lnkcomprar = new HyperLinkField();
            lnkcomprar.HeaderText = "Comprar";
            lnkcomprar.DataTextField = "Comprar";
            lnkcomprar.Text = "Comprar";
            lnkcomprar.DataNavigateUrlFormatString = "Comprar.aspx?id={0}&preco={1}";
            lnkcomprar.DataNavigateUrlFields = new string[] { "id","preco" };
            GridView1.Columns.Add(lnkcomprar);

            //refresh da gridview
            GridView1.DataBind();
        }

        protected void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string txt = Server.HtmlEncode(txtPesquisa.Text);
            DataTable dados = bd.DevolveConsulta("SELECT * FROM produto WHERE nome LIKE '%" + txt + "%'");
            //limpar grelha
            GridView1.Columns.Clear();

            if (dados == null) return;
            //adicionar coluna comprar
            DataColumn cComprar = new DataColumn();
            cComprar.ColumnName = "Comprar";
            cComprar.DataType = Type.GetType("System.String");
            dados.Columns.Add(cComprar);

            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "id";
            bfId.HeaderText = "ID";
            bfId.Visible = false;
            GridView1.Columns.Add(bfId);

            //imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/imagens/{0}.jpg";
            imagem.DataImageUrlField = "id";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //nome
            BoundField bfNome = new BoundField();
            bfNome.DataField = "nome";
            bfNome.HeaderText = "Nome";
            GridView1.Columns.Add(bfNome);

            //descrição
            BoundField bfDesc = new BoundField();
            bfDesc.DataField = "descricao";
            bfDesc.HeaderText = "Descrição";
            GridView1.Columns.Add(bfDesc);

            //categoria
            BoundField bfCat = new BoundField();
            bfCat.DataField = "categoria";
            bfCat.HeaderText = "Categoria";
            GridView1.Columns.Add(bfCat);

            //preço
            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "preco";
            bfPreco.HeaderText = "Preço";
            GridView1.Columns.Add(bfPreco);

            //quantidade
            BoundField bfQuant = new BoundField();
            bfQuant.DataField = "quantidade";
            bfQuant.HeaderText = "Quantidade";
            GridView1.Columns.Add(bfQuant);

            //comprar
            HyperLinkField lnkcomprar = new HyperLinkField();
            lnkcomprar.HeaderText = "Comprar";
            lnkcomprar.DataTextField = "Comprar";
            lnkcomprar.Text = "Comprar";
            lnkcomprar.DataNavigateUrlFormatString = "Comprar.aspx?id={0}&preco={1}";
            lnkcomprar.DataNavigateUrlFields = new string[] { "id", "preco" };
            GridView1.Columns.Add(lnkcomprar);

            //refresh da gridview
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            atualizaGrelha();
        }

        protected void ddlpesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = Server.HtmlEncode(ddlpesquisa.SelectedItem.Text);
            DataTable dados = bd.DevolveConsulta("SELECT * FROM produto WHERE categoria = '" + cat + "'");

            GridView1.Columns.Clear();

            if (dados == null) return;
            //adicionar coluna comprar
            DataColumn cComprar = new DataColumn();
            cComprar.ColumnName = "Comprar";
            cComprar.DataType = Type.GetType("System.String");
            dados.Columns.Add(cComprar);

            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "id";
            bfId.HeaderText = "ID";
            bfId.Visible = false;
            GridView1.Columns.Add(bfId);

            //imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/imagens/{0}.jpg";
            imagem.DataImageUrlField = "id";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //nome
            BoundField bfNome = new BoundField();
            bfNome.DataField = "nome";
            bfNome.HeaderText = "Nome";
            GridView1.Columns.Add(bfNome);

            //descrição
            BoundField bfDesc = new BoundField();
            bfDesc.DataField = "descricao";
            bfDesc.HeaderText = "Descrição";
            GridView1.Columns.Add(bfDesc);

            //categoria
            BoundField bfCat = new BoundField();
            bfCat.DataField = "categoria";
            bfCat.HeaderText = "Categoria";
            GridView1.Columns.Add(bfCat);

            //preço
            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "preco";
            bfPreco.HeaderText = "Preço";
            GridView1.Columns.Add(bfPreco);

            //quantidade
            BoundField bfQuant = new BoundField();
            bfQuant.DataField = "quantidade";
            bfQuant.HeaderText = "Quantidade";
            GridView1.Columns.Add(bfQuant);

            //comprar
            HyperLinkField lnkcomprar = new HyperLinkField();
            lnkcomprar.HeaderText = "Comprar";
            lnkcomprar.DataTextField = "Comprar";
            lnkcomprar.Text = "Comprar";
            lnkcomprar.DataNavigateUrlFormatString = "Comprar.aspx?id={0}&preco={1}";
            lnkcomprar.DataNavigateUrlFields = new string[] { "id", "preco" };
            GridView1.Columns.Add(lnkcomprar);

            //refresh da gridview
            GridView1.DataBind();

            //Response.Write("SELECT * FROM produto WHERE categoria LIKE '%" + cat + "%'");
        }
    }
}
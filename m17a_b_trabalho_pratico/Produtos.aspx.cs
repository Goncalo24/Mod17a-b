using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class Produtos : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            atualizaGrelha();

            //Actulizar a lista de categorias
            DataTable categorias = bd.DevolveConsulta("SELECT * FROM Categorias");
            if (categorias == null || categorias.Rows.Count == 0) return;
            foreach (DataRow linha in categorias.Rows)
            {
                ListItem novo = new ListItem(linha[1].ToString(), linha[0].ToString());
                ddlCat.Items.Add(novo);
            }
        }


        private void atualizaGrelha()
        {
            DataTable dados = bd.DevolveConsulta("SELECT * FROM produto");
            //limpar grelha
            GridView1.Columns.Clear();

            if (dados == null) return;
            //adicionar coluna remover
            DataColumn cRemover = new DataColumn();
            cRemover.ColumnName = "Remover";
            cRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(cRemover);
            //adicionar coluna editar
            DataColumn cEditar = new DataColumn();
            cEditar.ColumnName = "Editar";
            cEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(cEditar);
            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/imagens/{0}.jpg";
            imagem.DataImageUrlField = "id";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "id";
            bfId.HeaderText = "ID";
            bfId.Visible = false;
            GridView1.Columns.Add(bfId);

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

            //editar
            HyperLinkField lnkEditar = new HyperLinkField();
            lnkEditar.HeaderText = "Editar";
            lnkEditar.DataTextField = "Editar";
            lnkEditar.Text = "Editar";
            lnkEditar.DataNavigateUrlFormatString = "editarprodutos.aspx?id={0}";
            lnkEditar.DataNavigateUrlFields = new string[] { "id" };
            GridView1.Columns.Add(lnkEditar);

            //remover
            HyperLinkField lnkRemover = new HyperLinkField();
            lnkRemover.HeaderText = "Remover";
            lnkRemover.DataTextField = "Remover";
            lnkRemover.Text = "Remover";
            lnkRemover.DataNavigateUrlFormatString = "removerprodutos.aspx?id={0}";
            lnkRemover.DataNavigateUrlFields = new string[] { "id" };
            GridView1.Columns.Add(lnkRemover);

            //refresh da gridview
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = Server.HtmlEncode(tbNome.Text);
                string desc = Server.HtmlEncode(tbDesc.Text);
                string cat = ddlCat.SelectedItem.Text;
                float quant = float.Parse(tbQuant.Text);
                decimal preco = Decimal.Parse(tbPreco.Text);
                //guarda na bd
                int id = bd.adicionarProduto(nome, desc, cat, quant, preco);
                //guardar a imagem
                if (FileUpload1.HasFile == true)
                {
                    if (FileUpload1.PostedFile.ContentLength > 0)
                    {
                        string caminho = Server.MapPath(@"~\imagens");
                        caminho += "\\" + id + ".jpg";
                        FileUpload1.SaveAs(caminho);
                    }
                }
            }
            catch (Exception erro)
            {
                Label1.Text = "Ocorreu o seguinte erro: " + erro.Message;
                return;
            }
            //atualiza grelha
            atualizaGrelha();
            //limpar form
        }
    }
}
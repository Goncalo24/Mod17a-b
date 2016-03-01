using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class vendasadmin : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            atualizaGrelha();
        }
        private void atualizaGrelha()
        {
            DataTable dados = bd.DevolveConsulta("SELECT Vendas.idProduto,(SELECT produto.nome FROM produto WHERE produto.id=Vendas.idProduto) AS produto, Vendas.valor_venda, Vendas.quantidade_venda,(SELECT Clientes.Nome FROM Clientes WHERE Clientes.idCliente=Vendas.idCliente) AS nome, Vendas.data FROM Vendas ORDER BY data ASC");
            //limpar grelha
            GridView1.Columns.Clear();

            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "idProduto";
            bfId.HeaderText = "ID";
            bfId.Visible = false;
            GridView1.Columns.Add(bfId);

            //imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/imagens/{0}.jpg";
            imagem.DataImageUrlField = "idProduto";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //descrição
            BoundField bfproduto = new BoundField();
            bfproduto.DataField = "produto";
            bfproduto.HeaderText = "Produto";
            GridView1.Columns.Add(bfproduto);

            //preço
            BoundField bfPreco = new BoundField();
            bfPreco.DataField = "valor_venda";
            bfPreco.HeaderText = "Valor da venda";
            GridView1.Columns.Add(bfPreco);

            //quantidade
            BoundField bfQuant = new BoundField();
            bfQuant.DataField = "quantidade_venda";
            bfQuant.HeaderText = "Quantidade da venda";
            GridView1.Columns.Add(bfQuant);

            //nome
            BoundField bfNome= new BoundField();
            bfNome.DataField = Server.HtmlDecode("nome");
            bfNome.HeaderText = "Nome Cliente";
            GridView1.Columns.Add(bfNome);

            //data
            BoundField bfdata = new BoundField();
            bfdata.DataField = "data";
            bfdata.HeaderText = "Data";
            GridView1.Columns.Add(bfdata);

            //refresh da gridview
            GridView1.DataBind();
        }
    }
}
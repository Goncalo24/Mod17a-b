using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class vendascliente : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();
        int idCliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                string stridCliente = (string)Session["id"];
                idCliente = int.Parse(stridCliente);
                atualizaGrelha();
            }
        }
        private void atualizaGrelha()
        {
            DataTable dados = bd.DevolveConsulta("SELECT Vendas.idProduto,(SELECT produto.descricao FROM produto WHERE produto.id=Vendas.idProduto) AS produto, Vendas.valor_venda, Vendas.quantidade_venda, Vendas.data FROM Vendas WHERE idCliente= "+ idCliente);
            //limpar grelha
            GridView1.Columns.Clear();

            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
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
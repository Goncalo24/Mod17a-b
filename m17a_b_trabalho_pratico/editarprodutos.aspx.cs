using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace m17a_b_trabalho_pratico
{
    public partial class editarprodutos : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //validar dados dor webform
            string strid = Request["id"].ToString();
            int id = int.Parse(strid);
            string nome = tbNome.Text;
            string descricao = tbDesc.Text;
            string categoria = tbCat.Text;
            decimal preco = decimal.Parse(tbPreco.Text);
            float quantidade = float.Parse(tbQuant.Text);
            //atualizar bd
            bd.atualizarProduto(id, nome, descricao, categoria, quantidade, preco);
            //atualizar imagem
            if (FileUpload1.HasFile == true)
            {
                if (FileUpload1.PostedFile.ContentLength > 0)
                {
                    string caminho = Server.MapPath(@"~\imagens");
                    caminho += "\\" + id + ".jpg";
                    FileUpload1.SaveAs(caminho);
                }
            }
            //voltar
            Response.Redirect("Produtos.aspx");
        }
        //voltar
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produtos.aspx");
        }
    }
}
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
            try
            {
                //validar dados dor webform
                string strid = Server.HtmlEncode(Request["id"].ToString());
                int id = int.Parse(strid);
                string nome = Server.HtmlEncode(tbNome.Text);
                string descricao = Server.HtmlEncode(tbDesc.Text);
                string categoria = Server.HtmlEncode(tbCat.Text);
                decimal preco = decimal.Parse(Server.HtmlEncode(tbPreco.Text));
                float quantidade = float.Parse(Server.HtmlEncode(tbQuant.Text));
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
            catch (Exception erro)
            {
                Label1.Text = "Erro: " + erro.Message;
            }
            
        }

        //voltar
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produtos.aspx");
        }
    }
}
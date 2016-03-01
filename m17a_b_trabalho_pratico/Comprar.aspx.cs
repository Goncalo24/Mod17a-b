using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class Comprar : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    string strid = Request["id"].ToString();
                    int id = int.Parse(strid);

                    //atualizar quantidade produto
                    DataTable produtos = bd.DevolveConsulta("SELECT quantidade FROM produto WHERE id=" + id);
                    if (produtos == null || produtos.Rows.Count == 0) return;
                    foreach (DataRow linha in produtos.Rows)
                    {
                        string novo = linha[0].ToString();
                        Label1.Text = novo;
                    }
                }
            }
        }

        protected void btncomprar_Click(object sender, EventArgs e)
        {
            string strid = Request["id"].ToString();
            int idProduto = int.Parse(strid);
            string stridCliente = (string)Session["id"];
            int idCliente = int.Parse(stridCliente);
            float quantidade = float.Parse(txtquantidade.Text);
            string strpreco = Request["preco"].ToString();
            decimal preco = decimal.Parse(strpreco) * decimal.Parse(quantidade.ToString()); ;
            DateTime data = DateTime.Now;

            bd.adicionarVenda(idCliente, idProduto, preco, quantidade, data);
            Response.Redirect("loja.aspx");
        }
    }
}
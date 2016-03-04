using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace m17a_b_trabalho_pratico
{
    public partial class editarclientes : System.Web.UI.Page
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
                string strid = Server.HtmlEncode(Request["idcliente"].ToString());
                int id = int.Parse(strid);
                string nome = Server.HtmlEncode(txtnome.Text);
                string email = Server.HtmlEncode(txtemail.Text);
                string morada = Server.HtmlEncode(txtmorada.Text);
                string cp = Server.HtmlEncode(txtcp.Text);
                DateTime data = DateTime.Parse(txtdata.Text);
                string pass;
                int tipo = int.Parse(Server.HtmlEncode(txttipo.Text));

                //confirmar se as duas passwords são iguais
                if (txtpass.Text != txtpass2.Text)
                {
                    Response.Write("<script>alert('As palavras passe não são iguais!');</script>");
                    return;
                }
                else
                {
                    pass = Server.HtmlEncode(txtpass.Text);
                }

                //atualizar bd
                bd.atualizarCliente(id, nome, email, morada, cp, data, pass, tipo);

                //voltar
                Response.Redirect("utilizadores.aspx");
            }
            catch (Exception erro)
            {
                Label9.Text = "Erro: " + erro.Message;
            }
            
        }
        //voltar
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("utilizadores.aspx");
        }
    }
}
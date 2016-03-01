using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace m17a_b_trabalho_pratico
{
    public partial class registo : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistar_Click(object sender, EventArgs e)
        {
            string pass;

            //confirmar se as duas passwords são iguais
            if (txtpass.Text != txtpass2.Text)
            {
                Response.Write("<script>alert('As palavras passe não são iguais!');</script>");
                return;
            }
            else
            {
                pass = txtpass.Text;
            }

            try
            {
                string nome = Server.HtmlEncode(txtnome.Text);
                string email = Server.HtmlEncode(txtemail.Text);
                string morada = Server.HtmlEncode(txtmorada.Text);
                string cp = Server.HtmlEncode(txtcp.Text);
                DateTime data = DateTime.Parse(txtdata.Text);
                string passc = pass;
                
                //guardar dados na bd
                bd.AdicionaClientes(nome, email, morada, cp, data, passc);
                Response.Redirect("index.aspx");
            }
            catch (Exception erro)
            {
                //Response.Write("<script>alert("+erro.Message+");</script>");
                Label1.Text = "Ocorreu o seguinte erro: " + erro.Message;
                return;
            }
        }
    }
}
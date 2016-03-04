using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class login : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Server.HtmlEncode(txtemail.Text);
                string pass = txtpass.Text;
                DataTable cliente = bd.login(email, pass);
                if (cliente == null)
                {
                    lblerro.Text = "Login falhou. Tente novamente.";
                    return;
                }
                //login com sucesso
                Session["id"] = cliente.Rows[0][0].ToString();
                Session["nome"] = cliente.Rows[0][1].ToString();
                Session["tipo"] = cliente.Rows[0][7].ToString();
                Response.Redirect("index.aspx");
            }
            catch (Exception erro)
            {
                lblerro.Text = erro.Message;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class editarcategoria : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //validar dados dor webform
                string strid = Server.HtmlEncode(Request["id"].ToString());
                int id = int.Parse(strid);
                string cat = Server.HtmlEncode(txtcat.Text);

                //atualizar bd
                bd.atualizarCategoria(id, cat);

                //voltar
                Response.Redirect("categoria.aspx");
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        //voltar
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("categoria.aspx");
        }
    }
}
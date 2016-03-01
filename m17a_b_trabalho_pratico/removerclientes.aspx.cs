using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class removerclientes : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strid = Request["id"].ToString();
                    int id = int.Parse(strid);
                    DataTable cliente = bd.devolveCliente(id);
                    if (cliente == null || cliente.Rows.Count == 0)
                    {
                        Response.Redirect("utilizadores.aspx");
                        return;
                    }
                    lbId.Text = "Id: " + cliente.Rows[0][0].ToString();
                    lbNome.Text = "Nome: " + cliente.Rows[0][1].ToString();
                    lbEmail.Text = "Email: " + cliente.Rows[0][2].ToString();
                    lbMorada.Text = "Morada: " + cliente.Rows[0][3].ToString();
                    lbCP.Text = "Código Postal: " + cliente.Rows[0][4].ToString();
                    lbData.Text = "Data Nascimento: " + cliente.Rows[0][5].ToString();
                    lbPass.Text = "Password: " + cliente.Rows[0][6].ToString();
                    lbTipo.Text = "Tipo de utilizador: " + cliente.Rows[0][7].ToString();
                }
                catch (Exception erro)
                {
                    Response.Redirect("utilizadores.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strid = Request["id"].ToString();
            int id = int.Parse(strid);
            bd.removerCliente(id);
            Response.Redirect("utilizadores.aspx");
        }
        //cancelar
        protected void Button2_Click(object sender, EventArgs e)
        {
            //redirecionar para página produtos
            Response.Redirect("utilizadores.aspx");
        }
    }
}
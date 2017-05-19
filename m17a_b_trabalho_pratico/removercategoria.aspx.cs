using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class removercategoria : System.Web.UI.Page
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
                    try
                    {
                        string strid = Request["id"].ToString();
                        int id = int.Parse(strid);
                        DataTable cat = bd.devolveCategoria(id);
                        if (cat == null || cat.Rows.Count == 0)
                        {
                            Response.Redirect("categoria.aspx");
                            return;
                        }
                        lbId.Text = "Id: " + cat.Rows[0][0].ToString();
                        lbCat.Text = "Nome: " + cat.Rows[0][1].ToString();
                    }
                    catch (Exception erro)
                    {
                        Response.Redirect("categoria.aspx");
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strid = Request["id"].ToString();
            int id = int.Parse(strid);
            bd.removerCategoria(id);
            Response.Redirect("categoria.aspx");
        }
        //cancelar
        protected void Button2_Click(object sender, EventArgs e)
        {
            //redirecionar para página produtos
            Response.Redirect("categoria.aspx");
        }
    }
}
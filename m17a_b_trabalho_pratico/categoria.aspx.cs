using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class categoria : System.Web.UI.Page
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
                atualizaGrelha();
            }
        }

        private void atualizaGrelha()
        {
            DataTable dados = bd.DevolveConsulta("SELECT * FROM categorias");
            //limpar grelha
            GridView1.Columns.Clear();

            if (dados == null) return;
            //adicionar coluna remover
            DataColumn cRemover = new DataColumn();
            cRemover.ColumnName = "Remover";
            cRemover.DataType = Type.GetType("System.String");
            dados.Columns.Add(cRemover);
            //adicionar coluna editar
            DataColumn cEditar = new DataColumn();
            cEditar.ColumnName = "Editar";
            cEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(cEditar);
            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "idcliente";
            bfId.HeaderText = "ID";
            bfId.Visible = false;
            GridView1.Columns.Add(bfId);

            //nome
            BoundField bfnome = new BoundField();
            bfnome.DataField = "categoria";
            bfnome.HeaderText = "Categoria";
            GridView1.Columns.Add(bfnome);

            //editar
            HyperLinkField lnkEditar = new HyperLinkField();
            lnkEditar.HeaderText = "Editar";
            lnkEditar.DataTextField = "Editar";
            lnkEditar.Text = "Editar";
            lnkEditar.DataNavigateUrlFormatString = "editarcategoria.aspx?id={0}";
            lnkEditar.DataNavigateUrlFields = new string[] { "idCategoria" };
            GridView1.Columns.Add(lnkEditar);

            //remover
            HyperLinkField lnkRemover = new HyperLinkField();
            lnkRemover.HeaderText = "Remover";
            lnkRemover.DataTextField = "Remover";
            lnkRemover.Text = "Remover";
            lnkRemover.DataNavigateUrlFormatString = "removercategoria.aspx?id={0}";
            lnkRemover.DataNavigateUrlFields = new string[] { "idCategoria" };
            GridView1.Columns.Add(lnkRemover);

            //refresh da gridview
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cat =Server.HtmlEncode(tbCategoria.Text);
                bd.AdicionaCategoria(cat);
            }
            catch (Exception erro)
            {
                Label1.Text = "Ocorreu o seguinte erro: " + erro.Message;
                return;
            }
            //atualiza grelha
            atualizaGrelha();
        }
    }
}
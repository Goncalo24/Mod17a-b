using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class utilizadores : System.Web.UI.Page
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
            DataTable dados = bd.DevolveConsulta("SELECT idCliente, nome, email, morada, cp, data_nascimento, tipo FROM Clientes");
            //limpar grelha
            GridView1.Columns.Clear();

            if (dados == null) return;

            foreach (DataRow linha in dados.Rows)
            {
                linha[1] = Server.HtmlDecode(linha[1].ToString());
            }
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
            bfnome.DataField = "nome";
            bfnome.HeaderText = "Nome";
            GridView1.Columns.Add(bfnome);

            //email
            BoundField bfemail = new BoundField();
            bfemail.DataField = "email";
            bfemail.HeaderText = "Email";
            GridView1.Columns.Add(bfemail);

            //morada
            BoundField bfmorada = new BoundField();
            bfmorada.DataField = "morada";
            bfmorada.HeaderText = "Morada";
            GridView1.Columns.Add(bfmorada);

            //cp
            BoundField bfcp = new BoundField();
            bfcp.DataField = "cp";
            bfcp.HeaderText = "Código Postal";
            GridView1.Columns.Add(bfcp);

            //data
            BoundField bfdata = new BoundField();
            bfdata.DataField = "data_nascimento";
            bfdata.HeaderText = "Data Nascimento";
            GridView1.Columns.Add(bfdata);

            //data
            BoundField bftipo = new BoundField();
            bftipo.DataField = "tipo";
            bftipo.HeaderText = "Tipo Utilizador";
            GridView1.Columns.Add(bftipo);

            //editar
            HyperLinkField lnkEditar = new HyperLinkField();
            lnkEditar.HeaderText = "Editar";
            lnkEditar.DataTextField = "Editar";
            lnkEditar.Text = "Editar";
            lnkEditar.DataNavigateUrlFormatString = "editarclientes.aspx?id={0}";
            lnkEditar.DataNavigateUrlFields = new string[] { "idcliente" };
            GridView1.Columns.Add(lnkEditar);

            //remover
            HyperLinkField lnkRemover = new HyperLinkField();
            lnkRemover.HeaderText = "Remover";
            lnkRemover.DataTextField = "Remover";
            lnkRemover.Text = "Remover";
            lnkRemover.DataNavigateUrlFormatString = "removerclientes.aspx?id={0}";
            lnkRemover.DataNavigateUrlFields = new string[] { "idcliente" };
            GridView1.Columns.Add(lnkRemover);

            //refresh da gridview
            GridView1.DataBind();
        }
    }
}
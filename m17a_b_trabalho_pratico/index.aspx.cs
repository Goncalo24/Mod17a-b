using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public partial class index : System.Web.UI.Page
    {
        BaseDados bd = new BaseDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            atualizaGrelha();
        }

        private void atualizaGrelha()
        {
            DataTable dados = bd.DevolveConsulta("SELECT TOP 5 * FROM produto ORDER BY id DESC");
            //limpar grelha
            GridView1.Columns.Clear();

            if (dados == null) return;

            foreach (DataRow linha in dados.Rows)
            {
                linha[2] = Server.HtmlDecode(linha[2].ToString());
            }

            //adicionar coluna ver
            DataColumn cVer = new DataColumn();
            cVer.ColumnName = "ver";
            cVer.DataType = Type.GetType("System.String");
            dados.Columns.Add(cVer);

            //associar datatable
            GridView1.DataSource = dados;
            GridView1.AutoGenerateColumns = false;

            //definir colunas
            //id
            BoundField bfId = new BoundField();
            bfId.DataField = "id";
            bfId.HeaderText = "ID";
            bfId.Visible = false;
            GridView1.Columns.Add(bfId);

            //imagem
            ImageField imagem = new ImageField();
            imagem.DataImageUrlFormatString = "~/Imagens/{0}.jpg";
            imagem.DataImageUrlField = "id";
            imagem.HeaderText = "Imagem";
            imagem.ControlStyle.Width = 100;
            GridView1.Columns.Add(imagem);

            //nome
            BoundField bfNome = new BoundField();
            bfNome.DataField = "nome";
            bfNome.HeaderText = "Nome";
            GridView1.Columns.Add(bfNome);

            //descrição
            BoundField bfDesc = new BoundField();
            bfDesc.DataField = "descricao";
            bfDesc.HeaderText = "Descrição";
            GridView1.Columns.Add(bfDesc);

            //comprar
            HyperLinkField lnkcomprar = new HyperLinkField();
            lnkcomprar.HeaderText = "Ver";
            lnkcomprar.DataTextField = "ver";
            lnkcomprar.Text = "Ver";
            lnkcomprar.DataNavigateUrlFormatString = "loja.aspx";
            lnkcomprar.DataNavigateUrlFields = new string[] { "id", "preco" };
            GridView1.Columns.Add(lnkcomprar);

            //refresh da gridview
            GridView1.DataBind();
        }
    }
}
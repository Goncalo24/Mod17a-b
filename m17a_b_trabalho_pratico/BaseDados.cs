using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//sqlserver
using System.Data.SqlClient;
//configuração
using System.Configuration;
//datatable
using System.Data;

namespace m17a_b_trabalho_pratico
{
    public class BaseDados
    {
        string strligacao;
        SqlConnection ligacaoBD;

        //construtor
        public BaseDados()
        {
            strligacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            ligacaoBD = new SqlConnection(strligacao);
            try
            {
                ligacaoBD.Open();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
            }
        }
        //destrutor
        ~BaseDados()
        {
            try
            {
                ligacaoBD.Close();
                ligacaoBD.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
            }
        }

        #region consultas/comandos
        public DataTable DevolveConsulta(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            DataTable registos = new DataTable();

            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;
        }
        public DataTable DevolveConsulta(string sql, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            DataTable registos = new DataTable();

            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;
        }
        public DataTable devolvepesquisa(string descricao)
        {
            string strSQL = "SELECT * FROM produto WHERE descricao LIKE @desc";
            SqlCommand comando = new SqlCommand(strSQL, ligacaoBD);
            comando.Parameters.AddWithValue("@desc", (string)"%" + descricao + "%");
            DataTable registos = new DataTable();
            SqlDataReader jogador = comando.ExecuteReader();
            registos.Load(jogador);
            return registos;
        }
        public bool executaComando(string sql)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
        public bool ExecutaComando(string sql, List<SqlParameter> parametros)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                comando.Parameters.AddRange(parametros.ToArray());
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception erro)
            {
                Console.Write(erro.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region Clientes
        public DataTable devolveCliente(int id)
        {
            string sql = "SELECT * FROM Clientes WHERE idCliente=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };

            return DevolveConsulta(sql, parametros);
        }

        public void AdicionaClientes(string nome, string email, string morada, string cp, DateTime data, string pass)
        {
            string sql = "INSERT INTO Clientes(nome, email, morada, cp, data_nascimento, password) VALUES ";
            sql += "(@nome, @email, @morada, @cp, @data, cast(HASHBYTES('SHA1',@pass) as varchar));";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@email",SqlDbType=System.Data.SqlDbType.VarChar,Value= email},
                new SqlParameter() {ParameterName="@morada",SqlDbType=System.Data.SqlDbType.VarChar,Value= morada},
                new SqlParameter() {ParameterName="@cp",SqlDbType=System.Data.SqlDbType.VarChar,Value= cp},
                new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value= data},
                new SqlParameter() {ParameterName="@pass",SqlDbType=System.Data.SqlDbType.VarChar,Value= pass}
            };
            ExecutaComando(sql, parametros);
        }

        public void atualizarCliente(int id, string nome, string email, string morada, string cp, DateTime data, string pass, int tipo)
        {
            string sql = "UPDATE clientes SET nome=@nome,email=@email,morada=@morada,cp=@cp,";
            sql += "data_nascimento=@data,password=@pass, tipo=@tipo WHERE id=@id;";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@morada",SqlDbType=System.Data.SqlDbType.VarChar,Value= morada},
                new SqlParameter() {ParameterName="@cp",SqlDbType=System.Data.SqlDbType.VarChar,Value= cp},
                new SqlParameter() {ParameterName="@data",SqlDbType=System.Data.SqlDbType.Date,Value= data},
                new SqlParameter() {ParameterName="@email",SqlDbType=System.Data.SqlDbType.VarChar,Value= email},
                new SqlParameter() {ParameterName="@pass",SqlDbType=System.Data.SqlDbType.VarChar,Value= pass},
                new SqlParameter() {ParameterName="@tipo",SqlDbType=System.Data.SqlDbType.VarChar,Value= tipo},
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            ExecutaComando(sql, parametros);
        }

        public bool removerCliente(int id)
        {
            string sql = "DELETE FROM Clientes WHERE idCliente=@id ";

            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            return ExecutaComando(sql, parametros);
        }

        public DataTable login(string email, string pass)
        {
            string sql = "SELECT * FROM Clientes WHERE email=@email AND ";
            sql += " password=cast(HASHBYTES('SHA1',@pass) as varchar)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value= email},
                new SqlParameter() {ParameterName="@pass",SqlDbType=SqlDbType.VarChar,Value= pass}
            };
            DataTable cliente = DevolveConsulta(sql, parametros);
            if (cliente == null || cliente.Rows.Count == 0)
            {
                return null;
            }
            return cliente;
        }
        #endregion

        #region produtos
        public DataTable devolveProduto(int id)
        {
            string sql = "SELECT * FROM Produto WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };

            return DevolveConsulta(sql, parametros);
        }
        public int adicionarProduto(string nome, string descricao, string categoria, float quantidade, decimal preco)
        {
            string sql = "INSERT INTO produto(nome,descricao,categoria,preco,quantidade) VALUES ";
            sql += "(@nome,@descricao,@cat,@preco,@quantidade);SELECT CAST(scope_identity() as int)";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@descricao",SqlDbType=System.Data.SqlDbType.VarChar,Value= descricao},
                new SqlParameter() {ParameterName="@cat",SqlDbType=System.Data.SqlDbType.VarChar,Value= categoria},
                new SqlParameter() {ParameterName="@preco",SqlDbType=System.Data.SqlDbType.Float,Value= preco},
                new SqlParameter() {ParameterName="@quantidade",SqlDbType=System.Data.SqlDbType.Decimal,Value= quantidade}
            };
            //executaComando(sql, parametros);
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddRange(parametros.ToArray());
            int id = (int)comando.ExecuteScalar();
            comando.Dispose();
            return id;
        }
        public void atualizarProduto(int id, string nome, string descricao, string categoria, float quantidade, decimal preco)
        {
            string sql = "UPDATE produto SET nome=@nome, descricao=@descricao, categoria=@cat, preco=@preco, ";
            sql += " quantidade=@quantidade WHERE id=@id";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=System.Data.SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@descricao",SqlDbType=System.Data.SqlDbType.VarChar,Value= descricao},
                new SqlParameter() {ParameterName="@cat",SqlDbType=System.Data.SqlDbType.VarChar,Value= categoria},
                new SqlParameter() {ParameterName="@quantidade",SqlDbType=System.Data.SqlDbType.Float,Value= quantidade},
                new SqlParameter() {ParameterName="@preco",SqlDbType=System.Data.SqlDbType.Decimal,Value= preco},
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            ExecutaComando(sql, parametros);

            return;
        }
        public void removerProduto(int id)
        {
            string sql = "DELETE FROM produto WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };

            ExecutaComando(sql, parametros);
            return;
        }
        #endregion

        #region vendas
        public void adicionarVenda(int idcliente, int idproduto, decimal preco, float quantidade, DateTime data)
        {
            //iniciar transação
            string sql = "";
            SqlTransaction transacao = ligacaoBD.BeginTransaction();
            try
            {
                //registar venda
                sql = "INSERT INTO Vendas(idcliente,idproduto,valor_venda,quantidade_venda,data) ";
                sql += " VALUES (@idCliente,@idProduto,@preco,@quantidade,@data);";
                SqlCommand comando = new SqlCommand(sql, ligacaoBD);
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@idCliente",SqlDbType=SqlDbType.Int,Value= idcliente},
                    new SqlParameter() {ParameterName="@idProduto",SqlDbType=SqlDbType.Int,Value= idproduto},
                    new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value= preco},
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Float,Value= quantidade},
                    new SqlParameter() {ParameterName="@data",SqlDbType=SqlDbType.Date,Value= data}
                };
                comando.Parameters.AddRange(parametros.ToArray());
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
                comando.Dispose();

                //atualizar quantidade produto
                sql = "UPDATE produto SET quantidade=quantidade-@quantidade WHERE id=@id";
                comando = new SqlCommand(sql, ligacaoBD);
                parametros.Clear();
                parametros = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@quantidade",SqlDbType=SqlDbType.Float,Value= quantidade},
                    new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= idproduto}
                };
                comando.Parameters.AddRange(parametros.ToArray());
                comando.Transaction = transacao;
                comando.ExecuteNonQuery();
                comando.Dispose();

                //terminar commit
                transacao.Commit();
            }
            catch (Exception erro)
            {
                transacao.Rollback();
            }
        }
        #endregion

        #region categoria
        public DataTable devolveCategoria(int id)
        {
            string sql = "SELECT * FROM Categorias WHERE idCategoria=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };

            return DevolveConsulta(sql, parametros);
        }
        public void AdicionaCategoria(string categoria)
        {
            string sql = "INSERT INTO Categorias(Categoria) VALUES(@cat);";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@cat",SqlDbType=System.Data.SqlDbType.VarChar,Value= categoria}
            };
            ExecutaComando(sql, parametros);
        }

        public void atualizarCategoria(int id, string categoria)
        {
            string sql = "UPDATE Categorias SET categoria=@cat WHERE idCategoria=@id;";
            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@cat",SqlDbType=System.Data.SqlDbType.VarChar,Value= categoria},
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            ExecutaComando(sql, parametros);
        }

        public bool removerCategoria(int id)
        {
            string sql = "DELETE FROM Categorias WHERE idCategoria=@id ";

            //parâmetros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=System.Data.SqlDbType.Int,Value= id}
            };
            return ExecutaComando(sql, parametros);
        }
        #endregion
    }
}
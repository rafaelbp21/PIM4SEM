using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Login.DAL
{
    internal class LoginDAO
    {
        public bool tem = false;
        public string mensagem = "";
        public bool active = false;
        NpgsqlCommand cmd = new NpgsqlCommand();
        Conexao con = new Conexao();
        NpgsqlDataReader dr;

        #region Verificar Login
        public (bool, string, bool) verificarLogin(string usuario, string senha)
        {
            
            //procurar no banco esse login e senha
            cmd.CommandText = "SELECT * FROM public.\"Usuario\" WHERE email=@usuario AND senha=@senha";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);
            string access_level = "";
            
            
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                dr.Read();
                
                if (dr.HasRows) //se foi encontrado
                {
                    access_level = dr.GetString(4);
                    active = dr.GetBoolean(5);
                    tem = true;
                }
                con.desconectar();
                dr.Close();

            }

            catch (NpgsqlException)
            {
                this.mensagem = "Erro com Banco de Dados!";
            }
            return (tem, access_level, active);

        }
        #endregion

        #region Cadastrar Usuário
        public string cadastrar(string email, string nome, string senha, string acesso, bool active)
        {
            tem = false;
            //comandos para inserir
            cmd.CommandText = "INSERT INTO public.\"Usuario\" (email, senha, nome_de_usuario, nivel_de_acesso, ativo) VALUES (@email, @senha, @nome, @acesso, @active)";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@acesso", acesso);
            cmd.Parameters.AddWithValue("@active", active);
            try
            {
                cmd.Connection=con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Usuário cadastrado com sucesso!";
                tem = true;
            }
            catch(NpgsqlException)
            {
                this.mensagem = "Erro com banco de dados";
            }
            return mensagem;
        }
        #endregion

        #region Método Listar Usuários
        public DataTable ListarUser()
        {
            cmd.CommandText = "SELECT * from public.\"Usuario\"";
            cmd.Connection = con.conectar();
            cmd.ExecuteNonQuery();
            DataTable tabelaUser = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(tabelaUser);
            con.desconectar();
            return tabelaUser;
        }


        #endregion

        #region Alterar Usuário

        public string alterar (string email, string nome, string senha, string acesso, int id, bool active)
        {
            tem = false;
            //comandos para inserir
            cmd.CommandText = "UPDATE public.\"Usuario\" set email=@email, senha=@senha, nome_de_usuario=@nome, nivel_de_acesso=@acesso, ativo=@active where usuario_id=@user_id";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@acesso", acesso);
            cmd.Parameters.AddWithValue("@user_id", id);
            cmd.Parameters.AddWithValue("@active", active);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Usuário alterado com sucesso!";
                tem = true;
            }
            catch (NpgsqlException)
            {
                this.mensagem = "Erro com banco de dados";
            }
            return mensagem;
        }

        #endregion

        #region Excluir Usuário
        public string excluir(int id)
        {
            tem = false;
            //comandos para inserir
            cmd.CommandText = "DELETE from public.\"Usuario\" where user_id=@user_id";
            cmd.Parameters.AddWithValue("@user_id", id);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Usuário excluído com sucesso!";
                tem = true;
            }
            catch (NpgsqlException)
            {
                this.mensagem = "Erro com banco de dados";
            }
            return mensagem;
        }
        #endregion


    }
}

using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Login.DAL
{
    internal class FuncionarioDAO
    {
        public bool tem = false;
        public string mensagem = "";
        public bool active = false;
        NpgsqlCommand cmd = new NpgsqlCommand();
        Conexao con = new Conexao();
        private static string nome;
        public static string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        #region Cadastrar Funcionario
        public string cadastrar(string nome, string codigo, string cargo, bool active, string cpf, string log, int numero, string bairro, string cep, string munic, string uf, string pais, string tel, string email, decimal salario, DateTime nasc, DateTime adm)
        {
            tem = false;
            //comandos para inserir
            cmd.CommandText = "INSERT INTO public.\"Funcionario\" (nome, codigo_de_acesso, cargo, ativo, cpf, lagradouro, numero, bairro, cep, municipio, uf, pais, telefone, email, salario_bruto, data_nascimento, data_admissao) VALUES (@nome, @codigo, @cargo, @active, @cpf, @log, @n, @bairro, @cep, @munic, @uf, @pais, @tel, @email, @salario, @nasc, @admissao)";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@log", log);
            cmd.Parameters.AddWithValue("@n", numero);
            cmd.Parameters.AddWithValue("@bairro", bairro);
            cmd.Parameters.AddWithValue("@cep", cep);
            cmd.Parameters.AddWithValue("@munic", munic);
            cmd.Parameters.AddWithValue("@uf", uf);
            cmd.Parameters.AddWithValue("@pais", pais);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@salario", salario);
            cmd.Parameters.AddWithValue("@nasc", nasc);
            cmd.Parameters.AddWithValue("@admissao", adm);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Funcionário cadastrado com sucesso!";
                tem = true;
            }
            catch (NpgsqlException)
            {
                this.mensagem = "Erro com banco de dados";
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return mensagem;
        }
        #endregion

        #region Alterar Funcionario
        public string alterar(string nome, string codigo, string cargo, bool active, string cpf, string log, int numero, string bairro, string cep, string munic, string uf, string pais, string tel, string email, decimal salario, DateTime datenasc, DateTime dateadm, int id)
        {
            tem = false;
            //comandos para inserir
            cmd.CommandText = "UPDATE public.\"Funcionario\" set nome=@nome, codigo_de_acesso=@codigo, cargo=@cargo, ativo=@active, cpf=@cpf, lagradouro=@log, numero=@num, bairro=@bairro, cep=@cep, municipio=@munic, uf=@uf, pais=@pais, telefone=@tel, email=@email, salario_bruto=@salario, data_nascimento=@nasc, data_admissao=@adm where funcionario_id=@id";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@log", log);
            cmd.Parameters.AddWithValue("@num", numero);
            cmd.Parameters.AddWithValue("@bairro", bairro);
            cmd.Parameters.AddWithValue("@cep", cep);
            cmd.Parameters.AddWithValue("@munic", munic);
            cmd.Parameters.AddWithValue("@uf", uf);
            cmd.Parameters.AddWithValue("@pais", pais);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@salario", salario);
            cmd.Parameters.AddWithValue("@nasc", datenasc);
            cmd.Parameters.AddWithValue("@adm", dateadm);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Funcionário alterado com sucesso!";
                tem = true;
            }
            catch (NpgsqlException)
            {
                this.mensagem = "Erro com banco de dados ";
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return mensagem;
        }

        #endregion

        #region Método Listar Funcionários
        public DataTable ListarFunc()
        {
            cmd.CommandText = "SELECT * from public.\"Funcionario\"";
            cmd.Connection = con.conectar();
            cmd.ExecuteNonQuery();
            DataTable tabelaFunc = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(tabelaFunc);
            con.desconectar();
            return tabelaFunc;
        }


        #endregion

        #region Metodo Pesquisar

        public DataTable PesquisarFuncNome(string nome)
        {
            cmd.CommandText = "SELECT * from public.\"Funcionario\" where (@nome IS NULL OR nome like @nome || '%')";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", nome);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                DataTable tabelaFunc = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(tabelaFunc);
                con.desconectar();
                cmd.Dispose();
                return tabelaFunc;
            }
            catch (NpgsqlException)
            {
                this.mensagem = "Funcionário não encontrado!";
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return null;

        }

        public DataTable PesquisarFuncCargo(string cargo)
        {
            cmd.CommandText = "SELECT * from public.\"Funcionario\" where (@cargo IS NULL OR cargo like @cargo || '%')";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cargo", cargo);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                DataTable tabelaFunc = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(tabelaFunc);
                con.desconectar();
                return tabelaFunc;

            }
            catch (NpgsqlException)
            {
                this.mensagem = "Funcionário não encontrado!";
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return null;

        }

        #endregion


    }
}

using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Login.DAL
{
    internal class FolhaDAO
    {
        public bool tem = false;
        public string mensagem = "";
        public bool active = false;
        NpgsqlCommand cmd = new NpgsqlCommand();
        Conexao con = new Conexao();
        private static string ano_mes;
        private static string nome;
        public static int id;
        public static string Ano_mes
        {
            get { return ano_mes; }
            set { ano_mes = value; }
        }
        public static string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public static int Id
        {
            get { return id; }
            set { id = value; }
        }
        #region Cadastrar Folha
        public string cadastrar(int id, string mes, decimal salario, decimal bc_inss, decimal bc_irrf, decimal inss, decimal irrf, decimal acres, decimal descontos, decimal salario_base, decimal faltas, int dias_faltas)
        {
            try
            {
                con.conectar();

                // Verificar se já existe um registro com o mesmo funcionario_id e mes_de_referencia
                string consulta = "SELECT * FROM public.\"Holerite\" WHERE funcionario_id = @id AND mes_de_referencia = @mes";
                NpgsqlCommand cmdConsulta = new NpgsqlCommand(consulta, con.conectar());
                cmdConsulta.Parameters.AddWithValue("@id", id);
                cmdConsulta.Parameters.AddWithValue("@mes", mes);

                NpgsqlDataReader dr = cmdConsulta.ExecuteReader();

                if (dr.HasRows)
                {
                    // Já existe um registro para esse funcionário e mês
                    this.mensagem = "Folha já lançada para o período informado para este funcionário!";
                }
                else
                {
                    // Não existe registro, inserir na tabela
                    string insert = "INSERT INTO public.\"Holerite\" (funcionario_id, mes_de_referencia, salario_liquido, base_de_calculo_inss, base_de_calculo_irrf, desconto_inss, desconto_irrf, outros_acrescimos, outros_descontos, salario_base, desconto_faltas, n_faltas) VALUES (@fk, @mes, @salario, @bcinss, @bcirrf, @inss, @irrf, @acres, @desc, @salb, @faltas, @nfaltas)";
                    NpgsqlCommand cmdInsert = new NpgsqlCommand(insert, con.conectar());
                    cmdInsert.Parameters.AddWithValue("@fk", id);
                    cmdInsert.Parameters.AddWithValue("@mes", mes);
                    cmdInsert.Parameters.AddWithValue("@salario", salario);
                    cmdInsert.Parameters.AddWithValue("@bcinss", bc_inss);
                    cmdInsert.Parameters.AddWithValue("@bcirrf", bc_irrf);
                    cmdInsert.Parameters.AddWithValue("@inss", inss);
                    cmdInsert.Parameters.AddWithValue("@irrf", irrf);
                    cmdInsert.Parameters.AddWithValue("@acres", acres);
                    cmdInsert.Parameters.AddWithValue("@desc", descontos);
                    cmdInsert.Parameters.AddWithValue("@salb", salario_base);
                    cmdInsert.Parameters.AddWithValue("@faltas", faltas);
                    cmdInsert.Parameters.AddWithValue("@nfaltas", dias_faltas);

                    dr.Close(); // fechar o data reader antes de executar o próximo comando
                    con.desconectar(); // fechar a conexão antes de executar o próximo comando

                    con.conectar(); // abrir a conexão novamente para executar o próximo comando
                    int reg = cmdInsert.ExecuteNonQuery();

                    if (reg == 1)
                    {
                        mensagem = "Folha cadastrada com sucesso!";
                    }
                }

                dr.Close();
            }
            catch (NpgsqlException ex)
            {
                this.mensagem = "Erro com banco de dados: " + ex.Message;
            }
            finally
            {
                con.desconectar();
            }

            return mensagem;
        
    }


        #endregion

        #region Alterar Folha
        public string alterar(int id, string mes, decimal salario, decimal bc_inss, decimal bc_irrf, decimal inss, decimal irrf, decimal acres, decimal descontos, decimal salario_base, decimal faltas, int dias_faltas, int h_id)
        {
            
            cmd.CommandText = "UPDATE public.\"Holerite\" set funcionario_id=@fk, mes_de_referencia=@mes, salario_liquido=@salario, base_de_calculo_inss=@bcinss, base_de_calculo_irrf=@bcirrf, desconto_inss=@inss, desconto_irrf=@irrf, outros_acrescimos=@acresc, outros_descontos=@desc, salario_base=@salb, desconto_faltas=@faltas, n_faltas=@nfaltas where holerite_id=@hid";
            cmd.Parameters.AddWithValue("@fk", id);
            cmd.Parameters.AddWithValue("@mes", mes);
            cmd.Parameters.AddWithValue("@salario", salario);
            cmd.Parameters.AddWithValue("@bcinss", bc_inss);
            cmd.Parameters.AddWithValue("@bcirrf", bc_irrf);
            cmd.Parameters.AddWithValue("@inss", inss);
            cmd.Parameters.AddWithValue("@irrf", irrf);
            cmd.Parameters.AddWithValue("@acresc", acres);
            cmd.Parameters.AddWithValue("@desc", descontos);
            cmd.Parameters.AddWithValue("@salb", salario_base);
            cmd.Parameters.AddWithValue("@faltas", faltas);
            cmd.Parameters.AddWithValue("@nfaltas", dias_faltas);
            cmd.Parameters.AddWithValue("@hid", h_id);
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Folha alterada com sucesso!";
                tem = true;
            }
            catch (NpgsqlException)
            {
                this.mensagem = "Erro com banco de dados ";
            }
            return mensagem;

        }

        #endregion

        #region Método Listar Funcionários Ativos
        public DataTable ListarFuncAtivos()
        {
            cmd.CommandText = "SELECT * from public.\"Funcionario\" where ativo = true";
            cmd.Connection = con.conectar();
            cmd.ExecuteNonQuery();
            DataTable tabelaFunc = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(tabelaFunc);
            con.desconectar();
            return tabelaFunc;
        }


        #endregion

        #region Pesquisar Folha
        public DataTable pesquisar_nome(string nome)
        {
            try 
            { 
                tem = false;
                cmd.CommandText = "SELECT h.*, f.nome, f.cargo, f.codigo_de_acesso from public.\"Holerite\" h INNER JOIN public.\"Funcionario\" f on h.funcionario_id = f.funcionario_id where f.nome like @nome";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                DataTable pesquisar = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(pesquisar);
                con.desconectar();
                return pesquisar;

             }
            catch (NpgsqlException ex)
            {
                throw new Exception("Erro com banco de dados", ex);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
           
        }
        #endregion

        #region Pesquisar Folha Ano_Mes
        public DataTable pesquisar_mesano(string mes_ano)
        {
            try
            {
                tem = false;
                cmd.CommandText = "SELECT h.*, f.nome, f.cargo, f.codigo_de_acesso from public.\"Holerite\" h INNER JOIN public.\"Funcionario\" f on h.funcionario_id = f.funcionario_id where h.mes_de_referencia like @mes_ano";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mes_ano", mes_ano);
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                DataTable pesquisar = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(pesquisar);
                con.desconectar();
                return pesquisar;
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Erro com banco de dados", ex);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }

        }

        #endregion

        #region Folha Id
        public DataTable pesquisar_ID(int id)
        {
            try
            {
                tem = false;
                cmd.CommandText = "SELECT h.*, f.nome, f.cargo, f.codigo_de_acesso from public.\"Holerite\" h INNER JOIN public.\"Funcionario\" f on h.funcionario_id = f.funcionario_id where h.holerite_id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                DataTable pesquisar = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(pesquisar);
                con.desconectar();
                return pesquisar;

            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Erro com banco de dados", ex);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }

        }

        #endregion

        #region Calculo INSS

        public decimal INSS(decimal salarioB)
        {
            decimal inss = 0.00m;
            if(salarioB <= 1301.99m)
            {
                inss = 0.00m;
            }
            else if (salarioB <= 1302.00m)
            {
                inss = salarioB * 0.075m;
            }
            else if (salarioB <= 2571.29m)
            {
                inss = (salarioB * 0.09m) - 19.53m;
            }
            else if (salarioB <= 3856.94m)
            {
                inss = (salarioB * 0.12m) - 96.67m;
            }
            else
            {
                inss = (salarioB * 0.14m) - 173.81m;
            }

            return inss;
        }

        #endregion

        #region Aliquota INSS
        public decimal AliquotaINSS(decimal salario)
        {
            if(salario <= 1301.99m)
            {
                return 0.00m;
            }
            else if (salario <= 1302.00m)
            {
                return 0.075m;
            }
            else if (salario <= 2571.29m)
            {
                return 0.09m;
            }
            else if (salario <= 3856.94m)
            {
                return 0.12m;
            }
            else
            {
                return 0.14m;
            }
        }

        #endregion

        #region Deducao INSS
        public decimal DeducaoINSS(decimal salario)
        {
            if (salario <= 1302.00m)
            {
                return 0.00m;
            }
            else if (salario <= 2571.29m)
            {
                return 19.53m;
            }
            else if (salario <= 3856.94m)
            {
                return 96.67m;
            }
            else
            {
                return 173.81m;
            }
        }

        #endregion

        #region Caculo IRRF
        public decimal IRRF(decimal salarioINSS)
        {
            decimal irrf = 0.00m;
            if(salarioINSS <= 2112.00m)
            {
                irrf = 0.00m;
            }
            else if (salarioINSS <= 2826.65m)
            {
                irrf = (salarioINSS * 0.075m) - 158.40m;
            }
            else if (salarioINSS <= 3751.05m)
            {
                irrf = (salarioINSS * 0.15m) - 370.40m;
            }
            else if (salarioINSS <= 4664.68m)
            {
                irrf = (salarioINSS * 0.225m) - 651.73m;
            }
            else
            {
                irrf = (salarioINSS * 0.275m) - 884.96m;
            }

            return irrf;
        }

        #endregion

        #region Aliquota IRRF
        public decimal AliquotaIRRF(decimal salarioINSS)
        {
            if(salarioINSS <= 2112.00m)
            {
                return 0.00m;
            }
            if (salarioINSS <= 2826.65m)
            {
                return 0.075m;
            }
            else if (salarioINSS <= 3751.05m)
            {
                return 0.15m;
            }
            else if (salarioINSS <= 4664.68m)
            {
                return 0.225m;
            }
            else
            {
                return 0.275m;
            }
        }

        #endregion

        #region Deducao IRRF
        public decimal DeducaoIRRF(decimal salarioINSS)
        {
            if (salarioINSS <= 2112.00m)
            {
                return 0.00m;
            }
            else if (salarioINSS <= 2826.65m)
            {
                return 158.40m;
            }
            else if (salarioINSS <= 3751.05m)
            {
                return 370.40m;
            }
            else if (salarioINSS <= 4664.68m)
            {
                return 651.73m;
            }
            else
            {
                return 884.96m;
            }
        }

        #endregion
    }
}

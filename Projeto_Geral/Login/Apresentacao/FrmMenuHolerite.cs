using Login.DAL;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Apresentacao
{
    public partial class FrmMenuHolerite : Form
    {
        NpgsqlCommand cmd = new NpgsqlCommand();
        Conexao con = new Conexao();
        public FrmMenuHolerite()
        {
            InitializeComponent();
            txbData.TextChanged += (sender, args) => DataSelecionada = txbData.Text;
            txbPin.TextChanged += (sender, args) => Pin = txbPin.Text;
            txbCpf.TextChanged += (sender, args) => Cpf = txbCpf.Text;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            string regexPatternData = @"^(0[1-9]|1[0-2])/[0-9]{4}$";
            string regexPatternCpf = @"^\d{3}\,\d{3}\,\d{3}-\d{2}$";
            bool isValidData = Regex.IsMatch(txbData.Text, regexPatternData);
            bool isValidCpf = Regex.IsMatch(txbCpf.Text, regexPatternCpf);
            if (!isValidData || !isValidCpf || string.IsNullOrWhiteSpace(txbPin.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente.", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                cmd.CommandText = @"SELECT COUNT(*) 
                    FROM public.""Funcionario"" f 
                    WHERE f.codigo_de_acesso = @pin 
                    AND f.cpf = @cpf";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pin", Pin);
                cmd.Parameters.AddWithValue("@cpf", Cpf);
                cmd.Connection = con.conectar();
                object resultadoConsulta = cmd.ExecuteScalar();
                int count = Convert.ToInt32(resultadoConsulta);
                if (count == 0)
                {
                    MessageBox.Show("Dados invalidos.", "Não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cmd.CommandText = @"SELECT COUNT(*) 
                    FROM public.""Holerite"" h 
                    INNER JOIN public.""Funcionario"" f 
                    ON h.funcionario_id = f.funcionario_id 
                    WHERE h.mes_de_referencia = @mes 
                    AND f.codigo_de_acesso = @pin 
                    AND f.cpf = @cpf";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mes", DataSelecionada);
                cmd.Parameters.AddWithValue("@pin", Pin);
                cmd.Parameters.AddWithValue("@cpf", Cpf);
                cmd.Connection = con.conectar();
                object resultado = cmd.ExecuteScalar();
                int linha = Convert.ToInt32(resultado);
                if (linha == 0)
                {
                    MessageBox.Show("Não há holerites disponíveis para o mês selecionado.", "Não disponível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (NpgsqlException ex)
            {
                throw new Exception("Erro com banco de dados", ex);
            }
            
            string dataSelecionada = txbData.Text;
            string pin = txbPin.Text;
            string cpf = txbCpf.Text;
            FrmMenuHoleriteFunc abrir = new FrmMenuHoleriteFunc(dataSelecionada, pin, cpf);
            abrir.Show();
        }
        public string DataSelecionada { get; private set; }
        public string Pin { get; private set; }
        public string Cpf { get; private set; }
    }
}

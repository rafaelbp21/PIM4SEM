using FontAwesome.Sharp;
using Login.DAL;
using Login.Modelo;
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
using System.Windows.Forms.VisualStyles;

namespace Login.Apresentacao
{
    public partial class FrmMenuFolha : Form
    {
        bool novo;
        public FrmMenuFolha()
        {
            InitializeComponent();
        }

        private void FrmMenuFolha_Load(object sender, EventArgs e)
        {
            FolhaDAO lista = new FolhaDAO();
            cmbFunc.DataSource = lista.ListarFuncAtivos();
            cmbFunc.DisplayMember = "nome";
            cmbFunc.ValueMember = "funcionario_id";
            cmbFunc.SelectedIndex = -1;
            txbCargo.Text = "";
            txbSalarioB.Text = "";
            decimal desconto = 0.00m;
            txbDescontos.Text = desconto.ToString("N2");
            txbAcrescimos.Text = desconto.ToString("N2");
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnPesquisar.Enabled = true;
            cmbFunc.Enabled = false;
            txbDias.Enabled = false;
            txbDescontos.Enabled = false;
            txbAcrescimos.Enabled = false;
            txbData.Enabled = false;

        }

        private void cmbFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFunc.SelectedIndex != -1)
            {
                DataRowView drw = cmbFunc.SelectedItem as DataRowView;
                if (drw != null)
                {
                    txbCargo.Text = drw["cargo"].ToString();
                    decimal salarioBruto = Convert.ToDecimal(drw["salario_bruto"]);
                    txbSalarioB.Text = salarioBruto.ToString("N2");
                }
            }


        }
        private void Limpadados()
        {
            txbCargo.Clear();
            txbSalarioB.Clear();
            txbDias.Clear();
            txbFaltas.Clear();
            txbSalarioBase.Clear();
            txbInss.Clear();
            txbIRRF.Clear();
            txbBcInss.Clear();
            txbBcIr.Clear();
            txbDedInss.Clear();
            txbDedIr.Clear();
            txbValorInss.Clear();
            txbValorIR.Clear();
            decimal desconto = 0.00m;
            txbDescontos.Text = desconto.ToString("N2");
            txbAcrescimos.Text = desconto.ToString("N2");
            txbHid.Clear();
            txbSalarioL.Clear();
            txbData.Clear();

        }

       

        private void txbDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '\b')
            {
                return;
            }

            // converter o valor atual do txbDias em um inteiro
            int currentValue = 0;
            int.TryParse(txbDias.Text + e.KeyChar, out currentValue);

            // permitir apenas valores entre 0 e 30
            if (currentValue < 0 || currentValue > 30)
            {
                e.Handled = true;
                return;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbDias.Text))
            {
                MessageBox.Show("Por favor, digite um valor válido para dias.", "Erro ao calcular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
      
            
            int dias = Convert.ToInt32(txbDias.Text);
            decimal salarioBase = Convert.ToDecimal(txbSalarioB.Text);
            decimal desconto_faltas = (salarioBase/30) * dias;
            txbFaltas.Text = desconto_faltas.ToString("N2");
            decimal salarioBruto = salarioBase - desconto_faltas;
            txbSalarioBase.Text = salarioBruto.ToString("N2");
            txbBcInss.Text = txbSalarioBase.Text;

            #region Aliquota INSS
            FolhaDAO folhaDAO = new FolhaDAO();
            if (decimal.TryParse(txbSalarioBase.Text, out decimal salario))
            {
                decimal valorAliquota = folhaDAO.AliquotaINSS(salario);
                txbInss.Text = valorAliquota.ToString("P");
            }
            else
            {
                txbInss.Clear();
            }
            #endregion

            #region Deducao INSS
            FolhaDAO DeducaoINSS = new FolhaDAO();
            if (decimal.TryParse(txbSalarioBase.Text, out decimal aliquota))
            {
                decimal DedINSS = DeducaoINSS.DeducaoINSS(aliquota);
                txbDedInss.Text = DedINSS.ToString();
            }
            else
            {
                txbDedInss.Clear();
            }
            #endregion

            #region Valor INSS
            FolhaDAO INSS = new FolhaDAO();
            if (decimal.TryParse(txbSalarioBase.Text, out decimal valorINSS))
            {
                decimal valor = INSS.INSS(valorINSS);
                txbValorInss.Text = valor.ToString("N2");
            }
            else
            {
                txbValorInss.Clear();
            }
            #endregion

            decimal valorsalario = Convert.ToDecimal(txbSalarioBase.Text);
            decimal inss = Convert.ToDecimal(txbValorInss.Text);
            decimal baseCalculo = valorsalario - inss;
            txbBcIr.Text = baseCalculo.ToString("N2");

            #region Valor IRRF
            FolhaDAO IRRF = new FolhaDAO();
            if (decimal.TryParse(txbBcIr.Text, out decimal valorIRRF))
            {
                decimal valor = IRRF.IRRF(valorIRRF);
                txbValorIR.Text = valor.ToString("N2");
            }
            else
            {
                txbValorIR.Clear();
            }
            #endregion

            #region Aliquota IRRF
            FolhaDAO aliquotaIRRF = new FolhaDAO();
            if (decimal.TryParse(txbBcIr.Text, out decimal aliquotaIR))
            {
                decimal valor = aliquotaIRRF.AliquotaIRRF(aliquotaIR);
                txbIRRF.Text = valor.ToString("P");
            }
            else
            {
                txbIRRF.Clear();
            }
            #endregion

            #region Deducao IRRF
            FolhaDAO DeducaoIRRF = new FolhaDAO();
            if (decimal.TryParse(txbBcIr.Text, out decimal deducao))
            {
                decimal DedIRRF = DeducaoIRRF.DeducaoIRRF(deducao);
                txbDedIr.Text = DedIRRF.ToString();
            }
            else
            {
                txbDedIr.Clear();
            }

            #endregion

            
            decimal descINSS = Convert.ToDecimal(txbValorInss.Text);
            decimal descIR = Convert.ToDecimal(txbValorIR.Text);
            decimal salarioB = Convert.ToDecimal(txbSalarioBase.Text);
            decimal outros_acres = Convert.ToDecimal(txbAcrescimos.Text);
            decimal outros_desc = outros_desc = Convert.ToDecimal(txbDescontos.Text);
            decimal descontos = descINSS + descIR + outros_desc;
            decimal acrescimos = outros_acres + salarioB;
            decimal salarioL = acrescimos - descontos;
            txbSalarioL.Text = salarioL.ToString("N2");
        }


        private void txbAcrescimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.DecNumber(sender, e);
        }


        private void txbAcrescimos_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbAcrescimos.Text))
            {
                MessageBox.Show("Digite um valor válido para Acrescimos. Formato aceito 0,00.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var num = Convert.ToDecimal(txbAcrescimos.Text);
            txbAcrescimos.Text = num.ToString("N2");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FolhaDAO.Id = -1;
            FrmMenuFolhaPesquisar abrir = new FrmMenuFolhaPesquisar();
            abrir.ShowDialog();
            if (FolhaDAO.Id == -1)
            {
                MessageBox.Show("Nenhum item selecionado.");
                return;
            }
            txbData.Text = FolhaDAO.Ano_mes;
            cmbFunc.Text = FolhaDAO.Nome;
            FolhaDAO pesquisar = new FolhaDAO();
            DataRow row = pesquisar.pesquisar_ID(FolhaDAO.Id).Rows[0];
            txbSalarioL.Text = row["salario_liquido"].ToString();
            txbDias.Text = row["n_faltas"].ToString();
            txbAcrescimos.Text = row["outros_acrescimos"].ToString();
            txbDescontos.Text = row["outros_descontos"].ToString();
            txbFaltas.Text = row["desconto_faltas"].ToString();
            txbHid.Text = row["holerite_id"].ToString();
            txbSalarioBase.Text = row["salario_base"].ToString();
            novo = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnPesquisar.Enabled = false;
            cmbFunc.Enabled = true;
            txbDias.Enabled = true;
            txbDescontos.Enabled = true;
            txbAcrescimos.Enabled = true;
            txbData.Enabled = true;
            

        }

        private void txbDescontos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.DecNumber(sender, e);
        }

        private void txbDescontos_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbDescontos.Text))
            {
                MessageBox.Show("Digite um valor válido para Descontos. Formato aceito 0,00.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var num = Convert.ToDecimal(txbDescontos.Text);
            txbDescontos.Text = num.ToString("N2");
        }

        

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnPesquisar.Enabled = false;
            cmbFunc.Enabled = true;
            txbDias.Enabled = true;
            txbDescontos.Enabled = true;
            txbAcrescimos.Enabled = true;
            txbData.Enabled = true;
            cmbFunc.Focus();
            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string regexPattern = @"^(0[1-9]|1[0-2])/[0-9]{4}$";
            bool isValid = Regex.IsMatch(txbData.Text, regexPattern);
            if (!isValid)
            {
                MessageBox.Show("Por favor, informe o período antes de continuar.", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txbBcInss.Text.Length == 0)
            {
                MessageBox.Show("Por favor, calcule a folha antes de continuar.", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (novo)
            {
                FolhaDAO gravar = new FolhaDAO();

                try
                {
                    int funcId = int.Parse(cmbFunc.SelectedValue.ToString());
                    string data = txbData.Text;
                    decimal salarioLiquido = decimal.Parse(txbSalarioL.Text);
                    decimal bcInss = decimal.Parse(txbBcInss.Text);
                    decimal bcIr = decimal.Parse(txbBcIr.Text);
                    decimal inss = decimal.Parse(txbValorInss.Text);
                    decimal irrf = decimal.Parse(txbValorIR.Text);
                    decimal acrescimos = decimal.Parse(txbAcrescimos.Text);
                    decimal descontos = decimal.Parse(txbDescontos.Text);
                    decimal salario_base = decimal.Parse(txbSalarioBase.Text);
                    int diasTrabalhados = int.Parse(txbDias.Text);
                    decimal faltas = decimal.Parse(txbFaltas.Text);

                    string mensagem = gravar.cadastrar(funcId, data, salarioLiquido, bcInss, bcIr, inss, irrf, acrescimos, descontos, salario_base, faltas, diasTrabalhados);

                    if (gravar.tem) //mensagem de sucesso
                    {
                        MessageBox.Show("Folha cadastrada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(gravar.mensagem); //mensagem de erro
                    }
                }
                catch (FormatException ex)
                {
                    // exibe a mensagem de erro
                    MessageBox.Show("Erro ao converter valor: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // exibe a mensagem de erro
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
            else
            {
                FolhaDAO alterar = new FolhaDAO();
                try
                {
                    int funcId = int.Parse(cmbFunc.SelectedValue.ToString());
                    string data = txbData.Text;
                    decimal salarioLiquido = decimal.Parse(txbSalarioL.Text);
                    decimal bcInss = decimal.Parse(txbBcInss.Text);
                    decimal bcIr = decimal.Parse(txbBcIr.Text);
                    decimal inss = decimal.Parse(txbValorInss.Text);
                    decimal irrf = decimal.Parse(txbValorIR.Text);
                    decimal acrescimos = decimal.Parse(txbAcrescimos.Text);
                    decimal descontos = decimal.Parse(txbDescontos.Text);
                    decimal salario_base = decimal.Parse(txbSalarioBase.Text);
                    int diasTrabalhados = int.Parse(txbDias.Text);
                    decimal faltas = decimal.Parse(txbFaltas.Text);
                    int h_id = int.Parse(txbHid.Text);

                    string mensagem = alterar.alterar(funcId, data, salarioLiquido, bcInss, bcIr, inss, irrf, acrescimos, descontos, salario_base, faltas, diasTrabalhados, h_id);

                    if (alterar.tem) //mensagem de sucesso
                    {
                        MessageBox.Show("Folha alterada com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(alterar.mensagem); //mensagem de erro
                    }
                }
                catch (FormatException ex)
                {
                    // exibe a mensagem de erro
                    MessageBox.Show("Erro ao converter valor: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // exibe a mensagem de erro
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnPesquisar.Enabled = true;
            cmbFunc.Enabled = false;
            txbDias.Enabled = false;
            txbDescontos.Enabled = false;
            txbAcrescimos.Enabled = false;
            txbData.Enabled = false;
            Limpadados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnPesquisar.Enabled = true;
            cmbFunc.Enabled = false;
            txbDias.Enabled = false;
            txbDescontos.Enabled = false;
            txbAcrescimos.Enabled = false;
            txbData.Enabled = false;
            Limpadados();
        }

    }
}

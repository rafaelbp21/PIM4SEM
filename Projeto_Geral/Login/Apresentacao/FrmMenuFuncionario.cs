using Login.DAL;
using Login.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Login.Apresentacao
{
    public partial class FrmMenuFuncionario : Form
    {
        bool novo;
        public FrmMenuFuncionario()
        {
            InitializeComponent();
        }

        private void FrmMenuFuncionario_Load(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnPesquisar.Enabled = true;
            txbNome.Enabled = false;
            txbPin.Enabled = false;
            txbCargo.Enabled = false;
            checkBox1.Enabled = false;
            txbCpf.Enabled = false;
            txbLoc.Enabled = false;
            txbNum.Enabled = false;
            txbBairro.Enabled = false;
            txbcep.Enabled = false;
            txbMun.Enabled = false;
            txbUF.Enabled = false;
            txbPais.Enabled = false;
            txbTel.Enabled = false;
            txbEmail.Enabled = false;
            txbID.Enabled = false;
            dateNasc.Enabled = false;
            dateAdm.Enabled = false;
            txbSalarioB.Enabled = false;
           
        }
        private void LimpaDados()
        {
            txbNome.Clear();
            txbPin.Clear();
            txbCargo.Clear();
            checkBox1.Checked = true;
            txbCpf.Clear();
            txbLoc.Clear();
            txbNum.Clear();
            txbBairro.Clear();
            txbcep.Clear();
            txbMun.Clear();
            txbUF.Clear();
            txbPais.Clear();
            txbTel.Clear();
            txbEmail.Clear();
            txbID.Clear();
            dateNasc.Value = new DateTime(1960, 01, 01);
            dateAdm.Value = new DateTime(2000, 01, 01);
            txbSalarioB.Clear();
            txbLoc.Focus();

        }

        private void txbPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.IntNumber(e);
        }

        private void txbSalarioB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.DecimalSal(e);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FuncionarioDAO.Nome = null;
            FrmMenuFuncionarioPesquisar abrir = new FrmMenuFuncionarioPesquisar();
            abrir.ShowDialog();
            if (string.IsNullOrEmpty(FuncionarioDAO.Nome))
            {
                MessageBox.Show("Nenhum item selecionado.");
                return;
            }
            txbNome.Text = FuncionarioDAO.Nome;
            FuncionarioDAO pesquisar = new FuncionarioDAO();
            DataRow row = pesquisar.PesquisarFuncNome(FuncionarioDAO.Nome).Rows[0];
            txbCargo.Text = row["cargo"].ToString();
            txbNome.Text = row["nome"].ToString();
            checkBox1.Checked = Convert.ToBoolean(row["ativo"]);
            txbCpf.Text = row["cpf"].ToString();
            txbID.Text = row["funcionario_id"].ToString();
            txbLoc.Text = row["lagradouro"].ToString();
            txbNum.Text = row["numero"].ToString();
            txbBairro.Text = row["bairro"].ToString();
            txbcep.Text = row["cep"].ToString();
            txbMun.Text = row["municipio"].ToString();
            txbUF.Text = row["uf"].ToString();
            txbPais.Text = row["pais"].ToString();
            txbTel.Text = row["telefone"].ToString();
            txbEmail.Text = row["email"].ToString();
            txbSalarioB.Text = row["salario_bruto"].ToString();
            dateNasc.Text = row["data_nascimento"].ToString();
            dateAdm.Text = row["data_admissao"].ToString();
            txbPin.Text = row["codigo_de_acesso"].ToString();
            novo = false;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnPesquisar.Enabled = false;
            txbNome.Enabled = true;
            txbPin.Enabled = true;
            txbCargo.Enabled = true;
            checkBox1.Enabled = true;
            txbCpf.Enabled = true;
            txbLoc.Enabled = true;
            txbNum.Enabled = true;
            txbBairro.Enabled = true;
            txbcep.Enabled = true;
            txbMun.Enabled = true;
            txbUF.Enabled = true;
            txbPais.Enabled = true;
            txbTel.Enabled = true;
            txbEmail.Enabled = true;
            txbID.Enabled = true;
            dateNasc.Enabled = true;
            dateAdm.Enabled = true;
            txbSalarioB.Enabled = true;

        }

        private void txbSalarioB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbSalarioB.Text))
            {
                MessageBox.Show("Digite um valor válido para Salário. Formato aceito 0,00.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var num = Convert.ToDecimal(txbSalarioB.Text);
            txbSalarioB.Text = num.ToString("N2");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnPesquisar.Enabled = true;
            txbNome.Enabled = false;
            txbPin.Enabled = false;
            txbCargo.Enabled = false;
            checkBox1.Enabled = false;
            txbCpf.Enabled = false;
            txbLoc.Enabled = false;
            txbNum.Enabled = false;
            txbBairro.Enabled = false;
            txbcep.Enabled = false;
            txbMun.Enabled = false;
            txbUF.Enabled = false;
            txbPais.Enabled = false;
            txbTel.Enabled = false;
            txbEmail.Enabled = false;
            txbID.Enabled = false;
            dateNasc.Enabled = false;
            dateAdm.Enabled = false;
            txbSalarioB.Enabled = false;
            LimpaDados();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnPesquisar.Enabled = false;
            txbNome.Enabled = true;
            txbPin.Enabled = true;
            txbCargo.Enabled = true;
            checkBox1.Enabled = true;
            txbCpf.Enabled = true;
            txbLoc.Enabled = true;
            txbNum.Enabled = true;
            txbBairro.Enabled = true;
            txbcep.Enabled = true;
            txbMun.Enabled = true;
            txbUF.Enabled = true;
            txbPais.Enabled = true;
            txbTel.Enabled = true;
            txbEmail.Enabled = true;
            txbID.Enabled = true;
            dateNasc.Enabled = true;
            dateAdm.Enabled = true;
            txbSalarioB.Enabled = true;
            txbNome.Focus();
            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                if (txbNome.Text.Length > 0 && txbPin.Text.Length > 0 && txbCargo.Text.Length > 0 && txbCpf.Text.Length > 0 && txbLoc.Text.Length > 0 && txbNum.Text.Length > 0 && txbBairro.Text.Length > 0 && txbcep.Text.Length > 0 && txbMun.Text.Length > 0 && txbUF.Text.Length > 0 && txbPais.Text.Length > 0 && txbTel.Text.Length > 0 && txbEmail.Text.Length > 0 && txbSalarioB.Text.Length > 0)
                {
                    FuncionarioDAO controle = new FuncionarioDAO();

                    string mensagem = controle.cadastrar(txbNome.Text.ToUpper(), txbPin.Text, txbCargo.Text.ToUpper(), checkBox1.Checked, txbCpf.Text, txbLoc.Text.ToUpper(), int.Parse(txbNum.Text), txbBairro.Text.ToUpper(), txbcep.Text, txbMun.Text.ToUpper(), txbUF.Text, txbPais.Text.ToUpper(), txbTel.Text, txbEmail.Text.ToUpper(), decimal.Parse(txbSalarioB.Text), dateNasc.Value, dateAdm.Value);
                    if (controle.tem) //mensagem de sucesso
                    {
                        MessageBox.Show(mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(controle.mensagem); //mensagem de erro
                    }
                    LimpaDados();
                }
                else
                {
                    MessageBox.Show("Por favor, preencha todos os campos antes de continuar.", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (txbNome.Text.Length > 0 && txbPin.Text.Length > 0 && txbCargo.Text.Length > 0 && txbCpf.Text.Length > 0 && txbLoc.Text.Length > 0 && txbNum.Text.Length > 0 && txbBairro.Text.Length > 0 && txbcep.Text.Length > 0 && txbMun.Text.Length > 0 && txbUF.Text.Length > 0 && txbPais.Text.Length > 0 && txbTel.Text.Length > 0 && txbEmail.Text.Length > 0 && txbSalarioB.Text.Length > 0)
                {
                    FuncionarioDAO alterar = new FuncionarioDAO();
                    int id;
                    if (int.TryParse(txbID.Text, out id))
                    {
                        string mensagem = alterar.alterar(txbNome.Text.ToUpper(), txbPin.Text, txbCargo.Text.ToUpper(), checkBox1.Checked, txbCpf.Text, txbLoc.Text.ToUpper(), int.Parse(txbNum.Text), txbBairro.Text.ToUpper(), txbcep.Text, txbMun.Text.ToUpper(), txbUF.Text, txbPais.Text.ToUpper(), txbTel.Text, txbEmail.Text.ToUpper(), decimal.Parse(txbSalarioB.Text), dateNasc.Value, dateAdm.Value, id);
                        if (alterar.tem)
                        {
                            MessageBox.Show(mensagem, "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(alterar.mensagem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O ID precisa ser um número inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LimpaDados();
                }
                else
                {
                    MessageBox.Show("Por favor, preencha todos os campos antes de continuar.", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnPesquisar.Enabled = true;
            txbNome.Enabled = false;
            txbPin.Enabled = false;
            txbCargo.Enabled = false;
            checkBox1.Enabled = false;
            txbCpf.Enabled = false;
            txbLoc.Enabled = false;
            txbNum.Enabled = false;
            txbBairro.Enabled = false;
            txbcep.Enabled = false;
            txbMun.Enabled = false;
            txbUF.Enabled = false;
            txbPais.Enabled = false;
            txbTel.Enabled = false;
            txbEmail.Enabled = false;
            txbID.Enabled = false;
            dateNasc.Enabled = false;
            dateAdm.Enabled = false;
            txbSalarioB.Enabled = false;
            LimpaDados();
        }
    }
}

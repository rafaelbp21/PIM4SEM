using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Login.Modelo;
using Login.DAL;
using Npgsql;

namespace Login.Apresentacao
{
    public partial class FrmMenuCadastrar : Form
    {
        bool novo;
        public FrmMenuCadastrar()
        {
            InitializeComponent();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            txbNome.Enabled = false;
            txbSenha.Enabled = false;
            txbUsuario.Enabled = false;
            txbID.Enabled = false;
            cbAcesso.Enabled = false;
            checkBox1.Enabled = false;
            dgUser.Enabled = false;
            dgUser.Visible = false;
            

        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            LoginDAO listar = new LoginDAO();
            dgUser.DataSource = listar.ListarUser();
            cabecalho();
            txbNome.Focus();

        }

        private void LimpaDados()
        {
            txbUsuario.Clear();
            txbNome.Clear();
            txbSenha.Clear();
            cbAcesso.SelectedValue = null;
            txbID.Clear();
            checkBox1.Checked = true;
            txbNome.Focus();

        }
        private void cabecalho()
        {
            dgUser.Columns[0].HeaderText = "ID";
            dgUser.Columns[0].Width = 60;
            dgUser.Columns[1].HeaderText = "Nome do Usuário";
            dgUser.Columns[1].Width = 150;
            dgUser.Columns[2].HeaderText = "E-mail";
            dgUser.Columns[2].Width = 150;
            dgUser.Columns[3].HeaderText = "Senha";
            dgUser.Columns[3].Width = 90;
            dgUser.Columns[4].HeaderText = "Nivel de Acesso";
            dgUser.Columns[4].Width = 150;
            dgUser.Columns[5].HeaderText = "Situação";
            dgUser.Columns[5].Width = 90;
        }

        private void dgUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbNome.Text = dgUser.CurrentRow.Cells[1].Value.ToString();
            txbUsuario.Text = dgUser.CurrentRow.Cells[2].Value.ToString();
            txbSenha.Text = dgUser.CurrentRow.Cells[3].Value.ToString();
            cbAcesso.Text = dgUser.CurrentRow.Cells[4].Value.ToString();
            txbID.Text = dgUser.CurrentRow.Cells[0].Value.ToString();
            checkBox1.Checked = (bool)dgUser.CurrentRow.Cells[5].Value;
            novo = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            txbID.Enabled = true;
            dgUser.Enabled = true;
            dgUser.Visible = true;
            txbNome.Enabled = true;
            txbSenha.Enabled = true;
            txbUsuario.Enabled = true;
            cbAcesso.Enabled = true;
            checkBox1.Enabled = true;
            txbNome.Focus();
            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                if (txbUsuario.Text.Length > 0 && txbNome.Text.Length > 0 && txbSenha.Text.Length > 0 && cbAcesso.Text.Length > 0)
                {
                    Controle controle = new Controle();
                    string mensagem = controle.cadastrar(txbUsuario.Text.ToUpper(), txbNome.Text.ToUpper(), txbSenha.Text, cbAcesso.Text, checkBox1.Checked);
                    if (controle.tem.Item1) //mensagem de sucesso
                    {
                        MessageBox.Show(mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginDAO listar = new LoginDAO();
                        dgUser.DataSource = listar.ListarUser();
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
                cabecalho();
            }
            else
            {
                Controle controle = new Controle();
                int id;
                if (txbUsuario.Text.Length > 0 && txbNome.Text.Length > 0 && txbSenha.Text.Length > 0 && cbAcesso.Text.Length > 0)
                {
                    if (int.TryParse(txbID.Text, out id))
                    {
                        string mensagem = controle.alterar(txbUsuario.Text.ToUpper(), txbNome.Text.ToUpper(), txbSenha.Text, cbAcesso.Text, id, checkBox1.Checked);
                        if (controle.tem.Item1) //mensagem de sucesso
                        {
                            MessageBox.Show(mensagem, "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoginDAO listar = new LoginDAO();
                            dgUser.DataSource = listar.ListarUser();
                        }
                        else
                        {
                            MessageBox.Show(controle.mensagem); //mensagem de erro
                        }
                    }
                    LimpaDados();
                }
                else
                {
                    MessageBox.Show("Por favor, preencha todos os campos antes de continuar.", "Campos vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                cabecalho();
          
            }
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            txbID.Enabled = false;
            txbNome.Enabled = false;
            txbSenha.Enabled = false;
            txbUsuario.Enabled = false;
            cbAcesso.Enabled = false;
            checkBox1.Enabled = false;
            dgUser.Enabled = false;
            dgUser.Visible = false;
            LimpaDados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            txbID.Enabled = false;
            txbNome.Enabled = false;
            txbSenha.Enabled = false;
            txbUsuario.Enabled = false;
            cbAcesso.Enabled = false;
            checkBox1.Enabled = false;
            dgUser.Enabled = false;
            dgUser.Visible = false;
            LimpaDados();
        }
    }
}

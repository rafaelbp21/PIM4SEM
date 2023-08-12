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
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Login.Apresentacao
{
    public partial class FrmMenuFuncionarioPesquisar : Form
    {
        public FrmMenuFuncionarioPesquisar()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rbNome.Checked)
            {
                FuncionarioDAO nome = new FuncionarioDAO();
                dgPesquisar.DataSource = nome.PesquisarFuncNome(txbPesquisa.Text.ToUpper());
                txbPesquisa.Clear();
            }

            if (rbCargo.Checked)
            {
                FuncionarioDAO nome = new FuncionarioDAO();
                dgPesquisar.DataSource = nome.PesquisarFuncCargo(txbPesquisa.Text.ToUpper());
                txbPesquisa.Clear();
            }
            cabecalho();
        }

        private void cabecalho()
        {
            dgPesquisar.Columns[0].HeaderText = "ID";
            dgPesquisar.Columns[0].Width = 60;
            dgPesquisar.Columns[1].HeaderText = "Nome";
            dgPesquisar.Columns[1].Width = 150;
            dgPesquisar.Columns[2].HeaderText = "PIN";
            dgPesquisar.Columns[2].Width = 60;
            dgPesquisar.Columns[3].HeaderText = "Cargo";
            dgPesquisar.Columns[3].Width = 90;
            dgPesquisar.Columns[4].HeaderText = "Situação";
            dgPesquisar.Columns[4].Width = 90;
            dgPesquisar.Columns[5].HeaderText = "CPF";
            dgPesquisar.Columns[5].Width = 90;
            dgPesquisar.Columns[6].HeaderText = "Endereço";
            dgPesquisar.Columns[6].Width = 90;
            dgPesquisar.Columns[7].HeaderText = "Número";
            dgPesquisar.Columns[7].Width = 60;
            dgPesquisar.Columns[8].HeaderText = "Bairro";
            dgPesquisar.Columns[8].Width = 90;
            dgPesquisar.Columns[9].HeaderText = "CEP";
            dgPesquisar.Columns[9].Width = 90;
            dgPesquisar.Columns[10].HeaderText = "Cidade";
            dgPesquisar.Columns[10].Width = 90;
            dgPesquisar.Columns[11].HeaderText = "UF";
            dgPesquisar.Columns[11].Width = 60;
            dgPesquisar.Columns[12].HeaderText = "País";
            dgPesquisar.Columns[12].Width = 90;
            dgPesquisar.Columns[13].HeaderText = "Telefone";
            dgPesquisar.Columns[13].Width = 90;
            dgPesquisar.Columns[14].HeaderText = "E-mail";
            dgPesquisar.Columns[14].Width = 90;
            dgPesquisar.Columns[15].HeaderText = "Criado em";
            dgPesquisar.Columns[15].Width = 90;
            dgPesquisar.Columns[16].HeaderText = "Dt.Admissão";
            dgPesquisar.Columns[16].Width = 90;
            dgPesquisar.Columns[17].HeaderText = "Salário Bruto";
            dgPesquisar.Columns[17].Width = 90;
            dgPesquisar.Columns["salario_bruto"].DefaultCellStyle.Format = "c2";

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPesquisar_DoubleClick(object sender, EventArgs e)
        {
            FuncionarioDAO.Nome = dgPesquisar.CurrentRow.Cells[1].Value.ToString();
            this.Close();
        }
    }
}

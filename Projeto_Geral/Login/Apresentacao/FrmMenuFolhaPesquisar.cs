using Login.DAL;
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
    public partial class FrmMenuFolhaPesquisar : Form
    {
        public FrmMenuFolhaPesquisar()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FrmMenuFolhaPesquisar_Load(object sender, EventArgs e)
        {
            FolhaDAO lista = new FolhaDAO();
            cmbFunc.DataSource = lista.ListarFuncAtivos();
            cmbFunc.DisplayMember = "nome";
            cmbFunc.ValueMember = "funcionario_id";
            cmbFunc.SelectedIndex = -1;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cabecalho()
        {
            dgvFolha.Columns[1].Visible = false;
            dgvFolha.Columns[0].HeaderText = "ID";
            dgvFolha.Columns[0].Width = 50;
            dgvFolha.Columns[2].HeaderText = "Mes/Ano";
            dgvFolha.Columns[2].Width = 80;
            dgvFolha.Columns[3].HeaderText = "Sal. Liquido";
            dgvFolha.Columns[3].Width = 90;
            dgvFolha.Columns[3].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[4].HeaderText = "BC IRRF";
            dgvFolha.Columns[4].Width = 90;
            dgvFolha.Columns[4].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[5].HeaderText = "BC INSS";
            dgvFolha.Columns[5].Width = 90;
            dgvFolha.Columns[5].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[6].HeaderText = "Vl. INSS";
            dgvFolha.Columns[6].Width = 90;
            dgvFolha.Columns[6].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[7].HeaderText = "Vl. IRRF";
            dgvFolha.Columns[7].Width = 90;
            dgvFolha.Columns[7].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[8].HeaderText = "Acresc.";
            dgvFolha.Columns[8].Width = 90;
            dgvFolha.Columns[8].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[9].HeaderText = "Descontos";
            dgvFolha.Columns[9].Width = 90;
            dgvFolha.Columns[9].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[10].Visible = false;
            dgvFolha.Columns[11].HeaderText = "Desc. Faltas";
            dgvFolha.Columns[11].Width = 90;
            dgvFolha.Columns[11].DefaultCellStyle.Format = "c2";
            dgvFolha.Columns[12].HeaderText = "Faltas";
            dgvFolha.Columns[12].Width = 60;
            dgvFolha.Columns[13].HeaderText = "Nome";
            dgvFolha.Columns[13].Width = 150;
            dgvFolha.Columns[14].HeaderText = "Cargo";
            dgvFolha.Columns[14].Width = 90;
            dgvFolha.Columns[15].HeaderText = "PIN";
            dgvFolha.Columns[15].Width = 60;
        }
        private void dgvFolha_DoubleClick(object sender, EventArgs e)
        {
            FolhaDAO.Ano_mes = dgvFolha.CurrentRow.Cells[2].Value.ToString();
            FolhaDAO.Id = Convert.ToInt32(dgvFolha.CurrentRow.Cells[0].Value);
            FolhaDAO.Nome = dgvFolha.CurrentRow.Cells[13].Value.ToString();
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rbMesAno.Checked)
            {
                FolhaDAO mes_ano = new FolhaDAO();
                dgvFolha.DataSource = mes_ano.pesquisar_mesano(txbData.Text);
            }

            if (rbFuncionario.Checked)
            {
                FolhaDAO nome = new FolhaDAO();
                dgvFolha.DataSource = nome.pesquisar_nome(cmbFunc.Text);
            }
            cabecalho();
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}

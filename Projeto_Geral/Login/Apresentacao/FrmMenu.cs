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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            AbrirFormFilho(new FrmMenuCadastrar());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormFilho(object formfilho)
        {
            if (this.painelContenedor.Controls.Count > 0)
                this.painelContenedor.Controls.RemoveAt(0);
            Form fh = formfilho as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.painelContenedor.Controls.Add(fh);
            this.painelContenedor.Tag = fh;
            fh.Show();

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormFilho(new CalendarioClinica.FrmMenuHome());
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            AbrirFormFilho(new FrmMenuFuncionario());
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            AbrirFormFilho(new CalendarioClinica.FrmMenuHome());
        }

        private void btnFolhaPagto_Click(object sender, EventArgs e)
        {
            AbrirFormFilho(new FrmMenuFolha());
        }

        private void btnHolerite_Click(object sender, EventArgs e)
        {
            AbrirFormFilho(new FrmMenuHolerite());
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            AbrirFormFilho(new FrmMenuRelatorios());
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            string url = "https://contate.me/suporte_inovatech";
            System.Diagnostics.Process.Start(url);
        }
    }
}

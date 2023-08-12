using Login.Apresentacao;
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

namespace Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSuporte_Click(object sender, EventArgs e)
        {
            string url = "https://contate.me/suporte_inovatech";
            System.Diagnostics.Process.Start(url);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FrmMenu open = new FrmMenu();
            open.Show();

            /*Controle controle = new Controle();
            controle.acessar(txbUsuario.Text.ToUpper(), txbSenha.Text);
            if (controle.mensagem.Equals(""))
            {

                if (controle.tem.Item1 && controle.tem.Item3)
                {
                    if (controle.tem.Item2 == "Admin")
                    {
                        FrmMenu open = new FrmMenu();
                        open.Show();
                    }
                    else if(controle.tem.Item2 == "Departamento Pessoal")
                    {
                        FrmMenu open = new FrmMenu();
                        open.btnCadastrar.Enabled = false;
                        open.Show();                     
                    }
                    else if(controle.tem.Item2 == "Colaborador")
                    {
                        FrmMenu open = new FrmMenu();
                        open.btnCadastrar.Enabled = false;
                        open.btnFolhaPagto.Enabled = false;
                        open.btnFuncionario.Enabled = false;
                        open.btnRelatorios.Enabled = false;
                        open.Show();                       
                    }
                    else
                    {
                        MessageBox.Show("Nível de acesso desconhecido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Login não encontrado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }*/


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


    }
}

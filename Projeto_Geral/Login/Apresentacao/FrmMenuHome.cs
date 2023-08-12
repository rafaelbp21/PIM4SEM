using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace CalendarioClinica
{
    public partial class FrmMenuHome : Form
    {

        string dataSelecionada;
        string horaSelecionada;
        string med1, med2, med3 = string.Empty; 
        public FrmMenuHome()
        {            
            InitializeComponent();
        }

        private void calDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            GetDatas();
        }

        private void GetDatas()
        {
            horaSelecionada = cboHoraAgenda.Value.ToShortTimeString();

            dataSelecionada = calData.SelectionRange.Start.ToShortDateString();
            apptDate.Value = DateTime.Parse(dataSelecionada);

            CarregaAgendamentos(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            GetMedicos();
            GetTipoAgendamentos();
            GetDatas();
            CarregaAgendamentos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void RemoveItem()
        {
            string strDeleta = listAppts.SelectedItem.ToString();
            var todasLinhas = File.ReadAllLines(@"agendamentos.dat");
            var novasLinhas = todasLinhas.Where(line => !line.Contains(strDeleta));
            File.WriteAllLines(@"agendamentos.dat", novasLinhas);
            CarregaAgendamentos();
        }

        private void cboHoraAgenda_ValueChanged(object sender, EventArgs e)
        {
            horaSelecionada = cboHoraAgenda.Value.ToShortTimeString();
            lblStatus.Text = dataSelecionada + " @ " + horaSelecionada;

            AtualizaStatus();
        }

        private void apptDate_ValueChanged(object sender, EventArgs e)
        {
            dataSelecionada = apptDate.Value.ToString("dddd dd MMMM yyyy");
            lblStatus.Text = dataSelecionada + " @ " + horaSelecionada;
            AtualizaStatus();
            CarregaAgendamentos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaDados();
        }

        private void LimpaDados()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }

        private void CarregaAgendamentos()
        {
            panel1.Controls.Clear(); 
            panel2.Controls.Clear();
            panel3.Controls.Clear();

            try
            {
                string[] linhas = File.ReadAllLines(@"agendamentos.dat");
                var linhasFiltradas = linhas.Where(line => line.Contains(dataSelecionada)).ToList();
                listAppts.DataSource = linhasFiltradas;

                foreach (var line in linhasFiltradas)
                {
                    TextBox text = new TextBox();
                    text.Font = new Font("Arial", 10);
                    text.Width = panel1.Width;
                    text.Height = 60;
                    text.WordWrap = true;
                    text.Multiline = true;
                    text.AcceptsReturn = true;

                    var campos = line.Split(',');
                    var lernome = campos[0].Trim();
                    var lerhora = campos[2].Trim();
                    var lertipo = campos[5].Trim();

                    text.Text = lernome + Environment.NewLine + lerhora + Environment.NewLine + lertipo;
                    tip.SetToolTip(text, text.Text);

                    tip.SetToolTip(text, text.Text);
                    int med = 0;

                    if (line.Contains(med1)) { med = 1; }
                    if (line.Contains(med2)) { med = 2; }
                    if (line.Contains(med3)) { med = 3; }

                    switch (med)
                    {
                        case 1:
                            text.BackColor = Color.PaleTurquoise;
                            panel1.Controls.Add(text);
                            break;
                        case 2:
                            text.BackColor = Color.LemonChiffon;
                            panel2.Controls.Add(text);
                            break;
                        case 3:
                            text.BackColor = Color.PeachPuff;
                            panel3.Controls.Add(text);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                lblStatus.Text = "ERRO! Verifique se o agendamento foi incluído!";
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha todas as informações antes de salvar o agendamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Erro - Agendamento não foi salvo.";
            }
            else
            {
                using (StreamWriter sw = File.AppendText(@"agendamentos.dat"))
                {
                    sw.WriteLine(txtNome.Text + ", " + dataSelecionada + ", " + horaSelecionada + ", " + comboMedicos.Text + ", " + txtTelefone.Text + ", " + cboTipoAgendamento.Text);
                    sw.Close();

                    LimpaDados();

                    lblStatus.Text = "Agendamento Incluído";
                    CarregaAgendamentos();
                }
            }
        }

        private void txtSingleText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AtualizaStatus()
        {
            lblStatus.Text = "Alterações não salvas! O agendamento não foi salvo ainda...";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            AtualizaStatus();
        }

        private void txtCell_TextChanged(object sender, EventArgs e)
        {
            AtualizaStatus();
        }

        private void txtPhysician_TextChanged(object sender, EventArgs e)
        {
            AtualizaStatus();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                this.Show();
                this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void GetMedicos()
        {
            try
            {
                // carrega medicos 
                string[] linhas = File.ReadAllLines(@"medicos.dat");
                var linhasFiltradas = linhas.ToList();
                foreach (var line in linhasFiltradas)
                {
                    comboMedicos.Items.Add(line);
                }
                comboMedicos.SelectedIndex = 0;

                labelMed1.Text = (med1 = linhas[0]);  
                labelMed2.Text = (med2 = linhas[1]);
                labelMed3.Text = (med3 = linhas[2]);
            }
            catch (Exception)
            {
                lblStatus.Text = "ERROR! Nenhum médico listado. Inclua um médico.";
            }
        }

        private void GetTipoAgendamentos()
        {
            try
            {
                string[] linhas = File.ReadAllLines(@"tiposAgendamentos.dat");
                var linhasFiltradas = linhas.ToList();
                foreach (var linha in linhasFiltradas)
                {
                    cboTipoAgendamento.Items.Add(linha);
                }
                cboTipoAgendamento.SelectedIndex = 0;
            }
            catch (Exception)
            {
                lblStatus.Text = "ERRO! Nenhum tipo de agendamento foi definido. Inclua um tipo.";
            }
        }
    }
}

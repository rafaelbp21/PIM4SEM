using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Apresentacao
{
    public partial class FrmMenuRelatorios : Form
    {
        public FrmMenuRelatorios()
        {
            InitializeComponent();
            txbData.TextChanged += (sender, args) => DataSelecionada = txbData.Text;
        }

        private void btnFolha_Click(object sender, EventArgs e)
        {
            string dataSelecionada = txbData.Text;
            FrmMenuRelatorioTodos abrir = new FrmMenuRelatorioTodos(dataSelecionada);
            abrir.Show();

        }

        public string DataSelecionada { get; private set; }
    }
}

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
    public partial class FrmMenuRelatorioTodos : Form
    {
        private readonly string _dataSelecionada;
        public FrmMenuRelatorioTodos(string dataSelecionada)
        {
            InitializeComponent();
            _dataSelecionada = dataSelecionada;
        }

        private void FrmMenuHoleriteTodos_Load(object sender, EventArgs e)
        {
            
            // TODO: esta linha de código carrega dados na tabela 'teste.FolhaPagto'. Você pode movê-la ou removê-la conforme necessário.
            this.folhaPagtoTableAdapter.Fill(this.teste.FolhaPagto, _dataSelecionada);

            this.reportViewer1.RefreshReport();
        }
    }
}

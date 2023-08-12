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
    public partial class FrmMenuHoleriteFunc : Form
    {
        private readonly string _dataSelecionada;
        private readonly string _Pin;
        private readonly string _cpf;
        public FrmMenuHoleriteFunc(string dataSelecionada, string Pin, string cpf)
        {
            InitializeComponent();
            _dataSelecionada = dataSelecionada;
            _Pin = Pin;
            _cpf = cpf;

        }

        private void FrmMenuHoleriteFunc_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'teste.FolhaPagto'. Você pode movê-la ou removê-la conforme necessário.
            this.holeriteFuncTableAdapter.Fill(this.teste.HoleriteFunc, _dataSelecionada, _cpf, _Pin);
            this.reportViewer1.RefreshReport();

        }
    }
}

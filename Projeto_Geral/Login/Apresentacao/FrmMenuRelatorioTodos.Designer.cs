namespace Login.Apresentacao
{
    partial class FrmMenuRelatorioTodos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuRelatorioTodos));
            this.folhaPagtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teste = new Login.Teste();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.folhaPagtoTableAdapter = new Login.TesteTableAdapters.FolhaPagtoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.folhaPagtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teste)).BeginInit();
            this.SuspendLayout();
            // 
            // folhaPagtoBindingSource
            // 
            this.folhaPagtoBindingSource.DataMember = "FolhaPagto";
            this.folhaPagtoBindingSource.DataSource = this.teste;
            // 
            // teste
            // 
            this.teste.DataSetName = "Teste";
            this.teste.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FolhaPagto";
            reportDataSource1.Value = this.folhaPagtoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Login.RelHoleriteFolha.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 13;
            // 
            // folhaPagtoTableAdapter
            // 
            this.folhaPagtoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmMenuHoleriteTodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenuHoleriteTodos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physiotime - Folha de Pagamento";
            this.Load += new System.EventHandler(this.FrmMenuHoleriteTodos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.folhaPagtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Teste teste;
        private System.Windows.Forms.BindingSource folhaPagtoBindingSource;
        private TesteTableAdapters.FolhaPagtoTableAdapter folhaPagtoTableAdapter;
    }
}
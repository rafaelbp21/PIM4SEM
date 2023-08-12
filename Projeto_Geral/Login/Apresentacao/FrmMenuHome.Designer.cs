namespace CalendarioClinica
{
    partial class FrmMenuHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuHome));
            this.calData = new System.Windows.Forms.MonthCalendar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.btnRemover = new System.Windows.Forms.Button();
            this.listAppts = new System.Windows.Forms.ListBox();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.cboTipoAgendamento = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboMedicos = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboHoraAgenda = new System.Windows.Forms.DateTimePicker();
            this.apptDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelMed1 = new System.Windows.Forms.Label();
            this.labelMed2 = new System.Windows.Forms.Label();
            this.labelMed3 = new System.Windows.Forms.Label();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // calData
            // 
            this.calData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.calData.BackColor = System.Drawing.Color.White;
            this.calData.CalendarDimensions = new System.Drawing.Size(1, 3);
            this.calData.Location = new System.Drawing.Point(8, 101);
            this.calData.Margin = new System.Windows.Forms.Padding(14);
            this.calData.MaxSelectionCount = 1;
            this.calData.Name = "calData";
            this.calData.ShowToday = false;
            this.calData.TabIndex = 0;
            this.calData.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calDate_DateChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(241, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 560);
            this.tabControl1.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.btnRemover);
            this.tab1.Controls.Add(this.listAppts);
            this.tab1.Location = new System.Drawing.Point(4, 24);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(455, 532);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Agendamento";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemover.Location = new System.Drawing.Point(6, 503);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(121, 23);
            this.btnRemover.TabIndex = 1;
            this.btnRemover.Text = "Remover Seleção";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // listAppts
            // 
            this.listAppts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listAppts.BackColor = System.Drawing.Color.White;
            this.listAppts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAppts.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listAppts.FormattingEnabled = true;
            this.listAppts.ItemHeight = 15;
            this.listAppts.Location = new System.Drawing.Point(3, 6);
            this.listAppts.Name = "listAppts";
            this.listAppts.Size = new System.Drawing.Size(456, 480);
            this.listAppts.TabIndex = 0;
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.White;
            this.tab2.Controls.Add(this.cboTipoAgendamento);
            this.tab2.Controls.Add(this.label19);
            this.tab2.Controls.Add(this.comboMedicos);
            this.tab2.Controls.Add(this.label17);
            this.tab2.Controls.Add(this.lblStatus);
            this.tab2.Controls.Add(this.btnLimpar);
            this.tab2.Controls.Add(this.btnAdicionar);
            this.tab2.Controls.Add(this.label8);
            this.tab2.Controls.Add(this.cboHoraAgenda);
            this.tab2.Controls.Add(this.apptDate);
            this.tab2.Controls.Add(this.label7);
            this.tab2.Controls.Add(this.label6);
            this.tab2.Controls.Add(this.txtTelefone);
            this.tab2.Controls.Add(this.label1);
            this.tab2.Controls.Add(this.label5);
            this.tab2.Controls.Add(this.txtNome);
            this.tab2.Controls.Add(this.label4);
            this.tab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab2.Location = new System.Drawing.Point(4, 24);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(455, 532);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Agendar";
            // 
            // cboTipoAgendamento
            // 
            this.cboTipoAgendamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAgendamento.FormattingEnabled = true;
            this.cboTipoAgendamento.Location = new System.Drawing.Point(156, 151);
            this.cboTipoAgendamento.Name = "cboTipoAgendamento";
            this.cboTipoAgendamento.Size = new System.Drawing.Size(261, 23);
            this.cboTipoAgendamento.TabIndex = 19;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(31, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 15);
            this.label19.TabIndex = 16;
            this.label19.Text = "Tipo Agendamento:";
            // 
            // comboMedicos
            // 
            this.comboMedicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedicos.FormattingEnabled = true;
            this.comboMedicos.Location = new System.Drawing.Point(156, 113);
            this.comboMedicos.Name = "comboMedicos";
            this.comboMedicos.Size = new System.Drawing.Size(261, 23);
            this.comboMedicos.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(42, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 14;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(43, 409);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(374, 23);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(45, 339);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(129, 53);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "&Reiniciar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(288, 339);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(129, 53);
            this.btnAdicionar.TabIndex = 11;
            this.btnAdicionar.Text = "&Incluir Agenda";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 18;
            // 
            // cboHoraAgenda
            // 
            this.cboHoraAgenda.CustomFormat = "h:mm tt";
            this.cboHoraAgenda.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cboHoraAgenda.Location = new System.Drawing.Point(156, 238);
            this.cboHoraAgenda.Name = "cboHoraAgenda";
            this.cboHoraAgenda.ShowUpDown = true;
            this.cboHoraAgenda.Size = new System.Drawing.Size(105, 21);
            this.cboHoraAgenda.TabIndex = 8;
            this.cboHoraAgenda.ValueChanged += new System.EventHandler(this.cboHoraAgenda_ValueChanged);
            // 
            // apptDate
            // 
            this.apptDate.CustomFormat = "dddd dd MMMM yyyy";
            this.apptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.apptDate.Location = new System.Drawing.Point(156, 192);
            this.apptDate.Name = "apptDate";
            this.apptDate.Size = new System.Drawing.Size(261, 21);
            this.apptDate.TabIndex = 7;
            this.apptDate.ValueChanged += new System.EventHandler(this.apptDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Hora Agendamento :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Data Agendamento:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(156, 71);
            this.txtTelefone.MaxLength = 50;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(261, 21);
            this.txtTelefone.TabIndex = 3;
            this.txtTelefone.TextChanged += new System.EventHandler(this.txtCell_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Priporidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Observação:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(156, 28);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(261, 21);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome :";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Double click to open...";
            this.notifyIcon1.BalloonTipTitle = "Appointment Reminder";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Appointment Reminder";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // labelMed1
            // 
            this.labelMed1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.labelMed1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMed1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMed1.Location = new System.Drawing.Point(714, 7);
            this.labelMed1.Name = "labelMed1";
            this.labelMed1.Size = new System.Drawing.Size(97, 21);
            this.labelMed1.TabIndex = 7;
            this.labelMed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMed2
            // 
            this.labelMed2.BackColor = System.Drawing.Color.LemonChiffon;
            this.labelMed2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMed2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMed2.Location = new System.Drawing.Point(817, 7);
            this.labelMed2.Name = "labelMed2";
            this.labelMed2.Size = new System.Drawing.Size(97, 21);
            this.labelMed2.TabIndex = 8;
            this.labelMed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMed3
            // 
            this.labelMed3.BackColor = System.Drawing.Color.PeachPuff;
            this.labelMed3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMed3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMed3.Location = new System.Drawing.Point(920, 7);
            this.labelMed3.Name = "labelMed3";
            this.labelMed3.Size = new System.Drawing.Size(97, 21);
            this.labelMed3.TabIndex = 9;
            this.labelMed3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tip
            // 
            this.tip.AutoPopDelay = 5000;
            this.tip.InitialDelay = 100;
            this.tip.IsBalloon = true;
            this.tip.ReshowDelay = 100;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel1.Location = new System.Drawing.Point(714, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 467);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel2.Location = new System.Drawing.Point(817, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 467);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel3.Location = new System.Drawing.Point(920, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 467);
            this.panel3.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login.Properties.Resources.agenda;
            this.pictureBox1.Location = new System.Drawing.Point(8, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMenuHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1042, 583);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMed3);
            this.Controls.Add(this.labelMed2);
            this.Controls.Add(this.labelMed1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.calData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmMenuHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendário / Agenda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker cboHoraAgenda;
        private System.Windows.Forms.DateTimePicker apptDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListBox listAppts;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox comboMedicos;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelMed1;
        private System.Windows.Forms.Label labelMed2;
        private System.Windows.Forms.Label labelMed3;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.FlowLayoutPanel panel2;
        private System.Windows.Forms.FlowLayoutPanel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoAgendamento;
    }
}


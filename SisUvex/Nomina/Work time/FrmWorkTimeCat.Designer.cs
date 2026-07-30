namespace SisUvex.Nomina.Work_time
{
    partial class FrmWorkTimeCat
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkTimeCat));
			dgvCatalog = new DataGridView();
			btnModify = new Button();
			btnAdd = new Button();
			cboProductionLine = new ComboBox();
			lblProductionLine = new Label();
			chbActiveProductionLine = new CheckBox();
			btnSearch = new Button();
			btnReportField = new Button();
			btnReportFacility = new Button();
			cboTemporada = new ComboBox();
			lblTemporada = new Label();
			cboFinal = new ComboBox();
			lblFechaFinal = new Label();
			cboFechaInicio = new ComboBox();
			lblFechaInicial = new Label();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			groupBox3 = new GroupBox();
			label1 = new Label();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// dgvCatalog
			// 
			dgvCatalog.AllowUserToAddRows = false;
			dgvCatalog.AllowUserToDeleteRows = false;
			dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvCatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvCatalog.BackgroundColor = SystemColors.ControlLightLight;
			dgvCatalog.BorderStyle = BorderStyle.Fixed3D;
			dgvCatalog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvCatalog.ColumnHeadersHeight = 29;
			dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCatalog.EnableHeadersVisualStyles = false;
			dgvCatalog.ImeMode = ImeMode.NoControl;
			dgvCatalog.Location = new Point(12, 252);
			dgvCatalog.Name = "dgvCatalog";
			dgvCatalog.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvCatalog.RowHeadersVisible = false;
			dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCatalog.Size = new Size(1102, 528);
			dgvCatalog.TabIndex = 7;
			dgvCatalog.CellPainting += dgvCatalog_CellPainting;
			dgvCatalog.DataBindingComplete += dgvCatalog_DataBindingComplete;
			dgvCatalog.DoubleClick += dgvCatalog_DoubleClick;
			// 
			// btnModify
			// 
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(122, 22);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(3, 0, 3, 0);
			btnModify.Size = new Size(91, 23);
			btnModify.TabIndex = 1;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnAdd
			// 
			btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
			btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
			btnAdd.Location = new Point(10, 22);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(6, 0, 6, 0);
			btnAdd.Size = new Size(87, 23);
			btnAdd.TabIndex = 0;
			btnAdd.Text = "Añadir";
			btnAdd.TextAlign = ContentAlignment.MiddleRight;
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// cboProductionLine
			// 
			cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
			cboProductionLine.FormattingEnabled = true;
			cboProductionLine.ItemHeight = 15;
			cboProductionLine.Location = new Point(56, 98);
			cboProductionLine.Name = "cboProductionLine";
			cboProductionLine.Size = new Size(194, 23);
			cboProductionLine.TabIndex = 3;
			// 
			// lblProductionLine
			// 
			lblProductionLine.AutoSize = true;
			lblProductionLine.Location = new Point(25, 78);
			lblProductionLine.Name = "lblProductionLine";
			lblProductionLine.Size = new Size(43, 15);
			lblProductionLine.TabIndex = 27;
			lblProductionLine.Text = "Banda:";
			// 
			// chbActiveProductionLine
			// 
			chbActiveProductionLine.Appearance = Appearance.Button;
			chbActiveProductionLine.AutoSize = true;
			chbActiveProductionLine.BackgroundImage = Properties.Resources.Imagen6;
			chbActiveProductionLine.BackgroundImageLayout = ImageLayout.Stretch;
			chbActiveProductionLine.Font = new Font("Segoe UI", 9F);
			chbActiveProductionLine.Location = new Point(24, 96);
			chbActiveProductionLine.Name = "chbActiveProductionLine";
			chbActiveProductionLine.Size = new Size(32, 25);
			chbActiveProductionLine.TabIndex = 2;
			chbActiveProductionLine.Text = "     ";
			chbActiveProductionLine.UseVisualStyleBackColor = true;
			// 
			// btnSearch
			// 
			btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
			btnSearch.Font = new Font("Segoe UI", 14F);
			btnSearch.Image = Properties.Resources.BuscarLupa1;
			btnSearch.Location = new Point(251, 96);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(25, 25);
			btnSearch.TabIndex = 4;
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// btnReportField
			// 
			btnReportField.Image = (Image)resources.GetObject("btnReportField.Image");
			btnReportField.ImageAlign = ContentAlignment.MiddleLeft;
			btnReportField.Location = new Point(10, 29);
			btnReportField.Name = "btnReportField";
			btnReportField.Padding = new Padding(4, 0, 4, 0);
			btnReportField.Size = new Size(87, 23);
			btnReportField.TabIndex = 5;
			btnReportField.Text = "Campo";
			btnReportField.TextAlign = ContentAlignment.MiddleRight;
			btnReportField.UseVisualStyleBackColor = true;
			btnReportField.Click += btnReportField_Click;
			// 
			// btnReportFacility
			// 
			btnReportFacility.Image = (Image)resources.GetObject("btnReportFacility.Image");
			btnReportFacility.ImageAlign = ContentAlignment.MiddleLeft;
			btnReportFacility.Location = new Point(122, 29);
			btnReportFacility.Name = "btnReportFacility";
			btnReportFacility.Size = new Size(91, 23);
			btnReportFacility.TabIndex = 6;
			btnReportFacility.Text = "Empaque";
			btnReportFacility.TextAlign = ContentAlignment.MiddleRight;
			btnReportFacility.UseVisualStyleBackColor = true;
			btnReportFacility.Click += btnReportFacility_Click;
			// 
			// cboTemporada
			// 
			cboTemporada.DropDownStyle = ComboBoxStyle.DropDownList;
			cboTemporada.FormattingEnabled = true;
			cboTemporada.Location = new Point(23, 38);
			cboTemporada.Name = "cboTemporada";
			cboTemporada.Size = new Size(256, 23);
			cboTemporada.TabIndex = 34;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Microsoft Sans Serif", 9F);
			lblTemporada.Location = new Point(23, 20);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(74, 15);
			lblTemporada.TabIndex = 33;
			lblTemporada.Text = "Temporada:";
			// 
			// cboFinal
			// 
			cboFinal.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFinal.FormattingEnabled = true;
			cboFinal.Location = new Point(522, 96);
			cboFinal.Name = "cboFinal";
			cboFinal.Size = new Size(235, 23);
			cboFinal.TabIndex = 38;
			cboFinal.SelectedIndexChanged += cboFinal_SelectedIndexChanged;
			// 
			// lblFechaFinal
			// 
			lblFechaFinal.AutoSize = true;
			lblFechaFinal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaFinal.Location = new Point(522, 78);
			lblFechaFinal.Name = "lblFechaFinal";
			lblFechaFinal.Size = new Size(81, 15);
			lblFechaFinal.TabIndex = 37;
			lblFechaFinal.Text = "Semana Final:";
			// 
			// cboFechaInicio
			// 
			cboFechaInicio.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFechaInicio.FormattingEnabled = true;
			cboFechaInicio.Location = new Point(522, 38);
			cboFechaInicio.Name = "cboFechaInicio";
			cboFechaInicio.Size = new Size(235, 23);
			cboFechaInicio.TabIndex = 36;
			cboFechaInicio.SelectedIndexChanged += cboFechaInicio_SelectedIndexChanged;
			// 
			// lblFechaInicial
			// 
			lblFechaInicial.AutoSize = true;
			lblFechaInicial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaInicial.Location = new Point(522, 20);
			lblFechaInicial.Name = "lblFechaInicial";
			lblFechaInicial.Size = new Size(88, 15);
			lblFechaInicial.TabIndex = 35;
			lblFechaInicial.Text = "Semana Inicial:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnModify);
			groupBox1.Controls.Add(btnAdd);
			groupBox1.Location = new Point(868, 85);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(219, 62);
			groupBox1.TabIndex = 40;
			groupBox1.TabStop = false;
			groupBox1.Text = "Ajustes de Horario";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnReportField);
			groupBox2.Controls.Add(btnReportFacility);
			groupBox2.Location = new Point(868, 165);
			groupBox2.Margin = new Padding(3, 2, 3, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(3, 2, 3, 2);
			groupBox2.Size = new Size(219, 62);
			groupBox2.TabIndex = 41;
			groupBox2.TabStop = false;
			groupBox2.Text = "Generar Reporte";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(cboTemporada);
			groupBox3.Controls.Add(cboProductionLine);
			groupBox3.Controls.Add(lblProductionLine);
			groupBox3.Controls.Add(cboFinal);
			groupBox3.Controls.Add(chbActiveProductionLine);
			groupBox3.Controls.Add(lblFechaFinal);
			groupBox3.Controls.Add(btnSearch);
			groupBox3.Controls.Add(cboFechaInicio);
			groupBox3.Controls.Add(lblTemporada);
			groupBox3.Controls.Add(lblFechaInicial);
			groupBox3.Location = new Point(12, 85);
			groupBox3.Margin = new Padding(3, 2, 3, 2);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(3, 2, 3, 2);
			groupBox3.Size = new Size(800, 142);
			groupBox3.TabIndex = 42;
			groupBox3.TabStop = false;
			groupBox3.Text = "Informacion General";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
			label1.Location = new Point(10, 16);
			label1.Name = "label1";
			label1.Size = new Size(295, 30);
			label1.TabIndex = 43;
			label1.Text = "Horario de Empaque Central";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(10, 50);
			label2.Name = "label2";
			label2.Size = new Size(342, 15);
			label2.TabIndex = 44;
			label2.Text = " Administra los horarios, descansos y horas extras del personal.  ";
			// 
			// FrmWorkTimeCat
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1125, 791);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(dgvCatalog);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmWorkTimeCat";
			Text = "Horarios de empaque";
			WindowState = FormWindowState.Maximized;
			Load += FrmWorkTimeCat_Load;
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public DataGridView dgvCatalog;
        private Button btnModify;
        private Button btnAdd;
        private Label lblProductionLine;
        public CheckBox chbActiveProductionLine;
        public ComboBox cboProductionLine;
        private Button btnSearch;
        private Button btnReportField;
        private Button btnReportFacility;
		public ComboBox cboTemporada;
		private Label lblTemporada;
		public ComboBox cboFinal;
		private Label lblFechaFinal;
		public ComboBox cboFechaInicio;
		private Label lblFechaInicial;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private Label label1;
		private Label label2;
	}
}
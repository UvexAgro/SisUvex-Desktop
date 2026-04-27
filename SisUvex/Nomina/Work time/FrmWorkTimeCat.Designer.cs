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
			label1 = new Label();
			cboTemporada = new ComboBox();
			lblTemporada = new Label();
			cboFinal = new ComboBox();
			lblFechaFinal = new Label();
			cboFechaInicio = new ComboBox();
			lblFechaInicial = new Label();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
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
			dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCatalog.EnableHeadersVisualStyles = false;
			dgvCatalog.ImeMode = ImeMode.NoControl;
			dgvCatalog.Location = new Point(12, 131);
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
			dgvCatalog.Size = new Size(1055, 672);
			dgvCatalog.TabIndex = 7;
			dgvCatalog.CellPainting += dgvCatalog_CellPainting;
			dgvCatalog.DataBindingComplete += dgvCatalog_DataBindingComplete;
			dgvCatalog.DoubleClick += dgvCatalog_DoubleClick;
			// 
			// btnModify
			// 
			btnModify.Location = new Point(728, 32);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(75, 23);
			btnModify.TabIndex = 1;
			btnModify.Text = "Modificar";
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(664, 32);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(58, 23);
			btnAdd.TabIndex = 0;
			btnAdd.Text = "Añadir";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// cboProductionLine
			// 
			cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
			cboProductionLine.FormattingEnabled = true;
			cboProductionLine.ItemHeight = 15;
			cboProductionLine.Location = new Point(45, 86);
			cboProductionLine.Name = "cboProductionLine";
			cboProductionLine.Size = new Size(194, 23);
			cboProductionLine.TabIndex = 3;
			// 
			// lblProductionLine
			// 
			lblProductionLine.AutoSize = true;
			lblProductionLine.Location = new Point(14, 67);
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
			chbActiveProductionLine.Location = new Point(12, 85);
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
			btnSearch.Location = new Point(240, 85);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(25, 25);
			btnSearch.TabIndex = 4;
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// btnReportField
			// 
			btnReportField.Location = new Point(664, 85);
			btnReportField.Name = "btnReportField";
			btnReportField.Size = new Size(70, 23);
			btnReportField.TabIndex = 5;
			btnReportField.Text = "Campo";
			btnReportField.UseVisualStyleBackColor = true;
			btnReportField.Click += btnReportField_Click;
			// 
			// btnReportFacility
			// 
			btnReportFacility.Location = new Point(740, 85);
			btnReportFacility.Name = "btnReportFacility";
			btnReportFacility.Size = new Size(70, 23);
			btnReportFacility.TabIndex = 6;
			btnReportFacility.Text = "Empaque";
			btnReportFacility.UseVisualStyleBackColor = true;
			btnReportFacility.Click += btnReportFacility_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(664, 67);
			label1.Name = "label1";
			label1.Size = new Size(51, 15);
			label1.TabIndex = 30;
			label1.Text = "Reporte:";
			// 
			// cboTemporada
			// 
			cboTemporada.DropDownStyle = ComboBoxStyle.DropDownList;
			cboTemporada.FormattingEnabled = true;
			cboTemporada.Location = new Point(12, 27);
			cboTemporada.Name = "cboTemporada";
			cboTemporada.Size = new Size(256, 23);
			cboTemporada.TabIndex = 34;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Microsoft Sans Serif", 9F);
			lblTemporada.Location = new Point(12, 9);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(74, 15);
			lblTemporada.TabIndex = 33;
			lblTemporada.Text = "Temporada:";
			// 
			// cboFinal
			// 
			cboFinal.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFinal.FormattingEnabled = true;
			cboFinal.Location = new Point(346, 91);
			cboFinal.Name = "cboFinal";
			cboFinal.Size = new Size(235, 23);
			cboFinal.TabIndex = 38;
			cboFinal.SelectedIndexChanged += cboFinal_SelectedIndexChanged;
			// 
			// lblFechaFinal
			// 
			lblFechaFinal.AutoSize = true;
			lblFechaFinal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaFinal.Location = new Point(346, 73);
			lblFechaFinal.Name = "lblFechaFinal";
			lblFechaFinal.Size = new Size(81, 15);
			lblFechaFinal.TabIndex = 37;
			lblFechaFinal.Text = "Semana Final:";
			// 
			// cboFechaInicio
			// 
			cboFechaInicio.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFechaInicio.FormattingEnabled = true;
			cboFechaInicio.Location = new Point(346, 27);
			cboFechaInicio.Name = "cboFechaInicio";
			cboFechaInicio.Size = new Size(235, 23);
			cboFechaInicio.TabIndex = 36;
			cboFechaInicio.SelectedIndexChanged += cboFechaInicio_SelectedIndexChanged;
			// 
			// lblFechaInicial
			// 
			lblFechaInicial.AutoSize = true;
			lblFechaInicial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaInicial.Location = new Point(346, 9);
			lblFechaInicial.Name = "lblFechaInicial";
			lblFechaInicial.Size = new Size(88, 15);
			lblFechaInicial.TabIndex = 35;
			lblFechaInicial.Text = "Semana Inicial:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(664, 10);
			label2.Name = "label2";
			label2.Size = new Size(95, 15);
			label2.TabIndex = 39;
			label2.Text = "Agregar Horario:";
			// 
			// FrmWorkTimeCat
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1079, 814);
			Controls.Add(label2);
			Controls.Add(cboFinal);
			Controls.Add(lblFechaFinal);
			Controls.Add(cboFechaInicio);
			Controls.Add(lblFechaInicial);
			Controls.Add(cboTemporada);
			Controls.Add(lblTemporada);
			Controls.Add(btnReportFacility);
			Controls.Add(btnReportField);
			Controls.Add(btnSearch);
			Controls.Add(chbActiveProductionLine);
			Controls.Add(lblProductionLine);
			Controls.Add(cboProductionLine);
			Controls.Add(btnModify);
			Controls.Add(btnAdd);
			Controls.Add(dgvCatalog);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmWorkTimeCat";
			Text = "Horarios de empaque";
			WindowState = FormWindowState.Maximized;
			Load += FrmWorkTimeCat_Load;
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
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
        private Label label1;
		public ComboBox cboTemporada;
		private Label lblTemporada;
		public ComboBox cboFinal;
		private Label lblFechaFinal;
		public ComboBox cboFechaInicio;
		private Label lblFechaInicial;
		private Label label2;
	}
}
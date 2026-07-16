namespace SisUvex.Nomina.Reporte_de_Empacador
{
	partial class FrmPackersReport
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPackersReport));
			lblReporteEmpacadores = new Label();
			lblcodigo = new Label();
			txbCodigo = new TextBox();
			lblEmpleado = new Label();
			txbNombre = new TextBox();
			lblLinea = new Label();
			cboLineas = new ComboBox();
			dgvEmployee = new DataGridView();
			btnEmpleado = new Button();
			btnExcelBandas = new Button();
			btnPdfEmpleado = new Button();
			lblSemana = new Label();
			cboSemana = new ComboBox();
			pictureBox1 = new PictureBox();
			pictureBox2 = new PictureBox();
			rbtUva = new RadioButton();
			lblTipodeNomina = new Label();
			rbtEsparrago = new RadioButton();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// lblReporteEmpacadores
			// 
			lblReporteEmpacadores.AutoSize = true;
			lblReporteEmpacadores.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporteEmpacadores.Location = new Point(337, 9);
			lblReporteEmpacadores.Name = "lblReporteEmpacadores";
			lblReporteEmpacadores.Size = new Size(255, 30);
			lblReporteEmpacadores.TabIndex = 0;
			lblReporteEmpacadores.Text = "Reporte de Empacadores";
			// 
			// lblcodigo
			// 
			lblcodigo.AutoSize = true;
			lblcodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblcodigo.Location = new Point(35, 171);
			lblcodigo.Name = "lblcodigo";
			lblcodigo.Size = new Size(63, 21);
			lblcodigo.TabIndex = 1;
			lblcodigo.Text = "Codigo:";
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(136, 169);
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(117, 23);
			txbCodigo.TabIndex = 14;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblEmpleado.Location = new Point(35, 202);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(82, 21);
			lblEmpleado.TabIndex = 15;
			lblEmpleado.Text = "Empleado:";
			// 
			// txbNombre
			// 
			txbNombre.Location = new Point(136, 202);
			txbNombre.Name = "txbNombre";
			txbNombre.ReadOnly = true;
			txbNombre.Size = new Size(258, 23);
			txbNombre.TabIndex = 16;
			// 
			// lblLinea
			// 
			lblLinea.AutoSize = true;
			lblLinea.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLinea.Location = new Point(35, 138);
			lblLinea.Name = "lblLinea";
			lblLinea.Size = new Size(56, 21);
			lblLinea.TabIndex = 17;
			lblLinea.Text = "Banda:";
			// 
			// cboLineas
			// 
			cboLineas.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLineas.FormattingEnabled = true;
			cboLineas.Location = new Point(136, 136);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(117, 23);
			cboLineas.TabIndex = 20;
			// 
			// dgvEmployee
			// 
			dgvEmployee.AllowUserToAddRows = false;
			dgvEmployee.AllowUserToDeleteRows = false;
			dgvEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvEmployee.BackgroundColor = SystemColors.ControlLightLight;
			dgvEmployee.BorderStyle = BorderStyle.Fixed3D;
			dgvEmployee.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvEmployee.ColumnHeadersHeight = 58;
			dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvEmployee.EnableHeadersVisualStyles = false;
			dgvEmployee.ImeMode = ImeMode.NoControl;
			dgvEmployee.Location = new Point(29, 233);
			dgvEmployee.Name = "dgvEmployee";
			dgvEmployee.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvEmployee.RowHeadersVisible = false;
			dgvEmployee.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvEmployee.Size = new Size(891, 571);
			dgvEmployee.TabIndex = 24;
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(259, 171);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(23, 23);
			btnEmpleado.TabIndex = 25;
			btnEmpleado.UseVisualStyleBackColor = true;
			btnEmpleado.Click += btnEmpleado_Click;
			// 
			// btnExcelBandas
			// 
			btnExcelBandas.BackgroundImage = (Image)resources.GetObject("btnExcelBandas.BackgroundImage");
			btnExcelBandas.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcelBandas.Location = new Point(259, 136);
			btnExcelBandas.Name = "btnExcelBandas";
			btnExcelBandas.Size = new Size(23, 23);
			btnExcelBandas.TabIndex = 26;
			btnExcelBandas.UseVisualStyleBackColor = true;
			btnExcelBandas.Click += btnExcelBandas_Click;
			// 
			// btnPdfEmpleado
			// 
			btnPdfEmpleado.BackgroundImage = (Image)resources.GetObject("btnPdfEmpleado.BackgroundImage");
			btnPdfEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnPdfEmpleado.Location = new Point(400, 203);
			btnPdfEmpleado.Name = "btnPdfEmpleado";
			btnPdfEmpleado.Size = new Size(23, 23);
			btnPdfEmpleado.TabIndex = 27;
			btnPdfEmpleado.UseVisualStyleBackColor = true;
			btnPdfEmpleado.Click += btnExcelEmpleado_Click;
			// 
			// lblSemana
			// 
			lblSemana.AutoSize = true;
			lblSemana.Font = new Font("Segoe UI", 10F);
			lblSemana.Location = new Point(680, 37);
			lblSemana.Name = "lblSemana";
			lblSemana.Size = new Size(60, 19);
			lblSemana.TabIndex = 28;
			lblSemana.Text = "Semana:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(680, 61);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(235, 23);
			cboSemana.TabIndex = 29;
			cboSemana.SelectedIndexChanged += cboSemana_SelectedIndexChanged;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(35, 78);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(33, 32);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 33;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(35, 32);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(33, 27);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 34;
			pictureBox2.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(74, 82);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(45, 19);
			rbtUva.TabIndex = 32;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			// 
			// lblTipodeNomina
			// 
			lblTipodeNomina.AutoSize = true;
			lblTipodeNomina.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTipodeNomina.Location = new Point(29, 9);
			lblTipodeNomina.Name = "lblTipodeNomina";
			lblTipodeNomina.Size = new Size(131, 21);
			lblTipodeNomina.TabIndex = 30;
			lblTipodeNomina.Text = "Tipo de Nomina:";
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(74, 40);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(77, 19);
			rbtEsparrago.TabIndex = 31;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			// 
			// FrmPackersReport
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(956, 816);
			Controls.Add(pictureBox1);
			Controls.Add(pictureBox2);
			Controls.Add(rbtUva);
			Controls.Add(lblTipodeNomina);
			Controls.Add(rbtEsparrago);
			Controls.Add(cboSemana);
			Controls.Add(lblSemana);
			Controls.Add(btnPdfEmpleado);
			Controls.Add(btnExcelBandas);
			Controls.Add(btnEmpleado);
			Controls.Add(dgvEmployee);
			Controls.Add(cboLineas);
			Controls.Add(lblLinea);
			Controls.Add(txbNombre);
			Controls.Add(lblEmpleado);
			Controls.Add(txbCodigo);
			Controls.Add(lblcodigo);
			Controls.Add(lblReporteEmpacadores);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmPackersReport";
			Text = "Reporte de cajas ";
			Load += FrmPackersReport_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblReporteEmpacadores;
		private Label lblcodigo;
		public TextBox txbCodigo;
		private Label lblEmpleado;
		public TextBox txbNombre;
		private Label lblLinea;
		public ComboBox cboLineas;
		public DataGridView dgvEmployee;
		private Button btnEmpleado;
		private Button btnExcelBandas;
		private Button btnPdfEmpleado;
		public ComboBox cboPeriodoSemanas;
		private Label lblSemana;
		public ComboBox cboSemana;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		public RadioButton rbtUva;
		private Label lblTipodeNomina;
		public RadioButton rbtEsparrago;
	}
}
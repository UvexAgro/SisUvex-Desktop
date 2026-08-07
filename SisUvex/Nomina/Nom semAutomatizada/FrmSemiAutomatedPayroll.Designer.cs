namespace SisUvex.Nomina.Nom_semAutomatizada
{
	partial class FrmSemiAutomatedPayroll
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSemiAutomatedPayroll));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			lblLote = new Label();
			lblReferencia = new Label();
			dtpFecha = new DateTimePicker();
			txbReferencia = new TextBox();
			cboLote = new ComboBox();
			lblencabezado = new Label();
			btnCSV = new Button();
			btnExcel = new Button();
			btncargar = new Button();
			dgvEmployee = new DataGridView();
			btnCalcularLibra = new Button();
			cboLineas = new ComboBox();
			lblLineas = new Label();
			rbtEsparrago = new RadioButton();
			pictureBox1 = new PictureBox();
			rbtUva = new RadioButton();
			pictureBox2 = new PictureBox();
			groupBox1 = new GroupBox();
			gbCsv = new GroupBox();
			gbGenerar = new GroupBox();
			gbLibras = new GroupBox();
			btnGuardar = new Button();
			lblTipoProceso = new Label();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			groupBox1.SuspendLayout();
			gbCsv.SuspendLayout();
			gbGenerar.SuspendLayout();
			gbLibras.SuspendLayout();
			SuspendLayout();
			// 
			// lblLote
			// 
			lblLote.AutoSize = true;
			lblLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLote.Location = new Point(57, 31);
			lblLote.Name = "lblLote";
			lblLote.Size = new Size(47, 21);
			lblLote.TabIndex = 0;
			lblLote.Text = "Lote :";
			// 
			// lblReferencia
			// 
			lblReferencia.AutoSize = true;
			lblReferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblReferencia.Location = new Point(57, 86);
			lblReferencia.Name = "lblReferencia";
			lblReferencia.Size = new Size(90, 21);
			lblReferencia.TabIndex = 1;
			lblReferencia.Text = "Referencia :";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(320, 62);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(329, 23);
			dtpFecha.TabIndex = 2;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// txbReferencia
			// 
			txbReferencia.Location = new Point(165, 82);
			txbReferencia.Multiline = true;
			txbReferencia.Name = "txbReferencia";
			txbReferencia.Size = new Size(135, 25);
			txbReferencia.TabIndex = 3;
			// 
			// cboLote
			// 
			cboLote.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(165, 34);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(135, 23);
			cboLote.TabIndex = 4;
			// 
			// lblencabezado
			// 
			lblencabezado.AutoSize = true;
			lblencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblencabezado.Location = new Point(320, 9);
			lblencabezado.Name = "lblencabezado";
			lblencabezado.Size = new Size(329, 32);
			lblencabezado.TabIndex = 5;
			lblencabezado.Text = "Reporte de Empaque Central";
			// 
			// btnCSV
			// 
			btnCSV.BackgroundImageLayout = ImageLayout.Stretch;
			btnCSV.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCSV.Image = (Image)resources.GetObject("btnCSV.Image");
			btnCSV.ImageAlign = ContentAlignment.MiddleLeft;
			btnCSV.Location = new Point(675, 21);
			btnCSV.Name = "btnCSV";
			btnCSV.Padding = new Padding(10, 0, 10, 0);
			btnCSV.Size = new Size(158, 41);
			btnCSV.TabIndex = 7;
			btnCSV.Text = "Exportar CSV";
			btnCSV.TextAlign = ContentAlignment.MiddleRight;
			btnCSV.UseVisualStyleBackColor = true;
			btnCSV.Click += btnCVS_Click;
			// 
			// btnExcel
			// 
			btnExcel.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnExcel.Image = Properties.Resources.excelIcon16;
			btnExcel.ImageAlign = ContentAlignment.MiddleLeft;
			btnExcel.Location = new Point(675, 82);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(10, 0, 10, 0);
			btnExcel.Size = new Size(158, 42);
			btnExcel.TabIndex = 8;
			btnExcel.Text = "Exportar Excel";
			btnExcel.TextAlign = ContentAlignment.MiddleRight;
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btncargar.Image = (Image)resources.GetObject("btncargar.Image");
			btncargar.ImageAlign = ContentAlignment.MiddleLeft;
			btncargar.Location = new Point(27, 33);
			btncargar.Name = "btncargar";
			btncargar.Padding = new Padding(15, 0, 15, 0);
			btncargar.Size = new Size(159, 38);
			btncargar.TabIndex = 9;
			btncargar.Text = "Cargar Datos";
			btncargar.TextAlign = ContentAlignment.MiddleRight;
			btncargar.UseVisualStyleBackColor = true;
			btncargar.Click += btncargar_Click;
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
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvEmployee.ColumnHeadersHeight = 58;
			dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvEmployee.EnableHeadersVisualStyles = false;
			dgvEmployee.ImeMode = ImeMode.NoControl;
			dgvEmployee.Location = new Point(27, 430);
			dgvEmployee.Name = "dgvEmployee";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvEmployee.RowHeadersVisible = false;
			dgvEmployee.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvEmployee.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgvEmployee.Size = new Size(1277, 350);
			dgvEmployee.TabIndex = 17;
			dgvEmployee.CellValueChanged += dgvEmployee_CellValueChanged;
			// 
			// btnCalcularLibra
			// 
			btnCalcularLibra.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCalcularLibra.Image = (Image)resources.GetObject("btnCalcularLibra.Image");
			btnCalcularLibra.ImageAlign = ContentAlignment.MiddleLeft;
			btnCalcularLibra.Location = new Point(27, 33);
			btnCalcularLibra.Name = "btnCalcularLibra";
			btnCalcularLibra.Padding = new Padding(15, 0, 15, 0);
			btnCalcularLibra.Size = new Size(159, 38);
			btnCalcularLibra.TabIndex = 18;
			btnCalcularLibra.Text = "Cargar Libras";
			btnCalcularLibra.TextAlign = ContentAlignment.MiddleRight;
			btnCalcularLibra.UseVisualStyleBackColor = true;
			btnCalcularLibra.Click += btnCalcularLibra_Click;
			// 
			// cboLineas
			// 
			cboLineas.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLineas.FormattingEnabled = true;
			cboLineas.Location = new Point(140, 403);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(135, 23);
			cboLineas.TabIndex = 19;
			// 
			// lblLineas
			// 
			lblLineas.AutoSize = true;
			lblLineas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLineas.Location = new Point(32, 403);
			lblLineas.Name = "lblLineas";
			lblLineas.Size = new Size(63, 21);
			lblLineas.TabIndex = 20;
			lblLineas.Text = "Bandas:";
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(48, 28);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(77, 19);
			rbtEsparrago.TabIndex = 23;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(9, 66);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(33, 32);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(48, 70);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(45, 19);
			rbtUva.TabIndex = 24;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(9, 20);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(33, 27);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 25;
			pictureBox2.TabStop = false;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = SystemColors.Control;
			groupBox1.Controls.Add(rbtUva);
			groupBox1.Controls.Add(rbtEsparrago);
			groupBox1.Controls.Add(pictureBox2);
			groupBox1.Controls.Add(pictureBox1);
			groupBox1.Location = new Point(32, 110);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(173, 108);
			groupBox1.TabIndex = 28;
			groupBox1.TabStop = false;
			groupBox1.Text = "Tipo de Nomina";
			// 
			// gbCsv
			// 
			gbCsv.BackColor = SystemColors.Control;
			gbCsv.Controls.Add(lblLote);
			gbCsv.Controls.Add(cboLote);
			gbCsv.Controls.Add(lblReferencia);
			gbCsv.Controls.Add(btnCSV);
			gbCsv.Controls.Add(txbReferencia);
			gbCsv.Controls.Add(btnExcel);
			gbCsv.Location = new Point(27, 248);
			gbCsv.Margin = new Padding(3, 2, 3, 2);
			gbCsv.Name = "gbCsv";
			gbCsv.Padding = new Padding(3, 2, 3, 2);
			gbCsv.Size = new Size(907, 140);
			gbCsv.TabIndex = 29;
			gbCsv.TabStop = false;
			gbCsv.Text = "Generar Reporte CSV";
			// 
			// gbGenerar
			// 
			gbGenerar.BackColor = SystemColors.Control;
			gbGenerar.Controls.Add(btncargar);
			gbGenerar.Location = new Point(646, 130);
			gbGenerar.Margin = new Padding(3, 2, 3, 2);
			gbGenerar.Name = "gbGenerar";
			gbGenerar.Padding = new Padding(3, 2, 3, 2);
			gbGenerar.Size = new Size(214, 87);
			gbGenerar.TabIndex = 30;
			gbGenerar.TabStop = false;
			gbGenerar.Text = "Generar Nomina";
			// 
			// gbLibras
			// 
			gbLibras.BackColor = SystemColors.Control;
			gbLibras.Controls.Add(btnCalcularLibra);
			gbLibras.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			gbLibras.Location = new Point(389, 130);
			gbLibras.Margin = new Padding(3, 2, 3, 2);
			gbLibras.Name = "gbLibras";
			gbLibras.Padding = new Padding(3, 2, 3, 2);
			gbLibras.Size = new Size(214, 87);
			gbLibras.TabIndex = 31;
			gbLibras.TabStop = false;
			gbLibras.Text = "Procesar Libras del Día";
			// 
			// btnGuardar
			// 
			btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
			btnGuardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
			btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
			btnGuardar.Location = new Point(979, 382);
			btnGuardar.Name = "btnGuardar";
			btnGuardar.Padding = new Padding(6, 0, 6, 0);
			btnGuardar.Size = new Size(158, 41);
			btnGuardar.TabIndex = 21;
			btnGuardar.Text = "Actualizar Sueldo ";
			btnGuardar.TextAlign = ContentAlignment.MiddleRight;
			btnGuardar.UseVisualStyleBackColor = true;
			btnGuardar.Click += btnGuardar_Click;
			// 
			// lblTipoProceso
			// 
			lblTipoProceso.AutoSize = true;
			lblTipoProceso.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTipoProceso.Location = new Point(389, 38);
			lblTipoProceso.Name = "lblTipoProceso";
			lblTipoProceso.Size = new Size(0, 21);
			lblTipoProceso.TabIndex = 33;
			// 
			// FrmSemiAutomatedPayroll
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1329, 791);
			Controls.Add(lblTipoProceso);
			Controls.Add(btnGuardar);
			Controls.Add(gbLibras);
			Controls.Add(gbGenerar);
			Controls.Add(gbCsv);
			Controls.Add(lblLineas);
			Controls.Add(groupBox1);
			Controls.Add(dgvEmployee);
			Controls.Add(cboLineas);
			Controls.Add(lblencabezado);
			Controls.Add(dtpFecha);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmSemiAutomatedPayroll";
			Text = "Reporte de Empaque Central";
			Load += FrmSemiAutomatedPayroll_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			gbCsv.ResumeLayout(false);
			gbCsv.PerformLayout();
			gbGenerar.ResumeLayout(false);
			gbLibras.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblLote;
		private Label lblReferencia;
		public DateTimePicker dtpFecha;
		public TextBox txbReferencia;
		public ComboBox cboLote;
		public DataGridView dgvEmployee;
		private Label lblLineas;
		public ComboBox cboLineas;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		public RadioButton rbtEsparrago;
		public RadioButton rbtUva;
		private GroupBox groupBox1;
		public GroupBox gbCsv;
		public Button btncargar;
		public Button btnCalcularLibra;
		public Button btnCSV;
		public Button btnExcel;
		public Label lblencabezado;
		public GroupBox gbGenerar;
		public GroupBox gbLibras;
		public Button btnGuardar;
		public Label lblTipoProceso;
	}
}
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			lblLote = new Label();
			lblReferencia = new Label();
			dtpFecha = new DateTimePicker();
			txbReferencia = new TextBox();
			cboLote = new ComboBox();
			lbencabezado = new Label();
			btnCVS = new Button();
			btnExcel = new Button();
			btncargar = new Button();
			dgvEmployee = new DataGridView();
			btnCalcularLibra = new Button();
			cboLineas = new ComboBox();
			lblLineas = new Label();
			pllCsv = new Panel();
			label1 = new Label();
			btnFestivos = new Button();
			lblTipodeNomina = new Label();
			rbtEsparrago = new RadioButton();
			pictureBox1 = new PictureBox();
			rbtUva = new RadioButton();
			pictureBox2 = new PictureBox();
			lblLibras = new Label();
			lblAccion = new Label();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			pllCsv.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// lblLote
			// 
			lblLote.AutoSize = true;
			lblLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLote.Location = new Point(60, 36);
			lblLote.Name = "lblLote";
			lblLote.Size = new Size(47, 21);
			lblLote.TabIndex = 0;
			lblLote.Text = "Lote :";
			// 
			// lblReferencia
			// 
			lblReferencia.AutoSize = true;
			lblReferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblReferencia.Location = new Point(60, 92);
			lblReferencia.Name = "lblReferencia";
			lblReferencia.Size = new Size(90, 21);
			lblReferencia.TabIndex = 1;
			lblReferencia.Text = "Referencia :";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(599, 73);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(319, 23);
			dtpFecha.TabIndex = 2;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// txbReferencia
			// 
			txbReferencia.Location = new Point(156, 94);
			txbReferencia.Multiline = true;
			txbReferencia.Name = "txbReferencia";
			txbReferencia.Size = new Size(135, 25);
			txbReferencia.TabIndex = 3;
			// 
			// cboLote
			// 
			cboLote.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(113, 38);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(135, 23);
			cboLote.TabIndex = 4;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(300, 9);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(329, 32);
			lbencabezado.TabIndex = 5;
			lbencabezado.Text = "Reporte de Empaque Central";
			// 
			// btnCVS
			// 
			btnCVS.BackgroundImageLayout = ImageLayout.Stretch;
			btnCVS.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCVS.Image = (Image)resources.GetObject("btnCVS.Image");
			btnCVS.ImageAlign = ContentAlignment.MiddleLeft;
			btnCVS.Location = new Point(676, 20);
			btnCVS.Name = "btnCVS";
			btnCVS.Padding = new Padding(10, 0, 10, 0);
			btnCVS.Size = new Size(158, 41);
			btnCVS.TabIndex = 7;
			btnCVS.Text = "Exportar CSV";
			btnCVS.TextAlign = ContentAlignment.MiddleRight;
			btnCVS.UseVisualStyleBackColor = true;
			btnCVS.Click += btnCVS_Click;
			// 
			// btnExcel
			// 
			btnExcel.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnExcel.Image = Properties.Resources.excelIcon16;
			btnExcel.ImageAlign = ContentAlignment.MiddleLeft;
			btnExcel.Location = new Point(676, 81);
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
			btncargar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btncargar.Image = (Image)resources.GetObject("btncargar.Image");
			btncargar.ImageAlign = ContentAlignment.MiddleLeft;
			btncargar.Location = new Point(616, 204);
			btncargar.Name = "btncargar";
			btncargar.Padding = new Padding(10, 0, 10, 0);
			btncargar.Size = new Size(148, 38);
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
			dgvEmployee.Location = new Point(27, 465);
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
			dgvEmployee.Size = new Size(1277, 338);
			dgvEmployee.TabIndex = 17;
			// 
			// btnCalcularLibra
			// 
			btnCalcularLibra.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCalcularLibra.Location = new Point(408, 204);
			btnCalcularLibra.Name = "btnCalcularLibra";
			btnCalcularLibra.Size = new Size(148, 38);
			btnCalcularLibra.TabIndex = 18;
			btnCalcularLibra.Text = "Cargar Libras";
			btnCalcularLibra.UseVisualStyleBackColor = true;
			btnCalcularLibra.Click += btnCalcularLibra_Click;
			// 
			// cboLineas
			// 
			cboLineas.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLineas.FormattingEnabled = true;
			cboLineas.Location = new Point(787, 436);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(131, 23);
			cboLineas.TabIndex = 19;
			// 
			// lblLineas
			// 
			lblLineas.AutoSize = true;
			lblLineas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLineas.Location = new Point(718, 438);
			lblLineas.Name = "lblLineas";
			lblLineas.Size = new Size(63, 21);
			lblLineas.TabIndex = 20;
			lblLineas.Text = "Bandas:";
			// 
			// pllCsv
			// 
			pllCsv.BackColor = SystemColors.ActiveCaption;
			pllCsv.BorderStyle = BorderStyle.FixedSingle;
			pllCsv.Controls.Add(lblLote);
			pllCsv.Controls.Add(cboLote);
			pllCsv.Controls.Add(lblReferencia);
			pllCsv.Controls.Add(txbReferencia);
			pllCsv.Controls.Add(btnExcel);
			pllCsv.Controls.Add(btnCVS);
			pllCsv.Controls.Add(label1);
			pllCsv.Location = new Point(27, 267);
			pllCsv.Name = "pllCsv";
			pllCsv.Size = new Size(891, 151);
			pllCsv.TabIndex = 21;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(349, 20);
			label1.Name = "label1";
			label1.Size = new Size(165, 21);
			label1.TabIndex = 0;
			label1.Text = "Generar Reporte CSV";
			// 
			// btnFestivos
			// 
			btnFestivos.BackgroundImageLayout = ImageLayout.Stretch;
			btnFestivos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnFestivos.Image = (Image)resources.GetObject("btnFestivos.Image");
			btnFestivos.ImageAlign = ContentAlignment.MiddleLeft;
			btnFestivos.Location = new Point(770, 204);
			btnFestivos.Name = "btnFestivos";
			btnFestivos.Padding = new Padding(10, 0, 10, 0);
			btnFestivos.Size = new Size(148, 38);
			btnFestivos.TabIndex = 9;
			btnFestivos.Text = "Festivos";
			btnFestivos.TextAlign = ContentAlignment.MiddleRight;
			btnFestivos.UseVisualStyleBackColor = true;
			btnFestivos.Click += btnFestivos_Click;
			// 
			// lblTipodeNomina
			// 
			lblTipodeNomina.AutoSize = true;
			lblTipodeNomina.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTipodeNomina.Location = new Point(27, 73);
			lblTipodeNomina.Name = "lblTipodeNomina";
			lblTipodeNomina.Size = new Size(131, 21);
			lblTipodeNomina.TabIndex = 22;
			lblTipodeNomina.Text = "Tipo de Nomina:";
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(75, 113);
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
			pictureBox1.Location = new Point(36, 151);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(33, 32);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(75, 155);
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
			pictureBox2.Location = new Point(36, 105);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(33, 27);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 25;
			pictureBox2.TabStop = false;
			// 
			// lblLibras
			// 
			lblLibras.AutoSize = true;
			lblLibras.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblLibras.Location = new Point(408, 186);
			lblLibras.Name = "lblLibras";
			lblLibras.Size = new Size(134, 15);
			lblLibras.TabIndex = 26;
			lblLibras.Text = "Capture las libras del día";
			// 
			// lblAccion
			// 
			lblAccion.AutoSize = true;
			lblAccion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblAccion.Location = new Point(724, 186);
			lblAccion.Name = "lblAccion";
			lblAccion.Size = new Size(92, 15);
			lblAccion.TabIndex = 27;
			lblAccion.Text = "Generar nómina";
			// 
			// FrmSemiAutomatedPayroll
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1329, 815);
			Controls.Add(lblAccion);
			Controls.Add(lblLibras);
			Controls.Add(pictureBox1);
			Controls.Add(pictureBox2);
			Controls.Add(rbtUva);
			Controls.Add(lblTipodeNomina);
			Controls.Add(rbtEsparrago);
			Controls.Add(btnFestivos);
			Controls.Add(pllCsv);
			Controls.Add(btncargar);
			Controls.Add(lblLineas);
			Controls.Add(cboLineas);
			Controls.Add(btnCalcularLibra);
			Controls.Add(dgvEmployee);
			Controls.Add(lbencabezado);
			Controls.Add(dtpFecha);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmSemiAutomatedPayroll";
			Text = "Reporte de Empaque Central";
			Load += FrmSemiAutomatedPayroll_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			pllCsv.ResumeLayout(false);
			pllCsv.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblLote;
		private Label lblReferencia;
		private Label lbencabezado;
		private Button btnCVS;
		private Button btnExcel;
		private Button btncargar;
		public DateTimePicker dtpFecha;
		public TextBox txbReferencia;
		public ComboBox cboLote;
		public DataGridView dgvEmployee;
		private Button btnCalcularLibra;
		private Label lblLineas;
		public ComboBox cboLineas;
		private Label label1;
		private Button btnFestivos;
		private Label lblTipodeNomina;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		private Label lblLibras;
		private Label lblAccion;
		public RadioButton rbtEsparrago;
		public RadioButton rbtUva;
		public Panel pllCsv;
	}
}
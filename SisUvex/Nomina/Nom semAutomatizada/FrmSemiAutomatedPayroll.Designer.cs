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
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
			btnCerrar = new Button();
			lblAvisoCierre = new Label();
			plTitulo = new Panel();
			plCerrar = new Panel();
			pnCerrar = new Panel();
			lblEstado = new Label();
			pbCirculo = new PictureBox();
			label1 = new Label();
			gbFecha = new GroupBox();
			gbSueldos = new GroupBox();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			groupBox1.SuspendLayout();
			gbCsv.SuspendLayout();
			gbGenerar.SuspendLayout();
			gbLibras.SuspendLayout();
			plTitulo.SuspendLayout();
			plCerrar.SuspendLayout();
			pnCerrar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbCirculo).BeginInit();
			gbFecha.SuspendLayout();
			gbSueldos.SuspendLayout();
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
			dtpFecha.Location = new Point(42, 50);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(246, 23);
			dtpFecha.TabIndex = 2;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// txbReferencia
			// 
			txbReferencia.Location = new Point(165, 82);
			txbReferencia.Multiline = true;
			txbReferencia.Name = "txbReferencia";
			txbReferencia.Size = new Size(197, 25);
			txbReferencia.TabIndex = 3;
			// 
			// cboLote
			// 
			cboLote.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(165, 34);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(197, 23);
			cboLote.TabIndex = 4;
			// 
			// lblencabezado
			// 
			lblencabezado.AutoSize = true;
			lblencabezado.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblencabezado.ForeColor = SystemColors.ActiveCaptionText;
			lblencabezado.Location = new Point(116, 4);
			lblencabezado.Name = "lblencabezado";
			lblencabezado.Size = new Size(386, 37);
			lblencabezado.TabIndex = 5;
			lblencabezado.Text = "Reporte de Empaque Central";
			// 
			// btnCSV
			// 
			btnCSV.BackgroundImageLayout = ImageLayout.Stretch;
			btnCSV.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCSV.Image = (Image)resources.GetObject("btnCSV.Image");
			btnCSV.ImageAlign = ContentAlignment.MiddleLeft;
			btnCSV.Location = new Point(520, 21);
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
			btnExcel.Location = new Point(520, 82);
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
			btncargar.Location = new Point(29, 40);
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
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			dgvEmployee.DefaultCellStyle = dataGridViewCellStyle2;
			dgvEmployee.EnableHeadersVisualStyles = false;
			dgvEmployee.ImeMode = ImeMode.NoControl;
			dgvEmployee.Location = new Point(27, 439);
			dgvEmployee.Name = "dgvEmployee";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvEmployee.RowHeadersVisible = false;
			dgvEmployee.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvEmployee.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgvEmployee.Size = new Size(1149, 341);
			dgvEmployee.TabIndex = 17;
			dgvEmployee.CellValueChanged += dgvEmployee_CellValueChanged;
			// 
			// btnCalcularLibra
			// 
			btnCalcularLibra.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCalcularLibra.Image = (Image)resources.GetObject("btnCalcularLibra.Image");
			btnCalcularLibra.ImageAlign = ContentAlignment.MiddleLeft;
			btnCalcularLibra.Location = new Point(27, 40);
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
			cboLineas.Location = new Point(121, 410);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(135, 23);
			cboLineas.TabIndex = 19;
			// 
			// lblLineas
			// 
			lblLineas.AutoSize = true;
			lblLineas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLineas.Location = new Point(27, 412);
			lblLineas.Name = "lblLineas";
			lblLineas.Size = new Size(63, 21);
			lblLineas.TabIndex = 20;
			lblLineas.Text = "Bandas:";
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(56, 34);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(77, 19);
			rbtEsparrago.TabIndex = 23;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			rbtEsparrago.CheckedChanged += rbtEsparrago_CheckedChanged;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(17, 72);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(33, 32);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(56, 76);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(45, 19);
			rbtUva.TabIndex = 24;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			rbtUva.CheckedChanged += rbtUva_CheckedChanged;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(17, 26);
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
			groupBox1.Location = new Point(27, 127);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(251, 124);
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
			gbCsv.Location = new Point(27, 265);
			gbCsv.Margin = new Padding(3, 2, 3, 2);
			gbCsv.Name = "gbCsv";
			gbCsv.Padding = new Padding(3, 2, 3, 2);
			gbCsv.Size = new Size(756, 140);
			gbCsv.TabIndex = 29;
			gbCsv.TabStop = false;
			gbCsv.Text = "Generar Reporte CSV";
			// 
			// gbGenerar
			// 
			gbGenerar.BackColor = SystemColors.Control;
			gbGenerar.Controls.Add(btncargar);
			gbGenerar.Location = new Point(919, 127);
			gbGenerar.Margin = new Padding(3, 2, 3, 2);
			gbGenerar.Name = "gbGenerar";
			gbGenerar.Padding = new Padding(3, 2, 3, 2);
			gbGenerar.Size = new Size(214, 124);
			gbGenerar.TabIndex = 30;
			gbGenerar.TabStop = false;
			gbGenerar.Text = "Generar Nomina";
			// 
			// gbLibras
			// 
			gbLibras.BackColor = SystemColors.Control;
			gbLibras.Controls.Add(btnCalcularLibra);
			gbLibras.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			gbLibras.Location = new Point(674, 127);
			gbLibras.Margin = new Padding(3, 2, 3, 2);
			gbLibras.Name = "gbLibras";
			gbLibras.Padding = new Padding(3, 2, 3, 2);
			gbLibras.Size = new Size(214, 124);
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
			btnGuardar.Location = new Point(82, 49);
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
			lblTipoProceso.Location = new Point(156, 45);
			lblTipoProceso.Name = "lblTipoProceso";
			lblTipoProceso.Size = new Size(0, 21);
			lblTipoProceso.TabIndex = 33;
			// 
			// btnCerrar
			// 
			btnCerrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
			btnCerrar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCerrar.Location = new Point(21, 17);
			btnCerrar.Name = "btnCerrar";
			btnCerrar.Padding = new Padding(15, 0, 15, 0);
			btnCerrar.Size = new Size(159, 38);
			btnCerrar.TabIndex = 9;
			btnCerrar.Text = "Cerrar Nomina";
			btnCerrar.TextAlign = ContentAlignment.MiddleRight;
			btnCerrar.UseVisualStyleBackColor = true;
			btnCerrar.Click += btnCerrar_Click;
			// 
			// lblAvisoCierre
			// 
			lblAvisoCierre.AutoSize = true;
			lblAvisoCierre.Location = new Point(649, 236);
			lblAvisoCierre.Name = "lblAvisoCierre";
			lblAvisoCierre.Size = new Size(0, 15);
			lblAvisoCierre.TabIndex = 34;
			// 
			// plTitulo
			// 
			plTitulo.Controls.Add(plCerrar);
			plTitulo.Controls.Add(pnCerrar);
			plTitulo.Controls.Add(lblencabezado);
			plTitulo.Controls.Add(lblTipoProceso);
			plTitulo.Location = new Point(12, 12);
			plTitulo.Name = "plTitulo";
			plTitulo.Size = new Size(1171, 100);
			plTitulo.TabIndex = 35;
			plTitulo.Resize += plTitulo_Resize;
			// 
			// plCerrar
			// 
			plCerrar.BackColor = SystemColors.ControlLight;
			plCerrar.Controls.Add(btnCerrar);
			plCerrar.Location = new Point(928, 11);
			plCerrar.Name = "plCerrar";
			plCerrar.Size = new Size(200, 72);
			plCerrar.TabIndex = 33;
			plCerrar.Resize += plCerrar_Resize;
			// 
			// pnCerrar
			// 
			pnCerrar.BackColor = SystemColors.HighlightText;
			pnCerrar.Controls.Add(lblEstado);
			pnCerrar.Controls.Add(pbCirculo);
			pnCerrar.Controls.Add(label1);
			pnCerrar.Location = new Point(683, 11);
			pnCerrar.Name = "pnCerrar";
			pnCerrar.Size = new Size(200, 72);
			pnCerrar.TabIndex = 32;
			pnCerrar.Resize += pnCerrar_Resize;
			// 
			// lblEstado
			// 
			lblEstado.AutoSize = true;
			lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEstado.Location = new Point(81, 37);
			lblEstado.Name = "lblEstado";
			lblEstado.Size = new Size(71, 21);
			lblEstado.TabIndex = 2;
			lblEstado.Text = "ESTADO";
			// 
			// pbCirculo
			// 
			pbCirculo.BackgroundImageLayout = ImageLayout.Zoom;
			pbCirculo.Location = new Point(54, 37);
			pbCirculo.Name = "pbCirculo";
			pbCirculo.Size = new Size(30, 27);
			pbCirculo.SizeMode = PictureBoxSizeMode.Zoom;
			pbCirculo.TabIndex = 1;
			pbCirculo.TabStop = false;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = SystemColors.ActiveCaptionText;
			label1.Location = new Point(37, 10);
			label1.Name = "label1";
			label1.Size = new Size(135, 17);
			label1.TabIndex = 0;
			label1.Text = "ESTADO DE NÓMINA";
			// 
			// gbFecha
			// 
			gbFecha.BackColor = SystemColors.Control;
			gbFecha.Controls.Add(dtpFecha);
			gbFecha.Location = new Point(303, 127);
			gbFecha.Margin = new Padding(3, 2, 3, 2);
			gbFecha.Name = "gbFecha";
			gbFecha.Padding = new Padding(3, 2, 3, 2);
			gbFecha.Size = new Size(346, 124);
			gbFecha.TabIndex = 31;
			gbFecha.TabStop = false;
			gbFecha.Text = "Fecha de Trabajo ";
			// 
			// gbSueldos
			// 
			gbSueldos.BackColor = SystemColors.Control;
			gbSueldos.Controls.Add(btnGuardar);
			gbSueldos.Location = new Point(816, 265);
			gbSueldos.Margin = new Padding(3, 2, 3, 2);
			gbSueldos.Name = "gbSueldos";
			gbSueldos.Padding = new Padding(3, 2, 3, 2);
			gbSueldos.Size = new Size(317, 140);
			gbSueldos.TabIndex = 31;
			gbSueldos.TabStop = false;
			gbSueldos.Text = "Actualizar Sueldo de Empleados";
			// 
			// FrmSemiAutomatedPayroll
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1201, 791);
			Controls.Add(gbSueldos);
			Controls.Add(gbFecha);
			Controls.Add(plTitulo);
			Controls.Add(lblAvisoCierre);
			Controls.Add(gbLibras);
			Controls.Add(gbGenerar);
			Controls.Add(gbCsv);
			Controls.Add(lblLineas);
			Controls.Add(groupBox1);
			Controls.Add(dgvEmployee);
			Controls.Add(cboLineas);
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
			plTitulo.ResumeLayout(false);
			plTitulo.PerformLayout();
			plCerrar.ResumeLayout(false);
			pnCerrar.ResumeLayout(false);
			pnCerrar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbCirculo).EndInit();
			gbFecha.ResumeLayout(false);
			gbSueldos.ResumeLayout(false);
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
		public Button btnCerrar;
		public Label lblAvisoCierre;
		public GroupBox groupBox3;
		public GroupBox gbSueldos;
		public GroupBox gbFecha;
		public Panel plTitulo;
		private Label label2;
		private Label label1;
		public Label lblEstado;
		public PictureBox pbCirculo;
		public Panel pnCerrar;
		public Panel plCerrar;
	}
}
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
			lblencabezado = new Label();
			btnCSV = new Button();
			btnExcel = new Button();
			btncargar = new Button();
			dgvEmployee = new DataGridView();
			btnCalcularLibra = new Button();
			cboLineas = new ComboBox();
			lblLineas = new Label();
			btnFestivos = new Button();
			rbtEsparrago = new RadioButton();
			pictureBox1 = new PictureBox();
			rbtUva = new RadioButton();
			pictureBox2 = new PictureBox();
			groupBox1 = new GroupBox();
			gbCsv = new GroupBox();
			gbGenerar = new GroupBox();
			gbLibras = new GroupBox();
			btnGuardar = new Button();
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
			lblLote.Location = new Point(65, 41);
			lblLote.Name = "lblLote";
			lblLote.Size = new Size(59, 28);
			lblLote.TabIndex = 0;
			lblLote.Text = "Lote :";
			// 
			// lblReferencia
			// 
			lblReferencia.AutoSize = true;
			lblReferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblReferencia.Location = new Point(65, 114);
			lblReferencia.Name = "lblReferencia";
			lblReferencia.Size = new Size(110, 28);
			lblReferencia.TabIndex = 1;
			lblReferencia.Text = "Referencia :";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(382, 71);
			dtpFecha.Margin = new Padding(3, 4, 3, 4);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(364, 27);
			dtpFecha.TabIndex = 2;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// txbReferencia
			// 
			txbReferencia.Location = new Point(189, 110);
			txbReferencia.Margin = new Padding(3, 4, 3, 4);
			txbReferencia.Multiline = true;
			txbReferencia.Name = "txbReferencia";
			txbReferencia.Size = new Size(154, 32);
			txbReferencia.TabIndex = 3;
			// 
			// cboLote
			// 
			cboLote.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(189, 45);
			cboLote.Margin = new Padding(3, 4, 3, 4);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(154, 28);
			cboLote.TabIndex = 4;
			// 
			// lblencabezado
			// 
			lblencabezado.AutoSize = true;
			lblencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblencabezado.Location = new Point(366, 9);
			lblencabezado.Name = "lblencabezado";
			lblencabezado.Size = new Size(413, 41);
			lblencabezado.TabIndex = 5;
			lblencabezado.Text = "Reporte de Empaque Central";
			// 
			// btnCSV
			// 
			btnCSV.BackgroundImageLayout = ImageLayout.Stretch;
			btnCSV.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCSV.Image = (Image)resources.GetObject("btnCSV.Image");
			btnCSV.ImageAlign = ContentAlignment.MiddleLeft;
			btnCSV.Location = new Point(771, 28);
			btnCSV.Margin = new Padding(3, 4, 3, 4);
			btnCSV.Name = "btnCSV";
			btnCSV.Padding = new Padding(11, 0, 11, 0);
			btnCSV.Size = new Size(181, 55);
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
			btnExcel.Location = new Point(771, 110);
			btnExcel.Margin = new Padding(3, 4, 3, 4);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(11, 0, 11, 0);
			btnExcel.Size = new Size(181, 56);
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
			btncargar.Location = new Point(31, 44);
			btncargar.Margin = new Padding(3, 4, 3, 4);
			btncargar.Name = "btncargar";
			btncargar.Padding = new Padding(11, 0, 11, 0);
			btncargar.Size = new Size(182, 51);
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
			dgvEmployee.Location = new Point(31, 573);
			dgvEmployee.Margin = new Padding(3, 4, 3, 4);
			dgvEmployee.Name = "dgvEmployee";
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
			dgvEmployee.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgvEmployee.Size = new Size(1459, 466);
			dgvEmployee.TabIndex = 17;
			dgvEmployee.CellValueChanged += dgvEmployee_CellValueChanged;
			// 
			// btnCalcularLibra
			// 
			btnCalcularLibra.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCalcularLibra.Location = new Point(26, 44);
			btnCalcularLibra.Margin = new Padding(3, 4, 3, 4);
			btnCalcularLibra.Name = "btnCalcularLibra";
			btnCalcularLibra.Size = new Size(169, 51);
			btnCalcularLibra.TabIndex = 18;
			btnCalcularLibra.Text = "Cargar Libras";
			btnCalcularLibra.UseVisualStyleBackColor = true;
			btnCalcularLibra.Click += btnCalcularLibra_Click;
			// 
			// cboLineas
			// 
			cboLineas.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLineas.FormattingEnabled = true;
			cboLineas.Location = new Point(160, 537);
			cboLineas.Margin = new Padding(3, 4, 3, 4);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(154, 28);
			cboLineas.TabIndex = 19;
			// 
			// lblLineas
			// 
			lblLineas.AutoSize = true;
			lblLineas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLineas.Location = new Point(36, 537);
			lblLineas.Name = "lblLineas";
			lblLineas.Size = new Size(78, 28);
			lblLineas.TabIndex = 20;
			lblLineas.Text = "Bandas:";
			// 
			// btnFestivos
			// 
			btnFestivos.BackgroundImageLayout = ImageLayout.Stretch;
			btnFestivos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnFestivos.Image = (Image)resources.GetObject("btnFestivos.Image");
			btnFestivos.ImageAlign = ContentAlignment.MiddleLeft;
			btnFestivos.Location = new Point(239, 44);
			btnFestivos.Margin = new Padding(3, 4, 3, 4);
			btnFestivos.Name = "btnFestivos";
			btnFestivos.Padding = new Padding(15, 0, 15, 0);
			btnFestivos.Size = new Size(169, 51);
			btnFestivos.TabIndex = 9;
			btnFestivos.Text = "Festivos";
			btnFestivos.TextAlign = ContentAlignment.MiddleRight;
			btnFestivos.UseVisualStyleBackColor = true;
			btnFestivos.Click += btnFestivos_Click;
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(55, 38);
			rbtEsparrago.Margin = new Padding(3, 4, 3, 4);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(97, 24);
			rbtEsparrago.TabIndex = 23;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(10, 88);
			pictureBox1.Margin = new Padding(3, 4, 3, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(38, 43);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(55, 94);
			rbtUva.Margin = new Padding(3, 4, 3, 4);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(55, 24);
			rbtUva.TabIndex = 24;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(10, 27);
			pictureBox2.Margin = new Padding(3, 4, 3, 4);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(38, 36);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 25;
			pictureBox2.TabStop = false;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(rbtUva);
			groupBox1.Controls.Add(rbtEsparrago);
			groupBox1.Controls.Add(pictureBox2);
			groupBox1.Controls.Add(pictureBox1);
			groupBox1.Location = new Point(31, 147);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(198, 144);
			groupBox1.TabIndex = 28;
			groupBox1.TabStop = false;
			groupBox1.Text = "Tipo de Nomina";
			// 
			// gbCsv
			// 
			gbCsv.Controls.Add(lblLote);
			gbCsv.Controls.Add(cboLote);
			gbCsv.Controls.Add(lblReferencia);
			gbCsv.Controls.Add(btnCSV);
			gbCsv.Controls.Add(txbReferencia);
			gbCsv.Controls.Add(btnExcel);
			gbCsv.Location = new Point(31, 331);
			gbCsv.Name = "gbCsv";
			gbCsv.Size = new Size(1037, 186);
			gbCsv.TabIndex = 29;
			gbCsv.TabStop = false;
			gbCsv.Text = "Generar Reporte CSV";
			// 
			// gbGenerar
			// 
			gbGenerar.Controls.Add(btncargar);
			gbGenerar.Controls.Add(btnFestivos);
			gbGenerar.Location = new Point(630, 175);
			gbGenerar.Name = "gbGenerar";
			gbGenerar.Size = new Size(438, 116);
			gbGenerar.TabIndex = 30;
			gbGenerar.TabStop = false;
			gbGenerar.Text = "Generar Nomina";
			// 
			// gbLibras
			// 
			gbLibras.Controls.Add(btnCalcularLibra);
			gbLibras.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			gbLibras.Location = new Point(366, 175);
			gbLibras.Name = "gbLibras";
			gbLibras.Size = new Size(222, 116);
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
			btnGuardar.Location = new Point(1119, 510);
			btnGuardar.Margin = new Padding(3, 4, 3, 4);
			btnGuardar.Name = "btnGuardar";
			btnGuardar.Padding = new Padding(7, 0, 7, 0);
			btnGuardar.Size = new Size(181, 55);
			btnGuardar.TabIndex = 21;
			btnGuardar.Text = "Actualizar Sueldo ";
			btnGuardar.TextAlign = ContentAlignment.MiddleRight;
			btnGuardar.UseVisualStyleBackColor = true;
			btnGuardar.Click += btnGuardar_Click;
			// 
			// FrmSemiAutomatedPayroll
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1519, 1055);
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
			Margin = new Padding(3, 4, 3, 4);
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
		private Button btnFestivos;
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
	}
}
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
			rbtEsparrago = new RadioButton();
			groupBox1 = new GroupBox();
			label1 = new Label();
			groupBox2 = new GroupBox();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// lblReporteEmpacadores
			// 
			lblReporteEmpacadores.AutoSize = true;
			lblReporteEmpacadores.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporteEmpacadores.Location = new Point(12, 9);
			lblReporteEmpacadores.Name = "lblReporteEmpacadores";
			lblReporteEmpacadores.Size = new Size(321, 37);
			lblReporteEmpacadores.TabIndex = 0;
			lblReporteEmpacadores.Text = "Reporte de Empacadores";
			// 
			// lblcodigo
			// 
			lblcodigo.AutoSize = true;
			lblcodigo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblcodigo.Location = new Point(5, 113);
			lblcodigo.Name = "lblcodigo";
			lblcodigo.Size = new Size(69, 23);
			lblcodigo.TabIndex = 1;
			lblcodigo.Text = "Codigo:";
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(120, 114);
			txbCodigo.Margin = new Padding(3, 4, 3, 4);
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(133, 27);
			txbCodigo.TabIndex = 14;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblEmpleado.Location = new Point(3, 150);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(90, 23);
			lblEmpleado.TabIndex = 15;
			lblEmpleado.Text = "Empleado:";
			// 
			// txbNombre
			// 
			txbNombre.Location = new Point(120, 152);
			txbNombre.Margin = new Padding(3, 4, 3, 4);
			txbNombre.Name = "txbNombre";
			txbNombre.ReadOnly = true;
			txbNombre.Size = new Size(294, 27);
			txbNombre.TabIndex = 16;
			// 
			// lblLinea
			// 
			lblLinea.AutoSize = true;
			lblLinea.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblLinea.Location = new Point(5, 75);
			lblLinea.Name = "lblLinea";
			lblLinea.Size = new Size(62, 23);
			lblLinea.TabIndex = 17;
			lblLinea.Text = "Banda:";
			// 
			// cboLineas
			// 
			cboLineas.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLineas.FormattingEnabled = true;
			cboLineas.Location = new Point(120, 72);
			cboLineas.Margin = new Padding(3, 4, 3, 4);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(133, 28);
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
			dgvEmployee.Location = new Point(12, 293);
			dgvEmployee.Margin = new Padding(3, 4, 3, 4);
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
			dgvEmployee.Size = new Size(1039, 746);
			dgvEmployee.TabIndex = 24;
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(261, 113);
			btnEmpleado.Margin = new Padding(3, 4, 3, 4);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(26, 31);
			btnEmpleado.TabIndex = 25;
			btnEmpleado.UseVisualStyleBackColor = true;
			btnEmpleado.Click += btnEmpleado_Click;
			// 
			// btnExcelBandas
			// 
			btnExcelBandas.BackgroundImage = (Image)resources.GetObject("btnExcelBandas.BackgroundImage");
			btnExcelBandas.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcelBandas.Location = new Point(261, 72);
			btnExcelBandas.Margin = new Padding(3, 4, 3, 4);
			btnExcelBandas.Name = "btnExcelBandas";
			btnExcelBandas.Size = new Size(26, 31);
			btnExcelBandas.TabIndex = 26;
			btnExcelBandas.UseVisualStyleBackColor = true;
			btnExcelBandas.Click += btnExcelBandas_Click;
			// 
			// btnPdfEmpleado
			// 
			btnPdfEmpleado.BackgroundImage = (Image)resources.GetObject("btnPdfEmpleado.BackgroundImage");
			btnPdfEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnPdfEmpleado.Location = new Point(422, 151);
			btnPdfEmpleado.Margin = new Padding(3, 4, 3, 4);
			btnPdfEmpleado.Name = "btnPdfEmpleado";
			btnPdfEmpleado.Size = new Size(26, 31);
			btnPdfEmpleado.TabIndex = 27;
			btnPdfEmpleado.UseVisualStyleBackColor = true;
			btnPdfEmpleado.Click += btnExcelEmpleado_Click;
			// 
			// lblSemana
			// 
			lblSemana.AutoSize = true;
			lblSemana.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblSemana.Location = new Point(5, 31);
			lblSemana.Name = "lblSemana";
			lblSemana.Size = new Size(75, 23);
			lblSemana.TabIndex = 28;
			lblSemana.Text = "Semana:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(120, 28);
			cboSemana.Margin = new Padding(3, 4, 3, 4);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(268, 28);
			cboSemana.TabIndex = 29;
			cboSemana.SelectedIndexChanged += cboSemana_SelectedIndexChanged;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(26, 113);
			pictureBox1.Margin = new Padding(3, 4, 3, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(38, 43);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 33;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(26, 40);
			pictureBox2.Margin = new Padding(3, 4, 3, 4);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(38, 36);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 34;
			pictureBox2.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(71, 118);
			rbtUva.Margin = new Padding(3, 4, 3, 4);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(55, 24);
			rbtUva.TabIndex = 32;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(71, 50);
			rbtEsparrago.Margin = new Padding(3, 4, 3, 4);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(97, 24);
			rbtEsparrago.TabIndex = 31;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(pictureBox1);
			groupBox1.Controls.Add(rbtEsparrago);
			groupBox1.Controls.Add(pictureBox2);
			groupBox1.Controls.Add(rbtUva);
			groupBox1.Location = new Point(33, 97);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(211, 189);
			groupBox1.TabIndex = 35;
			groupBox1.TabStop = false;
			groupBox1.Text = "Tipo de Nomina";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(13, 51);
			label1.Name = "label1";
			label1.Size = new Size(526, 17);
			label1.TabIndex = 36;
			label1.Text = "Consulta e imprime reportes de producción por empleado, línea o para todas las líneas.";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(cboLineas);
			groupBox2.Controls.Add(lblcodigo);
			groupBox2.Controls.Add(txbCodigo);
			groupBox2.Controls.Add(cboSemana);
			groupBox2.Controls.Add(lblEmpleado);
			groupBox2.Controls.Add(lblSemana);
			groupBox2.Controls.Add(txbNombre);
			groupBox2.Controls.Add(btnPdfEmpleado);
			groupBox2.Controls.Add(lblLinea);
			groupBox2.Controls.Add(btnExcelBandas);
			groupBox2.Controls.Add(btnEmpleado);
			groupBox2.Location = new Point(275, 97);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(478, 189);
			groupBox2.TabIndex = 37;
			groupBox2.TabStop = false;
			groupBox2.Text = "Filtros";
			// 
			// FrmPackersReport
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1093, 1055);
			Controls.Add(groupBox2);
			Controls.Add(label1);
			Controls.Add(groupBox1);
			Controls.Add(dgvEmployee);
			Controls.Add(lblReporteEmpacadores);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmPackersReport";
			Text = "Reporte de cajas ";
			Load += FrmPackersReport_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
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
		public RadioButton rbtEsparrago;
		private GroupBox groupBox1;
		private Label label1;
		private GroupBox groupBox2;
	}
}
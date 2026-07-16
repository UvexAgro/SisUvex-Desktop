namespace SisUvex.Nomina.Nom_Reporte_de_sueldos_diarios
{
	partial class FrmNomsemana
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
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNomsemana));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			btnExcel = new Button();
			btnExcelBandas = new Button();
			txbNombre = new TextBox();
			lblEmpleado = new Label();
			btnEmpleado = new Button();
			txbCodigo = new TextBox();
			lblcodigo = new Label();
			lblSemana = new Label();
			cboSemana = new ComboBox();
			dgvEmployee = new DataGridView();
			lblReporteEmpacadores = new Label();
			btncargar = new Button();
			btnEmployee = new Button();
			toolTip1 = new ToolTip(components);
			btnAñadir = new Button();
			dgvListaEmpleado = new DataGridView();
			panel1 = new Panel();
			lblempleados = new Label();
			panellbl = new Panel();
			lblbuscar = new Label();
			lblFiltro = new Label();
			label1 = new Label();
			pictureBox1 = new PictureBox();
			pictureBox2 = new PictureBox();
			rbtUva = new RadioButton();
			lblTipodeNomina = new Label();
			rbtEsparrago = new RadioButton();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvListaEmpleado).BeginInit();
			panel1.SuspendLayout();
			panellbl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// btnExcel
			// 
			btnExcel.BackgroundImage = Properties.Resources.excelIcon;
			btnExcel.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcel.Location = new Point(254, 134);
			btnExcel.Name = "btnExcel";
			btnExcel.Size = new Size(23, 23);
			btnExcel.TabIndex = 51;
			toolTip1.SetToolTip(btnExcel, "Exportar reporte por empleado");
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
			// 
			// btnExcelBandas
			// 
			btnExcelBandas.BackColor = SystemColors.ButtonHighlight;
			btnExcelBandas.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcelBandas.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			btnExcelBandas.ForeColor = Color.Black;
			btnExcelBandas.Image = Properties.Resources.excelIcon16;
			btnExcelBandas.ImageAlign = ContentAlignment.MiddleLeft;
			btnExcelBandas.Location = new Point(699, 449);
			btnExcelBandas.Name = "btnExcelBandas";
			btnExcelBandas.Padding = new Padding(10, 0, 10, 0);
			btnExcelBandas.Size = new Size(146, 38);
			btnExcelBandas.TabIndex = 50;
			btnExcelBandas.Text = "Exportar Excel";
			btnExcelBandas.TextAlign = ContentAlignment.MiddleRight;
			btnExcelBandas.TextImageRelation = TextImageRelation.ImageBeforeText;
			toolTip1.SetToolTip(btnExcelBandas, "Exportar sueldos de la semana");
			btnExcelBandas.UseVisualStyleBackColor = false;
			btnExcelBandas.Click += btnExcelBandas_Click;
			// 
			// txbNombre
			// 
			txbNombre.Location = new Point(101, 63);
			txbNombre.Name = "txbNombre";
			txbNombre.Size = new Size(258, 23);
			txbNombre.TabIndex = 49;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblEmpleado.Location = new Point(13, 61);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(82, 21);
			lblEmpleado.TabIndex = 48;
			lblEmpleado.Text = "Empleado:";
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(225, 134);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(23, 23);
			btnEmpleado.TabIndex = 47;
			btnEmpleado.UseVisualStyleBackColor = true;
			btnEmpleado.Click += btnEmpleado_Click;
			// 
			// txbCodigo
			// 
			txbCodigo.Cursor = Cursors.SizeAll;
			txbCodigo.Location = new Point(101, 134);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(89, 23);
			txbCodigo.TabIndex = 46;
			// 
			// lblcodigo
			// 
			lblcodigo.AutoSize = true;
			lblcodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblcodigo.Location = new Point(13, 134);
			lblcodigo.Name = "lblcodigo";
			lblcodigo.Size = new Size(63, 21);
			lblcodigo.TabIndex = 45;
			lblcodigo.Text = "Codigo:";
			// 
			// lblSemana
			// 
			lblSemana.AutoSize = true;
			lblSemana.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSemana.Location = new Point(563, 121);
			lblSemana.Name = "lblSemana";
			lblSemana.Size = new Size(69, 21);
			lblSemana.TabIndex = 42;
			lblSemana.Text = "Semana:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(638, 123);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(235, 23);
			cboSemana.TabIndex = 41;
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
			dgvEmployee.Location = new Point(29, 493);
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
			dgvEmployee.Size = new Size(835, 280);
			dgvEmployee.TabIndex = 52;
			// 
			// lblReporteEmpacadores
			// 
			lblReporteEmpacadores.AutoSize = true;
			lblReporteEmpacadores.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporteEmpacadores.Location = new Point(257, 9);
			lblReporteEmpacadores.Name = "lblReporteEmpacadores";
			lblReporteEmpacadores.Size = new Size(350, 29);
			lblReporteEmpacadores.TabIndex = 53;
			lblReporteEmpacadores.Text = "Reporte de Nomina Semanal";
			lblReporteEmpacadores.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btncargar.Image = (Image)resources.GetObject("btncargar.Image");
			btncargar.ImageAlign = ContentAlignment.MiddleLeft;
			btncargar.Location = new Point(523, 448);
			btncargar.Name = "btncargar";
			btncargar.Padding = new Padding(10, 0, 10, 0);
			btncargar.Size = new Size(154, 38);
			btncargar.TabIndex = 54;
			btncargar.Text = "Cargar Datos";
			btncargar.TextAlign = ContentAlignment.MiddleRight;
			btncargar.TextImageRelation = TextImageRelation.ImageBeforeText;
			btncargar.UseVisualStyleBackColor = true;
			btncargar.Click += btncargar_Click;
			// 
			// btnEmployee
			// 
			btnEmployee.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmployee.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmployee.Location = new Point(365, 63);
			btnEmployee.Name = "btnEmployee";
			btnEmployee.Size = new Size(23, 23);
			btnEmployee.TabIndex = 55;
			btnEmployee.UseVisualStyleBackColor = true;
			btnEmployee.Click += btnEmployee_Click;
			// 
			// btnAñadir
			// 
			btnAñadir.BackgroundImage = (Image)resources.GetObject("btnAñadir.BackgroundImage");
			btnAñadir.BackgroundImageLayout = ImageLayout.Stretch;
			btnAñadir.Location = new Point(196, 134);
			btnAñadir.Name = "btnAñadir";
			btnAñadir.Size = new Size(23, 23);
			btnAñadir.TabIndex = 56;
			toolTip1.SetToolTip(btnAñadir, "Exportar reporte por empleado");
			btnAñadir.UseVisualStyleBackColor = true;
			btnAñadir.Click += btnAñadir_Click;
			// 
			// dgvListaEmpleado
			// 
			dgvListaEmpleado.AllowUserToAddRows = false;
			dgvListaEmpleado.AllowUserToDeleteRows = false;
			dgvListaEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvListaEmpleado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvListaEmpleado.BackgroundColor = Color.Gainsboro;
			dgvListaEmpleado.BorderStyle = BorderStyle.None;
			dgvListaEmpleado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvListaEmpleado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvListaEmpleado.ColumnHeadersHeight = 58;
			dgvListaEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvListaEmpleado.EnableHeadersVisualStyles = false;
			dgvListaEmpleado.ImeMode = ImeMode.NoControl;
			dgvListaEmpleado.Location = new Point(518, 61);
			dgvListaEmpleado.Name = "dgvListaEmpleado";
			dgvListaEmpleado.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvListaEmpleado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvListaEmpleado.RowHeadersVisible = false;
			dgvListaEmpleado.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvListaEmpleado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListaEmpleado.Size = new Size(276, 124);
			dgvListaEmpleado.TabIndex = 57;
			dgvListaEmpleado.CellContentClick += dgvListaEmpleado_CellContentClick;
			// 
			// panel1
			// 
			panel1.AllowDrop = true;
			panel1.BackColor = Color.Gainsboro;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(lblempleados);
			panel1.Controls.Add(panellbl);
			panel1.Controls.Add(dgvListaEmpleado);
			panel1.Controls.Add(btnEmployee);
			panel1.Controls.Add(btnAñadir);
			panel1.Controls.Add(lblcodigo);
			panel1.Controls.Add(lblEmpleado);
			panel1.Controls.Add(txbCodigo);
			panel1.Controls.Add(btnExcel);
			panel1.Controls.Add(txbNombre);
			panel1.Controls.Add(btnEmpleado);
			panel1.Location = new Point(31, 177);
			panel1.Name = "panel1";
			panel1.Padding = new Padding(10);
			panel1.Size = new Size(841, 211);
			panel1.TabIndex = 58;
			// 
			// lblempleados
			// 
			lblempleados.AutoSize = true;
			lblempleados.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblempleados.Location = new Point(556, 39);
			lblempleados.Name = "lblempleados";
			lblempleados.Size = new Size(194, 17);
			lblempleados.TabIndex = 60;
			lblempleados.Text = "Lista de Empleados Agregados";
			// 
			// panellbl
			// 
			panellbl.BackColor = Color.Silver;
			panellbl.BorderStyle = BorderStyle.FixedSingle;
			panellbl.Controls.Add(lblbuscar);
			panellbl.Location = new Point(-1, -1);
			panellbl.Name = "panellbl";
			panellbl.Size = new Size(841, 37);
			panellbl.TabIndex = 58;
			// 
			// lblbuscar
			// 
			lblbuscar.AutoSize = true;
			lblbuscar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblbuscar.ForeColor = Color.Black;
			lblbuscar.Location = new Point(3, 10);
			lblbuscar.Name = "lblbuscar";
			lblbuscar.Size = new Size(221, 20);
			lblbuscar.TabIndex = 59;
			lblbuscar.Text = " Buscar Empleados Específicos  ";
			// 
			// lblFiltro
			// 
			lblFiltro.AutoSize = true;
			lblFiltro.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFiltro.ForeColor = Color.Black;
			lblFiltro.Location = new Point(561, 100);
			lblFiltro.Name = "lblFiltro";
			lblFiltro.Size = new Size(102, 20);
			lblFiltro.TabIndex = 58;
			lblFiltro.Text = "Filtro General";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.Black;
			label1.Location = new Point(588, 413);
			label1.Name = "label1";
			label1.Size = new Size(216, 20);
			label1.TabIndex = 60;
			label1.Text = "Nomina General de la Semana";
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(38, 108);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(33, 32);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 64;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(38, 62);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(33, 27);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 65;
			pictureBox2.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(77, 112);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(45, 19);
			rbtUva.TabIndex = 63;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			// 
			// lblTipodeNomina
			// 
			lblTipodeNomina.AutoSize = true;
			lblTipodeNomina.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTipodeNomina.Location = new Point(29, 30);
			lblTipodeNomina.Name = "lblTipodeNomina";
			lblTipodeNomina.Size = new Size(131, 21);
			lblTipodeNomina.TabIndex = 61;
			lblTipodeNomina.Text = "Tipo de Nomina:";
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(77, 70);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(77, 19);
			rbtEsparrago.TabIndex = 62;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			// 
			// FrmNomsemana
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(900, 787);
			Controls.Add(pictureBox1);
			Controls.Add(pictureBox2);
			Controls.Add(rbtUva);
			Controls.Add(lblTipodeNomina);
			Controls.Add(rbtEsparrago);
			Controls.Add(label1);
			Controls.Add(btnExcelBandas);
			Controls.Add(cboSemana);
			Controls.Add(btncargar);
			Controls.Add(lblFiltro);
			Controls.Add(panel1);
			Controls.Add(lblSemana);
			Controls.Add(lblReporteEmpacadores);
			Controls.Add(dgvEmployee);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmNomsemana";
			Text = "Reporte de nomina Semanal";
			Load += FrmNomsemana_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvListaEmpleado).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panellbl.ResumeLayout(false);
			panellbl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnExcel;
		private Button btnExcelBandas;
		public TextBox txbNombre;
		private Label lblEmpleado;
		private Button btnEmpleado;
		public TextBox txbCodigo;
		private Label lblcodigo;
		private Label lblSemana;
		public ComboBox cboSemana;
		public DataGridView dgvEmployee;
		private Label lblReporteEmpacadores;
		private Button btncargar;
		private Button btnEmployee;
		private ToolTip toolTip1;
		private Button btnAñadir;
		public DataGridView dgvListaEmpleado;
		private Panel panel1;
		private Label lblFiltro;
		private Label lblbuscar;
		private Panel panellbl;
		private Label lblempleados;
		private Label label1;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		public RadioButton rbtUva;
		private Label lblTipodeNomina;
		public RadioButton rbtEsparrago;
	}
}
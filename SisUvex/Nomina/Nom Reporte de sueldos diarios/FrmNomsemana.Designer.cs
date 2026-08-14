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
			lblempleados = new Label();
			pictureBox1 = new PictureBox();
			pictureBox2 = new PictureBox();
			rbtUva = new RadioButton();
			rbtEsparrago = new RadioButton();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			groupBox3 = new GroupBox();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvListaEmpleado).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// btnExcel
			// 
			btnExcel.BackgroundImage = Properties.Resources.excelIcon;
			btnExcel.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcel.Location = new Point(297, 167);
			btnExcel.Margin = new Padding(3, 4, 3, 4);
			btnExcel.Name = "btnExcel";
			btnExcel.Size = new Size(26, 31);
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
			btnExcelBandas.Location = new Point(219, 48);
			btnExcelBandas.Margin = new Padding(3, 4, 3, 4);
			btnExcelBandas.Name = "btnExcelBandas";
			btnExcelBandas.Padding = new Padding(11, 0, 11, 0);
			btnExcelBandas.Size = new Size(167, 51);
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
			txbNombre.Location = new Point(122, 72);
			txbNombre.Margin = new Padding(3, 4, 3, 4);
			txbNombre.Name = "txbNombre";
			txbNombre.Size = new Size(294, 27);
			txbNombre.TabIndex = 49;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblEmpleado.Location = new Point(22, 69);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(104, 28);
			lblEmpleado.TabIndex = 48;
			lblEmpleado.Text = "Empleado:";
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(264, 167);
			btnEmpleado.Margin = new Padding(3, 4, 3, 4);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(26, 31);
			btnEmpleado.TabIndex = 47;
			btnEmpleado.UseVisualStyleBackColor = true;
			btnEmpleado.Click += btnEmpleado_Click;
			// 
			// txbCodigo
			// 
			txbCodigo.Cursor = Cursors.SizeAll;
			txbCodigo.Location = new Point(122, 167);
			txbCodigo.Margin = new Padding(3, 4, 3, 4);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(101, 27);
			txbCodigo.TabIndex = 46;
			// 
			// lblcodigo
			// 
			lblcodigo.AutoSize = true;
			lblcodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblcodigo.Location = new Point(22, 167);
			lblcodigo.Name = "lblcodigo";
			lblcodigo.Size = new Size(81, 28);
			lblcodigo.TabIndex = 45;
			lblcodigo.Text = "Codigo:";
			// 
			// lblSemana
			// 
			lblSemana.AutoSize = true;
			lblSemana.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSemana.Location = new Point(693, 62);
			lblSemana.Name = "lblSemana";
			lblSemana.Size = new Size(85, 28);
			lblSemana.TabIndex = 42;
			lblSemana.Text = "Semana:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(784, 62);
			cboSemana.Margin = new Padding(3, 4, 3, 4);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(319, 28);
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
			dgvEmployee.Location = new Point(33, 586);
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
			dgvEmployee.Size = new Size(1635, 444);
			dgvEmployee.TabIndex = 52;
			// 
			// lblReporteEmpacadores
			// 
			lblReporteEmpacadores.AutoSize = true;
			lblReporteEmpacadores.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporteEmpacadores.Location = new Point(294, 12);
			lblReporteEmpacadores.Name = "lblReporteEmpacadores";
			lblReporteEmpacadores.Size = new Size(420, 36);
			lblReporteEmpacadores.TabIndex = 53;
			lblReporteEmpacadores.Text = "Reporte de Nomina Semanal";
			lblReporteEmpacadores.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btncargar.Image = (Image)resources.GetObject("btncargar.Image");
			btncargar.ImageAlign = ContentAlignment.MiddleLeft;
			btncargar.Location = new Point(22, 48);
			btncargar.Margin = new Padding(3, 4, 3, 4);
			btncargar.Name = "btncargar";
			btncargar.Padding = new Padding(11, 0, 11, 0);
			btncargar.Size = new Size(176, 51);
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
			btnEmployee.Location = new Point(424, 72);
			btnEmployee.Margin = new Padding(3, 4, 3, 4);
			btnEmployee.Name = "btnEmployee";
			btnEmployee.Size = new Size(26, 31);
			btnEmployee.TabIndex = 55;
			btnEmployee.UseVisualStyleBackColor = true;
			btnEmployee.Click += btnEmployee_Click;
			// 
			// btnAñadir
			// 
			btnAñadir.BackgroundImage = (Image)resources.GetObject("btnAñadir.BackgroundImage");
			btnAñadir.BackgroundImageLayout = ImageLayout.Stretch;
			btnAñadir.Location = new Point(231, 167);
			btnAñadir.Margin = new Padding(3, 4, 3, 4);
			btnAñadir.Name = "btnAñadir";
			btnAñadir.Size = new Size(26, 31);
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
			dgvListaEmpleado.BackgroundColor = SystemColors.Control;
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
			dgvListaEmpleado.Location = new Point(618, 69);
			dgvListaEmpleado.Margin = new Padding(3, 4, 3, 4);
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
			dgvListaEmpleado.Size = new Size(358, 146);
			dgvListaEmpleado.TabIndex = 57;
			dgvListaEmpleado.CellContentClick += dgvListaEmpleado_CellContentClick;
			// 
			// lblempleados
			// 
			lblempleados.AutoSize = true;
			lblempleados.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblempleados.Location = new Point(667, 23);
			lblempleados.Name = "lblempleados";
			lblempleados.Size = new Size(243, 23);
			lblempleados.TabIndex = 60;
			lblempleados.Text = "Lista de Empleados Agregados";
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(27, 87);
			pictureBox1.Margin = new Padding(3, 4, 3, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(38, 43);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 64;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new Point(27, 26);
			pictureBox2.Margin = new Padding(3, 4, 3, 4);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(38, 36);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 65;
			pictureBox2.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(72, 92);
			rbtUva.Margin = new Padding(3, 4, 3, 4);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(55, 24);
			rbtUva.TabIndex = 63;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(72, 36);
			rbtEsparrago.Margin = new Padding(3, 4, 3, 4);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(97, 24);
			rbtEsparrago.TabIndex = 62;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(lblempleados);
			groupBox1.Controls.Add(dgvListaEmpleado);
			groupBox1.Controls.Add(txbNombre);
			groupBox1.Controls.Add(btnEmpleado);
			groupBox1.Controls.Add(btnExcel);
			groupBox1.Controls.Add(btnEmployee);
			groupBox1.Controls.Add(txbCodigo);
			groupBox1.Controls.Add(btnAñadir);
			groupBox1.Controls.Add(lblEmpleado);
			groupBox1.Controls.Add(lblcodigo);
			groupBox1.Location = new Point(33, 213);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(1070, 235);
			groupBox1.TabIndex = 66;
			groupBox1.TabStop = false;
			groupBox1.Text = "Buscar Empleado Especifico";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnExcelBandas);
			groupBox2.Controls.Add(btncargar);
			groupBox2.Location = new Point(693, 454);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(410, 125);
			groupBox2.TabIndex = 67;
			groupBox2.TabStop = false;
			groupBox2.Text = "Generar nomina Semanal";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(rbtEsparrago);
			groupBox3.Controls.Add(rbtUva);
			groupBox3.Controls.Add(pictureBox2);
			groupBox3.Controls.Add(pictureBox1);
			groupBox3.Location = new Point(33, 62);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(250, 145);
			groupBox3.TabIndex = 68;
			groupBox3.TabStop = false;
			groupBox3.Text = "Tipo de Nomina";
			// 
			// FrmNomsemana
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1710, 1049);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(cboSemana);
			Controls.Add(lblSemana);
			Controls.Add(lblReporteEmpacadores);
			Controls.Add(dgvEmployee);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmNomsemana";
			Text = "Reporte de nomina Semanal";
			Load += FrmNomsemana_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvListaEmpleado).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
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
		private Label lblempleados;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		public RadioButton rbtUva;
		public RadioButton rbtEsparrago;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
	}
}
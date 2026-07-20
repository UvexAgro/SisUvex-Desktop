namespace SisUvex.Nomina.Registro_de_Asistencia
{
	partial class FrmRegistroA
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroA));
			btnMostrarEmpleado = new Button();
			btnAgregarListado = new Button();
			btnSearch = new Button();
			txbCodigo = new TextBox();
			lblCodigo = new Label();
			cboLinea = new ComboBox();
			cboActividad = new ComboBox();
			lblBanda = new Label();
			lblActividad = new Label();
			txbEmpleado = new TextBox();
			btnAcceptarEmpleado = new Button();
			lblEmpleado = new Label();
			dtpDay = new DateTimePicker();
			btnCancelar = new Button();
			cboHoja = new ComboBox();
			btnInstrucciones = new Button();
			btnMostrar = new Button();
			btnExaminar = new Button();
			lblHoja = new Label();
			txbRuta = new TextBox();
			btnExcelAceptar = new Button();
			lblRuta = new Label();
			cboCuadrilla = new ComboBox();
			lblCuadrilla = new Label();
			lblReporte = new Label();
			dgvAsistencia = new DataGridView();
			btnEliminar = new Button();
			btnEliminarR = new Button();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			groupBox3 = new GroupBox();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// btnMostrarEmpleado
			// 
			btnMostrarEmpleado.Location = new Point(318, 224);
			btnMostrarEmpleado.Margin = new Padding(3, 4, 3, 4);
			btnMostrarEmpleado.Name = "btnMostrarEmpleado";
			btnMostrarEmpleado.Size = new Size(72, 32);
			btnMostrarEmpleado.TabIndex = 113;
			btnMostrarEmpleado.Text = "Mostrar";
			btnMostrarEmpleado.UseVisualStyleBackColor = true;
			btnMostrarEmpleado.Click += btnMostrarEmpleado_Click;
			// 
			// btnAgregarListado
			// 
			btnAgregarListado.Image = Properties.Resources.mas_16;
			btnAgregarListado.Location = new Point(238, 88);
			btnAgregarListado.Margin = new Padding(1);
			btnAgregarListado.Name = "btnAgregarListado";
			btnAgregarListado.Size = new Size(29, 33);
			btnAgregarListado.TabIndex = 112;
			btnAgregarListado.UseVisualStyleBackColor = true;
			btnAgregarListado.Click += btnAgregarListado_Click;
			// 
			// btnSearch
			// 
			btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
			btnSearch.Font = new Font("Segoe UI", 14F);
			btnSearch.Image = Properties.Resources.BuscarLupa1;
			btnSearch.Location = new Point(458, 44);
			btnSearch.Margin = new Padding(3, 4, 3, 4);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(29, 33);
			btnSearch.TabIndex = 111;
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(116, 94);
			txbCodigo.Margin = new Padding(3, 4, 3, 4);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(116, 27);
			txbCodigo.TabIndex = 110;
			txbCodigo.KeyDown += txbCodigo_KeyDown;
			// 
			// lblCodigo
			// 
			lblCodigo.AutoSize = true;
			lblCodigo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblCodigo.Location = new Point(16, 98);
			lblCodigo.Name = "lblCodigo";
			lblCodigo.Size = new Size(69, 23);
			lblCodigo.TabIndex = 109;
			lblCodigo.Text = "Codigo:";
			// 
			// cboLinea
			// 
			cboLinea.FormattingEnabled = true;
			cboLinea.Location = new Point(116, 185);
			cboLinea.Margin = new Padding(3, 4, 3, 4);
			cboLinea.Name = "cboLinea";
			cboLinea.Size = new Size(138, 28);
			cboLinea.TabIndex = 108;
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(116, 140);
			cboActividad.Margin = new Padding(3, 4, 3, 4);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(340, 28);
			cboActividad.TabIndex = 107;
			// 
			// lblBanda
			// 
			lblBanda.AutoSize = true;
			lblBanda.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblBanda.Location = new Point(16, 188);
			lblBanda.Name = "lblBanda";
			lblBanda.Size = new Size(62, 23);
			lblBanda.TabIndex = 104;
			lblBanda.Text = "Banda:";
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblActividad.Location = new Point(16, 145);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(85, 23);
			lblActividad.TabIndex = 105;
			lblActividad.Text = "Actividad:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(116, 47);
			txbEmpleado.Margin = new Padding(3, 4, 3, 4);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(337, 27);
			txbEmpleado.TabIndex = 102;
			// 
			// btnAcceptarEmpleado
			// 
			btnAcceptarEmpleado.Location = new Point(415, 224);
			btnAcceptarEmpleado.Margin = new Padding(3, 4, 3, 4);
			btnAcceptarEmpleado.Name = "btnAcceptarEmpleado";
			btnAcceptarEmpleado.Size = new Size(72, 32);
			btnAcceptarEmpleado.TabIndex = 101;
			btnAcceptarEmpleado.Text = "Guardar";
			btnAcceptarEmpleado.UseVisualStyleBackColor = true;
			btnAcceptarEmpleado.Click += btnAcceptarEmpleado_Click;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblEmpleado.Location = new Point(16, 52);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(90, 23);
			lblEmpleado.TabIndex = 39;
			lblEmpleado.Text = "Empleado:";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(17, 32);
			dtpDay.Margin = new Padding(3, 4, 3, 4);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(351, 27);
			dtpDay.TabIndex = 150;
			dtpDay.ValueChanged += dtpDay_ValueChanged;
			// 
			// btnCancelar
			// 
			btnCancelar.Location = new Point(427, 215);
			btnCancelar.Margin = new Padding(3, 4, 3, 4);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(82, 33);
			btnCancelar.TabIndex = 110;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// cboHoja
			// 
			cboHoja.DropDownStyle = ComboBoxStyle.DropDownList;
			cboHoja.FormattingEnabled = true;
			cboHoja.Location = new Point(80, 127);
			cboHoja.Margin = new Padding(3, 4, 3, 4);
			cboHoja.Name = "cboHoja";
			cboHoja.Size = new Size(308, 28);
			cboHoja.TabIndex = 109;
			// 
			// btnInstrucciones
			// 
			btnInstrucciones.Location = new Point(24, 216);
			btnInstrucciones.Margin = new Padding(3, 4, 3, 4);
			btnInstrucciones.Name = "btnInstrucciones";
			btnInstrucciones.Size = new Size(147, 32);
			btnInstrucciones.TabIndex = 108;
			btnInstrucciones.Text = "Instrucciones";
			btnInstrucciones.UseVisualStyleBackColor = true;
			btnInstrucciones.Click += btnInstrucciones_Click;
			// 
			// btnMostrar
			// 
			btnMostrar.Location = new Point(416, 123);
			btnMostrar.Margin = new Padding(3, 4, 3, 4);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Size = new Size(83, 32);
			btnMostrar.TabIndex = 107;
			btnMostrar.Text = "Mostrar";
			btnMostrar.UseVisualStyleBackColor = true;
			btnMostrar.Click += btnMostrar_Click;
			// 
			// btnExaminar
			// 
			btnExaminar.Location = new Point(416, 44);
			btnExaminar.Margin = new Padding(3, 4, 3, 4);
			btnExaminar.Name = "btnExaminar";
			btnExaminar.Size = new Size(83, 32);
			btnExaminar.TabIndex = 106;
			btnExaminar.Text = "Examinar";
			btnExaminar.UseVisualStyleBackColor = true;
			btnExaminar.Click += btnExaminar_Click;
			// 
			// lblHoja
			// 
			lblHoja.AutoSize = true;
			lblHoja.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblHoja.Location = new Point(24, 135);
			lblHoja.Name = "lblHoja";
			lblHoja.Size = new Size(50, 23);
			lblHoja.TabIndex = 104;
			lblHoja.Text = "Hoja:";
			// 
			// txbRuta
			// 
			txbRuta.Location = new Point(78, 47);
			txbRuta.Margin = new Padding(3, 4, 3, 4);
			txbRuta.Name = "txbRuta";
			txbRuta.Size = new Size(331, 27);
			txbRuta.TabIndex = 102;
			// 
			// btnExcelAceptar
			// 
			btnExcelAceptar.Location = new Point(327, 215);
			btnExcelAceptar.Margin = new Padding(3, 4, 3, 4);
			btnExcelAceptar.Name = "btnExcelAceptar";
			btnExcelAceptar.Size = new Size(82, 32);
			btnExcelAceptar.TabIndex = 101;
			btnExcelAceptar.Text = "Guardar";
			btnExcelAceptar.UseVisualStyleBackColor = true;
			btnExcelAceptar.Click += btnExcelAceptar_Click;
			// 
			// lblRuta
			// 
			lblRuta.AutoSize = true;
			lblRuta.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblRuta.Location = new Point(24, 52);
			lblRuta.Name = "lblRuta";
			lblRuta.Size = new Size(50, 23);
			lblRuta.TabIndex = 39;
			lblRuta.Text = "Ruta:";
			// 
			// cboCuadrilla
			// 
			cboCuadrilla.DropDownStyle = ComboBoxStyle.DropDownList;
			cboCuadrilla.FormattingEnabled = true;
			cboCuadrilla.Location = new Point(733, 27);
			cboCuadrilla.Margin = new Padding(3, 4, 3, 4);
			cboCuadrilla.Name = "cboCuadrilla";
			cboCuadrilla.Size = new Size(366, 28);
			cboCuadrilla.TabIndex = 111;
			cboCuadrilla.SelectedIndexChanged += cboCuadrilla_SelectedIndexChanged;
			// 
			// lblCuadrilla
			// 
			lblCuadrilla.AutoSize = true;
			lblCuadrilla.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblCuadrilla.Location = new Point(646, 28);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(81, 23);
			lblCuadrilla.TabIndex = 111;
			lblCuadrilla.Text = "Cuadrilla:";
			// 
			// lblReporte
			// 
			lblReporte.AutoSize = true;
			lblReporte.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporte.Location = new Point(23, 9);
			lblReporte.Name = "lblReporte";
			lblReporte.Size = new Size(318, 41);
			lblReporte.TabIndex = 2;
			lblReporte.Text = "Registro de Asistencia";
			// 
			// dgvAsistencia
			// 
			dgvAsistencia.AllowUserToAddRows = false;
			dgvAsistencia.AllowUserToDeleteRows = false;
			dgvAsistencia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dgvAsistencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvAsistencia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvAsistencia.BackgroundColor = SystemColors.ControlLightLight;
			dgvAsistencia.BorderStyle = BorderStyle.Fixed3D;
			dgvAsistencia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvAsistencia.ColumnHeadersHeight = 58;
			dgvAsistencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvAsistencia.EnableHeadersVisualStyles = false;
			dgvAsistencia.ImeMode = ImeMode.NoControl;
			dgvAsistencia.Location = new Point(23, 532);
			dgvAsistencia.Margin = new Padding(3, 4, 3, 4);
			dgvAsistencia.Name = "dgvAsistencia";
			dgvAsistencia.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvAsistencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvAsistencia.RowHeadersVisible = false;
			dgvAsistencia.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvAsistencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvAsistencia.Size = new Size(1182, 505);
			dgvAsistencia.TabIndex = 113;
			dgvAsistencia.CellFormatting += dgvAsistencia_CellFormatting;
			// 
			// btnEliminar
			// 
			btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
			btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
			btnEliminar.Location = new Point(1005, 485);
			btnEliminar.Margin = new Padding(3, 4, 3, 4);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Padding = new Padding(12, 0, 12, 0);
			btnEliminar.Size = new Size(179, 39);
			btnEliminar.TabIndex = 155;
			btnEliminar.Text = "Eliminar Todo";
			btnEliminar.TextAlign = ContentAlignment.MiddleRight;
			btnEliminar.UseVisualStyleBackColor = true;
			btnEliminar.Click += btnEliminar_Click;
			// 
			// btnEliminarR
			// 
			btnEliminarR.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnEliminarR.Image = (Image)resources.GetObject("btnEliminarR.Image");
			btnEliminarR.ImageAlign = ContentAlignment.MiddleLeft;
			btnEliminarR.Location = new Point(23, 485);
			btnEliminarR.Margin = new Padding(3, 4, 3, 4);
			btnEliminarR.Name = "btnEliminarR";
			btnEliminarR.Padding = new Padding(9, 0, 9, 0);
			btnEliminarR.Size = new Size(179, 39);
			btnEliminarR.TabIndex = 156;
			btnEliminarR.Text = "Eliminar Registro";
			btnEliminarR.TextAlign = ContentAlignment.MiddleRight;
			btnEliminarR.UseVisualStyleBackColor = true;
			btnEliminarR.Click += btnEliminarR_Click;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = SystemColors.ControlLight;
			groupBox1.Controls.Add(btnMostrarEmpleado);
			groupBox1.Controls.Add(txbEmpleado);
			groupBox1.Controls.Add(btnAgregarListado);
			groupBox1.Controls.Add(lblEmpleado);
			groupBox1.Controls.Add(btnAcceptarEmpleado);
			groupBox1.Controls.Add(btnSearch);
			groupBox1.Controls.Add(txbCodigo);
			groupBox1.Controls.Add(lblActividad);
			groupBox1.Controls.Add(lblCodigo);
			groupBox1.Controls.Add(lblBanda);
			groupBox1.Controls.Add(cboLinea);
			groupBox1.Controls.Add(cboActividad);
			groupBox1.Location = new Point(23, 209);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(524, 263);
			groupBox1.TabIndex = 157;
			groupBox1.TabStop = false;
			groupBox1.Text = "Registro Manual";
			// 
			// groupBox2
			// 
			groupBox2.BackColor = SystemColors.ControlLight;
			groupBox2.Controls.Add(btnCancelar);
			groupBox2.Controls.Add(txbRuta);
			groupBox2.Controls.Add(cboHoja);
			groupBox2.Controls.Add(lblRuta);
			groupBox2.Controls.Add(btnInstrucciones);
			groupBox2.Controls.Add(btnExcelAceptar);
			groupBox2.Controls.Add(btnMostrar);
			groupBox2.Controls.Add(lblHoja);
			groupBox2.Controls.Add(btnExaminar);
			groupBox2.Location = new Point(660, 209);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(524, 263);
			groupBox2.TabIndex = 158;
			groupBox2.TabStop = false;
			groupBox2.Text = "Registro en Excel";
			// 
			// groupBox3
			// 
			groupBox3.BackColor = SystemColors.ControlLight;
			groupBox3.Controls.Add(dtpDay);
			groupBox3.Controls.Add(cboCuadrilla);
			groupBox3.Controls.Add(lblCuadrilla);
			groupBox3.Location = new Point(23, 108);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(1161, 82);
			groupBox3.TabIndex = 159;
			groupBox3.TabStop = false;
			groupBox3.Text = "Informacion General";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(23, 60);
			label1.Name = "label1";
			label1.Size = new Size(456, 20);
			label1.TabIndex = 160;
			label1.Text = "Registra la asistencia manualmente o mediante un archivo de Excel.";
			// 
			// FrmRegistroA
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1274, 1055);
			Controls.Add(label1);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(btnEliminarR);
			Controls.Add(btnEliminar);
			Controls.Add(dgvAsistencia);
			Controls.Add(lblReporte);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmRegistroA";
			Text = "Registro de Asistencia ";
			Load += FrmRegistroA_Load;
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label lblBanda;
		public TextBox txbEmpleado;
		private Label lblEmpleado;
		private Label lblActividad;
		public DateTimePicker dtpDay;
		private Label lblFecha;
		public TextBox txbRuta;
		private Label lblHoja;
		private Label lblRuta;
		private Label lblReporte;
		public DataGridView dgvAsistencia;
		public ComboBox cboHoja;
		public Button btnAcceptarEmpleado;
		public Button btnExcelAceptar;
		public Button btnMostrar;
		public Button btnExaminar;
		public Button btnInstrucciones;
		public Button btnCancelar;
		public ComboBox cboLinea;
		public ComboBox cboActividad;
		public TextBox txbCodigo;
		private Label lblCodigo;
		private Button btnSearch;
		private Button btnAgregarListado;
		public Button btnMostrarEmpleado;
		public Button btnEliminar;
		public ComboBox cboCuadrilla;
		private Label lblCuadrilla;
		public Button btnEliminarR;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private Label label1;
	}
}
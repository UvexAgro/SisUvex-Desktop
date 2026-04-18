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
			pllManual = new Panel();
			cboCuadrillaM = new ComboBox();
			lblCuadrillaM = new Label();
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
			lblManual = new Label();
			pllExcel = new Panel();
			cboCuadrilla = new ComboBox();
			lblCuadrilla = new Label();
			btnCancelar = new Button();
			cboHoja = new ComboBox();
			btnInstrucciones = new Button();
			btnMostrar = new Button();
			btnExaminar = new Button();
			lblHoja = new Label();
			txbRuta = new TextBox();
			btnExcelAceptar = new Button();
			lblRuta = new Label();
			lblExcel = new Label();
			lblReporte = new Label();
			dgvAsistencia = new DataGridView();
			btnEliminar = new Button();
			pllManual.SuspendLayout();
			pllExcel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
			SuspendLayout();
			// 
			// pllManual
			// 
			pllManual.BackColor = SystemColors.ActiveCaption;
			pllManual.BorderStyle = BorderStyle.FixedSingle;
			pllManual.Controls.Add(cboCuadrillaM);
			pllManual.Controls.Add(lblCuadrillaM);
			pllManual.Controls.Add(btnMostrarEmpleado);
			pllManual.Controls.Add(btnAgregarListado);
			pllManual.Controls.Add(btnSearch);
			pllManual.Controls.Add(txbCodigo);
			pllManual.Controls.Add(lblCodigo);
			pllManual.Controls.Add(cboLinea);
			pllManual.Controls.Add(cboActividad);
			pllManual.Controls.Add(lblBanda);
			pllManual.Controls.Add(lblActividad);
			pllManual.Controls.Add(txbEmpleado);
			pllManual.Controls.Add(btnAcceptarEmpleado);
			pllManual.Controls.Add(lblEmpleado);
			pllManual.Location = new Point(41, 151);
			pllManual.Name = "pllManual";
			pllManual.Size = new Size(456, 232);
			pllManual.TabIndex = 108;
			// 
			// cboCuadrillaM
			// 
			cboCuadrillaM.DropDownStyle = ComboBoxStyle.DropDownList;
			cboCuadrillaM.FormattingEnabled = true;
			cboCuadrillaM.Location = new Point(87, 144);
			cboCuadrillaM.Name = "cboCuadrillaM";
			cboCuadrillaM.Size = new Size(298, 23);
			cboCuadrillaM.TabIndex = 114;
			// 
			// lblCuadrillaM
			// 
			lblCuadrillaM.AutoSize = true;
			lblCuadrillaM.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblCuadrillaM.Location = new Point(13, 144);
			lblCuadrillaM.Name = "lblCuadrillaM";
			lblCuadrillaM.Size = new Size(68, 19);
			lblCuadrillaM.TabIndex = 115;
			lblCuadrillaM.Text = "Cuadrilla:";
			// 
			// btnMostrarEmpleado
			// 
			btnMostrarEmpleado.Location = new Point(306, 188);
			btnMostrarEmpleado.Name = "btnMostrarEmpleado";
			btnMostrarEmpleado.Size = new Size(63, 24);
			btnMostrarEmpleado.TabIndex = 113;
			btnMostrarEmpleado.Text = "Mostrar";
			btnMostrarEmpleado.UseVisualStyleBackColor = true;
			btnMostrarEmpleado.Click += btnMostrarEmpleado_Click;
			// 
			// btnAgregarListado
			// 
			btnAgregarListado.Image = Properties.Resources.mas_16;
			btnAgregarListado.Location = new Point(196, 66);
			btnAgregarListado.Margin = new Padding(1);
			btnAgregarListado.Name = "btnAgregarListado";
			btnAgregarListado.Size = new Size(25, 25);
			btnAgregarListado.TabIndex = 112;
			btnAgregarListado.UseVisualStyleBackColor = true;
			btnAgregarListado.Click += btnAgregarListado_Click;
			// 
			// btnSearch
			// 
			btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
			btnSearch.Font = new Font("Segoe UI", 14F);
			btnSearch.Image = Properties.Resources.BuscarLupa1;
			btnSearch.Location = new Point(394, 18);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(25, 25);
			btnSearch.TabIndex = 111;
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(90, 66);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(102, 23);
			txbCodigo.TabIndex = 110;
			// 
			// lblCodigo
			// 
			lblCodigo.AutoSize = true;
			lblCodigo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblCodigo.Location = new Point(13, 66);
			lblCodigo.Name = "lblCodigo";
			lblCodigo.Size = new Size(57, 19);
			lblCodigo.TabIndex = 109;
			lblCodigo.Text = "Codigo:";
			// 
			// cboLinea
			// 
			cboLinea.FormattingEnabled = true;
			cboLinea.Location = new Point(87, 182);
			cboLinea.Name = "cboLinea";
			cboLinea.Size = new Size(121, 23);
			cboLinea.TabIndex = 108;
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(87, 106);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(298, 23);
			cboActividad.TabIndex = 107;
			// 
			// lblBanda
			// 
			lblBanda.AutoSize = true;
			lblBanda.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblBanda.Location = new Point(20, 182);
			lblBanda.Name = "lblBanda";
			lblBanda.Size = new Size(50, 19);
			lblBanda.TabIndex = 104;
			lblBanda.Text = "Banda:";
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblActividad.Location = new Point(13, 106);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(71, 19);
			lblActividad.TabIndex = 105;
			lblActividad.Text = "Actividad:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(90, 20);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(295, 23);
			txbEmpleado.TabIndex = 102;
			// 
			// btnAcceptarEmpleado
			// 
			btnAcceptarEmpleado.Location = new Point(388, 188);
			btnAcceptarEmpleado.Name = "btnAcceptarEmpleado";
			btnAcceptarEmpleado.Size = new Size(63, 24);
			btnAcceptarEmpleado.TabIndex = 101;
			btnAcceptarEmpleado.Text = "Aceptar";
			btnAcceptarEmpleado.UseVisualStyleBackColor = true;
			btnAcceptarEmpleado.Click += btnAcceptarEmpleado_Click;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblEmpleado.Location = new Point(13, 24);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(73, 19);
			lblEmpleado.TabIndex = 39;
			lblEmpleado.Text = "Empleado:";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(50, 70);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(308, 23);
			dtpDay.TabIndex = 150;
			dtpDay.ValueChanged += dtpDay_ValueChanged;
			// 
			// lblManual
			// 
			lblManual.AutoSize = true;
			lblManual.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
			lblManual.Location = new Point(55, 123);
			lblManual.Name = "lblManual";
			lblManual.Size = new Size(77, 25);
			lblManual.TabIndex = 152;
			lblManual.Text = "Manual";
			// 
			// pllExcel
			// 
			pllExcel.BackColor = SystemColors.ActiveCaption;
			pllExcel.BorderStyle = BorderStyle.FixedSingle;
			pllExcel.Controls.Add(cboCuadrilla);
			pllExcel.Controls.Add(lblCuadrilla);
			pllExcel.Controls.Add(btnCancelar);
			pllExcel.Controls.Add(cboHoja);
			pllExcel.Controls.Add(btnInstrucciones);
			pllExcel.Controls.Add(btnMostrar);
			pllExcel.Controls.Add(btnExaminar);
			pllExcel.Controls.Add(lblHoja);
			pllExcel.Controls.Add(txbRuta);
			pllExcel.Controls.Add(btnExcelAceptar);
			pllExcel.Controls.Add(lblRuta);
			pllExcel.Location = new Point(578, 151);
			pllExcel.Name = "pllExcel";
			pllExcel.Size = new Size(443, 232);
			pllExcel.TabIndex = 153;
			// 
			// cboCuadrilla
			// 
			cboCuadrilla.DropDownStyle = ComboBoxStyle.DropDownList;
			cboCuadrilla.FormattingEnabled = true;
			cboCuadrilla.Location = new Point(87, 130);
			cboCuadrilla.Name = "cboCuadrilla";
			cboCuadrilla.Size = new Size(321, 23);
			cboCuadrilla.TabIndex = 111;
			// 
			// lblCuadrilla
			// 
			lblCuadrilla.AutoSize = true;
			lblCuadrilla.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblCuadrilla.Location = new Point(13, 134);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(68, 19);
			lblCuadrilla.TabIndex = 111;
			lblCuadrilla.Text = "Cuadrilla:";
			// 
			// btnCancelar
			// 
			btnCancelar.Location = new Point(366, 182);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(63, 25);
			btnCancelar.TabIndex = 110;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// cboHoja
			// 
			cboHoja.DropDownStyle = ComboBoxStyle.DropDownList;
			cboHoja.FormattingEnabled = true;
			cboHoja.Location = new Point(60, 77);
			cboHoja.Name = "cboHoja";
			cboHoja.Size = new Size(270, 23);
			cboHoja.TabIndex = 109;
			// 
			// btnInstrucciones
			// 
			btnInstrucciones.Location = new Point(13, 182);
			btnInstrucciones.Name = "btnInstrucciones";
			btnInstrucciones.Size = new Size(129, 24);
			btnInstrucciones.TabIndex = 108;
			btnInstrucciones.Text = "Instrucciones";
			btnInstrucciones.UseVisualStyleBackColor = true;
			btnInstrucciones.Click += btnInstrucciones_Click;
			// 
			// btnMostrar
			// 
			btnMostrar.Location = new Point(356, 74);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Size = new Size(63, 24);
			btnMostrar.TabIndex = 107;
			btnMostrar.Text = "Mostrar";
			btnMostrar.UseVisualStyleBackColor = true;
			btnMostrar.Click += btnMostrar_Click;
			// 
			// btnExaminar
			// 
			btnExaminar.Location = new Point(356, 18);
			btnExaminar.Name = "btnExaminar";
			btnExaminar.Size = new Size(73, 24);
			btnExaminar.TabIndex = 106;
			btnExaminar.Text = "Examinar";
			btnExaminar.UseVisualStyleBackColor = true;
			btnExaminar.Click += btnExaminar_Click;
			// 
			// lblHoja
			// 
			lblHoja.AutoSize = true;
			lblHoja.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblHoja.Location = new Point(13, 81);
			lblHoja.Name = "lblHoja";
			lblHoja.Size = new Size(41, 19);
			lblHoja.TabIndex = 104;
			lblHoja.Text = "Hoja:";
			// 
			// txbRuta
			// 
			txbRuta.Location = new Point(60, 20);
			txbRuta.Name = "txbRuta";
			txbRuta.Size = new Size(290, 23);
			txbRuta.TabIndex = 102;
			// 
			// btnExcelAceptar
			// 
			btnExcelAceptar.Location = new Point(287, 183);
			btnExcelAceptar.Name = "btnExcelAceptar";
			btnExcelAceptar.Size = new Size(63, 24);
			btnExcelAceptar.TabIndex = 101;
			btnExcelAceptar.Text = "Aceptar";
			btnExcelAceptar.UseVisualStyleBackColor = true;
			btnExcelAceptar.Click += btnExcelAceptar_Click;
			// 
			// lblRuta
			// 
			lblRuta.AutoSize = true;
			lblRuta.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblRuta.Location = new Point(13, 24);
			lblRuta.Name = "lblRuta";
			lblRuta.Size = new Size(41, 19);
			lblRuta.TabIndex = 39;
			lblRuta.Text = "Ruta:";
			// 
			// lblExcel
			// 
			lblExcel.AutoSize = true;
			lblExcel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
			lblExcel.Location = new Point(577, 123);
			lblExcel.Name = "lblExcel";
			lblExcel.Size = new Size(56, 25);
			lblExcel.TabIndex = 154;
			lblExcel.Text = "Excel";
			// 
			// lblReporte
			// 
			lblReporte.AutoSize = true;
			lblReporte.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporte.Location = new Point(50, 9);
			lblReporte.Name = "lblReporte";
			lblReporte.Size = new Size(252, 32);
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
			dgvAsistencia.Location = new Point(20, 445);
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
			dgvAsistencia.Size = new Size(1001, 333);
			dgvAsistencia.TabIndex = 113;
			dgvAsistencia.CellFormatting += dgvAsistencia_CellFormatting;
			// 
			// btnEliminar
			// 
			btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnEliminar.Location = new Point(905, 385);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Size = new Size(107, 29);
			btnEliminar.TabIndex = 155;
			btnEliminar.Text = "Eliminar";
			btnEliminar.UseVisualStyleBackColor = true;
			btnEliminar.Click += btnEliminar_Click;
			// 
			// FrmRegistroA
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1069, 811);
			Controls.Add(btnEliminar);
			Controls.Add(lblExcel);
			Controls.Add(pllExcel);
			Controls.Add(lblManual);
			Controls.Add(dtpDay);
			Controls.Add(dgvAsistencia);
			Controls.Add(pllManual);
			Controls.Add(lblReporte);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmRegistroA";
			Text = "Registro de Asistencia ";
			Load += FrmRegistroA_Load;
			pllManual.ResumeLayout(false);
			pllManual.PerformLayout();
			pllExcel.ResumeLayout(false);
			pllExcel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Panel pllManual;
		private Label lblBanda;
		public TextBox txbEmpleado;
		private Label lblEmpleado;
		private Label lblActividad;
		public DateTimePicker dtpDay;
		private Label lblFecha;
		private Label lblManual;
		private Panel pllExcel;
		public TextBox txbRuta;
		private Label lblHoja;
		private Label lblRuta;
		private Label lblExcel;
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
		public ComboBox cboCuadrillaM;
		private Label lblCuadrillaM;
	}
}
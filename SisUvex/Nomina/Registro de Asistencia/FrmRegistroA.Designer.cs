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
			lblExcel = new Label();
			lblReporte = new Label();
			dgvAsistencia = new DataGridView();
			btnEliminar = new Button();
			btnEliminarR = new Button();
			pllManual.SuspendLayout();
			pllExcel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
			SuspendLayout();
			// 
			// pllManual
			// 
			pllManual.BackColor = SystemColors.ActiveCaption;
			pllManual.BorderStyle = BorderStyle.FixedSingle;
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
			pllManual.Location = new Point(41, 243);
			pllManual.Margin = new Padding(3, 4, 3, 4);
			pllManual.Name = "pllManual";
			pllManual.Size = new Size(521, 255);
			pllManual.TabIndex = 108;
			// 
			// btnMostrarEmpleado
			// 
			btnMostrarEmpleado.Location = new Point(350, 197);
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
			btnAgregarListado.Location = new Point(224, 86);
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
			btnSearch.Location = new Point(450, 24);
			btnSearch.Margin = new Padding(3, 4, 3, 4);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(29, 33);
			btnSearch.TabIndex = 111;
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(103, 88);
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
			lblCodigo.Location = new Point(15, 88);
			lblCodigo.Name = "lblCodigo";
			lblCodigo.Size = new Size(69, 23);
			lblCodigo.TabIndex = 109;
			lblCodigo.Text = "Codigo:";
			// 
			// cboLinea
			// 
			cboLinea.FormattingEnabled = true;
			cboLinea.Location = new Point(99, 197);
			cboLinea.Margin = new Padding(3, 4, 3, 4);
			cboLinea.Name = "cboLinea";
			cboLinea.Size = new Size(138, 28);
			cboLinea.TabIndex = 108;
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(99, 141);
			cboActividad.Margin = new Padding(3, 4, 3, 4);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(340, 28);
			cboActividad.TabIndex = 107;
			// 
			// lblBanda
			// 
			lblBanda.AutoSize = true;
			lblBanda.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblBanda.Location = new Point(23, 197);
			lblBanda.Name = "lblBanda";
			lblBanda.Size = new Size(62, 23);
			lblBanda.TabIndex = 104;
			lblBanda.Text = "Banda:";
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblActividad.Location = new Point(15, 141);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(85, 23);
			lblActividad.TabIndex = 105;
			lblActividad.Text = "Actividad:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(103, 27);
			txbEmpleado.Margin = new Padding(3, 4, 3, 4);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(337, 27);
			txbEmpleado.TabIndex = 102;
			// 
			// btnAcceptarEmpleado
			// 
			btnAcceptarEmpleado.Location = new Point(443, 197);
			btnAcceptarEmpleado.Margin = new Padding(3, 4, 3, 4);
			btnAcceptarEmpleado.Name = "btnAcceptarEmpleado";
			btnAcceptarEmpleado.Size = new Size(72, 32);
			btnAcceptarEmpleado.TabIndex = 101;
			btnAcceptarEmpleado.Text = "Aceptar";
			btnAcceptarEmpleado.UseVisualStyleBackColor = true;
			btnAcceptarEmpleado.Click += btnAcceptarEmpleado_Click;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblEmpleado.Location = new Point(15, 32);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(90, 23);
			lblEmpleado.TabIndex = 39;
			lblEmpleado.Text = "Empleado:";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(57, 93);
			dtpDay.Margin = new Padding(3, 4, 3, 4);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(351, 27);
			dtpDay.TabIndex = 150;
			dtpDay.ValueChanged += dtpDay_ValueChanged;
			// 
			// lblManual
			// 
			lblManual.AutoSize = true;
			lblManual.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
			lblManual.Location = new Point(57, 205);
			lblManual.Name = "lblManual";
			lblManual.Size = new Size(96, 32);
			lblManual.TabIndex = 152;
			lblManual.Text = "Manual";
			// 
			// pllExcel
			// 
			pllExcel.BackColor = SystemColors.ActiveCaption;
			pllExcel.BorderStyle = BorderStyle.FixedSingle;
			pllExcel.Controls.Add(btnCancelar);
			pllExcel.Controls.Add(cboHoja);
			pllExcel.Controls.Add(btnInstrucciones);
			pllExcel.Controls.Add(btnMostrar);
			pllExcel.Controls.Add(btnExaminar);
			pllExcel.Controls.Add(lblHoja);
			pllExcel.Controls.Add(txbRuta);
			pllExcel.Controls.Add(btnExcelAceptar);
			pllExcel.Controls.Add(lblRuta);
			pllExcel.Location = new Point(653, 243);
			pllExcel.Margin = new Padding(3, 4, 3, 4);
			pllExcel.Name = "pllExcel";
			pllExcel.Size = new Size(506, 255);
			pllExcel.TabIndex = 153;
			// 
			// btnCancelar
			// 
			btnCancelar.Location = new Point(418, 197);
			btnCancelar.Margin = new Padding(3, 4, 3, 4);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(72, 33);
			btnCancelar.TabIndex = 110;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// cboHoja
			// 
			cboHoja.DropDownStyle = ComboBoxStyle.DropDownList;
			cboHoja.FormattingEnabled = true;
			cboHoja.Location = new Point(69, 113);
			cboHoja.Margin = new Padding(3, 4, 3, 4);
			cboHoja.Name = "cboHoja";
			cboHoja.Size = new Size(308, 28);
			cboHoja.TabIndex = 109;
			// 
			// btnInstrucciones
			// 
			btnInstrucciones.Location = new Point(15, 197);
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
			btnMostrar.Location = new Point(407, 109);
			btnMostrar.Margin = new Padding(3, 4, 3, 4);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Size = new Size(72, 32);
			btnMostrar.TabIndex = 107;
			btnMostrar.Text = "Mostrar";
			btnMostrar.UseVisualStyleBackColor = true;
			btnMostrar.Click += btnMostrar_Click;
			// 
			// btnExaminar
			// 
			btnExaminar.Location = new Point(407, 24);
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
			lblHoja.Location = new Point(15, 115);
			lblHoja.Name = "lblHoja";
			lblHoja.Size = new Size(50, 23);
			lblHoja.TabIndex = 104;
			lblHoja.Text = "Hoja:";
			// 
			// txbRuta
			// 
			txbRuta.Location = new Point(69, 27);
			txbRuta.Margin = new Padding(3, 4, 3, 4);
			txbRuta.Name = "txbRuta";
			txbRuta.Size = new Size(331, 27);
			txbRuta.TabIndex = 102;
			// 
			// btnExcelAceptar
			// 
			btnExcelAceptar.Location = new Point(328, 199);
			btnExcelAceptar.Margin = new Padding(3, 4, 3, 4);
			btnExcelAceptar.Name = "btnExcelAceptar";
			btnExcelAceptar.Size = new Size(72, 32);
			btnExcelAceptar.TabIndex = 101;
			btnExcelAceptar.Text = "Aceptar";
			btnExcelAceptar.UseVisualStyleBackColor = true;
			btnExcelAceptar.Click += btnExcelAceptar_Click;
			// 
			// lblRuta
			// 
			lblRuta.AutoSize = true;
			lblRuta.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblRuta.Location = new Point(15, 32);
			lblRuta.Name = "lblRuta";
			lblRuta.Size = new Size(50, 23);
			lblRuta.TabIndex = 39;
			lblRuta.Text = "Ruta:";
			// 
			// cboCuadrilla
			// 
			cboCuadrilla.DropDownStyle = ComboBoxStyle.DropDownList;
			cboCuadrilla.FormattingEnabled = true;
			cboCuadrilla.Location = new Point(792, 93);
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
			lblCuadrilla.Location = new Point(792, 64);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(81, 23);
			lblCuadrilla.TabIndex = 111;
			lblCuadrilla.Text = "Cuadrilla:";
			// 
			// lblExcel
			// 
			lblExcel.AutoSize = true;
			lblExcel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
			lblExcel.Location = new Point(651, 205);
			lblExcel.Name = "lblExcel";
			lblExcel.Size = new Size(68, 32);
			lblExcel.TabIndex = 154;
			lblExcel.Text = "Excel";
			// 
			// lblReporte
			// 
			lblReporte.AutoSize = true;
			lblReporte.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporte.Location = new Point(57, 12);
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
			dgvAsistencia.Location = new Point(23, 593);
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
			dgvAsistencia.Size = new Size(1144, 444);
			dgvAsistencia.TabIndex = 113;
			dgvAsistencia.CellFormatting += dgvAsistencia_CellFormatting;
			// 
			// btnEliminar
			// 
			btnEliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnEliminar.Location = new Point(921, 547);
			btnEliminar.Margin = new Padding(3, 4, 3, 4);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Size = new Size(231, 39);
			btnEliminar.TabIndex = 155;
			btnEliminar.Text = "Eliminar Todo";
			btnEliminar.UseVisualStyleBackColor = true;
			btnEliminar.Click += btnEliminar_Click;
			// 
			// btnEliminarR
			// 
			btnEliminarR.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnEliminarR.Location = new Point(23, 547);
			btnEliminarR.Margin = new Padding(3, 4, 3, 4);
			btnEliminarR.Name = "btnEliminarR";
			btnEliminarR.Size = new Size(231, 39);
			btnEliminarR.TabIndex = 156;
			btnEliminarR.Text = "Eliminar Registro";
			btnEliminarR.UseVisualStyleBackColor = true;
			btnEliminarR.Click += btnEliminarR_Click;
			// 
			// FrmRegistroA
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1222, 1055);
			Controls.Add(btnEliminarR);
			Controls.Add(lblCuadrilla);
			Controls.Add(cboCuadrilla);
			Controls.Add(btnEliminar);
			Controls.Add(lblExcel);
			Controls.Add(pllExcel);
			Controls.Add(lblManual);
			Controls.Add(dtpDay);
			Controls.Add(dgvAsistencia);
			Controls.Add(pllManual);
			Controls.Add(lblReporte);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
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
		public Button btnEliminarR;
	}
}
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
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroA));
			this.pllManual = new Panel();
			txbBanda = new TextBox();
			lblActividad = new Label();
			lblBanda = new Label();
			txbActividad = new TextBox();
			txbEmpleado = new TextBox();
			btnAcceptarEmpleado = new Button();
			lblEmpleado = new Label();
			dtpDay = new DateTimePicker();
			lblManual = new Label();
			pllExcel = new Panel();
			btnInstrucciones = new Button();
			btnMostrar = new Button();
			btnExaminar = new Button();
			txbHoja = new TextBox();
			lblHoja = new Label();
			txbRuta = new TextBox();
			btnExcelAceptar = new Button();
			lblRuta = new Label();
			lblExcel = new Label();
			lblReporte = new Label();
			dgvAsistencia = new DataGridView();
			this.pllManual.SuspendLayout();
			pllExcel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
			SuspendLayout();
			// 
			// pllManual
			// 
			this.pllManual.BackColor = SystemColors.ActiveCaption;
			this.pllManual.BorderStyle = BorderStyle.FixedSingle;
			this.pllManual.Controls.Add(txbBanda);
			this.pllManual.Controls.Add(lblActividad);
			this.pllManual.Controls.Add(lblBanda);
			this.pllManual.Controls.Add(txbActividad);
			this.pllManual.Controls.Add(txbEmpleado);
			this.pllManual.Controls.Add(btnAcceptarEmpleado);
			this.pllManual.Controls.Add(lblEmpleado);
			this.pllManual.Location = new Point(50, 147);
			this.pllManual.Name = "pllManual";
			this.pllManual.Size = new Size(443, 153);
			this.pllManual.TabIndex = 108;
			// 
			// txbBanda
			// 
			txbBanda.Location = new Point(103, 104);
			txbBanda.MaxLength = 6;
			txbBanda.Name = "txbBanda";
			txbBanda.Size = new Size(93, 23);
			txbBanda.TabIndex = 106;
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblActividad.Location = new Point(13, 64);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(71, 19);
			lblActividad.TabIndex = 105;
			lblActividad.Text = "Actividad:";
			// 
			// lblBanda
			// 
			lblBanda.AutoSize = true;
			lblBanda.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblBanda.Location = new Point(19, 104);
			lblBanda.Name = "lblBanda";
			lblBanda.Size = new Size(50, 19);
			lblBanda.TabIndex = 104;
			lblBanda.Text = "Banda:";
			// 
			// txbActividad
			// 
			txbActividad.Location = new Point(103, 60);
			txbActividad.MaxLength = 6;
			txbActividad.Name = "txbActividad";
			txbActividad.Size = new Size(93, 23);
			txbActividad.TabIndex = 103;
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(103, 23);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(298, 23);
			txbEmpleado.TabIndex = 102;
			// 
			// btnAcceptarEmpleado
			// 
			btnAcceptarEmpleado.Location = new Point(338, 115);
			btnAcceptarEmpleado.Name = "btnAcceptarEmpleado";
			btnAcceptarEmpleado.Size = new Size(63, 24);
			btnAcceptarEmpleado.TabIndex = 101;
			btnAcceptarEmpleado.Text = "Aceptar";
			btnAcceptarEmpleado.UseVisualStyleBackColor = true;
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
			// 
			// lblManual
			// 
			lblManual.AutoSize = true;
			lblManual.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
			lblManual.Location = new Point(50, 119);
			lblManual.Name = "lblManual";
			lblManual.Size = new Size(77, 25);
			lblManual.TabIndex = 152;
			lblManual.Text = "Manual";
			// 
			// pllExcel
			// 
			pllExcel.BackColor = SystemColors.ActiveCaption;
			pllExcel.BorderStyle = BorderStyle.FixedSingle;
			pllExcel.Controls.Add(btnInstrucciones);
			pllExcel.Controls.Add(btnMostrar);
			pllExcel.Controls.Add(btnExaminar);
			pllExcel.Controls.Add(txbHoja);
			pllExcel.Controls.Add(lblHoja);
			pllExcel.Controls.Add(txbRuta);
			pllExcel.Controls.Add(btnExcelAceptar);
			pllExcel.Controls.Add(lblRuta);
			pllExcel.Location = new Point(569, 147);
			pllExcel.Name = "pllExcel";
			pllExcel.Size = new Size(443, 153);
			pllExcel.TabIndex = 153;
			// 
			// btnInstrucciones
			// 
			btnInstrucciones.Location = new Point(13, 115);
			btnInstrucciones.Name = "btnInstrucciones";
			btnInstrucciones.Size = new Size(129, 24);
			btnInstrucciones.TabIndex = 108;
			btnInstrucciones.Text = "Instrucciones";
			btnInstrucciones.UseVisualStyleBackColor = true;
			// 
			// btnMostrar
			// 
			btnMostrar.Location = new Point(356, 61);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Size = new Size(63, 24);
			btnMostrar.TabIndex = 107;
			btnMostrar.Text = "Mostrar";
			btnMostrar.UseVisualStyleBackColor = true;
			// 
			// btnExaminar
			// 
			btnExaminar.Location = new Point(356, 18);
			btnExaminar.Name = "btnExaminar";
			btnExaminar.Size = new Size(63, 24);
			btnExaminar.TabIndex = 106;
			btnExaminar.Text = "Examinar";
			btnExaminar.UseVisualStyleBackColor = true;
			// 
			// txbHoja
			// 
			txbHoja.Enabled = false;
			txbHoja.Location = new Point(60, 60);
			txbHoja.Name = "txbHoja";
			txbHoja.Size = new Size(255, 23);
			txbHoja.TabIndex = 105;
			// 
			// lblHoja
			// 
			lblHoja.AutoSize = true;
			lblHoja.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblHoja.Location = new Point(13, 64);
			lblHoja.Name = "lblHoja";
			lblHoja.Size = new Size(41, 19);
			lblHoja.TabIndex = 104;
			lblHoja.Text = "Hoja:";
			// 
			// txbRuta
			// 
			txbRuta.Enabled = false;
			txbRuta.Location = new Point(60, 20);
			txbRuta.Name = "txbRuta";
			txbRuta.Size = new Size(290, 23);
			txbRuta.TabIndex = 102;
			// 
			// btnExcelAceptar
			// 
			btnExcelAceptar.Location = new Point(356, 115);
			btnExcelAceptar.Name = "btnExcelAceptar";
			btnExcelAceptar.Size = new Size(63, 24);
			btnExcelAceptar.TabIndex = 101;
			btnExcelAceptar.Text = "Aceptar";
			btnExcelAceptar.UseVisualStyleBackColor = true;
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
			lblExcel.Location = new Point(569, 119);
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
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvAsistencia.ColumnHeadersHeight = 58;
			dgvAsistencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvAsistencia.EnableHeadersVisualStyles = false;
			dgvAsistencia.ImeMode = ImeMode.NoControl;
			dgvAsistencia.Location = new Point(32, 324);
			dgvAsistencia.Name = "dgvAsistencia";
			dgvAsistencia.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvAsistencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvAsistencia.RowHeadersVisible = false;
			dgvAsistencia.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvAsistencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvAsistencia.Size = new Size(1001, 475);
			dgvAsistencia.TabIndex = 113;
			// 
			// FrmRegistroA
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1069, 811);
			Controls.Add(lblExcel);
			Controls.Add(pllExcel);
			Controls.Add(lblManual);
			Controls.Add(dtpDay);
			Controls.Add(dgvAsistencia);
			Controls.Add(this.pllManual);
			Controls.Add(lblReporte);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmRegistroA";
			Text = "Registro de Asistencia ";
			this.pllManual.ResumeLayout(false);
			this.pllManual.PerformLayout();
			pllExcel.ResumeLayout(false);
			pllExcel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Panel pllEmpleado;
		private Label lblBanda;
		public TextBox txbBanda;
		public TextBox txbEmpleado;
		private Button btnAcceptarEmpleado;
		private Label lblEmpleado;
		private Label lblActividad;
		public DateTimePicker dtpDay;
		private Label lblFecha;
		public TextBox txbActividad;
		private Label lblManual;
		private Panel pllExcel;
		public TextBox txbRuta;
		private Label lblHoja;
		private Button btnExcelAceptar;
		private Label lblRuta;
		private Label lblExcel;
		private Label lblReporte;
		private Button btnMostrar;
		private Button btnExaminar;
		public TextBox txbHoja;
		private Button btnInstrucciones;
		public DataGridView dgvAsistencia;
	}
}
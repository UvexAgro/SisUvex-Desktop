namespace SisUvex.Nomina.Reporte_de_Asistencia
{
	partial class FrmAsistenciaR
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaR));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			lblReporte = new Label();
			lblEmpleado = new Label();
			pllEmpleado = new Panel();
			btnAgregarListado = new Button();
			btnSearch = new Button();
			lbl = new Label();
			txbCodigo = new TextBox();
			txbEmpleado = new TextBox();
			btnAcceptarEmpleado = new Button();
			label1 = new Label();
			pllCuadrilla = new Panel();
			cboCuadrilla = new ComboBox();
			btnAceptarCuadrilla = new Button();
			label3 = new Label();
			btnImprimir = new Button();
			lblCuadrilla = new Label();
			dgvAsistencia = new DataGridView();
			dgvEmployee = new DataGridView();
			lblSemanaFinal = new Label();
			cboSemanaFinal = new ComboBox();
			cboSemanaInicial = new ComboBox();
			lblsub = new Label();
			label2 = new Label();
			label4 = new Label();
			btnExcel = new Button();
			pllEmpleado.SuspendLayout();
			pllCuadrilla.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			SuspendLayout();
			// 
			// lblReporte
			// 
			lblReporte.AutoSize = true;
			lblReporte.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblReporte.Location = new Point(72, 19);
			lblReporte.Name = "lblReporte";
			lblReporte.Size = new Size(250, 32);
			lblReporte.TabIndex = 1;
			lblReporte.Text = "Reporte de Asistencia";
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEmpleado.Location = new Point(68, 118);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(83, 21);
			lblEmpleado.TabIndex = 108;
			lblEmpleado.Text = "Empleado";
			// 
			// pllEmpleado
			// 
			pllEmpleado.BackColor = SystemColors.ActiveCaption;
			pllEmpleado.BorderStyle = BorderStyle.FixedSingle;
			pllEmpleado.Controls.Add(btnAgregarListado);
			pllEmpleado.Controls.Add(btnSearch);
			pllEmpleado.Controls.Add(lbl);
			pllEmpleado.Controls.Add(txbCodigo);
			pllEmpleado.Controls.Add(txbEmpleado);
			pllEmpleado.Controls.Add(label1);
			pllEmpleado.Location = new Point(68, 142);
			pllEmpleado.Name = "pllEmpleado";
			pllEmpleado.Size = new Size(418, 92);
			pllEmpleado.TabIndex = 107;
			// 
			// btnAgregarListado
			// 
			btnAgregarListado.Image = Properties.Resources.mas_16;
			btnAgregarListado.Location = new Point(190, 49);
			btnAgregarListado.Margin = new Padding(1);
			btnAgregarListado.Name = "btnAgregarListado";
			btnAgregarListado.Size = new Size(25, 25);
			btnAgregarListado.TabIndex = 106;
			btnAgregarListado.UseVisualStyleBackColor = true;
			btnAgregarListado.Click += btnAgregarListado_Click;
			// 
			// btnSearch
			// 
			btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
			btnSearch.Font = new Font("Segoe UI", 14F);
			btnSearch.Image = Properties.Resources.BuscarLupa1;
			btnSearch.Location = new Point(377, 12);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(25, 25);
			btnSearch.TabIndex = 105;
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// lbl
			// 
			lbl.AutoSize = true;
			lbl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lbl.Location = new Point(3, 53);
			lbl.Name = "lbl";
			lbl.Size = new Size(54, 19);
			lbl.TabIndex = 104;
			lbl.Text = "Codigo";
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(93, 49);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(93, 23);
			txbCodigo.TabIndex = 103;
			// 
			// txbEmpleado
			// 
			txbEmpleado.Enabled = false;
			txbEmpleado.Location = new Point(93, 12);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(278, 23);
			txbEmpleado.TabIndex = 102;
			// 
			// btnAcceptarEmpleado
			// 
			btnAcceptarEmpleado.Location = new Point(158, 471);
			btnAcceptarEmpleado.Name = "btnAcceptarEmpleado";
			btnAcceptarEmpleado.Size = new Size(126, 34);
			btnAcceptarEmpleado.TabIndex = 101;
			btnAcceptarEmpleado.Text = "Mostrar";
			btnAcceptarEmpleado.UseVisualStyleBackColor = true;
			btnAcceptarEmpleado.Click += btnAcceptarEmpleado_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			label1.Location = new Point(3, 13);
			label1.Name = "label1";
			label1.Size = new Size(70, 19);
			label1.TabIndex = 39;
			label1.Text = "Empleado";
			// 
			// pllCuadrilla
			// 
			pllCuadrilla.BackColor = SystemColors.ActiveCaption;
			pllCuadrilla.BorderStyle = BorderStyle.FixedSingle;
			pllCuadrilla.Controls.Add(cboCuadrilla);
			pllCuadrilla.Controls.Add(btnAceptarCuadrilla);
			pllCuadrilla.Controls.Add(label3);
			pllCuadrilla.Location = new Point(579, 142);
			pllCuadrilla.Name = "pllCuadrilla";
			pllCuadrilla.Size = new Size(373, 92);
			pllCuadrilla.TabIndex = 109;
			// 
			// cboCuadrilla
			// 
			cboCuadrilla.DropDownStyle = ComboBoxStyle.DropDownList;
			cboCuadrilla.FormattingEnabled = true;
			cboCuadrilla.Location = new Point(74, 13);
			cboCuadrilla.Name = "cboCuadrilla";
			cboCuadrilla.Size = new Size(278, 23);
			cboCuadrilla.TabIndex = 103;
			// 
			// btnAceptarCuadrilla
			// 
			btnAceptarCuadrilla.Location = new Point(289, 53);
			btnAceptarCuadrilla.Name = "btnAceptarCuadrilla";
			btnAceptarCuadrilla.Size = new Size(63, 24);
			btnAceptarCuadrilla.TabIndex = 102;
			btnAceptarCuadrilla.Text = "Aceptar";
			btnAceptarCuadrilla.UseVisualStyleBackColor = true;
			btnAceptarCuadrilla.Click += btnAceptarCuadrilla_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			label3.Location = new Point(3, 13);
			label3.Name = "label3";
			label3.Size = new Size(65, 19);
			label3.TabIndex = 39;
			label3.Text = "Cuadrilla";
			// 
			// btnImprimir
			// 
			btnImprimir.Image = (Image)resources.GetObject("btnImprimir.Image");
			btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
			btnImprimir.Location = new Point(752, 471);
			btnImprimir.Name = "btnImprimir";
			btnImprimir.Padding = new Padding(10, 0, 10, 0);
			btnImprimir.Size = new Size(126, 34);
			btnImprimir.TabIndex = 113;
			btnImprimir.Text = "Imprimir ";
			btnImprimir.TextAlign = ContentAlignment.MiddleRight;
			btnImprimir.UseVisualStyleBackColor = true;
			btnImprimir.Click += btnImprimir_Click;
			// 
			// lblCuadrilla
			// 
			lblCuadrilla.AutoSize = true;
			lblCuadrilla.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCuadrilla.Location = new Point(579, 118);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(73, 21);
			lblCuadrilla.TabIndex = 110;
			lblCuadrilla.Text = "Cuadrilla";
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
			dgvAsistencia.Location = new Point(12, 508);
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
			dgvAsistencia.Size = new Size(998, 303);
			dgvAsistencia.TabIndex = 112;
			// 
			// dgvEmployee
			// 
			dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvEmployee.BackgroundColor = Color.White;
			dgvEmployee.BorderStyle = BorderStyle.Fixed3D;
			dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEmployee.Location = new Point(51, 289);
			dgvEmployee.Name = "dgvEmployee";
			dgvEmployee.Size = new Size(922, 173);
			dgvEmployee.TabIndex = 111;
			// 
			// lblSemanaFinal
			// 
			lblSemanaFinal.AutoSize = true;
			lblSemanaFinal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSemanaFinal.Location = new Point(583, 68);
			lblSemanaFinal.Name = "lblSemanaFinal";
			lblSemanaFinal.Size = new Size(108, 21);
			lblSemanaFinal.TabIndex = 106;
			lblSemanaFinal.Text = "Semana Final:";
			// 
			// cboSemanaFinal
			// 
			cboSemanaFinal.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemanaFinal.FormattingEnabled = true;
			cboSemanaFinal.Location = new Point(697, 70);
			cboSemanaFinal.Name = "cboSemanaFinal";
			cboSemanaFinal.Size = new Size(235, 23);
			cboSemanaFinal.TabIndex = 105;
			cboSemanaFinal.SelectedIndexChanged += cboSemanaFinal_SelectedIndexChanged;
			// 
			// cboSemanaInicial
			// 
			cboSemanaInicial.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemanaInicial.FormattingEnabled = true;
			cboSemanaInicial.Location = new Point(195, 70);
			cboSemanaInicial.Name = "cboSemanaInicial";
			cboSemanaInicial.Size = new Size(235, 23);
			cboSemanaInicial.TabIndex = 104;
			cboSemanaInicial.SelectedIndexChanged += cboSemanaInicial_SelectedIndexChanged;
			// 
			// lblsub
			// 
			lblsub.AutoSize = true;
			lblsub.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblsub.Location = new Point(72, 72);
			lblsub.Name = "lblsub";
			lblsub.Size = new Size(117, 21);
			lblsub.TabIndex = 103;
			lblsub.Text = "Semana Inicial:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			label2.Location = new Point(51, 267);
			label2.Name = "label2";
			label2.Size = new Size(119, 19);
			label2.TabIndex = 114;
			label2.Text = "Listado Empleado";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			label4.Location = new Point(12, 486);
			label4.Name = "label4";
			label4.Size = new Size(140, 19);
			label4.TabIndex = 115;
			label4.Text = "Listado de Asistencia";
			// 
			// btnExcel
			// 
			btnExcel.Image = (Image)resources.GetObject("btnExcel.Image");
			btnExcel.ImageAlign = ContentAlignment.MiddleRight;
			btnExcel.Location = new Point(884, 471);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(10, 0, 10, 0);
			btnExcel.Size = new Size(126, 34);
			btnExcel.TabIndex = 116;
			btnExcel.Text = "Exportar ";
			btnExcel.TextAlign = ContentAlignment.MiddleLeft;
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
			// 
			// FrmAsistenciaR
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1047, 825);
			Controls.Add(btnExcel);
			Controls.Add(label4);
			Controls.Add(label2);
			Controls.Add(lblEmpleado);
			Controls.Add(pllEmpleado);
			Controls.Add(btnAcceptarEmpleado);
			Controls.Add(pllCuadrilla);
			Controls.Add(btnImprimir);
			Controls.Add(lblCuadrilla);
			Controls.Add(dgvAsistencia);
			Controls.Add(dgvEmployee);
			Controls.Add(lblSemanaFinal);
			Controls.Add(cboSemanaFinal);
			Controls.Add(cboSemanaInicial);
			Controls.Add(lblsub);
			Controls.Add(lblReporte);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAsistenciaR";
			Text = "Reporte de Asistencia ";
			Load += FrmAsistenciaR_Load;
			pllEmpleado.ResumeLayout(false);
			pllEmpleado.PerformLayout();
			pllCuadrilla.ResumeLayout(false);
			pllCuadrilla.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvAsistencia).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblReporte;
		private Label lblEmpleado;
		private Panel pllEmpleado;
		private Button btnAcceptarEmpleado;
		private Label label1;
		private Panel pllCuadrilla;
		public ComboBox cboCuadrilla;
		private Button btnAceptarCuadrilla;
		private Label label3;
		private Label lblCuadrilla;
		public DataGridView dgvAsistencia;
		public DataGridView dgvEmployee;
		private Label lblSemanaFinal;
		public ComboBox cboSemanaFinal;
		public ComboBox cboSemanaInicial;
		private Label lblsub;
		public Button btnImprimir;
		private Label lbl;
		private Button btnSearch;
		public TextBox txbEmpleado;
		public TextBox txbCodigo;
		private Button btnAgregarListado;
		private Label label2;
		private Label label4;
		public Button btnExcel;
	}
}
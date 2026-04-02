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
			cboEmployee = new ComboBox();
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
			lblReporte.Location = new Point(12, 21);
			lblReporte.Name = "lblReporte";
			lblReporte.Size = new Size(250, 32);
			lblReporte.TabIndex = 1;
			lblReporte.Text = "Reporte de Asistencia";
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEmpleado.Location = new Point(12, 129);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(83, 21);
			lblEmpleado.TabIndex = 108;
			lblEmpleado.Text = "Empleado";
			// 
			// pllEmpleado
			// 
			pllEmpleado.BackColor = SystemColors.ActiveCaption;
			pllEmpleado.BorderStyle = BorderStyle.FixedSingle;
			pllEmpleado.Controls.Add(cboEmployee);
			pllEmpleado.Controls.Add(btnAcceptarEmpleado);
			pllEmpleado.Controls.Add(label1);
			pllEmpleado.Location = new Point(12, 153);
			pllEmpleado.Name = "pllEmpleado";
			pllEmpleado.Size = new Size(408, 76);
			pllEmpleado.TabIndex = 107;
			// 
			// cboEmployee
			// 
			cboEmployee.FormattingEnabled = true;
			cboEmployee.Location = new Point(78, 12);
			cboEmployee.Name = "cboEmployee";
			cboEmployee.Size = new Size(309, 23);
			cboEmployee.TabIndex = 104;
			// 
			// btnAcceptarEmpleado
			// 
			btnAcceptarEmpleado.Location = new Point(324, 47);
			btnAcceptarEmpleado.Name = "btnAcceptarEmpleado";
			btnAcceptarEmpleado.Size = new Size(63, 24);
			btnAcceptarEmpleado.TabIndex = 101;
			btnAcceptarEmpleado.Text = "Aceptar";
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
			pllCuadrilla.Location = new Point(523, 153);
			pllCuadrilla.Name = "pllCuadrilla";
			pllCuadrilla.Size = new Size(373, 76);
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
			btnAceptarCuadrilla.Location = new Point(289, 47);
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
			btnImprimir.Location = new Point(801, 470);
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
			lblCuadrilla.Location = new Point(523, 129);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(73, 21);
			lblCuadrilla.TabIndex = 110;
			lblCuadrilla.Text = "Cuadrilla";
			// 
			// dgvAsistencia
			// 
			dgvAsistencia.AllowUserToAddRows = false;
			dgvAsistencia.AllowUserToDeleteRows = false;
			dgvAsistencia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
			dgvAsistencia.Location = new Point(6, 510);
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
			dgvAsistencia.Size = new Size(920, 273);
			dgvAsistencia.TabIndex = 112;
			// 
			// dgvEmployee
			// 
			dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvEmployee.BackgroundColor = Color.White;
			dgvEmployee.BorderStyle = BorderStyle.Fixed3D;
			dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEmployee.Location = new Point(5, 272);
			dgvEmployee.Name = "dgvEmployee";
			dgvEmployee.Size = new Size(922, 181);
			dgvEmployee.TabIndex = 111;
			// 
			// lblSemanaFinal
			// 
			lblSemanaFinal.AutoSize = true;
			lblSemanaFinal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSemanaFinal.Location = new Point(523, 70);
			lblSemanaFinal.Name = "lblSemanaFinal";
			lblSemanaFinal.Size = new Size(108, 21);
			lblSemanaFinal.TabIndex = 106;
			lblSemanaFinal.Text = "Semana Final:";
			// 
			// cboSemanaFinal
			// 
			cboSemanaFinal.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemanaFinal.FormattingEnabled = true;
			cboSemanaFinal.Location = new Point(637, 72);
			cboSemanaFinal.Name = "cboSemanaFinal";
			cboSemanaFinal.Size = new Size(235, 23);
			cboSemanaFinal.TabIndex = 105;
			cboSemanaFinal.SelectedIndexChanged += cboSemanaFinal_SelectedIndexChanged;
			// 
			// cboSemanaInicial
			// 
			cboSemanaInicial.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemanaInicial.FormattingEnabled = true;
			cboSemanaInicial.Location = new Point(135, 72);
			cboSemanaInicial.Name = "cboSemanaInicial";
			cboSemanaInicial.Size = new Size(235, 23);
			cboSemanaInicial.TabIndex = 104;
			cboSemanaInicial.SelectedIndexChanged += cboSemanaInicial_SelectedIndexChanged;
			// 
			// lblsub
			// 
			lblsub.AutoSize = true;
			lblsub.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblsub.Location = new Point(12, 74);
			lblsub.Name = "lblsub";
			lblsub.Size = new Size(117, 21);
			lblsub.TabIndex = 103;
			lblsub.Text = "Semana Inicial:";
			// 
			// FrmAsistenciaR
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(938, 795);
			Controls.Add(lblEmpleado);
			Controls.Add(pllEmpleado);
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
		public ComboBox cboEmployee;
		private Button btnAcceptarEmpleado;
		private Label label1;
		private Panel pllCuadrilla;
		public ComboBox cboCuadrilla;
		private Button btnAceptarCuadrilla;
		private Label label3;
		private Button btnImprimir;
		private Label lblCuadrilla;
		public DataGridView dgvAsistencia;
		public DataGridView dgvEmployee;
		private Label lblSemanaFinal;
		public ComboBox cboSemanaFinal;
		public ComboBox cboSemanaInicial;
		private Label lblsub;
	}
}
namespace SisUvex.Nomina.Nom_bajas_personal
{
	partial class FrmEmployeeStatus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployeeStatus));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			groupBox1 = new GroupBox();
			btnMostrar = new Button();
			label4 = new Label();
			label2 = new Label();
			cboCuadrilla = new ComboBox();
			cboTemporada = new ComboBox();
			dtpFecha = new DateTimePicker();
			label1 = new Label();
			label3 = new Label();
			dgvCatalog = new DataGridView();
			this.btnAplicar = new Button();
			groupBox2 = new GroupBox();
			txbEmpleado = new TextBox();
			label5 = new Label();
			btnQuitar = new Button();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnMostrar);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(cboCuadrilla);
			groupBox1.Controls.Add(cboTemporada);
			groupBox1.Location = new Point(12, 52);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(621, 130);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Informacion General ";
			// 
			// btnMostrar
			// 
			btnMostrar.Image = (Image)resources.GetObject("btnMostrar.Image");
			btnMostrar.ImageAlign = ContentAlignment.MiddleLeft;
			btnMostrar.Location = new Point(422, 43);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Padding = new Padding(12, 0, 12, 0);
			btnMostrar.Size = new Size(167, 26);
			btnMostrar.TabIndex = 6;
			btnMostrar.Text = "Mostrar Empleados";
			btnMostrar.TextAlign = ContentAlignment.MiddleRight;
			btnMostrar.UseVisualStyleBackColor = true;
			btnMostrar.Click += btnMostrar_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label4.Location = new Point(16, 38);
			label4.Name = "label4";
			label4.Size = new Size(94, 21);
			label4.TabIndex = 5;
			label4.Text = "Temporada :";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.Location = new Point(16, 83);
			label2.Name = "label2";
			label2.Size = new Size(79, 21);
			label2.TabIndex = 3;
			label2.Text = "Cuadrilla :";
			// 
			// cboCuadrilla
			// 
			cboCuadrilla.FormattingEnabled = true;
			cboCuadrilla.Location = new Point(111, 81);
			cboCuadrilla.Name = "cboCuadrilla";
			cboCuadrilla.Size = new Size(260, 23);
			cboCuadrilla.TabIndex = 2;
			// 
			// cboTemporada
			// 
			cboTemporada.FormattingEnabled = true;
			cboTemporada.Location = new Point(111, 36);
			cboTemporada.Name = "cboTemporada";
			cboTemporada.Size = new Size(260, 23);
			cboTemporada.TabIndex = 4;
			cboTemporada.SelectedIndexChanged += cboTemporada_SelectedIndexChanged;
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(111, 40);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(260, 23);
			dtpFecha.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(16, 41);
			label1.Name = "label1";
			label1.Size = new Size(57, 21);
			label1.TabIndex = 0;
			label1.Text = "Fecha :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(12, 9);
			label3.Name = "label3";
			label3.Size = new Size(281, 25);
			label3.TabIndex = 1;
			label3.Text = "Registro de Bajas de Empleados";
			// 
			// dgvCatalog
			// 
			dgvCatalog.AllowUserToAddRows = false;
			dgvCatalog.AllowUserToDeleteRows = false;
			dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvCatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvCatalog.BackgroundColor = SystemColors.ControlLightLight;
			dgvCatalog.BorderStyle = BorderStyle.Fixed3D;
			dgvCatalog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvCatalog.ColumnHeadersHeight = 29;
			dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCatalog.EnableHeadersVisualStyles = false;
			dgvCatalog.ImeMode = ImeMode.NoControl;
			dgvCatalog.Location = new Point(5, 310);
			dgvCatalog.Name = "dgvCatalog";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvCatalog.RowHeadersVisible = false;
			dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCatalog.Size = new Size(910, 499);
			dgvCatalog.TabIndex = 14;
			// 
			// btnAplicar
			// 
			this.btnAplicar.Image = (Image)resources.GetObject("btnAplicar.Image");
			this.btnAplicar.ImageAlign = ContentAlignment.MiddleLeft;
			this.btnAplicar.Location = new Point(422, 37);
			this.btnAplicar.Name = "btnAplicar";
			this.btnAplicar.Padding = new Padding(15, 0, 40, 0);
			this.btnAplicar.Size = new Size(167, 26);
			this.btnAplicar.TabIndex = 7;
			this.btnAplicar.Text = "Aplicar Baja";
			this.btnAplicar.TextAlign = ContentAlignment.MiddleRight;
			this.btnAplicar.UseVisualStyleBackColor = true;
			this.btnAplicar.Click += this.button1_Click;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(dtpFecha);
			groupBox2.Controls.Add(this.btnAplicar);
			groupBox2.Controls.Add(label1);
			groupBox2.Location = new Point(12, 188);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(621, 87);
			groupBox2.TabIndex = 15;
			groupBox2.TabStop = false;
			groupBox2.Text = "Seleccione la fecha en que se aplicará la baja:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(123, 281);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(260, 23);
			txbEmpleado.TabIndex = 16;
			txbEmpleado.TextChanged += txbEmpleado_TextChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label5.Location = new Point(28, 284);
			label5.Name = "label5";
			label5.Size = new Size(86, 21);
			label5.TabIndex = 17;
			label5.Text = "Empleado :";
			// 
			// btnQuitar
			// 
			btnQuitar.Image = (Image)resources.GetObject("btnQuitar.Image");
			btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
			btnQuitar.Location = new Point(434, 281);
			btnQuitar.Name = "btnQuitar";
			btnQuitar.Padding = new Padding(15, 0, 40, 0);
			btnQuitar.Size = new Size(167, 23);
			btnQuitar.TabIndex = 18;
			btnQuitar.Text = "Quitar Baja";
			btnQuitar.TextAlign = ContentAlignment.MiddleRight;
			btnQuitar.UseVisualStyleBackColor = true;
			btnQuitar.Click += button2_Click;
			// 
			// FrmEmployeeStatus
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(927, 821);
			Controls.Add(btnQuitar);
			Controls.Add(label5);
			Controls.Add(txbEmpleado);
			Controls.Add(groupBox2);
			Controls.Add(dgvCatalog);
			Controls.Add(label3);
			Controls.Add(groupBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmEmployeeStatus";
			Text = "Registro de Bajas de Empleados";
			Load += FrmEmployeeStatus_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBox1;
		private Label label2;
		private DateTimePicker dateTimePicker1;
		private Label label1;
		private Label label3;
		public DataGridView dgvCatalog;
		public DateTimePicker dtpFecha;
		public ComboBox cboCuadrilla;
		private Label label4;
		public ComboBox cboTemporada;
		private Button btnMostrar;
		private Button btnAplicar;
		private GroupBox groupBox2;
		private TextBox txbEmpleado;
		private Label label5;
		private Button btnQuitar;
	}
}
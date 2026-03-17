namespace SisUvex.Nomina.Nom_semAutomatizada
{
	partial class FrmSemiAutomatedPayroll
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSemiAutomatedPayroll));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			lblLote = new Label();
			lblReferencia = new Label();
			dtpFecha = new DateTimePicker();
			txbReferencia = new TextBox();
			cboLote = new ComboBox();
			lbencabezado = new Label();
			btnCVS = new Button();
			btnExcel = new Button();
			btncargar = new Button();
			dgvEmployee = new DataGridView();
			btnCalcularLibra = new Button();
			cboLineas = new ComboBox();
			lblLineas = new Label();
			panel1 = new Panel();
			panel2 = new Panel();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// lblLote
			// 
			lblLote.AutoSize = true;
			lblLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLote.Location = new Point(3, 76);
			lblLote.Name = "lblLote";
			lblLote.Size = new Size(47, 21);
			lblLote.TabIndex = 0;
			lblLote.Text = "Lote :";
			// 
			// lblReferencia
			// 
			lblReferencia.AutoSize = true;
			lblReferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblReferencia.Location = new Point(3, 136);
			lblReferencia.Name = "lblReferencia";
			lblReferencia.Size = new Size(90, 21);
			lblReferencia.TabIndex = 1;
			lblReferencia.Text = "Referencia :";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(27, 96);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(260, 23);
			dtpFecha.TabIndex = 2;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// txbReferencia
			// 
			txbReferencia.Location = new Point(99, 138);
			txbReferencia.Multiline = true;
			txbReferencia.Name = "txbReferencia";
			txbReferencia.Size = new Size(135, 25);
			txbReferencia.TabIndex = 3;
			// 
			// cboLote
			// 
			cboLote.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(56, 78);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(135, 23);
			cboLote.TabIndex = 4;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(332, 9);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(329, 32);
			lbencabezado.TabIndex = 5;
			lbencabezado.Text = "Reporte de Empaque Central";
			// 
			// btnCVS
			// 
			btnCVS.BackgroundImageLayout = ImageLayout.Stretch;
			btnCVS.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCVS.Image = (Image)resources.GetObject("btnCVS.Image");
			btnCVS.ImageAlign = ContentAlignment.MiddleLeft;
			btnCVS.Location = new Point(648, 76);
			btnCVS.Name = "btnCVS";
			btnCVS.Padding = new Padding(10, 0, 10, 0);
			btnCVS.Size = new Size(158, 41);
			btnCVS.TabIndex = 7;
			btnCVS.Text = "Exportar CSV";
			btnCVS.TextAlign = ContentAlignment.MiddleRight;
			btnCVS.UseVisualStyleBackColor = true;
			btnCVS.Click += btnCVS_Click;
			// 
			// btnExcel
			// 
			btnExcel.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnExcel.Image = Properties.Resources.excelIcon16;
			btnExcel.ImageAlign = ContentAlignment.MiddleLeft;
			btnExcel.Location = new Point(648, 157);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(10, 0, 10, 0);
			btnExcel.Size = new Size(158, 42);
			btnExcel.TabIndex = 8;
			btnExcel.Text = "Exportar Excel";
			btnExcel.TextAlign = ContentAlignment.MiddleRight;
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btncargar.Image = (Image)resources.GetObject("btncargar.Image");
			btncargar.ImageAlign = ContentAlignment.MiddleLeft;
			btncargar.Location = new Point(227, 409);
			btncargar.Name = "btncargar";
			btncargar.Padding = new Padding(10, 0, 10, 0);
			btncargar.Size = new Size(148, 38);
			btncargar.TabIndex = 9;
			btncargar.Text = "Cargar Datos";
			btncargar.TextAlign = ContentAlignment.MiddleRight;
			btncargar.UseVisualStyleBackColor = true;
			btncargar.Click += btncargar_Click;
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
			dgvEmployee.Location = new Point(27, 450);
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
			dgvEmployee.Size = new Size(878, 353);
			dgvEmployee.TabIndex = 17;
			// 
			// btnCalcularLibra
			// 
			btnCalcularLibra.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCalcularLibra.Location = new Point(27, 408);
			btnCalcularLibra.Name = "btnCalcularLibra";
			btnCalcularLibra.Size = new Size(148, 39);
			btnCalcularLibra.TabIndex = 18;
			btnCalcularLibra.Text = "Cargar Libras";
			btnCalcularLibra.UseVisualStyleBackColor = true;
			btnCalcularLibra.Click += btnCalcularLibra_Click;
			// 
			// cboLineas
			// 
			cboLineas.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLineas.FormattingEnabled = true;
			cboLineas.Location = new Point(774, 419);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(131, 23);
			cboLineas.TabIndex = 19;
			// 
			// lblLineas
			// 
			lblLineas.AutoSize = true;
			lblLineas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLineas.Location = new Point(705, 421);
			lblLineas.Name = "lblLineas";
			lblLineas.Size = new Size(63, 21);
			lblLineas.TabIndex = 20;
			lblLineas.Text = "Bandas:";
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLight;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(lblLote);
			panel1.Controls.Add(cboLote);
			panel1.Controls.Add(lblReferencia);
			panel1.Controls.Add(txbReferencia);
			panel1.Controls.Add(btnCVS);
			panel1.Controls.Add(btnExcel);
			panel1.Location = new Point(27, 139);
			panel1.Name = "panel1";
			panel1.Size = new Size(878, 227);
			panel1.TabIndex = 21;
			// 
			// panel2
			// 
			panel2.BackColor = SystemColors.ActiveBorder;
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Controls.Add(label1);
			panel2.Location = new Point(27, 139);
			panel2.Name = "panel2";
			panel2.Size = new Size(878, 40);
			panel2.TabIndex = 9;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(343, 10);
			label1.Name = "label1";
			label1.Size = new Size(165, 21);
			label1.TabIndex = 0;
			label1.Text = "Generar Reporte CSV";
			// 
			// FrmSemiAutomatedPayroll
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(968, 815);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(lblLineas);
			Controls.Add(cboLineas);
			Controls.Add(btnCalcularLibra);
			Controls.Add(dgvEmployee);
			Controls.Add(btncargar);
			Controls.Add(lbencabezado);
			Controls.Add(dtpFecha);
			Name = "FrmSemiAutomatedPayroll";
			Text = "FrmSemiAutomatedPayroll";
			Load += FrmSemiAutomatedPayroll_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblLote;
		private Label lblReferencia;
		private Label lbencabezado;
		private Button btnCVS;
		private Button btnExcel;
		private Button btncargar;
		public DateTimePicker dtpFecha;
		public TextBox txbReferencia;
		public ComboBox cboLote;
		public DataGridView dgvEmployee;
		private Button btnCalcularLibra;
		private Label lblLineas;
		public ComboBox cboLineas;
		private Panel panel1;
		private Panel panel2;
		private Label label1;
	}
}
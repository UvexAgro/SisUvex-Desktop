namespace SisUvex.Nomina.Reporte_de_horas
{
	partial class FrmPackingHours
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPackingHours));
			dgvHoras = new DataGridView();
			lbencabezado = new Label();
			lblFechaInicial = new Label();
			cboSemana = new ComboBox();
			lblTemporada = new Label();
			cboTemporada = new ComboBox();
			lblFechaFinal = new Label();
			cboFinal = new ComboBox();
			btnAdd = new Button();
			btnModify = new Button();
			label1 = new Label();
			btnExcel = new Button();
			((System.ComponentModel.ISupportInitialize)dgvHoras).BeginInit();
			SuspendLayout();
			// 
			// dgvHoras
			// 
			dgvHoras.AllowUserToAddRows = false;
			dgvHoras.AllowUserToDeleteRows = false;
			dgvHoras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dgvHoras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvHoras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvHoras.BackgroundColor = SystemColors.ControlLightLight;
			dgvHoras.BorderStyle = BorderStyle.Fixed3D;
			dgvHoras.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvHoras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvHoras.ColumnHeadersHeight = 58;
			dgvHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvHoras.EnableHeadersVisualStyles = false;
			dgvHoras.GridColor = SystemColors.InactiveCaption;
			dgvHoras.ImeMode = ImeMode.NoControl;
			dgvHoras.Location = new Point(40, 186);
			dgvHoras.Name = "dgvHoras";
			dgvHoras.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvHoras.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvHoras.RowHeadersVisible = false;
			dgvHoras.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvHoras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvHoras.Size = new Size(952, 615);
			dgvHoras.TabIndex = 19;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(352, 9);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(314, 32);
			lbencabezado.TabIndex = 20;
			lbencabezado.Text = "Reporte de Horas Empaque";
			// 
			// lblFechaInicial
			// 
			lblFechaInicial.AutoSize = true;
			lblFechaInicial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaInicial.Location = new Point(39, 127);
			lblFechaInicial.Name = "lblFechaInicial";
			lblFechaInicial.Size = new Size(88, 15);
			lblFechaInicial.TabIndex = 29;
			lblFechaInicial.Text = "Semana Inicial:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(39, 145);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(235, 23);
			cboSemana.TabIndex = 30;
			cboSemana.SelectedIndexChanged += cboSemana_SelectedIndexChanged;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTemporada.Location = new Point(40, 49);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(79, 17);
			lblTemporada.TabIndex = 31;
			lblTemporada.Text = "Temporada:";
			// 
			// cboTemporada
			// 
			cboTemporada.DropDownStyle = ComboBoxStyle.DropDownList;
			cboTemporada.FormattingEnabled = true;
			cboTemporada.Location = new Point(40, 73);
			cboTemporada.Name = "cboTemporada";
			cboTemporada.Size = new Size(256, 23);
			cboTemporada.TabIndex = 32;
			// 
			// lblFechaFinal
			// 
			lblFechaFinal.AutoSize = true;
			lblFechaFinal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaFinal.Location = new Point(333, 127);
			lblFechaFinal.Name = "lblFechaFinal";
			lblFechaFinal.Size = new Size(81, 15);
			lblFechaFinal.TabIndex = 33;
			lblFechaFinal.Text = "Semana Final:";
			// 
			// cboFinal
			// 
			cboFinal.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFinal.FormattingEnabled = true;
			cboFinal.Location = new Point(333, 145);
			cboFinal.Name = "cboFinal";
			cboFinal.Size = new Size(235, 23);
			cboFinal.TabIndex = 34;
			cboFinal.SelectedIndexChanged += cboFinal_SelectedIndexChanged;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(752, 145);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(117, 26);
			btnAdd.TabIndex = 37;
			btnAdd.Text = "Añadir";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnModify
			// 
			btnModify.Location = new Point(875, 143);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(117, 28);
			btnModify.TabIndex = 38;
			btnModify.Text = "Modificar";
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(781, 121);
			label1.Name = "label1";
			label1.Size = new Size(178, 17);
			label1.TabIndex = 39;
			label1.Text = "Añadir Horario de Empaque";
			// 
			// btnExcel
			// 
			btnExcel.Image = (Image)resources.GetObject("btnExcel.Image");
			btnExcel.ImageAlign = ContentAlignment.MiddleRight;
			btnExcel.Location = new Point(866, 62);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(10, 0, 10, 0);
			btnExcel.Size = new Size(126, 34);
			btnExcel.TabIndex = 117;
			btnExcel.Text = "Exportar ";
			btnExcel.TextAlign = ContentAlignment.MiddleLeft;
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
			// 
			// FrmPackingHours
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1020, 813);
			Controls.Add(btnExcel);
			Controls.Add(label1);
			Controls.Add(btnModify);
			Controls.Add(btnAdd);
			Controls.Add(cboFinal);
			Controls.Add(lblFechaFinal);
			Controls.Add(cboTemporada);
			Controls.Add(lblTemporada);
			Controls.Add(cboSemana);
			Controls.Add(lblFechaInicial);
			Controls.Add(lbencabezado);
			Controls.Add(dgvHoras);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmPackingHours";
			Text = "Reporte de Horas";
			Load += FrmPackingHours_Load;
			((System.ComponentModel.ISupportInitialize)dgvHoras).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public DataGridView dgvHoras;
		private Label lbencabezado;
		private Label lblFechaInicial;
		public ComboBox cboSemana;
		private Label lblTemporada;
		public ComboBox cboTemporada;
		private Label lblFechaFinal;
		public ComboBox cboFinal;
		private Button btnAdd;
		private Button btnModify;
		private Label label1;
		public Button btnExcel;
	}
}
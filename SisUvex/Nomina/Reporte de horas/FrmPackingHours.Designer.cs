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
			btnExcel = new Button();
			btnEliminar = new Button();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvHoras).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// dgvHoras
			// 
			dgvHoras.AllowUserToAddRows = false;
			dgvHoras.AllowUserToDeleteRows = false;
			dgvHoras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
			dgvHoras.Location = new Point(14, 268);
			dgvHoras.Margin = new Padding(3, 4, 3, 4);
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
			dgvHoras.Size = new Size(1277, 771);
			dgvHoras.TabIndex = 19;
			dgvHoras.CellPainting += dgvHoras_CellPainting;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(12, 9);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(394, 41);
			lbencabezado.TabIndex = 20;
			lbencabezado.Text = "Reporte de Horas Empaque";
			// 
			// lblFechaInicial
			// 
			lblFechaInicial.AutoSize = true;
			lblFechaInicial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaInicial.Location = new Point(17, 74);
			lblFechaInicial.Name = "lblFechaInicial";
			lblFechaInicial.Size = new Size(111, 20);
			lblFechaInicial.TabIndex = 29;
			lblFechaInicial.Text = "Semana Inicial:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(134, 71);
			cboSemana.Margin = new Padding(3, 4, 3, 4);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(292, 28);
			cboSemana.TabIndex = 30;
			cboSemana.SelectedIndexChanged += cboSemana_SelectedIndexChanged;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			lblTemporada.Location = new Point(17, 43);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(90, 20);
			lblTemporada.TabIndex = 31;
			lblTemporada.Text = "Temporada:";
			// 
			// cboTemporada
			// 
			cboTemporada.DropDownStyle = ComboBoxStyle.DropDownList;
			cboTemporada.FormattingEnabled = true;
			cboTemporada.Location = new Point(134, 35);
			cboTemporada.Margin = new Padding(3, 4, 3, 4);
			cboTemporada.Name = "cboTemporada";
			cboTemporada.Size = new Size(292, 28);
			cboTemporada.TabIndex = 32;
			// 
			// lblFechaFinal
			// 
			lblFechaFinal.AutoSize = true;
			lblFechaFinal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaFinal.Location = new Point(17, 112);
			lblFechaFinal.Name = "lblFechaFinal";
			lblFechaFinal.Size = new Size(104, 20);
			lblFechaFinal.TabIndex = 33;
			lblFechaFinal.Text = "Semana Final:";
			// 
			// cboFinal
			// 
			cboFinal.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFinal.FormattingEnabled = true;
			cboFinal.Location = new Point(134, 109);
			cboFinal.Margin = new Padding(3, 4, 3, 4);
			cboFinal.Name = "cboFinal";
			cboFinal.Size = new Size(292, 28);
			cboFinal.TabIndex = 34;
			cboFinal.SelectedIndexChanged += cboFinal_SelectedIndexChanged;
			// 
			// btnAdd
			// 
			btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
			btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
			btnAdd.Location = new Point(32, 30);
			btnAdd.Margin = new Padding(3, 4, 3, 4);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(3, 0, 3, 0);
			btnAdd.Size = new Size(110, 35);
			btnAdd.TabIndex = 37;
			btnAdd.Text = "Añadir";
			btnAdd.TextAlign = ContentAlignment.MiddleRight;
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnModify
			// 
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(181, 30);
			btnModify.Margin = new Padding(3, 4, 3, 4);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(110, 35);
			btnModify.TabIndex = 38;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnExcel
			// 
			btnExcel.Image = (Image)resources.GetObject("btnExcel.Image");
			btnExcel.ImageAlign = ContentAlignment.MiddleLeft;
			btnExcel.Location = new Point(485, 30);
			btnExcel.Margin = new Padding(3, 4, 3, 4);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(3, 0, 3, 0);
			btnExcel.Size = new Size(109, 35);
			btnExcel.TabIndex = 117;
			btnExcel.Text = "Exportar ";
			btnExcel.TextAlign = ContentAlignment.MiddleRight;
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
			// 
			// btnEliminar
			// 
			btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
			btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
			btnEliminar.Location = new Point(339, 30);
			btnEliminar.Margin = new Padding(3, 4, 3, 4);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Size = new Size(109, 35);
			btnEliminar.TabIndex = 118;
			btnEliminar.Text = "Eliminar";
			btnEliminar.TextAlign = ContentAlignment.MiddleRight;
			btnEliminar.UseVisualStyleBackColor = true;
			btnEliminar.Click += btnEliminar_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(cboSemana);
			groupBox1.Controls.Add(lblFechaInicial);
			groupBox1.Controls.Add(lblTemporada);
			groupBox1.Controls.Add(cboTemporada);
			groupBox1.Controls.Add(lblFechaFinal);
			groupBox1.Controls.Add(cboFinal);
			groupBox1.Location = new Point(14, 101);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(449, 160);
			groupBox1.TabIndex = 119;
			groupBox1.TabStop = false;
			groupBox1.Text = "Filtros";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnModify);
			groupBox2.Controls.Add(btnAdd);
			groupBox2.Controls.Add(btnExcel);
			groupBox2.Controls.Add(btnEliminar);
			groupBox2.Location = new Point(662, 180);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(626, 81);
			groupBox2.TabIndex = 120;
			groupBox2.TabStop = false;
			groupBox2.Text = "Acciones ";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 8F);
			label1.Location = new Point(14, 57);
			label1.Name = "label1";
			label1.Size = new Size(560, 19);
			label1.TabIndex = 121;
			label1.Text = "Administra los horarios ajustados para cumplir con las horas permitidas durante la jornada";
			// 
			// FrmPackingHours
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1300, 1055);
			Controls.Add(label1);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(lbencabezado);
			Controls.Add(dgvHoras);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmPackingHours";
			Text = "Reporte de Horas";
			Load += FrmPackingHours_Load;
			((System.ComponentModel.ISupportInitialize)dgvHoras).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
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
		public Button btnExcel;
		private Button btnEliminar;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Label label1;
	}
}
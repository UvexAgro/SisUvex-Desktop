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
			((System.ComponentModel.ISupportInitialize)dgvHoras).BeginInit();
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
			dgvHoras.ImeMode = ImeMode.NoControl;
			dgvHoras.Location = new Point(25, 343);
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
			dgvHoras.Size = new Size(550, 218);
			dgvHoras.TabIndex = 19;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(144, 25);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(314, 32);
			lbencabezado.TabIndex = 20;
			lbencabezado.Text = "Reporte de Horas Empaque";
			// 
			// lblFechaInicial
			// 
			lblFechaInicial.AutoSize = true;
			lblFechaInicial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblFechaInicial.Location = new Point(25, 185);
			lblFechaInicial.Name = "lblFechaInicial";
			lblFechaInicial.Size = new Size(113, 21);
			lblFechaInicial.TabIndex = 29;
			lblFechaInicial.Text = "Semana Inicial:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(144, 187);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(235, 23);
			cboSemana.TabIndex = 30;
			cboSemana.SelectedIndexChanged += cboSemana_SelectedIndexChanged;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblTemporada.Location = new Point(25, 119);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(90, 21);
			lblTemporada.TabIndex = 31;
			lblTemporada.Text = "Temporada:";
			// 
			// cboTemporada
			// 
			cboTemporada.DropDownStyle = ComboBoxStyle.DropDownList;
			cboTemporada.FormattingEnabled = true;
			cboTemporada.Location = new Point(144, 121);
			cboTemporada.Name = "cboTemporada";
			cboTemporada.Size = new Size(235, 23);
			cboTemporada.TabIndex = 32;
			// 
			// lblFechaFinal
			// 
			lblFechaFinal.AutoSize = true;
			lblFechaFinal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblFechaFinal.Location = new Point(25, 256);
			lblFechaFinal.Name = "lblFechaFinal";
			lblFechaFinal.Size = new Size(106, 21);
			lblFechaFinal.TabIndex = 33;
			lblFechaFinal.Text = "Semana Final:";
			// 
			// cboFinal
			// 
			cboFinal.DropDownStyle = ComboBoxStyle.DropDownList;
			cboFinal.FormattingEnabled = true;
			cboFinal.Location = new Point(144, 258);
			cboFinal.Name = "cboFinal";
			cboFinal.Size = new Size(235, 23);
			cboFinal.TabIndex = 34;
			cboFinal.SelectedIndexChanged += cboFinal_SelectedIndexChanged;
			// 
			// FrmPackingHours
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(600, 573);
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
	}
}
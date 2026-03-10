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
			dgvHoras = new DataGridView();
			lbencabezado = new Label();
			lblSemana = new Label();
			cboSemana = new ComboBox();
			lblTemporada = new Label();
			cboTemporada = new ComboBox();
			btncargar = new Button();
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
			dgvHoras.Location = new Point(25, 255);
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
			dgvHoras.Size = new Size(550, 183);
			dgvHoras.TabIndex = 19;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(121, 28);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(314, 32);
			lbencabezado.TabIndex = 20;
			lbencabezado.Text = "Reporte de Horas Empaque";
			// 
			// lblSemana
			// 
			lblSemana.AutoSize = true;
			lblSemana.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSemana.Location = new Point(25, 185);
			lblSemana.Name = "lblSemana";
			lblSemana.Size = new Size(69, 21);
			lblSemana.TabIndex = 29;
			lblSemana.Text = "Semana:";
			// 
			// cboSemana
			// 
			cboSemana.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(100, 187);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(235, 23);
			cboSemana.TabIndex = 30;
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
			cboTemporada.Location = new Point(121, 121);
			cboTemporada.Name = "cboTemporada";
			cboTemporada.Size = new Size(235, 23);
			cboTemporada.TabIndex = 32;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btncargar.Location = new Point(444, 185);
			btncargar.Name = "btncargar";
			btncargar.Size = new Size(131, 38);
			btncargar.TabIndex = 33;
			btncargar.Text = "Cargar Datos";
			btncargar.UseVisualStyleBackColor = true;
			btncargar.Click += btncargar_Click;
			// 
			// FrmPackingHours
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(600, 450);
			Controls.Add(btncargar);
			Controls.Add(cboTemporada);
			Controls.Add(lblTemporada);
			Controls.Add(cboSemana);
			Controls.Add(lblSemana);
			Controls.Add(lbencabezado);
			Controls.Add(dgvHoras);
			Name = "FrmPackingHours";
			Text = "FrmPackingHours";
			Load += FrmPackingHours_Load;
			((System.ComponentModel.ISupportInitialize)dgvHoras).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public DataGridView dgvHoras;
		private Label lbencabezado;
		private Label lblSemana;
		public ComboBox cboSemana;
		private Label lblTemporada;
		public ComboBox cboTemporada;
		private Button btncargar;
	}
}
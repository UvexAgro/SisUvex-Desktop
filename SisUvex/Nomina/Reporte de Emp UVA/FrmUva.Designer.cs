namespace SisUvex.Nomina.Reporte_de_Emp_UVA
{
	partial class FrmUva
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUva));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			btnExcel = new Button();
			dgvHoras = new DataGridView();
			btnCargar = new Button();
			dtpFecha = new DateTimePicker();
			((System.ComponentModel.ISupportInitialize)dgvHoras).BeginInit();
			SuspendLayout();
			// 
			// btnExcel
			// 
			btnExcel.Image = (Image)resources.GetObject("btnExcel.Image");
			btnExcel.ImageAlign = ContentAlignment.MiddleRight;
			btnExcel.Location = new Point(842, 29);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(10, 0, 10, 0);
			btnExcel.Size = new Size(126, 34);
			btnExcel.TabIndex = 118;
			btnExcel.Text = "Exportar ";
			btnExcel.TextAlign = ContentAlignment.MiddleLeft;
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
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
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvHoras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvHoras.ColumnHeadersHeight = 58;
			dgvHoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvHoras.EnableHeadersVisualStyles = false;
			dgvHoras.GridColor = SystemColors.InactiveCaption;
			dgvHoras.ImeMode = ImeMode.NoControl;
			dgvHoras.Location = new Point(12, 89);
			dgvHoras.Name = "dgvHoras";
			dgvHoras.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvHoras.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvHoras.RowHeadersVisible = false;
			dgvHoras.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvHoras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvHoras.Size = new Size(956, 671);
			dgvHoras.TabIndex = 119;
			// 
			// btnCargar
			// 
			btnCargar.Image = (Image)resources.GetObject("btnCargar.Image");
			btnCargar.ImageAlign = ContentAlignment.MiddleRight;
			btnCargar.Location = new Point(700, 29);
			btnCargar.Name = "btnCargar";
			btnCargar.Padding = new Padding(10, 0, 10, 0);
			btnCargar.Size = new Size(126, 34);
			btnCargar.TabIndex = 120;
			btnCargar.Text = "Cargar Datos";
			btnCargar.TextAlign = ContentAlignment.MiddleLeft;
			btnCargar.UseVisualStyleBackColor = true;
			btnCargar.Click += btnCargar_Click;
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(12, 29);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(278, 23);
			dtpFecha.TabIndex = 121;
			// 
			// FrmUva
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1012, 772);
			Controls.Add(dtpFecha);
			Controls.Add(btnCargar);
			Controls.Add(dgvHoras);
			Controls.Add(btnExcel);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmUva";
			Text = "Reporte de Empleados Uva";
			Load += FrmUva_Load;
			((System.ComponentModel.ISupportInitialize)dgvHoras).EndInit();
			ResumeLayout(false);
		}

		#endregion
		public Button btnExcel;
		public DataGridView dgvHoras;
		public Button btnCargar;
		public DateTimePicker dtpFecha;
	}
}
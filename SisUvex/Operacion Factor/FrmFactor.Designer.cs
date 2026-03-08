namespace SisUvex.Operacion_Factor
{
	partial class FrmFactor
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
			dtpFecha = new DateTimePicker();
			dgvFactor = new DataGridView();
			lbencabezado = new Label();
			lblPeso = new Label();
			txbPesodeCaja = new TextBox();
			lblCajasenPiso = new Label();
			txbCajasenPiso = new TextBox();
			lblLibras = new Label();
			txbLibras = new TextBox();
			btncargar = new Button();
			((System.ComponentModel.ISupportInitialize)dgvFactor).BeginInit();
			SuspendLayout();
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(368, 107);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(260, 23);
			dtpFecha.TabIndex = 3;
			// 
			// dgvFactor
			// 
			dgvFactor.AllowUserToAddRows = false;
			dgvFactor.AllowUserToDeleteRows = false;
			dgvFactor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvFactor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvFactor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvFactor.BackgroundColor = SystemColors.ControlLightLight;
			dgvFactor.BorderStyle = BorderStyle.Fixed3D;
			dgvFactor.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvFactor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvFactor.ColumnHeadersHeight = 58;
			dgvFactor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvFactor.EnableHeadersVisualStyles = false;
			dgvFactor.ImeMode = ImeMode.NoControl;
			dgvFactor.Location = new Point(40, 334);
			dgvFactor.Name = "dgvFactor";
			dgvFactor.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvFactor.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvFactor.RowHeadersVisible = false;
			dgvFactor.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvFactor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvFactor.Size = new Size(961, 438);
			dgvFactor.TabIndex = 18;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(323, 25);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(351, 32);
			lbencabezado.TabIndex = 19;
			lbencabezado.Text = "Generar Reporte Para el Factor";
			// 
			// lblPeso
			// 
			lblPeso.AutoSize = true;
			lblPeso.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblPeso.Location = new Point(40, 182);
			lblPeso.Name = "lblPeso";
			lblPeso.Size = new Size(100, 21);
			lblPeso.TabIndex = 20;
			lblPeso.Text = "Peso de Caja:";
			// 
			// txbPesodeCaja
			// 
			txbPesodeCaja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbPesodeCaja.Location = new Point(146, 178);
			txbPesodeCaja.Multiline = true;
			txbPesodeCaja.Name = "txbPesodeCaja";
			txbPesodeCaja.ReadOnly = true;
			txbPesodeCaja.Size = new Size(64, 25);
			txbPesodeCaja.TabIndex = 21;
			// 
			// lblCajasenPiso
			// 
			lblCajasenPiso.AutoSize = true;
			lblCajasenPiso.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblCajasenPiso.Location = new Point(40, 239);
			lblCajasenPiso.Name = "lblCajasenPiso";
			lblCajasenPiso.Size = new Size(104, 21);
			lblCajasenPiso.TabIndex = 22;
			lblCajasenPiso.Text = "Cajas en Piso:";
			// 
			// txbCajasenPiso
			// 
			txbCajasenPiso.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbCajasenPiso.Location = new Point(150, 235);
			txbCajasenPiso.Multiline = true;
			txbCajasenPiso.Name = "txbCajasenPiso";
			txbCajasenPiso.Size = new Size(64, 25);
			txbCajasenPiso.TabIndex = 23;
			txbCajasenPiso.TextChanged += txbCajasenPiso_TextChanged;
			// 
			// lblLibras
			// 
			lblLibras.AutoSize = true;
			lblLibras.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLibras.Location = new Point(40, 288);
			lblLibras.Name = "lblLibras";
			lblLibras.Size = new Size(55, 21);
			lblLibras.TabIndex = 24;
			lblLibras.Text = "Libras:";
			// 
			// txbLibras
			// 
			txbLibras.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbLibras.Location = new Point(113, 284);
			txbLibras.Multiline = true;
			txbLibras.Name = "txbLibras";
			txbLibras.ReadOnly = true;
			txbLibras.Size = new Size(97, 25);
			txbLibras.TabIndex = 25;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btncargar.Location = new Point(848, 278);
			btncargar.Name = "btncargar";
			btncargar.Size = new Size(131, 38);
			btncargar.TabIndex = 26;
			btncargar.Text = "Cargar Datos";
			btncargar.UseVisualStyleBackColor = true;
			btncargar.Click += btncargar_Click;
			// 
			// FrmFactor
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1049, 784);
			Controls.Add(btncargar);
			Controls.Add(txbLibras);
			Controls.Add(lblLibras);
			Controls.Add(txbCajasenPiso);
			Controls.Add(lblCajasenPiso);
			Controls.Add(txbPesodeCaja);
			Controls.Add(lblPeso);
			Controls.Add(lbencabezado);
			Controls.Add(dgvFactor);
			Controls.Add(dtpFecha);
			Name = "FrmFactor";
			Text = "FrmFactor";
			Load += FrmFactor_Load;
			((System.ComponentModel.ISupportInitialize)dgvFactor).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public DateTimePicker dtpFecha;
		public DataGridView dgvFactor;
		private Label lbencabezado;
		private Label lblPeso;
		public TextBox txbPesodeCaja;
		private Label lblCajasenPiso;
		public TextBox txbCajasenPiso;
		private Label lblLibras;
		public TextBox txbLibras;
		private Button btncargar;
	}
}
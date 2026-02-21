namespace SisUvex.Nomina.Ingresos_Diversos
{
	partial class FrmAsistenciaEmpleado
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
			lblCodigo = new Label();
			txbIdEmpleado = new TextBox();
			txbNombreEmpleado = new TextBox();
			btnBuscar = new Button();
			btnBuscarAsistencias = new Button();
			dgvLista = new DataGridView();
			((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
			SuspendLayout();
			// 
			// lblCodigo
			// 
			lblCodigo.AutoSize = true;
			lblCodigo.Location = new Point(12, 17);
			lblCodigo.Name = "lblCodigo";
			lblCodigo.Size = new Size(121, 15);
			lblCodigo.TabIndex = 34;
			lblCodigo.Text = "Código de empleado:";
			// 
			// txbIdEmpleado
			// 
			txbIdEmpleado.Location = new Point(139, 8);
			txbIdEmpleado.MaxLength = 6;
			txbIdEmpleado.Name = "txbIdEmpleado";
			txbIdEmpleado.Size = new Size(60, 23);
			txbIdEmpleado.TabIndex = 35;
			txbIdEmpleado.KeyPress += txbIdEmpleado_KeyPress;
			// 
			// txbNombreEmpleado
			// 
			txbNombreEmpleado.Enabled = false;
			txbNombreEmpleado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			txbNombreEmpleado.Location = new Point(205, 8);
			txbNombreEmpleado.Name = "txbNombreEmpleado";
			txbNombreEmpleado.Size = new Size(301, 23);
			txbNombreEmpleado.TabIndex = 36;
			// 
			// btnBuscar
			// 
			btnBuscar.Enabled = false;
			btnBuscar.Location = new Point(512, 9);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(113, 23);
			btnBuscar.TabIndex = 37;
			btnBuscar.Text = "Buscar empleado";
			btnBuscar.UseVisualStyleBackColor = true;
			btnBuscar.Click += btnBuscar_Click;
			// 
			// btnBuscarAsistencias
			// 
			btnBuscarAsistencias.Location = new Point(12, 48);
			btnBuscarAsistencias.Name = "btnBuscarAsistencias";
			btnBuscarAsistencias.Size = new Size(117, 23);
			btnBuscarAsistencias.TabIndex = 38;
			btnBuscarAsistencias.Text = "Buscar asistencias";
			btnBuscarAsistencias.UseVisualStyleBackColor = true;
			// 
			// dgvLista
			// 
			dgvLista.AllowUserToAddRows = false;
			dgvLista.AllowUserToDeleteRows = false;
			dgvLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvLista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvLista.BackgroundColor = SystemColors.ControlLightLight;
			dgvLista.BorderStyle = BorderStyle.Fixed3D;
			dgvLista.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvLista.EnableHeadersVisualStyles = false;
			dgvLista.ImeMode = ImeMode.NoControl;
			dgvLista.Location = new Point(12, 77);
			dgvLista.Name = "dgvLista";
			dgvLista.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvLista.RowHeadersVisible = false;
			dgvLista.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvLista.Size = new Size(610, 368);
			dgvLista.TabIndex = 39;
			// 
			// FrmAsistenciaEmpleado
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(634, 450);
			Controls.Add(dgvLista);
			Controls.Add(btnBuscarAsistencias);
			Controls.Add(btnBuscar);
			Controls.Add(txbNombreEmpleado);
			Controls.Add(txbIdEmpleado);
			Controls.Add(lblCodigo);
			Name = "FrmAsistenciaEmpleado";
			Text = "AsistenciaEmpleado";
			Load += FrmAsistenciaEmpleado_Load;
			((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblCodigo;
		public TextBox txbIdEmpleado;
		public TextBox txbNombreEmpleado;
		public Button btnBuscar;
		public Button btnBuscarAsistencias;
		public DataGridView dgvLista;
	}
}
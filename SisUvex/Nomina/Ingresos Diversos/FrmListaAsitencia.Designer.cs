namespace SisUvex.Nomina.Ingresos_Diversos
{
	partial class FrmListaAsitencia
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
			dtpDia = new DateTimePicker();
			dgvLista = new DataGridView();
			btnBuscar = new Button();
			btnAdd = new Button();
			btnModify = new Button();
			btnEliminar = new Button();
			((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
			SuspendLayout();
			// 
			// dtpDia
			// 
			dtpDia.Location = new Point(12, 12);
			dtpDia.Name = "dtpDia";
			dtpDia.Size = new Size(254, 23);
			dtpDia.TabIndex = 1;
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
			dgvLista.Location = new Point(12, 52);
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
			dgvLista.Size = new Size(654, 419);
			dgvLista.TabIndex = 3;
			// 
			// btnBuscar
			// 
			btnBuscar.Location = new Point(285, 12);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(75, 23);
			btnBuscar.TabIndex = 4;
			btnBuscar.Text = "Buscar";
			btnBuscar.UseVisualStyleBackColor = true;
			btnBuscar.Click += btnBuscar_Click;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(366, 12);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(75, 23);
			btnAdd.TabIndex = 5;
			btnAdd.Text = "Añadir";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnModify
			// 
			btnModify.Location = new Point(447, 12);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(75, 23);
			btnModify.TabIndex = 6;
			btnModify.Text = "Modificar";
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnEliminar
			// 
			btnEliminar.Location = new Point(528, 12);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Size = new Size(75, 23);
			btnEliminar.TabIndex = 7;
			btnEliminar.Text = "Eliminar";
			btnEliminar.UseVisualStyleBackColor = true;
			btnEliminar.Click += btnEliminar_Click;
			// 
			// FrmListaAsitencia
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(678, 483);
			Controls.Add(btnEliminar);
			Controls.Add(btnModify);
			Controls.Add(btnAdd);
			Controls.Add(btnBuscar);
			Controls.Add(dgvLista);
			Controls.Add(dtpDia);
			Name = "FrmListaAsitencia";
			Text = "ListaAsitencia";
			WindowState = FormWindowState.Maximized;
			Load += FrmListaAsitencia_Load;
			((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
			ResumeLayout(false);
		}

		#endregion

		public DateTimePicker dtpDia;
		public DataGridView dgvLista;
		public Button btnBuscar;
		private Button btnAdd;
		private Button btnModify;
		private Button btnEliminar;
	}
}
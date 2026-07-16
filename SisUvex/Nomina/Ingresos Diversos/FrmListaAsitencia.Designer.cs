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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaAsitencia));
			dtpDia = new DateTimePicker();
			dgvLista = new DataGridView();
			btnBuscar = new Button();
			btnAdd = new Button();
			btnModify = new Button();
			btnEliminar = new Button();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			btnAñadirD = new Button();
			button2 = new Button();
			btnModificarDed = new Button();
			lblEmpleado = new Label();
			txbEmpleado = new TextBox();
			btnEmpleado = new Button();
			btnFrmSearchEmployeeId = new Button();
			cboActividad = new ComboBox();
			lblActividad = new Label();
			((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
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
			dgvLista.Location = new Point(12, 105);
			dgvLista.Name = "dgvLista";
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
			dgvLista.Size = new Size(1045, 581);
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
			btnAdd.Location = new Point(33, 22);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(75, 23);
			btnAdd.TabIndex = 5;
			btnAdd.Text = "Añadir";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnModify
			// 
			btnModify.Location = new Point(126, 22);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(75, 23);
			btnModify.TabIndex = 6;
			btnModify.Text = "Modificar";
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnEliminar
			// 
			btnEliminar.Location = new Point(217, 22);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Size = new Size(75, 23);
			btnEliminar.TabIndex = 7;
			btnEliminar.Text = "Eliminar";
			btnEliminar.UseVisualStyleBackColor = true;
			btnEliminar.Click += btnEliminar_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnAdd);
			groupBox1.Controls.Add(btnEliminar);
			groupBox1.Controls.Add(btnModify);
			groupBox1.Location = new Point(376, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(308, 53);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Ingresos";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnAñadirD);
			groupBox2.Controls.Add(button2);
			groupBox2.Controls.Add(btnModificarDed);
			groupBox2.Location = new Point(703, 12);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(308, 53);
			groupBox2.TabIndex = 9;
			groupBox2.TabStop = false;
			groupBox2.Text = "Deducciones";
			// 
			// btnAñadirD
			// 
			btnAñadirD.Location = new Point(33, 22);
			btnAñadirD.Name = "btnAñadirD";
			btnAñadirD.Size = new Size(75, 23);
			btnAñadirD.TabIndex = 5;
			btnAñadirD.Text = "Añadir";
			btnAñadirD.UseVisualStyleBackColor = true;
			btnAñadirD.Click += btnAñadirD_Click;
			// 
			// button2
			// 
			button2.Location = new Point(217, 22);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 7;
			button2.Text = "Eliminar";
			button2.UseVisualStyleBackColor = true;
			button2.Click += EliminarD_Click;
			// 
			// btnModificarDed
			// 
			btnModificarDed.Location = new Point(126, 22);
			btnModificarDed.Name = "btnModificarDed";
			btnModificarDed.Size = new Size(75, 23);
			btnModificarDed.TabIndex = 6;
			btnModificarDed.Text = "Modificar";
			btnModificarDed.UseVisualStyleBackColor = true;
			btnModificarDed.Click += btnModificarDed_Click;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Location = new Point(12, 50);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(84, 15);
			lblEmpleado.TabIndex = 11;
			lblEmpleado.Text = "Por empleado:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(12, 75);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(186, 23);
			txbEmpleado.TabIndex = 13;
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(204, 75);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(23, 23);
			btnEmpleado.TabIndex = 14;
			btnEmpleado.UseVisualStyleBackColor = true;
			btnEmpleado.Click += btnEmpleado_Click;
			// 
			// btnFrmSearchEmployeeId
			// 
			btnFrmSearchEmployeeId.BackgroundImageLayout = ImageLayout.Stretch;
			btnFrmSearchEmployeeId.Location = new Point(233, 75);
			btnFrmSearchEmployeeId.Name = "btnFrmSearchEmployeeId";
			btnFrmSearchEmployeeId.Size = new Size(26, 23);
			btnFrmSearchEmployeeId.TabIndex = 68;
			btnFrmSearchEmployeeId.Text = "...";
			btnFrmSearchEmployeeId.UseVisualStyleBackColor = true;
			btnFrmSearchEmployeeId.Click += btnFrmSearchEmployeeId_Click;
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(442, 75);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(234, 23);
			cboActividad.TabIndex = 108;
			cboActividad.SelectedIndexChanged += cboActividad_SelectedIndexChanged;
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			lblActividad.Location = new Point(376, 78);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(60, 15);
			lblActividad.TabIndex = 109;
			lblActividad.Text = "Actividad:";
			// 
			// FrmListaAsitencia
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1069, 698);
			Controls.Add(lblActividad);
			Controls.Add(cboActividad);
			Controls.Add(btnFrmSearchEmployeeId);
			Controls.Add(btnEmpleado);
			Controls.Add(txbEmpleado);
			Controls.Add(lblEmpleado);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(btnBuscar);
			Controls.Add(dgvLista);
			Controls.Add(dtpDia);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmListaAsitencia";
			Text = "Ajuste de Nomina ";
			WindowState = FormWindowState.Maximized;
			Load += FrmListaAsitencia_Load;
			((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public DateTimePicker dtpDia;
		public DataGridView dgvLista;
		public Button btnBuscar;
		private Button btnAdd;
		private Button btnModify;
		private Button btnEliminar;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Button btnAñadirD;
		private Button button2;
		private Button btnModificarDed;
		private Label lblEmpleado;
		public TextBox txbEmpleado;
		private Button btnEmpleado;
		private Button btnFrmSearchEmployeeId;
		public ComboBox cboActividad;
		private Label lblActividad;
	}
}
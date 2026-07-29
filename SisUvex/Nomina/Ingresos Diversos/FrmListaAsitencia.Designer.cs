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
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
			panel1 = new Panel();
			label2 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// dtpDia
			// 
			dtpDia.Location = new Point(13, 112);
			dtpDia.Margin = new Padding(3, 4, 3, 4);
			dtpDia.Name = "dtpDia";
			dtpDia.Size = new Size(290, 27);
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
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvLista.ColumnHeadersHeight = 29;
			dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvLista.EnableHeadersVisualStyles = false;
			dgvLista.ImeMode = ImeMode.NoControl;
			dgvLista.Location = new Point(14, 244);
			dgvLista.Margin = new Padding(3, 4, 3, 4);
			dgvLista.Name = "dgvLista";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvLista.RowHeadersVisible = false;
			dgvLista.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvLista.Size = new Size(1194, 671);
			dgvLista.TabIndex = 3;
			// 
			// btnBuscar
			// 
			btnBuscar.Location = new Point(320, 109);
			btnBuscar.Margin = new Padding(3, 4, 3, 4);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(86, 31);
			btnBuscar.TabIndex = 4;
			btnBuscar.Text = "Buscar";
			btnBuscar.UseVisualStyleBackColor = true;
			btnBuscar.Click += btnBuscar_Click;
			// 
			// btnAdd
			// 
			btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
			btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
			btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
			btnAdd.Location = new Point(6, 29);
			btnAdd.Margin = new Padding(3, 4, 3, 4);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(9, 0, 9, 0);
			btnAdd.Size = new Size(106, 31);
			btnAdd.TabIndex = 5;
			btnAdd.Text = "Añadir";
			btnAdd.TextAlign = ContentAlignment.MiddleRight;
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnModify
			// 
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(134, 29);
			btnModify.Margin = new Padding(3, 4, 3, 4);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(6, 0, 6, 0);
			btnModify.Size = new Size(116, 31);
			btnModify.TabIndex = 6;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnEliminar
			// 
			btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
			btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
			btnEliminar.Location = new Point(270, 29);
			btnEliminar.Margin = new Padding(3, 4, 3, 4);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Padding = new Padding(9, 0, 9, 0);
			btnEliminar.Size = new Size(116, 31);
			btnEliminar.TabIndex = 7;
			btnEliminar.Text = "Eliminar";
			btnEliminar.TextAlign = ContentAlignment.MiddleRight;
			btnEliminar.UseVisualStyleBackColor = true;
			btnEliminar.Click += btnEliminar_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnAdd);
			groupBox1.Controls.Add(btnEliminar);
			groupBox1.Controls.Add(btnModify);
			groupBox1.Location = new Point(14, 165);
			groupBox1.Margin = new Padding(3, 4, 3, 4);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 4, 3, 4);
			groupBox1.Size = new Size(392, 71);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Ingresos";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnAñadirD);
			groupBox2.Controls.Add(button2);
			groupBox2.Controls.Add(btnModificarDed);
			groupBox2.Location = new Point(458, 165);
			groupBox2.Margin = new Padding(3, 4, 3, 4);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(3, 4, 3, 4);
			groupBox2.Size = new Size(393, 71);
			groupBox2.TabIndex = 9;
			groupBox2.TabStop = false;
			groupBox2.Text = "Deducciones";
			// 
			// btnAñadirD
			// 
			btnAñadirD.Image = (Image)resources.GetObject("btnAñadirD.Image");
			btnAñadirD.ImageAlign = ContentAlignment.MiddleLeft;
			btnAñadirD.Location = new Point(6, 28);
			btnAñadirD.Margin = new Padding(3, 4, 3, 4);
			btnAñadirD.Name = "btnAñadirD";
			btnAñadirD.Padding = new Padding(9, 0, 9, 0);
			btnAñadirD.Size = new Size(106, 31);
			btnAñadirD.TabIndex = 5;
			btnAñadirD.Text = "Añadir";
			btnAñadirD.TextAlign = ContentAlignment.MiddleRight;
			btnAñadirD.UseVisualStyleBackColor = true;
			btnAñadirD.Click += btnAñadirD_Click;
			// 
			// button2
			// 
			button2.Image = (Image)resources.GetObject("button2.Image");
			button2.ImageAlign = ContentAlignment.MiddleLeft;
			button2.Location = new Point(271, 28);
			button2.Margin = new Padding(3, 4, 3, 4);
			button2.Name = "button2";
			button2.Padding = new Padding(9, 0, 9, 0);
			button2.Size = new Size(116, 31);
			button2.TabIndex = 7;
			button2.Text = "Eliminar";
			button2.TextAlign = ContentAlignment.MiddleRight;
			button2.UseVisualStyleBackColor = true;
			button2.Click += EliminarD_Click;
			// 
			// btnModificarDed
			// 
			btnModificarDed.Image = (Image)resources.GetObject("btnModificarDed.Image");
			btnModificarDed.ImageAlign = ContentAlignment.MiddleLeft;
			btnModificarDed.Location = new Point(135, 28);
			btnModificarDed.Margin = new Padding(3, 4, 3, 4);
			btnModificarDed.Name = "btnModificarDed";
			btnModificarDed.Padding = new Padding(6, 0, 6, 0);
			btnModificarDed.Size = new Size(116, 31);
			btnModificarDed.TabIndex = 6;
			btnModificarDed.Text = "Modificar";
			btnModificarDed.TextAlign = ContentAlignment.MiddleRight;
			btnModificarDed.UseVisualStyleBackColor = true;
			btnModificarDed.Click += btnModificarDed_Click;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEmpleado.Location = new Point(458, 117);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(81, 20);
			lblEmpleado.TabIndex = 11;
			lblEmpleado.Text = "Empleado:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(545, 109);
			txbEmpleado.Margin = new Padding(3, 4, 3, 4);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(212, 27);
			txbEmpleado.TabIndex = 13;
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(764, 109);
			btnEmpleado.Margin = new Padding(3, 4, 3, 4);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(26, 31);
			btnEmpleado.TabIndex = 14;
			btnEmpleado.UseVisualStyleBackColor = true;
			btnEmpleado.Click += btnEmpleado_Click;
			// 
			// btnFrmSearchEmployeeId
			// 
			btnFrmSearchEmployeeId.BackgroundImageLayout = ImageLayout.Stretch;
			btnFrmSearchEmployeeId.Location = new Point(797, 109);
			btnFrmSearchEmployeeId.Margin = new Padding(3, 4, 3, 4);
			btnFrmSearchEmployeeId.Name = "btnFrmSearchEmployeeId";
			btnFrmSearchEmployeeId.Size = new Size(30, 31);
			btnFrmSearchEmployeeId.TabIndex = 68;
			btnFrmSearchEmployeeId.Text = "...";
			btnFrmSearchEmployeeId.UseVisualStyleBackColor = true;
			btnFrmSearchEmployeeId.Click += btnFrmSearchEmployeeId_Click;
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(941, 111);
			cboActividad.Margin = new Padding(3, 4, 3, 4);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(267, 28);
			cboActividad.TabIndex = 108;
			cboActividad.SelectedIndexChanged += cboActividad_SelectedIndexChanged;
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			lblActividad.Location = new Point(858, 116);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(77, 20);
			lblActividad.TabIndex = 109;
			lblActividad.Text = "Actividad:";
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.BackColor = SystemColors.GradientInactiveCaption;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(14, 12);
			panel1.Name = "panel1";
			panel1.Size = new Size(1194, 80);
			panel1.TabIndex = 110;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(13, 47);
			label2.Name = "label2";
			label2.Size = new Size(445, 20);
			label2.TabIndex = 1;
			label2.Text = "Administra los ingresos y deducciones aplicados a los empleados.";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(13, 11);
			label1.Name = "label1";
			label1.Size = new Size(198, 28);
			label1.TabIndex = 0;
			label1.Text = "AJUSTE DE NÓMINA";
			// 
			// FrmListaAsitencia
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1222, 931);
			Controls.Add(panel1);
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
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmListaAsitencia";
			Text = "Ajuste de Nomina ";
			WindowState = FormWindowState.Maximized;
			Load += FrmListaAsitencia_Load;
			((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
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
		private Panel panel1;
		private Label label2;
		private Label label1;
	}
}
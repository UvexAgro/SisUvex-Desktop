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
			panel1 = new Panel();
			label2 = new Label();
			label1 = new Label();
			label3 = new Label();
			cboCuadrillaCampo = new ComboBox();
			label4 = new Label();
			cboCuadrillaEmpaque = new ComboBox();
			chkSeleccionar = new CheckBox();
			((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// dtpDia
			// 
			dtpDia.Location = new Point(12, 112);
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
			dgvLista.ColumnHeadersHeight = 29;
			dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvLista.EnableHeadersVisualStyles = false;
			dgvLista.ImeMode = ImeMode.NoControl;
			dgvLista.Location = new Point(12, 256);
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
			dgvLista.Size = new Size(1230, 529);
			dgvLista.TabIndex = 3;
			// 
			// btnBuscar
			// 
			btnBuscar.Location = new Point(281, 110);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(75, 23);
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
			btnAdd.Location = new Point(5, 22);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(8, 0, 8, 0);
			btnAdd.Size = new Size(93, 31);
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
			btnModify.Location = new Point(117, 22);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(7, 0, 7, 0);
			btnModify.Size = new Size(102, 31);
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
			btnEliminar.Location = new Point(236, 22);
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Padding = new Padding(8, 0, 8, 0);
			btnEliminar.Size = new Size(102, 31);
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
			groupBox1.Location = new Point(428, 88);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(343, 65);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Ingresos";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnAñadirD);
			groupBox2.Controls.Add(button2);
			groupBox2.Controls.Add(btnModificarDed);
			groupBox2.Location = new Point(818, 88);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(344, 65);
			groupBox2.TabIndex = 9;
			groupBox2.TabStop = false;
			groupBox2.Text = "Deducciones";
			// 
			// btnAñadirD
			// 
			btnAñadirD.Image = (Image)resources.GetObject("btnAñadirD.Image");
			btnAñadirD.ImageAlign = ContentAlignment.MiddleLeft;
			btnAñadirD.Location = new Point(5, 21);
			btnAñadirD.Name = "btnAñadirD";
			btnAñadirD.Padding = new Padding(8, 0, 8, 0);
			btnAñadirD.Size = new Size(93, 32);
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
			button2.Location = new Point(237, 21);
			button2.Name = "button2";
			button2.Padding = new Padding(8, 0, 8, 0);
			button2.Size = new Size(102, 32);
			button2.TabIndex = 7;
			button2.Text = "Eliminar";
			button2.TextAlign = ContentAlignment.MiddleRight;
			button2.UseVisualStyleBackColor = true;
			// 
			// btnModificarDed
			// 
			btnModificarDed.Image = (Image)resources.GetObject("btnModificarDed.Image");
			btnModificarDed.ImageAlign = ContentAlignment.MiddleLeft;
			btnModificarDed.Location = new Point(118, 21);
			btnModificarDed.Name = "btnModificarDed";
			btnModificarDed.Padding = new Padding(7, 0, 7, 0);
			btnModificarDed.Size = new Size(102, 32);
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
			lblEmpleado.Location = new Point(616, 185);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(51, 15);
			lblEmpleado.TabIndex = 11;
			lblEmpleado.Text = "Codigo :";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(673, 180);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(93, 23);
			txbEmpleado.TabIndex = 13;
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(772, 180);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(23, 23);
			btnEmpleado.TabIndex = 14;
			btnEmpleado.UseVisualStyleBackColor = true;
			// 
			// btnFrmSearchEmployeeId
			// 
			btnFrmSearchEmployeeId.BackgroundImageLayout = ImageLayout.Stretch;
			btnFrmSearchEmployeeId.Location = new Point(799, 181);
			btnFrmSearchEmployeeId.Name = "btnFrmSearchEmployeeId";
			btnFrmSearchEmployeeId.Size = new Size(23, 22);
			btnFrmSearchEmployeeId.TabIndex = 68;
			btnFrmSearchEmployeeId.Text = "...";
			btnFrmSearchEmployeeId.UseVisualStyleBackColor = true;
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(922, 177);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(234, 23);
			cboActividad.TabIndex = 108;
			cboActividad.SelectedIndexChanged += cboActividad_SelectedIndexChanged;
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			lblActividad.Location = new Point(856, 183);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(60, 15);
			lblActividad.TabIndex = 109;
			lblActividad.Text = "Actividad:";
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.BackColor = SystemColors.GradientInactiveCaption;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(12, 9);
			panel1.Margin = new Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(1230, 74);
			panel1.TabIndex = 110;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(11, 35);
			label2.Name = "label2";
			label2.Size = new Size(353, 15);
			label2.TabIndex = 1;
			label2.Text = "Administra los ingresos y deducciones aplicados a los empleados.";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(11, 8);
			label1.Name = "label1";
			label1.Size = new Size(159, 21);
			label1.TabIndex = 0;
			label1.Text = "AJUSTE DE NÓMINA";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			label3.Location = new Point(10, 164);
			label3.Name = "label3";
			label3.Size = new Size(100, 15);
			label3.TabIndex = 112;
			label3.Text = "Cuadrilla Campo :";
			// 
			// cboCuadrillaCampo
			// 
			cboCuadrillaCampo.FormattingEnabled = true;
			cboCuadrillaCampo.Location = new Point(9, 182);
			cboCuadrillaCampo.Name = "cboCuadrillaCampo";
			cboCuadrillaCampo.Size = new Size(234, 23);
			cboCuadrillaCampo.TabIndex = 111;
			cboCuadrillaCampo.SelectedIndexChanged += cboCuadrillaCampo_SelectedIndexChanged;
			cboCuadrillaCampo.Enter += cboCuadrillaCampo_Enter;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			label4.Location = new Point(310, 164);
			label4.Name = "label4";
			label4.Size = new Size(112, 15);
			label4.TabIndex = 114;
			label4.Text = "Cuadrilla Empaque :";
			// 
			// cboCuadrillaEmpaque
			// 
			cboCuadrillaEmpaque.FormattingEnabled = true;
			cboCuadrillaEmpaque.Location = new Point(309, 182);
			cboCuadrillaEmpaque.Name = "cboCuadrillaEmpaque";
			cboCuadrillaEmpaque.Size = new Size(234, 23);
			cboCuadrillaEmpaque.TabIndex = 113;
			cboCuadrillaEmpaque.SelectedIndexChanged += cboCuadrillaEmpaque_SelectedIndexChanged;
			cboCuadrillaEmpaque.Enter += cboCuadrillaEmpaque_Enter;
			// 
			// chkSeleccionar
			// 
			chkSeleccionar.AutoSize = true;
			chkSeleccionar.Location = new Point(12, 231);
			chkSeleccionar.Name = "chkSeleccionar";
			chkSeleccionar.Size = new Size(114, 19);
			chkSeleccionar.TabIndex = 115;
			chkSeleccionar.Text = "Seleccionar todo";
			chkSeleccionar.UseVisualStyleBackColor = true;
			chkSeleccionar.CheckedChanged += chkSeleccionar_CheckedChanged;
			// 
			// FrmListaAsitencia
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1254, 797);
			Controls.Add(chkSeleccionar);
			Controls.Add(label4);
			Controls.Add(cboCuadrillaEmpaque);
			Controls.Add(label3);
			Controls.Add(cboCuadrillaCampo);
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
		private Label label3;
		public ComboBox cboCuadrillaCampo;
		private Label label4;
		public ComboBox cboCuadrillaEmpaque;
		private CheckBox chkSeleccionar;
	}
}
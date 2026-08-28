namespace SisUvex.Nomina.NomCampoAgregarListados
{
	partial class FrmListados
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListados));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			panel1 = new Panel();
			btnMostrar = new Button();
			label3 = new Label();
			dgvCuadrilla = new DataGridView();
			pictureBox2 = new PictureBox();
			panel2 = new Panel();
			btnModificar = new Button();
			pnlSinEmpleados = new Panel();
			label8 = new Label();
			label7 = new Label();
			panel5 = new Panel();
			label6 = new Label();
			lblNumeroTotal = new Label();
			lblTotalEmpleados = new Label();
			panel4 = new Panel();
			btnImprimir = new Button();
			btnQuitar = new Button();
			btnAgregar = new Button();
			lblCuadrilla = new Label();
			label4 = new Label();
			dgvListado = new DataGridView();
			dtpFecha = new DateTimePicker();
			label1 = new Label();
			label2 = new Label();
			pictureBox1 = new PictureBox();
			panel3 = new Panel();
			button1 = new Button();
			btnActulizar = new Button();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvCuadrilla).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panel2.SuspendLayout();
			pnlSinEmpleados.SuspendLayout();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			panel1.BackColor = SystemColors.ControlLightLight;
			panel1.Controls.Add(btnMostrar);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(dgvCuadrilla);
			panel1.Location = new Point(12, 110);
			panel1.Name = "panel1";
			panel1.Size = new Size(306, 701);
			panel1.TabIndex = 0;
			// 
			// btnMostrar
			// 
			btnMostrar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnMostrar.Image = (Image)resources.GetObject("btnMostrar.Image");
			btnMostrar.ImageAlign = ContentAlignment.MiddleLeft;
			btnMostrar.Location = new Point(135, 58);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Padding = new Padding(20, 0, 30, 0);
			btnMostrar.Size = new Size(166, 39);
			btnMostrar.TabIndex = 16;
			btnMostrar.Text = "Mostrar";
			btnMostrar.TextAlign = ContentAlignment.MiddleRight;
			btnMostrar.UseVisualStyleBackColor = true;
			btnMostrar.Click += btnMostrar_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(3, 12);
			label3.Name = "label3";
			label3.Size = new Size(109, 30);
			label3.TabIndex = 15;
			label3.Text = "Cuadrillas";
			// 
			// dgvCuadrilla
			// 
			dgvCuadrilla.AllowUserToAddRows = false;
			dgvCuadrilla.AllowUserToDeleteRows = false;
			dgvCuadrilla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dgvCuadrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvCuadrilla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvCuadrilla.BackgroundColor = SystemColors.Control;
			dgvCuadrilla.BorderStyle = BorderStyle.Fixed3D;
			dgvCuadrilla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvCuadrilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvCuadrilla.ColumnHeadersHeight = 29;
			dgvCuadrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCuadrilla.EnableHeadersVisualStyles = false;
			dgvCuadrilla.ImeMode = ImeMode.NoControl;
			dgvCuadrilla.Location = new Point(3, 103);
			dgvCuadrilla.Name = "dgvCuadrilla";
			dgvCuadrilla.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvCuadrilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvCuadrilla.RowHeadersVisible = false;
			dgvCuadrilla.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvCuadrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCuadrilla.Size = new Size(298, 595);
			dgvCuadrilla.TabIndex = 14;
			// 
			// pictureBox2
			// 
			pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
			pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox2.Location = new Point(691, 126);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(120, 92);
			pictureBox2.TabIndex = 17;
			pictureBox2.TabStop = false;
			// 
			// panel2
			// 
			panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel2.BackColor = SystemColors.ControlLightLight;
			panel2.Controls.Add(btnModificar);
			panel2.Controls.Add(pnlSinEmpleados);
			panel2.Controls.Add(panel5);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(btnImprimir);
			panel2.Controls.Add(btnQuitar);
			panel2.Controls.Add(btnAgregar);
			panel2.Controls.Add(lblCuadrilla);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(dgvListado);
			panel2.Location = new Point(324, 110);
			panel2.Name = "panel2";
			panel2.Size = new Size(1136, 701);
			panel2.TabIndex = 1;
			// 
			// btnModificar
			// 
			btnModificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
			btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
			btnModificar.Location = new Point(177, 125);
			btnModificar.Name = "btnModificar";
			btnModificar.Padding = new Padding(16, 0, 40, 0);
			btnModificar.Size = new Size(166, 44);
			btnModificar.TabIndex = 42;
			btnModificar.Text = "Modificar";
			btnModificar.TextAlign = ContentAlignment.MiddleRight;
			btnModificar.UseVisualStyleBackColor = true;
			btnModificar.Click += btnModificar_Click;
			// 
			// pnlSinEmpleados
			// 
			pnlSinEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pnlSinEmpleados.Controls.Add(pictureBox2);
			pnlSinEmpleados.Controls.Add(label8);
			pnlSinEmpleados.Controls.Add(label7);
			pnlSinEmpleados.Location = new Point(5, 239);
			pnlSinEmpleados.Name = "pnlSinEmpleados";
			pnlSinEmpleados.Size = new Size(1128, 431);
			pnlSinEmpleados.TabIndex = 41;
			// 
			// label8
			// 
			label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label8.AutoSize = true;
			label8.BackColor = Color.Transparent;
			label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label8.ForeColor = Color.DimGray;
			label8.Location = new Point(632, 281);
			label8.Name = "label8";
			label8.Size = new Size(239, 17);
			label8.TabIndex = 2;
			label8.Text = "Selecciona una cuadrilla para comenzar";
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(616, 239);
			label7.Name = "label7";
			label7.Size = new Size(270, 25);
			label7.TabIndex = 1;
			label7.Text = "No hay empleados asignados";
			// 
			// panel5
			// 
			panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			panel5.BackColor = Color.FromArgb(245, 247, 250);
			panel5.Controls.Add(label6);
			panel5.Controls.Add(lblNumeroTotal);
			panel5.Controls.Add(lblTotalEmpleados);
			panel5.Location = new Point(892, 10);
			panel5.Name = "panel5";
			panel5.Size = new Size(200, 84);
			panel5.TabIndex = 40;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(68, 62);
			label6.Name = "label6";
			label6.Size = new Size(65, 15);
			label6.TabIndex = 22;
			label6.Text = "empleados";
			// 
			// lblNumeroTotal
			// 
			lblNumeroTotal.AutoSize = true;
			lblNumeroTotal.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblNumeroTotal.Location = new Point(84, 25);
			lblNumeroTotal.Name = "lblNumeroTotal";
			lblNumeroTotal.Size = new Size(32, 37);
			lblNumeroTotal.TabIndex = 21;
			lblNumeroTotal.Text = "0";
			// 
			// lblTotalEmpleados
			// 
			lblTotalEmpleados.AutoSize = true;
			lblTotalEmpleados.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTotalEmpleados.Location = new Point(29, 8);
			lblTotalEmpleados.Name = "lblTotalEmpleados";
			lblTotalEmpleados.Size = new Size(143, 17);
			lblTotalEmpleados.TabIndex = 20;
			lblTotalEmpleados.Text = "TOTAL DE EMPLEADOS";
			// 
			// panel4
			// 
			panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel4.BackColor = Color.Silver;
			panel4.Location = new Point(21, 110);
			panel4.Name = "panel4";
			panel4.Size = new Size(1096, 1);
			panel4.TabIndex = 39;
			// 
			// btnImprimir
			// 
			btnImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnImprimir.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnImprimir.Image = (Image)resources.GetObject("btnImprimir.Image");
			btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
			btnImprimir.Location = new Point(926, 125);
			btnImprimir.Name = "btnImprimir";
			btnImprimir.Padding = new Padding(16, 0, 25, 0);
			btnImprimir.Size = new Size(166, 44);
			btnImprimir.TabIndex = 21;
			btnImprimir.Text = "Imprimir Listas";
			btnImprimir.TextAlign = ContentAlignment.MiddleRight;
			btnImprimir.UseVisualStyleBackColor = true;
			btnImprimir.Click += btnImprimir_Click;
			// 
			// btnQuitar
			// 
			btnQuitar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnQuitar.Image = (Image)resources.GetObject("btnQuitar.Image");
			btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
			btnQuitar.Location = new Point(349, 125);
			btnQuitar.Name = "btnQuitar";
			btnQuitar.Padding = new Padding(15, 0, 15, 0);
			btnQuitar.Size = new Size(166, 44);
			btnQuitar.TabIndex = 18;
			btnQuitar.Text = "Quitar Empleado";
			btnQuitar.TextAlign = ContentAlignment.MiddleRight;
			btnQuitar.UseVisualStyleBackColor = true;
			btnQuitar.Click += btnQuitar_Click;
			// 
			// btnAgregar
			// 
			btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnAgregar.Image = (Image)resources.GetObject("btnAgregar.Image");
			btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
			btnAgregar.Location = new Point(5, 125);
			btnAgregar.Name = "btnAgregar";
			btnAgregar.Padding = new Padding(15, 0, 10, 0);
			btnAgregar.Size = new Size(166, 44);
			btnAgregar.TabIndex = 19;
			btnAgregar.Text = "Agregar Empleado";
			btnAgregar.TextAlign = ContentAlignment.MiddleRight;
			btnAgregar.UseVisualStyleBackColor = true;
			btnAgregar.Click += btnAgregar_Click;
			// 
			// lblCuadrilla
			// 
			lblCuadrilla.AutoSize = true;
			lblCuadrilla.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCuadrilla.ForeColor = SystemColors.HotTrack;
			lblCuadrilla.Location = new Point(192, 36);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(0, 25);
			lblCuadrilla.TabIndex = 15;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(35, 39);
			label4.Name = "label4";
			label4.Size = new Size(150, 25);
			label4.TabIndex = 14;
			label4.Text = "PERSONAL DE  :";
			// 
			// dgvListado
			// 
			dgvListado.AllowUserToAddRows = false;
			dgvListado.AllowUserToDeleteRows = false;
			dgvListado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvListado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvListado.BackgroundColor = SystemColors.Control;
			dgvListado.BorderStyle = BorderStyle.Fixed3D;
			dgvListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvListado.ColumnHeadersHeight = 29;
			dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvListado.EnableHeadersVisualStyles = false;
			dgvListado.ImeMode = ImeMode.NoControl;
			dgvListado.Location = new Point(3, 175);
			dgvListado.Name = "dgvListado";
			dgvListado.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvListado.RowHeadersVisible = false;
			dgvListado.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListado.Size = new Size(1130, 515);
			dgvListado.TabIndex = 13;
			// 
			// dtpFecha
			// 
			dtpFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			dtpFecha.Location = new Point(818, 32);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(246, 23);
			dtpFecha.TabIndex = 37;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(75, 8);
			label1.Name = "label1";
			label1.Size = new Size(471, 37);
			label1.TabIndex = 0;
			label1.Text = "Listado de Empleados por Cuadrilla";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.DimGray;
			label2.Location = new Point(75, 48);
			label2.Name = "label2";
			label2.Size = new Size(356, 17);
			label2.TabIndex = 1;
			label2.Text = "Consulta y administra el personal asignado a cada cuadrilla";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(5, 9);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(64, 66);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// panel3
			// 
			panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel3.BackColor = Color.FromArgb(245, 247, 250);
			panel3.Controls.Add(button1);
			panel3.Controls.Add(btnActulizar);
			panel3.Controls.Add(pictureBox1);
			panel3.Controls.Add(label2);
			panel3.Controls.Add(label1);
			panel3.Controls.Add(dtpFecha);
			panel3.Location = new Point(12, 3);
			panel3.Name = "panel3";
			panel3.Size = new Size(1448, 89);
			panel3.TabIndex = 2;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button1.Image = (Image)resources.GetObject("button1.Image");
			button1.ImageAlign = ContentAlignment.MiddleLeft;
			button1.Location = new Point(1266, 21);
			button1.Name = "button1";
			button1.Padding = new Padding(30, 0, 30, 0);
			button1.Size = new Size(166, 44);
			button1.TabIndex = 44;
			button1.Text = "Asistencia";
			button1.TextAlign = ContentAlignment.MiddleRight;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// btnActulizar
			// 
			btnActulizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnActulizar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnActulizar.Image = (Image)resources.GetObject("btnActulizar.Image");
			btnActulizar.ImageAlign = ContentAlignment.MiddleLeft;
			btnActulizar.Location = new Point(1094, 21);
			btnActulizar.Name = "btnActulizar";
			btnActulizar.Padding = new Padding(30, 0, 30, 0);
			btnActulizar.Size = new Size(166, 44);
			btnActulizar.TabIndex = 43;
			btnActulizar.Text = "Actualizar";
			btnActulizar.TextAlign = ContentAlignment.MiddleRight;
			btnActulizar.UseVisualStyleBackColor = true;
			btnActulizar.Click += btnActulizar_Click;
			// 
			// FrmListados
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1472, 812);
			Controls.Add(panel3);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmListados";
			Text = "Listados de Empleados por Cuadrilla ";
			Load += FrmListados_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvCuadrilla).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			pnlSinEmpleados.ResumeLayout(false);
			pnlSinEmpleados.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Panel panel2;
		public DataGridView dgvListado;
		private Label label3;
		public DataGridView dgvCuadrilla;
		private Label label4;
		private Button btnMostrar;
		private Button btnQuitar;
		private Button btnAgregar;
		private Label label1;
		private Label label2;
		private PictureBox pictureBox1;
		private Panel panel3;
		public DateTimePicker dtpFecha;
		public Label lblTotalEmpleados;
		public Button btnImprimir;
		public Label lblCuadrilla;
		private PictureBox pictureBox2;
		private Panel panel4;
		private Panel panel5;
		private Label label6;
		public Label lblNumeroTotal;
		private Panel plInformacion;
		private Label label8;
		private Label label7;
		public Panel pnlSinEmpleados;
		public Button btnModificar;
		public Button btnActulizar;
		public Button button1;
	}
}
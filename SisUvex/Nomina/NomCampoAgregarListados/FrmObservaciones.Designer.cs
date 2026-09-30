namespace SisUvex.Nomina.NomCampoAgregarListados
{
	partial class FrmObservaciones
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObservaciones));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			dtpFinal = new DateTimePicker();
			dtpInicio = new DateTimePicker();
			txbSemana = new TextBox();
			label6 = new Label();
			label5 = new Label();
			label1 = new Label();
			panel1 = new Panel();
			pictureBox1 = new PictureBox();
			label4 = new Label();
			label2 = new Label();
			dgvEstado = new DataGridView();
			groupBox1 = new GroupBox();
			btnCancelar = new Button();
			btnAgregar = new Button();
			btnGuardar = new Button();
			btnModificar = new Button();
			txbObservaciones = new TextBox();
			label10 = new Label();
			label9 = new Label();
			cboEstado = new ComboBox();
			label8 = new Label();
			cboDia = new ComboBox();
			label7 = new Label();
			cboCuadrilla2 = new ComboBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			panel2 = new Panel();
			label12 = new Label();
			tableLayoutPanel2 = new TableLayoutPanel();
			panel6 = new Panel();
			pictureBox3 = new PictureBox();
			label13 = new Label();
			panel5 = new Panel();
			pictureBox4 = new PictureBox();
			label3 = new Label();
			panel4 = new Panel();
			pictureBox2 = new PictureBox();
			label14 = new Label();
			label11 = new Label();
			label15 = new Label();
			label16 = new Label();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvEstado).BeginInit();
			groupBox1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			panel2.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// dtpFinal
			// 
			dtpFinal.Format = DateTimePickerFormat.Custom;
			dtpFinal.Location = new Point(436, 110);
			dtpFinal.Name = "dtpFinal";
			dtpFinal.Size = new Size(84, 23);
			dtpFinal.TabIndex = 24;
			// 
			// dtpInicio
			// 
			dtpInicio.CustomFormat = "";
			dtpInicio.Format = DateTimePickerFormat.Custom;
			dtpInicio.Location = new Point(258, 110);
			dtpInicio.Name = "dtpInicio";
			dtpInicio.Size = new Size(84, 23);
			dtpInicio.TabIndex = 23;
			// 
			// txbSemana
			// 
			txbSemana.Location = new Point(68, 110);
			txbSemana.Name = "txbSemana";
			txbSemana.Size = new Size(65, 23);
			txbSemana.TabIndex = 22;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(401, 113);
			label6.Name = "label6";
			label6.Size = new Size(29, 17);
			label6.TabIndex = 21;
			label6.Text = "Fin:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(209, 113);
			label5.Name = "label5";
			label5.Size = new Size(43, 17);
			label5.TabIndex = 20;
			label5.Text = "Inicio:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(8, 113);
			label1.Name = "label1";
			label1.Size = new Size(59, 17);
			label1.TabIndex = 19;
			label1.Text = "Semana:";
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.BackColor = Color.FromArgb(236, 243, 249);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label2);
			panel1.Location = new Point(5, 7);
			panel1.Name = "panel1";
			panel1.Size = new Size(1255, 75);
			panel1.TabIndex = 25;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(7, 7);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(72, 58);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.Transparent;
			label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.DimGray;
			label4.Location = new Point(85, 44);
			label4.Name = "label4";
			label4.Size = new Size(301, 21);
			label4.TabIndex = 1;
			label4.Text = "Control de cuadrillas terminadas por día";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(85, 7);
			label2.Name = "label2";
			label2.Size = new Size(276, 37);
			label2.TabIndex = 0;
			label2.Text = "Estado de Cuadrillas";
			// 
			// dgvEstado
			// 
			dgvEstado.AllowUserToAddRows = false;
			dgvEstado.AllowUserToDeleteRows = false;
			dgvEstado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvEstado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvEstado.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvEstado.BackgroundColor = SystemColors.ControlLightLight;
			dgvEstado.BorderStyle = BorderStyle.Fixed3D;
			dgvEstado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvEstado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvEstado.ColumnHeadersHeight = 29;
			dgvEstado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvEstado.EnableHeadersVisualStyles = false;
			dgvEstado.ImeMode = ImeMode.NoControl;
			dgvEstado.Location = new Point(5, 138);
			dgvEstado.Name = "dgvEstado";
			dgvEstado.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvEstado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvEstado.RowHeadersVisible = false;
			dgvEstado.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvEstado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvEstado.Size = new Size(961, 646);
			dgvEstado.TabIndex = 26;
			dgvEstado.CellClick += dgvEstado_CellClick;
			dgvEstado.Resize += dgvEstado_Resize;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = Color.FromArgb(236, 243, 249);
			groupBox1.Controls.Add(btnCancelar);
			groupBox1.Controls.Add(btnAgregar);
			groupBox1.Controls.Add(btnGuardar);
			groupBox1.Controls.Add(btnModificar);
			groupBox1.Controls.Add(txbObservaciones);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(cboEstado);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(cboDia);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(cboCuadrilla2);
			groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(972, 131);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(288, 654);
			groupBox1.TabIndex = 27;
			groupBox1.TabStop = false;
			groupBox1.Text = "Detalle del dia";
			// 
			// btnCancelar
			// 
			btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
			btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancelar.Location = new Point(9, 552);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Padding = new Padding(85, 0, 80, 0);
			btnCancelar.Size = new Size(272, 39);
			btnCancelar.TabIndex = 46;
			btnCancelar.Text = "Cancelar";
			btnCancelar.TextAlign = ContentAlignment.MiddleRight;
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// btnAgregar
			// 
			btnAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnAgregar.Image = (Image)resources.GetObject("btnAgregar.Image");
			btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
			btnAgregar.Location = new Point(9, 453);
			btnAgregar.Name = "btnAgregar";
			btnAgregar.Padding = new Padding(85, 0, 85, 0);
			btnAgregar.Size = new Size(273, 39);
			btnAgregar.TabIndex = 45;
			btnAgregar.Text = "Agregar";
			btnAgregar.TextAlign = ContentAlignment.MiddleRight;
			btnAgregar.UseVisualStyleBackColor = true;
			btnAgregar.Click += btnAgregar_Click;
			// 
			// btnGuardar
			// 
			btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnGuardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
			btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
			btnGuardar.Location = new Point(9, 603);
			btnGuardar.Name = "btnGuardar";
			btnGuardar.Padding = new Padding(85, 0, 80, 0);
			btnGuardar.Size = new Size(272, 39);
			btnGuardar.TabIndex = 44;
			btnGuardar.Text = "Guardar";
			btnGuardar.TextAlign = ContentAlignment.MiddleRight;
			btnGuardar.UseVisualStyleBackColor = true;
			btnGuardar.Click += btnGuardar_Click;
			// 
			// btnModificar
			// 
			btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnModificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
			btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
			btnModificar.Location = new Point(9, 500);
			btnModificar.Name = "btnModificar";
			btnModificar.Padding = new Padding(85, 0, 75, 0);
			btnModificar.Size = new Size(272, 39);
			btnModificar.TabIndex = 28;
			btnModificar.Text = "Modificar";
			btnModificar.TextAlign = ContentAlignment.MiddleRight;
			btnModificar.UseVisualStyleBackColor = true;
			btnModificar.Click += btnModificar_Click;
			// 
			// txbObservaciones
			// 
			txbObservaciones.Location = new Point(6, 300);
			txbObservaciones.Multiline = true;
			txbObservaciones.Name = "txbObservaciones";
			txbObservaciones.ScrollBars = ScrollBars.Vertical;
			txbObservaciones.Size = new Size(276, 136);
			txbObservaciones.TabIndex = 43;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.Location = new Point(6, 280);
			label10.Name = "label10";
			label10.Size = new Size(100, 17);
			label10.TabIndex = 42;
			label10.Text = "Observaciones:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.Location = new Point(14, 193);
			label9.Name = "label9";
			label9.Size = new Size(56, 17);
			label9.TabIndex = 41;
			label9.Text = "Estado :";
			// 
			// cboEstado
			// 
			cboEstado.FormattingEnabled = true;
			cboEstado.Location = new Point(14, 221);
			cboEstado.Name = "cboEstado";
			cboEstado.Size = new Size(260, 29);
			cboEstado.TabIndex = 40;
			cboEstado.DrawItem += cboEstado_DrawItem;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(9, 118);
			label8.Name = "label8";
			label8.Size = new Size(34, 17);
			label8.TabIndex = 39;
			label8.Text = "Dia :";
			// 
			// cboDia
			// 
			cboDia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			cboDia.FormattingEnabled = true;
			cboDia.Location = new Point(9, 138);
			cboDia.Name = "cboDia";
			cboDia.Size = new Size(89, 29);
			cboDia.TabIndex = 38;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(9, 40);
			label7.Name = "label7";
			label7.Size = new Size(67, 17);
			label7.TabIndex = 28;
			label7.Text = "Cuadrilla :";
			// 
			// cboCuadrilla2
			// 
			cboCuadrilla2.FormattingEnabled = true;
			cboCuadrilla2.Location = new Point(9, 68);
			cboCuadrilla2.Name = "cboCuadrilla2";
			cboCuadrilla2.Size = new Size(260, 29);
			cboCuadrilla2.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.61882F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.38118F));
			tableLayoutPanel1.Controls.Add(panel2, 0, 0);
			tableLayoutPanel1.Location = new Point(5, 791);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(1255, 151);
			tableLayoutPanel1.TabIndex = 28;
			// 
			// panel2
			// 
			panel2.BackColor = Color.FromArgb(236, 243, 249);
			panel2.Controls.Add(label12);
			panel2.Controls.Add(tableLayoutPanel2);
			panel2.Location = new Point(4, 4);
			panel2.Name = "panel2";
			panel2.Size = new Size(1247, 143);
			panel2.TabIndex = 0;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label12.Location = new Point(3, 3);
			label12.Name = "label12";
			label12.Size = new Size(87, 30);
			label12.TabIndex = 30;
			label12.Text = "Estados";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel2.Controls.Add(panel6, 1, 0);
			tableLayoutPanel2.Controls.Add(panel5, 0, 0);
			tableLayoutPanel2.Controls.Add(panel4, 2, 0);
			tableLayoutPanel2.Location = new Point(3, 36);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new Size(1241, 104);
			tableLayoutPanel2.TabIndex = 30;
			// 
			// panel6
			// 
			panel6.BackColor = Color.White;
			panel6.Controls.Add(label15);
			panel6.Controls.Add(pictureBox3);
			panel6.Controls.Add(label13);
			panel6.Font = new Font("Segoe UI Semibold", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			panel6.Location = new Point(416, 3);
			panel6.Name = "panel6";
			panel6.Size = new Size(407, 98);
			panel6.TabIndex = 1;
			// 
			// pictureBox3
			// 
			pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
			pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox3.Location = new Point(25, 21);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(59, 61);
			pictureBox3.TabIndex = 4;
			pictureBox3.TabStop = false;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label13.Location = new Point(115, 21);
			label13.Name = "label13";
			label13.Size = new Size(91, 21);
			label13.TabIndex = 1;
			label13.Text = "Terminada";
			// 
			// panel5
			// 
			panel5.BackColor = Color.White;
			panel5.Controls.Add(label11);
			panel5.Controls.Add(pictureBox4);
			panel5.Controls.Add(label3);
			panel5.Location = new Point(3, 3);
			panel5.Name = "panel5";
			panel5.Size = new Size(407, 98);
			panel5.TabIndex = 1;
			// 
			// pictureBox4
			// 
			pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
			pictureBox4.BackgroundImageLayout = ImageLayout.Center;
			pictureBox4.Location = new Point(25, 21);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new Size(59, 61);
			pictureBox4.TabIndex = 5;
			pictureBox4.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(108, 21);
			label3.Name = "label3";
			label3.Size = new Size(93, 21);
			label3.TabIndex = 0;
			label3.Text = "En Proceso";
			// 
			// panel4
			// 
			panel4.BackColor = Color.White;
			panel4.Controls.Add(label16);
			panel4.Controls.Add(pictureBox2);
			panel4.Controls.Add(label14);
			panel4.Location = new Point(829, 3);
			panel4.Name = "panel4";
			panel4.Size = new Size(405, 98);
			panel4.TabIndex = 0;
			// 
			// pictureBox2
			// 
			pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
			pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox2.Location = new Point(24, 21);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(59, 61);
			pictureBox2.TabIndex = 3;
			pictureBox2.TabStop = false;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label14.Location = new Point(109, 21);
			label14.Name = "label14";
			label14.Size = new Size(88, 21);
			label14.TabIndex = 2;
			label14.Text = "Pendiente";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(108, 53);
			label11.Name = "label11";
			label11.Size = new Size(261, 30);
			label11.TabIndex = 6;
			label11.Text = "La cuadrilla puede  tener asistencia , pero le falta\r\n actividad o lote.";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label15.Location = new Point(115, 53);
			label15.Name = "label15";
			label15.Size = new Size(235, 15);
			label15.TabIndex = 7;
			label15.Text = "La cuadrilla terminó sus actividades del día.";
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(118, 53);
			label16.Name = "label16";
			label16.Size = new Size(259, 15);
			label16.TabIndex = 8;
			label16.Text = "Aún no se ha registrado datos por falta de listas.";
			// 
			// FrmObservaciones
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(244, 247, 251);
			ClientSize = new Size(1265, 945);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(groupBox1);
			Controls.Add(dgvEstado);
			Controls.Add(panel1);
			Controls.Add(dtpFinal);
			Controls.Add(dtpInicio);
			Controls.Add(txbSemana);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmObservaciones";
			Text = "Estado de Cuadrilla";
			Load += FrmObservaciones_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvEstado).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		public DateTimePicker dtpFinal;
		public DateTimePicker dtpInicio;
		private Label label6;
		private Label label5;
		private Label label1;
		private Panel panel1;
		private Label label4;
		private Label label2;
		public DataGridView dgvEstado;
		private GroupBox groupBox1;
		private Label label7;
		private Label label10;
		private Label label9;
		private Label label8;
		public ComboBox cboDia;
		public Button btnModificar;
		private Button btnGuardar;
		private PictureBox pictureBox1;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel2;
		private Label label12;
		public ComboBox cboCuadrilla2;
		public ComboBox cboEstado;
		public Button btnAgregar;
		public TextBox txbObservaciones;
		public TextBox txbSemana;
		public Button btnCancelar;
		private TableLayoutPanel tableLayoutPanel2;
		private Panel panel5;
		private Label label3;
		private Panel panel4;
		private PictureBox pictureBox3;
		private Label label13;
		private PictureBox pictureBox4;
		private PictureBox pictureBox2;
		private Label label14;
		public Panel panel6;
		private Label label15;
		private Label label11;
		private Label label16;
	}
}
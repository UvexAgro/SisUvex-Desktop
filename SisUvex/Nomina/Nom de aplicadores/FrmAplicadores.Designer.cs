namespace SisUvex.Nomina.Nom_de_aplicadores
{
	partial class FrmAplicadores
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAplicadores));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			splitContainer1 = new SplitContainer();
			dgvEmpleados = new DataGridView();
			groupBox1 = new GroupBox();
			label3 = new Label();
			dtpFecha = new DateTimePicker();
			cboCuadrilla = new ComboBox();
			label2 = new Label();
			panel1 = new Panel();
			label1 = new Label();
			button2 = new Button();
			panel15 = new Panel();
			label26 = new Label();
			dgvTodoDatos = new DataGridView();
			panel9 = new Panel();
			panel16 = new Panel();
			lblTotalPagar = new Label();
			label22 = new Label();
			panel13 = new Panel();
			lblTotalHoras = new Label();
			label18 = new Label();
			panel14 = new Panel();
			lblTarifaHoraResumen = new Label();
			lblHorasTrabajadas = new Label();
			label25 = new Label();
			label24 = new Label();
			panel11 = new Panel();
			lblTotalCuadros = new Label();
			label23 = new Label();
			panel12 = new Panel();
			flpCuadros = new FlowLayoutPanel();
			panel10 = new Panel();
			label17 = new Label();
			panel8 = new Panel();
			label8 = new Label();
			dgvDatos = new DataGridView();
			panel2 = new Panel();
			panel7 = new Panel();
			btnAgregarHoras = new Button();
			txbImporteHoras = new TextBox();
			label19 = new Label();
			txbTarifa = new TextBox();
			label20 = new Label();
			txbHorasTrabajadas = new TextBox();
			label21 = new Label();
			button1 = new Button();
			panel6 = new Panel();
			label16 = new Label();
			panel5 = new Panel();
			btnAgregar = new Button();
			txbImportePorcentaje = new TextBox();
			label15 = new Label();
			nudCantidad = new NumericUpDown();
			label14 = new Label();
			txbPorcentaje = new TextBox();
			label13 = new Label();
			txbCosto = new TextBox();
			label12 = new Label();
			txbLineas = new TextBox();
			label11 = new Label();
			cboLote = new ComboBox();
			label10 = new Label();
			panel4 = new Panel();
			label9 = new Label();
			txbCodigo = new TextBox();
			label7 = new Label();
			txbNombre = new TextBox();
			label6 = new Label();
			label5 = new Label();
			panel3 = new Panel();
			label4 = new Label();
			dtpFechaRegistro = new DateTimePicker();
			sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
			groupBox1.SuspendLayout();
			panel1.SuspendLayout();
			panel15.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvTodoDatos).BeginInit();
			panel9.SuspendLayout();
			panel16.SuspendLayout();
			panel13.SuspendLayout();
			panel14.SuspendLayout();
			panel11.SuspendLayout();
			panel12.SuspendLayout();
			panel10.SuspendLayout();
			panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
			panel2.SuspendLayout();
			panel7.SuspendLayout();
			panel6.SuspendLayout();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.BackColor = SystemColors.GradientInactiveCaption;
			splitContainer1.Panel1.Controls.Add(dgvEmpleados);
			splitContainer1.Panel1.Controls.Add(groupBox1);
			splitContainer1.Panel1.Controls.Add(panel1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.BackColor = Color.FromArgb(242, 245, 249);
			splitContainer1.Panel2.Controls.Add(button2);
			splitContainer1.Panel2.Controls.Add(panel15);
			splitContainer1.Panel2.Controls.Add(dgvTodoDatos);
			splitContainer1.Panel2.Controls.Add(panel9);
			splitContainer1.Panel2.Controls.Add(panel8);
			splitContainer1.Panel2.Controls.Add(dgvDatos);
			splitContainer1.Panel2.Controls.Add(panel2);
			splitContainer1.Size = new Size(1843, 1092);
			splitContainer1.SplitterDistance = 349;
			splitContainer1.TabIndex = 0;
			// 
			// dgvEmpleados
			// 
			dgvEmpleados.AllowUserToAddRows = false;
			dgvEmpleados.AllowUserToDeleteRows = false;
			dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvEmpleados.BackgroundColor = SystemColors.ControlLightLight;
			dgvEmpleados.BorderStyle = BorderStyle.Fixed3D;
			dgvEmpleados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvEmpleados.ColumnHeadersHeight = 29;
			dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvEmpleados.EnableHeadersVisualStyles = false;
			dgvEmpleados.ImeMode = ImeMode.NoControl;
			dgvEmpleados.Location = new Point(3, 210);
			dgvEmpleados.Name = "dgvEmpleados";
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvEmpleados.RowHeadersVisible = false;
			dgvEmpleados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvEmpleados.Size = new Size(343, 879);
			dgvEmpleados.TabIndex = 5;
			dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.BackColor = Color.FromArgb(244, 247, 251);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(dtpFecha);
			groupBox1.Controls.Add(cboCuadrilla);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new Point(3, 50);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(343, 154);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(9, 27);
			label3.Name = "label3";
			label3.Size = new Size(44, 15);
			label3.TabIndex = 4;
			label3.Text = "Fecha :";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(9, 45);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(230, 23);
			dtpFecha.TabIndex = 3;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// cboCuadrilla
			// 
			cboCuadrilla.FormattingEnabled = true;
			cboCuadrilla.Location = new Point(9, 106);
			cboCuadrilla.Name = "cboCuadrilla";
			cboCuadrilla.Size = new Size(267, 23);
			cboCuadrilla.TabIndex = 1;
			cboCuadrilla.SelectedIndexChanged += cboCuadrilla_SelectedIndexChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(9, 88);
			label2.Name = "label2";
			label2.Size = new Size(59, 15);
			label2.TabIndex = 2;
			label2.Text = "Cuadrilla :";
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.BackColor = Color.FromArgb(35, 103, 149);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(343, 41);
			panel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(9, 5);
			label1.Name = "label1";
			label1.Size = new Size(131, 32);
			label1.TabIndex = 0;
			label1.Text = "Empleados";
			// 
			// button2
			// 
			button2.BackgroundImageLayout = ImageLayout.Zoom;
			button2.Image = (Image)resources.GetObject("button2.Image");
			button2.ImageAlign = ContentAlignment.MiddleLeft;
			button2.Location = new Point(7, 762);
			button2.Name = "button2";
			button2.Padding = new Padding(20, 0, 20, 0);
			button2.Size = new Size(137, 34);
			button2.TabIndex = 130;
			button2.Text = "Eliminar";
			button2.TextAlign = ContentAlignment.MiddleRight;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// panel15
			// 
			panel15.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel15.BackColor = Color.FromArgb(35, 103, 149);
			panel15.Controls.Add(label26);
			panel15.Location = new Point(3, 802);
			panel15.Name = "panel15";
			panel15.Size = new Size(1484, 36);
			panel15.TabIndex = 5;
			// 
			// label26
			// 
			label26.AutoSize = true;
			label26.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label26.ForeColor = Color.White;
			label26.Location = new Point(3, -2);
			label26.Name = "label26";
			label26.Size = new Size(330, 30);
			label26.TabIndex = 1;
			label26.Text = "Registros de todo los Emploados";
			// 
			// dgvTodoDatos
			// 
			dgvTodoDatos.AllowUserToAddRows = false;
			dgvTodoDatos.AllowUserToDeleteRows = false;
			dgvTodoDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvTodoDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvTodoDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvTodoDatos.BackgroundColor = SystemColors.ControlLightLight;
			dgvTodoDatos.BorderStyle = BorderStyle.Fixed3D;
			dgvTodoDatos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvTodoDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvTodoDatos.ColumnHeadersHeight = 29;
			dgvTodoDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvTodoDatos.EnableHeadersVisualStyles = false;
			dgvTodoDatos.ImeMode = ImeMode.NoControl;
			dgvTodoDatos.Location = new Point(3, 837);
			dgvTodoDatos.Name = "dgvTodoDatos";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvTodoDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvTodoDatos.RowHeadersVisible = false;
			dgvTodoDatos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvTodoDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvTodoDatos.Size = new Size(1483, 247);
			dgvTodoDatos.TabIndex = 129;
			// 
			// panel9
			// 
			panel9.BackColor = Color.White;
			panel9.Controls.Add(panel16);
			panel9.Controls.Add(panel13);
			panel9.Controls.Add(panel11);
			panel9.Controls.Add(panel10);
			panel9.Location = new Point(1057, 3);
			panel9.Name = "panel9";
			panel9.Size = new Size(382, 499);
			panel9.TabIndex = 7;
			// 
			// panel16
			// 
			panel16.BackColor = Color.FromArgb(35, 103, 149);
			panel16.Controls.Add(lblTotalPagar);
			panel16.Controls.Add(label22);
			panel16.Location = new Point(3, 402);
			panel16.Name = "panel16";
			panel16.Size = new Size(376, 94);
			panel16.TabIndex = 6;
			// 
			// lblTotalPagar
			// 
			lblTotalPagar.AutoSize = true;
			lblTotalPagar.BackColor = Color.Transparent;
			lblTotalPagar.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTotalPagar.ForeColor = Color.White;
			lblTotalPagar.Location = new Point(168, 34);
			lblTotalPagar.Name = "lblTotalPagar";
			lblTotalPagar.Size = new Size(38, 45);
			lblTotalPagar.TabIndex = 3;
			lblTotalPagar.Text = "0";
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.BackColor = Color.Transparent;
			label22.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label22.ForeColor = Color.White;
			label22.Location = new Point(13, 15);
			label22.Name = "label22";
			label22.Size = new Size(102, 21);
			label22.TabIndex = 2;
			label22.Text = "Total a Pagar";
			// 
			// panel13
			// 
			panel13.BackColor = Color.FromArgb(244, 247, 251);
			panel13.Controls.Add(lblTotalHoras);
			panel13.Controls.Add(label18);
			panel13.Controls.Add(panel14);
			panel13.Location = new Point(3, 261);
			panel13.Name = "panel13";
			panel13.Size = new Size(379, 137);
			panel13.TabIndex = 5;
			// 
			// lblTotalHoras
			// 
			lblTotalHoras.AutoSize = true;
			lblTotalHoras.BackColor = Color.Transparent;
			lblTotalHoras.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTotalHoras.ForeColor = Color.Black;
			lblTotalHoras.Location = new Point(253, 6);
			lblTotalHoras.Name = "lblTotalHoras";
			lblTotalHoras.Size = new Size(25, 30);
			lblTotalHoras.TabIndex = 2;
			lblTotalHoras.Text = "0";
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.BackColor = Color.Transparent;
			label18.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label18.ForeColor = Color.Black;
			label18.Location = new Point(3, 6);
			label18.Name = "label18";
			label18.Size = new Size(168, 30);
			label18.TabIndex = 1;
			label18.Text = "Total por Horas ";
			// 
			// panel14
			// 
			panel14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel14.BackColor = SystemColors.ControlLightLight;
			panel14.Controls.Add(lblTarifaHoraResumen);
			panel14.Controls.Add(lblHorasTrabajadas);
			panel14.Controls.Add(label25);
			panel14.Controls.Add(label24);
			panel14.Location = new Point(13, 42);
			panel14.Name = "panel14";
			panel14.Size = new Size(357, 92);
			panel14.TabIndex = 0;
			// 
			// lblTarifaHoraResumen
			// 
			lblTarifaHoraResumen.AutoSize = true;
			lblTarifaHoraResumen.BackColor = Color.Transparent;
			lblTarifaHoraResumen.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTarifaHoraResumen.ForeColor = Color.Black;
			lblTarifaHoraResumen.Location = new Point(139, 50);
			lblTarifaHoraResumen.Name = "lblTarifaHoraResumen";
			lblTarifaHoraResumen.Size = new Size(19, 21);
			lblTarifaHoraResumen.TabIndex = 6;
			lblTarifaHoraResumen.Text = "0";
			// 
			// lblHorasTrabajadas
			// 
			lblHorasTrabajadas.AutoSize = true;
			lblHorasTrabajadas.BackColor = Color.Transparent;
			lblHorasTrabajadas.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblHorasTrabajadas.ForeColor = Color.Black;
			lblHorasTrabajadas.Location = new Point(139, 12);
			lblHorasTrabajadas.Name = "lblHorasTrabajadas";
			lblHorasTrabajadas.Size = new Size(19, 21);
			lblHorasTrabajadas.TabIndex = 5;
			lblHorasTrabajadas.Text = "0";
			// 
			// label25
			// 
			label25.AutoSize = true;
			label25.BackColor = Color.Transparent;
			label25.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label25.ForeColor = Color.Black;
			label25.Location = new Point(25, 50);
			label25.Name = "label25";
			label25.Size = new Size(53, 21);
			label25.TabIndex = 4;
			label25.Text = "Tarifa:";
			// 
			// label24
			// 
			label24.AutoSize = true;
			label24.BackColor = Color.Transparent;
			label24.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label24.ForeColor = Color.Black;
			label24.Location = new Point(21, 12);
			label24.Name = "label24";
			label24.Size = new Size(57, 21);
			label24.TabIndex = 3;
			label24.Text = "Horas:";
			// 
			// panel11
			// 
			panel11.BackColor = Color.FromArgb(244, 247, 251);
			panel11.Controls.Add(lblTotalCuadros);
			panel11.Controls.Add(label23);
			panel11.Controls.Add(panel12);
			panel11.Location = new Point(3, 36);
			panel11.Name = "panel11";
			panel11.Size = new Size(379, 219);
			panel11.TabIndex = 3;
			// 
			// lblTotalCuadros
			// 
			lblTotalCuadros.AutoSize = true;
			lblTotalCuadros.BackColor = Color.Transparent;
			lblTotalCuadros.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTotalCuadros.ForeColor = Color.Black;
			lblTotalCuadros.Location = new Point(253, 11);
			lblTotalCuadros.Name = "lblTotalCuadros";
			lblTotalCuadros.Size = new Size(25, 30);
			lblTotalCuadros.TabIndex = 3;
			lblTotalCuadros.Text = "0";
			// 
			// label23
			// 
			label23.AutoSize = true;
			label23.BackColor = Color.Transparent;
			label23.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label23.ForeColor = Color.Black;
			label23.Location = new Point(13, 11);
			label23.Name = "label23";
			label23.Size = new Size(176, 30);
			label23.TabIndex = 2;
			label23.Text = "Total por Cuadro";
			// 
			// panel12
			// 
			panel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel12.BackColor = SystemColors.ControlLightLight;
			panel12.Controls.Add(flpCuadros);
			panel12.Location = new Point(13, 45);
			panel12.Name = "panel12";
			panel12.Size = new Size(357, 166);
			panel12.TabIndex = 0;
			// 
			// flpCuadros
			// 
			flpCuadros.AutoScroll = true;
			flpCuadros.Dock = DockStyle.Fill;
			flpCuadros.FlowDirection = FlowDirection.TopDown;
			flpCuadros.Location = new Point(0, 0);
			flpCuadros.Name = "flpCuadros";
			flpCuadros.Padding = new Padding(8);
			flpCuadros.Size = new Size(357, 166);
			flpCuadros.TabIndex = 0;
			flpCuadros.WrapContents = false;
			// 
			// panel10
			// 
			panel10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel10.BackColor = Color.FromArgb(35, 103, 149);
			panel10.Controls.Add(label17);
			panel10.Location = new Point(3, 0);
			panel10.Name = "panel10";
			panel10.Size = new Size(379, 36);
			panel10.TabIndex = 2;
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.BackColor = Color.Transparent;
			label17.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label17.ForeColor = Color.White;
			label17.Location = new Point(3, 3);
			label17.Name = "label17";
			label17.Size = new Size(231, 30);
			label17.TabIndex = 1;
			label17.Text = "Resumen de Empleado";
			// 
			// panel8
			// 
			panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel8.BackColor = Color.FromArgb(35, 103, 149);
			panel8.Controls.Add(label8);
			panel8.Location = new Point(3, 501);
			panel8.Name = "panel8";
			panel8.Size = new Size(1484, 36);
			panel8.TabIndex = 4;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.ForeColor = Color.White;
			label8.Location = new Point(3, 3);
			label8.Name = "label8";
			label8.Size = new Size(354, 30);
			label8.TabIndex = 1;
			label8.Text = "Detalles de Concepto del Empleado";
			// 
			// dgvDatos
			// 
			dgvDatos.AllowUserToAddRows = false;
			dgvDatos.AllowUserToDeleteRows = false;
			dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvDatos.BackgroundColor = SystemColors.ControlLightLight;
			dgvDatos.BorderStyle = BorderStyle.Fixed3D;
			dgvDatos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = SystemColors.Control;
			dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			dgvDatos.ColumnHeadersHeight = 29;
			dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvDatos.EnableHeadersVisualStyles = false;
			dgvDatos.ImeMode = ImeMode.NoControl;
			dgvDatos.Location = new Point(4, 537);
			dgvDatos.Name = "dgvDatos";
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Control;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			dgvDatos.RowHeadersVisible = false;
			dgvDatos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvDatos.Size = new Size(1483, 219);
			dgvDatos.TabIndex = 6;
			dgvDatos.CellContentClick += dgvDatos_CellContentClick;
			// 
			// panel2
			// 
			panel2.BackColor = SystemColors.ControlLightLight;
			panel2.Controls.Add(panel7);
			panel2.Controls.Add(button1);
			panel2.Controls.Add(panel6);
			panel2.Controls.Add(panel5);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(txbCodigo);
			panel2.Controls.Add(label7);
			panel2.Controls.Add(txbNombre);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(dtpFechaRegistro);
			panel2.Location = new Point(3, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(1048, 502);
			panel2.TabIndex = 0;
			// 
			// panel7
			// 
			panel7.BackColor = Color.FromArgb(244, 247, 251);
			panel7.Controls.Add(btnAgregarHoras);
			panel7.Controls.Add(txbImporteHoras);
			panel7.Controls.Add(label19);
			panel7.Controls.Add(txbTarifa);
			panel7.Controls.Add(label20);
			panel7.Controls.Add(txbHorasTrabajadas);
			panel7.Controls.Add(label21);
			panel7.Location = new Point(19, 368);
			panel7.Name = "panel7";
			panel7.Size = new Size(1005, 86);
			panel7.TabIndex = 127;
			// 
			// btnAgregarHoras
			// 
			btnAgregarHoras.BackgroundImageLayout = ImageLayout.Zoom;
			btnAgregarHoras.Image = (Image)resources.GetObject("btnAgregarHoras.Image");
			btnAgregarHoras.ImageAlign = ContentAlignment.MiddleLeft;
			btnAgregarHoras.Location = new Point(880, 24);
			btnAgregarHoras.Name = "btnAgregarHoras";
			btnAgregarHoras.Padding = new Padding(10, 0, 10, 0);
			btnAgregarHoras.Size = new Size(109, 40);
			btnAgregarHoras.TabIndex = 127;
			btnAgregarHoras.Text = "Agregar";
			btnAgregarHoras.TextAlign = ContentAlignment.MiddleRight;
			btnAgregarHoras.UseVisualStyleBackColor = true;
			btnAgregarHoras.Click += btnAgregarHoras_Click;
			// 
			// txbImporteHoras
			// 
			txbImporteHoras.Location = new Point(693, 34);
			txbImporteHoras.Name = "txbImporteHoras";
			txbImporteHoras.Size = new Size(81, 23);
			txbImporteHoras.TabIndex = 121;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label19.Location = new Point(623, 40);
			label19.Name = "label19";
			label19.Size = new Size(64, 17);
			label19.TabIndex = 120;
			label19.Text = "Importe :";
			// 
			// txbTarifa
			// 
			txbTarifa.Location = new Point(445, 34);
			txbTarifa.Name = "txbTarifa";
			txbTarifa.Size = new Size(81, 23);
			txbTarifa.TabIndex = 119;
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label20.Location = new Point(333, 40);
			label20.Name = "label20";
			label20.Size = new Size(106, 17);
			label20.TabIndex = 118;
			label20.Text = "Tarifa por Hora :";
			// 
			// txbHorasTrabajadas
			// 
			txbHorasTrabajadas.Location = new Point(158, 34);
			txbHorasTrabajadas.Name = "txbHorasTrabajadas";
			txbHorasTrabajadas.Size = new Size(81, 23);
			txbHorasTrabajadas.TabIndex = 16;
			txbHorasTrabajadas.TextChanged += txbHorasTrabajadas_TextChanged;
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label21.Location = new Point(26, 40);
			label21.Name = "label21";
			label21.Size = new Size(119, 17);
			label21.TabIndex = 15;
			label21.Text = "Horas Trabajadas :";
			// 
			// button1
			// 
			button1.BackgroundImageLayout = ImageLayout.Zoom;
			button1.Image = (Image)resources.GetObject("button1.Image");
			button1.ImageAlign = ContentAlignment.MiddleLeft;
			button1.Location = new Point(887, 460);
			button1.Name = "button1";
			button1.Padding = new Padding(20, 0, 20, 0);
			button1.Size = new Size(137, 34);
			button1.TabIndex = 128;
			button1.Text = "Guardar";
			button1.TextAlign = ContentAlignment.MiddleRight;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// panel6
			// 
			panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel6.BackColor = SystemColors.GradientInactiveCaption;
			panel6.Controls.Add(label16);
			panel6.Location = new Point(19, 331);
			panel6.Name = "panel6";
			panel6.Size = new Size(1005, 36);
			panel6.TabIndex = 3;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label16.ForeColor = Color.Black;
			label16.Location = new Point(3, 3);
			label16.Name = "label16";
			label16.Size = new Size(263, 30);
			label16.TabIndex = 1;
			label16.Text = "Informacion del Concepto";
			// 
			// panel5
			// 
			panel5.BackColor = Color.FromArgb(244, 247, 251);
			panel5.Controls.Add(btnAgregar);
			panel5.Controls.Add(txbImportePorcentaje);
			panel5.Controls.Add(label15);
			panel5.Controls.Add(nudCantidad);
			panel5.Controls.Add(label14);
			panel5.Controls.Add(txbPorcentaje);
			panel5.Controls.Add(label13);
			panel5.Controls.Add(txbCosto);
			panel5.Controls.Add(label12);
			panel5.Controls.Add(txbLineas);
			panel5.Controls.Add(label11);
			panel5.Controls.Add(cboLote);
			panel5.Controls.Add(label10);
			panel5.Location = new Point(19, 169);
			panel5.Name = "panel5";
			panel5.Size = new Size(1005, 149);
			panel5.TabIndex = 14;
			// 
			// btnAgregar
			// 
			btnAgregar.BackgroundImageLayout = ImageLayout.Zoom;
			btnAgregar.Image = (Image)resources.GetObject("btnAgregar.Image");
			btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
			btnAgregar.Location = new Point(880, 96);
			btnAgregar.Name = "btnAgregar";
			btnAgregar.Padding = new Padding(10, 0, 10, 0);
			btnAgregar.Size = new Size(109, 40);
			btnAgregar.TabIndex = 126;
			btnAgregar.Text = "Agregar";
			btnAgregar.TextAlign = ContentAlignment.MiddleRight;
			btnAgregar.UseVisualStyleBackColor = true;
			btnAgregar.Click += btnAgregar_Click;
			// 
			// txbImportePorcentaje
			// 
			txbImportePorcentaje.Location = new Point(689, 113);
			txbImportePorcentaje.Name = "txbImportePorcentaje";
			txbImportePorcentaje.Size = new Size(81, 23);
			txbImportePorcentaje.TabIndex = 125;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label15.Location = new Point(619, 119);
			label15.Name = "label15";
			label15.Size = new Size(64, 17);
			label15.TabIndex = 124;
			label15.Text = "Importe :";
			// 
			// nudCantidad
			// 
			nudCantidad.Location = new Point(470, 113);
			nudCantidad.Name = "nudCantidad";
			nudCantidad.Size = new Size(71, 23);
			nudCantidad.TabIndex = 123;
			nudCantidad.ValueChanged += nudCantidad_ValueChanged;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label14.Location = new Point(396, 119);
			label14.Name = "label14";
			label14.Size = new Size(69, 17);
			label14.TabIndex = 122;
			label14.Text = "Cantidad :";
			// 
			// txbPorcentaje
			// 
			txbPorcentaje.Location = new Point(689, 40);
			txbPorcentaje.Name = "txbPorcentaje";
			txbPorcentaje.Size = new Size(81, 23);
			txbPorcentaje.TabIndex = 121;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label13.Location = new Point(684, 22);
			label13.Name = "label13";
			label13.Size = new Size(86, 17);
			label13.TabIndex = 120;
			label13.Text = "% por Linea :";
			// 
			// txbCosto
			// 
			txbCosto.Location = new Point(498, 40);
			txbCosto.Name = "txbCosto";
			txbCosto.Size = new Size(81, 23);
			txbCosto.TabIndex = 119;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label12.Location = new Point(498, 22);
			label12.Name = "label12";
			label12.Size = new Size(50, 17);
			label12.TabIndex = 118;
			label12.Text = "Costo :";
			// 
			// txbLineas
			// 
			txbLineas.Location = new Point(315, 40);
			txbLineas.Name = "txbLineas";
			txbLineas.Size = new Size(81, 23);
			txbLineas.TabIndex = 16;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.Location = new Point(315, 22);
			label11.Name = "label11";
			label11.Size = new Size(52, 17);
			label11.TabIndex = 15;
			label11.Text = "Lineas :";
			// 
			// cboLote
			// 
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(9, 40);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(145, 23);
			cboLote.TabIndex = 117;
			cboLote.SelectedIndexChanged += cboLote_SelectedIndexChanged;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.Location = new Point(9, 20);
			label10.Name = "label10";
			label10.Size = new Size(121, 17);
			label10.TabIndex = 116;
			label10.Text = "Nombre del Lote : ";
			// 
			// panel4
			// 
			panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel4.BackColor = SystemColors.GradientInactiveCaption;
			panel4.Controls.Add(label9);
			panel4.Location = new Point(19, 134);
			panel4.Name = "panel4";
			panel4.Size = new Size(1005, 36);
			panel4.TabIndex = 2;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.Black;
			label9.Location = new Point(3, 3);
			label9.Name = "label9";
			label9.Size = new Size(263, 30);
			label9.TabIndex = 1;
			label9.Text = "Informacion del Concepto";
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(374, 84);
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(81, 23);
			txbCodigo.TabIndex = 10;
			txbCodigo.TextChanged += txbCodigo_TextChanged;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(374, 66);
			label7.Name = "label7";
			label7.Size = new Size(51, 15);
			label7.TabIndex = 9;
			label7.Text = "Codigo :";
			// 
			// txbNombre
			// 
			txbNombre.Location = new Point(568, 84);
			txbNombre.Name = "txbNombre";
			txbNombre.Size = new Size(359, 23);
			txbNombre.TabIndex = 8;
			txbNombre.TextChanged += txbNombre_TextChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(568, 66);
			label6.Name = "label6";
			label6.Size = new Size(66, 15);
			label6.TabIndex = 7;
			label6.Text = "Empleado :";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(28, 66);
			label5.Name = "label5";
			label5.Size = new Size(44, 15);
			label5.TabIndex = 6;
			label5.Text = "Fecha :";
			// 
			// panel3
			// 
			panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel3.BackColor = SystemColors.GradientInactiveCaption;
			panel3.Controls.Add(label4);
			panel3.Location = new Point(1, 0);
			panel3.Name = "panel3";
			panel3.Size = new Size(1047, 36);
			panel3.TabIndex = 0;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.Black;
			label4.Location = new Point(3, 3);
			label4.Name = "label4";
			label4.Size = new Size(206, 30);
			label4.TabIndex = 1;
			label4.Text = "Datos de el Registro";
			// 
			// dtpFechaRegistro
			// 
			dtpFechaRegistro.Location = new Point(28, 84);
			dtpFechaRegistro.Name = "dtpFechaRegistro";
			dtpFechaRegistro.Size = new Size(230, 23);
			dtpFechaRegistro.TabIndex = 5;
			// 
			// sqlCommand1
			// 
			sqlCommand1.CommandTimeout = 30;
			sqlCommand1.EnableOptimizedParameterBinding = false;
			// 
			// FrmAplicadores
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1843, 1092);
			Controls.Add(splitContainer1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAplicadores";
			Text = "Nomina de Aplicadores";
			Load += FrmAplicadores_Load;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel15.ResumeLayout(false);
			panel15.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvTodoDatos).EndInit();
			panel9.ResumeLayout(false);
			panel16.ResumeLayout(false);
			panel16.PerformLayout();
			panel13.ResumeLayout(false);
			panel13.PerformLayout();
			panel14.ResumeLayout(false);
			panel14.PerformLayout();
			panel11.ResumeLayout(false);
			panel11.PerformLayout();
			panel12.ResumeLayout(false);
			panel10.ResumeLayout(false);
			panel10.PerformLayout();
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private Panel panel1;
		private Label label2;
		private Label label1;
		private GroupBox groupBox1;
		private Label label3;
		private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
		public DataGridView dgvEmpleados;
		public DateTimePicker dtpFecha;
		public ComboBox cboCuadrilla;
		private Panel panel2;
		private Label label5;
		private Panel panel3;
		private Label label4;
		public DateTimePicker dtpFechaRegistro;
		private Label label7;
		private Label label6;
		private Panel panel5;
		private Panel panel4;
		private Label label9;
		public TextBox txbCodigo;
		public TextBox txbNombre;
		public TextBox txbPorcentaje;
		public Label label13;
		public TextBox txbCosto;
		public Label label12;
		public TextBox txbLineas;
		public Label label11;
		public ComboBox cboLote;
		private Label label10;
		public TextBox txbImportePorcentaje;
		public Label label15;
		public Label label14;
		private Button btnAgregar;
		private Panel panel7;
		public TextBox textBox3;
		public Label label19;
		public TextBox txbTarifa;
		public Label label20;
		public TextBox txbHorasTrabajadas;
		public Label label21;
		private Panel panel6;
		private Label label16;
		public NumericUpDown nudCantidad;
		public TextBox txbImporteHoras;
		public DataGridView dgvDatos;
		private Button btnAgregarHoras;
		private Panel panel8;
		private Label label8;
		private Panel panel9;
		private Panel panel11;
		private Panel panel10;
		private Label label17;
		private Panel panel12;
		private Label label18;
		private Panel panel13;
		private Panel panel14;
		private Panel panel16;
		private Label label22;
		private Label label23;
		public Label lblTotalHoras;
		public Label lblTarifaHoraResumen;
		public Label lblHorasTrabajadas;
		public Label label25;
		public Label label24;
		public Label lblTotalCuadros;
		public FlowLayoutPanel flpCuadros;
		public Label lblTotalPagar;
		private Button button1;
		public DataGridView dgvTodoDatos;
		private Panel panel15;
		private Label label26;
		private Button button2;
	}
}
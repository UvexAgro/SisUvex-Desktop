namespace SisUvex.Nomina.Generar_Recibos_de_Nomina
{
	partial class FrmRecibos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecibos));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			dtpFechaFinal = new DateTimePicker();
			cboSemana = new ComboBox();
			label2 = new Label();
			panel1 = new Panel();
			label1 = new Label();
			dtpFechaInicial = new DateTimePicker();
			panel2 = new Panel();
			pictureBox4 = new PictureBox();
			label3 = new Label();
			panel3 = new Panel();
			pictureBox2 = new PictureBox();
			rbNormal = new RadioButton();
			label10 = new Label();
			pictureBox1 = new PictureBox();
			rbCfdi = new RadioButton();
			label9 = new Label();
			panel4 = new Panel();
			pictureBox5 = new PictureBox();
			label6 = new Label();
			label17 = new Label();
			panel5 = new Panel();
			pictureBox9 = new PictureBox();
			label5 = new Label();
			label4 = new Label();
			panel6 = new Panel();
			btnBuscar = new Button();
			cboLugarPago = new ComboBox();
			txbNombre = new TextBox();
			label12 = new Label();
			txbCodigo = new TextBox();
			label11 = new Label();
			panel7 = new Panel();
			pictureBox6 = new PictureBox();
			label7 = new Label();
			panel8 = new Panel();
			label14 = new Label();
			label13 = new Label();
			cboDireccion = new ComboBox();
			cboOrdenar = new ComboBox();
			panel9 = new Panel();
			pictureBox3 = new PictureBox();
			label8 = new Label();
			btnConsultar = new Button();
			btnLimpiar = new Button();
			sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
			dgvRecibo = new DataGridView();
			panel10 = new Panel();
			pictureBox7 = new PictureBox();
			label15 = new Label();
			panel11 = new Panel();
			lblNormal = new Label();
			lblCfdi = new Label();
			lblEmpleados = new Label();
			btnPdf = new Button();
			button2 = new Button();
			button1 = new Button();
			panel15 = new Panel();
			panel14 = new Panel();
			panel13 = new Panel();
			label19 = new Label();
			label18 = new Label();
			panel12 = new Panel();
			pictureBox8 = new PictureBox();
			label16 = new Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
			panel6.SuspendLayout();
			panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
			panel8.SuspendLayout();
			panel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvRecibo).BeginInit();
			panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
			panel11.SuspendLayout();
			panel12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
			SuspendLayout();
			// 
			// dtpFechaFinal
			// 
			dtpFechaFinal.Enabled = false;
			dtpFechaFinal.Format = DateTimePickerFormat.Custom;
			dtpFechaFinal.Location = new Point(346, 67);
			dtpFechaFinal.Name = "dtpFechaFinal";
			dtpFechaFinal.Size = new Size(129, 23);
			dtpFechaFinal.TabIndex = 1;
			// 
			// cboSemana
			// 
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(17, 67);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(121, 23);
			cboSemana.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(19, 49);
			label2.Name = "label2";
			label2.Size = new Size(53, 15);
			label2.TabIndex = 4;
			label2.Text = "Semana:";
			// 
			// panel1
			// 
			panel1.BackColor = Color.FromArgb(242, 245, 249);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(dtpFechaInicial);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(cboSemana);
			panel1.Controls.Add(dtpFechaFinal);
			panel1.Location = new Point(4, 75);
			panel1.Name = "panel1";
			panel1.Size = new Size(502, 109);
			panel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(310, 72);
			label1.Name = "label1";
			label1.Size = new Size(18, 15);
			label1.TabIndex = 6;
			label1.Text = "Al";
			// 
			// dtpFechaInicial
			// 
			dtpFechaInicial.Enabled = false;
			dtpFechaInicial.Format = DateTimePickerFormat.Custom;
			dtpFechaInicial.Location = new Point(162, 67);
			dtpFechaInicial.Name = "dtpFechaInicial";
			dtpFechaInicial.Size = new Size(129, 23);
			dtpFechaInicial.TabIndex = 5;
			// 
			// panel2
			// 
			panel2.BackColor = Color.FromArgb(220, 232, 244);
			panel2.Controls.Add(pictureBox4);
			panel2.Controls.Add(label3);
			panel2.Location = new Point(4, 75);
			panel2.Name = "panel2";
			panel2.Size = new Size(502, 35);
			panel2.TabIndex = 7;
			// 
			// pictureBox4
			// 
			pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
			pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox4.Location = new Point(9, 4);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new Size(28, 23);
			pictureBox4.TabIndex = 15;
			pictureBox4.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(38, 52, 69);
			label3.Location = new Point(43, 7);
			label3.Name = "label3";
			label3.Size = new Size(69, 20);
			label3.TabIndex = 7;
			label3.Text = "Periodo";
			// 
			// panel3
			// 
			panel3.BackColor = Color.FromArgb(242, 245, 249);
			panel3.Controls.Add(pictureBox2);
			panel3.Controls.Add(rbNormal);
			panel3.Controls.Add(label10);
			panel3.Controls.Add(pictureBox1);
			panel3.Controls.Add(rbCfdi);
			panel3.Controls.Add(label9);
			panel3.Controls.Add(panel4);
			panel3.Location = new Point(529, 74);
			panel3.Name = "panel3";
			panel3.Size = new Size(496, 110);
			panel3.TabIndex = 7;
			// 
			// pictureBox2
			// 
			pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
			pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox2.Location = new Point(336, 54);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(39, 35);
			pictureBox2.TabIndex = 13;
			pictureBox2.TabStop = false;
			// 
			// rbNormal
			// 
			rbNormal.AutoSize = true;
			rbNormal.ImageAlign = ContentAlignment.MiddleLeft;
			rbNormal.Location = new Point(304, 66);
			rbNormal.Name = "rbNormal";
			rbNormal.Padding = new Padding(5, 0, 5, 0);
			rbNormal.Size = new Size(24, 13);
			rbNormal.TabIndex = 12;
			rbNormal.TabStop = true;
			rbNormal.TextAlign = ContentAlignment.MiddleCenter;
			rbNormal.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.ForeColor = Color.Black;
			label10.Location = new Point(379, 54);
			label10.Name = "label10";
			label10.Size = new Size(66, 34);
			label10.TabIndex = 11;
			label10.Text = "Normal \r\n(Sin CFDI)";
			label10.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(54, 54);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(39, 35);
			pictureBox1.TabIndex = 10;
			pictureBox1.TabStop = false;
			// 
			// rbCfdi
			// 
			rbCfdi.AutoSize = true;
			rbCfdi.ImageAlign = ContentAlignment.MiddleLeft;
			rbCfdi.Location = new Point(22, 66);
			rbCfdi.Name = "rbCfdi";
			rbCfdi.Padding = new Padding(5, 0, 5, 0);
			rbCfdi.Size = new Size(24, 13);
			rbCfdi.TabIndex = 9;
			rbCfdi.TabStop = true;
			rbCfdi.TextAlign = ContentAlignment.MiddleCenter;
			rbCfdi.UseVisualStyleBackColor = true;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.Black;
			label9.Location = new Point(97, 54);
			label9.Name = "label9";
			label9.Size = new Size(100, 34);
			label9.TabIndex = 8;
			label9.Text = "Con Impuestos\r\n(CFDI)";
			label9.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			panel4.BackColor = Color.FromArgb(220, 232, 244);
			panel4.Controls.Add(pictureBox5);
			panel4.Controls.Add(label6);
			panel4.Location = new Point(1, 0);
			panel4.Name = "panel4";
			panel4.Size = new Size(495, 36);
			panel4.TabIndex = 8;
			// 
			// pictureBox5
			// 
			pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
			pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox5.Location = new Point(8, 5);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new Size(28, 23);
			pictureBox5.TabIndex = 16;
			pictureBox5.TabStop = false;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(38, 52, 69);
			label6.Location = new Point(41, 8);
			label6.Name = "label6";
			label6.Size = new Size(124, 20);
			label6.TabIndex = 7;
			label6.Text = "Tipo de Recibo ";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label17.ForeColor = Color.Black;
			label17.Location = new Point(10, 93);
			label17.Name = "label17";
			label17.Size = new Size(143, 17);
			label17.TabIndex = 14;
			label17.Text = "Con Impuestos (CFDI):";
			label17.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel5.BackColor = Color.FromArgb(35, 103, 149);
			panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
			panel5.BackgroundImageLayout = ImageLayout.Stretch;
			panel5.Controls.Add(pictureBox9);
			panel5.Controls.Add(label5);
			panel5.Controls.Add(label4);
			panel5.Location = new Point(2, 0);
			panel5.Name = "panel5";
			panel5.Size = new Size(1230, 68);
			panel5.TabIndex = 8;
			// 
			// pictureBox9
			// 
			pictureBox9.BackColor = Color.Transparent;
			pictureBox9.BackgroundImage = (Image)resources.GetObject("pictureBox9.BackgroundImage");
			pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox9.Location = new Point(2, 7);
			pictureBox9.Name = "pictureBox9";
			pictureBox9.Size = new Size(56, 50);
			pictureBox9.TabIndex = 9;
			pictureBox9.TabStop = false;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.Transparent;
			label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.White;
			label5.Location = new Point(66, 39);
			label5.Name = "label5";
			label5.Size = new Size(156, 20);
			label5.TabIndex = 8;
			label5.Text = "NOMINA DE CAMPO ";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.Transparent;
			label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.White;
			label4.Location = new Point(66, 7);
			label4.Name = "label4";
			label4.Size = new Size(407, 32);
			label4.TabIndex = 8;
			label4.Text = "Generacion de Recibos de Nomina";
			// 
			// panel6
			// 
			panel6.BackColor = Color.FromArgb(242, 245, 249);
			panel6.Controls.Add(btnBuscar);
			panel6.Controls.Add(cboLugarPago);
			panel6.Controls.Add(txbNombre);
			panel6.Controls.Add(label12);
			panel6.Controls.Add(txbCodigo);
			panel6.Controls.Add(label11);
			panel6.Controls.Add(panel7);
			panel6.Location = new Point(301, 201);
			panel6.Name = "panel6";
			panel6.Size = new Size(562, 162);
			panel6.TabIndex = 9;
			// 
			// btnBuscar
			// 
			btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
			btnBuscar.Font = new Font("Segoe UI", 14F);
			btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
			btnBuscar.Location = new Point(179, 119);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(28, 25);
			btnBuscar.TabIndex = 37;
			btnBuscar.TextAlign = ContentAlignment.MiddleRight;
			btnBuscar.UseVisualStyleBackColor = true;
			btnBuscar.Click += btnBuscar_Click;
			// 
			// cboLugarPago
			// 
			cboLugarPago.FormattingEnabled = true;
			cboLugarPago.Location = new Point(101, 57);
			cboLugarPago.Name = "cboLugarPago";
			cboLugarPago.Size = new Size(334, 23);
			cboLugarPago.TabIndex = 16;
			// 
			// txbNombre
			// 
			txbNombre.Enabled = false;
			txbNombre.Location = new Point(211, 120);
			txbNombre.Name = "txbNombre";
			txbNombre.Size = new Size(286, 23);
			txbNombre.TabIndex = 15;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label12.ForeColor = Color.Black;
			label12.Location = new Point(10, 122);
			label12.Name = "label12";
			label12.Size = new Size(54, 17);
			label12.TabIndex = 14;
			label12.Text = "Codigo:";
			label12.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(70, 120);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(105, 23);
			txbCodigo.TabIndex = 9;
			txbCodigo.KeyDown += txbCodigo_KeyDown;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.Location = new Point(9, 65);
			label11.Name = "label11";
			label11.Size = new Size(86, 15);
			label11.TabIndex = 8;
			label11.Text = "Lugar de Pago:";
			// 
			// panel7
			// 
			panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel7.BackColor = Color.FromArgb(220, 232, 244);
			panel7.Controls.Add(pictureBox6);
			panel7.Controls.Add(label7);
			panel7.Location = new Point(1, 0);
			panel7.Name = "panel7";
			panel7.Size = new Size(561, 36);
			panel7.TabIndex = 8;
			// 
			// pictureBox6
			// 
			pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
			pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox6.Location = new Point(8, 8);
			pictureBox6.Name = "pictureBox6";
			pictureBox6.Size = new Size(28, 23);
			pictureBox6.TabIndex = 17;
			pictureBox6.TabStop = false;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.FromArgb(38, 52, 69);
			label7.Location = new Point(41, 8);
			label7.Name = "label7";
			label7.Size = new Size(156, 20);
			label7.TabIndex = 7;
			label7.Text = "Filtro de Empleados";
			// 
			// panel8
			// 
			panel8.BackColor = Color.FromArgb(242, 245, 249);
			panel8.Controls.Add(label14);
			panel8.Controls.Add(label13);
			panel8.Controls.Add(cboDireccion);
			panel8.Controls.Add(cboOrdenar);
			panel8.Controls.Add(panel9);
			panel8.Location = new Point(4, 201);
			panel8.Name = "panel8";
			panel8.Size = new Size(291, 162);
			panel8.TabIndex = 9;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label14.Location = new Point(5, 122);
			label14.Name = "label14";
			label14.Size = new Size(61, 15);
			label14.TabIndex = 10;
			label14.Text = "Direccion:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label13.Location = new Point(3, 70);
			label13.Name = "label13";
			label13.Size = new Size(53, 15);
			label13.TabIndex = 7;
			label13.Text = "Ordenar:";
			// 
			// cboDireccion
			// 
			cboDireccion.FormattingEnabled = true;
			cboDireccion.Location = new Point(90, 116);
			cboDireccion.Name = "cboDireccion";
			cboDireccion.Size = new Size(176, 23);
			cboDireccion.TabIndex = 9;
			// 
			// cboOrdenar
			// 
			cboOrdenar.FormattingEnabled = true;
			cboOrdenar.Location = new Point(90, 65);
			cboOrdenar.Name = "cboOrdenar";
			cboOrdenar.Size = new Size(176, 23);
			cboOrdenar.TabIndex = 7;
			// 
			// panel9
			// 
			panel9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel9.BackColor = Color.FromArgb(220, 232, 244);
			panel9.Controls.Add(pictureBox3);
			panel9.Controls.Add(label8);
			panel9.Location = new Point(1, 0);
			panel9.Name = "panel9";
			panel9.Size = new Size(290, 36);
			panel9.TabIndex = 8;
			// 
			// pictureBox3
			// 
			pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
			pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox3.Location = new Point(7, 7);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(28, 23);
			pictureBox3.TabIndex = 14;
			pictureBox3.TabStop = false;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.ForeColor = Color.FromArgb(38, 52, 69);
			label8.Location = new Point(41, 8);
			label8.Name = "label8";
			label8.Size = new Size(114, 20);
			label8.TabIndex = 7;
			label8.Text = "Ordenamiento";
			// 
			// btnConsultar
			// 
			btnConsultar.BackColor = Color.White;
			btnConsultar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
			btnConsultar.ImageAlign = ContentAlignment.MiddleLeft;
			btnConsultar.Location = new Point(881, 253);
			btnConsultar.Name = "btnConsultar";
			btnConsultar.Padding = new Padding(25, 0, 25, 0);
			btnConsultar.Size = new Size(145, 41);
			btnConsultar.TabIndex = 16;
			btnConsultar.Text = "Consultar";
			btnConsultar.TextAlign = ContentAlignment.MiddleRight;
			btnConsultar.UseVisualStyleBackColor = false;
			btnConsultar.Click += btnConsultar_Click;
			// 
			// btnLimpiar
			// 
			btnLimpiar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnLimpiar.Image = (Image)resources.GetObject("btnLimpiar.Image");
			btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
			btnLimpiar.Location = new Point(881, 313);
			btnLimpiar.Name = "btnLimpiar";
			btnLimpiar.Padding = new Padding(30, 0, 30, 0);
			btnLimpiar.Size = new Size(145, 41);
			btnLimpiar.TabIndex = 17;
			btnLimpiar.Text = "Limpiar";
			btnLimpiar.TextAlign = ContentAlignment.MiddleRight;
			btnLimpiar.UseVisualStyleBackColor = true;
			btnLimpiar.Click += btnLimpiar_Click;
			// 
			// sqlCommand1
			// 
			sqlCommand1.CommandTimeout = 30;
			sqlCommand1.EnableOptimizedParameterBinding = false;
			// 
			// dgvRecibo
			// 
			dgvRecibo.AllowUserToAddRows = false;
			dgvRecibo.AllowUserToDeleteRows = false;
			dgvRecibo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvRecibo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvRecibo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvRecibo.BackgroundColor = Color.White;
			dgvRecibo.BorderStyle = BorderStyle.Fixed3D;
			dgvRecibo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvRecibo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvRecibo.ColumnHeadersHeight = 29;
			dgvRecibo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvRecibo.EnableHeadersVisualStyles = false;
			dgvRecibo.ImeMode = ImeMode.NoControl;
			dgvRecibo.Location = new Point(2, 408);
			dgvRecibo.Name = "dgvRecibo";
			dgvRecibo.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvRecibo.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvRecibo.RowHeadersVisible = false;
			dgvRecibo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvRecibo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvRecibo.Size = new Size(1232, 437);
			dgvRecibo.TabIndex = 18;
			dgvRecibo.CellContentClick += dgvRecibo_CellContentClick;
			// 
			// panel10
			// 
			panel10.BackColor = Color.FromArgb(220, 232, 244);
			panel10.Controls.Add(pictureBox7);
			panel10.Controls.Add(label15);
			panel10.Location = new Point(2, 3);
			panel10.Name = "panel10";
			panel10.Size = new Size(1112, 40);
			panel10.TabIndex = 17;
			// 
			// pictureBox7
			// 
			pictureBox7.BackgroundImage = (Image)resources.GetObject("pictureBox7.BackgroundImage");
			pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox7.Location = new Point(9, 8);
			pictureBox7.Name = "pictureBox7";
			pictureBox7.Size = new Size(28, 23);
			pictureBox7.TabIndex = 15;
			pictureBox7.TabStop = false;
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label15.ForeColor = Color.FromArgb(38, 52, 69);
			label15.Location = new Point(43, 10);
			label15.Name = "label15";
			label15.Size = new Size(182, 20);
			label15.TabIndex = 7;
			label15.Text = "Resumen de Generacion";
			// 
			// panel11
			// 
			panel11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			panel11.BackColor = Color.FromArgb(242, 245, 249);
			panel11.Controls.Add(lblNormal);
			panel11.Controls.Add(lblCfdi);
			panel11.Controls.Add(lblEmpleados);
			panel11.Controls.Add(btnPdf);
			panel11.Controls.Add(panel10);
			panel11.Controls.Add(button2);
			panel11.Controls.Add(button1);
			panel11.Controls.Add(panel15);
			panel11.Controls.Add(panel14);
			panel11.Controls.Add(panel13);
			panel11.Controls.Add(label19);
			panel11.Controls.Add(label18);
			panel11.Controls.Add(label17);
			panel11.Location = new Point(2, 848);
			panel11.Name = "panel11";
			panel11.Size = new Size(1116, 157);
			panel11.TabIndex = 16;
			// 
			// lblNormal
			// 
			lblNormal.AutoSize = true;
			lblNormal.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblNormal.ForeColor = Color.Black;
			lblNormal.Location = new Point(74, 132);
			lblNormal.Name = "lblNormal";
			lblNormal.Size = new Size(0, 17);
			lblNormal.TabIndex = 24;
			lblNormal.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblCfdi
			// 
			lblCfdi.AutoSize = true;
			lblCfdi.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCfdi.ForeColor = Color.Black;
			lblCfdi.Location = new Point(159, 93);
			lblCfdi.Name = "lblCfdi";
			lblCfdi.Size = new Size(0, 17);
			lblCfdi.TabIndex = 23;
			lblCfdi.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblEmpleados
			// 
			lblEmpleados.AutoSize = true;
			lblEmpleados.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEmpleados.ForeColor = Color.Black;
			lblEmpleados.Location = new Point(93, 62);
			lblEmpleados.Name = "lblEmpleados";
			lblEmpleados.Size = new Size(0, 17);
			lblEmpleados.TabIndex = 22;
			lblEmpleados.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnPdf
			// 
			btnPdf.BackColor = Color.White;
			btnPdf.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnPdf.Image = (Image)resources.GetObject("btnPdf.Image");
			btnPdf.ImageAlign = ContentAlignment.MiddleLeft;
			btnPdf.Location = new Point(478, 82);
			btnPdf.Name = "btnPdf";
			btnPdf.Padding = new Padding(25, 0, 25, 0);
			btnPdf.Size = new Size(177, 41);
			btnPdf.TabIndex = 21;
			btnPdf.Text = "Formato Pdf";
			btnPdf.TextAlign = ContentAlignment.MiddleRight;
			btnPdf.UseVisualStyleBackColor = false;
			btnPdf.Click += btnPdf_Click;
			// 
			// button2
			// 
			button2.BackColor = Color.White;
			button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button2.Image = (Image)resources.GetObject("button2.Image");
			button2.ImageAlign = ContentAlignment.MiddleLeft;
			button2.Location = new Point(879, 82);
			button2.Name = "button2";
			button2.Padding = new Padding(25, 0, 25, 0);
			button2.Size = new Size(145, 41);
			button2.TabIndex = 20;
			button2.Text = "Cancelar";
			button2.TextAlign = ContentAlignment.MiddleRight;
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.BackColor = Color.White;
			button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button1.Image = (Image)resources.GetObject("button1.Image");
			button1.ImageAlign = ContentAlignment.MiddleLeft;
			button1.Location = new Point(693, 82);
			button1.Name = "button1";
			button1.Padding = new Padding(25, 0, 25, 0);
			button1.Size = new Size(145, 41);
			button1.TabIndex = 19;
			button1.Text = "Imprimir";
			button1.TextAlign = ContentAlignment.MiddleRight;
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// panel15
			// 
			panel15.BackColor = Color.Gray;
			panel15.Location = new Point(341, 49);
			panel15.Name = "panel15";
			panel15.Size = new Size(1, 100);
			panel15.TabIndex = 19;
			// 
			// panel14
			// 
			panel14.BackColor = Color.DimGray;
			panel14.Location = new Point(9, 122);
			panel14.Name = "panel14";
			panel14.Size = new Size(300, 1);
			panel14.TabIndex = 18;
			// 
			// panel13
			// 
			panel13.BackColor = Color.DimGray;
			panel13.Location = new Point(10, 82);
			panel13.Name = "panel13";
			panel13.Size = new Size(300, 1);
			panel13.TabIndex = 17;
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label19.ForeColor = Color.Black;
			label19.Location = new Point(12, 132);
			label19.Name = "label19";
			label19.Size = new Size(56, 17);
			label19.TabIndex = 16;
			label19.Text = "Normal:";
			label19.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label18.ForeColor = Color.Black;
			label18.Location = new Point(10, 62);
			label18.Name = "label18";
			label18.Size = new Size(77, 17);
			label18.TabIndex = 15;
			label18.Text = "Empleados:";
			label18.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel12
			// 
			panel12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel12.BackColor = Color.FromArgb(220, 232, 244);
			panel12.Controls.Add(pictureBox8);
			panel12.Controls.Add(label16);
			panel12.Location = new Point(2, 369);
			panel12.Name = "panel12";
			panel12.Size = new Size(1231, 40);
			panel12.TabIndex = 18;
			// 
			// pictureBox8
			// 
			pictureBox8.BackgroundImage = (Image)resources.GetObject("pictureBox8.BackgroundImage");
			pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox8.Location = new Point(9, 8);
			pictureBox8.Name = "pictureBox8";
			pictureBox8.Size = new Size(28, 23);
			pictureBox8.TabIndex = 15;
			pictureBox8.TabStop = false;
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label16.ForeColor = Color.FromArgb(38, 52, 69);
			label16.Location = new Point(43, 10);
			label16.Name = "label16";
			label16.Size = new Size(179, 20);
			label16.TabIndex = 7;
			label16.Text = "Empleados  Econtrados";
			// 
			// FrmRecibos
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1238, 1009);
			Controls.Add(panel12);
			Controls.Add(panel11);
			Controls.Add(dgvRecibo);
			Controls.Add(btnLimpiar);
			Controls.Add(btnConsultar);
			Controls.Add(panel8);
			Controls.Add(panel6);
			Controls.Add(panel5);
			Controls.Add(panel3);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmRecibos";
			Text = "Generacion de Recibos";
			Load += FrmRecibos_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			panel9.ResumeLayout(false);
			panel9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvRecibo).EndInit();
			panel10.ResumeLayout(false);
			panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
			panel11.ResumeLayout(false);
			panel11.PerformLayout();
			panel12.ResumeLayout(false);
			panel12.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private Label label2;
		private Panel panel1;
		private Label label1;
		private Panel panel2;
		private Label label3;
		private Panel panel3;
		private Panel panel4;
		private Label label6;
		private Panel panel5;
		private Label label5;
		private Label label4;
		private Panel panel6;
		private Panel panel7;
		private Label label7;
		private Panel panel8;
		private Panel panel9;
		private Label label8;
		private Label label9;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		private Label label10;
		private PictureBox pictureBox4;
		private PictureBox pictureBox5;
		private PictureBox pictureBox6;
		private PictureBox pictureBox3;
		private Label label11;
		private Label label12;
		private Button btnConsultar;
		private Button btnLimpiar;
		private Button cboLugardePago;
		private Label label14;
		private Label label13;
		private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
		public Button btnBuscar;
		public DataGridView dgvRecibo;
		private Panel panel10;
		private PictureBox pictureBox7;
		private Label label15;
		private Panel panel11;
		private Panel panel12;
		private PictureBox pictureBox8;
		private Label label16;
		public DateTimePicker dtpFechaFinal;
		public ComboBox cboSemana;
		public DateTimePicker dtpFechaInicial;
		public TextBox txbNombre;
		public TextBox txbCodigo;
		private Label label17;
		private Label label19;
		private Label label18;
		private Panel panel13;
		private Panel panel15;
		private Panel panel14;
		private Button button2;
		private Button button1;
		public ComboBox cboLugarPago;
		public ComboBox cboDireccion;
		public ComboBox cboOrdenar;
		public RadioButton rbCfdi;
		public RadioButton rbNormal;
		private Button btnPdf;
		private PictureBox pictureBox9;
		public Label lblNormal;
		public Label lblCfdi;
		public Label lblEmpleados;
		private Label label21;
		private Label label20;
	}
}
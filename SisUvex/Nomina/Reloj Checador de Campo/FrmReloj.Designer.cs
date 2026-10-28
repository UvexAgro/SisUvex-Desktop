namespace SisUvex.Nomina.Reloj_Checador_de_Campo
{
	partial class FrmReloj
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReloj));
			dgvLista = new DataGridView();
			groupBox1 = new GroupBox();
			label15 = new Label();
			label14 = new Label();
			label13 = new Label();
			label12 = new Label();
			txbLugardePago = new TextBox();
			txbCuadrilla = new TextBox();
			label11 = new Label();
			label10 = new Label();
			btnLimpiar = new Button();
			btnBuscar = new Button();
			btnConsultarSemana = new Button();
			label9 = new Label();
			label8 = new Label();
			dtpFechaFinal = new DateTimePicker();
			label7 = new Label();
			dtpFechaInicial = new DateTimePicker();
			label6 = new Label();
			panel1 = new Panel();
			label5 = new Label();
			cboSemana = new ComboBox();
			btnConsultar = new Button();
			txbCodigo = new TextBox();
			label2 = new Label();
			txbEmpleado = new TextBox();
			label1 = new Label();
			panel2 = new Panel();
			label3 = new Label();
			label4 = new Label();
			pictureBox1 = new PictureBox();
			((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
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
			dgvLista.Location = new Point(2, 548);
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
			dgvLista.Size = new Size(1513, 610);
			dgvLista.TabIndex = 4;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = Color.FromArgb(236, 243, 249);
			groupBox1.Controls.Add(label15);
			groupBox1.Controls.Add(label14);
			groupBox1.Controls.Add(label13);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(txbLugardePago);
			groupBox1.Controls.Add(txbCuadrilla);
			groupBox1.Controls.Add(label11);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(btnLimpiar);
			groupBox1.Controls.Add(btnBuscar);
			groupBox1.Controls.Add(btnConsultarSemana);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(dtpFechaFinal);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(dtpFechaInicial);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(panel1);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(cboSemana);
			groupBox1.Controls.Add(btnConsultar);
			groupBox1.Controls.Add(txbCodigo);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(txbEmpleado);
			groupBox1.Controls.Add(label1);
			groupBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(3, 142);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(1270, 400);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Filtro de Busqueda";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label15.ForeColor = Color.DimGray;
			label15.Location = new Point(540, 211);
			label15.Name = "label15";
			label15.Size = new Size(275, 13);
			label15.TabIndex = 46;
			label15.Text = "Limpia el filtro del empleado para consultar a todos.";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label14.ForeColor = Color.DimGray;
			label14.Location = new Point(6, 29);
			label14.Name = "label14";
			label14.Size = new Size(571, 13);
			label14.TabIndex = 45;
			label14.Text = "Escribe el código y presiona Enter o utiliza «Buscar Empleado» para buscar el Empleado cargar la información.";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label13.ForeColor = Color.DimGray;
			label13.Location = new Point(670, 360);
			label13.Name = "label13";
			label13.Size = new Size(543, 26);
			label13.TabIndex = 44;
			label13.Text = "Selecciona un rango de fecha y presiona el botón. Si ingresaste un código, se consultará ese empleado; \r\nsi lo dejas vacío, se consultarán todos.";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label12.ForeColor = Color.DimGray;
			label12.Location = new Point(9, 360);
			label12.Name = "label12";
			label12.Size = new Size(510, 26);
			label12.TabIndex = 43;
			label12.Text = "Selecciona una semana y presiona el botón. Si ingresaste un código, se consultará ese empleado; \r\nsi lo dejas vacío, se consultarán todos.";
			// 
			// txbLugardePago
			// 
			txbLugardePago.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			txbLugardePago.Location = new Point(141, 181);
			txbLugardePago.Name = "txbLugardePago";
			txbLugardePago.ReadOnly = true;
			txbLugardePago.Size = new Size(289, 27);
			txbLugardePago.TabIndex = 42;
			// 
			// txbCuadrilla
			// 
			txbCuadrilla.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			txbCuadrilla.Location = new Point(141, 141);
			txbCuadrilla.Name = "txbCuadrilla";
			txbCuadrilla.ReadOnly = true;
			txbCuadrilla.Size = new Size(289, 27);
			txbCuadrilla.TabIndex = 41;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.Location = new Point(15, 186);
			label11.Name = "label11";
			label11.Size = new Size(99, 17);
			label11.TabIndex = 40;
			label11.Text = "Lugar de Pago:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.Location = new Point(15, 151);
			label10.Name = "label10";
			label10.Size = new Size(63, 17);
			label10.TabIndex = 39;
			label10.Text = "Cuadrilla:";
			// 
			// btnLimpiar
			// 
			btnLimpiar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnLimpiar.Image = (Image)resources.GetObject("btnLimpiar.Image");
			btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
			btnLimpiar.Location = new Point(540, 175);
			btnLimpiar.Name = "btnLimpiar";
			btnLimpiar.Padding = new Padding(20, 0, 20, 0);
			btnLimpiar.Size = new Size(124, 33);
			btnLimpiar.TabIndex = 38;
			btnLimpiar.Text = "Limpiar";
			btnLimpiar.TextAlign = ContentAlignment.MiddleRight;
			btnLimpiar.UseVisualStyleBackColor = true;
			btnLimpiar.Click += btnLimpiar_Click;
			// 
			// btnBuscar
			// 
			btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
			btnBuscar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
			btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
			btnBuscar.Location = new Point(272, 59);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Padding = new Padding(20, 0, 20, 0);
			btnBuscar.Size = new Size(197, 34);
			btnBuscar.TabIndex = 37;
			btnBuscar.Text = "Buscar Empleado";
			btnBuscar.TextAlign = ContentAlignment.MiddleRight;
			btnBuscar.UseVisualStyleBackColor = true;
			btnBuscar.Click += btnBuscar_Click;
			// 
			// btnConsultarSemana
			// 
			btnConsultarSemana.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnConsultarSemana.Image = (Image)resources.GetObject("btnConsultarSemana.Image");
			btnConsultarSemana.ImageAlign = ContentAlignment.MiddleLeft;
			btnConsultarSemana.Location = new Point(354, 313);
			btnConsultarSemana.Name = "btnConsultarSemana";
			btnConsultarSemana.Padding = new Padding(20, 0, 20, 0);
			btnConsultarSemana.Size = new Size(152, 33);
			btnConsultarSemana.TabIndex = 17;
			btnConsultarSemana.Text = "Consultar";
			btnConsultarSemana.TextAlign = ContentAlignment.MiddleRight;
			btnConsultarSemana.UseVisualStyleBackColor = true;
			btnConsultarSemana.Click += btnConsultarSemana_Click;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(670, 259);
			label9.Name = "label9";
			label9.Size = new Size(156, 25);
			label9.TabIndex = 16;
			label9.Text = "Rango de Fechas";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(838, 297);
			label8.Name = "label8";
			label8.Size = new Size(78, 17);
			label8.TabIndex = 15;
			label8.Text = "Fecha Final:";
			// 
			// dtpFechaFinal
			// 
			dtpFechaFinal.CustomFormat = "dd/MM/yyyy";
			dtpFechaFinal.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dtpFechaFinal.Format = DateTimePickerFormat.Custom;
			dtpFechaFinal.Location = new Point(838, 317);
			dtpFechaFinal.Name = "dtpFechaFinal";
			dtpFechaFinal.Size = new Size(110, 25);
			dtpFechaFinal.TabIndex = 14;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(670, 297);
			label7.Name = "label7";
			label7.Size = new Size(84, 17);
			label7.TabIndex = 13;
			label7.Text = "Fecha Inicial:";
			// 
			// dtpFechaInicial
			// 
			dtpFechaInicial.CustomFormat = "dd/MM/yyyy";
			dtpFechaInicial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dtpFechaInicial.Format = DateTimePickerFormat.Custom;
			dtpFechaInicial.Location = new Point(670, 317);
			dtpFechaInicial.Name = "dtpFechaInicial";
			dtpFechaInicial.Size = new Size(110, 25);
			dtpFechaInicial.TabIndex = 12;
			dtpFechaInicial.ValueChanged += dtpFechaInicial_ValueChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(15, 259);
			label6.Name = "label6";
			label6.Size = new Size(199, 25);
			label6.TabIndex = 11;
			label6.Text = "Consulta por Semana ";
			// 
			// panel1
			// 
			panel1.BackColor = Color.DimGray;
			panel1.Location = new Point(15, 232);
			panel1.Name = "panel1";
			panel1.Size = new Size(1239, 1);
			panel1.TabIndex = 10;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(10, 297);
			label5.Name = "label5";
			label5.Size = new Size(59, 17);
			label5.TabIndex = 9;
			label5.Text = "Semana:";
			// 
			// cboSemana
			// 
			cboSemana.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(10, 317);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(338, 25);
			cboSemana.TabIndex = 8;
			// 
			// btnConsultar
			// 
			btnConsultar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
			btnConsultar.ImageAlign = ContentAlignment.MiddleLeft;
			btnConsultar.Location = new Point(982, 312);
			btnConsultar.Name = "btnConsultar";
			btnConsultar.Padding = new Padding(20, 0, 20, 0);
			btnConsultar.Size = new Size(152, 33);
			btnConsultar.TabIndex = 7;
			btnConsultar.Text = "Consultar";
			btnConsultar.TextAlign = ContentAlignment.MiddleRight;
			btnConsultar.UseVisualStyleBackColor = true;
			btnConsultar.Click += btnConsultar_Click;
			// 
			// txbCodigo
			// 
			txbCodigo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			txbCodigo.Location = new Point(141, 62);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(116, 27);
			txbCodigo.TabIndex = 3;
			txbCodigo.KeyDown += txbCodigo_KeyDown;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(15, 72);
			label2.Name = "label2";
			label2.Size = new Size(54, 17);
			label2.TabIndex = 2;
			label2.Text = "Codigo:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			txbEmpleado.Location = new Point(141, 100);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.ReadOnly = true;
			txbEmpleado.Size = new Size(289, 27);
			txbEmpleado.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(15, 110);
			label1.Name = "label1";
			label1.Size = new Size(71, 17);
			label1.TabIndex = 0;
			label1.Text = "Empleado:";
			// 
			// panel2
			// 
			panel2.BackColor = Color.FromArgb(35, 103, 149);
			panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
			panel2.BackgroundImageLayout = ImageLayout.Stretch;
			panel2.Controls.Add(pictureBox1);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(label4);
			panel2.Location = new Point(2, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(1271, 133);
			panel2.TabIndex = 7;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.Transparent;
			label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.White;
			label3.Location = new Point(100, 64);
			label3.Name = "label3";
			label3.Size = new Size(1043, 17);
			label3.TabIndex = 9;
			label3.Text = "Consulta los registros de entrada y salida de cada empleado, seleccionando una fecha específica y buscando por su código o nombre para revisar sus horarios de checada.";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.Transparent;
			label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.White;
			label4.Location = new Point(100, 27);
			label4.Name = "label4";
			label4.Size = new Size(579, 37);
			label4.TabIndex = 8;
			label4.Text = "Consulta de Asistencia en el Reloj Checador ";
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.Transparent;
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(11, 10);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(83, 107);
			pictureBox1.TabIndex = 10;
			pictureBox1.TabStop = false;
			// 
			// FrmReloj
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(244, 247, 251);
			ClientSize = new Size(1518, 1177);
			Controls.Add(panel2);
			Controls.Add(groupBox1);
			Controls.Add(dgvLista);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmReloj";
			Text = "Reloj Checador";
			Load += FrmReloj_Load;
			((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		public DataGridView dgvLista;
		private GroupBox groupBox1;
		private Label label1;
		private Label label3;
		private Label label2;
		private Button btnConsultar;
		private Panel panel2;
		private Label label4;
		private Label label6;
		private Panel panel1;
		private Label label5;
		private Label label9;
		public Label label8;
		private DateTimePicker dtpFechaFinal;
		public Label label7;
		private DateTimePicker dtpFechaInicial;
		public ComboBox cboSemana;
		private Button btnConsultarSemana;
		public TextBox txbEmpleado;
		public TextBox txbCodigo;
		public Button btnBuscar;
		private Button btnLimpiar;
		public TextBox txbLugardePago;
		public TextBox txbCuadrilla;
		private Label label11;
		private Label label10;
		private Label label12;
		private Label label14;
		private Label label13;
		private Label label15;
		private PictureBox pictureBox1;
	}
}
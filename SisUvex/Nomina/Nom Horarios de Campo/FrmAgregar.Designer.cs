namespace SisUvex.Nomina.Nom_Horarios_de_Campo
{
	partial class FrmAgregar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregar));
			clbCuadrilla = new CheckedListBox();
			lblTitle = new Label();
			groupBox1 = new GroupBox();
			chkSeleccionarTodas = new CheckBox();
			groupBox2 = new GroupBox();
			label6 = new Label();
			chkCruce = new CheckBox();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			dtpSalida = new DateTimePicker();
			dtpEntrada = new DateTimePicker();
			dtpFechaFin = new DateTimePicker();
			dtpFechaInicio = new DateTimePicker();
			btnGuardar = new Button();
			btnCancelar = new Button();
			pictureBox1 = new PictureBox();
			lblSubtitulo = new Label();
			panel1 = new Panel();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// clbCuadrilla
			// 
			clbCuadrilla.CheckOnClick = true;
			clbCuadrilla.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			clbCuadrilla.ForeColor = SystemColors.ActiveCaptionText;
			clbCuadrilla.FormattingEnabled = true;
			clbCuadrilla.Location = new Point(6, 29);
			clbCuadrilla.Name = "clbCuadrilla";
			clbCuadrilla.Size = new Size(274, 202);
			clbCuadrilla.TabIndex = 155;
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitle.Location = new Point(83, 9);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(160, 25);
			lblTitle.TabIndex = 156;
			lblTitle.Text = "Agregar Horario";
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			groupBox1.Controls.Add(chkSeleccionarTodas);
			groupBox1.Controls.Add(clbCuadrilla);
			groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(12, 83);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(289, 268);
			groupBox1.TabIndex = 157;
			groupBox1.TabStop = false;
			groupBox1.Text = "Selecciona una Cuadrilla";
			// 
			// chkSeleccionarTodas
			// 
			chkSeleccionarTodas.AutoSize = true;
			chkSeleccionarTodas.Location = new Point(6, 239);
			chkSeleccionarTodas.Name = "chkSeleccionarTodas";
			chkSeleccionarTodas.Size = new Size(133, 21);
			chkSeleccionarTodas.TabIndex = 10;
			chkSeleccionarTodas.Text = "Seleccionar Todas";
			chkSeleccionarTodas.UseVisualStyleBackColor = true;
			chkSeleccionarTodas.CheckedChanged += chkSeleccionarTodas_CheckedChanged;
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(chkCruce);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(label2);
			groupBox2.Controls.Add(dtpSalida);
			groupBox2.Controls.Add(dtpEntrada);
			groupBox2.Controls.Add(dtpFechaFin);
			groupBox2.Controls.Add(dtpFechaInicio);
			groupBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupBox2.Location = new Point(307, 83);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(482, 226);
			groupBox2.TabIndex = 158;
			groupBox2.TabStop = false;
			groupBox2.Text = "Definir Horario";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(319, 136);
			label6.Name = "label6";
			label6.Size = new Size(106, 13);
			label6.TabIndex = 9;
			label6.Text = "Cruza medianoche:";
			// 
			// chkCruce
			// 
			chkCruce.AutoSize = true;
			chkCruce.Location = new Point(324, 158);
			chkCruce.Name = "chkCruce";
			chkCruce.Size = new Size(37, 21);
			chkCruce.TabIndex = 8;
			chkCruce.Text = "Si";
			chkCruce.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(166, 136);
			label5.Name = "label5";
			label5.Size = new Size(72, 13);
			label5.TabIndex = 7;
			label5.Text = "Hora Salida :";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(6, 136);
			label4.Name = "label4";
			label4.Size = new Size(81, 13);
			label4.TabIndex = 6;
			label4.Text = "Hora Entrada :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(275, 47);
			label3.Name = "label3";
			label3.Size = new Size(85, 13);
			label3.TabIndex = 5;
			label3.Text = "Fecha de final :";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(6, 47);
			label2.Name = "label2";
			label2.Size = new Size(90, 13);
			label2.TabIndex = 4;
			label2.Text = "Fecha de Inicio :";
			// 
			// dtpSalida
			// 
			dtpSalida.CustomFormat = "HH:mm";
			dtpSalida.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dtpSalida.Format = DateTimePickerFormat.Custom;
			dtpSalida.Location = new Point(166, 155);
			dtpSalida.Name = "dtpSalida";
			dtpSalida.ShowUpDown = true;
			dtpSalida.Size = new Size(90, 23);
			dtpSalida.TabIndex = 3;
			// 
			// dtpEntrada
			// 
			dtpEntrada.CustomFormat = "HH:mm";
			dtpEntrada.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dtpEntrada.Format = DateTimePickerFormat.Custom;
			dtpEntrada.Location = new Point(6, 155);
			dtpEntrada.Name = "dtpEntrada";
			dtpEntrada.ShowUpDown = true;
			dtpEntrada.Size = new Size(90, 23);
			dtpEntrada.TabIndex = 2;
			// 
			// dtpFechaFin
			// 
			dtpFechaFin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dtpFechaFin.Format = DateTimePickerFormat.Custom;
			dtpFechaFin.Location = new Point(275, 63);
			dtpFechaFin.Name = "dtpFechaFin";
			dtpFechaFin.ShowCheckBox = true;
			dtpFechaFin.Size = new Size(196, 23);
			dtpFechaFin.TabIndex = 1;
			// 
			// dtpFechaInicio
			// 
			dtpFechaInicio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dtpFechaInicio.Format = DateTimePickerFormat.Custom;
			dtpFechaInicio.Location = new Point(6, 63);
			dtpFechaInicio.Name = "dtpFechaInicio";
			dtpFechaInicio.Size = new Size(196, 23);
			dtpFechaInicio.TabIndex = 0;
			// 
			// btnGuardar
			// 
			btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
			btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
			btnGuardar.Location = new Point(436, 322);
			btnGuardar.Name = "btnGuardar";
			btnGuardar.Padding = new Padding(35, 0, 35, 0);
			btnGuardar.Size = new Size(173, 26);
			btnGuardar.TabIndex = 10;
			btnGuardar.Text = "Guardar";
			btnGuardar.TextAlign = ContentAlignment.MiddleRight;
			btnGuardar.UseVisualStyleBackColor = true;
			btnGuardar.Click += btnGuardar_Click;
			// 
			// btnCancelar
			// 
			btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
			btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancelar.Location = new Point(615, 322);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Padding = new Padding(35, 0, 35, 0);
			btnCancelar.Size = new Size(173, 26);
			btnCancelar.TabIndex = 159;
			btnCancelar.Text = "Cancelar";
			btnCancelar.TextAlign = ContentAlignment.MiddleRight;
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(12, 9);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(52, 52);
			pictureBox1.TabIndex = 160;
			pictureBox1.TabStop = false;
			// 
			// lblSubtitulo
			// 
			lblSubtitulo.AutoSize = true;
			lblSubtitulo.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
			lblSubtitulo.ForeColor = Color.DimGray;
			lblSubtitulo.Location = new Point(83, 42);
			lblSubtitulo.Name = "lblSubtitulo";
			lblSubtitulo.Size = new Size(286, 15);
			lblSubtitulo.TabIndex = 161;
			lblSubtitulo.Text = "Define el horario y asígnalo a una o varias cuadrillas.";
			// 
			// panel1
			// 
			panel1.BackColor = Color.DimGray;
			panel1.Location = new Point(12, 72);
			panel1.Name = "panel1";
			panel1.Size = new Size(776, 2);
			panel1.TabIndex = 162;
			// 
			// FrmAgregar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(801, 363);
			Controls.Add(panel1);
			Controls.Add(lblSubtitulo);
			Controls.Add(pictureBox1);
			Controls.Add(btnCancelar);
			Controls.Add(btnGuardar);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(lblTitle);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAgregar";
			Text = "Agregar Horario";
			Load += FrmAgregar_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public CheckedListBox clbCuadrilla;
		private Label label1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Label label3;
		private Label label2;
		private Label label5;
		private Label label4;
		private Label label6;
		public Button btnGuardar;
		private Button btnCancelar;
		private PictureBox pictureBox1;
		private Label label7;
		private Panel panel1;
		public Label lblTitle;
		public DateTimePicker dtpFechaInicio;
		public Label lblSubtitulo;
		public CheckBox chkCruce;
		public DateTimePicker dtpSalida;
		public DateTimePicker dtpEntrada;
		public DateTimePicker dtpFechaFin;
		public CheckBox chkSeleccionarTodas;
	}
}
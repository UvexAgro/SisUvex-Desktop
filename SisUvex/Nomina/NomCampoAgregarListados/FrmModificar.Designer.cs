namespace SisUvex.Nomina.NomCampoAgregarListados
{
	partial class FrmModificar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificar));
			panel1 = new Panel();
			label1 = new Label();
			groupBox1 = new GroupBox();
			dtpFinal = new DateTimePicker();
			dtpInicio = new DateTimePicker();
			txbCuadrilla = new TextBox();
			txbSemana = new TextBox();
			txbCodigo = new TextBox();
			txbEmpleado = new TextBox();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			tlpSemana = new TableLayoutPanel();
			panel2 = new Panel();
			label8 = new Label();
			btnCancelar = new Button();
			btnContinuar = new Button();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.BackColor = Color.FromArgb(236, 243, 249);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(1369, 28);
			panel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(3, 7);
			label1.Name = "label1";
			label1.Size = new Size(167, 17);
			label1.TabIndex = 0;
			label1.Text = "Informacion del Empleado";
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.BackColor = Color.FromArgb(236, 243, 249);
			groupBox1.Controls.Add(dtpFinal);
			groupBox1.Controls.Add(dtpInicio);
			groupBox1.Controls.Add(txbCuadrilla);
			groupBox1.Controls.Add(txbSemana);
			groupBox1.Controls.Add(txbCodigo);
			groupBox1.Controls.Add(txbEmpleado);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new Point(3, 33);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(1369, 100);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			// 
			// dtpFinal
			// 
			dtpFinal.Format = DateTimePickerFormat.Custom;
			dtpFinal.Location = new Point(440, 59);
			dtpFinal.Name = "dtpFinal";
			dtpFinal.Size = new Size(84, 23);
			dtpFinal.TabIndex = 18;
			// 
			// dtpInicio
			// 
			dtpInicio.CustomFormat = "";
			dtpInicio.Format = DateTimePickerFormat.Custom;
			dtpInicio.Location = new Point(262, 59);
			dtpInicio.Name = "dtpInicio";
			dtpInicio.Size = new Size(84, 23);
			dtpInicio.TabIndex = 17;
			// 
			// txbCuadrilla
			// 
			txbCuadrilla.Location = new Point(638, 57);
			txbCuadrilla.Name = "txbCuadrilla";
			txbCuadrilla.Size = new Size(170, 23);
			txbCuadrilla.TabIndex = 8;
			// 
			// txbSemana
			// 
			txbSemana.Location = new Point(72, 57);
			txbSemana.Name = "txbSemana";
			txbSemana.Size = new Size(65, 23);
			txbSemana.TabIndex = 7;
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(72, 18);
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(83, 23);
			txbCodigo.TabIndex = 6;
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(293, 18);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(339, 23);
			txbEmpleado.TabIndex = 5;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(569, 63);
			label7.Name = "label7";
			label7.Size = new Size(63, 17);
			label7.TabIndex = 4;
			label7.Text = "Cuadrilla:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(405, 63);
			label6.Name = "label6";
			label6.Size = new Size(29, 17);
			label6.TabIndex = 3;
			label6.Text = "Fin:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(213, 63);
			label5.Name = "label5";
			label5.Size = new Size(43, 17);
			label5.TabIndex = 2;
			label5.Text = "Inicio:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(213, 24);
			label4.Name = "label4";
			label4.Size = new Size(71, 17);
			label4.TabIndex = 2;
			label4.Text = "Empleado:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(12, 63);
			label3.Name = "label3";
			label3.Size = new Size(59, 17);
			label3.TabIndex = 1;
			label3.Text = "Semana:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(12, 24);
			label2.Name = "label2";
			label2.Size = new Size(54, 17);
			label2.TabIndex = 0;
			label2.Text = "Codigo:";
			// 
			// tlpSemana
			// 
			tlpSemana.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tlpSemana.ColumnCount = 8;
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tlpSemana.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tlpSemana.Location = new Point(3, 167);
			tlpSemana.Name = "tlpSemana";
			tlpSemana.RowCount = 3;
			tlpSemana.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tlpSemana.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tlpSemana.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
			tlpSemana.Size = new Size(1369, 150);
			tlpSemana.TabIndex = 2;
			// 
			// panel2
			// 
			panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel2.BackColor = Color.FromArgb(236, 243, 249);
			panel2.Controls.Add(label8);
			panel2.Location = new Point(3, 136);
			panel2.Name = "panel2";
			panel2.Size = new Size(1369, 28);
			panel2.TabIndex = 1;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(3, 7);
			label8.Name = "label8";
			label8.Size = new Size(204, 17);
			label8.TabIndex = 0;
			label8.Text = "Actidades, variedd y lote por dia";
			// 
			// btnCancelar
			// 
			btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCancelar.BackgroundImageLayout = ImageLayout.Zoom;
			btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
			btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancelar.Location = new Point(1103, 342);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Padding = new Padding(10, 0, 10, 0);
			btnCancelar.Size = new Size(110, 27);
			btnCancelar.TabIndex = 45;
			btnCancelar.Text = "Cancelar";
			btnCancelar.TextAlign = ContentAlignment.MiddleRight;
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// btnContinuar
			// 
			btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnContinuar.Image = (Image)resources.GetObject("btnContinuar.Image");
			btnContinuar.ImageAlign = ContentAlignment.MiddleLeft;
			btnContinuar.Location = new Point(1253, 342);
			btnContinuar.Name = "btnContinuar";
			btnContinuar.Padding = new Padding(6, 0, 6, 0);
			btnContinuar.Size = new Size(110, 27);
			btnContinuar.TabIndex = 44;
			btnContinuar.Text = "Continuar";
			btnContinuar.TextAlign = ContentAlignment.MiddleRight;
			btnContinuar.UseVisualStyleBackColor = true;
			btnContinuar.Click += btnContinuar_Click;
			// 
			// FrmModificar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(244, 247, 251);
			ClientSize = new Size(1375, 381);
			Controls.Add(btnCancelar);
			Controls.Add(btnContinuar);
			Controls.Add(panel2);
			Controls.Add(tlpSemana);
			Controls.Add(groupBox1);
			Controls.Add(panel1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmModificar";
			Text = "Modificar Lote y Actividad";
			Load += FrmModificar_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label1;
		private GroupBox groupBox1;
		private TextBox txbCuadrilla;
		private TextBox txbSemana;
		public TextBox txbCodigo;
		public TextBox txbEmpleado;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		public DateTimePicker dtpInicio;
		public DateTimePicker dtpFinal;
		public TableLayoutPanel tlpSemana;
		private Panel panel2;
		private Label label8;
		public Button btnCancelar;
		public Button btnContinuar;
	}
}
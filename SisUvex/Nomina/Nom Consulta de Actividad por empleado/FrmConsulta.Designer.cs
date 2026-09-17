namespace SisUvex.Nomina.Nom_Consulta_de_Actividad_por_empleado
{
	partial class FrmConsulta
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsulta));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			panel1 = new Panel();
			label2 = new Label();
			pictureBox1 = new PictureBox();
			label1 = new Label();
			panel2 = new Panel();
			dtpFinal = new DateTimePicker();
			dtpInicio = new DateTimePicker();
			label14 = new Label();
			label13 = new Label();
			cboSemana = new ComboBox();
			label6 = new Label();
			panel3 = new Panel();
			label3 = new Label();
			panel4 = new Panel();
			btnBuscar = new Button();
			lblLugardePago = new Label();
			lblNombre = new Label();
			lblCodigo = new Label();
			label9 = new Label();
			label7 = new Label();
			label5 = new Label();
			txbCodigo = new TextBox();
			label8 = new Label();
			panel5 = new Panel();
			label4 = new Label();
			dgvNomina = new DataGridView();
			btnConsultar = new Button();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvNomina).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.BackColor = Color.FromArgb(35, 103, 149);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(1, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(1168, 113);
			panel1.TabIndex = 6;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = SystemColors.ControlLightLight;
			label2.Location = new Point(144, 73);
			label2.Name = "label2";
			label2.Size = new Size(406, 25);
			label2.TabIndex = 2;
			label2.Text = "Consulta de actividad registrada por empleado";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(33, 16);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(87, 82);
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = SystemColors.ControlLightLight;
			label1.Location = new Point(144, 16);
			label1.Name = "label1";
			label1.Size = new Size(672, 45);
			label1.TabIndex = 0;
			label1.Text = "CONSULTA DE ACTIVIDAD POR EMPLEADO";
			// 
			// panel2
			// 
			panel2.BackColor = Color.FromArgb(236, 243, 249);
			panel2.Controls.Add(dtpFinal);
			panel2.Controls.Add(dtpInicio);
			panel2.Controls.Add(label14);
			panel2.Controls.Add(label13);
			panel2.Controls.Add(cboSemana);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(panel3);
			panel2.Location = new Point(1, 133);
			panel2.Name = "panel2";
			panel2.Size = new Size(1168, 108);
			panel2.TabIndex = 7;
			// 
			// dtpFinal
			// 
			dtpFinal.Format = DateTimePickerFormat.Custom;
			dtpFinal.Location = new Point(498, 65);
			dtpFinal.Name = "dtpFinal";
			dtpFinal.Size = new Size(84, 23);
			dtpFinal.TabIndex = 17;
			// 
			// dtpInicio
			// 
			dtpInicio.CustomFormat = "";
			dtpInicio.Format = DateTimePickerFormat.Custom;
			dtpInicio.Location = new Point(323, 65);
			dtpInicio.Name = "dtpInicio";
			dtpInicio.Size = new Size(84, 23);
			dtpInicio.TabIndex = 16;
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label14.ForeColor = Color.FromArgb(31, 95, 145);
			label14.Location = new Point(465, 68);
			label14.Name = "label14";
			label14.Size = new Size(27, 17);
			label14.TabIndex = 15;
			label14.Text = "Al :";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label13.ForeColor = Color.FromArgb(31, 95, 145);
			label13.Location = new Point(283, 68);
			label13.Name = "label13";
			label13.Size = new Size(34, 17);
			label13.TabIndex = 14;
			label13.Text = "Del :";
			// 
			// cboSemana
			// 
			cboSemana.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(132, 65);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(78, 25);
			cboSemana.TabIndex = 13;
			cboSemana.SelectedIndexChanged += cboSemana_SelectedIndexChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(31, 95, 145);
			label6.Location = new Point(51, 68);
			label6.Name = "label6";
			label6.Size = new Size(63, 17);
			label6.TabIndex = 12;
			label6.Text = "Semana :";
			// 
			// panel3
			// 
			panel3.BackColor = Color.FromArgb(225, 239, 250);
			panel3.Controls.Add(label3);
			panel3.Location = new Point(3, 3);
			panel3.Name = "panel3";
			panel3.Size = new Size(1162, 39);
			panel3.TabIndex = 8;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(31, 95, 145);
			label3.Location = new Point(8, 7);
			label3.Name = "label3";
			label3.Size = new Size(82, 25);
			label3.TabIndex = 0;
			label3.Text = "Periodo";
			// 
			// panel4
			// 
			panel4.BackColor = Color.FromArgb(236, 243, 249);
			panel4.Controls.Add(btnBuscar);
			panel4.Controls.Add(lblLugardePago);
			panel4.Controls.Add(lblNombre);
			panel4.Controls.Add(lblCodigo);
			panel4.Controls.Add(label9);
			panel4.Controls.Add(label7);
			panel4.Controls.Add(label5);
			panel4.Controls.Add(txbCodigo);
			panel4.Controls.Add(label8);
			panel4.Controls.Add(panel5);
			panel4.Location = new Point(1, 247);
			panel4.Name = "panel4";
			panel4.Size = new Size(1168, 200);
			panel4.TabIndex = 9;
			// 
			// btnBuscar
			// 
			btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
			btnBuscar.Font = new Font("Segoe UI", 14F);
			btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
			btnBuscar.Location = new Point(246, 62);
			btnBuscar.Name = "btnBuscar";
			btnBuscar.Size = new Size(28, 23);
			btnBuscar.TabIndex = 37;
			btnBuscar.TextAlign = ContentAlignment.MiddleRight;
			btnBuscar.UseVisualStyleBackColor = true;
			btnBuscar.Click += btnBuscar_Click;
			// 
			// lblLugardePago
			// 
			lblLugardePago.AutoSize = true;
			lblLugardePago.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblLugardePago.Location = new Point(140, 170);
			lblLugardePago.Name = "lblLugardePago";
			lblLugardePago.Size = new Size(13, 17);
			lblLugardePago.TabIndex = 19;
			lblLugardePago.Text = "-";
			// 
			// lblNombre
			// 
			lblNombre.AutoSize = true;
			lblNombre.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblNombre.Location = new Point(140, 138);
			lblNombre.Name = "lblNombre";
			lblNombre.Size = new Size(13, 17);
			lblNombre.TabIndex = 18;
			lblNombre.Text = "-";
			// 
			// lblCodigo
			// 
			lblCodigo.AutoSize = true;
			lblCodigo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCodigo.Location = new Point(140, 107);
			lblCodigo.Name = "lblCodigo";
			lblCodigo.Size = new Size(13, 17);
			lblCodigo.TabIndex = 17;
			lblCodigo.Text = "-";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.FromArgb(31, 95, 145);
			label9.Location = new Point(11, 168);
			label9.Name = "label9";
			label9.Size = new Size(103, 17);
			label9.TabIndex = 16;
			label9.Text = "Lugar de Pago :";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.FromArgb(31, 95, 145);
			label7.Location = new Point(11, 136);
			label7.Name = "label7";
			label7.Size = new Size(65, 17);
			label7.TabIndex = 15;
			label7.Text = "Nombre :";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.FromArgb(31, 95, 145);
			label5.Location = new Point(11, 105);
			label5.Name = "label5";
			label5.Size = new Size(58, 17);
			label5.TabIndex = 14;
			label5.Text = "Codigo :";
			// 
			// txbCodigo
			// 
			txbCodigo.Location = new Point(140, 61);
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(100, 23);
			txbCodigo.TabIndex = 13;
			txbCodigo.KeyDown += txbCodigo_KeyDown;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.ForeColor = Color.FromArgb(31, 95, 145);
			label8.Location = new Point(11, 67);
			label8.Name = "label8";
			label8.Size = new Size(58, 17);
			label8.TabIndex = 12;
			label8.Text = "Codigo :";
			// 
			// panel5
			// 
			panel5.BackColor = Color.FromArgb(225, 239, 250);
			panel5.Controls.Add(label4);
			panel5.Location = new Point(3, 3);
			panel5.Name = "panel5";
			panel5.Size = new Size(1162, 39);
			panel5.TabIndex = 8;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(31, 95, 145);
			label4.Location = new Point(8, 7);
			label4.Name = "label4";
			label4.Size = new Size(188, 25);
			label4.TabIndex = 0;
			label4.Text = "Datos del Empleado";
			// 
			// dgvNomina
			// 
			dgvNomina.AllowUserToAddRows = false;
			dgvNomina.AllowUserToDeleteRows = false;
			dgvNomina.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvNomina.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvNomina.BackgroundColor = SystemColors.ControlLightLight;
			dgvNomina.BorderStyle = BorderStyle.Fixed3D;
			dgvNomina.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvNomina.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvNomina.ColumnHeadersHeight = 29;
			dgvNomina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvNomina.EnableHeadersVisualStyles = false;
			dgvNomina.ImeMode = ImeMode.NoControl;
			dgvNomina.Location = new Point(4, 478);
			dgvNomina.Name = "dgvNomina";
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvNomina.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvNomina.RowHeadersVisible = false;
			dgvNomina.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvNomina.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvNomina.Size = new Size(1162, 404);
			dgvNomina.TabIndex = 10;
			// 
			// btnConsultar
			// 
			btnConsultar.BackColor = Color.White;
			btnConsultar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnConsultar.ForeColor = Color.Black;
			btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
			btnConsultar.ImageAlign = ContentAlignment.MiddleLeft;
			btnConsultar.Location = new Point(994, 902);
			btnConsultar.Name = "btnConsultar";
			btnConsultar.Padding = new Padding(40, 0, 40, 0);
			btnConsultar.Size = new Size(165, 40);
			btnConsultar.TabIndex = 11;
			btnConsultar.Text = "Salir";
			btnConsultar.TextAlign = ContentAlignment.MiddleRight;
			btnConsultar.UseVisualStyleBackColor = false;
			btnConsultar.Click += btnConsultar_Click;
			// 
			// FrmConsulta
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(244, 247, 251);
			ClientSize = new Size(1171, 954);
			Controls.Add(btnConsultar);
			Controls.Add(dgvNomina);
			Controls.Add(panel4);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmConsulta";
			Text = "Consulta de Actividades por Empleado";
			Load += FrmConsulta_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvNomina).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private Panel panel1;
		private Label label2;
		private PictureBox pictureBox1;
		private Label label1;
		private Panel panel2;
		private Panel panel3;
		private Label label3;
		private Panel panel4;
		private Panel panel5;
		private Label label4;
		public ComboBox cboSemana;
		private Label label6;
		public TextBox txbCodigo;
		private Label label8;
		private Label label9;
		private Label label7;
		private Label label5;
		private Label label12;
		private Label label11;
		private Label label10;
		public DataGridView dgvNomina;
		private Label label13;
		private Label label14;
		public Label lblLugardePago;
		public Label lblCodigo;
		public DateTimePicker dtpInicio;
		public DateTimePicker dtpFinal;
		private Button btnConsultar;
		public Button btnBuscar;
		public Label lblNombre;
	}
}
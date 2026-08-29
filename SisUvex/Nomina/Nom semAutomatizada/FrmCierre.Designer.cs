namespace SisUvex.Nomina.Nom_semAutomatizada
{
	partial class FrmCierre
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCierre));
			btnCerrar = new Button();
			button2 = new Button();
			pbColor = new PictureBox();
			lblUsuario = new Label();
			lblEstado = new Label();
			lblPeriodo = new Label();
			lblSemana = new Label();
			lblTipoNomina = new Label();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			label11 = new Label();
			lblMensaje = new Label();
			lblTitulo = new Label();
			label2 = new Label();
			pnlLinea = new Panel();
			gbInformacion = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			panel1 = new Panel();
			pnlAviso = new Panel();
			pbAviso = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pbColor).BeginInit();
			gbInformacion.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			pnlAviso.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbAviso).BeginInit();
			SuspendLayout();
			// 
			// btnCerrar
			// 
			btnCerrar.BackColor = SystemColors.Control;
			btnCerrar.BackgroundImageLayout = ImageLayout.Zoom;
			btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCerrar.ForeColor = SystemColors.ActiveCaptionText;
			btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
			btnCerrar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCerrar.Location = new Point(120, 350);
			btnCerrar.Name = "btnCerrar";
			btnCerrar.Padding = new Padding(10, 0, 10, 0);
			btnCerrar.Size = new Size(182, 32);
			btnCerrar.TabIndex = 10;
			btnCerrar.Text = "Cerrar Semana";
			btnCerrar.TextAlign = ContentAlignment.MiddleRight;
			btnCerrar.UseVisualStyleBackColor = false;
			btnCerrar.Click += btnCerrar_Click;
			// 
			// button2
			// 
			button2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			button2.Image = (Image)resources.GetObject("button2.Image");
			button2.ImageAlign = ContentAlignment.MiddleLeft;
			button2.Location = new Point(120, 388);
			button2.Name = "button2";
			button2.Padding = new Padding(10, 0, 40, 0);
			button2.Size = new Size(182, 29);
			button2.TabIndex = 11;
			button2.Text = "Cancelar";
			button2.TextAlign = ContentAlignment.MiddleRight;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// pbColor
			// 
			pbColor.BackgroundImageLayout = ImageLayout.Zoom;
			pbColor.Location = new Point(73, 5);
			pbColor.Name = "pbColor";
			pbColor.Size = new Size(21, 21);
			pbColor.TabIndex = 17;
			pbColor.TabStop = false;
			// 
			// lblUsuario
			// 
			lblUsuario.AutoSize = true;
			lblUsuario.Dock = DockStyle.Fill;
			lblUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblUsuario.Location = new Point(177, 137);
			lblUsuario.Name = "lblUsuario";
			lblUsuario.Size = new Size(210, 35);
			lblUsuario.TabIndex = 16;
			lblUsuario.Text = "Usuario";
			lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblEstado
			// 
			lblEstado.AutoSize = true;
			lblEstado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEstado.Location = new Point(90, 2);
			lblEstado.Name = "lblEstado";
			lblEstado.Size = new Size(59, 21);
			lblEstado.TabIndex = 15;
			lblEstado.Text = "Estado";
			lblEstado.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblPeriodo
			// 
			lblPeriodo.AutoSize = true;
			lblPeriodo.Dock = DockStyle.Fill;
			lblPeriodo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblPeriodo.Location = new Point(177, 69);
			lblPeriodo.Name = "lblPeriodo";
			lblPeriodo.Size = new Size(210, 33);
			lblPeriodo.TabIndex = 14;
			lblPeriodo.Tag = "";
			lblPeriodo.Text = "periodo";
			lblPeriodo.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblSemana
			// 
			lblSemana.AutoSize = true;
			lblSemana.Dock = DockStyle.Fill;
			lblSemana.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSemana.Location = new Point(177, 35);
			lblSemana.Name = "lblSemana";
			lblSemana.Size = new Size(210, 33);
			lblSemana.TabIndex = 13;
			lblSemana.Text = "semana";
			lblSemana.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblTipoNomina
			// 
			lblTipoNomina.AutoSize = true;
			lblTipoNomina.Dock = DockStyle.Fill;
			lblTipoNomina.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTipoNomina.Location = new Point(177, 1);
			lblTipoNomina.Name = "lblTipoNomina";
			lblTipoNomina.Size = new Size(210, 33);
			lblTipoNomina.TabIndex = 12;
			lblTipoNomina.Text = "tipo de nomina ";
			lblTipoNomina.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			label7.Anchor = AnchorStyles.Left;
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.DimGray;
			label7.Location = new Point(4, 147);
			label7.Name = "label7";
			label7.Size = new Size(53, 15);
			label7.TabIndex = 11;
			label7.Text = "Usuario :";
			label7.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			label8.Anchor = AnchorStyles.Left;
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label8.ForeColor = Color.DimGray;
			label8.Location = new Point(4, 112);
			label8.Name = "label8";
			label8.Size = new Size(48, 15);
			label8.TabIndex = 10;
			label8.Text = "Estado :";
			label8.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			label9.Anchor = AnchorStyles.Left;
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.DimGray;
			label9.Location = new Point(4, 78);
			label9.Name = "label9";
			label9.Size = new Size(54, 15);
			label9.TabIndex = 9;
			label9.Text = "Periodo :";
			label9.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			label10.Anchor = AnchorStyles.Left;
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label10.ForeColor = Color.DimGray;
			label10.Location = new Point(4, 44);
			label10.Name = "label10";
			label10.Size = new Size(55, 15);
			label10.TabIndex = 8;
			label10.Text = "Semana :";
			label10.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			label11.Anchor = AnchorStyles.Left;
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label11.ForeColor = Color.DimGray;
			label11.Location = new Point(4, 10);
			label11.Name = "label11";
			label11.Size = new Size(99, 15);
			label11.TabIndex = 7;
			label11.Text = "Tipo de Nomina :";
			label11.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblMensaje
			// 
			lblMensaje.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblMensaje.ForeColor = Color.FromArgb(60, 60, 60);
			lblMensaje.Location = new Point(62, 3);
			lblMensaje.Name = "lblMensaje";
			lblMensaje.Size = new Size(324, 45);
			lblMensaje.TabIndex = 12;
			lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitulo.ForeColor = Color.DarkGreen;
			lblTitulo.Location = new Point(121, 9);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(181, 30);
			lblTitulo.TabIndex = 14;
			lblTitulo.Text = "CERRAR SEMANA";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = Color.DimGray;
			label2.Location = new Point(112, 39);
			label2.Name = "label2";
			label2.Size = new Size(206, 15);
			label2.TabIndex = 15;
			label2.Text = "Confirmación del período de nómina ";
			// 
			// pnlLinea
			// 
			pnlLinea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			pnlLinea.BackColor = Color.ForestGreen;
			pnlLinea.Location = new Point(2, 65);
			pnlLinea.Name = "pnlLinea";
			pnlLinea.Size = new Size(411, 2);
			pnlLinea.TabIndex = 16;
			// 
			// gbInformacion
			// 
			gbInformacion.Controls.Add(tableLayoutPanel1);
			gbInformacion.Location = new Point(12, 86);
			gbInformacion.Name = "gbInformacion";
			gbInformacion.Size = new Size(397, 195);
			gbInformacion.TabIndex = 17;
			gbInformacion.TabStop = false;
			gbInformacion.Text = "INFORMACIÓN DEL CIERRE";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.44444F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.5555573F));
			tableLayoutPanel1.Controls.Add(lblUsuario, 1, 4);
			tableLayoutPanel1.Controls.Add(lblTipoNomina, 1, 0);
			tableLayoutPanel1.Controls.Add(label11, 0, 0);
			tableLayoutPanel1.Controls.Add(label10, 0, 1);
			tableLayoutPanel1.Controls.Add(lblPeriodo, 1, 2);
			tableLayoutPanel1.Controls.Add(label9, 0, 2);
			tableLayoutPanel1.Controls.Add(panel1, 1, 3);
			tableLayoutPanel1.Controls.Add(lblSemana, 1, 1);
			tableLayoutPanel1.Controls.Add(label8, 0, 3);
			tableLayoutPanel1.Controls.Add(label7, 0, 4);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(3, 19);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.Size = new Size(391, 173);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.Controls.Add(pbColor);
			panel1.Controls.Add(lblEstado);
			panel1.Location = new Point(177, 106);
			panel1.Name = "panel1";
			panel1.Size = new Size(210, 27);
			panel1.TabIndex = 17;
			// 
			// pnlAviso
			// 
			pnlAviso.BackColor = Color.FromArgb(244, 250, 244);
			pnlAviso.BorderStyle = BorderStyle.FixedSingle;
			pnlAviso.Controls.Add(lblMensaje);
			pnlAviso.Controls.Add(pbAviso);
			pnlAviso.Location = new Point(15, 290);
			pnlAviso.Name = "pnlAviso";
			pnlAviso.Size = new Size(391, 54);
			pnlAviso.TabIndex = 18;
			// 
			// pbAviso
			// 
			pbAviso.BackgroundImageLayout = ImageLayout.Zoom;
			pbAviso.Location = new Point(11, 3);
			pbAviso.Name = "pbAviso";
			pbAviso.Size = new Size(45, 45);
			pbAviso.SizeMode = PictureBoxSizeMode.Zoom;
			pbAviso.TabIndex = 0;
			pbAviso.TabStop = false;
			// 
			// FrmCierre
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(415, 432);
			Controls.Add(button2);
			Controls.Add(btnCerrar);
			Controls.Add(pnlAviso);
			Controls.Add(gbInformacion);
			Controls.Add(pnlLinea);
			Controls.Add(label2);
			Controls.Add(lblTitulo);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmCierre";
			Text = "Cierre de Semana ";
			Load += FrmCierre_Load;
			((System.ComponentModel.ISupportInitialize)pbColor).EndInit();
			gbInformacion.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			pnlAviso.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pbAviso).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		public Button btnCerrar;
		public Button button2;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		public Label lblUsuario;
		public Label lblEstado;
		public Label lblTipoNomina;
		public Label lblSemana;
		public Label lblPeriodo;
		public PictureBox pbColor;
		private PictureBox pictureBox1;
		public Label lblMensaje;
		private Label label2;
		private GroupBox gbInformacion;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel1;
		public PictureBox pbAviso;
		public Panel pnlAviso;
		public Panel pnlLinea;
		public Label lblTitulo;
	}
}
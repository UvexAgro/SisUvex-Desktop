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
			label1 = new Label();
			panel1 = new Panel();
			btnCerrar = new Button();
			button2 = new Button();
			groupBox1 = new GroupBox();
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
			groupBox2 = new GroupBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbColor).BeginInit();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(148, 9);
			label1.Name = "label1";
			label1.Size = new Size(138, 25);
			label1.TabIndex = 0;
			label1.Text = "Cerrar Semana";
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveCaption;
			panel1.Location = new Point(2, 44);
			panel1.Name = "panel1";
			panel1.Size = new Size(415, 23);
			panel1.TabIndex = 1;
			// 
			// btnCerrar
			// 
			btnCerrar.BackgroundImageLayout = ImageLayout.Zoom;
			btnCerrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCerrar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCerrar.Location = new Point(139, 19);
			btnCerrar.Name = "btnCerrar";
			btnCerrar.Padding = new Padding(10, 0, 4, 0);
			btnCerrar.Size = new Size(140, 29);
			btnCerrar.TabIndex = 10;
			btnCerrar.Text = "Cerrar Semana";
			btnCerrar.TextAlign = ContentAlignment.MiddleRight;
			btnCerrar.UseVisualStyleBackColor = true;
			btnCerrar.Click += btnCerrar_Click;
			// 
			// button2
			// 
			button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button2.Image = (Image)resources.GetObject("button2.Image");
			button2.ImageAlign = ContentAlignment.MiddleLeft;
			button2.Location = new Point(139, 66);
			button2.Name = "button2";
			button2.Padding = new Padding(10, 0, 20, 0);
			button2.Size = new Size(140, 29);
			button2.TabIndex = 11;
			button2.Text = "Cancelar";
			button2.TextAlign = ContentAlignment.MiddleRight;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(pbColor);
			groupBox1.Controls.Add(lblUsuario);
			groupBox1.Controls.Add(lblEstado);
			groupBox1.Controls.Add(lblPeriodo);
			groupBox1.Controls.Add(lblSemana);
			groupBox1.Controls.Add(lblTipoNomina);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(label11);
			groupBox1.Location = new Point(2, 73);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(415, 231);
			groupBox1.TabIndex = 12;
			groupBox1.TabStop = false;
			groupBox1.Text = "Informacion General";
			// 
			// pbColor
			// 
			pbColor.BackgroundImageLayout = ImageLayout.Zoom;
			pbColor.Location = new Point(147, 141);
			pbColor.Name = "pbColor";
			pbColor.Size = new Size(21, 21);
			pbColor.TabIndex = 17;
			pbColor.TabStop = false;
			// 
			// lblUsuario
			// 
			lblUsuario.AutoSize = true;
			lblUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblUsuario.Location = new Point(147, 184);
			lblUsuario.Name = "lblUsuario";
			lblUsuario.Size = new Size(65, 21);
			lblUsuario.TabIndex = 16;
			lblUsuario.Text = "Usuario";
			// 
			// lblEstado
			// 
			lblEstado.AutoSize = true;
			lblEstado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEstado.Location = new Point(171, 140);
			lblEstado.Name = "lblEstado";
			lblEstado.Size = new Size(59, 21);
			lblEstado.TabIndex = 15;
			lblEstado.Text = "Estado";
			// 
			// lblPeriodo
			// 
			lblPeriodo.AutoSize = true;
			lblPeriodo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblPeriodo.Location = new Point(147, 109);
			lblPeriodo.Name = "lblPeriodo";
			lblPeriodo.Size = new Size(69, 21);
			lblPeriodo.TabIndex = 14;
			lblPeriodo.Tag = "";
			lblPeriodo.Text = "periodo";
			// 
			// lblSemana
			// 
			lblSemana.AutoSize = true;
			lblSemana.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSemana.Location = new Point(147, 67);
			lblSemana.Name = "lblSemana";
			lblSemana.Size = new Size(65, 21);
			lblSemana.TabIndex = 13;
			lblSemana.Text = "semana";
			// 
			// lblTipoNomina
			// 
			lblTipoNomina.AutoSize = true;
			lblTipoNomina.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTipoNomina.Location = new Point(147, 32);
			lblTipoNomina.Name = "lblTipoNomina";
			lblTipoNomina.Size = new Size(125, 21);
			lblTipoNomina.TabIndex = 12;
			lblTipoNomina.Text = "tipo de nomina ";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label7.Location = new Point(18, 187);
			label7.Name = "label7";
			label7.Size = new Size(60, 17);
			label7.TabIndex = 11;
			label7.Text = "Usuario :";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label8.Location = new Point(18, 145);
			label8.Name = "label8";
			label8.Size = new Size(55, 17);
			label8.TabIndex = 10;
			label8.Text = "Estado :";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label9.Location = new Point(18, 109);
			label9.Name = "label9";
			label9.Size = new Size(61, 17);
			label9.TabIndex = 9;
			label9.Text = "Periodo :";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label10.Location = new Point(18, 70);
			label10.Name = "label10";
			label10.Size = new Size(61, 17);
			label10.TabIndex = 8;
			label10.Text = "Semana :";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label11.Location = new Point(18, 36);
			label11.Name = "label11";
			label11.Size = new Size(110, 17);
			label11.TabIndex = 7;
			label11.Text = "Tipo de Nomina :";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnCerrar);
			groupBox2.Controls.Add(button2);
			groupBox2.Location = new Point(2, 310);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(415, 110);
			groupBox2.TabIndex = 13;
			groupBox2.TabStop = false;
			// 
			// FrmCierre
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(421, 427);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(panel1);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmCierre";
			Text = "Cierre de Semana ";
			Load += FrmCierre_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbColor).EndInit();
			groupBox2.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Panel panel1;
		public Button btnCerrar;
		public Button button2;
		private GroupBox groupBox1;
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
		private GroupBox groupBox2;
	}
}
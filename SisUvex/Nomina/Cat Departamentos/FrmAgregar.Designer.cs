namespace SisUvex.Nomina.Cat_Departamentos
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
			label5 = new Label();
			lblSubtitulo = new Label();
			pictureBox1 = new PictureBox();
			btnCancelar = new Button();
			btnAccept = new Button();
			lblTitulo = new Label();
			groupBox1 = new GroupBox();
			txbCorto = new TextBox();
			flowLayoutPanel1 = new FlowLayoutPanel();
			this.txbDepartamento = new TextBox();
			chkActivo = new CheckBox();
			label2 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(5, 103);
			label5.Name = "label5";
			label5.Size = new Size(99, 17);
			label5.TabIndex = 109;
			label5.Text = "Nombre Corto:";
			// 
			// lblSubtitulo
			// 
			lblSubtitulo.AutoSize = true;
			lblSubtitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSubtitulo.ForeColor = Color.DimGray;
			lblSubtitulo.Location = new Point(61, 36);
			lblSubtitulo.Name = "lblSubtitulo";
			lblSubtitulo.Size = new Size(258, 13);
			lblSubtitulo.TabIndex = 113;
			lblSubtitulo.Text = "Capture la informacion del nuevo departamento.";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(10, 11);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(45, 40);
			pictureBox1.TabIndex = 112;
			pictureBox1.TabStop = false;
			// 
			// btnCancelar
			// 
			btnCancelar.Location = new Point(275, 287);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 29);
			btnCancelar.TabIndex = 111;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(175, 287);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 110;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitulo.ForeColor = Color.Black;
			lblTitulo.Location = new Point(61, 11);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(208, 21);
			lblTitulo.TabIndex = 108;
			lblTitulo.Text = "AGREGAR DEPARTAMENTO";
			// 
			// groupBox1
			// 
			groupBox1.BackColor = SystemColors.Control;
			groupBox1.Controls.Add(txbCorto);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(flowLayoutPanel1);
			groupBox1.Controls.Add(this.txbDepartamento);
			groupBox1.Controls.Add(chkActivo);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(10, 70);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(340, 211);
			groupBox1.TabIndex = 107;
			groupBox1.TabStop = false;
			// 
			// txbCorto
			// 
			txbCorto.BackColor = SystemColors.Control;
			txbCorto.Location = new Point(6, 128);
			txbCorto.Name = "txbCorto";
			txbCorto.Size = new Size(98, 23);
			txbCorto.TabIndex = 110;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.BackColor = Color.FromArgb(220, 225, 230);
			flowLayoutPanel1.Location = new Point(6, 88);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(327, 1);
			flowLayoutPanel1.TabIndex = 5;
			// 
			// txbDepartamento
			// 
			this.txbDepartamento.BackColor = SystemColors.Control;
			this.txbDepartamento.Location = new Point(6, 47);
			this.txbDepartamento.Name = "txbDepartamento";
			this.txbDepartamento.Size = new Size(327, 23);
			this.txbDepartamento.TabIndex = 1;
			// 
			// chkActivo
			// 
			chkActivo.AutoSize = true;
			chkActivo.Location = new Point(6, 182);
			chkActivo.Name = "chkActivo";
			chkActivo.Size = new Size(60, 19);
			chkActivo.TabIndex = 4;
			chkActivo.Text = "Activo";
			chkActivo.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(6, 164);
			label2.Name = "label2";
			label2.Size = new Size(52, 17);
			label2.TabIndex = 3;
			label2.Text = "Estado:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(6, 27);
			label1.Name = "label1";
			label1.Size = new Size(179, 17);
			label1.TabIndex = 0;
			label1.Text = " Nombre de departamento: ";
			// 
			// FrmAgregar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(360, 327);
			Controls.Add(lblSubtitulo);
			Controls.Add(pictureBox1);
			Controls.Add(btnCancelar);
			Controls.Add(btnAccept);
			Controls.Add(lblTitulo);
			Controls.Add(groupBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAgregar";
			Text = "AGREGAR DEPARTAMENTO";
			Load += FrmAgregar_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label5;
		public Label lblSubtitulo;
		private PictureBox pictureBox1;
		private Button btnCancelar;
		private Button btnAccept;
		public Label lblTitulo;
		private GroupBox groupBox1;
		private FlowLayoutPanel flowLayoutPanel1;
		public TextBox txbDepartamento;
		public CheckBox chkActivo;
		private Label label2;
		private Label label1;
		public TextBox txbCorto;
	}
}
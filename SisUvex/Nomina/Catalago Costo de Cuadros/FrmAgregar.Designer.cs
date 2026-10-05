namespace SisUvex.Nomina.Catalago_Costo_de_Cuadros
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
			lblSubtitulo = new Label();
			pictureBox1 = new PictureBox();
			btnCancelar = new Button();
			btnAccept = new Button();
			lblTitulo = new Label();
			groupBox1 = new GroupBox();
			cboLote = new ComboBox();
			txbPorcentaje = new TextBox();
			label3 = new Label();
			txbCosto = new TextBox();
			txbLineas = new TextBox();
			label5 = new Label();
			flowLayoutPanel1 = new FlowLayoutPanel();
			label2 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// lblSubtitulo
			// 
			lblSubtitulo.AutoSize = true;
			lblSubtitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSubtitulo.ForeColor = Color.DimGray;
			lblSubtitulo.Location = new Point(58, 31);
			lblSubtitulo.Name = "lblSubtitulo";
			lblSubtitulo.Size = new Size(258, 13);
			lblSubtitulo.TabIndex = 119;
			lblSubtitulo.Text = "Capture la informacion del nuevo departamento.";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(7, 6);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(45, 40);
			pictureBox1.TabIndex = 118;
			pictureBox1.TabStop = false;
			// 
			// btnCancelar
			// 
			btnCancelar.Location = new Point(273, 317);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 29);
			btnCancelar.TabIndex = 117;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(173, 317);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 116;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitulo.ForeColor = Color.Black;
			lblTitulo.Location = new Point(58, 6);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(208, 21);
			lblTitulo.TabIndex = 115;
			lblTitulo.Text = "AGREGAR DEPARTAMENTO";
			// 
			// groupBox1
			// 
			groupBox1.BackColor = SystemColors.Control;
			groupBox1.Controls.Add(cboLote);
			groupBox1.Controls.Add(txbPorcentaje);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(txbCosto);
			groupBox1.Controls.Add(txbLineas);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(flowLayoutPanel1);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(7, 65);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(340, 246);
			groupBox1.TabIndex = 114;
			groupBox1.TabStop = false;
			// 
			// cboLote
			// 
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(6, 47);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(216, 23);
			cboLote.TabIndex = 115;
			cboLote.SelectedIndexChanged += cboLote_SelectedIndexChanged;
			// 
			// txbPorcentaje
			// 
			txbPorcentaje.BackColor = SystemColors.Control;
			txbPorcentaje.Location = new Point(161, 184);
			txbPorcentaje.Name = "txbPorcentaje";
			txbPorcentaje.Size = new Size(98, 23);
			txbPorcentaje.TabIndex = 114;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(161, 164);
			label3.Name = "label3";
			label3.Size = new Size(75, 17);
			label3.TabIndex = 113;
			label3.Text = "Porcentaje:";
			// 
			// txbCosto
			// 
			txbCosto.BackColor = SystemColors.Control;
			txbCosto.Location = new Point(6, 184);
			txbCosto.Name = "txbCosto";
			txbCosto.Size = new Size(98, 23);
			txbCosto.TabIndex = 112;
			// 
			// txbLineas
			// 
			txbLineas.BackColor = SystemColors.Control;
			txbLineas.Location = new Point(6, 128);
			txbLineas.Name = "txbLineas";
			txbLineas.Size = new Size(98, 23);
			txbLineas.TabIndex = 110;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(5, 103);
			label5.Name = "label5";
			label5.Size = new Size(48, 17);
			label5.TabIndex = 109;
			label5.Text = "Lineas:";
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.BackColor = Color.FromArgb(220, 225, 230);
			flowLayoutPanel1.Location = new Point(6, 88);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(327, 1);
			flowLayoutPanel1.TabIndex = 5;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(6, 164);
			label2.Name = "label2";
			label2.Size = new Size(46, 17);
			label2.TabIndex = 3;
			label2.Text = "Costo:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(6, 27);
			label1.Name = "label1";
			label1.Size = new Size(121, 17);
			label1.TabIndex = 0;
			label1.Text = "Nombre del Lote : ";
			// 
			// FrmAgregar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(358, 363);
			Controls.Add(lblSubtitulo);
			Controls.Add(pictureBox1);
			Controls.Add(btnCancelar);
			Controls.Add(btnAccept);
			Controls.Add(lblTitulo);
			Controls.Add(groupBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAgregar";
			Text = "Agregar Costo";
			Load += FrmAgregar_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Label lblSubtitulo;
		private PictureBox pictureBox1;
		private Button btnCancelar;
		private Button btnAccept;
		public Label lblTitulo;
		private GroupBox groupBox1;
		public TextBox txbLineas;
		private Label label5;
		private FlowLayoutPanel flowLayoutPanel1;
		private Label label2;
		private Label label1;
		public TextBox txbPorcentaje;
		private Label label3;
		public TextBox txbCosto;
		public ComboBox cboLote;
	}
}
namespace SisUvex.Nomina.NomCuadrillasCampo
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
			label1 = new Label();
			groupBox1 = new GroupBox();
			flowLayoutPanel1 = new FlowLayoutPanel();
			txbCuadrilla = new TextBox();
			chkActivo = new CheckBox();
			label2 = new Label();
			btnCancelar = new Button();
			btnAccept = new Button();
			pictureBox1 = new PictureBox();
			lblSubtitulo = new Label();
			lblTitulo = new Label();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(6, 27);
			label1.Name = "label1";
			label1.Size = new Size(142, 17);
			label1.TabIndex = 0;
			label1.Text = " Nombre de cuadrilla: ";
			// 
			// groupBox1
			// 
			groupBox1.BackColor = SystemColors.Control;
			groupBox1.Controls.Add(flowLayoutPanel1);
			groupBox1.Controls.Add(txbCuadrilla);
			groupBox1.Controls.Add(chkActivo);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(13, 59);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(340, 157);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.BackColor = Color.FromArgb(220, 225, 230);
			flowLayoutPanel1.Location = new Point(6, 88);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(327, 1);
			flowLayoutPanel1.TabIndex = 5;
			// 
			// txbCuadrilla
			// 
			txbCuadrilla.BackColor = SystemColors.Control;
			txbCuadrilla.Location = new Point(6, 47);
			txbCuadrilla.Name = "txbCuadrilla";
			txbCuadrilla.Size = new Size(327, 23);
			txbCuadrilla.TabIndex = 1;
			txbCuadrilla.Enter += txbCuadrilla_Enter;
			txbCuadrilla.Leave += txbCuadrilla_Leave;
			// 
			// chkActivo
			// 
			chkActivo.AutoSize = true;
			chkActivo.Location = new Point(15, 122);
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
			label2.Location = new Point(15, 104);
			label2.Name = "label2";
			label2.Size = new Size(52, 17);
			label2.TabIndex = 3;
			label2.Text = "Estado:";
			// 
			// btnCancelar
			// 
			btnCancelar.Location = new Point(278, 222);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 29);
			btnCancelar.TabIndex = 103;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(178, 222);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 102;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(45, 40);
			pictureBox1.TabIndex = 104;
			pictureBox1.TabStop = false;
			// 
			// lblSubtitulo
			// 
			lblSubtitulo.AutoSize = true;
			lblSubtitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSubtitulo.ForeColor = Color.DimGray;
			lblSubtitulo.Location = new Point(63, 37);
			lblSubtitulo.Name = "lblSubtitulo";
			lblSubtitulo.Size = new Size(290, 13);
			lblSubtitulo.TabIndex = 105;
			lblSubtitulo.Text = "Capture la informacion de la nueva cuadrilla de campo.";
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitulo.ForeColor = Color.Black;
			lblTitulo.Location = new Point(63, 12);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(175, 21);
			lblTitulo.TabIndex = 3;
			lblTitulo.Text = "AGREGAR CUADRILLA ";
			// 
			// FrmAgregar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(366, 266);
			Controls.Add(lblSubtitulo);
			Controls.Add(pictureBox1);
			Controls.Add(btnCancelar);
			Controls.Add(btnAccept);
			Controls.Add(lblTitulo);
			Controls.Add(groupBox1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAgregar";
			Text = "Agregar Cuadrilla";
			Load += FrmAgregar_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private GroupBox groupBox1;
		private Label label2;
		private CheckBox cbActivo;
		private Label label3;
		private Button btnCancelar;
		private Button btnAccept;
		private PictureBox pictureBox1;
		private Label label4;
		public TextBox txbCuadrilla;
		public CheckBox chkActivo;
		private FlowLayoutPanel flowLayoutPanel1;
		public Label lblTitulo;
		public Label lblSubtitulo;
	}
}
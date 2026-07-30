namespace SisUvex.Nomina.Nom_semAutomatizada
{
	partial class FrmNominaExistente
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNominaExistente));
			lblTitulo = new Label();
			plNomina = new Panel();
			gbDatos = new GroupBox();
			lblGenero = new Label();
			ptbGenero = new PictureBox();
			pictureBox1 = new PictureBox();
			lblUsuario = new Label();
			label1 = new Label();
			lblFecha = new Label();
			ptbFecha = new PictureBox();
			label3 = new Label();
			gbAccion = new GroupBox();
			btnCancelar = new Button();
			btnRecalcular = new Button();
			btnMostrar = new Button();
			lblMensaje = new Label();
			groupBox1 = new GroupBox();
			gbDatos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ptbGenero).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)ptbFecha).BeginInit();
			gbAccion.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
			lblTitulo.Location = new Point(139, 7);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(191, 25);
			lblTitulo.TabIndex = 0;
			lblTitulo.Text = "NOMINA EXISTENTE";
			// 
			// plNomina
			// 
			plNomina.BackColor = SystemColors.Control;
			plNomina.Location = new Point(3, 55);
			plNomina.Margin = new Padding(3, 2, 3, 2);
			plNomina.Name = "plNomina";
			plNomina.Size = new Size(487, 18);
			plNomina.TabIndex = 1;
			// 
			// gbDatos
			// 
			gbDatos.Controls.Add(lblGenero);
			gbDatos.Controls.Add(ptbGenero);
			gbDatos.Location = new Point(34, 77);
			gbDatos.Margin = new Padding(3, 2, 3, 2);
			gbDatos.Name = "gbDatos";
			gbDatos.Padding = new Padding(3, 2, 3, 2);
			gbDatos.Size = new Size(420, 74);
			gbDatos.TabIndex = 2;
			gbDatos.TabStop = false;
			gbDatos.Text = "Tipo de Nomina";
			// 
			// lblGenero
			// 
			lblGenero.AutoSize = true;
			lblGenero.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblGenero.Location = new Point(80, 33);
			lblGenero.Name = "lblGenero";
			lblGenero.Size = new Size(0, 21);
			lblGenero.TabIndex = 4;
			// 
			// ptbGenero
			// 
			ptbGenero.BackgroundImageLayout = ImageLayout.Zoom;
			ptbGenero.Location = new Point(10, 20);
			ptbGenero.Margin = new Padding(3, 2, 3, 2);
			ptbGenero.Name = "ptbGenero";
			ptbGenero.Size = new Size(60, 45);
			ptbGenero.TabIndex = 2;
			ptbGenero.TabStop = false;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(13, 68);
			pictureBox1.Margin = new Padding(3, 2, 3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(49, 21);
			pictureBox1.TabIndex = 8;
			pictureBox1.TabStop = false;
			// 
			// lblUsuario
			// 
			lblUsuario.AutoSize = true;
			lblUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			lblUsuario.Location = new Point(79, 78);
			lblUsuario.Name = "lblUsuario";
			lblUsuario.Size = new Size(0, 21);
			lblUsuario.TabIndex = 7;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(79, 63);
			label1.Name = "label1";
			label1.Size = new Size(47, 15);
			label1.TabIndex = 6;
			label1.Text = "Usuario";
			// 
			// lblFecha
			// 
			lblFecha.AutoSize = true;
			lblFecha.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFecha.Location = new Point(79, 32);
			lblFecha.Name = "lblFecha";
			lblFecha.Size = new Size(0, 21);
			lblFecha.TabIndex = 5;
			// 
			// ptbFecha
			// 
			ptbFecha.BackgroundImage = (Image)resources.GetObject("ptbFecha.BackgroundImage");
			ptbFecha.BackgroundImageLayout = ImageLayout.Zoom;
			ptbFecha.Location = new Point(13, 23);
			ptbFecha.Margin = new Padding(3, 2, 3, 2);
			ptbFecha.Name = "ptbFecha";
			ptbFecha.Size = new Size(49, 21);
			ptbFecha.TabIndex = 3;
			ptbFecha.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(79, 18);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 1;
			label3.Text = "Fecha";
			// 
			// gbAccion
			// 
			gbAccion.BackColor = SystemColors.Control;
			gbAccion.Controls.Add(btnCancelar);
			gbAccion.Controls.Add(btnRecalcular);
			gbAccion.Controls.Add(btnMostrar);
			gbAccion.Location = new Point(34, 264);
			gbAccion.Margin = new Padding(3, 2, 3, 2);
			gbAccion.Name = "gbAccion";
			gbAccion.Padding = new Padding(3, 2, 3, 2);
			gbAccion.Size = new Size(420, 174);
			gbAccion.TabIndex = 3;
			gbAccion.TabStop = false;
			gbAccion.Text = "Seleccione una acción";
			// 
			// btnCancelar
			// 
			btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancelar.Location = new Point(71, 121);
			btnCancelar.Margin = new Padding(3, 2, 3, 2);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Padding = new Padding(18, 0, 9, 0);
			btnCancelar.Size = new Size(278, 30);
			btnCancelar.TabIndex = 2;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// btnRecalcular
			// 
			btnRecalcular.Image = (Image)resources.GetObject("btnRecalcular.Image");
			btnRecalcular.ImageAlign = ContentAlignment.MiddleLeft;
			btnRecalcular.Location = new Point(71, 76);
			btnRecalcular.Margin = new Padding(3, 2, 3, 2);
			btnRecalcular.Name = "btnRecalcular";
			btnRecalcular.Padding = new Padding(18, 0, 9, 0);
			btnRecalcular.Size = new Size(278, 30);
			btnRecalcular.TabIndex = 1;
			btnRecalcular.Text = "Recalcular Nomina";
			btnRecalcular.UseVisualStyleBackColor = true;
			btnRecalcular.Click += btnRecalcular_Click;
			// 
			// btnMostrar
			// 
			btnMostrar.BackColor = SystemColors.ControlLightLight;
			btnMostrar.BackgroundImageLayout = ImageLayout.None;
			btnMostrar.Image = (Image)resources.GetObject("btnMostrar.Image");
			btnMostrar.ImageAlign = ContentAlignment.MiddleLeft;
			btnMostrar.Location = new Point(71, 34);
			btnMostrar.Margin = new Padding(3, 2, 3, 2);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Padding = new Padding(18, 0, 10, 0);
			btnMostrar.Size = new Size(278, 30);
			btnMostrar.TabIndex = 0;
			btnMostrar.Text = "Mostrar Nomina";
			btnMostrar.UseVisualStyleBackColor = false;
			btnMostrar.Click += btnMostrar_Click;
			// 
			// lblMensaje
			// 
			lblMensaje.AutoSize = true;
			lblMensaje.Location = new Point(139, 31);
			lblMensaje.Name = "lblMensaje";
			lblMensaje.Size = new Size(0, 15);
			lblMensaje.TabIndex = 4;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(pictureBox1);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(ptbFecha);
			groupBox1.Controls.Add(lblUsuario);
			groupBox1.Controls.Add(lblFecha);
			groupBox1.Location = new Point(34, 155);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(420, 104);
			groupBox1.TabIndex = 9;
			groupBox1.TabStop = false;
			groupBox1.Text = "Datos de Generación";
			// 
			// FrmNominaExistente
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(491, 441);
			Controls.Add(groupBox1);
			Controls.Add(lblMensaje);
			Controls.Add(gbAccion);
			Controls.Add(gbDatos);
			Controls.Add(plNomina);
			Controls.Add(lblTitulo);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 2, 3, 2);
			Name = "FrmNominaExistente";
			Text = "Nomina";
			Load += FrmNominaExistente_Load;
			gbDatos.ResumeLayout(false);
			gbDatos.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ptbGenero).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)ptbFecha).EndInit();
			gbAccion.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblTitulo;
		private Panel plNomina;
		private GroupBox gbDatos;
		private Label label3;
		private GroupBox gbAccion;
		private Button btnCancelar;
		private Button btnRecalcular;
		private Button btnMostrar;
		private PictureBox ptbFecha;
		private PictureBox ptbGenero;
		private Label lblFecha;
		private Label lblGenero;
		private Label lblMensaje;
		private PictureBox pictureBox1;
		public Label lblUsuario;
		private Label label1;
		private GroupBox groupBox1;
	}
}
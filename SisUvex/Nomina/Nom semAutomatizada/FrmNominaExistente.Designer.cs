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
			panel2 = new Panel();
			pictureBox3 = new PictureBox();
			label5 = new Label();
			lblCantidadEmpleados = new Label();
			lbldatos = new Label();
			panel3 = new Panel();
			label4 = new Label();
			lblFechaNomina = new Label();
			pictureBox2 = new PictureBox();
			panel1 = new Panel();
			label2 = new Label();
			lblGenero = new Label();
			ptbGenero = new PictureBox();
			pictureBox1 = new PictureBox();
			lblUsuario = new Label();
			label1 = new Label();
			lblFecha = new Label();
			ptbFecha = new PictureBox();
			label3 = new Label();
			gbAccion = new GroupBox();
			lblAccion = new Label();
			btnCancelar = new Button();
			btnRecalcular = new Button();
			btnMostrar = new Button();
			lblMensaje = new Label();
			gbGenerada = new GroupBox();
			lblGeneracion = new Label();
			gbDatos.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ptbGenero).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)ptbFecha).BeginInit();
			gbAccion.SuspendLayout();
			gbGenerada.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
			lblTitulo.Location = new Point(156, 7);
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
			plNomina.Size = new Size(483, 12);
			plNomina.TabIndex = 1;
			// 
			// gbDatos
			// 
			gbDatos.Controls.Add(panel2);
			gbDatos.Controls.Add(lbldatos);
			gbDatos.Controls.Add(panel3);
			gbDatos.Controls.Add(panel1);
			gbDatos.Location = new Point(12, 86);
			gbDatos.Margin = new Padding(3, 2, 3, 2);
			gbDatos.Name = "gbDatos";
			gbDatos.Padding = new Padding(3, 2, 3, 2);
			gbDatos.Size = new Size(463, 105);
			gbDatos.TabIndex = 2;
			gbDatos.TabStop = false;
			gbDatos.Enter += gbDatos_Enter;
			// 
			// panel2
			// 
			panel2.Controls.Add(pictureBox3);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(lblCantidadEmpleados);
			panel2.Location = new Point(322, 35);
			panel2.Name = "panel2";
			panel2.Size = new Size(134, 54);
			panel2.TabIndex = 5;
			// 
			// pictureBox3
			// 
			pictureBox3.Anchor = AnchorStyles.None;
			pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
			pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox3.Location = new Point(11, 9);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(46, 35);
			pictureBox3.TabIndex = 10;
			pictureBox3.TabStop = false;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.DimGray;
			label5.Location = new Point(67, 32);
			label5.Name = "label5";
			label5.Size = new Size(63, 13);
			label5.TabIndex = 11;
			label5.Text = "Empleados";
			// 
			// lblCantidadEmpleados
			// 
			lblCantidadEmpleados.AutoSize = true;
			lblCantidadEmpleados.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCantidadEmpleados.Location = new Point(67, 11);
			lblCantidadEmpleados.Name = "lblCantidadEmpleados";
			lblCantidadEmpleados.Size = new Size(29, 17);
			lblCantidadEmpleados.TabIndex = 11;
			lblCantidadEmpleados.Text = "100";
			// 
			// lbldatos
			// 
			lbldatos.AutoSize = true;
			lbldatos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbldatos.Location = new Point(6, 15);
			lbldatos.Name = "lbldatos";
			lbldatos.Size = new Size(166, 17);
			lbldatos.TabIndex = 1;
			lbldatos.Text = "Información de la Nómina";
			// 
			// panel3
			// 
			panel3.Controls.Add(label4);
			panel3.Controls.Add(lblFechaNomina);
			panel3.Controls.Add(pictureBox2);
			panel3.Location = new Point(167, 35);
			panel3.Name = "panel3";
			panel3.Size = new Size(149, 54);
			panel3.TabIndex = 6;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.DimGray;
			label4.Location = new Point(51, 30);
			label4.Name = "label4";
			label4.Size = new Size(96, 13);
			label4.TabIndex = 10;
			label4.Text = "Fecha de Nomina";
			// 
			// lblFechaNomina
			// 
			lblFechaNomina.AutoSize = true;
			lblFechaNomina.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFechaNomina.Location = new Point(51, 13);
			lblFechaNomina.Name = "lblFechaNomina";
			lblFechaNomina.Size = new Size(43, 17);
			lblFechaNomina.TabIndex = 10;
			lblFechaNomina.Text = "Fecha";
			// 
			// pictureBox2
			// 
			pictureBox2.Anchor = AnchorStyles.None;
			pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
			pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox2.Location = new Point(1, 11);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(41, 34);
			pictureBox2.TabIndex = 9;
			pictureBox2.TabStop = false;
			// 
			// panel1
			// 
			panel1.Controls.Add(label2);
			panel1.Controls.Add(lblGenero);
			panel1.Controls.Add(ptbGenero);
			panel1.Location = new Point(6, 35);
			panel1.Name = "panel1";
			panel1.Size = new Size(155, 54);
			panel1.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.DimGray;
			label2.Location = new Point(52, 30);
			label2.Name = "label2";
			label2.Size = new Size(88, 13);
			label2.TabIndex = 9;
			label2.Text = "Tipo de Nomina";
			// 
			// lblGenero
			// 
			lblGenero.AutoSize = true;
			lblGenero.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblGenero.Location = new Point(57, 11);
			lblGenero.Name = "lblGenero";
			lblGenero.Size = new Size(69, 17);
			lblGenero.TabIndex = 4;
			lblGenero.Text = "Esparrago";
			// 
			// ptbGenero
			// 
			ptbGenero.Anchor = AnchorStyles.None;
			ptbGenero.BackgroundImageLayout = ImageLayout.Zoom;
			ptbGenero.Location = new Point(2, 9);
			ptbGenero.Margin = new Padding(3, 2, 3, 2);
			ptbGenero.Name = "ptbGenero";
			ptbGenero.Size = new Size(44, 36);
			ptbGenero.TabIndex = 2;
			ptbGenero.TabStop = false;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(285, 41);
			pictureBox1.Margin = new Padding(3, 2, 3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(44, 35);
			pictureBox1.TabIndex = 8;
			pictureBox1.TabStop = false;
			// 
			// lblUsuario
			// 
			lblUsuario.AutoSize = true;
			lblUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblUsuario.Location = new Point(335, 43);
			lblUsuario.Name = "lblUsuario";
			lblUsuario.Size = new Size(53, 17);
			lblUsuario.TabIndex = 7;
			lblUsuario.Text = "usuario";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = Color.DimGray;
			label1.Location = new Point(335, 60);
			label1.Name = "label1";
			label1.Size = new Size(47, 15);
			label1.TabIndex = 6;
			label1.Text = "Usuario";
			// 
			// lblFecha
			// 
			lblFecha.AutoSize = true;
			lblFecha.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblFecha.Location = new Point(118, 43);
			lblFecha.Name = "lblFecha";
			lblFecha.Size = new Size(43, 17);
			lblFecha.TabIndex = 5;
			lblFecha.Text = "Fecha";
			// 
			// ptbFecha
			// 
			ptbFecha.BackgroundImage = (Image)resources.GetObject("ptbFecha.BackgroundImage");
			ptbFecha.BackgroundImageLayout = ImageLayout.Zoom;
			ptbFecha.Location = new Point(66, 41);
			ptbFecha.Margin = new Padding(3, 2, 3, 2);
			ptbFecha.Name = "ptbFecha";
			ptbFecha.Size = new Size(45, 35);
			ptbFecha.TabIndex = 3;
			ptbFecha.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = Color.DimGray;
			label3.Location = new Point(117, 60);
			label3.Name = "label3";
			label3.Size = new Size(72, 15);
			label3.TabIndex = 1;
			label3.Text = "Generada el ";
			// 
			// gbAccion
			// 
			gbAccion.BackColor = SystemColors.Control;
			gbAccion.Controls.Add(lblAccion);
			gbAccion.Controls.Add(btnCancelar);
			gbAccion.Controls.Add(btnRecalcular);
			gbAccion.Controls.Add(btnMostrar);
			gbAccion.Location = new Point(12, 284);
			gbAccion.Margin = new Padding(3, 2, 3, 2);
			gbAccion.Name = "gbAccion";
			gbAccion.Padding = new Padding(3, 2, 3, 2);
			gbAccion.Size = new Size(463, 179);
			gbAccion.TabIndex = 3;
			gbAccion.TabStop = false;
			// 
			// lblAccion
			// 
			lblAccion.AutoSize = true;
			lblAccion.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblAccion.Location = new Point(6, 18);
			lblAccion.Name = "lblAccion";
			lblAccion.Size = new Size(139, 17);
			lblAccion.TabIndex = 3;
			lblAccion.Text = "Seleccione una acción";
			// 
			// btnCancelar
			// 
			btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancelar.Location = new Point(109, 139);
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
			btnRecalcular.Location = new Point(109, 94);
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
			btnMostrar.Location = new Point(109, 52);
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
			lblMensaje.Location = new Point(167, 31);
			lblMensaje.Name = "lblMensaje";
			lblMensaje.Size = new Size(0, 15);
			lblMensaje.TabIndex = 4;
			// 
			// gbGenerada
			// 
			gbGenerada.BackColor = SystemColors.Control;
			gbGenerada.Controls.Add(lblGeneracion);
			gbGenerada.Controls.Add(label1);
			gbGenerada.Controls.Add(pictureBox1);
			gbGenerada.Controls.Add(ptbFecha);
			gbGenerada.Controls.Add(label3);
			gbGenerada.Controls.Add(lblUsuario);
			gbGenerada.Controls.Add(lblFecha);
			gbGenerada.Location = new Point(12, 195);
			gbGenerada.Margin = new Padding(3, 2, 3, 2);
			gbGenerada.Name = "gbGenerada";
			gbGenerada.Padding = new Padding(3, 2, 3, 2);
			gbGenerada.Size = new Size(463, 85);
			gbGenerada.TabIndex = 9;
			gbGenerada.TabStop = false;
			// 
			// lblGeneracion
			// 
			lblGeneracion.AutoSize = true;
			lblGeneracion.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblGeneracion.Location = new Point(6, 13);
			lblGeneracion.Name = "lblGeneracion";
			lblGeneracion.Size = new Size(134, 17);
			lblGeneracion.TabIndex = 9;
			lblGeneracion.Text = "Datos de Generación";
			// 
			// FrmNominaExistente
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(486, 474);
			Controls.Add(gbGenerada);
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
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ptbGenero).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)ptbFecha).EndInit();
			gbAccion.ResumeLayout(false);
			gbAccion.PerformLayout();
			gbGenerada.ResumeLayout(false);
			gbGenerada.PerformLayout();
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
		private Button btnMostrar;
		private PictureBox ptbFecha;
		private PictureBox ptbGenero;
		private Label lblFecha;
		private Label lblGenero;
		private Label lblMensaje;
		private PictureBox pictureBox1;
		public Label lblUsuario;
		private Label label1;
		private GroupBox gbGenerada;
		public Button btnRecalcular;
		public Label lblFechaNomina;
		public Label lblCantidadEmpleados;
		private Label label2;
		private Panel panel1;
		private Panel panel3;
		private Label label4;
		private Panel panel2;
		private Label label5;
		private PictureBox pictureBox3;
		private PictureBox pictureBox2;
		private Label lblAccion;
		private Label lblGeneracion;
		public Label lbldatos;
	}
}
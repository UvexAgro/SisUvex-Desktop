namespace SisUvex.Nomina.NomCampoAgregarListados
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
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregar));
			label1 = new Label();
			txbEmpleado = new TextBox();
			dgvListadoAgregar = new DataGridView();
			btnContinuar = new Button();
			btnCancelar = new Button();
			label2 = new Label();
			label3 = new Label();
			cboActividad = new ComboBox();
			txbCodigo = new TextBox();
			groupBox1 = new GroupBox();
			cboLote = new ComboBox();
			label5 = new Label();
			btnAgregarListado = new Button();
			lblTitulo = new Label();
			pictureBox1 = new PictureBox();
			lblSubtitulo = new Label();
			((System.ComponentModel.ISupportInitialize)dgvListadoAgregar).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(28, 80);
			label1.Name = "label1";
			label1.Size = new Size(66, 15);
			label1.TabIndex = 0;
			label1.Text = "Empleado :";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(28, 98);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(252, 23);
			txbEmpleado.TabIndex = 8;
			// 
			// dgvListadoAgregar
			// 
			dgvListadoAgregar.AllowUserToAddRows = false;
			dgvListadoAgregar.AllowUserToDeleteRows = false;
			dgvListadoAgregar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvListadoAgregar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvListadoAgregar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvListadoAgregar.BackgroundColor = SystemColors.Control;
			dgvListadoAgregar.BorderStyle = BorderStyle.Fixed3D;
			dgvListadoAgregar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvListadoAgregar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvListadoAgregar.ColumnHeadersHeight = 29;
			dgvListadoAgregar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvListadoAgregar.EnableHeadersVisualStyles = false;
			dgvListadoAgregar.ImeMode = ImeMode.NoControl;
			dgvListadoAgregar.Location = new Point(12, 251);
			dgvListadoAgregar.Name = "dgvListadoAgregar";
			dgvListadoAgregar.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvListadoAgregar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvListadoAgregar.RowHeadersVisible = false;
			dgvListadoAgregar.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvListadoAgregar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvListadoAgregar.Size = new Size(836, 206);
			dgvListadoAgregar.TabIndex = 14;
			// 
			// btnContinuar
			// 
			btnContinuar.Image = (Image)resources.GetObject("btnContinuar.Image");
			btnContinuar.ImageAlign = ContentAlignment.MiddleLeft;
			btnContinuar.Location = new Point(707, 463);
			btnContinuar.Name = "btnContinuar";
			btnContinuar.Padding = new Padding(6, 0, 6, 0);
			btnContinuar.Size = new Size(110, 27);
			btnContinuar.TabIndex = 20;
			btnContinuar.Text = "Continuar";
			btnContinuar.TextAlign = ContentAlignment.MiddleRight;
			btnContinuar.UseVisualStyleBackColor = true;
			btnContinuar.Click += btnContinuar_Click;
			// 
			// btnCancelar
			// 
			btnCancelar.BackgroundImageLayout = ImageLayout.Zoom;
			btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
			btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancelar.Location = new Point(573, 463);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Padding = new Padding(10, 0, 10, 0);
			btnCancelar.Size = new Size(110, 27);
			btnCancelar.TabIndex = 21;
			btnCancelar.Text = "Cancelar";
			btnCancelar.TextAlign = ContentAlignment.MiddleRight;
			btnCancelar.UseVisualStyleBackColor = true;
			btnCancelar.Click += btnCancelar_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(28, 27);
			label2.Name = "label2";
			label2.Size = new Size(126, 15);
			label2.TabIndex = 22;
			label2.Text = "Codigo del Empleado :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(468, 27);
			label3.Name = "label3";
			label3.Size = new Size(166, 15);
			label3.TabIndex = 24;
			label3.Text = "Actividad (misma para todos):";
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(468, 45);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(265, 23);
			cboActividad.TabIndex = 26;
			// 
			// txbCodigo
			// 
			txbCodigo.Font = new Font("Segoe UI", 9.25F);
			txbCodigo.Location = new Point(28, 45);
			txbCodigo.Margin = new Padding(1);
			txbCodigo.MaxLength = 3000;
			txbCodigo.Multiline = true;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.ScrollBars = ScrollBars.Vertical;
			txbCodigo.Size = new Size(112, 25);
			txbCodigo.TabIndex = 30;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(cboLote);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(cboActividad);
			groupBox1.Controls.Add(txbCodigo);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(txbEmpleado);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label3);
			groupBox1.Location = new Point(12, 60);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(836, 153);
			groupBox1.TabIndex = 31;
			groupBox1.TabStop = false;
			// 
			// cboLote
			// 
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(468, 98);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(323, 23);
			cboLote.TabIndex = 33;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(468, 80);
			label5.Name = "label5";
			label5.Size = new Size(36, 15);
			label5.TabIndex = 32;
			label5.Text = "Lote :";
			// 
			// btnAgregarListado
			// 
			btnAgregarListado.Image = Properties.Resources.mas_16;
			btnAgregarListado.ImageAlign = ContentAlignment.MiddleLeft;
			btnAgregarListado.Location = new Point(664, 217);
			btnAgregarListado.Margin = new Padding(1);
			btnAgregarListado.Name = "btnAgregarListado";
			btnAgregarListado.Padding = new Padding(20, 0, 15, 0);
			btnAgregarListado.Size = new Size(184, 30);
			btnAgregarListado.TabIndex = 31;
			btnAgregarListado.Text = "Agregar Empleado";
			btnAgregarListado.TextAlign = ContentAlignment.MiddleRight;
			btnAgregarListado.UseVisualStyleBackColor = true;
			btnAgregarListado.Click += btnAgregarListado_Click;
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitulo.ForeColor = Color.FromArgb(23, 74, 139);
			lblTitulo.Location = new Point(72, 9);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(217, 25);
			lblTitulo.TabIndex = 32;
			lblTitulo.Text = "AGREGAR EMPLEADOS";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(12, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(53, 50);
			pictureBox1.TabIndex = 33;
			pictureBox1.TabStop = false;
			// 
			// lblSubtitulo
			// 
			lblSubtitulo.AutoSize = true;
			lblSubtitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSubtitulo.ForeColor = Color.DimGray;
			lblSubtitulo.Location = new Point(72, 37);
			lblSubtitulo.Name = "lblSubtitulo";
			lblSubtitulo.Size = new Size(193, 13);
			lblSubtitulo.TabIndex = 34;
			lblSubtitulo.Text = "Registro de empleados por cuadrilla";
			// 
			// FrmAgregar
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(852, 499);
			Controls.Add(lblSubtitulo);
			Controls.Add(pictureBox1);
			Controls.Add(btnAgregarListado);
			Controls.Add(lblTitulo);
			Controls.Add(groupBox1);
			Controls.Add(btnCancelar);
			Controls.Add(btnContinuar);
			Controls.Add(dgvListadoAgregar);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAgregar";
			Text = "Agregar Empleado";
			Load += FrmAgregar_Load;
			((System.ComponentModel.ISupportInitialize)dgvListadoAgregar).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		public DataGridView dgvListadoAgregar;
		public Button btnContinuar;
		public Button btnCancelar;
		private Label label2;
		private Label label3;
		private ComboBox comboBox1;
		public ComboBox cboActividad;
		public TextBox txbEmpleado;
		public TextBox txbCodigo;
		private GroupBox groupBox1;
		private Button btnAgregarListado;
		public Label lblTitulo;
		private PictureBox pictureBox1;
		public Label lblSubtitulo;
		private Label label6;
		public ComboBox cboLote;
		private Label label5;
	}
}
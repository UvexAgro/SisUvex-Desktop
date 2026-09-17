namespace SisUvex.Nomina.NomCampoAgregarListados
{
	partial class FrmAgregarLoteyActividad
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarLoteyActividad));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			cboFecha = new ComboBox();
			lblSubtitulo = new Label();
			pictureBox1 = new PictureBox();
			lblTitulo = new Label();
			groupBox1 = new GroupBox();
			btnLote = new Button();
			btnAsignar = new Button();
			cboCultivo = new ComboBox();
			label2 = new Label();
			cboLote = new ComboBox();
			lblLote = new Label();
			cboActividad = new ComboBox();
			lblActividad = new Label();
			dgvAgregarLoteyActividad = new DataGridView();
			btnCancelar = new Button();
			btnContinuar = new Button();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAgregarLoteyActividad).BeginInit();
			SuspendLayout();
			// 
			// cboFecha
			// 
			cboFecha.FormattingEnabled = true;
			cboFecha.Location = new Point(593, 40);
			cboFecha.Name = "cboFecha";
			cboFecha.Size = new Size(265, 23);
			cboFecha.TabIndex = 39;
			cboFecha.DrawItem += cboFecha_DrawItem;
			cboFecha.SelectedIndexChanged += cboFecha_SelectedIndexChanged;
			// 
			// lblSubtitulo
			// 
			lblSubtitulo.AutoSize = true;
			lblSubtitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblSubtitulo.ForeColor = Color.DimGray;
			lblSubtitulo.Location = new Point(68, 46);
			lblSubtitulo.Name = "lblSubtitulo";
			lblSubtitulo.Size = new Size(149, 13);
			lblSubtitulo.TabIndex = 38;
			lblSubtitulo.Text = "Registro de Actividad y Lote";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(8, 13);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(53, 50);
			pictureBox1.TabIndex = 37;
			pictureBox1.TabStop = false;
			// 
			// lblTitulo
			// 
			lblTitulo.AutoSize = true;
			lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitulo.ForeColor = Color.FromArgb(23, 74, 139);
			lblTitulo.Location = new Point(68, 18);
			lblTitulo.Name = "lblTitulo";
			lblTitulo.Size = new Size(278, 25);
			lblTitulo.TabIndex = 36;
			lblTitulo.Text = "AGREGAR LOTE Y ACTIVIDAD ";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnLote);
			groupBox1.Controls.Add(btnAsignar);
			groupBox1.Controls.Add(cboCultivo);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(cboLote);
			groupBox1.Controls.Add(lblLote);
			groupBox1.Controls.Add(cboActividad);
			groupBox1.Controls.Add(lblActividad);
			groupBox1.Location = new Point(8, 90);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(905, 186);
			groupBox1.TabIndex = 40;
			groupBox1.TabStop = false;
			// 
			// btnLote
			// 
			btnLote.Image = (Image)resources.GetObject("btnLote.Image");
			btnLote.ImageAlign = ContentAlignment.MiddleLeft;
			btnLote.Location = new Point(694, 153);
			btnLote.Name = "btnLote";
			btnLote.Padding = new Padding(10, 0, 20, 0);
			btnLote.Size = new Size(156, 27);
			btnLote.TabIndex = 46;
			btnLote.Text = "Asignar Lote";
			btnLote.TextAlign = ContentAlignment.MiddleRight;
			btnLote.UseVisualStyleBackColor = true;
			btnLote.Click += btnLote_Click;
			// 
			// btnAsignar
			// 
			btnAsignar.Image = (Image)resources.GetObject("btnAsignar.Image");
			btnAsignar.ImageAlign = ContentAlignment.MiddleLeft;
			btnAsignar.Location = new Point(6, 110);
			btnAsignar.Name = "btnAsignar";
			btnAsignar.Padding = new Padding(6, 0, 6, 0);
			btnAsignar.Size = new Size(156, 27);
			btnAsignar.TabIndex = 45;
			btnAsignar.Text = "Asignar Actividad";
			btnAsignar.TextAlign = ContentAlignment.MiddleRight;
			btnAsignar.UseVisualStyleBackColor = true;
			btnAsignar.Click += btnAsignar_Click;
			// 
			// cboCultivo
			// 
			cboCultivo.FormattingEnabled = true;
			cboCultivo.Location = new Point(527, 42);
			cboCultivo.Name = "cboCultivo";
			cboCultivo.Size = new Size(323, 23);
			cboCultivo.TabIndex = 35;
			cboCultivo.SelectionChangeCommitted += cboCultivo_SelectionChangeCommitted;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(527, 24);
			label2.Name = "label2";
			label2.Size = new Size(50, 15);
			label2.TabIndex = 34;
			label2.Text = "Cultivo :";
			// 
			// cboLote
			// 
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(527, 97);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(323, 23);
			cboLote.TabIndex = 33;
			cboLote.KeyDown += cboLote_KeyDown;
			// 
			// lblLote
			// 
			lblLote.AutoSize = true;
			lblLote.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblLote.Location = new Point(527, 79);
			lblLote.Name = "lblLote";
			lblLote.Size = new Size(137, 15);
			lblLote.TabIndex = 32;
			lblLote.Text = "Lote (Aplica Seleccion ) :";
			// 
			// cboActividad
			// 
			cboActividad.FormattingEnabled = true;
			cboActividad.Location = new Point(6, 58);
			cboActividad.Name = "cboActividad";
			cboActividad.Size = new Size(265, 23);
			cboActividad.TabIndex = 26;
			cboActividad.TextUpdate += cboActividad_TextUpdate;
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblActividad.Location = new Point(6, 40);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(161, 15);
			lblActividad.TabIndex = 24;
			lblActividad.Text = "Actividad (Aplica Seleccion) :";
			// 
			// dgvAgregarLoteyActividad
			// 
			dgvAgregarLoteyActividad.AllowUserToAddRows = false;
			dgvAgregarLoteyActividad.AllowUserToDeleteRows = false;
			dgvAgregarLoteyActividad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvAgregarLoteyActividad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvAgregarLoteyActividad.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvAgregarLoteyActividad.BackgroundColor = SystemColors.Control;
			dgvAgregarLoteyActividad.BorderStyle = BorderStyle.Fixed3D;
			dgvAgregarLoteyActividad.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvAgregarLoteyActividad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvAgregarLoteyActividad.ColumnHeadersHeight = 29;
			dgvAgregarLoteyActividad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvAgregarLoteyActividad.EnableHeadersVisualStyles = false;
			dgvAgregarLoteyActividad.ImeMode = ImeMode.NoControl;
			dgvAgregarLoteyActividad.Location = new Point(8, 290);
			dgvAgregarLoteyActividad.Name = "dgvAgregarLoteyActividad";
			dgvAgregarLoteyActividad.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvAgregarLoteyActividad.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvAgregarLoteyActividad.RowHeadersVisible = false;
			dgvAgregarLoteyActividad.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvAgregarLoteyActividad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvAgregarLoteyActividad.Size = new Size(905, 402);
			dgvAgregarLoteyActividad.TabIndex = 41;
			dgvAgregarLoteyActividad.KeyDown += dgvAgregarLoteyActividad_KeyDown;
			// 
			// btnCancelar
			// 
			btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnCancelar.BackgroundImageLayout = ImageLayout.Zoom;
			btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
			btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancelar.Location = new Point(653, 702);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Padding = new Padding(10, 0, 10, 0);
			btnCancelar.Size = new Size(110, 27);
			btnCancelar.TabIndex = 43;
			btnCancelar.Text = "Cancelar";
			btnCancelar.TextAlign = ContentAlignment.MiddleRight;
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// btnContinuar
			// 
			btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			btnContinuar.Image = (Image)resources.GetObject("btnContinuar.Image");
			btnContinuar.ImageAlign = ContentAlignment.MiddleLeft;
			btnContinuar.Location = new Point(803, 702);
			btnContinuar.Name = "btnContinuar";
			btnContinuar.Padding = new Padding(6, 0, 6, 0);
			btnContinuar.Size = new Size(110, 27);
			btnContinuar.TabIndex = 42;
			btnContinuar.Text = "Continuar";
			btnContinuar.TextAlign = ContentAlignment.MiddleRight;
			btnContinuar.UseVisualStyleBackColor = true;
			btnContinuar.Click += btnContinuar_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(560, 43);
			label1.Name = "label1";
			label1.Size = new Size(30, 17);
			label1.TabIndex = 44;
			label1.Text = "Dia:";
			// 
			// FrmAgregarLoteyActividad
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(925, 741);
			Controls.Add(label1);
			Controls.Add(btnCancelar);
			Controls.Add(btnContinuar);
			Controls.Add(dgvAgregarLoteyActividad);
			Controls.Add(groupBox1);
			Controls.Add(cboFecha);
			Controls.Add(lblSubtitulo);
			Controls.Add(pictureBox1);
			Controls.Add(lblTitulo);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAgregarLoteyActividad";
			Text = "Agregar Lote y Actividad";
			Load += FrmAgregarLoteyActividad_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgvAgregarLoteyActividad).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public ComboBox cboFecha;
		public Label lblSubtitulo;
		private PictureBox pictureBox1;
		public Label lblTitulo;
		private GroupBox groupBox1;
		public ComboBox cboLote;
		public Label lblLote;
		public ComboBox cboActividad;
		public Label lblActividad;
		public DataGridView dgvAgregarLoteyActividad;
		public Button btnCancelar;
		public Button btnContinuar;
		private Label label1;
		public Button btnAsignar;
		public ComboBox cboCultivo;
		public Label label2;
		public Button btnLote;
	}
}
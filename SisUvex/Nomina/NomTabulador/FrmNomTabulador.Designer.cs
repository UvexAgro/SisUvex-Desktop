namespace SisUvex.Nomina.NomTabulador
{
	partial class FrmNomTabulador
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNomTabulador));
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			btnModify = new Button();
			dgvCatalog = new DataGridView();
			cboSeason = new ComboBox();
			lblSeason = new Label();
			panel1 = new Panel();
			pictureBox1 = new PictureBox();
			label2 = new Label();
			label1 = new Label();
			btnActualizar = new Button();
			txbBuscar = new TextBox();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// btnModify
			// 
			btnModify.BackgroundImageLayout = ImageLayout.Zoom;
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(320, 125);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(8, 0, 8, 0);
			btnModify.Size = new Size(105, 33);
			btnModify.TabIndex = 3;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// dgvCatalog
			// 
			dgvCatalog.AllowUserToAddRows = false;
			dgvCatalog.AllowUserToDeleteRows = false;
			dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvCatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvCatalog.BackgroundColor = SystemColors.ControlLightLight;
			dgvCatalog.BorderStyle = BorderStyle.Fixed3D;
			dgvCatalog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgvCatalog.ColumnHeadersHeight = 29;
			dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCatalog.EnableHeadersVisualStyles = false;
			dgvCatalog.ImeMode = ImeMode.NoControl;
			dgvCatalog.Location = new Point(12, 164);
			dgvCatalog.Name = "dgvCatalog";
			dgvCatalog.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvCatalog.RowHeadersVisible = false;
			dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCatalog.Size = new Size(1209, 956);
			dgvCatalog.TabIndex = 13;
			// 
			// cboSeason
			// 
			cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSeason.FormattingEnabled = true;
			cboSeason.Location = new Point(95, 135);
			cboSeason.Name = "cboSeason";
			cboSeason.Size = new Size(200, 23);
			cboSeason.TabIndex = 22;
			cboSeason.SelectedIndexChanged += cboSeason_SelectedIndexChanged;
			// 
			// lblSeason
			// 
			lblSeason.AutoSize = true;
			lblSeason.Location = new Point(15, 137);
			lblSeason.Name = "lblSeason";
			lblSeason.Size = new Size(67, 15);
			lblSeason.TabIndex = 23;
			lblSeason.Text = "Temporada";
			// 
			// panel1
			// 
			panel1.BackColor = Color.FromArgb(35, 103, 149);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(12, 9);
			panel1.Margin = new Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(1209, 107);
			panel1.TabIndex = 24;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(13, 9);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(91, 85);
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = SystemColors.ControlLightLight;
			label2.Location = new Point(120, 70);
			label2.Name = "label2";
			label2.Size = new Size(342, 20);
			label2.TabIndex = 2;
			label2.Text = "Administra los salarios y comisiones por actividad.";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(119, 18);
			label1.Name = "label1";
			label1.Size = new Size(343, 37);
			label1.TabIndex = 1;
			label1.Text = "TABULADOR DE NÓMINA";
			// 
			// btnActualizar
			// 
			btnActualizar.BackgroundImageLayout = ImageLayout.Zoom;
			btnActualizar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
			btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
			btnActualizar.Location = new Point(1080, 120);
			btnActualizar.Name = "btnActualizar";
			btnActualizar.Padding = new Padding(15, 0, 15, 0);
			btnActualizar.Size = new Size(141, 40);
			btnActualizar.TabIndex = 26;
			btnActualizar.Text = "Actualizar";
			btnActualizar.TextAlign = ContentAlignment.MiddleRight;
			btnActualizar.UseVisualStyleBackColor = true;
			btnActualizar.Click += btnActualizar_Click;
			// 
			// txbBuscar
			// 
			txbBuscar.Location = new Point(538, 129);
			txbBuscar.Name = "txbBuscar";
			txbBuscar.Size = new Size(297, 23);
			txbBuscar.TabIndex = 25;
			txbBuscar.TextChanged += txbBuscar_TextChanged;
			txbBuscar.Enter += txbBuscar_Enter;
			txbBuscar.Leave += txbBuscar_Leave;
			// 
			// FrmNomTabulador
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1233, 1142);
			Controls.Add(btnActualizar);
			Controls.Add(txbBuscar);
			Controls.Add(panel1);
			Controls.Add(cboSeason);
			Controls.Add(lblSeason);
			Controls.Add(dgvCatalog);
			Controls.Add(btnModify);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmNomTabulador";
			Text = "Tabulador de Nomina";
			Load += FrmNomTabulador_Load;
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnModify;
		public DataGridView dgvCatalog;
		public ComboBox cboSeason;
		private Label lblSeason;
		private Panel panel1;
		private Label label2;
		private Label label1;
		private PictureBox pictureBox1;
		private TextBox txbBuscar;
		private Button btnActualizar;
	}
}
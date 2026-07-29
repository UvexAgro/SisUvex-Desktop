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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			btnModify = new Button();
			dgvCatalog = new DataGridView();
			cboSeason = new ComboBox();
			lblSeason = new Label();
			panel1 = new Panel();
			label2 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// btnModify
			// 
			btnModify.BackgroundImageLayout = ImageLayout.Zoom;
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(364, 114);
			btnModify.Margin = new Padding(3, 4, 3, 4);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(120, 28);
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
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvCatalog.ColumnHeadersHeight = 29;
			dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCatalog.EnableHeadersVisualStyles = false;
			dgvCatalog.ImeMode = ImeMode.NoControl;
			dgvCatalog.Location = new Point(14, 150);
			dgvCatalog.Margin = new Padding(3, 4, 3, 4);
			dgvCatalog.Name = "dgvCatalog";
			dgvCatalog.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvCatalog.RowHeadersVisible = false;
			dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCatalog.Size = new Size(887, 421);
			dgvCatalog.TabIndex = 13;
			// 
			// cboSeason
			// 
			cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSeason.FormattingEnabled = true;
			cboSeason.Location = new Point(106, 114);
			cboSeason.Margin = new Padding(3, 4, 3, 4);
			cboSeason.Name = "cboSeason";
			cboSeason.Size = new Size(228, 28);
			cboSeason.TabIndex = 22;
			cboSeason.SelectedIndexChanged += cboSeason_SelectedIndexChanged;
			// 
			// lblSeason
			// 
			lblSeason.AutoSize = true;
			lblSeason.Location = new Point(15, 117);
			lblSeason.Name = "lblSeason";
			lblSeason.Size = new Size(85, 20);
			lblSeason.TabIndex = 23;
			lblSeason.Text = "Temporada";
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.GradientInactiveCaption;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(14, 12);
			panel1.Name = "panel1";
			panel1.Size = new Size(887, 82);
			panel1.TabIndex = 24;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(18, 50);
			label2.Name = "label2";
			label2.Size = new Size(342, 20);
			label2.TabIndex = 2;
			label2.Text = "Administra los salarios y comisiones por actividad.";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(18, 10);
			label1.Name = "label1";
			label1.Size = new Size(282, 31);
			label1.TabIndex = 1;
			label1.Text = "TABULADOR DE NÓMINA";
			// 
			// FrmNomTabulador
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(914, 600);
			Controls.Add(panel1);
			Controls.Add(cboSeason);
			Controls.Add(lblSeason);
			Controls.Add(dgvCatalog);
			Controls.Add(btnModify);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmNomTabulador";
			Text = "Tabulador de Nomina";
			Load += FrmNomTabulador_Load;
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
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
	}
}
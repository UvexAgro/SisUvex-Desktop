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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNomTabulador));
			btnModify = new Button();
			dgvCatalog = new DataGridView();
			cboSeason = new ComboBox();
			lblSeason = new Label();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
			SuspendLayout();
			// 
			// btnModify
			// 
			btnModify.Location = new Point(12, 12);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(75, 23);
			btnModify.TabIndex = 3;
			btnModify.Text = "Modificar";
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
			dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCatalog.EnableHeadersVisualStyles = false;
			dgvCatalog.ImeMode = ImeMode.NoControl;
			dgvCatalog.Location = new Point(12, 41);
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
			dgvCatalog.Size = new Size(776, 387);
			dgvCatalog.TabIndex = 13;
			// 
			// cboSeason
			// 
			cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSeason.FormattingEnabled = true;
			cboSeason.Location = new Point(199, 13);
			cboSeason.Name = "cboSeason";
			cboSeason.Size = new Size(200, 23);
			cboSeason.TabIndex = 22;
			cboSeason.SelectedIndexChanged += cboSeason_SelectedIndexChanged;
			// 
			// lblSeason
			// 
			lblSeason.AutoSize = true;
			lblSeason.Location = new Point(131, 16);
			lblSeason.Name = "lblSeason";
			lblSeason.Size = new Size(67, 15);
			lblSeason.TabIndex = 23;
			lblSeason.Text = "Temporada";
			// 
			// FrmNomTabulador
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(cboSeason);
			Controls.Add(lblSeason);
			Controls.Add(dgvCatalog);
			Controls.Add(btnModify);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmNomTabulador";
			Text = "Tabulador de Nomina";
			Load += FrmNomTabulador_Load;
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnModify;
		public DataGridView dgvCatalog;
		public ComboBox cboSeason;
		private Label lblSeason;
	}
}
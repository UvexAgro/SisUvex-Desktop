namespace SisUvex.Nomina.Nom_Descuento_de_personal
{
	partial class FrmDescuento
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDescuento));
			btnAdd = new Button();
			btnModify = new Button();
			btnRemove = new Button();
			dgvCatalog = new DataGridView();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
			SuspendLayout();
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(12, 12);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(75, 23);
			btnAdd.TabIndex = 2;
			btnAdd.Text = "Añadir";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnModify
			// 
			btnModify.Location = new Point(93, 12);
			btnModify.Name = "btnModify";
			btnModify.Size = new Size(75, 23);
			btnModify.TabIndex = 3;
			btnModify.Text = "Modificar";
			btnModify.UseVisualStyleBackColor = true;
			// 
			// btnRemove
			// 
			btnRemove.Location = new Point(174, 12);
			btnRemove.Name = "btnRemove";
			btnRemove.Size = new Size(75, 23);
			btnRemove.TabIndex = 5;
			btnRemove.Text = "Eliminar";
			btnRemove.UseVisualStyleBackColor = true;
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
			dgvCatalog.TabIndex = 12;
			// 
			// FrmDescuento
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(dgvCatalog);
			Controls.Add(btnRemove);
			Controls.Add(btnModify);
			Controls.Add(btnAdd);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmDescuento";
			Text = "Descuento de Personal por Linea ";
			Load += FrmDescuento_Load;
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnAdd;
		private Button btnModify;
		private Button btnRemove;
		public DataGridView dgvCatalog;
	}
}
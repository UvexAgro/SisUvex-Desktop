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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDescuento));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			btnAdd = new Button();
			btnModify = new Button();
			btnRemove = new Button();
			dgvCatalog = new DataGridView();
			panel1 = new Panel();
			label2 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// btnAdd
			// 
			btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
			btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
			btnAdd.Location = new Point(15, 68);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(8, 0, 8, 0);
			btnAdd.Size = new Size(96, 23);
			btnAdd.TabIndex = 2;
			btnAdd.Text = "Añadir";
			btnAdd.TextAlign = ContentAlignment.MiddleRight;
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnModify
			// 
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(126, 68);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(5, 0, 5, 0);
			btnModify.Size = new Size(96, 23);
			btnModify.TabIndex = 3;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnRemove
			// 
			btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
			btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
			btnRemove.Location = new Point(237, 68);
			btnRemove.Name = "btnRemove";
			btnRemove.Padding = new Padding(5, 0, 5, 0);
			btnRemove.Size = new Size(96, 23);
			btnRemove.TabIndex = 5;
			btnRemove.Text = "Eliminar";
			btnRemove.TextAlign = ContentAlignment.MiddleRight;
			btnRemove.UseVisualStyleBackColor = true;
			btnRemove.Click += btnRemove_Click;
			// 
			// dgvCatalog
			// 
			dgvCatalog.AllowUserToAddRows = false;
			dgvCatalog.AllowUserToDeleteRows = false;
			dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
			dgvCatalog.Location = new Point(10, 97);
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
			dgvCatalog.Size = new Size(776, 344);
			dgvCatalog.TabIndex = 12;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.GradientActiveCaption;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(10, 9);
			panel1.Margin = new Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(778, 53);
			panel1.TabIndex = 13;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(5, 30);
			label2.Name = "label2";
			label2.Size = new Size(414, 15);
			label2.TabIndex = 1;
			label2.Text = "Administra los descuentos de personal asignados a cada línea de producción.";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(4, 7);
			label1.Name = "label1";
			label1.Size = new Size(297, 21);
			label1.TabIndex = 0;
			label1.Text = "DESCUENTOS DE PERSONAL POR LÍNEA";
			// 
			// FrmDescuento
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel1);
			Controls.Add(dgvCatalog);
			Controls.Add(btnRemove);
			Controls.Add(btnModify);
			Controls.Add(btnAdd);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmDescuento";
			Text = "Descuento de Personal por Linea ";
			Load += FrmDescuento_Load;
			((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button btnAdd;
		private Button btnModify;
		private Button btnRemove;
		public DataGridView dgvCatalog;
		private Panel panel1;
		private Label label2;
		private Label label1;
	}
}
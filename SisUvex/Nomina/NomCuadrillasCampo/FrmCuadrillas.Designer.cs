namespace SisUvex.Nomina.NomCuadrillasCampo
{
	partial class FrmCuadrillas
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCuadrillas));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			panel1 = new Panel();
			btnRemove = new Button();
			pictureBox1 = new PictureBox();
			btnModify = new Button();
			label2 = new Label();
			btnAdd = new Button();
			label1 = new Label();
			dgvCuadrillas = new DataGridView();
			panel2 = new Panel();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvCuadrillas).BeginInit();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveCaption;
			panel1.Location = new Point(2, 15);
			panel1.Name = "panel1";
			panel1.Size = new Size(5, 76);
			panel1.TabIndex = 13;
			// 
			// btnRemove
			// 
			btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
			btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
			btnRemove.Location = new Point(573, 66);
			btnRemove.Name = "btnRemove";
			btnRemove.Padding = new Padding(5, 0, 5, 0);
			btnRemove.Size = new Size(97, 34);
			btnRemove.TabIndex = 15;
			btnRemove.Text = "Eliminar";
			btnRemove.TextAlign = ContentAlignment.MiddleRight;
			btnRemove.UseVisualStyleBackColor = true;
			btnRemove.Click += btnRemove_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(21, 19);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(50, 50);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// btnModify
			// 
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(474, 66);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(5, 0, 5, 0);
			btnModify.Size = new Size(97, 34);
			btnModify.TabIndex = 14;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(85, 54);
			label2.Name = "label2";
			label2.Size = new Size(209, 15);
			label2.TabIndex = 1;
			label2.Text = "Catálogo de cuadrillas para nómina     ";
			// 
			// btnAdd
			// 
			btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
			btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
			btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
			btnAdd.Location = new Point(371, 66);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(8, 0, 8, 0);
			btnAdd.Size = new Size(97, 34);
			btnAdd.TabIndex = 13;
			btnAdd.Text = "Añadir";
			btnAdd.TextAlign = ContentAlignment.MiddleRight;
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(85, 24);
			label1.Name = "label1";
			label1.Size = new Size(262, 30);
			label1.TabIndex = 0;
			label1.Text = "CUADRILLAS DE CAMPO ";
			// 
			// dgvCuadrillas
			// 
			dgvCuadrillas.AllowUserToAddRows = false;
			dgvCuadrillas.AllowUserToDeleteRows = false;
			dgvCuadrillas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dgvCuadrillas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvCuadrillas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvCuadrillas.BackgroundColor = SystemColors.Control;
			dgvCuadrillas.BorderStyle = BorderStyle.Fixed3D;
			dgvCuadrillas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvCuadrillas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvCuadrillas.ColumnHeadersHeight = 29;
			dgvCuadrillas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCuadrillas.EnableHeadersVisualStyles = false;
			dgvCuadrillas.ImeMode = ImeMode.NoControl;
			dgvCuadrillas.Location = new Point(3, 112);
			dgvCuadrillas.Name = "dgvCuadrillas";
			dgvCuadrillas.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvCuadrillas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvCuadrillas.RowHeadersVisible = false;
			dgvCuadrillas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvCuadrillas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCuadrillas.Size = new Size(681, 625);
			dgvCuadrillas.TabIndex = 12;
			// 
			// panel2
			// 
			panel2.BackColor = Color.FromArgb(247, 248, 250);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(panel1);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(btnModify);
			panel2.Controls.Add(btnRemove);
			panel2.Controls.Add(btnAdd);
			panel2.Controls.Add(pictureBox1);
			panel2.Location = new Point(3, 1);
			panel2.Name = "panel2";
			panel2.Size = new Size(681, 105);
			panel2.TabIndex = 16;
			// 
			// FrmCuadrillas
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(939, 749);
			Controls.Add(panel2);
			Controls.Add(dgvCuadrillas);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmCuadrillas";
			Text = "Cuadrillas de Nomina";
			Load += FrmCuadrillas_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvCuadrillas).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private Label label2;
		private Label label1;
		public DataGridView dgvCuadrillas;
		private Button btnRemove;
		private Button btnModify;
		private Button btnAdd;
		private PictureBox pictureBox1;
		private Panel panel1;
		private Panel panel2;
	}
}
namespace SisUvex.Nomina.Catalago_Costo_de_Cuadros
{
	partial class FrmCostos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCostos));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			panel2 = new Panel();
			label1 = new Label();
			panel1 = new Panel();
			label2 = new Label();
			btnModify = new Button();
			btnRemove = new Button();
			btnAdd = new Button();
			pictureBox1 = new PictureBox();
			dgvCuadroCosto = new DataGridView();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvCuadroCosto).BeginInit();
			SuspendLayout();
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
			panel2.Location = new Point(3, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(776, 126);
			panel2.TabIndex = 18;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(95, 34);
			label1.Name = "label1";
			label1.Size = new Size(158, 30);
			label1.TabIndex = 0;
			label1.Text = "Costo por Lote";
			// 
			// panel1
			// 
			panel1.BackColor = Color.FromArgb(35, 103, 149);
			panel1.Location = new Point(2, 16);
			panel1.Name = "panel1";
			panel1.Size = new Size(5, 94);
			panel1.TabIndex = 13;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.ForeColor = Color.DimGray;
			label2.Location = new Point(95, 74);
			label2.Name = "label2";
			label2.Size = new Size(274, 15);
			label2.TabIndex = 1;
			label2.Text = "Consulta y registro de costos asociados a cada lote";
			// 
			// btnModify
			// 
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(570, 85);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(5, 0, 5, 0);
			btnModify.Size = new Size(97, 34);
			btnModify.TabIndex = 14;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnRemove
			// 
			btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
			btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
			btnRemove.Location = new Point(669, 85);
			btnRemove.Name = "btnRemove";
			btnRemove.Padding = new Padding(5, 0, 5, 0);
			btnRemove.Size = new Size(97, 34);
			btnRemove.TabIndex = 15;
			btnRemove.Text = "Eliminar";
			btnRemove.TextAlign = ContentAlignment.MiddleRight;
			btnRemove.UseVisualStyleBackColor = true;
			btnRemove.Click += btnRemove_Click;
			// 
			// btnAdd
			// 
			btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
			btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
			btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
			btnAdd.Location = new Point(467, 85);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(8, 0, 8, 0);
			btnAdd.Size = new Size(97, 34);
			btnAdd.TabIndex = 13;
			btnAdd.Text = "Añadir";
			btnAdd.TextAlign = ContentAlignment.MiddleRight;
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(13, 19);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(58, 85);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// dgvCuadroCosto
			// 
			dgvCuadroCosto.AllowUserToAddRows = false;
			dgvCuadroCosto.AllowUserToDeleteRows = false;
			dgvCuadroCosto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dgvCuadroCosto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvCuadroCosto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvCuadroCosto.BackgroundColor = SystemColors.Control;
			dgvCuadroCosto.BorderStyle = BorderStyle.Fixed3D;
			dgvCuadroCosto.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvCuadroCosto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvCuadroCosto.ColumnHeadersHeight = 29;
			dgvCuadroCosto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvCuadroCosto.EnableHeadersVisualStyles = false;
			dgvCuadroCosto.ImeMode = ImeMode.NoControl;
			dgvCuadroCosto.Location = new Point(5, 135);
			dgvCuadroCosto.Name = "dgvCuadroCosto";
			dgvCuadroCosto.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvCuadroCosto.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvCuadroCosto.RowHeadersVisible = false;
			dgvCuadroCosto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvCuadroCosto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCuadroCosto.Size = new Size(921, 1014);
			dgvCuadroCosto.TabIndex = 19;
			// 
			// FrmCostos
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(938, 1154);
			Controls.Add(dgvCuadroCosto);
			Controls.Add(panel2);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmCostos";
			Text = "Catalago Costo de lote Aplicadores";
			Load += FrmCostos_Load;
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvCuadroCosto).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel2;
		private Label label1;
		private Panel panel1;
		private Label label2;
		private Button btnModify;
		private Button btnRemove;
		private Button btnAdd;
		private PictureBox pictureBox1;
		public DataGridView dgvCuadroCosto;
	}
}
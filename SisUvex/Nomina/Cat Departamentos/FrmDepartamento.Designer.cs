namespace SisUvex.Nomina.Cat_Departamentos
{
	partial class FrmDepartamento
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartamento));
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
			dgvDepartamento = new DataGridView();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvDepartamento).BeginInit();
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
			panel2.Location = new Point(3, 2);
			panel2.Name = "panel2";
			panel2.Size = new Size(776, 126);
			panel2.TabIndex = 17;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(95, 34);
			label1.Name = "label1";
			label1.Size = new Size(352, 30);
			label1.TabIndex = 0;
			label1.Text = "DEPARTAMENTO POR CUADRILLA";
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
			label2.Location = new Point(95, 74);
			label2.Name = "label2";
			label2.Size = new Size(158, 15);
			label2.TabIndex = 1;
			label2.Text = "Catálogo de Departamentos ";
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
			// dgvDepartamento
			// 
			dgvDepartamento.AllowUserToAddRows = false;
			dgvDepartamento.AllowUserToDeleteRows = false;
			dgvDepartamento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dgvDepartamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvDepartamento.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvDepartamento.BackgroundColor = SystemColors.Control;
			dgvDepartamento.BorderStyle = BorderStyle.Fixed3D;
			dgvDepartamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvDepartamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvDepartamento.ColumnHeadersHeight = 29;
			dgvDepartamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvDepartamento.EnableHeadersVisualStyles = false;
			dgvDepartamento.ImeMode = ImeMode.NoControl;
			dgvDepartamento.Location = new Point(3, 143);
			dgvDepartamento.Name = "dgvDepartamento";
			dgvDepartamento.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvDepartamento.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvDepartamento.RowHeadersVisible = false;
			dgvDepartamento.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvDepartamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvDepartamento.Size = new Size(776, 1023);
			dgvDepartamento.TabIndex = 18;
			// 
			// FrmDepartamento
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(783, 1178);
			Controls.Add(dgvDepartamento);
			Controls.Add(panel2);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmDepartamento";
			Text = "Catalgo Departamentos";
			Load += FrmDepartamento_Load;
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvDepartamento).EndInit();
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
		public DataGridView dgvDepartamento;
	}
}
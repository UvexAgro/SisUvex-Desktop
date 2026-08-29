namespace SisUvex.Nomina.Nom_Horarios_de_Campo
{
	partial class FrmHorarios
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHorarios));
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			label1 = new Label();
			pictureBox1 = new PictureBox();
			dgvHorarios = new DataGridView();
			btnModify = new Button();
			btnRemove = new Button();
			btnAdd = new Button();
			panel1 = new Panel();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvHorarios).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(97, 9);
			label1.Name = "label1";
			label1.Size = new Size(257, 32);
			label1.TabIndex = 0;
			label1.Text = "Registro de Horarios ";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(12, 9);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(64, 51);
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// dgvHorarios
			// 
			dgvHorarios.AllowUserToAddRows = false;
			dgvHorarios.AllowUserToDeleteRows = false;
			dgvHorarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvHorarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvHorarios.BackgroundColor = SystemColors.Control;
			dgvHorarios.BorderStyle = BorderStyle.Fixed3D;
			dgvHorarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvHorarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvHorarios.ColumnHeadersHeight = 29;
			dgvHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvHorarios.EnableHeadersVisualStyles = false;
			dgvHorarios.ImeMode = ImeMode.NoControl;
			dgvHorarios.Location = new Point(12, 129);
			dgvHorarios.Name = "dgvHorarios";
			dgvHorarios.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvHorarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvHorarios.RowHeadersVisible = false;
			dgvHorarios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvHorarios.Size = new Size(766, 672);
			dgvHorarios.TabIndex = 13;
			// 
			// btnModify
			// 
			btnModify.Image = (Image)resources.GetObject("btnModify.Image");
			btnModify.ImageAlign = ContentAlignment.MiddleLeft;
			btnModify.Location = new Point(573, 89);
			btnModify.Name = "btnModify";
			btnModify.Padding = new Padding(5, 0, 5, 0);
			btnModify.Size = new Size(97, 34);
			btnModify.TabIndex = 17;
			btnModify.Text = "Modificar";
			btnModify.TextAlign = ContentAlignment.MiddleRight;
			btnModify.UseVisualStyleBackColor = true;
			btnModify.Click += btnModify_Click;
			// 
			// btnRemove
			// 
			btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
			btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
			btnRemove.Location = new Point(672, 89);
			btnRemove.Name = "btnRemove";
			btnRemove.Padding = new Padding(5, 0, 5, 0);
			btnRemove.Size = new Size(97, 34);
			btnRemove.TabIndex = 18;
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
			btnAdd.Location = new Point(470, 89);
			btnAdd.Name = "btnAdd";
			btnAdd.Padding = new Padding(8, 0, 8, 0);
			btnAdd.Size = new Size(97, 34);
			btnAdd.TabIndex = 16;
			btnAdd.Text = "Añadir";
			btnAdd.TextAlign = ContentAlignment.MiddleRight;
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// panel1
			// 
			panel1.BackColor = Color.Gainsboro;
			panel1.Location = new Point(15, 78);
			panel1.Name = "panel1";
			panel1.Size = new Size(763, 2);
			panel1.TabIndex = 19;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.DimGray;
			label2.Location = new Point(97, 45);
			label2.Name = "label2";
			label2.Size = new Size(284, 13);
			label2.TabIndex = 20;
			label2.Text = "Admimistra los Rangos de horario del Reloj Checador ";
			// 
			// FrmHorarios
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(788, 813);
			Controls.Add(label2);
			Controls.Add(panel1);
			Controls.Add(btnModify);
			Controls.Add(btnRemove);
			Controls.Add(btnAdd);
			Controls.Add(dgvHorarios);
			Controls.Add(pictureBox1);
			Controls.Add(label1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmHorarios";
			Text = "Registro de Horarios";
			Load += FrmHorarios_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvHorarios).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private PictureBox pictureBox1;
		public DataGridView dgvHorarios;
		private Button btnModify;
		private Button btnRemove;
		private Button btnAdd;
		private Panel panel1;
		private Label label2;
	}
}
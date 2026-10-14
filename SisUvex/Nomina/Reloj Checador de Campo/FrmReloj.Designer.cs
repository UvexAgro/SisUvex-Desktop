namespace SisUvex.Nomina.Reloj_Checador_de_Campo
{
	partial class FrmReloj
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReloj));
			dgvLista = new DataGridView();
			groupBox1 = new GroupBox();
			btnConsultar = new Button();
			dtpFecha = new Label();
			dateTimePicker1 = new DateTimePicker();
			txbCodigo = new TextBox();
			label2 = new Label();
			txbEmpleado = new TextBox();
			label1 = new Label();
			panel2 = new Panel();
			pictureBox1 = new PictureBox();
			label3 = new Label();
			label4 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// dgvLista
			// 
			dgvLista.AllowUserToAddRows = false;
			dgvLista.AllowUserToDeleteRows = false;
			dgvLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvLista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvLista.BackgroundColor = SystemColors.ControlLightLight;
			dgvLista.BorderStyle = BorderStyle.Fixed3D;
			dgvLista.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvLista.ColumnHeadersHeight = 29;
			dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvLista.EnableHeadersVisualStyles = false;
			dgvLista.ImeMode = ImeMode.NoControl;
			dgvLista.Location = new Point(2, 233);
			dgvLista.Name = "dgvLista";
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvLista.RowHeadersVisible = false;
			dgvLista.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvLista.Size = new Size(1513, 925);
			dgvLista.TabIndex = 4;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = Color.FromArgb(236, 243, 249);
			groupBox1.Controls.Add(btnConsultar);
			groupBox1.Controls.Add(dtpFecha);
			groupBox1.Controls.Add(dateTimePicker1);
			groupBox1.Controls.Add(txbCodigo);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(txbEmpleado);
			groupBox1.Controls.Add(label1);
			groupBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(3, 101);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(1270, 130);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Filtro de Busqueda";
			// 
			// btnConsultar
			// 
			btnConsultar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
			btnConsultar.ImageAlign = ContentAlignment.MiddleLeft;
			btnConsultar.Location = new Point(883, 67);
			btnConsultar.Name = "btnConsultar";
			btnConsultar.Padding = new Padding(20, 0, 20, 0);
			btnConsultar.Size = new Size(152, 33);
			btnConsultar.TabIndex = 7;
			btnConsultar.Text = "Consultar";
			btnConsultar.TextAlign = ContentAlignment.MiddleRight;
			btnConsultar.UseVisualStyleBackColor = true;
			btnConsultar.Click += btnConsultar_Click;
			// 
			// dtpFecha
			// 
			dtpFecha.AutoSize = true;
			dtpFecha.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dtpFecha.Location = new Point(522, 53);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(46, 17);
			dtpFecha.TabIndex = 6;
			dtpFecha.Text = "Fecha:";
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.CustomFormat = "";
			dateTimePicker1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			dateTimePicker1.Location = new Point(522, 73);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(297, 25);
			dateTimePicker1.TabIndex = 4;
			// 
			// txbCodigo
			// 
			txbCodigo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			txbCodigo.Location = new Point(10, 73);
			txbCodigo.MaxLength = 6;
			txbCodigo.Name = "txbCodigo";
			txbCodigo.Size = new Size(116, 27);
			txbCodigo.TabIndex = 3;
			txbCodigo.KeyDown += txbCodigo_KeyDown;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(10, 53);
			label2.Name = "label2";
			label2.Size = new Size(54, 17);
			label2.TabIndex = 2;
			label2.Text = "Codigo:";
			// 
			// txbEmpleado
			// 
			txbEmpleado.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			txbEmpleado.Location = new Point(159, 73);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.ReadOnly = true;
			txbEmpleado.Size = new Size(289, 27);
			txbEmpleado.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(159, 53);
			label1.Name = "label1";
			label1.Size = new Size(71, 17);
			label1.TabIndex = 0;
			label1.Text = "Empleado:";
			// 
			// panel2
			// 
			panel2.BackColor = Color.FromArgb(35, 103, 149);
			panel2.Controls.Add(pictureBox1);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(label4);
			panel2.Location = new Point(2, 3);
			panel2.Name = "panel2";
			panel2.Size = new Size(1271, 95);
			panel2.TabIndex = 7;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(11, 10);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(83, 69);
			pictureBox1.TabIndex = 10;
			pictureBox1.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.ForeColor = Color.White;
			label3.Location = new Point(100, 61);
			label3.Name = "label3";
			label3.Size = new Size(903, 15);
			label3.TabIndex = 9;
			label3.Text = "Consulta los registros de entrada y salida de cada empleado, seleccionando una fecha específica y buscando por su código o nombre para revisar sus horarios de checada.";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.White;
			label4.Location = new Point(100, 10);
			label4.Name = "label4";
			label4.Size = new Size(579, 37);
			label4.TabIndex = 8;
			label4.Text = "Consulta de Asistencia en el Reloj Checador ";
			// 
			// FrmReloj
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(244, 247, 251);
			ClientSize = new Size(1518, 1177);
			Controls.Add(panel2);
			Controls.Add(groupBox1);
			Controls.Add(dgvLista);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmReloj";
			Text = "Reloj Checador";
			Load += FrmReloj_Load;
			((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		public DataGridView dgvLista;
		private GroupBox groupBox1;
		private TextBox txbEmpleado;
		private Label label1;
		private Label label3;
		private DateTimePicker dateTimePicker1;
		private TextBox txbCodigo;
		private Label label2;
		public Label dtpFecha;
		private Button btnConsultar;
		private Panel panel2;
		private Label label4;
		private PictureBox pictureBox1;
	}
}
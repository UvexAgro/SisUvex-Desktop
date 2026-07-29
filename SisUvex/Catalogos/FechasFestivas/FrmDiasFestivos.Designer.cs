namespace SisUvex.Catalogos.FechasFestivas
{
	partial class FrmDiasFestivos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiasFestivos));
			lblAdd = new Label();
			lblConcepto = new Label();
			txbDescripccion = new TextBox();
			lblId = new Label();
			txbId = new TextBox();
			btnAccept = new Button();
			btnCancel = new Button();
			lblFecha = new Label();
			dtpDay = new DateTimePicker();
			panel1 = new Panel();
			pictureBox1 = new PictureBox();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Arial Black", 16F);
			lblAdd.Location = new Point(157, 26);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(211, 38);
			lblAdd.TabIndex = 71;
			lblAdd.Text = "Añadir Fecha";
			// 
			// lblConcepto
			// 
			lblConcepto.AutoSize = true;
			lblConcepto.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblConcepto.Location = new Point(12, 258);
			lblConcepto.Name = "lblConcepto";
			lblConcepto.Size = new Size(110, 23);
			lblConcepto.TabIndex = 95;
			lblConcepto.Text = "Descripccion:";
			// 
			// txbDescripccion
			// 
			txbDescripccion.Font = new Font("Segoe UI", 12F);
			txbDescripccion.Location = new Point(12, 285);
			txbDescripccion.Margin = new Padding(3, 4, 3, 4);
			txbDescripccion.MaxLength = 300;
			txbDescripccion.Name = "txbDescripccion";
			txbDescripccion.Size = new Size(418, 34);
			txbDescripccion.TabIndex = 98;
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblId.Location = new Point(12, 115);
			lblId.Name = "lblId";
			lblId.Size = new Size(29, 23);
			lblId.TabIndex = 99;
			lblId.Text = "Id:";
			// 
			// txbId
			// 
			txbId.Enabled = false;
			txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbId.Location = new Point(12, 142);
			txbId.Margin = new Padding(3, 4, 3, 4);
			txbId.Name = "txbId";
			txbId.Size = new Size(77, 34);
			txbId.TabIndex = 100;
			txbId.TextAlign = HorizontalAlignment.Center;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(235, 347);
			btnAccept.Margin = new Padding(3, 4, 3, 4);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(86, 39);
			btnAccept.TabIndex = 101;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(346, 347);
			btnCancel.Margin = new Padding(3, 4, 3, 4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(86, 39);
			btnCancel.TabIndex = 102;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// lblFecha
			// 
			lblFecha.AutoSize = true;
			lblFecha.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblFecha.Location = new Point(12, 191);
			lblFecha.Name = "lblFecha";
			lblFecha.Size = new Size(58, 23);
			lblFecha.TabIndex = 103;
			lblFecha.Text = "Fecha:";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(12, 218);
			dtpDay.Margin = new Padding(3, 4, 3, 4);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(281, 27);
			dtpDay.TabIndex = 150;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLightLight;
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(lblAdd);
			panel1.Location = new Point(12, 12);
			panel1.Name = "panel1";
			panel1.Size = new Size(429, 87);
			panel1.TabIndex = 151;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(4, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(96, 81);
			pictureBox1.TabIndex = 152;
			pictureBox1.TabStop = false;
			// 
			// FrmDiasFestivos
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(457, 395);
			Controls.Add(panel1);
			Controls.Add(dtpDay);
			Controls.Add(lblFecha);
			Controls.Add(btnCancel);
			Controls.Add(btnAccept);
			Controls.Add(txbId);
			Controls.Add(lblId);
			Controls.Add(txbDescripccion);
			Controls.Add(lblConcepto);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmDiasFestivos";
			Text = "Dias Festivos";
			Load += FrmDiasFestivos_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Label lblAdd;
		private Label lblConcepto;
		public TextBox txbDescripccion;
		private Label lblId;
		public TextBox txbId;
		private Button btnAccept;
		private Button btnCancel;
		private Label lblFecha;
		public DateTimePicker dtpDay;
		private Panel panel1;
		private PictureBox pictureBox1;
	}
}
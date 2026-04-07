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
			lblAdd = new Label();
			lblConcepto = new Label();
			txbDescripccion = new TextBox();
			lblId = new Label();
			txbId = new TextBox();
			btnAccept = new Button();
			btnCancel = new Button();
			lblFecha = new Label();
			txbFecha = new TextBox();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Arial Black", 16F);
			lblAdd.Location = new Point(12, 19);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(174, 31);
			lblAdd.TabIndex = 71;
			lblAdd.Text = "Añadir Fecha";
			// 
			// lblConcepto
			// 
			lblConcepto.AutoSize = true;
			lblConcepto.Font = new Font("Segoe UI", 12F);
			lblConcepto.Location = new Point(12, 170);
			lblConcepto.Name = "lblConcepto";
			lblConcepto.Size = new Size(101, 21);
			lblConcepto.TabIndex = 95;
			lblConcepto.Text = "Descripccion:";
			// 
			// txbDescripccion
			// 
			txbDescripccion.Font = new Font("Segoe UI", 12F);
			txbDescripccion.Location = new Point(119, 167);
			txbDescripccion.MaxLength = 300;
			txbDescripccion.Name = "txbDescripccion";
			txbDescripccion.Size = new Size(366, 29);
			txbDescripccion.TabIndex = 98;
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Font = new Font("Segoe UI", 12F);
			lblId.Location = new Point(407, 34);
			lblId.Name = "lblId";
			lblId.Size = new Size(26, 21);
			lblId.TabIndex = 99;
			lblId.Text = "Id:";
			// 
			// txbId
			// 
			txbId.Enabled = false;
			txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbId.Location = new Point(439, 26);
			txbId.Name = "txbId";
			txbId.Size = new Size(68, 29);
			txbId.TabIndex = 100;
			txbId.TextAlign = HorizontalAlignment.Center;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(341, 228);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 101;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(432, 228);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 29);
			btnCancel.TabIndex = 102;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// lblFecha
			// 
			lblFecha.AutoSize = true;
			lblFecha.Font = new Font("Segoe UI", 12F);
			lblFecha.Location = new Point(12, 104);
			lblFecha.Name = "lblFecha";
			lblFecha.Size = new Size(53, 21);
			lblFecha.TabIndex = 103;
			lblFecha.Text = "Fecha:";
			// 
			// txbFecha
			// 
			txbFecha.Font = new Font("Segoe UI", 12F);
			txbFecha.Location = new Point(71, 101);
			txbFecha.MaxLength = 15;
			txbFecha.Name = "txbFecha";
			txbFecha.Size = new Size(193, 29);
			txbFecha.TabIndex = 104;
			// 
			// FrmDiasFestivos
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(519, 271);
			Controls.Add(txbFecha);
			Controls.Add(lblFecha);
			Controls.Add(btnCancel);
			Controls.Add(btnAccept);
			Controls.Add(txbId);
			Controls.Add(lblId);
			Controls.Add(txbDescripccion);
			Controls.Add(lblConcepto);
			Controls.Add(lblAdd);
			Name = "FrmDiasFestivos";
			Text = "FrmDiasFestivos";
			Load += FrmDiasFestivos_Load;
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
		public TextBox txbFecha;
	}
}
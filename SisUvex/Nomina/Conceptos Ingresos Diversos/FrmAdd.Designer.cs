namespace SisUvex.Nomina.Conceptos_Ingresos_Diversos
{
	partial class FrmAdd
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdd));
			lblAdd = new Label();
			lblId = new Label();
			txbId = new TextBox();
			lblConcepto = new Label();
			lblMonto = new Label();
			lblHoras = new Label();
			txbConcepto = new TextBox();
			txbMonto = new TextBox();
			txbHoras = new TextBox();
			btnAccept = new Button();
			btnCancel = new Button();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Arial Black", 16F);
			lblAdd.Location = new Point(12, 29);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(217, 31);
			lblAdd.TabIndex = 70;
			lblAdd.Text = "Añadir Concepto";
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Font = new Font("Segoe UI", 12F);
			lblId.Location = new Point(497, 31);
			lblId.Name = "lblId";
			lblId.Size = new Size(26, 21);
			lblId.TabIndex = 92;
			lblId.Text = "Id:";
			// 
			// txbId
			// 
			txbId.Enabled = false;
			txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbId.Location = new Point(529, 27);
			txbId.Name = "txbId";
			txbId.Size = new Size(46, 29);
			txbId.TabIndex = 93;
			txbId.TextAlign = HorizontalAlignment.Center;
			// 
			// lblConcepto
			// 
			lblConcepto.AutoSize = true;
			lblConcepto.Font = new Font("Segoe UI", 12F);
			lblConcepto.Location = new Point(12, 93);
			lblConcepto.Name = "lblConcepto";
			lblConcepto.Size = new Size(79, 21);
			lblConcepto.TabIndex = 94;
			lblConcepto.Text = "Concepto:";
			// 
			// lblMonto
			// 
			lblMonto.AutoSize = true;
			lblMonto.Font = new Font("Segoe UI", 12F);
			lblMonto.Location = new Point(12, 143);
			lblMonto.Name = "lblMonto";
			lblMonto.Size = new Size(59, 21);
			lblMonto.TabIndex = 95;
			lblMonto.Text = "Monto:";
			// 
			// lblHoras
			// 
			lblHoras.AutoSize = true;
			lblHoras.Font = new Font("Segoe UI", 12F);
			lblHoras.Location = new Point(12, 193);
			lblHoras.Name = "lblHoras";
			lblHoras.Size = new Size(99, 21);
			lblHoras.TabIndex = 96;
			lblHoras.Text = "Horas Extras:";
			// 
			// txbConcepto
			// 
			txbConcepto.Font = new Font("Segoe UI", 12F);
			txbConcepto.Location = new Point(149, 85);
			txbConcepto.MaxLength = 300;
			txbConcepto.Name = "txbConcepto";
			txbConcepto.Size = new Size(331, 29);
			txbConcepto.TabIndex = 97;
			// 
			// txbMonto
			// 
			txbMonto.Font = new Font("Segoe UI", 12F);
			txbMonto.Location = new Point(149, 135);
			txbMonto.MaxLength = 15;
			txbMonto.Name = "txbMonto";
			txbMonto.Size = new Size(54, 29);
			txbMonto.TabIndex = 98;
			txbMonto.TextChanged += txbMonto_TextChanged;
			// 
			// txbHoras
			// 
			txbHoras.Font = new Font("Segoe UI", 12F);
			txbHoras.Location = new Point(149, 185);
			txbHoras.MaxLength = 15;
			txbHoras.Name = "txbHoras";
			txbHoras.Size = new Size(54, 29);
			txbHoras.TabIndex = 99;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(427, 234);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 100;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(508, 234);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 29);
			btnCancel.TabIndex = 101;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// FrmAdd
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(595, 275);
			Controls.Add(btnCancel);
			Controls.Add(btnAccept);
			Controls.Add(txbHoras);
			Controls.Add(txbMonto);
			Controls.Add(txbConcepto);
			Controls.Add(lblHoras);
			Controls.Add(lblMonto);
			Controls.Add(lblConcepto);
			Controls.Add(txbId);
			Controls.Add(lblId);
			Controls.Add(lblAdd);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "FrmAdd";
			Text = "Añadir Concepto";
			Load += FrmAdd_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Label lblAdd;
		private Label lblId;
		public TextBox txbId;
		private Label lblConcepto;
		private Label lblMonto;
		private Label lblHoras;
		public TextBox txbConcepto;
		public TextBox txbMonto;
		public TextBox txbHoras;
		private Button btnAccept;
		private Button btnCancel;
	}
}
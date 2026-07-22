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
			panel1 = new Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Arial Black", 16F);
			lblAdd.Location = new Point(125, 27);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(258, 38);
			lblAdd.TabIndex = 70;
			lblAdd.Text = "Nuevo Concepto";
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblId.Location = new Point(23, 114);
			lblId.Name = "lblId";
			lblId.Size = new Size(29, 23);
			lblId.TabIndex = 92;
			lblId.Text = "Id:";
			// 
			// txbId
			// 
			txbId.Enabled = false;
			txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbId.Location = new Point(23, 141);
			txbId.Margin = new Padding(3, 4, 3, 4);
			txbId.Name = "txbId";
			txbId.Size = new Size(76, 34);
			txbId.TabIndex = 93;
			txbId.TextAlign = HorizontalAlignment.Center;
			// 
			// lblConcepto
			// 
			lblConcepto.AutoSize = true;
			lblConcepto.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblConcepto.Location = new Point(23, 184);
			lblConcepto.Name = "lblConcepto";
			lblConcepto.Size = new Size(88, 23);
			lblConcepto.TabIndex = 94;
			lblConcepto.Text = "Concepto:";
			// 
			// lblMonto
			// 
			lblMonto.AutoSize = true;
			lblMonto.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblMonto.Location = new Point(23, 249);
			lblMonto.Name = "lblMonto";
			lblMonto.Size = new Size(65, 23);
			lblMonto.TabIndex = 95;
			lblMonto.Text = "Monto:";
			// 
			// lblHoras
			// 
			lblHoras.AutoSize = true;
			lblHoras.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblHoras.Location = new Point(23, 317);
			lblHoras.Name = "lblHoras";
			lblHoras.Size = new Size(108, 23);
			lblHoras.TabIndex = 96;
			lblHoras.Text = "Horas Extras:";
			// 
			// txbConcepto
			// 
			txbConcepto.Font = new Font("Segoe UI", 12F);
			txbConcepto.Location = new Point(23, 211);
			txbConcepto.Margin = new Padding(3, 4, 3, 4);
			txbConcepto.MaxLength = 300;
			txbConcepto.Name = "txbConcepto";
			txbConcepto.Size = new Size(475, 34);
			txbConcepto.TabIndex = 97;
			// 
			// txbMonto
			// 
			txbMonto.Font = new Font("Segoe UI", 12F);
			txbMonto.Location = new Point(23, 274);
			txbMonto.Margin = new Padding(3, 4, 3, 4);
			txbMonto.MaxLength = 15;
			txbMonto.Name = "txbMonto";
			txbMonto.Size = new Size(76, 34);
			txbMonto.TabIndex = 98;
			txbMonto.TextChanged += txbMonto_TextChanged;
			// 
			// txbHoras
			// 
			txbHoras.Font = new Font("Segoe UI", 12F);
			txbHoras.Location = new Point(23, 344);
			txbHoras.Margin = new Padding(3, 4, 3, 4);
			txbHoras.MaxLength = 15;
			txbHoras.Name = "txbHoras";
			txbHoras.Size = new Size(76, 34);
			txbHoras.TabIndex = 99;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(287, 417);
			btnAccept.Margin = new Padding(3, 4, 3, 4);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(86, 39);
			btnAccept.TabIndex = 100;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(401, 417);
			btnCancel.Margin = new Padding(3, 4, 3, 4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(86, 39);
			btnCancel.TabIndex = 101;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLightLight;
			panel1.Controls.Add(lblAdd);
			panel1.Location = new Point(12, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(481, 95);
			panel1.TabIndex = 102;
			// 
			// FrmAdd
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(505, 464);
			Controls.Add(panel1);
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
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			Name = "FrmAdd";
			Text = "Añadir Concepto";
			Load += FrmAdd_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
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
		private Panel panel1;
	}
}
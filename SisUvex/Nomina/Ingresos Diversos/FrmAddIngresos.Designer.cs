namespace SisUvex.Nomina.Ingresos_Diversos
{
	partial class FrmAddIngresos
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
			cboConceptos = new ComboBox();
			lblConceptos = new Label();
			btnCancel = new Button();
			btnAccept = new Button();
			lblMonto = new Label();
			lblMontoConcepto = new Label();
			lblHoras = new Label();
			txbMonto = new TextBox();
			txbHoras = new TextBox();
			txbMmodificar = new TextBox();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblAdd.Location = new Point(59, 22);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(146, 25);
			lblAdd.TabIndex = 0;
			lblAdd.Text = "Añadir Ingresos";
			// 
			// cboConceptos
			// 
			cboConceptos.DropDownStyle = ComboBoxStyle.DropDownList;
			cboConceptos.FormattingEnabled = true;
			cboConceptos.Location = new Point(159, 85);
			cboConceptos.Name = "cboConceptos";
			cboConceptos.Size = new Size(299, 23);
			cboConceptos.TabIndex = 7;
			cboConceptos.SelectedIndexChanged += cboConceptos_SelectedIndexChanged;
			// 
			// lblConceptos
			// 
			lblConceptos.AutoSize = true;
			lblConceptos.Font = new Font("Segoe UI", 12F);
			lblConceptos.Location = new Point(59, 87);
			lblConceptos.Name = "lblConceptos";
			lblConceptos.Size = new Size(79, 21);
			lblConceptos.TabIndex = 92;
			lblConceptos.Text = "Concepto:";
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(465, 256);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 29);
			btnCancel.TabIndex = 94;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(383, 256);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 95;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// lblMonto
			// 
			lblMonto.AutoSize = true;
			lblMonto.Font = new Font("Segoe UI", 12F);
			lblMonto.Location = new Point(59, 231);
			lblMonto.Name = "lblMonto";
			lblMonto.Size = new Size(129, 21);
			lblMonto.TabIndex = 96;
			lblMonto.Text = "Modificar Monto:";
			// 
			// lblMontoConcepto
			// 
			lblMontoConcepto.AutoSize = true;
			lblMontoConcepto.Font = new Font("Segoe UI", 12F);
			lblMontoConcepto.Location = new Point(59, 140);
			lblMontoConcepto.Name = "lblMontoConcepto";
			lblMontoConcepto.Size = new Size(59, 21);
			lblMontoConcepto.TabIndex = 98;
			lblMontoConcepto.Text = "Monto:";
			// 
			// lblHoras
			// 
			lblHoras.AutoSize = true;
			lblHoras.Font = new Font("Segoe UI", 12F);
			lblHoras.Location = new Point(59, 187);
			lblHoras.Name = "lblHoras";
			lblHoras.Size = new Size(99, 21);
			lblHoras.TabIndex = 99;
			lblHoras.Text = "Horas Extras:";
			// 
			// txbMonto
			// 
			txbMonto.Enabled = false;
			txbMonto.Font = new Font("Segoe UI", 12F);
			txbMonto.Location = new Point(159, 132);
			txbMonto.MaxLength = 15;
			txbMonto.Name = "txbMonto";
			txbMonto.Size = new Size(71, 29);
			txbMonto.TabIndex = 100;
			// 
			// txbHoras
			// 
			txbHoras.Enabled = false;
			txbHoras.Font = new Font("Segoe UI", 12F);
			txbHoras.Location = new Point(164, 179);
			txbHoras.MaxLength = 15;
			txbHoras.Name = "txbHoras";
			txbHoras.Size = new Size(66, 29);
			txbHoras.TabIndex = 101;
			// 
			// txbMmodificar
			// 
			txbMmodificar.Font = new Font("Segoe UI", 12F);
			txbMmodificar.Location = new Point(194, 223);
			txbMmodificar.MaxLength = 15;
			txbMmodificar.Name = "txbMmodificar";
			txbMmodificar.Size = new Size(66, 29);
			txbMmodificar.TabIndex = 102;
			// 
			// FrmAddIngresos
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(552, 310);
			Controls.Add(txbMmodificar);
			Controls.Add(txbHoras);
			Controls.Add(txbMonto);
			Controls.Add(lblHoras);
			Controls.Add(lblMontoConcepto);
			Controls.Add(lblMonto);
			Controls.Add(btnAccept);
			Controls.Add(btnCancel);
			Controls.Add(lblConceptos);
			Controls.Add(cboConceptos);
			Controls.Add(lblAdd);
			Name = "FrmAddIngresos";
			Text = "FrmAddIngresos";
			Load += FrmAddIngresos_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblAdd;
		public ComboBox cboConceptos;
		private Label lblConceptos;
		private Button btnCancel;
		private Button btnAccept;
		private Label lblMonto;
		private Label lblMontoConcepto;
		private Label lblHoras;
		public TextBox txbMonto;
		public TextBox txbHoras;
		public TextBox txbMmodificar;
	}
}
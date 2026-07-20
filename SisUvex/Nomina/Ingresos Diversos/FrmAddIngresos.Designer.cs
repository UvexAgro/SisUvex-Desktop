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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddIngresos));
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
			groupBox1 = new GroupBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblAdd.Location = new Point(201, 9);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(184, 32);
			lblAdd.TabIndex = 0;
			lblAdd.Text = "Añadir Ingresos";
			// 
			// cboConceptos
			// 
			cboConceptos.DropDownStyle = ComboBoxStyle.DropDownList;
			cboConceptos.FormattingEnabled = true;
			cboConceptos.Location = new Point(189, 50);
			cboConceptos.Margin = new Padding(3, 4, 3, 4);
			cboConceptos.Name = "cboConceptos";
			cboConceptos.Size = new Size(341, 28);
			cboConceptos.TabIndex = 7;
			cboConceptos.SelectedIndexChanged += cboConceptos_SelectedIndexChanged;
			// 
			// lblConceptos
			// 
			lblConceptos.AutoSize = true;
			lblConceptos.Font = new Font("Segoe UI", 12F);
			lblConceptos.Location = new Point(18, 50);
			lblConceptos.Name = "lblConceptos";
			lblConceptos.Size = new Size(101, 28);
			lblConceptos.TabIndex = 92;
			lblConceptos.Text = "Concepto:";
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(469, 307);
			btnCancel.Margin = new Padding(3, 4, 3, 4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(86, 39);
			btnCancel.TabIndex = 94;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(350, 307);
			btnAccept.Margin = new Padding(3, 4, 3, 4);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(86, 39);
			btnAccept.TabIndex = 95;
			btnAccept.Text = "Guardar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// lblMonto
			// 
			lblMonto.AutoSize = true;
			lblMonto.Font = new Font("Segoe UI", 12F);
			lblMonto.Location = new Point(18, 173);
			lblMonto.Name = "lblMonto";
			lblMonto.Size = new Size(142, 28);
			lblMonto.TabIndex = 96;
			lblMonto.Text = "Ajustar Monto:";
			// 
			// lblMontoConcepto
			// 
			lblMontoConcepto.AutoSize = true;
			lblMontoConcepto.Font = new Font("Segoe UI", 12F);
			lblMontoConcepto.Location = new Point(18, 89);
			lblMontoConcepto.Name = "lblMontoConcepto";
			lblMontoConcepto.Size = new Size(76, 28);
			lblMontoConcepto.TabIndex = 98;
			lblMontoConcepto.Text = "Monto:";
			// 
			// lblHoras
			// 
			lblHoras.AutoSize = true;
			lblHoras.Font = new Font("Segoe UI", 12F);
			lblHoras.Location = new Point(18, 131);
			lblHoras.Name = "lblHoras";
			lblHoras.Size = new Size(123, 28);
			lblHoras.TabIndex = 99;
			lblHoras.Text = "Horas Extras:";
			// 
			// txbMonto
			// 
			txbMonto.Enabled = false;
			txbMonto.Font = new Font("Segoe UI", 12F);
			txbMonto.Location = new Point(189, 86);
			txbMonto.Margin = new Padding(3, 4, 3, 4);
			txbMonto.MaxLength = 15;
			txbMonto.Name = "txbMonto";
			txbMonto.Size = new Size(81, 34);
			txbMonto.TabIndex = 100;
			// 
			// txbHoras
			// 
			txbHoras.Enabled = false;
			txbHoras.Font = new Font("Segoe UI", 12F);
			txbHoras.Location = new Point(189, 128);
			txbHoras.Margin = new Padding(3, 4, 3, 4);
			txbHoras.MaxLength = 15;
			txbHoras.Name = "txbHoras";
			txbHoras.Size = new Size(81, 34);
			txbHoras.TabIndex = 101;
			// 
			// txbMmodificar
			// 
			txbMmodificar.Font = new Font("Segoe UI", 12F);
			txbMmodificar.Location = new Point(189, 170);
			txbMmodificar.Margin = new Padding(3, 4, 3, 4);
			txbMmodificar.MaxLength = 15;
			txbMmodificar.Name = "txbMmodificar";
			txbMmodificar.Size = new Size(81, 34);
			txbMmodificar.TabIndex = 102;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(txbMonto);
			groupBox1.Controls.Add(txbMmodificar);
			groupBox1.Controls.Add(cboConceptos);
			groupBox1.Controls.Add(txbHoras);
			groupBox1.Controls.Add(lblConceptos);
			groupBox1.Controls.Add(lblMonto);
			groupBox1.Controls.Add(lblHoras);
			groupBox1.Controls.Add(lblMontoConcepto);
			groupBox1.Location = new Point(12, 59);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(543, 241);
			groupBox1.TabIndex = 103;
			groupBox1.TabStop = false;
			groupBox1.Text = "Informacion de Ingreso";
			// 
			// FrmAddIngresos
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(567, 359);
			Controls.Add(groupBox1);
			Controls.Add(btnAccept);
			Controls.Add(btnCancel);
			Controls.Add(lblAdd);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmAddIngresos";
			Text = "Ingresos";
			Load += FrmAddIngresos_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
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
		private GroupBox groupBox1;
	}
}
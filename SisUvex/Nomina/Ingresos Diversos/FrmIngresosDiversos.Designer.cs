namespace SisUvex.Nomina.Ingresos_Diversos
{
	partial class FrmIngresosDiversos
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
			lblDia = new Label();
			dtpDia = new DateTimePicker();
			btnDia = new Button();
			lblEmpleado = new Label();
			btnSeleccionar = new Button();
			txbEmpleado = new TextBox();
			btnEmpleado = new Button();
			btnFrmSearchEmployeeId = new Button();
			lblIngresos = new Label();
			SuspendLayout();
			// 
			// lblDia
			// 
			lblDia.AutoSize = true;
			lblDia.Location = new Point(37, 63);
			lblDia.Name = "lblDia";
			lblDia.Size = new Size(47, 15);
			lblDia.TabIndex = 7;
			lblDia.Text = "Por día:";
			// 
			// dtpDia
			// 
			dtpDia.Location = new Point(37, 81);
			dtpDia.Name = "dtpDia";
			dtpDia.Size = new Size(224, 23);
			dtpDia.TabIndex = 8;
			// 
			// btnDia
			// 
			btnDia.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnDia.BackgroundImageLayout = ImageLayout.Stretch;
			btnDia.Location = new Point(267, 81);
			btnDia.Name = "btnDia";
			btnDia.Size = new Size(23, 23);
			btnDia.TabIndex = 9;
			btnDia.UseVisualStyleBackColor = true;
			btnDia.Click += btnDia_Click;
			// 
			// lblEmpleado
			// 
			lblEmpleado.AutoSize = true;
			lblEmpleado.Location = new Point(37, 132);
			lblEmpleado.Name = "lblEmpleado";
			lblEmpleado.Size = new Size(84, 15);
			lblEmpleado.TabIndex = 10;
			lblEmpleado.Text = "Por empleado:";
			// 
			// btnSeleccionar
			// 
			btnSeleccionar.Location = new Point(37, 151);
			btnSeleccionar.Name = "btnSeleccionar";
			btnSeleccionar.Size = new Size(75, 23);
			btnSeleccionar.TabIndex = 11;
			btnSeleccionar.Text = "Seleccionar";
			btnSeleccionar.UseVisualStyleBackColor = true;
			// 
			// txbEmpleado
			// 
			txbEmpleado.Location = new Point(118, 151);
			txbEmpleado.Name = "txbEmpleado";
			txbEmpleado.Size = new Size(105, 23);
			txbEmpleado.TabIndex = 12;
			// 
			// btnEmpleado
			// 
			btnEmpleado.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnEmpleado.BackgroundImageLayout = ImageLayout.Stretch;
			btnEmpleado.Location = new Point(229, 151);
			btnEmpleado.Name = "btnEmpleado";
			btnEmpleado.Size = new Size(23, 23);
			btnEmpleado.TabIndex = 13;
			btnEmpleado.UseVisualStyleBackColor = true;
			btnEmpleado.Click += btnEmpleado_Click;
			// 
			// btnFrmSearchEmployeeId
			// 
			btnFrmSearchEmployeeId.BackgroundImageLayout = ImageLayout.Stretch;
			btnFrmSearchEmployeeId.Location = new Point(264, 151);
			btnFrmSearchEmployeeId.Name = "btnFrmSearchEmployeeId";
			btnFrmSearchEmployeeId.Size = new Size(26, 23);
			btnFrmSearchEmployeeId.TabIndex = 67;
			btnFrmSearchEmployeeId.Text = "...";
			btnFrmSearchEmployeeId.UseVisualStyleBackColor = true;
			btnFrmSearchEmployeeId.Click += btnFrmSearchEmployeeId_Click;
			// 
			// lblIngresos
			// 
			lblIngresos.AutoSize = true;
			lblIngresos.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
			lblIngresos.Location = new Point(37, 9);
			lblIngresos.Name = "lblIngresos";
			lblIngresos.Size = new Size(293, 30);
			lblIngresos.TabIndex = 68;
			lblIngresos.Text = "Percepciones y Deducciones";
			// 
			// FrmIngresosDiversos
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(348, 207);
			Controls.Add(lblIngresos);
			Controls.Add(btnFrmSearchEmployeeId);
			Controls.Add(btnEmpleado);
			Controls.Add(txbEmpleado);
			Controls.Add(btnSeleccionar);
			Controls.Add(lblEmpleado);
			Controls.Add(btnDia);
			Controls.Add(dtpDia);
			Controls.Add(lblDia);
			Name = "FrmIngresosDiversos";
			Text = "Percepciones y Deducciones";
			Load += FrmIngresosDiversos_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblDia;
		public DateTimePicker dtpDia;
		private Button btnDia;
		private Label lblEmpleado;
		private Button btnSeleccionar;
		public TextBox txbEmpleado;
		private Button btnEmpleado;
		private Button btnFrmSearchEmployeeId;
		private Label lblIngresos;
	}
}
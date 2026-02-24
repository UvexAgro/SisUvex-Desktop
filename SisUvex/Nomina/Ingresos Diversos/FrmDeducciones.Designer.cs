namespace SisUvex.Nomina.Ingresos_Diversos
{
	partial class FrmDeducciones
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
			lblMmodificarD = new Label();
			cboDeducciones = new ComboBox();
			lblMontoDeduccion = new Label();
			txbMontoDeduccion = new TextBox();
			txbMmodificarD = new TextBox();
			btnAcceptD = new Button();
			btnCancelD = new Button();
			lblDeducciones = new Label();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblAdd.Location = new Point(12, 21);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(165, 25);
			lblAdd.TabIndex = 1;
			lblAdd.Text = "Añadir Deduccion";
			// 
			// lblMmodificarD
			// 
			lblMmodificarD.AutoSize = true;
			lblMmodificarD.Font = new Font("Segoe UI", 12F);
			lblMmodificarD.Location = new Point(12, 185);
			lblMmodificarD.Name = "lblMmodificarD";
			lblMmodificarD.Size = new Size(129, 21);
			lblMmodificarD.TabIndex = 102;
			lblMmodificarD.Text = "Modificar Monto:";
			// 
			// cboDeducciones
			// 
			cboDeducciones.DropDownStyle = ComboBoxStyle.DropDownList;
			cboDeducciones.FormattingEnabled = true;
			cboDeducciones.Location = new Point(132, 81);
			cboDeducciones.Name = "cboDeducciones";
			cboDeducciones.Size = new Size(299, 23);
			cboDeducciones.TabIndex = 94;
			cboDeducciones.SelectedIndexChanged += cboDeducciones_SelectedIndexChanged;
			// 
			// lblMontoDeduccion
			// 
			lblMontoDeduccion.AutoSize = true;
			lblMontoDeduccion.Font = new Font("Segoe UI", 12F);
			lblMontoDeduccion.Location = new Point(12, 130);
			lblMontoDeduccion.Name = "lblMontoDeduccion";
			lblMontoDeduccion.Size = new Size(59, 21);
			lblMontoDeduccion.TabIndex = 99;
			lblMontoDeduccion.Text = "Monto:";
			// 
			// txbMontoDeduccion
			// 
			txbMontoDeduccion.Enabled = false;
			txbMontoDeduccion.Font = new Font("Segoe UI", 12F);
			txbMontoDeduccion.Location = new Point(132, 122);
			txbMontoDeduccion.MaxLength = 15;
			txbMontoDeduccion.Name = "txbMontoDeduccion";
			txbMontoDeduccion.Size = new Size(71, 29);
			txbMontoDeduccion.TabIndex = 101;
			// 
			// txbMmodificarD
			// 
			txbMmodificarD.Font = new Font("Segoe UI", 12F);
			txbMmodificarD.Location = new Point(160, 177);
			txbMmodificarD.MaxLength = 15;
			txbMmodificarD.Name = "txbMmodificarD";
			txbMmodificarD.Size = new Size(66, 29);
			txbMmodificarD.TabIndex = 103;
			// 
			// btnAcceptD
			// 
			btnAcceptD.Location = new Point(309, 202);
			btnAcceptD.Name = "btnAcceptD";
			btnAcceptD.Size = new Size(75, 29);
			btnAcceptD.TabIndex = 104;
			btnAcceptD.Text = "Aceptar";
			btnAcceptD.UseVisualStyleBackColor = true;
			btnAcceptD.Click += btnAcceptD_Click;
			// 
			// btnCancelD
			// 
			btnCancelD.Location = new Point(396, 202);
			btnCancelD.Name = "btnCancelD";
			btnCancelD.Size = new Size(75, 29);
			btnCancelD.TabIndex = 105;
			btnCancelD.Text = "Cancelar";
			btnCancelD.UseVisualStyleBackColor = true;
			btnCancelD.Click += btnCancelD_Click;
			// 
			// lblDeducciones
			// 
			lblDeducciones.AutoSize = true;
			lblDeducciones.Font = new Font("Segoe UI", 12F);
			lblDeducciones.Location = new Point(12, 79);
			lblDeducciones.Name = "lblDeducciones";
			lblDeducciones.Size = new Size(101, 21);
			lblDeducciones.TabIndex = 106;
			lblDeducciones.Text = "Deducciones:";
			// 
			// FrmDeducciones
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(483, 243);
			Controls.Add(lblDeducciones);
			Controls.Add(btnCancelD);
			Controls.Add(btnAcceptD);
			Controls.Add(txbMmodificarD);
			Controls.Add(lblMmodificarD);
			Controls.Add(txbMontoDeduccion);
			Controls.Add(cboDeducciones);
			Controls.Add(lblMontoDeduccion);
			Controls.Add(lblAdd);
			Name = "FrmDeducciones";
			Text = "FrmDeducciones";
			Load += FrmDeducciones_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblAdd;
		private Label lblMmodificarD;
		public ComboBox cboDeducciones;
		private Label lblMontoDeduccion;
		public TextBox txbMontoDeduccion;
		private Label lblMonto;
		public TextBox txbMmodificarD;
		private Button btnAcceptD;
		private Button btnCancelD;
		private Label lblDeducciones;
	}
}
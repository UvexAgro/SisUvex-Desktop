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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeducciones));
			lblAdd = new Label();
			lblMmodificarD = new Label();
			cboDeducciones = new ComboBox();
			lblMontoDeduccion = new Label();
			txbMontoDeduccion = new TextBox();
			txbMmodificarD = new TextBox();
			btnAcceptD = new Button();
			btnCancelD = new Button();
			lblDeducciones = new Label();
			groupBox1 = new GroupBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblAdd.Location = new Point(161, 9);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(207, 32);
			lblAdd.TabIndex = 1;
			lblAdd.Text = "Añadir Deduccion";
			// 
			// lblMmodificarD
			// 
			lblMmodificarD.AutoSize = true;
			lblMmodificarD.Font = new Font("Segoe UI", 12F);
			lblMmodificarD.Location = new Point(9, 141);
			lblMmodificarD.Name = "lblMmodificarD";
			lblMmodificarD.Size = new Size(165, 28);
			lblMmodificarD.TabIndex = 102;
			lblMmodificarD.Text = "Modificar Monto:";
			// 
			// cboDeducciones
			// 
			cboDeducciones.DropDownStyle = ComboBoxStyle.DropDownList;
			cboDeducciones.FormattingEnabled = true;
			cboDeducciones.Location = new Point(178, 57);
			cboDeducciones.Margin = new Padding(3, 4, 3, 4);
			cboDeducciones.Name = "cboDeducciones";
			cboDeducciones.Size = new Size(341, 28);
			cboDeducciones.TabIndex = 94;
			cboDeducciones.SelectedIndexChanged += cboDeducciones_SelectedIndexChanged;
			// 
			// lblMontoDeduccion
			// 
			lblMontoDeduccion.AutoSize = true;
			lblMontoDeduccion.Font = new Font("Segoe UI", 12F);
			lblMontoDeduccion.Location = new Point(9, 96);
			lblMontoDeduccion.Name = "lblMontoDeduccion";
			lblMontoDeduccion.Size = new Size(76, 28);
			lblMontoDeduccion.TabIndex = 99;
			lblMontoDeduccion.Text = "Monto:";
			// 
			// txbMontoDeduccion
			// 
			txbMontoDeduccion.Enabled = false;
			txbMontoDeduccion.Font = new Font("Segoe UI", 12F);
			txbMontoDeduccion.Location = new Point(178, 93);
			txbMontoDeduccion.Margin = new Padding(3, 4, 3, 4);
			txbMontoDeduccion.MaxLength = 15;
			txbMontoDeduccion.Name = "txbMontoDeduccion";
			txbMontoDeduccion.Size = new Size(81, 34);
			txbMontoDeduccion.TabIndex = 101;
			// 
			// txbMmodificarD
			// 
			txbMmodificarD.Font = new Font("Segoe UI", 12F);
			txbMmodificarD.Location = new Point(178, 135);
			txbMmodificarD.Margin = new Padding(3, 4, 3, 4);
			txbMmodificarD.MaxLength = 15;
			txbMmodificarD.Name = "txbMmodificarD";
			txbMmodificarD.Size = new Size(81, 34);
			txbMmodificarD.TabIndex = 103;
			// 
			// btnAcceptD
			// 
			btnAcceptD.Location = new Point(348, 272);
			btnAcceptD.Margin = new Padding(3, 4, 3, 4);
			btnAcceptD.Name = "btnAcceptD";
			btnAcceptD.Size = new Size(86, 39);
			btnAcceptD.TabIndex = 104;
			btnAcceptD.Text = "Guardar";
			btnAcceptD.UseVisualStyleBackColor = true;
			btnAcceptD.Click += btnAcceptD_Click;
			// 
			// btnCancelD
			// 
			btnCancelD.Location = new Point(451, 272);
			btnCancelD.Margin = new Padding(3, 4, 3, 4);
			btnCancelD.Name = "btnCancelD";
			btnCancelD.Size = new Size(86, 39);
			btnCancelD.TabIndex = 105;
			btnCancelD.Text = "Cancelar";
			btnCancelD.UseVisualStyleBackColor = true;
			btnCancelD.Click += btnCancelD_Click;
			// 
			// lblDeducciones
			// 
			lblDeducciones.AutoSize = true;
			lblDeducciones.Font = new Font("Segoe UI", 12F);
			lblDeducciones.Location = new Point(9, 53);
			lblDeducciones.Name = "lblDeducciones";
			lblDeducciones.Size = new Size(127, 28);
			lblDeducciones.TabIndex = 106;
			lblDeducciones.Text = "Deducciones:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(txbMmodificarD);
			groupBox1.Controls.Add(lblDeducciones);
			groupBox1.Controls.Add(lblMontoDeduccion);
			groupBox1.Controls.Add(cboDeducciones);
			groupBox1.Controls.Add(txbMontoDeduccion);
			groupBox1.Controls.Add(lblMmodificarD);
			groupBox1.Location = new Point(12, 60);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(530, 205);
			groupBox1.TabIndex = 107;
			groupBox1.TabStop = false;
			groupBox1.Text = "Informacion de Deduccion";
			// 
			// FrmDeducciones
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(549, 321);
			Controls.Add(groupBox1);
			Controls.Add(btnCancelD);
			Controls.Add(btnAcceptD);
			Controls.Add(lblAdd);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmDeducciones";
			Text = "Deducciones";
			Load += FrmDeducciones_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
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
		private GroupBox groupBox1;
	}
}
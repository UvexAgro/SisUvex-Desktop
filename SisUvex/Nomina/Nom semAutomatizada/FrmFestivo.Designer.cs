namespace SisUvex.Nomina.Nom_semAutomatizada
{
	partial class FrmFestivo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFestivo));
			rbtFestivoTrabajado = new RadioButton();
			rbtFDescansado = new RadioButton();
			rbtDescansado = new RadioButton();
			lblSelecciona = new Label();
			btnAceptar = new Button();
			groupBox1 = new GroupBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// rbtFestivoTrabajado
			// 
			rbtFestivoTrabajado.AutoSize = true;
			rbtFestivoTrabajado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			rbtFestivoTrabajado.Location = new Point(30, 101);
			rbtFestivoTrabajado.Margin = new Padding(3, 4, 3, 4);
			rbtFestivoTrabajado.Name = "rbtFestivoTrabajado";
			rbtFestivoTrabajado.Size = new Size(165, 27);
			rbtFestivoTrabajado.TabIndex = 0;
			rbtFestivoTrabajado.TabStop = true;
			rbtFestivoTrabajado.Text = "Festivo Trabajado";
			rbtFestivoTrabajado.UseVisualStyleBackColor = true;
			// 
			// rbtFDescansado
			// 
			rbtFDescansado.AutoSize = true;
			rbtFDescansado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			rbtFDescansado.Location = new Point(30, 47);
			rbtFDescansado.Margin = new Padding(3, 4, 3, 4);
			rbtFDescansado.Name = "rbtFDescansado";
			rbtFDescansado.Size = new Size(252, 27);
			rbtFDescansado.TabIndex = 1;
			rbtFDescansado.TabStop = true;
			rbtFDescansado.Text = "Descanso trabajado (Festivo)";
			rbtFDescansado.UseVisualStyleBackColor = true;
			// 
			// rbtDescansado
			// 
			rbtDescansado.AutoSize = true;
			rbtDescansado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			rbtDescansado.Location = new Point(30, 158);
			rbtDescansado.Margin = new Padding(3, 4, 3, 4);
			rbtDescansado.Name = "rbtDescansado";
			rbtDescansado.Size = new Size(193, 27);
			rbtDescansado.TabIndex = 2;
			rbtDescansado.TabStop = true;
			rbtDescansado.Text = "Festivo No Trabajado";
			rbtDescansado.UseVisualStyleBackColor = true;
			// 
			// lblSelecciona
			// 
			lblSelecciona.AutoSize = true;
			lblSelecciona.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSelecciona.Location = new Point(14, 24);
			lblSelecciona.Name = "lblSelecciona";
			lblSelecciona.Size = new Size(181, 28);
			lblSelecciona.TabIndex = 3;
			lblSelecciona.Text = "Tipo de día festivo";
			// 
			// btnAceptar
			// 
			btnAceptar.Location = new Point(286, 287);
			btnAceptar.Margin = new Padding(3, 4, 3, 4);
			btnAceptar.Name = "btnAceptar";
			btnAceptar.Size = new Size(86, 31);
			btnAceptar.TabIndex = 4;
			btnAceptar.Text = "Aceptar";
			btnAceptar.UseVisualStyleBackColor = true;
			btnAceptar.Click += btnAceptar_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(rbtFDescansado);
			groupBox1.Controls.Add(rbtDescansado);
			groupBox1.Controls.Add(rbtFestivoTrabajado);
			groupBox1.Location = new Point(12, 73);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(373, 207);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Seleccione cómo se pagará este día. ";
			// 
			// FrmFestivo
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonHighlight;
			ClientSize = new Size(401, 330);
			Controls.Add(groupBox1);
			Controls.Add(btnAceptar);
			Controls.Add(lblSelecciona);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmFestivo";
			Text = "Dias Festivos";
			Load += FrmFestivo_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private RadioButton rbtFestivoTrabajado;
		private RadioButton rbtFDescansado;
		private RadioButton rbtDescansado;
		private Label lblSelecciona;
		private Button btnAceptar;
		private GroupBox groupBox1;
	}
}
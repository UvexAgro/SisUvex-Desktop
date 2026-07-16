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
			pllDias = new Panel();
			pllDias.SuspendLayout();
			SuspendLayout();
			// 
			// rbtFestivoTrabajado
			// 
			rbtFestivoTrabajado.AutoSize = true;
			rbtFestivoTrabajado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			rbtFestivoTrabajado.Location = new Point(3, 53);
			rbtFestivoTrabajado.Name = "rbtFestivoTrabajado";
			rbtFestivoTrabajado.Size = new Size(155, 21);
			rbtFestivoTrabajado.TabIndex = 0;
			rbtFestivoTrabajado.TabStop = true;
			rbtFestivoTrabajado.Text = "Dia Trabajado Festivo";
			rbtFestivoTrabajado.UseVisualStyleBackColor = true;
			// 
			// rbtFDescansado
			// 
			rbtFDescansado.AutoSize = true;
			rbtFDescansado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			rbtFDescansado.Location = new Point(3, 13);
			rbtFDescansado.Name = "rbtFDescansado";
			rbtFDescansado.Size = new Size(230, 21);
			rbtFDescansado.TabIndex = 1;
			rbtFDescansado.TabStop = true;
			rbtFDescansado.Text = "Dia descansado Trabajado Festivo";
			rbtFDescansado.UseVisualStyleBackColor = true;
			// 
			// rbtDescansado
			// 
			rbtDescansado.AutoSize = true;
			rbtDescansado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			rbtDescansado.Location = new Point(3, 96);
			rbtDescansado.Name = "rbtDescansado";
			rbtDescansado.Size = new Size(177, 21);
			rbtDescansado.TabIndex = 2;
			rbtDescansado.TabStop = true;
			rbtDescansado.Text = "Dia No Trabajado Festivo";
			rbtDescansado.UseVisualStyleBackColor = true;
			// 
			// lblSelecciona
			// 
			lblSelecciona.AutoSize = true;
			lblSelecciona.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSelecciona.Location = new Point(12, 18);
			lblSelecciona.Name = "lblSelecciona";
			lblSelecciona.Size = new Size(176, 21);
			lblSelecciona.TabIndex = 3;
			lblSelecciona.Text = "Seleccione tipo de día:";
			// 
			// btnAceptar
			// 
			btnAceptar.Location = new Point(175, 179);
			btnAceptar.Name = "btnAceptar";
			btnAceptar.Size = new Size(75, 23);
			btnAceptar.TabIndex = 4;
			btnAceptar.Text = "Aceptar";
			btnAceptar.UseVisualStyleBackColor = true;
			btnAceptar.Click += btnAceptar_Click;
			// 
			// pllDias
			// 
			pllDias.BackColor = SystemColors.ActiveCaption;
			pllDias.BorderStyle = BorderStyle.FixedSingle;
			pllDias.Controls.Add(rbtFDescansado);
			pllDias.Controls.Add(rbtDescansado);
			pllDias.Controls.Add(rbtFestivoTrabajado);
			pllDias.Location = new Point(12, 42);
			pllDias.Name = "pllDias";
			pllDias.Size = new Size(240, 131);
			pllDias.TabIndex = 5;
			// 
			// FrmFestivo
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonHighlight;
			ClientSize = new Size(262, 209);
			Controls.Add(pllDias);
			Controls.Add(btnAceptar);
			Controls.Add(lblSelecciona);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmFestivo";
			Text = "Dias Festivos";
			Load += FrmFestivo_Load;
			pllDias.ResumeLayout(false);
			pllDias.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private RadioButton rbtFestivoTrabajado;
		private RadioButton rbtFDescansado;
		private RadioButton rbtDescansado;
		private Label lblSelecciona;
		private Button btnAceptar;
		private Panel pllDias;
	}
}
namespace SisUvex.Catalogos.Nom_Deducciones
{
	partial class FrmAddDeducciones
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddDeducciones));
			txbId = new TextBox();
			lblId = new Label();
			txbDescripccion = new TextBox();
			lblConcepto = new Label();
			label1 = new Label();
			txbCantidad = new TextBox();
			btnCancel = new Button();
			btnAccept = new Button();
			lblAdd = new Label();
			SuspendLayout();
			// 
			// txbId
			// 
			txbId.Enabled = false;
			txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbId.Location = new Point(412, 12);
			txbId.Name = "txbId";
			txbId.Size = new Size(68, 29);
			txbId.TabIndex = 102;
			txbId.TextAlign = HorizontalAlignment.Center;
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Font = new Font("Segoe UI", 12F);
			lblId.Location = new Point(380, 20);
			lblId.Name = "lblId";
			lblId.Size = new Size(26, 21);
			lblId.TabIndex = 101;
			lblId.Text = "Id:";
			// 
			// txbDescripccion
			// 
			txbDescripccion.Font = new Font("Segoe UI", 12F);
			txbDescripccion.Location = new Point(114, 80);
			txbDescripccion.MaxLength = 100;
			txbDescripccion.Name = "txbDescripccion";
			txbDescripccion.Size = new Size(366, 29);
			txbDescripccion.TabIndex = 104;
			// 
			// lblConcepto
			// 
			lblConcepto.AutoSize = true;
			lblConcepto.Font = new Font("Segoe UI", 12F);
			lblConcepto.Location = new Point(7, 83);
			lblConcepto.Name = "lblConcepto";
			lblConcepto.Size = new Size(101, 21);
			lblConcepto.TabIndex = 103;
			lblConcepto.Text = "Descripccion:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(7, 146);
			label1.Name = "label1";
			label1.Size = new Size(75, 21);
			label1.TabIndex = 105;
			label1.Text = "Cantidad:";
			// 
			// txbCantidad
			// 
			txbCantidad.Font = new Font("Segoe UI", 12F);
			txbCantidad.Location = new Point(88, 143);
			txbCantidad.MaxLength = 8;
			txbCantidad.Name = "txbCantidad";
			txbCantidad.Size = new Size(122, 29);
			txbCantidad.TabIndex = 106;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(401, 182);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 29);
			btnCancel.TabIndex = 108;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// btnAccept
			// 
			btnAccept.Location = new Point(310, 182);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 107;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Arial Black", 16F);
			lblAdd.Location = new Point(7, 20);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(229, 31);
			lblAdd.TabIndex = 109;
			lblAdd.Text = "Añadir Deduccion";
			// 
			// FrmAddDeducciones
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(489, 219);
			Controls.Add(lblAdd);
			Controls.Add(btnCancel);
			Controls.Add(btnAccept);
			Controls.Add(txbCantidad);
			Controls.Add(label1);
			Controls.Add(txbDescripccion);
			Controls.Add(lblConcepto);
			Controls.Add(txbId);
			Controls.Add(lblId);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAddDeducciones";
			Text = "Añadir Deduccion";
			Load += FrmAddDeducciones_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public TextBox txbId;
		private Label lblId;
		public TextBox txbDescripccion;
		private Label lblConcepto;
		private Label label1;
		public TextBox txbCantidad;
		private Button btnCancel;
		private Button btnAccept;
		public Label lblAdd;
	}
}
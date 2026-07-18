namespace SisUvex.Nomina.NomTabulador
{
	partial class FrmAddTabulador
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddTabulador));
			txbName = new TextBox();
			lblNombre = new Label();
			btnAccept = new Button();
			btnCancel = new Button();
			lblActividad = new Label();
			txbActividad = new TextBox();
			txbIdSeason = new TextBox();
			cboSeason = new ComboBox();
			lblTemporada = new Label();
			lblSueldobase = new Label();
			txbSueldoBase = new TextBox();
			txbSueldoDomingo = new TextBox();
			lblSueldoDomingo = new Label();
			txbSueldoFestivo = new TextBox();
			lblSueldoFestivo = new Label();
			txbFestivoDomingo = new TextBox();
			lblSueldoFestivoDomimgo = new Label();
			txbComision = new TextBox();
			lblComision = new Label();
			txbSobreSueldo = new TextBox();
			lblSobreSueldo = new Label();
			lblTitle = new Label();
			panel1 = new Panel();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			panel1.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// txbName
			// 
			txbName.Enabled = false;
			txbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbName.Location = new Point(96, 98);
			txbName.Margin = new Padding(3, 4, 3, 4);
			txbName.MaxLength = 100;
			txbName.Name = "txbName";
			txbName.Size = new Size(390, 34);
			txbName.TabIndex = 111;
			// 
			// lblNombre
			// 
			lblNombre.AutoSize = true;
			lblNombre.Font = new Font("Segoe UI", 12F);
			lblNombre.Location = new Point(8, 102);
			lblNombre.Name = "lblNombre";
			lblNombre.Size = new Size(89, 28);
			lblNombre.TabIndex = 112;
			lblNombre.Text = "Nombre:";
			// 
			// btnAccept
			// 
			btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnAccept.Location = new Point(854, 486);
			btnAccept.Margin = new Padding(3, 4, 3, 4);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(86, 39);
			btnAccept.TabIndex = 113;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCancel.Location = new Point(966, 486);
			btnCancel.Margin = new Padding(3, 4, 3, 4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(86, 39);
			btnCancel.TabIndex = 114;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI", 12F);
			lblActividad.Location = new Point(8, 37);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(99, 28);
			lblActividad.TabIndex = 115;
			lblActividad.Text = "Actividad:";
			// 
			// txbActividad
			// 
			txbActividad.Enabled = false;
			txbActividad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbActividad.Location = new Point(103, 33);
			txbActividad.Margin = new Padding(3, 4, 3, 4);
			txbActividad.MaxLength = 6;
			txbActividad.Name = "txbActividad";
			txbActividad.Size = new Size(133, 34);
			txbActividad.TabIndex = 116;
			// 
			// txbIdSeason
			// 
			txbIdSeason.Enabled = false;
			txbIdSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbIdSeason.Location = new Point(121, 154);
			txbIdSeason.Margin = new Padding(3, 4, 3, 4);
			txbIdSeason.Name = "txbIdSeason";
			txbIdSeason.Size = new Size(52, 34);
			txbIdSeason.TabIndex = 117;
			txbIdSeason.TextAlign = HorizontalAlignment.Center;
			// 
			// cboSeason
			// 
			cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSeason.Font = new Font("Segoe UI", 12F);
			cboSeason.FormattingEnabled = true;
			cboSeason.ItemHeight = 28;
			cboSeason.Location = new Point(179, 154);
			cboSeason.Margin = new Padding(3, 4, 3, 4);
			cboSeason.Name = "cboSeason";
			cboSeason.Size = new Size(314, 36);
			cboSeason.TabIndex = 118;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Segoe UI", 12F);
			lblTemporada.Location = new Point(8, 158);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(114, 28);
			lblTemporada.TabIndex = 119;
			lblTemporada.Text = "Temporada:";
			// 
			// lblSueldobase
			// 
			lblSueldobase.AutoSize = true;
			lblSueldobase.Font = new Font("Segoe UI", 12F);
			lblSueldobase.Location = new Point(10, 39);
			lblSueldobase.Name = "lblSueldobase";
			lblSueldobase.Size = new Size(121, 28);
			lblSueldobase.TabIndex = 120;
			lblSueldobase.Text = "Sueldo Base:";
			// 
			// txbSueldoBase
			// 
			txbSueldoBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoBase.Location = new Point(127, 35);
			txbSueldoBase.Margin = new Padding(3, 4, 3, 4);
			txbSueldoBase.MaxLength = 10;
			txbSueldoBase.Name = "txbSueldoBase";
			txbSueldoBase.Size = new Size(133, 34);
			txbSueldoBase.TabIndex = 121;
			// 
			// txbSueldoDomingo
			// 
			txbSueldoDomingo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoDomingo.Location = new Point(225, 89);
			txbSueldoDomingo.Margin = new Padding(3, 4, 3, 4);
			txbSueldoDomingo.MaxLength = 10;
			txbSueldoDomingo.Name = "txbSueldoDomingo";
			txbSueldoDomingo.Size = new Size(133, 34);
			txbSueldoDomingo.TabIndex = 123;
			// 
			// lblSueldoDomingo
			// 
			lblSueldoDomingo.AutoSize = true;
			lblSueldoDomingo.Font = new Font("Segoe UI", 12F);
			lblSueldoDomingo.Location = new Point(10, 89);
			lblSueldoDomingo.Name = "lblSueldoDomingo";
			lblSueldoDomingo.Size = new Size(209, 28);
			lblSueldoDomingo.TabIndex = 122;
			lblSueldoDomingo.Text = "Sueldo Base Domingo:";
			// 
			// txbSueldoFestivo
			// 
			txbSueldoFestivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoFestivo.Location = new Point(196, 142);
			txbSueldoFestivo.Margin = new Padding(3, 4, 3, 4);
			txbSueldoFestivo.MaxLength = 10;
			txbSueldoFestivo.Name = "txbSueldoFestivo";
			txbSueldoFestivo.Size = new Size(133, 34);
			txbSueldoFestivo.TabIndex = 125;
			// 
			// lblSueldoFestivo
			// 
			lblSueldoFestivo.AutoSize = true;
			lblSueldoFestivo.Font = new Font("Segoe UI", 12F);
			lblSueldoFestivo.Location = new Point(10, 148);
			lblSueldoFestivo.Name = "lblSueldoFestivo";
			lblSueldoFestivo.Size = new Size(188, 28);
			lblSueldoFestivo.TabIndex = 124;
			lblSueldoFestivo.Text = "Sueldo Base Festivo:";
			// 
			// txbFestivoDomingo
			// 
			txbFestivoDomingo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbFestivoDomingo.Location = new Point(243, 201);
			txbFestivoDomingo.Margin = new Padding(3, 4, 3, 4);
			txbFestivoDomingo.MaxLength = 10;
			txbFestivoDomingo.Name = "txbFestivoDomingo";
			txbFestivoDomingo.Size = new Size(133, 34);
			txbFestivoDomingo.TabIndex = 127;
			// 
			// lblSueldoFestivoDomimgo
			// 
			lblSueldoFestivoDomimgo.AutoSize = true;
			lblSueldoFestivoDomimgo.Font = new Font("Segoe UI", 12F);
			lblSueldoFestivoDomimgo.Location = new Point(10, 205);
			lblSueldoFestivoDomimgo.Name = "lblSueldoFestivoDomimgo";
			lblSueldoFestivoDomimgo.Size = new Size(232, 28);
			lblSueldoFestivoDomimgo.TabIndex = 126;
			lblSueldoFestivoDomimgo.Text = "Sueldo Festivo Domingo:";
			// 
			// txbComision
			// 
			txbComision.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbComision.Location = new Point(112, 261);
			txbComision.Margin = new Padding(3, 4, 3, 4);
			txbComision.MaxLength = 10;
			txbComision.Name = "txbComision";
			txbComision.Size = new Size(133, 34);
			txbComision.TabIndex = 129;
			// 
			// lblComision
			// 
			lblComision.AutoSize = true;
			lblComision.Font = new Font("Segoe UI", 12F);
			lblComision.Location = new Point(10, 265);
			lblComision.Name = "lblComision";
			lblComision.Size = new Size(98, 28);
			lblComision.TabIndex = 128;
			lblComision.Text = "Comision:";
			// 
			// txbSobreSueldo
			// 
			txbSobreSueldo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSobreSueldo.Location = new Point(142, 325);
			txbSobreSueldo.Margin = new Padding(3, 4, 3, 4);
			txbSobreSueldo.MaxLength = 10;
			txbSobreSueldo.Name = "txbSobreSueldo";
			txbSobreSueldo.Size = new Size(133, 34);
			txbSobreSueldo.TabIndex = 131;
			// 
			// lblSobreSueldo
			// 
			lblSobreSueldo.AutoSize = true;
			lblSobreSueldo.Font = new Font("Segoe UI", 12F);
			lblSobreSueldo.Location = new Point(10, 329);
			lblSobreSueldo.Name = "lblSobreSueldo";
			lblSobreSueldo.Size = new Size(134, 28);
			lblSobreSueldo.TabIndex = 130;
			lblSobreSueldo.Text = "Sobre Sueldo:";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial Black", 16F);
			lblTitle.Location = new Point(366, 15);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(312, 38);
			lblTitle.TabIndex = 132;
			lblTitle.Text = "Modificar Tabulador";
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.GradientInactiveCaption;
			panel1.Controls.Add(lblTitle);
			panel1.Location = new Point(12, 5);
			panel1.Name = "panel1";
			panel1.Size = new Size(1042, 72);
			panel1.TabIndex = 133;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(txbName);
			groupBox1.Controls.Add(lblNombre);
			groupBox1.Controls.Add(lblActividad);
			groupBox1.Controls.Add(txbActividad);
			groupBox1.Controls.Add(lblTemporada);
			groupBox1.Controls.Add(cboSeason);
			groupBox1.Controls.Add(txbIdSeason);
			groupBox1.Location = new Point(14, 99);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(506, 216);
			groupBox1.TabIndex = 134;
			groupBox1.TabStop = false;
			groupBox1.Text = "Información General";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(lblSueldoFestivoDomimgo);
			groupBox2.Controls.Add(lblSueldobase);
			groupBox2.Controls.Add(txbSueldoBase);
			groupBox2.Controls.Add(txbSobreSueldo);
			groupBox2.Controls.Add(lblSueldoDomingo);
			groupBox2.Controls.Add(lblSobreSueldo);
			groupBox2.Controls.Add(txbSueldoDomingo);
			groupBox2.Controls.Add(txbComision);
			groupBox2.Controls.Add(lblSueldoFestivo);
			groupBox2.Controls.Add(lblComision);
			groupBox2.Controls.Add(txbSueldoFestivo);
			groupBox2.Controls.Add(txbFestivoDomingo);
			groupBox2.Location = new Point(546, 99);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(508, 380);
			groupBox2.TabIndex = 135;
			groupBox2.TabStop = false;
			groupBox2.Text = "Configuración de Salarios";
			// 
			// FrmAddTabulador
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1064, 536);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(panel1);
			Controls.Add(btnAccept);
			Controls.Add(btnCancel);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FrmAddTabulador";
			Text = "Modificar Sueldo, Comisiones y Sobre Sueldos";
			Load += FrmAddTabulador_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		public TextBox txbName;
		private Label label1;
		private Button btnAccept;
		private Button btnCancel;
		private Label lblCodigo;
		public TextBox txbCodigo;
		public TextBox txbIdSeason;
		public ComboBox cboSeason;
		private Label label3;
		private Label lblSueldobase;
		public TextBox txbSueldoBase;
		public TextBox txbSueldoDomingo;
		private Label lblSueldoDomingo;
		public TextBox txbSueldoFestivo;
		private Label lblSueldoFestivo;
		public TextBox textBox2;
		private Label lblSueldoFestivoDomimgo;
		public TextBox txbComision;
		private Label lblComision;
		public TextBox txbSobreSueldo;
		private Label lblSobreSueldo;
		public Label lblTitle;
		public Label lblTemporada;
		public Label lblActividad;
		public Label lblNombre;
		public TextBox txbActividad;
		public TextBox txbFestivoDomingo;
		private Panel panel1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
	}
}
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
			chkEmpaque = new CheckBox();
			chkCampo = new CheckBox();
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
			txbName.Location = new Point(84, 74);
			txbName.MaxLength = 100;
			txbName.Name = "txbName";
			txbName.Size = new Size(342, 29);
			txbName.TabIndex = 111;
			// 
			// lblNombre
			// 
			lblNombre.AutoSize = true;
			lblNombre.Font = new Font("Segoe UI", 12F);
			lblNombre.Location = new Point(7, 76);
			lblNombre.Name = "lblNombre";
			lblNombre.Size = new Size(71, 21);
			lblNombre.TabIndex = 112;
			lblNombre.Text = "Nombre:";
			// 
			// btnAccept
			// 
			btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnAccept.Location = new Point(747, 364);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(75, 29);
			btnAccept.TabIndex = 113;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnCancel.Location = new Point(845, 364);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 29);
			btnCancel.TabIndex = 114;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// lblActividad
			// 
			lblActividad.AutoSize = true;
			lblActividad.Font = new Font("Segoe UI", 12F);
			lblActividad.Location = new Point(7, 28);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(77, 21);
			lblActividad.TabIndex = 115;
			lblActividad.Text = "Actividad:";
			// 
			// txbActividad
			// 
			txbActividad.Enabled = false;
			txbActividad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbActividad.Location = new Point(90, 25);
			txbActividad.MaxLength = 6;
			txbActividad.Name = "txbActividad";
			txbActividad.Size = new Size(117, 29);
			txbActividad.TabIndex = 116;
			// 
			// txbIdSeason
			// 
			txbIdSeason.Enabled = false;
			txbIdSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbIdSeason.Location = new Point(106, 116);
			txbIdSeason.Name = "txbIdSeason";
			txbIdSeason.Size = new Size(46, 29);
			txbIdSeason.TabIndex = 117;
			txbIdSeason.TextAlign = HorizontalAlignment.Center;
			// 
			// cboSeason
			// 
			cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
			cboSeason.Font = new Font("Segoe UI", 12F);
			cboSeason.FormattingEnabled = true;
			cboSeason.ItemHeight = 21;
			cboSeason.Location = new Point(157, 116);
			cboSeason.Name = "cboSeason";
			cboSeason.Size = new Size(275, 29);
			cboSeason.TabIndex = 118;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Segoe UI", 12F);
			lblTemporada.Location = new Point(7, 118);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(90, 21);
			lblTemporada.TabIndex = 119;
			lblTemporada.Text = "Temporada:";
			// 
			// lblSueldobase
			// 
			lblSueldobase.AutoSize = true;
			lblSueldobase.Font = new Font("Segoe UI", 12F);
			lblSueldobase.Location = new Point(9, 29);
			lblSueldobase.Name = "lblSueldobase";
			lblSueldobase.Size = new Size(97, 21);
			lblSueldobase.TabIndex = 120;
			lblSueldobase.Text = "Sueldo Base:";
			// 
			// txbSueldoBase
			// 
			txbSueldoBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoBase.Location = new Point(111, 26);
			txbSueldoBase.MaxLength = 10;
			txbSueldoBase.Name = "txbSueldoBase";
			txbSueldoBase.Size = new Size(117, 29);
			txbSueldoBase.TabIndex = 121;
			// 
			// txbSueldoDomingo
			// 
			txbSueldoDomingo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoDomingo.Location = new Point(197, 67);
			txbSueldoDomingo.MaxLength = 10;
			txbSueldoDomingo.Name = "txbSueldoDomingo";
			txbSueldoDomingo.Size = new Size(117, 29);
			txbSueldoDomingo.TabIndex = 123;
			// 
			// lblSueldoDomingo
			// 
			lblSueldoDomingo.AutoSize = true;
			lblSueldoDomingo.Font = new Font("Segoe UI", 12F);
			lblSueldoDomingo.Location = new Point(9, 67);
			lblSueldoDomingo.Name = "lblSueldoDomingo";
			lblSueldoDomingo.Size = new Size(166, 21);
			lblSueldoDomingo.TabIndex = 122;
			lblSueldoDomingo.Text = "Sueldo Base Domingo:";
			// 
			// txbSueldoFestivo
			// 
			txbSueldoFestivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoFestivo.Location = new Point(172, 106);
			txbSueldoFestivo.MaxLength = 10;
			txbSueldoFestivo.Name = "txbSueldoFestivo";
			txbSueldoFestivo.Size = new Size(117, 29);
			txbSueldoFestivo.TabIndex = 125;
			// 
			// lblSueldoFestivo
			// 
			lblSueldoFestivo.AutoSize = true;
			lblSueldoFestivo.Font = new Font("Segoe UI", 12F);
			lblSueldoFestivo.Location = new Point(9, 111);
			lblSueldoFestivo.Name = "lblSueldoFestivo";
			lblSueldoFestivo.Size = new Size(150, 21);
			lblSueldoFestivo.TabIndex = 124;
			lblSueldoFestivo.Text = "Sueldo Base Festivo:";
			// 
			// txbFestivoDomingo
			// 
			txbFestivoDomingo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbFestivoDomingo.Location = new Point(213, 151);
			txbFestivoDomingo.MaxLength = 10;
			txbFestivoDomingo.Name = "txbFestivoDomingo";
			txbFestivoDomingo.Size = new Size(117, 29);
			txbFestivoDomingo.TabIndex = 127;
			// 
			// lblSueldoFestivoDomimgo
			// 
			lblSueldoFestivoDomimgo.AutoSize = true;
			lblSueldoFestivoDomimgo.Font = new Font("Segoe UI", 12F);
			lblSueldoFestivoDomimgo.Location = new Point(9, 154);
			lblSueldoFestivoDomimgo.Name = "lblSueldoFestivoDomimgo";
			lblSueldoFestivoDomimgo.Size = new Size(183, 21);
			lblSueldoFestivoDomimgo.TabIndex = 126;
			lblSueldoFestivoDomimgo.Text = "Sueldo Festivo Domingo:";
			// 
			// txbComision
			// 
			txbComision.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbComision.Location = new Point(98, 196);
			txbComision.MaxLength = 10;
			txbComision.Name = "txbComision";
			txbComision.Size = new Size(117, 29);
			txbComision.TabIndex = 129;
			// 
			// lblComision
			// 
			lblComision.AutoSize = true;
			lblComision.Font = new Font("Segoe UI", 12F);
			lblComision.Location = new Point(9, 199);
			lblComision.Name = "lblComision";
			lblComision.Size = new Size(79, 21);
			lblComision.TabIndex = 128;
			lblComision.Text = "Comision:";
			// 
			// txbSobreSueldo
			// 
			txbSobreSueldo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSobreSueldo.Location = new Point(124, 244);
			txbSobreSueldo.MaxLength = 10;
			txbSobreSueldo.Name = "txbSobreSueldo";
			txbSobreSueldo.Size = new Size(117, 29);
			txbSobreSueldo.TabIndex = 131;
			// 
			// lblSobreSueldo
			// 
			lblSobreSueldo.AutoSize = true;
			lblSobreSueldo.Font = new Font("Segoe UI", 12F);
			lblSobreSueldo.Location = new Point(9, 247);
			lblSobreSueldo.Name = "lblSobreSueldo";
			lblSobreSueldo.Size = new Size(106, 21);
			lblSobreSueldo.TabIndex = 130;
			lblSobreSueldo.Text = "Sobre Sueldo:";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial Black", 16F);
			lblTitle.ForeColor = Color.White;
			lblTitle.Location = new Point(320, 11);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(257, 31);
			lblTitle.TabIndex = 132;
			lblTitle.Text = "Modificar Tabulador";
			// 
			// panel1
			// 
			panel1.BackColor = Color.FromArgb(35, 103, 149);
			panel1.Controls.Add(lblTitle);
			panel1.Location = new Point(10, 4);
			panel1.Margin = new Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(912, 54);
			panel1.TabIndex = 133;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(chkEmpaque);
			groupBox1.Controls.Add(chkCampo);
			groupBox1.Controls.Add(txbName);
			groupBox1.Controls.Add(lblNombre);
			groupBox1.Controls.Add(lblActividad);
			groupBox1.Controls.Add(txbActividad);
			groupBox1.Controls.Add(lblTemporada);
			groupBox1.Controls.Add(cboSeason);
			groupBox1.Controls.Add(txbIdSeason);
			groupBox1.Location = new Point(12, 74);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(443, 220);
			groupBox1.TabIndex = 134;
			groupBox1.TabStop = false;
			groupBox1.Text = "Información General";
			// 
			// chkEmpaque
			// 
			chkEmpaque.AutoSize = true;
			chkEmpaque.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			chkEmpaque.Location = new Point(117, 179);
			chkEmpaque.Name = "chkEmpaque";
			chkEmpaque.Size = new Size(91, 24);
			chkEmpaque.TabIndex = 121;
			chkEmpaque.Text = "Empaque";
			chkEmpaque.UseVisualStyleBackColor = true;
			// 
			// chkCampo
			// 
			chkCampo.AutoSize = true;
			chkCampo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			chkCampo.Location = new Point(15, 179);
			chkCampo.Name = "chkCampo";
			chkCampo.Size = new Size(76, 24);
			chkCampo.TabIndex = 120;
			chkCampo.Text = "Campo";
			chkCampo.UseVisualStyleBackColor = true;
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
			groupBox2.Location = new Point(478, 74);
			groupBox2.Margin = new Padding(3, 2, 3, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(3, 2, 3, 2);
			groupBox2.Size = new Size(444, 285);
			groupBox2.TabIndex = 135;
			groupBox2.TabStop = false;
			groupBox2.Text = "Configuración de Salarios";
			// 
			// FrmAddTabulador
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(931, 402);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(panel1);
			Controls.Add(btnAccept);
			Controls.Add(btnCancel);
			Icon = (Icon)resources.GetObject("$this.Icon");
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
		public CheckBox chkEmpaque;
		public CheckBox chkCampo;
		private CheckBox ckbCampo;
	}
}
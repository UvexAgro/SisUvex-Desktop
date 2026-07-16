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
			SuspendLayout();
			// 
			// txbName
			// 
			txbName.Enabled = false;
			txbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbName.Location = new Point(89, 118);
			txbName.MaxLength = 100;
			txbName.Name = "txbName";
			txbName.Size = new Size(342, 29);
			txbName.TabIndex = 111;
			// 
			// lblNombre
			// 
			lblNombre.AutoSize = true;
			lblNombre.Font = new Font("Segoe UI", 12F);
			lblNombre.Location = new Point(12, 121);
			lblNombre.Name = "lblNombre";
			lblNombre.Size = new Size(71, 21);
			lblNombre.TabIndex = 112;
			lblNombre.Text = "Nombre:";
			// 
			// btnAccept
			// 
			btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnAccept.Location = new Point(299, 528);
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
			btnCancel.Location = new Point(380, 528);
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
			lblActividad.Location = new Point(12, 72);
			lblActividad.Name = "lblActividad";
			lblActividad.Size = new Size(77, 21);
			lblActividad.TabIndex = 115;
			lblActividad.Text = "Actividad:";
			// 
			// txbActividad
			// 
			txbActividad.Enabled = false;
			txbActividad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbActividad.Location = new Point(95, 69);
			txbActividad.MaxLength = 6;
			txbActividad.Name = "txbActividad";
			txbActividad.Size = new Size(117, 29);
			txbActividad.TabIndex = 116;
			// 
			// txbIdSeason
			// 
			txbIdSeason.Enabled = false;
			txbIdSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbIdSeason.Location = new Point(104, 160);
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
			cboSeason.Location = new Point(156, 160);
			cboSeason.Name = "cboSeason";
			cboSeason.Size = new Size(275, 29);
			cboSeason.TabIndex = 118;
			// 
			// lblTemporada
			// 
			lblTemporada.AutoSize = true;
			lblTemporada.Font = new Font("Segoe UI", 12F);
			lblTemporada.Location = new Point(12, 163);
			lblTemporada.Name = "lblTemporada";
			lblTemporada.Size = new Size(90, 21);
			lblTemporada.TabIndex = 119;
			lblTemporada.Text = "Temporada:";
			// 
			// lblSueldobase
			// 
			lblSueldobase.AutoSize = true;
			lblSueldobase.Font = new Font("Segoe UI", 12F);
			lblSueldobase.Location = new Point(12, 217);
			lblSueldobase.Name = "lblSueldobase";
			lblSueldobase.Size = new Size(97, 21);
			lblSueldobase.TabIndex = 120;
			lblSueldobase.Text = "Sueldo Base:";
			// 
			// txbSueldoBase
			// 
			txbSueldoBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoBase.Location = new Point(115, 214);
			txbSueldoBase.MaxLength = 10;
			txbSueldoBase.Name = "txbSueldoBase";
			txbSueldoBase.Size = new Size(117, 29);
			txbSueldoBase.TabIndex = 121;
			// 
			// txbSueldoDomingo
			// 
			txbSueldoDomingo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoDomingo.Location = new Point(184, 261);
			txbSueldoDomingo.MaxLength = 10;
			txbSueldoDomingo.Name = "txbSueldoDomingo";
			txbSueldoDomingo.Size = new Size(117, 29);
			txbSueldoDomingo.TabIndex = 123;
			// 
			// lblSueldoDomingo
			// 
			lblSueldoDomingo.AutoSize = true;
			lblSueldoDomingo.Font = new Font("Segoe UI", 12F);
			lblSueldoDomingo.Location = new Point(12, 269);
			lblSueldoDomingo.Name = "lblSueldoDomingo";
			lblSueldoDomingo.Size = new Size(166, 21);
			lblSueldoDomingo.TabIndex = 122;
			lblSueldoDomingo.Text = "Sueldo Base Domingo:";
			// 
			// txbSueldoFestivo
			// 
			txbSueldoFestivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSueldoFestivo.Location = new Point(168, 312);
			txbSueldoFestivo.MaxLength = 10;
			txbSueldoFestivo.Name = "txbSueldoFestivo";
			txbSueldoFestivo.Size = new Size(117, 29);
			txbSueldoFestivo.TabIndex = 125;
			// 
			// lblSueldoFestivo
			// 
			lblSueldoFestivo.AutoSize = true;
			lblSueldoFestivo.Font = new Font("Segoe UI", 12F);
			lblSueldoFestivo.Location = new Point(12, 320);
			lblSueldoFestivo.Name = "lblSueldoFestivo";
			lblSueldoFestivo.Size = new Size(150, 21);
			lblSueldoFestivo.TabIndex = 124;
			lblSueldoFestivo.Text = "Sueldo Base Festivo:";
			// 
			// txbFestivoDomingo
			// 
			txbFestivoDomingo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbFestivoDomingo.Location = new Point(201, 370);
			txbFestivoDomingo.MaxLength = 10;
			txbFestivoDomingo.Name = "txbFestivoDomingo";
			txbFestivoDomingo.Size = new Size(117, 29);
			txbFestivoDomingo.TabIndex = 127;
			// 
			// lblSueldoFestivoDomimgo
			// 
			lblSueldoFestivoDomimgo.AutoSize = true;
			lblSueldoFestivoDomimgo.Font = new Font("Segoe UI", 12F);
			lblSueldoFestivoDomimgo.Location = new Point(12, 373);
			lblSueldoFestivoDomimgo.Name = "lblSueldoFestivoDomimgo";
			lblSueldoFestivoDomimgo.Size = new Size(183, 21);
			lblSueldoFestivoDomimgo.TabIndex = 126;
			lblSueldoFestivoDomimgo.Text = "Sueldo Festivo Domingo:";
			// 
			// txbComision
			// 
			txbComision.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbComision.Location = new Point(97, 418);
			txbComision.MaxLength = 10;
			txbComision.Name = "txbComision";
			txbComision.Size = new Size(117, 29);
			txbComision.TabIndex = 129;
			// 
			// lblComision
			// 
			lblComision.AutoSize = true;
			lblComision.Font = new Font("Segoe UI", 12F);
			lblComision.Location = new Point(12, 421);
			lblComision.Name = "lblComision";
			lblComision.Size = new Size(79, 21);
			lblComision.TabIndex = 128;
			lblComision.Text = "Comision:";
			// 
			// txbSobreSueldo
			// 
			txbSobreSueldo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txbSobreSueldo.Location = new Point(124, 471);
			txbSobreSueldo.MaxLength = 10;
			txbSobreSueldo.Name = "txbSobreSueldo";
			txbSobreSueldo.Size = new Size(117, 29);
			txbSobreSueldo.TabIndex = 131;
			// 
			// lblSobreSueldo
			// 
			lblSobreSueldo.AutoSize = true;
			lblSobreSueldo.Font = new Font("Segoe UI", 12F);
			lblSobreSueldo.Location = new Point(12, 474);
			lblSobreSueldo.Name = "lblSobreSueldo";
			lblSobreSueldo.Size = new Size(106, 21);
			lblSobreSueldo.TabIndex = 130;
			lblSobreSueldo.Text = "Sobre Sueldo:";
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial Black", 16F);
			lblTitle.Location = new Point(12, 14);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(257, 31);
			lblTitle.TabIndex = 132;
			lblTitle.Text = "Modificar Tabulador";
			// 
			// FrmAddTabulador
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(467, 569);
			Controls.Add(lblTitle);
			Controls.Add(txbSobreSueldo);
			Controls.Add(lblSobreSueldo);
			Controls.Add(txbComision);
			Controls.Add(lblComision);
			Controls.Add(txbFestivoDomingo);
			Controls.Add(lblSueldoFestivoDomimgo);
			Controls.Add(txbSueldoFestivo);
			Controls.Add(lblSueldoFestivo);
			Controls.Add(txbSueldoDomingo);
			Controls.Add(lblSueldoDomingo);
			Controls.Add(txbSueldoBase);
			Controls.Add(lblSueldobase);
			Controls.Add(txbIdSeason);
			Controls.Add(cboSeason);
			Controls.Add(lblTemporada);
			Controls.Add(txbActividad);
			Controls.Add(lblActividad);
			Controls.Add(btnAccept);
			Controls.Add(btnCancel);
			Controls.Add(txbName);
			Controls.Add(lblNombre);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAddTabulador";
			Text = "Modificar Sueldo, Comisiones y Sobre Sueldos";
			Load += FrmAddTabulador_Load;
			ResumeLayout(false);
			PerformLayout();
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
	}
}
namespace SisUvex.Nomina.Nom_Descuento_de_personal
{
	partial class FrmAddDesc
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
			lblWorkGroup = new Label();
			cboProductionLine = new ComboBox();
			dtpInicio = new DateTimePicker();
			lblFechaInicio = new Label();
			lblFechaFinal = new Label();
			dtpFinal = new DateTimePicker();
			nudOvertime = new NumericUpDown();
			lblCantidad = new Label();
			lblDescripcion = new Label();
			txbConcepto = new TextBox();
			lblId = new Label();
			txbId = new TextBox();
			btnAcept = new Button();
			btnCancel = new Button();
			gpbNormal = new GroupBox();
			((System.ComponentModel.ISupportInitialize)nudOvertime).BeginInit();
			gpbNormal.SuspendLayout();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Arial Black", 16F);
			lblAdd.Location = new Point(12, 23);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(100, 31);
			lblAdd.TabIndex = 148;
			lblAdd.Text = "Añadir ";
			// 
			// lblWorkGroup
			// 
			lblWorkGroup.AutoSize = true;
			lblWorkGroup.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblWorkGroup.Location = new Point(6, 10);
			lblWorkGroup.Name = "lblWorkGroup";
			lblWorkGroup.Size = new Size(50, 19);
			lblWorkGroup.TabIndex = 159;
			lblWorkGroup.Text = "Banda:";
			// 
			// cboProductionLine
			// 
			cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
			cboProductionLine.FormattingEnabled = true;
			cboProductionLine.Location = new Point(6, 34);
			cboProductionLine.Name = "cboProductionLine";
			cboProductionLine.Size = new Size(189, 23);
			cboProductionLine.TabIndex = 160;
			// 
			// dtpInicio
			// 
			dtpInicio.Format = DateTimePickerFormat.Custom;
			dtpInicio.Location = new Point(6, 109);
			dtpInicio.Name = "dtpInicio";
			dtpInicio.Size = new Size(273, 23);
			dtpInicio.TabIndex = 161;
			// 
			// lblFechaInicio
			// 
			lblFechaInicio.AutoSize = true;
			lblFechaInicio.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblFechaInicio.Location = new Point(6, 85);
			lblFechaInicio.Name = "lblFechaInicio";
			lblFechaInicio.Size = new Size(87, 19);
			lblFechaInicio.TabIndex = 162;
			lblFechaInicio.Text = "Fecha Inicio:";
			// 
			// lblFechaFinal
			// 
			lblFechaFinal.AutoSize = true;
			lblFechaFinal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblFechaFinal.Location = new Point(6, 159);
			lblFechaFinal.Name = "lblFechaFinal";
			lblFechaFinal.Size = new Size(87, 19);
			lblFechaFinal.TabIndex = 163;
			lblFechaFinal.Text = "Fecha Inicio:";
			// 
			// dtpFinal
			// 
			dtpFinal.Format = DateTimePickerFormat.Custom;
			dtpFinal.Location = new Point(6, 183);
			dtpFinal.Name = "dtpFinal";
			dtpFinal.Size = new Size(273, 23);
			dtpFinal.TabIndex = 164;
			// 
			// nudOvertime
			// 
			nudOvertime.DecimalPlaces = 2;
			nudOvertime.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudOvertime.Location = new Point(9, 251);
			nudOvertime.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudOvertime.Name = "nudOvertime";
			nudOvertime.Size = new Size(44, 23);
			nudOvertime.TabIndex = 165;
			// 
			// lblCantidad
			// 
			lblCantidad.AutoSize = true;
			lblCantidad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblCantidad.Location = new Point(6, 229);
			lblCantidad.Name = "lblCantidad";
			lblCantidad.Size = new Size(68, 19);
			lblCantidad.TabIndex = 166;
			lblCantidad.Text = "Cantidad:";
			// 
			// lblDescripcion
			// 
			lblDescripcion.AutoSize = true;
			lblDescripcion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblDescripcion.Location = new Point(6, 297);
			lblDescripcion.Name = "lblDescripcion";
			lblDescripcion.Size = new Size(86, 19);
			lblDescripcion.TabIndex = 167;
			lblDescripcion.Text = "Descripción:";
			// 
			// txbConcepto
			// 
			txbConcepto.Font = new Font("Segoe UI", 12F);
			txbConcepto.Location = new Point(6, 321);
			txbConcepto.MaxLength = 300;
			txbConcepto.Name = "txbConcepto";
			txbConcepto.Size = new Size(286, 29);
			txbConcepto.TabIndex = 168;
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Font = new Font("Segoe UI", 12F);
			lblId.Location = new Point(233, 31);
			lblId.Name = "lblId";
			lblId.Size = new Size(26, 21);
			lblId.TabIndex = 169;
			lblId.Text = "Id:";
			// 
			// txbId
			// 
			txbId.Enabled = false;
			txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbId.Location = new Point(265, 23);
			txbId.Name = "txbId";
			txbId.Size = new Size(46, 29);
			txbId.TabIndex = 170;
			txbId.TextAlign = HorizontalAlignment.Center;
			// 
			// btnAcept
			// 
			btnAcept.Location = new Point(136, 463);
			btnAcept.Name = "btnAcept";
			btnAcept.Size = new Size(75, 23);
			btnAcept.TabIndex = 171;
			btnAcept.Text = "Aceptar";
			btnAcept.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(233, 463);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 172;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// gpbNormal
			// 
			gpbNormal.Controls.Add(cboProductionLine);
			gpbNormal.Controls.Add(lblWorkGroup);
			gpbNormal.Controls.Add(dtpInicio);
			gpbNormal.Controls.Add(lblFechaInicio);
			gpbNormal.Controls.Add(lblFechaFinal);
			gpbNormal.Controls.Add(txbConcepto);
			gpbNormal.Controls.Add(dtpFinal);
			gpbNormal.Controls.Add(lblDescripcion);
			gpbNormal.Controls.Add(nudOvertime);
			gpbNormal.Controls.Add(lblCantidad);
			gpbNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			gpbNormal.Location = new Point(16, 73);
			gpbNormal.Name = "gpbNormal";
			gpbNormal.Size = new Size(295, 363);
			gpbNormal.TabIndex = 173;
			gpbNormal.TabStop = false;
			// 
			// FrmAddDesc
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(316, 498);
			Controls.Add(gpbNormal);
			Controls.Add(btnCancel);
			Controls.Add(btnAcept);
			Controls.Add(txbId);
			Controls.Add(lblId);
			Controls.Add(lblAdd);
			Name = "FrmAddDesc";
			Text = "Añadir";
			Load += FrmAddDesc_Load;
			((System.ComponentModel.ISupportInitialize)nudOvertime).EndInit();
			gpbNormal.ResumeLayout(false);
			gpbNormal.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Label lblAdd;
		private Label lblWorkGroup;
		public ComboBox cboProductionLine;
		public DateTimePicker dtpInicio;
		private Label lblFechaInicio;
		private Label lblFechaFinal;
		public DateTimePicker dtpFinal;
		public NumericUpDown nudOvertime;
		private Label lblCantidad;
		private Label lblDescripcion;
		public TextBox txbConcepto;
		private Label lblId;
		public TextBox txbId;
		private Button btnAcept;
		private Button btnCancel;
		private GroupBox gpbNormal;
	}
}
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddDesc));
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
			label1 = new Label();
			toolTip1 = new ToolTip(components);
			((System.ComponentModel.ISupportInitialize)nudOvertime).BeginInit();
			gpbNormal.SuspendLayout();
			SuspendLayout();
			// 
			// lblAdd
			// 
			lblAdd.AutoSize = true;
			lblAdd.Font = new Font("Arial Black", 16F);
			lblAdd.Location = new Point(18, 9);
			lblAdd.Name = "lblAdd";
			lblAdd.Size = new Size(280, 38);
			lblAdd.TabIndex = 148;
			lblAdd.Text = "Añadir Descuento";
			// 
			// lblWorkGroup
			// 
			lblWorkGroup.AutoSize = true;
			lblWorkGroup.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblWorkGroup.Location = new Point(16, 87);
			lblWorkGroup.Name = "lblWorkGroup";
			lblWorkGroup.Size = new Size(62, 23);
			lblWorkGroup.TabIndex = 159;
			lblWorkGroup.Text = "Banda:";
			// 
			// cboProductionLine
			// 
			cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
			cboProductionLine.FormattingEnabled = true;
			cboProductionLine.Location = new Point(84, 86);
			cboProductionLine.Margin = new Padding(3, 4, 3, 4);
			cboProductionLine.Name = "cboProductionLine";
			cboProductionLine.Size = new Size(215, 28);
			cboProductionLine.TabIndex = 160;
			// 
			// dtpInicio
			// 
			dtpInicio.Format = DateTimePickerFormat.Custom;
			dtpInicio.Location = new Point(127, 190);
			dtpInicio.Margin = new Padding(3, 4, 3, 4);
			dtpInicio.Name = "dtpInicio";
			dtpInicio.Size = new Size(311, 27);
			dtpInicio.TabIndex = 161;
			// 
			// lblFechaInicio
			// 
			lblFechaInicio.AutoSize = true;
			lblFechaInicio.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblFechaInicio.Location = new Point(16, 190);
			lblFechaInicio.Name = "lblFechaInicio";
			lblFechaInicio.Size = new Size(105, 23);
			lblFechaInicio.TabIndex = 162;
			lblFechaInicio.Text = "Fecha Inicio:";
			// 
			// lblFechaFinal
			// 
			lblFechaFinal.AutoSize = true;
			lblFechaFinal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblFechaFinal.Location = new Point(16, 246);
			lblFechaFinal.Name = "lblFechaFinal";
			lblFechaFinal.Size = new Size(100, 23);
			lblFechaFinal.TabIndex = 163;
			lblFechaFinal.Text = "Fecha Final:";
			// 
			// dtpFinal
			// 
			dtpFinal.Format = DateTimePickerFormat.Custom;
			dtpFinal.Location = new Point(122, 246);
			dtpFinal.Margin = new Padding(3, 4, 3, 4);
			dtpFinal.Name = "dtpFinal";
			dtpFinal.ShowCheckBox = true;
			dtpFinal.Size = new Size(311, 27);
			dtpFinal.TabIndex = 164;
			toolTip1.SetToolTip(dtpFinal, "\"Deje la fecha sin seleccionar para mantener el descuento vigente.\"");
			// 
			// nudOvertime
			// 
			nudOvertime.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudOvertime.Location = new Point(107, 291);
			nudOvertime.Margin = new Padding(3, 4, 3, 4);
			nudOvertime.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudOvertime.Name = "nudOvertime";
			nudOvertime.Size = new Size(50, 27);
			nudOvertime.TabIndex = 165;
			// 
			// lblCantidad
			// 
			lblCantidad.AutoSize = true;
			lblCantidad.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblCantidad.Location = new Point(18, 291);
			lblCantidad.Name = "lblCantidad";
			lblCantidad.Size = new Size(83, 23);
			lblCantidad.TabIndex = 166;
			lblCantidad.Text = "Cantidad:";
			// 
			// lblDescripcion
			// 
			lblDescripcion.AutoSize = true;
			lblDescripcion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
			lblDescripcion.Location = new Point(14, 140);
			lblDescripcion.Name = "lblDescripcion";
			lblDescripcion.Size = new Size(102, 23);
			lblDescripcion.TabIndex = 167;
			lblDescripcion.Text = "Descripción:";
			// 
			// txbConcepto
			// 
			txbConcepto.Font = new Font("Segoe UI", 12F);
			txbConcepto.Location = new Point(122, 132);
			txbConcepto.Margin = new Padding(3, 4, 3, 4);
			txbConcepto.MaxLength = 300;
			txbConcepto.Name = "txbConcepto";
			txbConcepto.Size = new Size(326, 34);
			txbConcepto.TabIndex = 168;
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblId.Location = new Point(16, 43);
			lblId.Name = "lblId";
			lblId.Size = new Size(29, 23);
			lblId.TabIndex = 169;
			lblId.Text = "Id:";
			// 
			// txbId
			// 
			txbId.Enabled = false;
			txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			txbId.Location = new Point(64, 35);
			txbId.Margin = new Padding(3, 4, 3, 4);
			txbId.Name = "txbId";
			txbId.Size = new Size(52, 34);
			txbId.TabIndex = 170;
			txbId.TextAlign = HorizontalAlignment.Center;
			// 
			// btnAcept
			// 
			btnAcept.Location = new Point(300, 443);
			btnAcept.Margin = new Padding(3, 4, 3, 4);
			btnAcept.Name = "btnAcept";
			btnAcept.Size = new Size(86, 31);
			btnAcept.TabIndex = 171;
			btnAcept.Text = "Aceptar";
			btnAcept.UseVisualStyleBackColor = true;
			btnAcept.Click += btnAcept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(411, 443);
			btnCancel.Margin = new Padding(3, 4, 3, 4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(86, 31);
			btnCancel.TabIndex = 172;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// gpbNormal
			// 
			gpbNormal.Controls.Add(cboProductionLine);
			gpbNormal.Controls.Add(lblWorkGroup);
			gpbNormal.Controls.Add(dtpInicio);
			gpbNormal.Controls.Add(txbId);
			gpbNormal.Controls.Add(lblId);
			gpbNormal.Controls.Add(lblFechaInicio);
			gpbNormal.Controls.Add(lblFechaFinal);
			gpbNormal.Controls.Add(txbConcepto);
			gpbNormal.Controls.Add(dtpFinal);
			gpbNormal.Controls.Add(nudOvertime);
			gpbNormal.Controls.Add(lblDescripcion);
			gpbNormal.Controls.Add(lblCantidad);
			gpbNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			gpbNormal.Location = new Point(18, 90);
			gpbNormal.Margin = new Padding(3, 4, 3, 4);
			gpbNormal.Name = "gpbNormal";
			gpbNormal.Padding = new Padding(3, 4, 3, 4);
			gpbNormal.Size = new Size(506, 324);
			gpbNormal.TabIndex = 173;
			gpbNormal.TabStop = false;
			gpbNormal.Text = "Información del Descuento";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(18, 47);
			label1.Name = "label1";
			label1.Size = new Size(221, 20);
			label1.TabIndex = 174;
			label1.Text = "Registra un descuento por línea.";
			// 
			// FrmAddDesc
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(536, 487);
			Controls.Add(label1);
			Controls.Add(gpbNormal);
			Controls.Add(btnCancel);
			Controls.Add(btnAcept);
			Controls.Add(lblAdd);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
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
		private Label label1;
		private ToolTip toolTip1;
	}
}
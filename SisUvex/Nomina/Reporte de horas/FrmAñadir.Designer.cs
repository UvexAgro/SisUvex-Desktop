namespace SisUvex.Nomina.Reporte_de_horas
{
	partial class FrmAñadir
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAñadir));
			lblTitle = new Label();
			dtpDay = new DateTimePicker();
			ldlDate = new Label();
			gpbNormal = new GroupBox();
			nudOvertime = new NumericUpDown();
			label1 = new Label();
			dtpEndExtra = new DateTimePicker();
			lblEndExtra = new Label();
			dtpEndNormal = new DateTimePicker();
			lblEndNormal = new Label();
			dtpBeginNormal = new DateTimePicker();
			lblBeginNormal = new Label();
			btnAcept = new Button();
			btnCancel = new Button();
			gpbNormal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).BeginInit();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial Black", 12F);
			lblTitle.Location = new Point(12, 9);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(135, 23);
			lblTitle.TabIndex = 148;
			lblTitle.Text = "Añadir horario";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(46, 46);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(216, 23);
			dtpDay.TabIndex = 149;
			dtpDay.ValueChanged += dtpDay_ValueChanged;
			// 
			// ldlDate
			// 
			ldlDate.AutoSize = true;
			ldlDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ldlDate.Location = new Point(12, 52);
			ldlDate.Name = "ldlDate";
			ldlDate.Size = new Size(28, 15);
			ldlDate.TabIndex = 150;
			ldlDate.Text = "Día:";
			// 
			// gpbNormal
			// 
			gpbNormal.Controls.Add(nudOvertime);
			gpbNormal.Controls.Add(label1);
			gpbNormal.Controls.Add(dtpEndExtra);
			gpbNormal.Controls.Add(lblEndExtra);
			gpbNormal.Controls.Add(dtpEndNormal);
			gpbNormal.Controls.Add(lblEndNormal);
			gpbNormal.Controls.Add(dtpBeginNormal);
			gpbNormal.Controls.Add(lblBeginNormal);
			gpbNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			gpbNormal.Location = new Point(12, 94);
			gpbNormal.Name = "gpbNormal";
			gpbNormal.Size = new Size(295, 296);
			gpbNormal.TabIndex = 151;
			gpbNormal.TabStop = false;
			// 
			// nudOvertime
			// 
			nudOvertime.DecimalPlaces = 2;
			nudOvertime.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudOvertime.Location = new Point(10, 249);
			nudOvertime.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudOvertime.Name = "nudOvertime";
			nudOvertime.Size = new Size(44, 23);
			nudOvertime.TabIndex = 163;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(10, 231);
			label1.Name = "label1";
			label1.Size = new Size(79, 15);
			label1.TabIndex = 162;
			label1.Text = "Horas Extras:";
			// 
			// dtpEndExtra
			// 
			dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.Location = new Point(10, 183);
			dtpEndExtra.Name = "dtpEndExtra";
			dtpEndExtra.ShowUpDown = true;
			dtpEndExtra.Size = new Size(273, 23);
			dtpEndExtra.TabIndex = 6;
			// 
			// lblEndExtra
			// 
			lblEndExtra.AutoSize = true;
			lblEndExtra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndExtra.Location = new Point(10, 165);
			lblEndExtra.Name = "lblEndExtra";
			lblEndExtra.Size = new Size(111, 15);
			lblEndExtra.TabIndex = 161;
			lblEndExtra.Text = "Final tiempo extra:";
			// 
			// dtpEndNormal
			// 
			dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.Location = new Point(10, 110);
			dtpEndNormal.Name = "dtpEndNormal";
			dtpEndNormal.ShowUpDown = true;
			dtpEndNormal.Size = new Size(273, 23);
			dtpEndNormal.TabIndex = 5;
			dtpEndNormal.ValueChanged += dtpEndNormal_ValueChanged;
			// 
			// lblEndNormal
			// 
			lblEndNormal.AutoSize = true;
			lblEndNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndNormal.Location = new Point(10, 92);
			lblEndNormal.Name = "lblEndNormal";
			lblEndNormal.Size = new Size(120, 15);
			lblEndNormal.TabIndex = 153;
			lblEndNormal.Text = "Final horario normal:";
			// 
			// dtpBeginNormal
			// 
			dtpBeginNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpBeginNormal.Format = DateTimePickerFormat.Custom;
			dtpBeginNormal.Location = new Point(10, 37);
			dtpBeginNormal.Name = "dtpBeginNormal";
			dtpBeginNormal.ShowUpDown = true;
			dtpBeginNormal.Size = new Size(273, 23);
			dtpBeginNormal.TabIndex = 4;
			dtpBeginNormal.ValueChanged += dtpBeginNormal_ValueChanged;
			// 
			// lblBeginNormal
			// 
			lblBeginNormal.AutoSize = true;
			lblBeginNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblBeginNormal.Location = new Point(10, 19);
			lblBeginNormal.Name = "lblBeginNormal";
			lblBeginNormal.Size = new Size(125, 15);
			lblBeginNormal.TabIndex = 151;
			lblBeginNormal.Text = "Inicio horario normal:";
			// 
			// btnAcept
			// 
			btnAcept.Location = new Point(126, 413);
			btnAcept.Name = "btnAcept";
			btnAcept.Size = new Size(75, 23);
			btnAcept.TabIndex = 152;
			btnAcept.Text = "Aceptar";
			btnAcept.UseVisualStyleBackColor = true;
			btnAcept.Click += btnAcept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(217, 413);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 153;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// FrmAñadir
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(315, 444);
			Controls.Add(btnCancel);
			Controls.Add(btnAcept);
			Controls.Add(gpbNormal);
			Controls.Add(ldlDate);
			Controls.Add(dtpDay);
			Controls.Add(lblTitle);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmAñadir";
			Text = "Añadir Horario";
			Load += FrmAñadir_Load;
			gpbNormal.ResumeLayout(false);
			gpbNormal.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Label lblTitle;
		public DateTimePicker dtpDay;
		private Label ldlDate;
		private GroupBox gpbNormal;
		public NumericUpDown nudOvertime;
		private Label label1;
		public DateTimePicker dtpEndExtra;
		private Label lblEndExtra;
		public DateTimePicker dtpEndNormal;
		private Label lblEndNormal;
		public DateTimePicker dtpBeginNormal;
		private Label lblBeginNormal;
		private Button btnAcept;
		private Button btnCancel;
	}
}
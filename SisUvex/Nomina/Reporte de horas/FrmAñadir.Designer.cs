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
			lblHorasExtras = new Label();
			dtpEndExtra = new DateTimePicker();
			lblEndExtra = new Label();
			dtpEndNormal = new DateTimePicker();
			lblEndNormal = new Label();
			dtpBeginNormal = new DateTimePicker();
			lblBeginNormal = new Label();
			btnAcept = new Button();
			btnCancel = new Button();
			clbCuadrilla = new CheckedListBox();
			lblDescansoHora = new Label();
			lblDescansoFinal = new Label();
			lblDescansoInicial = new Label();
			nudHorasDescanso = new NumericUpDown();
			dtpDescansoFinal = new DateTimePicker();
			dtpDescansoInicial = new DateTimePicker();
			lblComidaHora = new Label();
			lblComidaFinal = new Label();
			lblComicaInicial = new Label();
			nudComidaHora = new NumericUpDown();
			dtpComidaFinal = new DateTimePicker();
			dtpComidaInicial = new DateTimePicker();
			lblCenaHora = new Label();
			lblCenaFinal = new Label();
			lblCenaInicial = new Label();
			nudCenaHora = new NumericUpDown();
			dtpCenaFinal = new DateTimePicker();
			dtpCenaInicial = new DateTimePicker();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			nudD2 = new NumericUpDown();
			dtpDf2 = new DateTimePicker();
			dtpD2 = new DateTimePicker();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			groupBox3 = new GroupBox();
			groupBox4 = new GroupBox();
			groupBox5 = new GroupBox();
			gpbNormal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudD2).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox5.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial Black", 12F);
			lblTitle.Location = new Point(116, 7);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(135, 23);
			lblTitle.TabIndex = 148;
			lblTitle.Text = "Añadir horario";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(46, 46);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(264, 23);
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
			gpbNormal.Controls.Add(lblHorasExtras);
			gpbNormal.Controls.Add(dtpEndExtra);
			gpbNormal.Controls.Add(lblEndExtra);
			gpbNormal.Controls.Add(dtpEndNormal);
			gpbNormal.Controls.Add(lblEndNormal);
			gpbNormal.Controls.Add(dtpBeginNormal);
			gpbNormal.Controls.Add(lblBeginNormal);
			gpbNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			gpbNormal.Location = new Point(15, 176);
			gpbNormal.Name = "gpbNormal";
			gpbNormal.Size = new Size(464, 134);
			gpbNormal.TabIndex = 151;
			gpbNormal.TabStop = false;
			// 
			// nudOvertime
			// 
			nudOvertime.DecimalPlaces = 2;
			nudOvertime.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
			nudOvertime.Location = new Point(266, 97);
			nudOvertime.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudOvertime.Name = "nudOvertime";
			nudOvertime.Size = new Size(52, 23);
			nudOvertime.TabIndex = 163;
			// 
			// lblHorasExtras
			// 
			lblHorasExtras.AutoSize = true;
			lblHorasExtras.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblHorasExtras.Location = new Point(266, 79);
			lblHorasExtras.Name = "lblHorasExtras";
			lblHorasExtras.Size = new Size(79, 15);
			lblHorasExtras.TabIndex = 162;
			lblHorasExtras.Text = "Horas Extras:";
			// 
			// dtpEndExtra
			// 
			dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.Location = new Point(32, 97);
			dtpEndExtra.Name = "dtpEndExtra";
			dtpEndExtra.ShowUpDown = true;
			dtpEndExtra.Size = new Size(161, 23);
			dtpEndExtra.TabIndex = 6;
			// 
			// lblEndExtra
			// 
			lblEndExtra.AutoSize = true;
			lblEndExtra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndExtra.Location = new Point(32, 79);
			lblEndExtra.Name = "lblEndExtra";
			lblEndExtra.Size = new Size(111, 15);
			lblEndExtra.TabIndex = 161;
			lblEndExtra.Text = "Final tiempo extra:";
			// 
			// dtpEndNormal
			// 
			dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.Location = new Point(266, 37);
			dtpEndNormal.Name = "dtpEndNormal";
			dtpEndNormal.ShowUpDown = true;
			dtpEndNormal.Size = new Size(157, 23);
			dtpEndNormal.TabIndex = 5;
			dtpEndNormal.ValueChanged += dtpEndNormal_ValueChanged;
			// 
			// lblEndNormal
			// 
			lblEndNormal.AutoSize = true;
			lblEndNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndNormal.Location = new Point(266, 19);
			lblEndNormal.Name = "lblEndNormal";
			lblEndNormal.Size = new Size(120, 15);
			lblEndNormal.TabIndex = 153;
			lblEndNormal.Text = "Final horario normal:";
			// 
			// dtpBeginNormal
			// 
			dtpBeginNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpBeginNormal.Format = DateTimePickerFormat.Custom;
			dtpBeginNormal.Location = new Point(32, 37);
			dtpBeginNormal.Name = "dtpBeginNormal";
			dtpBeginNormal.ShowUpDown = true;
			dtpBeginNormal.Size = new Size(161, 23);
			dtpBeginNormal.TabIndex = 4;
			dtpBeginNormal.ValueChanged += dtpBeginNormal_ValueChanged;
			// 
			// lblBeginNormal
			// 
			lblBeginNormal.AutoSize = true;
			lblBeginNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblBeginNormal.Location = new Point(32, 19);
			lblBeginNormal.Name = "lblBeginNormal";
			lblBeginNormal.Size = new Size(125, 15);
			lblBeginNormal.TabIndex = 151;
			lblBeginNormal.Text = "Inicio horario normal:";
			// 
			// btnAcept
			// 
			btnAcept.Location = new Point(308, 506);
			btnAcept.Name = "btnAcept";
			btnAcept.Size = new Size(75, 23);
			btnAcept.TabIndex = 152;
			btnAcept.Text = "Aceptar";
			btnAcept.UseVisualStyleBackColor = true;
			btnAcept.Click += btnAcept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(389, 506);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 153;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// clbCuadrilla
			// 
			clbCuadrilla.FormattingEnabled = true;
			clbCuadrilla.Location = new Point(5, 20);
			clbCuadrilla.Name = "clbCuadrilla";
			clbCuadrilla.Size = new Size(391, 58);
			clbCuadrilla.TabIndex = 154;
			// 
			// lblDescansoHora
			// 
			lblDescansoHora.AutoSize = true;
			lblDescansoHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoHora.Location = new Point(5, 119);
			lblDescansoHora.Name = "lblDescansoHora";
			lblDescansoHora.Size = new Size(37, 15);
			lblDescansoHora.TabIndex = 167;
			lblDescansoHora.Text = "Hora:";
			// 
			// lblDescansoFinal
			// 
			lblDescansoFinal.AutoSize = true;
			lblDescansoFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoFinal.Location = new Point(5, 72);
			lblDescansoFinal.Name = "lblDescansoFinal";
			lblDescansoFinal.Size = new Size(65, 15);
			lblDescansoFinal.TabIndex = 166;
			lblDescansoFinal.Text = "Hora Final:";
			// 
			// lblDescansoInicial
			// 
			lblDescansoInicial.AutoSize = true;
			lblDescansoInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoInicial.Location = new Point(5, 20);
			lblDescansoInicial.Name = "lblDescansoInicial";
			lblDescansoInicial.Size = new Size(72, 15);
			lblDescansoInicial.TabIndex = 165;
			lblDescansoInicial.Text = "Hora Inicial:";
			// 
			// nudHorasDescanso
			// 
			nudHorasDescanso.DecimalPlaces = 2;
			nudHorasDescanso.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudHorasDescanso.Location = new Point(5, 137);
			nudHorasDescanso.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudHorasDescanso.Name = "nudHorasDescanso";
			nudHorasDescanso.Size = new Size(51, 23);
			nudHorasDescanso.TabIndex = 164;
			// 
			// dtpDescansoFinal
			// 
			dtpDescansoFinal.CustomFormat = "HH:mm:ss";
			dtpDescansoFinal.Format = DateTimePickerFormat.Custom;
			dtpDescansoFinal.Location = new Point(5, 90);
			dtpDescansoFinal.Name = "dtpDescansoFinal";
			dtpDescansoFinal.ShowCheckBox = true;
			dtpDescansoFinal.ShowUpDown = true;
			dtpDescansoFinal.Size = new Size(93, 23);
			dtpDescansoFinal.TabIndex = 6;
			dtpDescansoFinal.ValueChanged += dtpDescansoFinal_ValueChanged;
			// 
			// dtpDescansoInicial
			// 
			dtpDescansoInicial.CustomFormat = "HH:mm:ss";
			dtpDescansoInicial.Format = DateTimePickerFormat.Custom;
			dtpDescansoInicial.Location = new Point(5, 38);
			dtpDescansoInicial.Name = "dtpDescansoInicial";
			dtpDescansoInicial.ShowCheckBox = true;
			dtpDescansoInicial.ShowUpDown = true;
			dtpDescansoInicial.Size = new Size(91, 23);
			dtpDescansoInicial.TabIndex = 5;
			dtpDescansoInicial.ValueChanged += dtpDescansoInicial_ValueChanged;
			// 
			// lblComidaHora
			// 
			lblComidaHora.AutoSize = true;
			lblComidaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaHora.Location = new Point(5, 119);
			lblComidaHora.Name = "lblComidaHora";
			lblComidaHora.Size = new Size(37, 15);
			lblComidaHora.TabIndex = 173;
			lblComidaHora.Text = "Hora:";
			// 
			// lblComidaFinal
			// 
			lblComidaFinal.AutoSize = true;
			lblComidaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaFinal.Location = new Point(5, 68);
			lblComidaFinal.Name = "lblComidaFinal";
			lblComidaFinal.Size = new Size(65, 15);
			lblComidaFinal.TabIndex = 172;
			lblComidaFinal.Text = "Hora Final:";
			// 
			// lblComicaInicial
			// 
			lblComicaInicial.AutoSize = true;
			lblComicaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComicaInicial.Location = new Point(5, 19);
			lblComicaInicial.Name = "lblComicaInicial";
			lblComicaInicial.Size = new Size(72, 15);
			lblComicaInicial.TabIndex = 171;
			lblComicaInicial.Text = "Hora Inicial:";
			// 
			// nudComidaHora
			// 
			nudComidaHora.DecimalPlaces = 2;
			nudComidaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudComidaHora.Location = new Point(5, 137);
			nudComidaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudComidaHora.Name = "nudComidaHora";
			nudComidaHora.Size = new Size(51, 23);
			nudComidaHora.TabIndex = 170;
			// 
			// dtpComidaFinal
			// 
			dtpComidaFinal.CustomFormat = "HH:mm:ss";
			dtpComidaFinal.Format = DateTimePickerFormat.Custom;
			dtpComidaFinal.Location = new Point(5, 86);
			dtpComidaFinal.Name = "dtpComidaFinal";
			dtpComidaFinal.ShowCheckBox = true;
			dtpComidaFinal.ShowUpDown = true;
			dtpComidaFinal.Size = new Size(93, 23);
			dtpComidaFinal.TabIndex = 169;
			dtpComidaFinal.ValueChanged += dtpComidaFinal_ValueChanged;
			// 
			// dtpComidaInicial
			// 
			dtpComidaInicial.CustomFormat = "HH:mm:ss";
			dtpComidaInicial.Format = DateTimePickerFormat.Custom;
			dtpComidaInicial.Location = new Point(5, 37);
			dtpComidaInicial.Name = "dtpComidaInicial";
			dtpComidaInicial.ShowCheckBox = true;
			dtpComidaInicial.ShowUpDown = true;
			dtpComidaInicial.Size = new Size(91, 23);
			dtpComidaInicial.TabIndex = 168;
			dtpComidaInicial.ValueChanged += dtpComidaInicial_ValueChanged;
			// 
			// lblCenaHora
			// 
			lblCenaHora.AutoSize = true;
			lblCenaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaHora.Location = new Point(5, 121);
			lblCenaHora.Name = "lblCenaHora";
			lblCenaHora.Size = new Size(37, 15);
			lblCenaHora.TabIndex = 179;
			lblCenaHora.Text = "Hora:";
			// 
			// lblCenaFinal
			// 
			lblCenaFinal.AutoSize = true;
			lblCenaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaFinal.Location = new Point(5, 69);
			lblCenaFinal.Name = "lblCenaFinal";
			lblCenaFinal.Size = new Size(65, 15);
			lblCenaFinal.TabIndex = 178;
			lblCenaFinal.Text = "Hora Final:";
			// 
			// lblCenaInicial
			// 
			lblCenaInicial.AutoSize = true;
			lblCenaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaInicial.Location = new Point(5, 20);
			lblCenaInicial.Name = "lblCenaInicial";
			lblCenaInicial.Size = new Size(72, 15);
			lblCenaInicial.TabIndex = 177;
			lblCenaInicial.Text = "Hora Inicial:";
			// 
			// nudCenaHora
			// 
			nudCenaHora.DecimalPlaces = 2;
			nudCenaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudCenaHora.Location = new Point(5, 139);
			nudCenaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudCenaHora.Name = "nudCenaHora";
			nudCenaHora.Size = new Size(50, 23);
			nudCenaHora.TabIndex = 176;
			// 
			// dtpCenaFinal
			// 
			dtpCenaFinal.CustomFormat = "HH:mm:ss";
			dtpCenaFinal.Format = DateTimePickerFormat.Custom;
			dtpCenaFinal.Location = new Point(5, 87);
			dtpCenaFinal.Name = "dtpCenaFinal";
			dtpCenaFinal.ShowCheckBox = true;
			dtpCenaFinal.ShowUpDown = true;
			dtpCenaFinal.Size = new Size(96, 23);
			dtpCenaFinal.TabIndex = 175;
			dtpCenaFinal.ValueChanged += dtpCenaFinal_ValueChanged;
			// 
			// dtpCenaInicial
			// 
			dtpCenaInicial.CustomFormat = "HH:mm:ss";
			dtpCenaInicial.Format = DateTimePickerFormat.Custom;
			dtpCenaInicial.Location = new Point(5, 38);
			dtpCenaInicial.Name = "dtpCenaInicial";
			dtpCenaInicial.ShowCheckBox = true;
			dtpCenaInicial.ShowUpDown = true;
			dtpCenaInicial.Size = new Size(94, 23);
			dtpCenaInicial.TabIndex = 174;
			dtpCenaInicial.ValueChanged += dtpCenaInicial_ValueChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(5, 119);
			label2.Name = "label2";
			label2.Size = new Size(37, 15);
			label2.TabIndex = 167;
			label2.Text = "Hora:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(5, 74);
			label3.Name = "label3";
			label3.Size = new Size(65, 15);
			label3.TabIndex = 166;
			label3.Text = "Hora Final:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(5, 22);
			label4.Name = "label4";
			label4.Size = new Size(72, 15);
			label4.TabIndex = 165;
			label4.Text = "Hora Inicial:";
			// 
			// nudD2
			// 
			nudD2.DecimalPlaces = 2;
			nudD2.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudD2.Location = new Point(5, 137);
			nudD2.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudD2.Name = "nudD2";
			nudD2.Size = new Size(44, 23);
			nudD2.TabIndex = 164;
			// 
			// dtpDf2
			// 
			dtpDf2.CustomFormat = "HH:mm:ss";
			dtpDf2.Format = DateTimePickerFormat.Custom;
			dtpDf2.Location = new Point(5, 92);
			dtpDf2.Name = "dtpDf2";
			dtpDf2.ShowCheckBox = true;
			dtpDf2.ShowUpDown = true;
			dtpDf2.Size = new Size(92, 23);
			dtpDf2.TabIndex = 6;
			dtpDf2.ValueChanged += dtpDf2_ValueChanged;
			// 
			// dtpD2
			// 
			dtpD2.CustomFormat = "HH:mm:ss";
			dtpD2.Format = DateTimePickerFormat.Custom;
			dtpD2.Location = new Point(5, 40);
			dtpD2.Name = "dtpD2";
			dtpD2.ShowCheckBox = true;
			dtpD2.ShowUpDown = true;
			dtpD2.Size = new Size(91, 23);
			dtpD2.TabIndex = 5;
			dtpD2.ValueChanged += dtpD2_ValueChanged;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(clbCuadrilla);
			groupBox1.Location = new Point(15, 71);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(401, 104);
			groupBox1.TabIndex = 164;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cuadrillas";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(lblComidaHora);
			groupBox2.Controls.Add(nudComidaHora);
			groupBox2.Controls.Add(dtpComidaInicial);
			groupBox2.Controls.Add(lblComidaFinal);
			groupBox2.Controls.Add(lblComicaInicial);
			groupBox2.Controls.Add(dtpComidaFinal);
			groupBox2.Location = new Point(12, 327);
			groupBox2.Margin = new Padding(3, 2, 3, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(3, 2, 3, 2);
			groupBox2.Size = new Size(113, 163);
			groupBox2.TabIndex = 165;
			groupBox2.TabStop = false;
			groupBox2.Text = "Comida";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(lblCenaHora);
			groupBox3.Controls.Add(nudCenaHora);
			groupBox3.Controls.Add(lblCenaInicial);
			groupBox3.Controls.Add(lblCenaFinal);
			groupBox3.Controls.Add(dtpCenaInicial);
			groupBox3.Controls.Add(dtpCenaFinal);
			groupBox3.Location = new Point(130, 327);
			groupBox3.Margin = new Padding(3, 2, 3, 2);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(3, 2, 3, 2);
			groupBox3.Size = new Size(113, 163);
			groupBox3.TabIndex = 166;
			groupBox3.TabStop = false;
			groupBox3.Text = "Cena";
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(lblDescansoHora);
			groupBox4.Controls.Add(nudHorasDescanso);
			groupBox4.Controls.Add(dtpDescansoInicial);
			groupBox4.Controls.Add(lblDescansoFinal);
			groupBox4.Controls.Add(lblDescansoInicial);
			groupBox4.Controls.Add(dtpDescansoFinal);
			groupBox4.Location = new Point(248, 327);
			groupBox4.Margin = new Padding(3, 2, 3, 2);
			groupBox4.Name = "groupBox4";
			groupBox4.Padding = new Padding(3, 2, 3, 2);
			groupBox4.Size = new Size(113, 163);
			groupBox4.TabIndex = 167;
			groupBox4.TabStop = false;
			groupBox4.Text = "Descanso";
			// 
			// groupBox5
			// 
			groupBox5.Controls.Add(label2);
			groupBox5.Controls.Add(nudD2);
			groupBox5.Controls.Add(label4);
			groupBox5.Controls.Add(label3);
			groupBox5.Controls.Add(dtpD2);
			groupBox5.Controls.Add(dtpDf2);
			groupBox5.Location = new Point(367, 327);
			groupBox5.Margin = new Padding(3, 2, 3, 2);
			groupBox5.Name = "groupBox5";
			groupBox5.Padding = new Padding(3, 2, 3, 2);
			groupBox5.Size = new Size(112, 163);
			groupBox5.TabIndex = 168;
			groupBox5.TabStop = false;
			groupBox5.Text = "Descanso 2";
			// 
			// FrmAñadir
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(490, 534);
			Controls.Add(groupBox5);
			Controls.Add(groupBox4);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
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
			Shown += FrmAñadir_Shown;
			gpbNormal.ResumeLayout(false);
			gpbNormal.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).EndInit();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).EndInit();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).EndInit();
			((System.ComponentModel.ISupportInitialize)nudD2).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox5.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Label lblTitle;
		public DateTimePicker dtpDay;
		private Label ldlDate;
		private GroupBox gpbNormal;
		public NumericUpDown nudOvertime;
		private Label lblHorasExtras;
		public DateTimePicker dtpEndExtra;
		private Label lblEndExtra;
		public DateTimePicker dtpEndNormal;
		private Label lblEndNormal;
		public DateTimePicker dtpBeginNormal;
		private Label lblBeginNormal;
		private Button btnAcept;
		private Button btnCancel;
		public CheckedListBox clbCuadrilla;
		public DateTimePicker dtpDescansoInicial;
		private Label lblDescansoInicial;
		public NumericUpDown nudHorasDescanso;
		public DateTimePicker dtpDescansoFinal;
		private Label lblDescansoHora;
		private Label lblDescansoFinal;
		private Label lblComidaHora;
		private Label lblComidaFinal;
		private Label lblComicaInicial;
		public NumericUpDown nudComidaHora;
		public DateTimePicker dtpComidaFinal;
		public DateTimePicker dtpComidaInicial;
		private Label lblCenaHora;
		private Label lblCenaFinal;
		private Label lblCenaInicial;
		public NumericUpDown nudCenaHora;
		public DateTimePicker dtpCenaFinal;
		public DateTimePicker dtpCenaInicial;
		private Label label2;
		private Label label3;
		private Label label4;
		public NumericUpDown nudD2;
		public DateTimePicker dtpDf2;
		public DateTimePicker dtpD2;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private GroupBox groupBox4;
		private GroupBox groupBox5;
	}
}
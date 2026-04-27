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
			lblCuadrilla = new Label();
			pllDescanso = new Panel();
			lblDescansoHora = new Label();
			lblDescansoFinal = new Label();
			lblDescansoInicial = new Label();
			nudHorasDescanso = new NumericUpDown();
			dtpDescansoFinal = new DateTimePicker();
			dtpDescansoInicial = new DateTimePicker();
			pllComida = new Panel();
			lblComidaHora = new Label();
			lblComidaFinal = new Label();
			lblComicaInicial = new Label();
			nudComidaHora = new NumericUpDown();
			dtpComidaFinal = new DateTimePicker();
			dtpComidaInicial = new DateTimePicker();
			pllCena = new Panel();
			lblCenaHora = new Label();
			lblCenaFinal = new Label();
			lblCenaInicial = new Label();
			nudCenaHora = new NumericUpDown();
			dtpCenaFinal = new DateTimePicker();
			dtpCenaInicial = new DateTimePicker();
			lblDescanso = new Label();
			lblComida = new Label();
			lblCena = new Label();
			label1 = new Label();
			panel1 = new Panel();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			nudD2 = new NumericUpDown();
			dtpDf2 = new DateTimePicker();
			dtpD2 = new DateTimePicker();
			gpbNormal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).BeginInit();
			pllDescanso.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).BeginInit();
			pllComida.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).BeginInit();
			pllCena.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudD2).BeginInit();
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
			gpbNormal.Size = new Size(382, 134);
			gpbNormal.TabIndex = 151;
			gpbNormal.TabStop = false;
			// 
			// nudOvertime
			// 
			nudOvertime.DecimalPlaces = 2;
			nudOvertime.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
			nudOvertime.Location = new Point(210, 97);
			nudOvertime.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudOvertime.Name = "nudOvertime";
			nudOvertime.Size = new Size(44, 23);
			nudOvertime.TabIndex = 163;
			// 
			// lblHorasExtras
			// 
			lblHorasExtras.AutoSize = true;
			lblHorasExtras.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblHorasExtras.Location = new Point(210, 79);
			lblHorasExtras.Name = "lblHorasExtras";
			lblHorasExtras.Size = new Size(79, 15);
			lblHorasExtras.TabIndex = 162;
			lblHorasExtras.Text = "Horas Extras:";
			// 
			// dtpEndExtra
			// 
			dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.Location = new Point(10, 97);
			dtpEndExtra.Name = "dtpEndExtra";
			dtpEndExtra.ShowUpDown = true;
			dtpEndExtra.Size = new Size(154, 23);
			dtpEndExtra.TabIndex = 6;
			// 
			// lblEndExtra
			// 
			lblEndExtra.AutoSize = true;
			lblEndExtra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndExtra.Location = new Point(10, 79);
			lblEndExtra.Name = "lblEndExtra";
			lblEndExtra.Size = new Size(111, 15);
			lblEndExtra.TabIndex = 161;
			lblEndExtra.Text = "Final tiempo extra:";
			// 
			// dtpEndNormal
			// 
			dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.Location = new Point(210, 37);
			dtpEndNormal.Name = "dtpEndNormal";
			dtpEndNormal.ShowUpDown = true;
			dtpEndNormal.Size = new Size(154, 23);
			dtpEndNormal.TabIndex = 5;
			dtpEndNormal.ValueChanged += dtpEndNormal_ValueChanged;
			// 
			// lblEndNormal
			// 
			lblEndNormal.AutoSize = true;
			lblEndNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndNormal.Location = new Point(210, 19);
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
			dtpBeginNormal.Size = new Size(154, 23);
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
			btnAcept.Location = new Point(242, 730);
			btnAcept.Name = "btnAcept";
			btnAcept.Size = new Size(75, 23);
			btnAcept.TabIndex = 152;
			btnAcept.Text = "Aceptar";
			btnAcept.UseVisualStyleBackColor = true;
			btnAcept.Click += btnAcept_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(323, 730);
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
			clbCuadrilla.Location = new Point(15, 103);
			clbCuadrilla.Name = "clbCuadrilla";
			clbCuadrilla.Size = new Size(277, 76);
			clbCuadrilla.TabIndex = 154;
			// 
			// lblCuadrilla
			// 
			lblCuadrilla.AutoSize = true;
			lblCuadrilla.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCuadrilla.Location = new Point(15, 81);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(66, 17);
			lblCuadrilla.TabIndex = 155;
			lblCuadrilla.Text = "Cuadrillas";
			// 
			// pllDescanso
			// 
			pllDescanso.BackColor = SystemColors.ActiveCaption;
			pllDescanso.BorderStyle = BorderStyle.FixedSingle;
			pllDescanso.Controls.Add(lblDescansoHora);
			pllDescanso.Controls.Add(lblDescansoFinal);
			pllDescanso.Controls.Add(lblDescansoInicial);
			pllDescanso.Controls.Add(nudHorasDescanso);
			pllDescanso.Controls.Add(dtpDescansoFinal);
			pllDescanso.Controls.Add(dtpDescansoInicial);
			pllDescanso.Location = new Point(13, 543);
			pllDescanso.Name = "pllDescanso";
			pllDescanso.Size = new Size(384, 77);
			pllDescanso.TabIndex = 156;
			// 
			// lblDescansoHora
			// 
			lblDescansoHora.AutoSize = true;
			lblDescansoHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoHora.Location = new Point(319, 16);
			lblDescansoHora.Name = "lblDescansoHora";
			lblDescansoHora.Size = new Size(37, 15);
			lblDescansoHora.TabIndex = 167;
			lblDescansoHora.Text = "Hora:";
			// 
			// lblDescansoFinal
			// 
			lblDescansoFinal.AutoSize = true;
			lblDescansoFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoFinal.Location = new Point(155, 16);
			lblDescansoFinal.Name = "lblDescansoFinal";
			lblDescansoFinal.Size = new Size(65, 15);
			lblDescansoFinal.TabIndex = 166;
			lblDescansoFinal.Text = "Hora Final:";
			// 
			// lblDescansoInicial
			// 
			lblDescansoInicial.AutoSize = true;
			lblDescansoInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoInicial.Location = new Point(9, 16);
			lblDescansoInicial.Name = "lblDescansoInicial";
			lblDescansoInicial.Size = new Size(72, 15);
			lblDescansoInicial.TabIndex = 165;
			lblDescansoInicial.Text = "Hora Inicial:";
			// 
			// nudHorasDescanso
			// 
			nudHorasDescanso.DecimalPlaces = 2;
			nudHorasDescanso.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudHorasDescanso.Location = new Point(319, 34);
			nudHorasDescanso.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudHorasDescanso.Name = "nudHorasDescanso";
			nudHorasDescanso.Size = new Size(44, 23);
			nudHorasDescanso.TabIndex = 164;
			// 
			// dtpDescansoFinal
			// 
			dtpDescansoFinal.CustomFormat = "HH:mm:ss";
			dtpDescansoFinal.Format = DateTimePickerFormat.Custom;
			dtpDescansoFinal.Location = new Point(155, 34);
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
			dtpDescansoInicial.Location = new Point(9, 34);
			dtpDescansoInicial.Name = "dtpDescansoInicial";
			dtpDescansoInicial.ShowCheckBox = true;
			dtpDescansoInicial.ShowUpDown = true;
			dtpDescansoInicial.Size = new Size(91, 23);
			dtpDescansoInicial.TabIndex = 5;
			dtpDescansoInicial.ValueChanged += dtpDescansoInicial_ValueChanged;
			// 
			// pllComida
			// 
			pllComida.BackColor = SystemColors.ActiveCaption;
			pllComida.BorderStyle = BorderStyle.FixedSingle;
			pllComida.Controls.Add(lblComidaHora);
			pllComida.Controls.Add(lblComidaFinal);
			pllComida.Controls.Add(lblComicaInicial);
			pllComida.Controls.Add(nudComidaHora);
			pllComida.Controls.Add(dtpComidaFinal);
			pllComida.Controls.Add(dtpComidaInicial);
			pllComida.Location = new Point(13, 337);
			pllComida.Name = "pllComida";
			pllComida.Size = new Size(384, 77);
			pllComida.TabIndex = 157;
			// 
			// lblComidaHora
			// 
			lblComidaHora.AutoSize = true;
			lblComidaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaHora.Location = new Point(319, 17);
			lblComidaHora.Name = "lblComidaHora";
			lblComidaHora.Size = new Size(37, 15);
			lblComidaHora.TabIndex = 173;
			lblComidaHora.Text = "Hora:";
			// 
			// lblComidaFinal
			// 
			lblComidaFinal.AutoSize = true;
			lblComidaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaFinal.Location = new Point(155, 17);
			lblComidaFinal.Name = "lblComidaFinal";
			lblComidaFinal.Size = new Size(65, 15);
			lblComidaFinal.TabIndex = 172;
			lblComidaFinal.Text = "Hora Final:";
			// 
			// lblComicaInicial
			// 
			lblComicaInicial.AutoSize = true;
			lblComicaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComicaInicial.Location = new Point(9, 17);
			lblComicaInicial.Name = "lblComicaInicial";
			lblComicaInicial.Size = new Size(72, 15);
			lblComicaInicial.TabIndex = 171;
			lblComicaInicial.Text = "Hora Inicial:";
			// 
			// nudComidaHora
			// 
			nudComidaHora.DecimalPlaces = 2;
			nudComidaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudComidaHora.Location = new Point(319, 35);
			nudComidaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudComidaHora.Name = "nudComidaHora";
			nudComidaHora.Size = new Size(44, 23);
			nudComidaHora.TabIndex = 170;
			// 
			// dtpComidaFinal
			// 
			dtpComidaFinal.CustomFormat = "HH:mm:ss";
			dtpComidaFinal.Format = DateTimePickerFormat.Custom;
			dtpComidaFinal.Location = new Point(155, 35);
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
			dtpComidaInicial.Location = new Point(9, 35);
			dtpComidaInicial.Name = "dtpComidaInicial";
			dtpComidaInicial.ShowCheckBox = true;
			dtpComidaInicial.ShowUpDown = true;
			dtpComidaInicial.Size = new Size(91, 23);
			dtpComidaInicial.TabIndex = 168;
			dtpComidaInicial.ValueChanged += dtpDinicial2_ValueChanged;
			// 
			// pllCena
			// 
			pllCena.BackColor = SystemColors.ActiveCaption;
			pllCena.BorderStyle = BorderStyle.FixedSingle;
			pllCena.Controls.Add(lblCenaHora);
			pllCena.Controls.Add(lblCenaFinal);
			pllCena.Controls.Add(lblCenaInicial);
			pllCena.Controls.Add(nudCenaHora);
			pllCena.Controls.Add(dtpCenaFinal);
			pllCena.Controls.Add(dtpCenaInicial);
			pllCena.Location = new Point(10, 441);
			pllCena.Name = "pllCena";
			pllCena.Size = new Size(387, 77);
			pllCena.TabIndex = 158;
			// 
			// lblCenaHora
			// 
			lblCenaHora.AutoSize = true;
			lblCenaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaHora.Location = new Point(319, 20);
			lblCenaHora.Name = "lblCenaHora";
			lblCenaHora.Size = new Size(37, 15);
			lblCenaHora.TabIndex = 179;
			lblCenaHora.Text = "Hora:";
			// 
			// lblCenaFinal
			// 
			lblCenaFinal.AutoSize = true;
			lblCenaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaFinal.Location = new Point(155, 20);
			lblCenaFinal.Name = "lblCenaFinal";
			lblCenaFinal.Size = new Size(65, 15);
			lblCenaFinal.TabIndex = 178;
			lblCenaFinal.Text = "Hora Final:";
			// 
			// lblCenaInicial
			// 
			lblCenaInicial.AutoSize = true;
			lblCenaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaInicial.Location = new Point(9, 20);
			lblCenaInicial.Name = "lblCenaInicial";
			lblCenaInicial.Size = new Size(72, 15);
			lblCenaInicial.TabIndex = 177;
			lblCenaInicial.Text = "Hora Inicial:";
			// 
			// nudCenaHora
			// 
			nudCenaHora.DecimalPlaces = 2;
			nudCenaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudCenaHora.Location = new Point(319, 38);
			nudCenaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudCenaHora.Name = "nudCenaHora";
			nudCenaHora.Size = new Size(44, 23);
			nudCenaHora.TabIndex = 176;
			// 
			// dtpCenaFinal
			// 
			dtpCenaFinal.CustomFormat = "HH:mm:ss";
			dtpCenaFinal.Format = DateTimePickerFormat.Custom;
			dtpCenaFinal.Location = new Point(155, 38);
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
			dtpCenaInicial.Location = new Point(9, 38);
			dtpCenaInicial.Name = "dtpCenaInicial";
			dtpCenaInicial.ShowCheckBox = true;
			dtpCenaInicial.ShowUpDown = true;
			dtpCenaInicial.Size = new Size(94, 23);
			dtpCenaInicial.TabIndex = 174;
			dtpCenaInicial.ValueChanged += dtpCenaInicial_ValueChanged;
			// 
			// lblDescanso
			// 
			lblDescanso.AutoSize = true;
			lblDescanso.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescanso.Location = new Point(169, 519);
			lblDescanso.Name = "lblDescanso";
			lblDescanso.Size = new Size(79, 21);
			lblDescanso.TabIndex = 159;
			lblDescanso.Text = "Descanso";
			// 
			// lblComida
			// 
			lblComida.AutoSize = true;
			lblComida.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComida.Location = new Point(165, 313);
			lblComida.Name = "lblComida";
			lblComida.Size = new Size(66, 21);
			lblComida.TabIndex = 160;
			lblComida.Text = "Comida";
			// 
			// lblCena
			// 
			lblCena.AutoSize = true;
			lblCena.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCena.Location = new Point(165, 417);
			lblCena.Name = "lblCena";
			lblCena.Size = new Size(46, 21);
			lblCena.TabIndex = 161;
			lblCena.Text = "Cena";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(169, 623);
			label1.Name = "label1";
			label1.Size = new Size(92, 21);
			label1.TabIndex = 163;
			label1.Text = "Descanso 2";
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveCaption;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(label2);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(nudD2);
			panel1.Controls.Add(dtpDf2);
			panel1.Controls.Add(dtpD2);
			panel1.Location = new Point(13, 647);
			panel1.Name = "panel1";
			panel1.Size = new Size(384, 77);
			panel1.TabIndex = 162;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(319, 16);
			label2.Name = "label2";
			label2.Size = new Size(37, 15);
			label2.TabIndex = 167;
			label2.Text = "Hora:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(155, 16);
			label3.Name = "label3";
			label3.Size = new Size(65, 15);
			label3.TabIndex = 166;
			label3.Text = "Hora Final:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(9, 16);
			label4.Name = "label4";
			label4.Size = new Size(72, 15);
			label4.TabIndex = 165;
			label4.Text = "Hora Inicial:";
			// 
			// nudD2
			// 
			nudD2.DecimalPlaces = 2;
			nudD2.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudD2.Location = new Point(319, 34);
			nudD2.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudD2.Name = "nudD2";
			nudD2.Size = new Size(44, 23);
			nudD2.TabIndex = 164;
			// 
			// dtpDf2
			// 
			dtpDf2.CustomFormat = "HH:mm:ss";
			dtpDf2.Format = DateTimePickerFormat.Custom;
			dtpDf2.Location = new Point(155, 34);
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
			dtpD2.Location = new Point(9, 34);
			dtpD2.Name = "dtpD2";
			dtpD2.ShowCheckBox = true;
			dtpD2.ShowUpDown = true;
			dtpD2.Size = new Size(91, 23);
			dtpD2.TabIndex = 5;
			dtpD2.ValueChanged += dtpD2_ValueChanged;
			// 
			// FrmAñadir
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(411, 759);
			Controls.Add(label1);
			Controls.Add(panel1);
			Controls.Add(lblCena);
			Controls.Add(lblComida);
			Controls.Add(lblDescanso);
			Controls.Add(pllCena);
			Controls.Add(pllComida);
			Controls.Add(pllDescanso);
			Controls.Add(lblCuadrilla);
			Controls.Add(clbCuadrilla);
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
			pllDescanso.ResumeLayout(false);
			pllDescanso.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).EndInit();
			pllComida.ResumeLayout(false);
			pllComida.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).EndInit();
			pllCena.ResumeLayout(false);
			pllCena.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudD2).EndInit();
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
		private Label lblCuadrilla;
		private Label lblCena;
		private Panel pllDescanso;
		public DateTimePicker dtpDescansoInicial;
		private Panel pllComida;
		private Panel pllCena;
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
		private Label lblDescanso;
		private Label lblComida;
		private Label lblCenaHora;
		private Label lblCenaFinal;
		private Label lblCenaInicial;
		public NumericUpDown nudCenaHora;
		public DateTimePicker dtpCenaFinal;
		public DateTimePicker dtpCenaInicial;
		private Label label1;
		private Panel panel1;
		private Label label2;
		private Label label3;
		private Label label4;
		public NumericUpDown nudD2;
		public DateTimePicker dtpDf2;
		public DateTimePicker dtpD2;
	}
}
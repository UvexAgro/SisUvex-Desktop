namespace SisUvex.Nomina.Work_time
{
    partial class FrmWorkTimeAdd
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkTimeAdd));
			lblTitle = new Label();
			gpbNormal = new GroupBox();
			nudOvertime = new NumericUpDown();
			label1 = new Label();
			dtpEndExtra = new DateTimePicker();
			lblEndExtra = new Label();
			dtpEndNormal = new DateTimePicker();
			lblEndNormal = new Label();
			dtpBeginNormal = new DateTimePicker();
			lblBeginNormal = new Label();
			ldlDate = new Label();
			dtpDay = new DateTimePicker();
			btnCancel = new Button();
			lblWorkGroup = new Label();
			cboProductionLine = new ComboBox();
			chbActiveProductionLine = new CheckBox();
			btnAcept = new Button();
			txbWorkers = new TextBox();
			lblWorkers = new Label();
			lblDescanso = new Label();
			pllDescanso = new Panel();
			lblDescansoHora = new Label();
			lblDescansoFinal = new Label();
			lblDescansoInicial = new Label();
			nudHorasDescanso = new NumericUpDown();
			dtpDescansoFinal = new DateTimePicker();
			dtpDescansoInicial = new DateTimePicker();
			lblCena = new Label();
			lblComida = new Label();
			pllCena = new Panel();
			lblCenaHora = new Label();
			lblCenaFinal = new Label();
			lblCenaInicial = new Label();
			nudCenaHora = new NumericUpDown();
			dtpCenaFinal = new DateTimePicker();
			dtpCenaInicial = new DateTimePicker();
			pllComida = new Panel();
			lblComidaHora = new Label();
			lblComidaFinal = new Label();
			lblComicaInicial = new Label();
			nudComidaHora = new NumericUpDown();
			dtpComidaFinal = new DateTimePicker();
			dtpComidaInicial = new DateTimePicker();
			lblCuadrilla = new Label();
			clbCuadrilla = new CheckedListBox();
			label2 = new Label();
			panel1 = new Panel();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			nudHorasD2 = new NumericUpDown();
			dtpFinalD2 = new DateTimePicker();
			dtpDinicial2 = new DateTimePicker();
			gpbNormal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).BeginInit();
			pllDescanso.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).BeginInit();
			pllCena.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).BeginInit();
			pllComida.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudHorasD2).BeginInit();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial Black", 12F);
			lblTitle.Location = new Point(12, 9);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(135, 23);
			lblTitle.TabIndex = 147;
			lblTitle.Text = "Añadir horario";
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
			gpbNormal.Location = new Point(10, 131);
			gpbNormal.Name = "gpbNormal";
			gpbNormal.Size = new Size(431, 145);
			gpbNormal.TabIndex = 148;
			gpbNormal.TabStop = false;
			// 
			// nudOvertime
			// 
			nudOvertime.DecimalPlaces = 2;
			nudOvertime.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudOvertime.Location = new Point(233, 112);
			nudOvertime.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudOvertime.Name = "nudOvertime";
			nudOvertime.Size = new Size(44, 23);
			nudOvertime.TabIndex = 163;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(233, 94);
			label1.Name = "label1";
			label1.Size = new Size(79, 15);
			label1.TabIndex = 162;
			label1.Text = "Horas Extras:";
			// 
			// dtpEndExtra
			// 
			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.Location = new Point(10, 112);
			dtpEndExtra.Name = "dtpEndExtra";
			dtpEndExtra.Size = new Size(188, 23);
			dtpEndExtra.TabIndex = 6;
			// 
			// lblEndExtra
			// 
			lblEndExtra.AutoSize = true;
			lblEndExtra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndExtra.Location = new Point(10, 94);
			lblEndExtra.Name = "lblEndExtra";
			lblEndExtra.Size = new Size(111, 15);
			lblEndExtra.TabIndex = 161;
			lblEndExtra.Text = "Final tiempo extra:";
			// 
			// dtpEndNormal
			// 
			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.Location = new Point(233, 37);
			dtpEndNormal.Name = "dtpEndNormal";
			dtpEndNormal.Size = new Size(188, 23);
			dtpEndNormal.TabIndex = 5;
			dtpEndNormal.ValueChanged += dtpEndNormal_ValueChanged;
			// 
			// lblEndNormal
			// 
			lblEndNormal.AutoSize = true;
			lblEndNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndNormal.Location = new Point(233, 19);
			lblEndNormal.Name = "lblEndNormal";
			lblEndNormal.Size = new Size(120, 15);
			lblEndNormal.TabIndex = 153;
			lblEndNormal.Text = "Final horario normal:";
			// 
			// dtpBeginNormal
			// 
			dtpBeginNormal.Format = DateTimePickerFormat.Custom;
			dtpBeginNormal.Location = new Point(10, 37);
			dtpBeginNormal.Name = "dtpBeginNormal";
			dtpBeginNormal.Size = new Size(188, 23);
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
			// ldlDate
			// 
			ldlDate.AutoSize = true;
			ldlDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ldlDate.Location = new Point(12, 40);
			ldlDate.Name = "ldlDate";
			ldlDate.Size = new Size(28, 15);
			ldlDate.TabIndex = 149;
			ldlDate.Text = "Día:";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(42, 35);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(216, 23);
			dtpDay.TabIndex = 0;
			dtpDay.ValueChanged += dtpDay_ValueChanged;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(360, 711);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 8;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// lblWorkGroup
			// 
			lblWorkGroup.AutoSize = true;
			lblWorkGroup.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblWorkGroup.Location = new Point(6, 75);
			lblWorkGroup.Name = "lblWorkGroup";
			lblWorkGroup.Size = new Size(44, 15);
			lblWorkGroup.TabIndex = 158;
			lblWorkGroup.Text = "Banda:";
			// 
			// cboProductionLine
			// 
			cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
			cboProductionLine.FormattingEnabled = true;
			cboProductionLine.Location = new Point(55, 71);
			cboProductionLine.Name = "cboProductionLine";
			cboProductionLine.Size = new Size(153, 23);
			cboProductionLine.TabIndex = 1;
			// 
			// chbActiveProductionLine
			// 
			chbActiveProductionLine.Appearance = Appearance.Button;
			chbActiveProductionLine.AutoSize = true;
			chbActiveProductionLine.BackgroundImage = Properties.Resources.Imagen6;
			chbActiveProductionLine.BackgroundImageLayout = ImageLayout.Stretch;
			chbActiveProductionLine.Font = new Font("Segoe UI", 9F);
			chbActiveProductionLine.Location = new Point(214, 69);
			chbActiveProductionLine.Name = "chbActiveProductionLine";
			chbActiveProductionLine.Size = new Size(32, 25);
			chbActiveProductionLine.TabIndex = 2;
			chbActiveProductionLine.Text = "     ";
			chbActiveProductionLine.UseVisualStyleBackColor = true;
			// 
			// btnAcept
			// 
			btnAcept.Location = new Point(275, 711);
			btnAcept.Name = "btnAcept";
			btnAcept.Size = new Size(75, 23);
			btnAcept.TabIndex = 7;
			btnAcept.Text = "Aceptar";
			btnAcept.UseVisualStyleBackColor = true;
			btnAcept.Click += btnAcept_Click;
			// 
			// txbWorkers
			// 
			txbWorkers.Location = new Point(158, 103);
			txbWorkers.MaxLength = 4;
			txbWorkers.Name = "txbWorkers";
			txbWorkers.Size = new Size(100, 23);
			txbWorkers.TabIndex = 3;
			// 
			// lblWorkers
			// 
			lblWorkers.AutoSize = true;
			lblWorkers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblWorkers.Location = new Point(6, 107);
			lblWorkers.Name = "lblWorkers";
			lblWorkers.Size = new Size(151, 15);
			lblWorkers.TabIndex = 160;
			lblWorkers.Text = "Trabajadores por cuadrilla:";
			// 
			// lblDescanso
			// 
			lblDescanso.AutoSize = true;
			lblDescanso.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescanso.Location = new Point(187, 487);
			lblDescanso.Name = "lblDescanso";
			lblDescanso.Size = new Size(79, 21);
			lblDescanso.TabIndex = 162;
			lblDescanso.Text = "Descanso";
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
			pllDescanso.Location = new Point(14, 511);
			pllDescanso.Name = "pllDescanso";
			pllDescanso.Size = new Size(419, 77);
			pllDescanso.TabIndex = 161;
			// 
			// lblDescansoHora
			// 
			lblDescansoHora.AutoSize = true;
			lblDescansoHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoHora.Location = new Point(336, 16);
			lblDescansoHora.Name = "lblDescansoHora";
			lblDescansoHora.Size = new Size(37, 15);
			lblDescansoHora.TabIndex = 167;
			lblDescansoHora.Text = "Hora:";
			// 
			// lblDescansoFinal
			// 
			lblDescansoFinal.AutoSize = true;
			lblDescansoFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoFinal.Location = new Point(172, 16);
			lblDescansoFinal.Name = "lblDescansoFinal";
			lblDescansoFinal.Size = new Size(65, 15);
			lblDescansoFinal.TabIndex = 166;
			lblDescansoFinal.Text = "Hora Final:";
			// 
			// lblDescansoInicial
			// 
			lblDescansoInicial.AutoSize = true;
			lblDescansoInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoInicial.Location = new Point(26, 16);
			lblDescansoInicial.Name = "lblDescansoInicial";
			lblDescansoInicial.Size = new Size(72, 15);
			lblDescansoInicial.TabIndex = 165;
			lblDescansoInicial.Text = "Hora Inicial:";
			// 
			// nudHorasDescanso
			// 
			nudHorasDescanso.DecimalPlaces = 2;
			nudHorasDescanso.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudHorasDescanso.Location = new Point(336, 34);
			nudHorasDescanso.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudHorasDescanso.Name = "nudHorasDescanso";
			nudHorasDescanso.Size = new Size(44, 23);
			nudHorasDescanso.TabIndex = 164;
			// 
			// dtpDescansoFinal
			// 
			dtpDescansoFinal.CustomFormat = "HH:mm:ss";
			dtpDescansoFinal.Format = DateTimePickerFormat.Custom;
			dtpDescansoFinal.Location = new Point(166, 34);
			dtpDescansoFinal.Name = "dtpDescansoFinal";
			dtpDescansoFinal.ShowCheckBox = true;
			dtpDescansoFinal.ShowUpDown = true;
			dtpDescansoFinal.Size = new Size(91, 23);
			dtpDescansoFinal.TabIndex = 6;
			dtpDescansoFinal.ValueChanged += dtpDescansoFinal_ValueChanged;
			// 
			// dtpDescansoInicial
			// 
			dtpDescansoInicial.CustomFormat = "HH:mm:ss";
			dtpDescansoInicial.Format = DateTimePickerFormat.Custom;
			dtpDescansoInicial.Location = new Point(20, 34);
			dtpDescansoInicial.Name = "dtpDescansoInicial";
			dtpDescansoInicial.ShowCheckBox = true;
			dtpDescansoInicial.ShowUpDown = true;
			dtpDescansoInicial.Size = new Size(91, 23);
			dtpDescansoInicial.TabIndex = 5;
			dtpDescansoInicial.ValueChanged += dtpDescansoInicial_ValueChanged;
			// 
			// lblCena
			// 
			lblCena.AutoSize = true;
			lblCena.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCena.Location = new Point(193, 383);
			lblCena.Name = "lblCena";
			lblCena.Size = new Size(46, 21);
			lblCena.TabIndex = 166;
			lblCena.Text = "Cena";
			// 
			// lblComida
			// 
			lblComida.AutoSize = true;
			lblComida.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComida.Location = new Point(187, 279);
			lblComida.Name = "lblComida";
			lblComida.Size = new Size(66, 21);
			lblComida.TabIndex = 165;
			lblComida.Text = "Comida";
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
			pllCena.Location = new Point(17, 407);
			pllCena.Name = "pllCena";
			pllCena.Size = new Size(419, 77);
			pllCena.TabIndex = 164;
			// 
			// lblCenaHora
			// 
			lblCenaHora.AutoSize = true;
			lblCenaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaHora.Location = new Point(333, 20);
			lblCenaHora.Name = "lblCenaHora";
			lblCenaHora.Size = new Size(37, 15);
			lblCenaHora.TabIndex = 179;
			lblCenaHora.Text = "Hora:";
			// 
			// lblCenaFinal
			// 
			lblCenaFinal.AutoSize = true;
			lblCenaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaFinal.Location = new Point(177, 20);
			lblCenaFinal.Name = "lblCenaFinal";
			lblCenaFinal.Size = new Size(65, 15);
			lblCenaFinal.TabIndex = 178;
			lblCenaFinal.Text = "Hora Final:";
			// 
			// lblCenaInicial
			// 
			lblCenaInicial.AutoSize = true;
			lblCenaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaInicial.Location = new Point(30, 20);
			lblCenaInicial.Name = "lblCenaInicial";
			lblCenaInicial.Size = new Size(72, 15);
			lblCenaInicial.TabIndex = 177;
			lblCenaInicial.Text = "Hora Inicial:";
			// 
			// nudCenaHora
			// 
			nudCenaHora.DecimalPlaces = 2;
			nudCenaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudCenaHora.Location = new Point(333, 38);
			nudCenaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudCenaHora.Name = "nudCenaHora";
			nudCenaHora.Size = new Size(44, 23);
			nudCenaHora.TabIndex = 176;
			// 
			// dtpCenaFinal
			// 
			dtpCenaFinal.CustomFormat = "HH:mm:ss";
			dtpCenaFinal.Format = DateTimePickerFormat.Custom;
			dtpCenaFinal.Location = new Point(163, 38);
			dtpCenaFinal.Name = "dtpCenaFinal";
			dtpCenaFinal.ShowCheckBox = true;
			dtpCenaFinal.ShowUpDown = true;
			dtpCenaFinal.Size = new Size(93, 23);
			dtpCenaFinal.TabIndex = 175;
			dtpCenaFinal.ValueChanged += dtpCenaFinal_ValueChanged;
			// 
			// dtpCenaInicial
			// 
			dtpCenaInicial.CustomFormat = "HH:mm:ss";
			dtpCenaInicial.Format = DateTimePickerFormat.Custom;
			dtpCenaInicial.Location = new Point(17, 38);
			dtpCenaInicial.Name = "dtpCenaInicial";
			dtpCenaInicial.ShowCheckBox = true;
			dtpCenaInicial.ShowUpDown = true;
			dtpCenaInicial.Size = new Size(93, 23);
			dtpCenaInicial.TabIndex = 174;
			dtpCenaInicial.ValueChanged += dtpCenaInicial_ValueChanged;
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
			pllComida.Location = new Point(17, 303);
			pllComida.Name = "pllComida";
			pllComida.Size = new Size(419, 77);
			pllComida.TabIndex = 163;
			// 
			// lblComidaHora
			// 
			lblComidaHora.AutoSize = true;
			lblComidaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaHora.Location = new Point(333, 17);
			lblComidaHora.Name = "lblComidaHora";
			lblComidaHora.Size = new Size(37, 15);
			lblComidaHora.TabIndex = 173;
			lblComidaHora.Text = "Hora:";
			// 
			// lblComidaFinal
			// 
			lblComidaFinal.AutoSize = true;
			lblComidaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaFinal.Location = new Point(175, 17);
			lblComidaFinal.Name = "lblComidaFinal";
			lblComidaFinal.Size = new Size(65, 15);
			lblComidaFinal.TabIndex = 172;
			lblComidaFinal.Text = "Hora Final:";
			// 
			// lblComicaInicial
			// 
			lblComicaInicial.AutoSize = true;
			lblComicaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComicaInicial.Location = new Point(29, 17);
			lblComicaInicial.Name = "lblComicaInicial";
			lblComicaInicial.Size = new Size(72, 15);
			lblComicaInicial.TabIndex = 171;
			lblComicaInicial.Text = "Hora Inicial:";
			// 
			// nudComidaHora
			// 
			nudComidaHora.DecimalPlaces = 2;
			nudComidaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudComidaHora.Location = new Point(333, 35);
			nudComidaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudComidaHora.Name = "nudComidaHora";
			nudComidaHora.Size = new Size(44, 23);
			nudComidaHora.TabIndex = 170;
			// 
			// dtpComidaFinal
			// 
			dtpComidaFinal.CustomFormat = "HH:mm:ss";
			dtpComidaFinal.Format = DateTimePickerFormat.Custom;
			dtpComidaFinal.Location = new Point(163, 35);
			dtpComidaFinal.Name = "dtpComidaFinal";
			dtpComidaFinal.ShowCheckBox = true;
			dtpComidaFinal.ShowUpDown = true;
			dtpComidaFinal.Size = new Size(91, 23);
			dtpComidaFinal.TabIndex = 169;
			dtpComidaFinal.ValueChanged += dtpComidaFinal_ValueChanged;
			// 
			// dtpComidaInicial
			// 
			dtpComidaInicial.CustomFormat = "HH:mm:ss";
			dtpComidaInicial.Format = DateTimePickerFormat.Custom;
			dtpComidaInicial.Location = new Point(17, 35);
			dtpComidaInicial.Name = "dtpComidaInicial";
			dtpComidaInicial.ShowCheckBox = true;
			dtpComidaInicial.ShowUpDown = true;
			dtpComidaInicial.Size = new Size(91, 23);
			dtpComidaInicial.TabIndex = 168;
			dtpComidaInicial.ValueChanged += dtpComidaInicial_ValueChanged;
			// 
			// lblCuadrilla
			// 
			lblCuadrilla.AutoSize = true;
			lblCuadrilla.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCuadrilla.Location = new Point(263, 15);
			lblCuadrilla.Name = "lblCuadrilla";
			lblCuadrilla.Size = new Size(66, 17);
			lblCuadrilla.TabIndex = 168;
			lblCuadrilla.Text = "Cuadrillas";
			// 
			// clbCuadrilla
			// 
			clbCuadrilla.FormattingEnabled = true;
			clbCuadrilla.Location = new Point(265, 35);
			clbCuadrilla.Name = "clbCuadrilla";
			clbCuadrilla.Size = new Size(176, 94);
			clbCuadrilla.TabIndex = 167;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(187, 591);
			label2.Name = "label2";
			label2.Size = new Size(92, 21);
			label2.TabIndex = 170;
			label2.Text = "Descanso 2";
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ActiveCaption;
			panel1.BorderStyle = BorderStyle.FixedSingle;
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(nudHorasD2);
			panel1.Controls.Add(dtpFinalD2);
			panel1.Controls.Add(dtpDinicial2);
			panel1.Location = new Point(14, 615);
			panel1.Name = "panel1";
			panel1.Size = new Size(419, 77);
			panel1.TabIndex = 169;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(336, 16);
			label3.Name = "label3";
			label3.Size = new Size(37, 15);
			label3.TabIndex = 167;
			label3.Text = "Hora:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(172, 16);
			label4.Name = "label4";
			label4.Size = new Size(65, 15);
			label4.TabIndex = 166;
			label4.Text = "Hora Final:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(26, 16);
			label5.Name = "label5";
			label5.Size = new Size(72, 15);
			label5.TabIndex = 165;
			label5.Text = "Hora Inicial:";
			// 
			// nudHorasD2
			// 
			nudHorasD2.DecimalPlaces = 2;
			nudHorasD2.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudHorasD2.Location = new Point(336, 34);
			nudHorasD2.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudHorasD2.Name = "nudHorasD2";
			nudHorasD2.Size = new Size(44, 23);
			nudHorasD2.TabIndex = 164;
			// 
			// dtpFinalD2
			// 
			dtpFinalD2.CustomFormat = "HH:mm:ss";
			dtpFinalD2.Format = DateTimePickerFormat.Custom;
			dtpFinalD2.Location = new Point(166, 34);
			dtpFinalD2.Name = "dtpFinalD2";
			dtpFinalD2.ShowCheckBox = true;
			dtpFinalD2.ShowUpDown = true;
			dtpFinalD2.Size = new Size(91, 23);
			dtpFinalD2.TabIndex = 6;
			dtpFinalD2.ValueChanged += dtpFinalD2_ValueChanged;
			// 
			// dtpDinicial2
			// 
			dtpDinicial2.CustomFormat = "HH:mm:ss";
			dtpDinicial2.Format = DateTimePickerFormat.Custom;
			dtpDinicial2.Location = new Point(20, 34);
			dtpDinicial2.Name = "dtpDinicial2";
			dtpDinicial2.ShowCheckBox = true;
			dtpDinicial2.ShowUpDown = true;
			dtpDinicial2.Size = new Size(91, 23);
			dtpDinicial2.TabIndex = 5;
			dtpDinicial2.ValueChanged += dtpDinicial2_ValueChanged;
			// 
			// FrmWorkTimeAdd
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(453, 746);
			Controls.Add(label2);
			Controls.Add(panel1);
			Controls.Add(lblCuadrilla);
			Controls.Add(clbCuadrilla);
			Controls.Add(lblCena);
			Controls.Add(lblComida);
			Controls.Add(pllCena);
			Controls.Add(pllComida);
			Controls.Add(lblDescanso);
			Controls.Add(pllDescanso);
			Controls.Add(txbWorkers);
			Controls.Add(chbActiveProductionLine);
			Controls.Add(cboProductionLine);
			Controls.Add(lblWorkGroup);
			Controls.Add(btnAcept);
			Controls.Add(btnCancel);
			Controls.Add(dtpDay);
			Controls.Add(ldlDate);
			Controls.Add(gpbNormal);
			Controls.Add(lblTitle);
			Controls.Add(lblWorkers);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "FrmWorkTimeAdd";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Añadir horario de empaque";
			Load += FrmWorkTimeAdd_Load;
			Shown += FrmWorkTimeAdd_Shown;
			gpbNormal.ResumeLayout(false);
			gpbNormal.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).EndInit();
			pllDescanso.ResumeLayout(false);
			pllDescanso.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).EndInit();
			pllCena.ResumeLayout(false);
			pllCena.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).EndInit();
			pllComida.ResumeLayout(false);
			pllComida.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudHorasD2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		public Label lblTitle;
        private GroupBox gpbNormal;
        private Label ldlDate;
        private Label lblBeginNormal;
        private Label lblEndNormal;
        private Button btnCancel;
        private Label lblWorkGroup;
        public CheckBox chbActiveProductionLine;
        private Label lblEndExtra;
        private Button btnAcept;
        public ComboBox cboProductionLine;
        public DateTimePicker dtpDay;
        public DateTimePicker dtpBeginNormal;
        public DateTimePicker dtpEndNormal;
        public DateTimePicker dtpEndExtra;
        public TextBox txbWorkers;
        private Label lblWorkers;
		private Label label1;
		public NumericUpDown nudOvertime;
		private NumericUpDown numericUpDown1;
		private Label lblDescanso;
		private Panel pllDescanso;
		private Label lblDescansoHora;
		private Label lblDescansoFinal;
		private Label lblDescansoInicial;
		public NumericUpDown nudHorasDescanso;
		public DateTimePicker dtpDescansoFinal;
		public DateTimePicker dtpDescansoInicial;
		private Label lblCena;
		private Label lblComida;
		private Panel pllCena;
		private Label lblCenaHora;
		private Label lblCenaFinal;
		private Label lblCenaInicial;
		public NumericUpDown nudCenaHora;
		public DateTimePicker dtpCenaFinal;
		public DateTimePicker dtpCenaInicial;
		private Panel pllComida;
		private Label lblComidaHora;
		private Label lblComidaFinal;
		private Label lblComicaInicial;
		public NumericUpDown nudComidaHora;
		public DateTimePicker dtpComidaFinal;
		public DateTimePicker dtpComidaInicial;
		private Label lblCuadrilla;
		public CheckedListBox clbCuadrilla;
		private Label label2;
		private Panel panel1;
		private Label label3;
		private Label label4;
		private Label label5;
		public DateTimePicker dtpFinalD2;
		public DateTimePicker dtpDinicial2;
		public NumericUpDown nudHorasD2;
	}
}
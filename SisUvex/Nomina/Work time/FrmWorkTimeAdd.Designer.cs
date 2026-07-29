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
			lblDescansoHora = new Label();
			lblDescansoFinal = new Label();
			lblDescansoInicial = new Label();
			nudHorasDescanso = new NumericUpDown();
			dtpDescansoFinal = new DateTimePicker();
			dtpDescansoInicial = new DateTimePicker();
			lblCenaHora = new Label();
			lblCenaFinal = new Label();
			lblCenaInicial = new Label();
			nudCenaHora = new NumericUpDown();
			dtpCenaFinal = new DateTimePicker();
			dtpCenaInicial = new DateTimePicker();
			lblComidaHora = new Label();
			lblComidaFinal = new Label();
			lblComicaInicial = new Label();
			nudComidaHora = new NumericUpDown();
			dtpComidaFinal = new DateTimePicker();
			dtpComidaInicial = new DateTimePicker();
			clbCuadrilla = new CheckedListBox();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			nudHorasD2 = new NumericUpDown();
			dtpFinalD2 = new DateTimePicker();
			dtpDinicial2 = new DateTimePicker();
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			groupBox3 = new GroupBox();
			groupBox4 = new GroupBox();
			groupBox5 = new GroupBox();
			groupBox6 = new GroupBox();
			gpbNormal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudHorasD2).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox6.SuspendLayout();
			SuspendLayout();
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Arial Black", 12F);
			lblTitle.Location = new Point(227, 9);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(167, 28);
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
			gpbNormal.Location = new Point(11, 197);
			gpbNormal.Margin = new Padding(3, 4, 3, 4);
			gpbNormal.Name = "gpbNormal";
			gpbNormal.Padding = new Padding(3, 4, 3, 4);
			gpbNormal.Size = new Size(608, 156);
			gpbNormal.TabIndex = 148;
			gpbNormal.TabStop = false;
			// 
			// nudOvertime
			// 
			nudOvertime.DecimalPlaces = 2;
			nudOvertime.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudOvertime.Location = new Point(342, 117);
			nudOvertime.Margin = new Padding(3, 4, 3, 4);
			nudOvertime.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudOvertime.Name = "nudOvertime";
			nudOvertime.Size = new Size(63, 27);
			nudOvertime.TabIndex = 163;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(342, 93);
			label1.Name = "label1";
			label1.Size = new Size(101, 20);
			label1.TabIndex = 162;
			label1.Text = "Horas Extras:";
			// 
			// dtpEndExtra
			// 
			dtpEndExtra.Format = DateTimePickerFormat.Custom;
			dtpEndExtra.Location = new Point(22, 117);
			dtpEndExtra.Margin = new Padding(3, 4, 3, 4);
			dtpEndExtra.Name = "dtpEndExtra";
			dtpEndExtra.Size = new Size(214, 27);
			dtpEndExtra.TabIndex = 6;
			// 
			// lblEndExtra
			// 
			lblEndExtra.AutoSize = true;
			lblEndExtra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndExtra.Location = new Point(22, 93);
			lblEndExtra.Name = "lblEndExtra";
			lblEndExtra.Size = new Size(140, 20);
			lblEndExtra.TabIndex = 161;
			lblEndExtra.Text = "Final tiempo extra:";
			// 
			// dtpEndNormal
			// 
			dtpEndNormal.Format = DateTimePickerFormat.Custom;
			dtpEndNormal.Location = new Point(342, 49);
			dtpEndNormal.Margin = new Padding(3, 4, 3, 4);
			dtpEndNormal.Name = "dtpEndNormal";
			dtpEndNormal.Size = new Size(214, 27);
			dtpEndNormal.TabIndex = 5;
			dtpEndNormal.ValueChanged += dtpEndNormal_ValueChanged;
			// 
			// lblEndNormal
			// 
			lblEndNormal.AutoSize = true;
			lblEndNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEndNormal.Location = new Point(342, 25);
			lblEndNormal.Name = "lblEndNormal";
			lblEndNormal.Size = new Size(155, 20);
			lblEndNormal.TabIndex = 153;
			lblEndNormal.Text = "Final horario normal:";
			// 
			// dtpBeginNormal
			// 
			dtpBeginNormal.Format = DateTimePickerFormat.Custom;
			dtpBeginNormal.Location = new Point(22, 49);
			dtpBeginNormal.Margin = new Padding(3, 4, 3, 4);
			dtpBeginNormal.Name = "dtpBeginNormal";
			dtpBeginNormal.Size = new Size(214, 27);
			dtpBeginNormal.TabIndex = 4;
			dtpBeginNormal.ValueChanged += dtpBeginNormal_ValueChanged;
			// 
			// lblBeginNormal
			// 
			lblBeginNormal.AutoSize = true;
			lblBeginNormal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblBeginNormal.Location = new Point(22, 25);
			lblBeginNormal.Name = "lblBeginNormal";
			lblBeginNormal.Size = new Size(160, 20);
			lblBeginNormal.TabIndex = 151;
			lblBeginNormal.Text = "Inicio horario normal:";
			// 
			// ldlDate
			// 
			ldlDate.AutoSize = true;
			ldlDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ldlDate.Location = new Point(6, 32);
			ldlDate.Name = "ldlDate";
			ldlDate.Size = new Size(36, 20);
			ldlDate.TabIndex = 149;
			ldlDate.Text = "Día:";
			// 
			// dtpDay
			// 
			dtpDay.Location = new Point(53, 27);
			dtpDay.Margin = new Padding(3, 4, 3, 4);
			dtpDay.Name = "dtpDay";
			dtpDay.Size = new Size(277, 27);
			dtpDay.TabIndex = 0;
			dtpDay.ValueChanged += dtpDay_ValueChanged;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(519, 617);
			btnCancel.Margin = new Padding(3, 4, 3, 4);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(86, 31);
			btnCancel.TabIndex = 8;
			btnCancel.Text = "Cancelar";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// lblWorkGroup
			// 
			lblWorkGroup.AutoSize = true;
			lblWorkGroup.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblWorkGroup.Location = new Point(6, 72);
			lblWorkGroup.Name = "lblWorkGroup";
			lblWorkGroup.Size = new Size(57, 20);
			lblWorkGroup.TabIndex = 158;
			lblWorkGroup.Text = "Banda:";
			// 
			// cboProductionLine
			// 
			cboProductionLine.DropDownStyle = ComboBoxStyle.DropDownList;
			cboProductionLine.FormattingEnabled = true;
			cboProductionLine.Location = new Point(69, 64);
			cboProductionLine.Margin = new Padding(3, 4, 3, 4);
			cboProductionLine.Name = "cboProductionLine";
			cboProductionLine.Size = new Size(174, 28);
			cboProductionLine.TabIndex = 1;
			// 
			// chbActiveProductionLine
			// 
			chbActiveProductionLine.Appearance = Appearance.Button;
			chbActiveProductionLine.AutoSize = true;
			chbActiveProductionLine.BackgroundImage = Properties.Resources.Imagen6;
			chbActiveProductionLine.BackgroundImageLayout = ImageLayout.Stretch;
			chbActiveProductionLine.Font = new Font("Segoe UI", 9F);
			chbActiveProductionLine.Location = new Point(249, 62);
			chbActiveProductionLine.Margin = new Padding(3, 4, 3, 4);
			chbActiveProductionLine.Name = "chbActiveProductionLine";
			chbActiveProductionLine.Size = new Size(39, 30);
			chbActiveProductionLine.TabIndex = 2;
			chbActiveProductionLine.Text = "     ";
			chbActiveProductionLine.UseVisualStyleBackColor = true;
			// 
			// btnAcept
			// 
			btnAcept.Location = new Point(400, 617);
			btnAcept.Margin = new Padding(3, 4, 3, 4);
			btnAcept.Name = "btnAcept";
			btnAcept.Size = new Size(86, 31);
			btnAcept.TabIndex = 7;
			btnAcept.Text = "Aceptar";
			btnAcept.UseVisualStyleBackColor = true;
			btnAcept.Click += btnAcept_Click;
			// 
			// txbWorkers
			// 
			txbWorkers.Location = new Point(201, 101);
			txbWorkers.Margin = new Padding(3, 4, 3, 4);
			txbWorkers.MaxLength = 4;
			txbWorkers.Name = "txbWorkers";
			txbWorkers.Size = new Size(93, 27);
			txbWorkers.TabIndex = 3;
			// 
			// lblWorkers
			// 
			lblWorkers.AutoSize = true;
			lblWorkers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblWorkers.Location = new Point(6, 107);
			lblWorkers.Name = "lblWorkers";
			lblWorkers.Size = new Size(194, 20);
			lblWorkers.TabIndex = 160;
			lblWorkers.Text = "Trabajadores por cuadrilla:";
			// 
			// lblDescansoHora
			// 
			lblDescansoHora.AutoSize = true;
			lblDescansoHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoHora.Location = new Point(6, 168);
			lblDescansoHora.Name = "lblDescansoHora";
			lblDescansoHora.Size = new Size(47, 20);
			lblDescansoHora.TabIndex = 167;
			lblDescansoHora.Text = "Hora:";
			// 
			// lblDescansoFinal
			// 
			lblDescansoFinal.AutoSize = true;
			lblDescansoFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoFinal.Location = new Point(6, 100);
			lblDescansoFinal.Name = "lblDescansoFinal";
			lblDescansoFinal.Size = new Size(84, 20);
			lblDescansoFinal.TabIndex = 166;
			lblDescansoFinal.Text = "Hora Final:";
			// 
			// lblDescansoInicial
			// 
			lblDescansoInicial.AutoSize = true;
			lblDescansoInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblDescansoInicial.Location = new Point(6, 29);
			lblDescansoInicial.Name = "lblDescansoInicial";
			lblDescansoInicial.Size = new Size(92, 20);
			lblDescansoInicial.TabIndex = 165;
			lblDescansoInicial.Text = "Hora Inicial:";
			// 
			// nudHorasDescanso
			// 
			nudHorasDescanso.DecimalPlaces = 2;
			nudHorasDescanso.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudHorasDescanso.Location = new Point(6, 192);
			nudHorasDescanso.Margin = new Padding(3, 4, 3, 4);
			nudHorasDescanso.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudHorasDescanso.Name = "nudHorasDescanso";
			nudHorasDescanso.Size = new Size(56, 27);
			nudHorasDescanso.TabIndex = 164;
			// 
			// dtpDescansoFinal
			// 
			dtpDescansoFinal.CustomFormat = "HH:mm:ss";
			dtpDescansoFinal.Format = DateTimePickerFormat.Custom;
			dtpDescansoFinal.Location = new Point(6, 124);
			dtpDescansoFinal.Margin = new Padding(3, 4, 3, 4);
			dtpDescansoFinal.Name = "dtpDescansoFinal";
			dtpDescansoFinal.ShowCheckBox = true;
			dtpDescansoFinal.ShowUpDown = true;
			dtpDescansoFinal.Size = new Size(114, 27);
			dtpDescansoFinal.TabIndex = 6;
			dtpDescansoFinal.ValueChanged += dtpDescansoFinal_ValueChanged;
			// 
			// dtpDescansoInicial
			// 
			dtpDescansoInicial.CustomFormat = "HH:mm:ss";
			dtpDescansoInicial.Format = DateTimePickerFormat.Custom;
			dtpDescansoInicial.Location = new Point(6, 53);
			dtpDescansoInicial.Margin = new Padding(3, 4, 3, 4);
			dtpDescansoInicial.Name = "dtpDescansoInicial";
			dtpDescansoInicial.ShowCheckBox = true;
			dtpDescansoInicial.ShowUpDown = true;
			dtpDescansoInicial.Size = new Size(111, 27);
			dtpDescansoInicial.TabIndex = 5;
			dtpDescansoInicial.ValueChanged += dtpDescansoInicial_ValueChanged;
			// 
			// lblCenaHora
			// 
			lblCenaHora.AutoSize = true;
			lblCenaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaHora.Location = new Point(6, 168);
			lblCenaHora.Name = "lblCenaHora";
			lblCenaHora.Size = new Size(47, 20);
			lblCenaHora.TabIndex = 179;
			lblCenaHora.Text = "Hora:";
			// 
			// lblCenaFinal
			// 
			lblCenaFinal.AutoSize = true;
			lblCenaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaFinal.Location = new Point(6, 100);
			lblCenaFinal.Name = "lblCenaFinal";
			lblCenaFinal.Size = new Size(84, 20);
			lblCenaFinal.TabIndex = 178;
			lblCenaFinal.Text = "Hora Final:";
			// 
			// lblCenaInicial
			// 
			lblCenaInicial.AutoSize = true;
			lblCenaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCenaInicial.Location = new Point(6, 25);
			lblCenaInicial.Name = "lblCenaInicial";
			lblCenaInicial.Size = new Size(92, 20);
			lblCenaInicial.TabIndex = 177;
			lblCenaInicial.Text = "Hora Inicial:";
			// 
			// nudCenaHora
			// 
			nudCenaHora.DecimalPlaces = 2;
			nudCenaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudCenaHora.Location = new Point(6, 192);
			nudCenaHora.Margin = new Padding(3, 4, 3, 4);
			nudCenaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudCenaHora.Name = "nudCenaHora";
			nudCenaHora.Size = new Size(56, 27);
			nudCenaHora.TabIndex = 176;
			// 
			// dtpCenaFinal
			// 
			dtpCenaFinal.CustomFormat = "HH:mm:ss";
			dtpCenaFinal.Format = DateTimePickerFormat.Custom;
			dtpCenaFinal.Location = new Point(6, 124);
			dtpCenaFinal.Margin = new Padding(3, 4, 3, 4);
			dtpCenaFinal.Name = "dtpCenaFinal";
			dtpCenaFinal.ShowCheckBox = true;
			dtpCenaFinal.ShowUpDown = true;
			dtpCenaFinal.Size = new Size(121, 27);
			dtpCenaFinal.TabIndex = 175;
			dtpCenaFinal.ValueChanged += dtpCenaFinal_ValueChanged;
			// 
			// dtpCenaInicial
			// 
			dtpCenaInicial.CustomFormat = "HH:mm:ss";
			dtpCenaInicial.Format = DateTimePickerFormat.Custom;
			dtpCenaInicial.Location = new Point(6, 49);
			dtpCenaInicial.Margin = new Padding(3, 4, 3, 4);
			dtpCenaInicial.Name = "dtpCenaInicial";
			dtpCenaInicial.ShowCheckBox = true;
			dtpCenaInicial.ShowUpDown = true;
			dtpCenaInicial.Size = new Size(113, 27);
			dtpCenaInicial.TabIndex = 174;
			dtpCenaInicial.ValueChanged += dtpCenaInicial_ValueChanged;
			// 
			// lblComidaHora
			// 
			lblComidaHora.AutoSize = true;
			lblComidaHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaHora.Location = new Point(13, 168);
			lblComidaHora.Name = "lblComidaHora";
			lblComidaHora.Size = new Size(47, 20);
			lblComidaHora.TabIndex = 173;
			lblComidaHora.Text = "Hora:";
			// 
			// lblComidaFinal
			// 
			lblComidaFinal.AutoSize = true;
			lblComidaFinal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComidaFinal.Location = new Point(13, 100);
			lblComidaFinal.Name = "lblComidaFinal";
			lblComidaFinal.Size = new Size(84, 20);
			lblComidaFinal.TabIndex = 172;
			lblComidaFinal.Text = "Hora Final:";
			// 
			// lblComicaInicial
			// 
			lblComicaInicial.AutoSize = true;
			lblComicaInicial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblComicaInicial.Location = new Point(13, 26);
			lblComicaInicial.Name = "lblComicaInicial";
			lblComicaInicial.Size = new Size(92, 20);
			lblComicaInicial.TabIndex = 171;
			lblComicaInicial.Text = "Hora Inicial:";
			// 
			// nudComidaHora
			// 
			nudComidaHora.DecimalPlaces = 2;
			nudComidaHora.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudComidaHora.Location = new Point(13, 192);
			nudComidaHora.Margin = new Padding(3, 4, 3, 4);
			nudComidaHora.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudComidaHora.Name = "nudComidaHora";
			nudComidaHora.Size = new Size(53, 27);
			nudComidaHora.TabIndex = 170;
			// 
			// dtpComidaFinal
			// 
			dtpComidaFinal.CustomFormat = "HH:mm:ss";
			dtpComidaFinal.Format = DateTimePickerFormat.Custom;
			dtpComidaFinal.Location = new Point(13, 124);
			dtpComidaFinal.Margin = new Padding(3, 4, 3, 4);
			dtpComidaFinal.Name = "dtpComidaFinal";
			dtpComidaFinal.ShowCheckBox = true;
			dtpComidaFinal.ShowUpDown = true;
			dtpComidaFinal.Size = new Size(114, 27);
			dtpComidaFinal.TabIndex = 169;
			dtpComidaFinal.ValueChanged += dtpComidaFinal_ValueChanged;
			// 
			// dtpComidaInicial
			// 
			dtpComidaInicial.CustomFormat = "HH:mm:ss";
			dtpComidaInicial.Format = DateTimePickerFormat.Custom;
			dtpComidaInicial.Location = new Point(13, 50);
			dtpComidaInicial.Margin = new Padding(3, 4, 3, 4);
			dtpComidaInicial.Name = "dtpComidaInicial";
			dtpComidaInicial.ShowCheckBox = true;
			dtpComidaInicial.ShowUpDown = true;
			dtpComidaInicial.Size = new Size(110, 27);
			dtpComidaInicial.TabIndex = 168;
			dtpComidaInicial.ValueChanged += dtpComidaInicial_ValueChanged;
			// 
			// clbCuadrilla
			// 
			clbCuadrilla.FormattingEnabled = true;
			clbCuadrilla.Location = new Point(11, 32);
			clbCuadrilla.Margin = new Padding(3, 4, 3, 4);
			clbCuadrilla.Name = "clbCuadrilla";
			clbCuadrilla.Size = new Size(256, 92);
			clbCuadrilla.TabIndex = 167;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.Location = new Point(6, 168);
			label3.Name = "label3";
			label3.Size = new Size(47, 20);
			label3.TabIndex = 167;
			label3.Text = "Hora:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(6, 100);
			label4.Name = "label4";
			label4.Size = new Size(84, 20);
			label4.TabIndex = 166;
			label4.Text = "Hora Final:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(6, 30);
			label5.Name = "label5";
			label5.Size = new Size(92, 20);
			label5.TabIndex = 165;
			label5.Text = "Hora Inicial:";
			// 
			// nudHorasD2
			// 
			nudHorasD2.DecimalPlaces = 2;
			nudHorasD2.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			nudHorasD2.Location = new Point(6, 192);
			nudHorasD2.Margin = new Padding(3, 4, 3, 4);
			nudHorasD2.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
			nudHorasD2.Name = "nudHorasD2";
			nudHorasD2.Size = new Size(56, 27);
			nudHorasD2.TabIndex = 164;
			// 
			// dtpFinalD2
			// 
			dtpFinalD2.CustomFormat = "HH:mm:ss";
			dtpFinalD2.Format = DateTimePickerFormat.Custom;
			dtpFinalD2.Location = new Point(6, 124);
			dtpFinalD2.Margin = new Padding(3, 4, 3, 4);
			dtpFinalD2.Name = "dtpFinalD2";
			dtpFinalD2.ShowCheckBox = true;
			dtpFinalD2.ShowUpDown = true;
			dtpFinalD2.Size = new Size(114, 27);
			dtpFinalD2.TabIndex = 6;
			dtpFinalD2.ValueChanged += dtpFinalD2_ValueChanged;
			// 
			// dtpDinicial2
			// 
			dtpDinicial2.CustomFormat = "HH:mm:ss";
			dtpDinicial2.Format = DateTimePickerFormat.Custom;
			dtpDinicial2.Location = new Point(6, 54);
			dtpDinicial2.Margin = new Padding(3, 4, 3, 4);
			dtpDinicial2.Name = "dtpDinicial2";
			dtpDinicial2.ShowCheckBox = true;
			dtpDinicial2.ShowUpDown = true;
			dtpDinicial2.Size = new Size(115, 27);
			dtpDinicial2.TabIndex = 5;
			dtpDinicial2.ValueChanged += dtpDinicial2_ValueChanged;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(lblComidaHora);
			groupBox1.Controls.Add(nudComidaHora);
			groupBox1.Controls.Add(dtpComidaInicial);
			groupBox1.Controls.Add(lblComidaFinal);
			groupBox1.Controls.Add(lblComicaInicial);
			groupBox1.Controls.Add(dtpComidaFinal);
			groupBox1.Location = new Point(13, 362);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(147, 231);
			groupBox1.TabIndex = 171;
			groupBox1.TabStop = false;
			groupBox1.Text = "Comida";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(lblCenaHora);
			groupBox2.Controls.Add(lblCenaFinal);
			groupBox2.Controls.Add(dtpCenaInicial);
			groupBox2.Controls.Add(lblCenaInicial);
			groupBox2.Controls.Add(dtpCenaFinal);
			groupBox2.Controls.Add(nudCenaHora);
			groupBox2.Location = new Point(166, 362);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(148, 231);
			groupBox2.TabIndex = 172;
			groupBox2.TabStop = false;
			groupBox2.Text = "Cena";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(lblDescansoHora);
			groupBox3.Controls.Add(dtpDescansoFinal);
			groupBox3.Controls.Add(lblDescansoFinal);
			groupBox3.Controls.Add(dtpDescansoInicial);
			groupBox3.Controls.Add(lblDescansoInicial);
			groupBox3.Controls.Add(nudHorasDescanso);
			groupBox3.Location = new Point(320, 362);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(152, 231);
			groupBox3.TabIndex = 173;
			groupBox3.TabStop = false;
			groupBox3.Text = "Descanso";
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(label3);
			groupBox4.Controls.Add(dtpFinalD2);
			groupBox4.Controls.Add(label4);
			groupBox4.Controls.Add(dtpDinicial2);
			groupBox4.Controls.Add(label5);
			groupBox4.Controls.Add(nudHorasD2);
			groupBox4.Location = new Point(478, 362);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(141, 231);
			groupBox4.TabIndex = 174;
			groupBox4.TabStop = false;
			groupBox4.Text = "Descanso 2";
			// 
			// groupBox5
			// 
			groupBox5.Controls.Add(clbCuadrilla);
			groupBox5.Location = new Point(346, 54);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new Size(273, 147);
			groupBox5.TabIndex = 175;
			groupBox5.TabStop = false;
			groupBox5.Text = "Cuadrilla";
			// 
			// groupBox6
			// 
			groupBox6.Controls.Add(dtpDay);
			groupBox6.Controls.Add(lblWorkers);
			groupBox6.Controls.Add(ldlDate);
			groupBox6.Controls.Add(lblWorkGroup);
			groupBox6.Controls.Add(cboProductionLine);
			groupBox6.Controls.Add(chbActiveProductionLine);
			groupBox6.Controls.Add(txbWorkers);
			groupBox6.Location = new Point(7, 54);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new Size(333, 147);
			groupBox6.TabIndex = 176;
			groupBox6.TabStop = false;
			groupBox6.Text = "Informacion General ";
			// 
			// FrmWorkTimeAdd
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(637, 662);
			Controls.Add(groupBox6);
			Controls.Add(groupBox5);
			Controls.Add(groupBox4);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(btnAcept);
			Controls.Add(btnCancel);
			Controls.Add(gpbNormal);
			Controls.Add(lblTitle);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			Name = "FrmWorkTimeAdd";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Añadir horario de empaque";
			Load += FrmWorkTimeAdd_Load;
			Shown += FrmWorkTimeAdd_Shown;
			gpbNormal.ResumeLayout(false);
			gpbNormal.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudOvertime).EndInit();
			((System.ComponentModel.ISupportInitialize)nudHorasDescanso).EndInit();
			((System.ComponentModel.ISupportInitialize)nudCenaHora).EndInit();
			((System.ComponentModel.ISupportInitialize)nudComidaHora).EndInit();
			((System.ComponentModel.ISupportInitialize)nudHorasD2).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			groupBox5.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox6.PerformLayout();
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
		private Label lblDescansoHora;
		private Label lblDescansoFinal;
		private Label lblDescansoInicial;
		public NumericUpDown nudHorasDescanso;
		public DateTimePicker dtpDescansoFinal;
		public DateTimePicker dtpDescansoInicial;
		private Label lblCenaHora;
		private Label lblCenaFinal;
		private Label lblCenaInicial;
		public NumericUpDown nudCenaHora;
		public DateTimePicker dtpCenaFinal;
		public DateTimePicker dtpCenaInicial;
		private Label lblComidaHora;
		private Label lblComidaFinal;
		private Label lblComicaInicial;
		public NumericUpDown nudComidaHora;
		public DateTimePicker dtpComidaFinal;
		public DateTimePicker dtpComidaInicial;
		public CheckedListBox clbCuadrilla;
		private Label label3;
		private Label label4;
		private Label label5;
		public DateTimePicker dtpFinalD2;
		public DateTimePicker dtpDinicial2;
		public NumericUpDown nudHorasD2;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private GroupBox groupBox4;
		private GroupBox groupBox5;
		private GroupBox groupBox6;
	}
}
namespace SisUvex.Nomina.Nom_semAutomatizada
{
	partial class FrmSemiAutomatedPayroll
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSemiAutomatedPayroll));
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			lblLote = new Label();
			lblReferencia = new Label();
			dtpFecha = new DateTimePicker();
			txbReferencia = new TextBox();
			cboLote = new ComboBox();
			lblencabezado = new Label();
			btnCSV = new Button();
			btnExcel = new Button();
			btncargar = new Button();
			dgvEmployee = new DataGridView();
			btnCalcularLibra = new Button();
			cboLineas = new ComboBox();
			lblLineas = new Label();
			rbtEsparrago = new RadioButton();
			pictureBox1 = new PictureBox();
			rbtUva = new RadioButton();
			pictureBox2 = new PictureBox();
			gbTipo = new GroupBox();
			gbCsv = new GroupBox();
			gbGenerar = new GroupBox();
			label8 = new Label();
			gbLibras = new GroupBox();
			label7 = new Label();
			btnGuardar = new Button();
			lblTipoProceso = new Label();
			btnCerrar = new Button();
			lblAvisoCierre = new Label();
			plTitulo = new Panel();
			pbImagen = new PictureBox();
			lblSubtitulo = new Label();
			plCerrar = new Panel();
			pnCerrar = new Panel();
			lblEstado = new Label();
			pbCirculo = new PictureBox();
			lblNomina = new Label();
			gbFecha = new GroupBox();
			pictureBox5 = new PictureBox();
			label4 = new Label();
			gbSueldos = new GroupBox();
			label5 = new Label();
			tlpDatos = new TableLayoutPanel();
			plCajas = new Panel();
			lblCajas = new Label();
			label3 = new Label();
			pictureBox4 = new PictureBox();
			plEmpleados = new Panel();
			lblEmpleados = new Label();
			label2 = new Label();
			pictureBox3 = new PictureBox();
			pnlInicio = new Panel();
			pictureBox6 = new PictureBox();
			label6 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			gbTipo.SuspendLayout();
			gbCsv.SuspendLayout();
			gbGenerar.SuspendLayout();
			gbLibras.SuspendLayout();
			plTitulo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
			plCerrar.SuspendLayout();
			pnCerrar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbCirculo).BeginInit();
			gbFecha.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			gbSueldos.SuspendLayout();
			tlpDatos.SuspendLayout();
			plCajas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			plEmpleados.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			pnlInicio.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
			SuspendLayout();
			// 
			// lblLote
			// 
			lblLote.AutoSize = true;
			lblLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLote.Location = new Point(57, 31);
			lblLote.Name = "lblLote";
			lblLote.Size = new Size(47, 21);
			lblLote.TabIndex = 0;
			lblLote.Text = "Lote :";
			// 
			// lblReferencia
			// 
			lblReferencia.AutoSize = true;
			lblReferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblReferencia.Location = new Point(57, 86);
			lblReferencia.Name = "lblReferencia";
			lblReferencia.Size = new Size(90, 21);
			lblReferencia.TabIndex = 1;
			lblReferencia.Text = "Referencia :";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(65, 64);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(246, 23);
			dtpFecha.TabIndex = 2;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// txbReferencia
			// 
			txbReferencia.Location = new Point(165, 82);
			txbReferencia.Multiline = true;
			txbReferencia.Name = "txbReferencia";
			txbReferencia.Size = new Size(197, 25);
			txbReferencia.TabIndex = 3;
			// 
			// cboLote
			// 
			cboLote.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLote.FormattingEnabled = true;
			cboLote.Location = new Point(165, 34);
			cboLote.Name = "cboLote";
			cboLote.Size = new Size(197, 23);
			cboLote.TabIndex = 4;
			// 
			// lblencabezado
			// 
			lblencabezado.AutoSize = true;
			lblencabezado.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblencabezado.ForeColor = Color.FromArgb(35, 55, 50);
			lblencabezado.Location = new Point(116, 4);
			lblencabezado.Name = "lblencabezado";
			lblencabezado.Size = new Size(386, 37);
			lblencabezado.TabIndex = 5;
			lblencabezado.Text = "Reporte de Empaque Central";
			// 
			// btnCSV
			// 
			btnCSV.BackgroundImageLayout = ImageLayout.Stretch;
			btnCSV.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCSV.Image = (Image)resources.GetObject("btnCSV.Image");
			btnCSV.ImageAlign = ContentAlignment.MiddleLeft;
			btnCSV.Location = new Point(520, 21);
			btnCSV.Name = "btnCSV";
			btnCSV.Padding = new Padding(10, 0, 10, 0);
			btnCSV.Size = new Size(158, 41);
			btnCSV.TabIndex = 7;
			btnCSV.Text = "Exportar CSV";
			btnCSV.TextAlign = ContentAlignment.MiddleRight;
			btnCSV.UseVisualStyleBackColor = true;
			btnCSV.Click += btnCVS_Click;
			// 
			// btnExcel
			// 
			btnExcel.BackgroundImageLayout = ImageLayout.Stretch;
			btnExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnExcel.Image = Properties.Resources.excelIcon16;
			btnExcel.ImageAlign = ContentAlignment.MiddleLeft;
			btnExcel.Location = new Point(520, 82);
			btnExcel.Name = "btnExcel";
			btnExcel.Padding = new Padding(10, 0, 10, 0);
			btnExcel.Size = new Size(158, 42);
			btnExcel.TabIndex = 8;
			btnExcel.Text = "Exportar Excel";
			btnExcel.TextAlign = ContentAlignment.MiddleRight;
			btnExcel.UseVisualStyleBackColor = true;
			btnExcel.Click += btnExcel_Click;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btncargar.Image = (Image)resources.GetObject("btncargar.Image");
			btncargar.ImageAlign = ContentAlignment.MiddleLeft;
			btncargar.Location = new Point(21, 57);
			btncargar.Name = "btncargar";
			btncargar.Padding = new Padding(15, 0, 15, 0);
			btncargar.Size = new Size(159, 38);
			btncargar.TabIndex = 9;
			btncargar.Text = "Cargar Datos";
			btncargar.TextAlign = ContentAlignment.MiddleRight;
			btncargar.UseVisualStyleBackColor = true;
			btncargar.Click += btncargar_Click;
			// 
			// dgvEmployee
			// 
			dgvEmployee.AllowUserToAddRows = false;
			dgvEmployee.AllowUserToDeleteRows = false;
			dgvEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvEmployee.BackgroundColor = SystemColors.ControlLightLight;
			dgvEmployee.BorderStyle = BorderStyle.Fixed3D;
			dgvEmployee.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvEmployee.ColumnHeadersHeight = 58;
			dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.Window;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
			dgvEmployee.DefaultCellStyle = dataGridViewCellStyle5;
			dgvEmployee.EnableHeadersVisualStyles = false;
			dgvEmployee.ImeMode = ImeMode.NoControl;
			dgvEmployee.Location = new Point(27, 478);
			dgvEmployee.Name = "dgvEmployee";
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Control;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			dgvEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			dgvEmployee.RowHeadersVisible = false;
			dgvEmployee.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvEmployee.SelectionMode = DataGridViewSelectionMode.CellSelect;
			dgvEmployee.Size = new Size(1149, 343);
			dgvEmployee.TabIndex = 17;
			dgvEmployee.CellValueChanged += dgvEmployee_CellValueChanged;
			// 
			// btnCalcularLibra
			// 
			btnCalcularLibra.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCalcularLibra.Image = (Image)resources.GetObject("btnCalcularLibra.Image");
			btnCalcularLibra.ImageAlign = ContentAlignment.MiddleLeft;
			btnCalcularLibra.Location = new Point(34, 57);
			btnCalcularLibra.Name = "btnCalcularLibra";
			btnCalcularLibra.Padding = new Padding(15, 0, 15, 0);
			btnCalcularLibra.Size = new Size(159, 38);
			btnCalcularLibra.TabIndex = 18;
			btnCalcularLibra.Text = "Cargar Libras";
			btnCalcularLibra.TextAlign = ContentAlignment.MiddleRight;
			btnCalcularLibra.UseVisualStyleBackColor = true;
			btnCalcularLibra.Click += btnCalcularLibra_Click;
			// 
			// cboLineas
			// 
			cboLineas.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLineas.FormattingEnabled = true;
			cboLineas.Location = new Point(123, 445);
			cboLineas.Name = "cboLineas";
			cboLineas.Size = new Size(135, 23);
			cboLineas.TabIndex = 19;
			// 
			// lblLineas
			// 
			lblLineas.AutoSize = true;
			lblLineas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLineas.Location = new Point(29, 447);
			lblLineas.Name = "lblLineas";
			lblLineas.Size = new Size(63, 21);
			lblLineas.TabIndex = 20;
			lblLineas.Text = "Bandas:";
			// 
			// rbtEsparrago
			// 
			rbtEsparrago.AutoSize = true;
			rbtEsparrago.Location = new Point(56, 34);
			rbtEsparrago.Name = "rbtEsparrago";
			rbtEsparrago.Size = new Size(77, 19);
			rbtEsparrago.TabIndex = 23;
			rbtEsparrago.TabStop = true;
			rbtEsparrago.Text = "Esparrago";
			rbtEsparrago.UseVisualStyleBackColor = true;
			rbtEsparrago.CheckedChanged += rbtEsparrago_CheckedChanged;
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(17, 72);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(33, 32);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			// 
			// rbtUva
			// 
			rbtUva.AutoSize = true;
			rbtUva.Location = new Point(56, 76);
			rbtUva.Name = "rbtUva";
			rbtUva.Size = new Size(45, 19);
			rbtUva.TabIndex = 24;
			rbtUva.TabStop = true;
			rbtUva.Text = "Uva";
			rbtUva.UseVisualStyleBackColor = true;
			rbtUva.CheckedChanged += rbtUva_CheckedChanged;
			// 
			// pictureBox2
			// 
			pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
			pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox2.Location = new Point(17, 26);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(33, 27);
			pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox2.TabIndex = 25;
			pictureBox2.TabStop = false;
			// 
			// gbTipo
			// 
			gbTipo.BackColor = Color.FromArgb(240, 244, 242);
			gbTipo.Controls.Add(rbtUva);
			gbTipo.Controls.Add(rbtEsparrago);
			gbTipo.Controls.Add(pictureBox2);
			gbTipo.Controls.Add(pictureBox1);
			gbTipo.Location = new Point(27, 127);
			gbTipo.Margin = new Padding(3, 2, 3, 2);
			gbTipo.Name = "gbTipo";
			gbTipo.Padding = new Padding(3, 2, 3, 2);
			gbTipo.Size = new Size(251, 124);
			gbTipo.TabIndex = 28;
			gbTipo.TabStop = false;
			gbTipo.Text = "Tipo de Nomina";
			// 
			// gbCsv
			// 
			gbCsv.BackColor = Color.FromArgb(240, 244, 242);
			gbCsv.Controls.Add(lblLote);
			gbCsv.Controls.Add(cboLote);
			gbCsv.Controls.Add(lblReferencia);
			gbCsv.Controls.Add(btnCSV);
			gbCsv.Controls.Add(txbReferencia);
			gbCsv.Controls.Add(btnExcel);
			gbCsv.Location = new Point(27, 265);
			gbCsv.Margin = new Padding(3, 2, 3, 2);
			gbCsv.Name = "gbCsv";
			gbCsv.Padding = new Padding(3, 2, 3, 2);
			gbCsv.Size = new Size(756, 140);
			gbCsv.TabIndex = 29;
			gbCsv.TabStop = false;
			gbCsv.Text = "Generar Reporte CSV";
			// 
			// gbGenerar
			// 
			gbGenerar.BackColor = Color.FromArgb(240, 244, 242);
			gbGenerar.Controls.Add(label8);
			gbGenerar.Controls.Add(btncargar);
			gbGenerar.Location = new Point(965, 127);
			gbGenerar.Margin = new Padding(3, 2, 3, 2);
			gbGenerar.Name = "gbGenerar";
			gbGenerar.Padding = new Padding(3, 2, 3, 2);
			gbGenerar.Size = new Size(214, 124);
			gbGenerar.TabIndex = 30;
			gbGenerar.TabStop = false;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.Location = new Point(28, 25);
			label8.Name = "label8";
			label8.Size = new Size(94, 15);
			label8.TabIndex = 10;
			label8.Text = "Generar Nomina";
			// 
			// gbLibras
			// 
			gbLibras.BackColor = Color.FromArgb(240, 244, 242);
			gbLibras.Controls.Add(label7);
			gbLibras.Controls.Add(btnCalcularLibra);
			gbLibras.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			gbLibras.Location = new Point(710, 127);
			gbLibras.Margin = new Padding(3, 2, 3, 2);
			gbLibras.Name = "gbLibras";
			gbLibras.Padding = new Padding(3, 2, 3, 2);
			gbLibras.Size = new Size(214, 124);
			gbLibras.TabIndex = 31;
			gbLibras.TabStop = false;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.Location = new Point(21, 26);
			label7.Name = "label7";
			label7.Size = new Size(122, 13);
			label7.TabIndex = 19;
			label7.Text = "Procesar Libras del Día";
			// 
			// btnGuardar
			// 
			btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
			btnGuardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
			btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
			btnGuardar.Location = new Point(88, 72);
			btnGuardar.Name = "btnGuardar";
			btnGuardar.Padding = new Padding(6, 0, 6, 0);
			btnGuardar.Size = new Size(158, 41);
			btnGuardar.TabIndex = 21;
			btnGuardar.Text = "Actualizar Sueldo ";
			btnGuardar.TextAlign = ContentAlignment.MiddleRight;
			btnGuardar.UseVisualStyleBackColor = true;
			btnGuardar.Click += btnGuardar_Click;
			// 
			// lblTipoProceso
			// 
			lblTipoProceso.AutoSize = true;
			lblTipoProceso.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			lblTipoProceso.ForeColor = SystemColors.ControlLightLight;
			lblTipoProceso.Location = new Point(116, 74);
			lblTipoProceso.Name = "lblTipoProceso";
			lblTipoProceso.Size = new Size(0, 25);
			lblTipoProceso.TabIndex = 33;
			// 
			// btnCerrar
			// 
			btnCerrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
			btnCerrar.ImageAlign = ContentAlignment.MiddleLeft;
			btnCerrar.Location = new Point(21, 17);
			btnCerrar.Name = "btnCerrar";
			btnCerrar.Padding = new Padding(15, 0, 15, 0);
			btnCerrar.Size = new Size(159, 38);
			btnCerrar.TabIndex = 9;
			btnCerrar.Text = "Cerrar Nomina";
			btnCerrar.TextAlign = ContentAlignment.MiddleRight;
			btnCerrar.UseVisualStyleBackColor = true;
			btnCerrar.Click += btnCerrar_Click;
			// 
			// lblAvisoCierre
			// 
			lblAvisoCierre.AutoSize = true;
			lblAvisoCierre.Location = new Point(17, 100);
			lblAvisoCierre.Name = "lblAvisoCierre";
			lblAvisoCierre.Size = new Size(0, 15);
			lblAvisoCierre.TabIndex = 34;
			// 
			// plTitulo
			// 
			plTitulo.BackColor = Color.FromArgb(225, 229, 227);
			plTitulo.Controls.Add(pbImagen);
			plTitulo.Controls.Add(lblSubtitulo);
			plTitulo.Controls.Add(plCerrar);
			plTitulo.Controls.Add(pnCerrar);
			plTitulo.Controls.Add(lblencabezado);
			plTitulo.Controls.Add(lblTipoProceso);
			plTitulo.Location = new Point(12, 12);
			plTitulo.Name = "plTitulo";
			plTitulo.Size = new Size(1171, 100);
			plTitulo.TabIndex = 35;
			plTitulo.Resize += plTitulo_Resize;
			// 
			// pbImagen
			// 
			pbImagen.BackgroundImageLayout = ImageLayout.Zoom;
			pbImagen.Location = new Point(25, 11);
			pbImagen.Name = "pbImagen";
			pbImagen.Size = new Size(70, 76);
			pbImagen.TabIndex = 35;
			pbImagen.TabStop = false;
			// 
			// lblSubtitulo
			// 
			lblSubtitulo.AutoSize = true;
			lblSubtitulo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblSubtitulo.ForeColor = Color.FromArgb(90, 105, 100);
			lblSubtitulo.Location = new Point(116, 46);
			lblSubtitulo.Name = "lblSubtitulo";
			lblSubtitulo.Size = new Size(184, 25);
			lblSubtitulo.TabIndex = 34;
			lblSubtitulo.Text = "Sistema de Nomina ";
			// 
			// plCerrar
			// 
			plCerrar.BackColor = SystemColors.MenuBar;
			plCerrar.Controls.Add(btnCerrar);
			plCerrar.Location = new Point(928, 11);
			plCerrar.Name = "plCerrar";
			plCerrar.Size = new Size(200, 72);
			plCerrar.TabIndex = 33;
			plCerrar.Resize += plCerrar_Resize;
			// 
			// pnCerrar
			// 
			pnCerrar.BackColor = SystemColors.MenuBar;
			pnCerrar.Controls.Add(lblEstado);
			pnCerrar.Controls.Add(pbCirculo);
			pnCerrar.Controls.Add(lblNomina);
			pnCerrar.Location = new Point(683, 11);
			pnCerrar.Name = "pnCerrar";
			pnCerrar.Size = new Size(200, 72);
			pnCerrar.TabIndex = 32;
			pnCerrar.Resize += pnCerrar_Resize;
			// 
			// lblEstado
			// 
			lblEstado.AutoSize = true;
			lblEstado.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEstado.Location = new Point(81, 37);
			lblEstado.Name = "lblEstado";
			lblEstado.Size = new Size(74, 21);
			lblEstado.TabIndex = 2;
			lblEstado.Text = "ESTADO";
			// 
			// pbCirculo
			// 
			pbCirculo.BackgroundImageLayout = ImageLayout.Zoom;
			pbCirculo.Location = new Point(54, 37);
			pbCirculo.Name = "pbCirculo";
			pbCirculo.Size = new Size(30, 27);
			pbCirculo.SizeMode = PictureBoxSizeMode.Zoom;
			pbCirculo.TabIndex = 1;
			pbCirculo.TabStop = false;
			// 
			// lblNomina
			// 
			lblNomina.AutoSize = true;
			lblNomina.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblNomina.ForeColor = SystemColors.ActiveCaptionText;
			lblNomina.Location = new Point(37, 10);
			lblNomina.Name = "lblNomina";
			lblNomina.Size = new Size(135, 17);
			lblNomina.TabIndex = 0;
			lblNomina.Text = "ESTADO DE NÓMINA";
			// 
			// gbFecha
			// 
			gbFecha.BackColor = Color.FromArgb(240, 244, 242);
			gbFecha.Controls.Add(pictureBox5);
			gbFecha.Controls.Add(label4);
			gbFecha.Controls.Add(dtpFecha);
			gbFecha.Controls.Add(lblAvisoCierre);
			gbFecha.Location = new Point(330, 127);
			gbFecha.Margin = new Padding(3, 2, 3, 2);
			gbFecha.Name = "gbFecha";
			gbFecha.Padding = new Padding(3, 2, 3, 2);
			gbFecha.Size = new Size(337, 124);
			gbFecha.TabIndex = 31;
			gbFecha.TabStop = false;
			// 
			// pictureBox5
			// 
			pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
			pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox5.Location = new Point(24, 64);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new Size(24, 23);
			pictureBox5.TabIndex = 36;
			pictureBox5.TabStop = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(17, 26);
			label4.Name = "label4";
			label4.Size = new Size(99, 15);
			label4.TabIndex = 35;
			label4.Text = "Fecha de Trabajo ";
			// 
			// gbSueldos
			// 
			gbSueldos.BackColor = Color.FromArgb(240, 244, 242);
			gbSueldos.Controls.Add(label5);
			gbSueldos.Controls.Add(btnGuardar);
			gbSueldos.Location = new Point(862, 265);
			gbSueldos.Margin = new Padding(3, 2, 3, 2);
			gbSueldos.Name = "gbSueldos";
			gbSueldos.Padding = new Padding(3, 2, 3, 2);
			gbSueldos.Size = new Size(317, 140);
			gbSueldos.TabIndex = 31;
			gbSueldos.TabStop = false;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.Location = new Point(17, 31);
			label5.Name = "label5";
			label5.Size = new Size(177, 15);
			label5.TabIndex = 22;
			label5.Text = "Actualizar Sueldo de Empleados";
			// 
			// tlpDatos
			// 
			tlpDatos.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tlpDatos.ColumnCount = 2;
			tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpDatos.Controls.Add(plCajas, 1, 0);
			tlpDatos.Controls.Add(plEmpleados, 0, 0);
			tlpDatos.Location = new Point(905, 428);
			tlpDatos.Name = "tlpDatos";
			tlpDatos.RowCount = 1;
			tlpDatos.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tlpDatos.Size = new Size(278, 48);
			tlpDatos.TabIndex = 36;
			// 
			// plCajas
			// 
			plCajas.Controls.Add(lblCajas);
			plCajas.Controls.Add(label3);
			plCajas.Controls.Add(pictureBox4);
			plCajas.Location = new Point(142, 4);
			plCajas.Name = "plCajas";
			plCajas.Size = new Size(132, 40);
			plCajas.TabIndex = 1;
			// 
			// lblCajas
			// 
			lblCajas.AutoSize = true;
			lblCajas.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCajas.Location = new Point(69, 22);
			lblCajas.Name = "lblCajas";
			lblCajas.Size = new Size(0, 17);
			lblCajas.TabIndex = 4;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(54, 5);
			label3.Name = "label3";
			label3.Size = new Size(64, 15);
			label3.TabIndex = 2;
			label3.Text = "Total Cajas";
			// 
			// pictureBox4
			// 
			pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
			pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox4.Location = new Point(12, 16);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new Size(25, 18);
			pictureBox4.TabIndex = 1;
			pictureBox4.TabStop = false;
			// 
			// plEmpleados
			// 
			plEmpleados.Controls.Add(lblEmpleados);
			plEmpleados.Controls.Add(label2);
			plEmpleados.Controls.Add(pictureBox3);
			plEmpleados.Location = new Point(4, 4);
			plEmpleados.Name = "plEmpleados";
			plEmpleados.Size = new Size(131, 40);
			plEmpleados.TabIndex = 0;
			// 
			// lblEmpleados
			// 
			lblEmpleados.AutoSize = true;
			lblEmpleados.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblEmpleados.Location = new Point(66, 22);
			lblEmpleados.Name = "lblEmpleados";
			lblEmpleados.Size = new Size(0, 17);
			lblEmpleados.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(50, 5);
			label2.Name = "label2";
			label2.Size = new Size(65, 15);
			label2.TabIndex = 1;
			label2.Text = "Empleados";
			// 
			// pictureBox3
			// 
			pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
			pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox3.Location = new Point(10, 16);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(26, 18);
			pictureBox3.TabIndex = 0;
			pictureBox3.TabStop = false;
			// 
			// pnlInicio
			// 
			pnlInicio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			pnlInicio.BackColor = Color.FromArgb(248, 250, 249);
			pnlInicio.Controls.Add(pictureBox6);
			pnlInicio.Controls.Add(label6);
			pnlInicio.Controls.Add(label1);
			pnlInicio.Location = new Point(12, 478);
			pnlInicio.Name = "pnlInicio";
			pnlInicio.Size = new Size(1171, 343);
			pnlInicio.TabIndex = 37;
			// 
			// pictureBox6
			// 
			pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
			pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
			pictureBox6.Location = new Point(480, 74);
			pictureBox6.Name = "pictureBox6";
			pictureBox6.Size = new Size(133, 126);
			pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox6.TabIndex = 2;
			pictureBox6.TabStop = false;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(95, 105, 100);
			label6.Location = new Point(292, 279);
			label6.Name = "label6";
			label6.Size = new Size(511, 21);
			label6.TabIndex = 1;
			label6.Text = "Selecciona el tipo de nómina y la fecha para consultar la información.";
			label6.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(35, 55, 50);
			label1.Location = new Point(399, 233);
			label1.Name = "label1";
			label1.Size = new Size(296, 32);
			label1.TabIndex = 0;
			label1.Text = " SIN NÓMINA CARGADA";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// FrmSemiAutomatedPayroll
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(245, 247, 246);
			ClientSize = new Size(1201, 824);
			Controls.Add(pnlInicio);
			Controls.Add(tlpDatos);
			Controls.Add(gbSueldos);
			Controls.Add(gbFecha);
			Controls.Add(plTitulo);
			Controls.Add(gbLibras);
			Controls.Add(gbGenerar);
			Controls.Add(gbCsv);
			Controls.Add(lblLineas);
			Controls.Add(gbTipo);
			Controls.Add(dgvEmployee);
			Controls.Add(cboLineas);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmSemiAutomatedPayroll";
			Text = "Reporte de Empaque Central";
			Load += FrmSemiAutomatedPayroll_Load;
			((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			gbTipo.ResumeLayout(false);
			gbTipo.PerformLayout();
			gbCsv.ResumeLayout(false);
			gbCsv.PerformLayout();
			gbGenerar.ResumeLayout(false);
			gbGenerar.PerformLayout();
			gbLibras.ResumeLayout(false);
			gbLibras.PerformLayout();
			plTitulo.ResumeLayout(false);
			plTitulo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
			plCerrar.ResumeLayout(false);
			pnCerrar.ResumeLayout(false);
			pnCerrar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbCirculo).EndInit();
			gbFecha.ResumeLayout(false);
			gbFecha.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			gbSueldos.ResumeLayout(false);
			gbSueldos.PerformLayout();
			tlpDatos.ResumeLayout(false);
			plCajas.ResumeLayout(false);
			plCajas.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			plEmpleados.ResumeLayout(false);
			plEmpleados.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			pnlInicio.ResumeLayout(false);
			pnlInicio.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblLote;
		private Label lblReferencia;
		public DateTimePicker dtpFecha;
		public TextBox txbReferencia;
		public ComboBox cboLote;
		public DataGridView dgvEmployee;
		private Label lblLineas;
		public ComboBox cboLineas;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		public RadioButton rbtEsparrago;
		public RadioButton rbtUva;
		public GroupBox gbCsv;
		public Button btncargar;
		public Button btnCalcularLibra;
		public Button btnCSV;
		public Button btnExcel;
		public Label lblencabezado;
		public GroupBox gbGenerar;
		public GroupBox gbLibras;
		public Button btnGuardar;
		public Label lblTipoProceso;
		public Button btnCerrar;
		public Label lblAvisoCierre;
		public GroupBox groupBox3;
		public GroupBox gbSueldos;
		public GroupBox gbFecha;
		public Panel plTitulo;
		public Label lblEstado;
		public PictureBox pbCirculo;
		public Panel pnCerrar;
		public Panel plCerrar;
		public GroupBox gbTipo;
		public Label lblSubtitulo;
		private Panel panel2;
		private Label label3;
		private PictureBox pictureBox4;
		private Panel panel1;
		private Label label2;
		private PictureBox pictureBox3;
		public Label label6;
		public Label lblEmpleados;
		public Panel plEmpleados;
		public Panel plCajas;
		public Label lblCajas;
		private Label label8;
		private Label label7;
		private Label label4;
		private Label label5;
		private PictureBox pictureBox5;
		public Label lblNomina;
		public PictureBox pbImagen;
		public Label label1;
		private PictureBox pictureBox6;
		public Panel pnlInicio;
		public TableLayoutPanel tlpDatos;
	}
}
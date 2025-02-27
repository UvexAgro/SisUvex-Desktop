namespace SisUvex.Operacion
{
    partial class FrmCajasGranelRegistro
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
            lblLote = new Label();
            txbIdLote = new TextBox();
            cboLote = new ComboBox();
            label8 = new Label();
            lblCaja = new Label();
            cboTroque = new ComboBox();
            lblChofer = new Label();
            cboChofer = new ComboBox();
            lblKgTotales = new Label();
            txbKgTotales = new TextBox();
            lblTaraCaja = new Label();
            txbTaraCaja = new TextBox();
            lblTaraTarima = new Label();
            txbTaraTarima = new TextBox();
            lblCajasRegistro = new Label();
            txbCajasRegistro = new TextBox();
            cboPosicion = new ComboBox();
            lblPosicion = new Label();
            btnAgregar = new Button();
            dgvRegistros = new DataGridView();
            Cajas = new DataGridViewTextBoxColumn();
            Kilogramos = new DataGridViewTextBoxColumn();
            Lote = new DataGridViewTextBoxColumn();
            LoteVariedad = new DataGridViewTextBoxColumn();
            lblCajasTotales = new Label();
            txbCajasTotales = new TextBox();
            btnGuardarRegistro = new Button();
            btnSacarRegistro = new Button();
            lblPapeleta = new Label();
            txbPapeleta = new TextBox();
            lblId = new Label();
            txbId = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            lblKgNetos = new Label();
            txbKgNetos = new TextBox();
            lblKgPorCaja = new Label();
            txbKgPorCaja = new TextBox();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            chbWorkGroupActives = new CheckBox();
            lblWorkGroup = new Label();
            label4 = new Label();
            txbIdWorkGroup = new TextBox();
            cboWorkGroup = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Font = new Font("Segoe UI", 12F);
            lblLote.ForeColor = SystemColors.ControlText;
            lblLote.Location = new Point(17, 13);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(43, 21);
            lblLote.TabIndex = 75;
            lblLote.Text = "Lote:";
            // 
            // txbIdLote
            // 
            txbIdLote.Enabled = false;
            txbIdLote.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdLote.Location = new Point(67, 193);
            txbIdLote.Name = "txbIdLote";
            txbIdLote.Size = new Size(78, 29);
            txbIdLote.TabIndex = 78;
            txbIdLote.TextAlign = HorizontalAlignment.Center;
            // 
            // cboLote
            // 
            cboLote.DropDownHeight = 300;
            cboLote.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLote.DropDownWidth = 500;
            cboLote.Font = new Font("Segoe UI", 12F);
            cboLote.FormattingEnabled = true;
            cboLote.IntegralHeight = false;
            cboLote.ItemHeight = 21;
            cboLote.Location = new Point(150, 10);
            cboLote.MaxDropDownItems = 9;
            cboLote.Name = "cboLote";
            cboLote.Size = new Size(434, 29);
            cboLote.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Crimson;
            label8.Location = new Point(58, 196);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 79;
            label8.Text = "*";
            // 
            // lblCaja
            // 
            lblCaja.AutoSize = true;
            lblCaja.Font = new Font("Segoe UI", 12F);
            lblCaja.Location = new Point(32, 49);
            lblCaja.Name = "lblCaja";
            lblCaja.Size = new Size(61, 21);
            lblCaja.TabIndex = 150;
            lblCaja.Text = "Troque:";
            // 
            // cboTroque
            // 
            cboTroque.Font = new Font("Segoe UI", 12F);
            cboTroque.FormattingEnabled = true;
            cboTroque.ItemHeight = 21;
            cboTroque.Location = new Point(99, 46);
            cboTroque.Name = "cboTroque";
            cboTroque.Size = new Size(108, 29);
            cboTroque.TabIndex = 0;
            // 
            // lblChofer
            // 
            lblChofer.AutoSize = true;
            lblChofer.Font = new Font("Segoe UI", 12F);
            lblChofer.Location = new Point(231, 49);
            lblChofer.Name = "lblChofer";
            lblChofer.Size = new Size(60, 21);
            lblChofer.TabIndex = 154;
            lblChofer.Text = "Chofer:";
            // 
            // cboChofer
            // 
            cboChofer.Font = new Font("Segoe UI", 12F);
            cboChofer.FormattingEnabled = true;
            cboChofer.ItemHeight = 21;
            cboChofer.Location = new Point(297, 46);
            cboChofer.Name = "cboChofer";
            cboChofer.Size = new Size(323, 29);
            cboChofer.TabIndex = 1;
            // 
            // lblKgTotales
            // 
            lblKgTotales.AutoSize = true;
            lblKgTotales.Font = new Font("Segoe UI", 12F);
            lblKgTotales.Location = new Point(12, 84);
            lblKgTotales.Name = "lblKgTotales";
            lblKgTotales.Size = new Size(81, 21);
            lblKgTotales.TabIndex = 157;
            lblKgTotales.Text = "Kg totales:";
            // 
            // txbKgTotales
            // 
            txbKgTotales.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbKgTotales.Location = new Point(99, 81);
            txbKgTotales.MaxLength = 11;
            txbKgTotales.Name = "txbKgTotales";
            txbKgTotales.Size = new Size(108, 29);
            txbKgTotales.TabIndex = 2;
            txbKgTotales.TextChanged += txbValoresKilogramos_TextChanged;
            // 
            // lblTaraCaja
            // 
            lblTaraCaja.AutoSize = true;
            lblTaraCaja.Font = new Font("Segoe UI", 12F);
            lblTaraCaja.Location = new Point(450, 84);
            lblTaraCaja.Name = "lblTaraCaja";
            lblTaraCaja.Size = new Size(93, 21);
            lblTaraCaja.TabIndex = 159;
            lblTaraCaja.Text = "Kg tara caja:";
            // 
            // txbTaraCaja
            // 
            txbTaraCaja.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbTaraCaja.Location = new Point(549, 81);
            txbTaraCaja.MaxLength = 11;
            txbTaraCaja.Name = "txbTaraCaja";
            txbTaraCaja.Size = new Size(69, 29);
            txbTaraCaja.TabIndex = 4;
            txbTaraCaja.TextChanged += txbValoresKilogramos_TextChanged;
            // 
            // lblTaraTarima
            // 
            lblTaraTarima.AutoSize = true;
            lblTaraTarima.Font = new Font("Segoe UI", 12F);
            lblTaraTarima.Location = new Point(244, 84);
            lblTaraTarima.Name = "lblTaraTarima";
            lblTaraTarima.Size = new Size(111, 21);
            lblTaraTarima.TabIndex = 161;
            lblTaraTarima.Text = "Kg tara tarima:";
            // 
            // txbTaraTarima
            // 
            txbTaraTarima.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbTaraTarima.Location = new Point(361, 81);
            txbTaraTarima.MaxLength = 11;
            txbTaraTarima.Name = "txbTaraTarima";
            txbTaraTarima.Size = new Size(83, 29);
            txbTaraTarima.TabIndex = 3;
            txbTaraTarima.TextChanged += txbValoresKilogramos_TextChanged;
            // 
            // lblCajasRegistro
            // 
            lblCajasRegistro.AutoSize = true;
            lblCajasRegistro.Font = new Font("Segoe UI", 12F);
            lblCajasRegistro.Location = new Point(10, 48);
            lblCajasRegistro.Name = "lblCajasRegistro";
            lblCajasRegistro.Size = new Size(50, 21);
            lblCajasRegistro.TabIndex = 163;
            lblCajasRegistro.Text = "Cajas:";
            // 
            // txbCajasRegistro
            // 
            txbCajasRegistro.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbCajasRegistro.Location = new Point(67, 228);
            txbCajasRegistro.MaxLength = 10;
            txbCajasRegistro.Name = "txbCajasRegistro";
            txbCajasRegistro.Size = new Size(78, 29);
            txbCajasRegistro.TabIndex = 10;
            // 
            // cboPosicion
            // 
            cboPosicion.Font = new Font("Segoe UI", 12F);
            cboPosicion.FormattingEnabled = true;
            cboPosicion.ItemHeight = 21;
            cboPosicion.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" });
            cboPosicion.Location = new Point(361, 116);
            cboPosicion.MaxDropDownItems = 20;
            cboPosicion.Name = "cboPosicion";
            cboPosicion.Size = new Size(57, 29);
            cboPosicion.TabIndex = 6;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Font = new Font("Segoe UI", 12F);
            lblPosicion.Location = new Point(288, 119);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(70, 21);
            lblPosicion.TabIndex = 164;
            lblPosicion.Text = "Posición:";
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(277, 45);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(214, 29);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "AGREGAR REGISTRO";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvRegistros
            // 
            dgvRegistros.AllowUserToAddRows = false;
            dgvRegistros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRegistros.BorderStyle = BorderStyle.Fixed3D;
            dgvRegistros.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistros.Columns.AddRange(new DataGridViewColumn[] { Cajas, Kilogramos, Lote, LoteVariedad });
            dgvRegistros.EnableHeadersVisualStyles = false;
            dgvRegistros.Location = new Point(11, 80);
            dgvRegistros.MultiSelect = false;
            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.ReadOnly = true;
            dgvRegistros.RowHeadersVisible = false;
            dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistros.Size = new Size(669, 181);
            dgvRegistros.TabIndex = 15;
            // 
            // Cajas
            // 
            Cajas.HeaderText = "Cajas";
            Cajas.Name = "Cajas";
            Cajas.ReadOnly = true;
            Cajas.Width = 59;
            // 
            // Kilogramos
            // 
            Kilogramos.HeaderText = "Kilogramos";
            Kilogramos.Name = "Kilogramos";
            Kilogramos.ReadOnly = true;
            Kilogramos.Width = 91;
            // 
            // Lote
            // 
            Lote.HeaderText = "Lote";
            Lote.Name = "Lote";
            Lote.ReadOnly = true;
            Lote.Width = 54;
            // 
            // LoteVariedad
            // 
            LoteVariedad.HeaderText = "Lote - Variedad";
            LoteVariedad.Name = "LoteVariedad";
            LoteVariedad.ReadOnly = true;
            LoteVariedad.Width = 110;
            // 
            // lblCajasTotales
            // 
            lblCajasTotales.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCajasTotales.AutoSize = true;
            lblCajasTotales.Font = new Font("Segoe UI", 12F);
            lblCajasTotales.ForeColor = SystemColors.ControlText;
            lblCajasTotales.Location = new Point(67, 465);
            lblCajasTotales.Name = "lblCajasTotales";
            lblCajasTotales.Size = new Size(97, 21);
            lblCajasTotales.TabIndex = 168;
            lblCajasTotales.Text = "Cajas totales";
            // 
            // txbCajasTotales
            // 
            txbCajasTotales.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbCajasTotales.Enabled = false;
            txbCajasTotales.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbCajasTotales.Location = new Point(15, 462);
            txbCajasTotales.Name = "txbCajasTotales";
            txbCajasTotales.Size = new Size(46, 29);
            txbCajasTotales.TabIndex = 169;
            txbCajasTotales.Text = "0";
            txbCajasTotales.TextAlign = HorizontalAlignment.Center;
            // 
            // btnGuardarRegistro
            // 
            btnGuardarRegistro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGuardarRegistro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarRegistro.Location = new Point(564, 463);
            btnGuardarRegistro.Name = "btnGuardarRegistro";
            btnGuardarRegistro.Size = new Size(117, 29);
            btnGuardarRegistro.TabIndex = 13;
            btnGuardarRegistro.Text = "GUARDAR";
            btnGuardarRegistro.UseVisualStyleBackColor = true;
            btnGuardarRegistro.Click += btnGuardarRegistro_Click;
            // 
            // btnSacarRegistro
            // 
            btnSacarRegistro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSacarRegistro.Location = new Point(497, 45);
            btnSacarRegistro.Name = "btnSacarRegistro";
            btnSacarRegistro.Size = new Size(185, 29);
            btnSacarRegistro.TabIndex = 12;
            btnSacarRegistro.Text = "ELIMINAR REGISTRO";
            btnSacarRegistro.UseVisualStyleBackColor = true;
            btnSacarRegistro.Click += btnSacarRegistro_Click;
            // 
            // lblPapeleta
            // 
            lblPapeleta.AutoSize = true;
            lblPapeleta.Font = new Font("Segoe UI", 12F);
            lblPapeleta.Location = new Point(22, 119);
            lblPapeleta.Name = "lblPapeleta";
            lblPapeleta.Size = new Size(71, 21);
            lblPapeleta.TabIndex = 173;
            lblPapeleta.Text = "Papeleta:";
            // 
            // txbPapeleta
            // 
            txbPapeleta.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbPapeleta.Location = new Point(99, 116);
            txbPapeleta.MaxLength = 11;
            txbPapeleta.Name = "txbPapeleta";
            txbPapeleta.Size = new Size(183, 29);
            txbPapeleta.TabIndex = 5;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.ForeColor = SystemColors.ControlText;
            lblId.Location = new Point(12, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(110, 21);
            lblId.TabIndex = 174;
            lblId.Text = "N° de registro:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(128, 10);
            txbId.Name = "txbId";
            txbId.Size = new Size(79, 29);
            txbId.TabIndex = 175;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblCajasRegistro);
            panel1.Controls.Add(lblLote);
            panel1.Controls.Add(cboLote);
            panel1.Controls.Add(btnSacarRegistro);
            panel1.Controls.Add(dgvRegistros);
            panel1.Controls.Add(btnAgregar);
            panel1.Location = new Point(1, 183);
            panel1.Name = "panel1";
            panel1.Size = new Size(691, 273);
            panel1.TabIndex = 176;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(57, 45);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 179;
            label3.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(86, 116);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 177;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(86, 81);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 178;
            label2.Text = "*";
            // 
            // lblKgNetos
            // 
            lblKgNetos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblKgNetos.AutoSize = true;
            lblKgNetos.Font = new Font("Segoe UI", 12F);
            lblKgNetos.ForeColor = SystemColors.ControlText;
            lblKgNetos.Location = new Point(450, 465);
            lblKgNetos.Name = "lblKgNetos";
            lblKgNetos.Size = new Size(70, 21);
            lblKgNetos.TabIndex = 179;
            lblKgNetos.Text = "Kg netos";
            // 
            // txbKgNetos
            // 
            txbKgNetos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbKgNetos.Enabled = false;
            txbKgNetos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbKgNetos.Location = new Point(368, 462);
            txbKgNetos.Name = "txbKgNetos";
            txbKgNetos.Size = new Size(76, 29);
            txbKgNetos.TabIndex = 180;
            txbKgNetos.Text = "0";
            txbKgNetos.TextAlign = HorizontalAlignment.Center;
            // 
            // lblKgPorCaja
            // 
            lblKgPorCaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblKgPorCaja.AutoSize = true;
            lblKgPorCaja.Font = new Font("Segoe UI", 12F);
            lblKgPorCaja.ForeColor = SystemColors.ControlText;
            lblKgPorCaja.Location = new Point(265, 465);
            lblKgPorCaja.Name = "lblKgPorCaja";
            lblKgPorCaja.Size = new Size(87, 21);
            lblKgPorCaja.TabIndex = 181;
            lblKgPorCaja.Text = "Kg por caja";
            // 
            // txbKgPorCaja
            // 
            txbKgPorCaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbKgPorCaja.Enabled = false;
            txbKgPorCaja.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbKgPorCaja.Location = new Point(183, 462);
            txbKgPorCaja.Name = "txbKgPorCaja";
            txbKgPorCaja.Size = new Size(76, 29);
            txbKgPorCaja.TabIndex = 182;
            txbKgPorCaja.Text = "0";
            txbKgPorCaja.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpFecha
            // 
            dtpFecha.CalendarFont = new Font("Segoe UI", 16F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(523, 13);
            dtpFecha.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(98, 23);
            dtpFecha.TabIndex = 14;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 12F);
            lblFecha.Location = new Point(464, 14);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 21);
            lblFecha.TabIndex = 184;
            lblFecha.Text = "Fecha:";
            // 
            // chbWorkGroupActives
            // 
            chbWorkGroupActives.Appearance = Appearance.Button;
            chbWorkGroupActives.AutoSize = true;
            chbWorkGroupActives.BackgroundImage = Properties.Resources.Imagen6;
            chbWorkGroupActives.BackgroundImageLayout = ImageLayout.Stretch;
            chbWorkGroupActives.Font = new Font("Segoe UI", 10F);
            chbWorkGroupActives.Location = new Point(401, 148);
            chbWorkGroupActives.Name = "chbWorkGroupActives";
            chbWorkGroupActives.Size = new Size(39, 29);
            chbWorkGroupActives.TabIndex = 8;
            chbWorkGroupActives.Text = "     ";
            chbWorkGroupActives.UseVisualStyleBackColor = true;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Font = new Font("Segoe UI", 12F);
            lblWorkGroup.ForeColor = SystemColors.ControlText;
            lblWorkGroup.Location = new Point(18, 151);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(75, 21);
            lblWorkGroup.TabIndex = 186;
            lblWorkGroup.Text = "Cuadrilla:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(86, 152);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 188;
            label4.Text = "*";
            // 
            // txbIdWorkGroup
            // 
            txbIdWorkGroup.Enabled = false;
            txbIdWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdWorkGroup.Location = new Point(99, 148);
            txbIdWorkGroup.Name = "txbIdWorkGroup";
            txbIdWorkGroup.Size = new Size(46, 29);
            txbIdWorkGroup.TabIndex = 187;
            txbIdWorkGroup.TextAlign = HorizontalAlignment.Center;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownHeight = 300;
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 464;
            cboWorkGroup.Font = new Font("Segoe UI", 12F);
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.IntegralHeight = false;
            cboWorkGroup.ItemHeight = 21;
            cboWorkGroup.Location = new Point(151, 148);
            cboWorkGroup.MaxDropDownItems = 7;
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(244, 29);
            cboWorkGroup.TabIndex = 7;
            // 
            // FrmCajasGranelRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 503);
            Controls.Add(label4);
            Controls.Add(chbWorkGroupActives);
            Controls.Add(lblWorkGroup);
            Controls.Add(txbIdWorkGroup);
            Controls.Add(cboWorkGroup);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblKgPorCaja);
            Controls.Add(lblKgNetos);
            Controls.Add(txbKgNetos);
            Controls.Add(txbKgPorCaja);
            Controls.Add(label2);
            Controls.Add(lblId);
            Controls.Add(txbId);
            Controls.Add(txbPapeleta);
            Controls.Add(btnGuardarRegistro);
            Controls.Add(lblCajasTotales);
            Controls.Add(txbCajasTotales);
            Controls.Add(cboPosicion);
            Controls.Add(lblPosicion);
            Controls.Add(txbCajasRegistro);
            Controls.Add(lblTaraTarima);
            Controls.Add(txbTaraTarima);
            Controls.Add(lblTaraCaja);
            Controls.Add(txbTaraCaja);
            Controls.Add(lblKgTotales);
            Controls.Add(txbKgTotales);
            Controls.Add(cboChofer);
            Controls.Add(lblChofer);
            Controls.Add(cboTroque);
            Controls.Add(lblCaja);
            Controls.Add(txbIdLote);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(lblPapeleta);
            Controls.Add(panel1);
            Name = "FrmCajasGranelRegistro";
            Text = "Registro de cajas a granel";
            Load += FrmCajasGranelRegistro_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLote;
        public TextBox txbIdLote;
        private Label label8;
        private Label lblCaja;
        private Label lblChofer;
        private Label lblKgTotales;
        public TextBox txbKgTotales;
        private Label lblTaraCaja;
        public TextBox txbTaraCaja;
        private Label lblTaraTarima;
        public TextBox txbTaraTarima;
        private Label lblCajasRegistro;
        public TextBox txbCajasRegistro;
        private Label lblPosicion;
        private Button btnAgregar;
        public DataGridView dgvRegistros;
        private Label lblCajasTotales;
        public TextBox txbCajasTotales;
        private Button btnGuardarRegistro;
        private Button btnSacarRegistro;
        private Label lblPapeleta;
        public TextBox txbPapeleta;
        private Label lblId;
        public TextBox txbId;
        private Panel panel1;
        private Label label3;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn Cajas;
        private DataGridViewTextBoxColumn Kilogramos;
        private DataGridViewTextBoxColumn Lote;
        private DataGridViewTextBoxColumn LoteVariedad;
        private Label lblKgNetos;
        public TextBox txbKgNetos;
        private Label lblKgPorCaja;
        public TextBox txbKgPorCaja;
        private Label lblFecha;
        public CheckBox chbWorkGroupActives;
        private Label lblWorkGroup;
        private Label label4;
        public TextBox txbIdWorkGroup;
        public ComboBox cboWorkGroup;
        public ComboBox cboLote;
        public ComboBox cboTroque;
        public ComboBox cboChofer;
        public ComboBox cboPosicion;
        public DateTimePicker dtpFecha;
    }
}
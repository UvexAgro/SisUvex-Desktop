
namespace SisUvex.Catalogos.PlanTrabajo
{
    partial class FrmPlanTrabajoAñadir
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblObliId = new Label();
            txbIdPrograma = new TextBox();
            lblIdPrograma = new Label();
            lblLote = new Label();
            btnTodoLote = new Button();
            btnBuscarLote = new Button();
            txbIdLote = new TextBox();
            cboLote = new ComboBox();
            lblCuadrilla = new Label();
            btnTodoCuadrilla = new Button();
            btnBuscarCuadrilla = new Button();
            txbIdCuadrilla = new TextBox();
            cboCuadrilla = new ComboBox();
            label5 = new Label();
            label2 = new Label();
            label8 = new Label();
            btnIdProgramaSel = new Button();
            dgvPrograma = new DataGridView();
            lblVPC = new Label();
            txbVPC = new TextBox();
            dtpFechaPlan = new DateTimePicker();
            btnTodoTamaño = new Button();
            btnBuscarTamaño = new Button();
            txbIdTamaño = new TextBox();
            cboTamaño = new ComboBox();
            label1 = new Label();
            label9 = new Label();
            lblContenedor = new Label();
            btnTodoContenedor = new Button();
            btnBuscarContenedor = new Button();
            txbIdContenedor = new TextBox();
            cboContenedor = new ComboBox();
            lblContenedorObli = new Label();
            lblTarima = new Label();
            btnTodoTarima = new Button();
            btnBuscarTarima = new Button();
            txbIdTarima = new TextBox();
            cboTarima = new ComboBox();
            lblTarimaObli = new Label();
            lblTipoContenedor = new Label();
            btnTodos = new Button();
            txbIdTipoContenedor = new TextBox();
            cboTipoContenedor = new ComboBox();
            lblObligatorioTipoContenedor = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrograma).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(283, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir plan de trabajo";
            // 
            // txbId
            // 
            txbId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(922, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(84, 29);
            txbId.TabIndex = 5;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(890, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(930, 623);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(849, 623);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblObliId
            // 
            lblObliId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(913, 12);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 13;
            lblObliId.Text = "*";
            // 
            // txbIdPrograma
            // 
            txbIdPrograma.Enabled = false;
            txbIdPrograma.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdPrograma.Location = new Point(156, 210);
            txbIdPrograma.MaxLength = 20;
            txbIdPrograma.Name = "txbIdPrograma";
            txbIdPrograma.ReadOnly = true;
            txbIdPrograma.Size = new Size(73, 29);
            txbIdPrograma.TabIndex = 42;
            txbIdPrograma.TextAlign = HorizontalAlignment.Center;
            // 
            // lblIdPrograma
            // 
            lblIdPrograma.AutoSize = true;
            lblIdPrograma.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblIdPrograma.Location = new Point(68, 213);
            lblIdPrograma.Name = "lblIdPrograma";
            lblIdPrograma.Size = new Size(82, 21);
            lblIdPrograma.TabIndex = 43;
            lblIdPrograma.Text = "Programa:";
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLote.ForeColor = SystemColors.ControlText;
            lblLote.Location = new Point(55, 84);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(43, 21);
            lblLote.TabIndex = 46;
            lblLote.Text = "Lote:";
            // 
            // btnTodoLote
            // 
            btnTodoLote.Enabled = false;
            btnTodoLote.Location = new Point(689, 81);
            btnTodoLote.Name = "btnTodoLote";
            btnTodoLote.Size = new Size(57, 29);
            btnTodoLote.TabIndex = 49;
            btnTodoLote.Text = "Activos";
            btnTodoLote.UseVisualStyleBackColor = true;
            // 
            // btnBuscarLote
            // 
            btnBuscarLote.Enabled = false;
            btnBuscarLote.Location = new Point(626, 81);
            btnBuscarLote.Name = "btnBuscarLote";
            btnBuscarLote.Size = new Size(57, 29);
            btnBuscarLote.TabIndex = 48;
            btnBuscarLote.Text = "Buscar";
            btnBuscarLote.UseVisualStyleBackColor = true;
            // 
            // txbIdLote
            // 
            txbIdLote.Enabled = false;
            txbIdLote.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdLote.Location = new Point(104, 81);
            txbIdLote.Name = "txbIdLote";
            txbIdLote.Size = new Size(46, 29);
            txbIdLote.TabIndex = 50;
            txbIdLote.TextAlign = HorizontalAlignment.Center;
            // 
            // cboLote
            // 
            cboLote.DropDownHeight = 300;
            cboLote.DropDownWidth = 500;
            cboLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboLote.FormattingEnabled = true;
            cboLote.IntegralHeight = false;
            cboLote.ItemHeight = 21;
            cboLote.Location = new Point(156, 81);
            cboLote.Name = "cboLote";
            cboLote.Size = new Size(464, 29);
            cboLote.TabIndex = 2;
            cboLote.TextChanged += cboLote_TextChanged;
            // 
            // lblCuadrilla
            // 
            lblCuadrilla.AutoSize = true;
            lblCuadrilla.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCuadrilla.ForeColor = SystemColors.ControlText;
            lblCuadrilla.Location = new Point(23, 49);
            lblCuadrilla.Name = "lblCuadrilla";
            lblCuadrilla.Size = new Size(75, 21);
            lblCuadrilla.TabIndex = 52;
            lblCuadrilla.Text = "Cuadrilla:";
            // 
            // btnTodoCuadrilla
            // 
            btnTodoCuadrilla.Enabled = false;
            btnTodoCuadrilla.Location = new Point(689, 47);
            btnTodoCuadrilla.Name = "btnTodoCuadrilla";
            btnTodoCuadrilla.Size = new Size(57, 29);
            btnTodoCuadrilla.TabIndex = 55;
            btnTodoCuadrilla.Text = "Activos";
            btnTodoCuadrilla.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCuadrilla
            // 
            btnBuscarCuadrilla.Enabled = false;
            btnBuscarCuadrilla.Location = new Point(626, 47);
            btnBuscarCuadrilla.Name = "btnBuscarCuadrilla";
            btnBuscarCuadrilla.Size = new Size(57, 29);
            btnBuscarCuadrilla.TabIndex = 54;
            btnBuscarCuadrilla.Text = "Buscar";
            btnBuscarCuadrilla.UseVisualStyleBackColor = true;
            // 
            // txbIdCuadrilla
            // 
            txbIdCuadrilla.Enabled = false;
            txbIdCuadrilla.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdCuadrilla.Location = new Point(104, 46);
            txbIdCuadrilla.Name = "txbIdCuadrilla";
            txbIdCuadrilla.Size = new Size(46, 29);
            txbIdCuadrilla.TabIndex = 56;
            txbIdCuadrilla.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCuadrilla
            // 
            cboCuadrilla.DropDownHeight = 300;
            cboCuadrilla.DropDownWidth = 464;
            cboCuadrilla.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboCuadrilla.FormattingEnabled = true;
            cboCuadrilla.IntegralHeight = false;
            cboCuadrilla.ItemHeight = 21;
            cboCuadrilla.Location = new Point(156, 46);
            cboCuadrilla.Name = "cboCuadrilla";
            cboCuadrilla.Size = new Size(464, 29);
            cboCuadrilla.TabIndex = 1;
            cboCuadrilla.TextChanged += cboCuadrilla_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(148, 211);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 57;
            label5.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(96, 49);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 70;
            label2.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Crimson;
            label8.Location = new Point(95, 84);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 73;
            label8.Text = "*";
            // 
            // btnIdProgramaSel
            // 
            btnIdProgramaSel.Location = new Point(235, 210);
            btnIdProgramaSel.Name = "btnIdProgramaSel";
            btnIdProgramaSel.Size = new Size(136, 29);
            btnIdProgramaSel.TabIndex = 5;
            btnIdProgramaSel.Text = "Seleccionar programa";
            btnIdProgramaSel.UseVisualStyleBackColor = true;
            btnIdProgramaSel.Click += btnIdProgramaSel_Click;
            // 
            // dgvPrograma
            // 
            dgvPrograma.AllowUserToAddRows = false;
            dgvPrograma.AllowUserToDeleteRows = false;
            dgvPrograma.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPrograma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPrograma.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPrograma.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPrograma.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPrograma.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPrograma.EnableHeadersVisualStyles = false;
            dgvPrograma.ImeMode = ImeMode.NoControl;
            dgvPrograma.Location = new Point(17, 287);
            dgvPrograma.Name = "dgvPrograma";
            dgvPrograma.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPrograma.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPrograma.RowHeadersVisible = false;
            dgvPrograma.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPrograma.RowTemplate.Height = 25;
            dgvPrograma.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrograma.Size = new Size(988, 260);
            dgvPrograma.TabIndex = 93;
            dgvPrograma.DoubleClick += dgvPrograma_DoubleClick;
            // 
            // lblVPC
            // 
            lblVPC.AutoSize = true;
            lblVPC.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblVPC.ForeColor = SystemColors.ControlDark;
            lblVPC.Location = new Point(541, 213);
            lblVPC.Name = "lblVPC";
            lblVPC.Size = new Size(119, 21);
            lblVPC.TabIndex = 108;
            lblVPC.Text = "Voice pick code:";
            // 
            // txbVPC
            // 
            txbVPC.Enabled = false;
            txbVPC.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbVPC.Location = new Point(662, 210);
            txbVPC.Name = "txbVPC";
            txbVPC.Size = new Size(84, 29);
            txbVPC.TabIndex = 109;
            txbVPC.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpFechaPlan
            // 
            dtpFechaPlan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFechaPlan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFechaPlan.Format = DateTimePickerFormat.Short;
            dtpFechaPlan.Location = new Point(762, 12);
            dtpFechaPlan.Name = "dtpFechaPlan";
            dtpFechaPlan.Size = new Size(122, 29);
            dtpFechaPlan.TabIndex = 11;
            dtpFechaPlan.ValueChanged += dtpFechaPlan_ValueChanged;
            // 
            // btnTodoTamaño
            // 
            btnTodoTamaño.Enabled = false;
            btnTodoTamaño.Location = new Point(689, 171);
            btnTodoTamaño.Name = "btnTodoTamaño";
            btnTodoTamaño.Size = new Size(57, 29);
            btnTodoTamaño.TabIndex = 119;
            btnTodoTamaño.Text = "Activos";
            btnTodoTamaño.UseVisualStyleBackColor = true;
            // 
            // btnBuscarTamaño
            // 
            btnBuscarTamaño.Enabled = false;
            btnBuscarTamaño.Location = new Point(626, 171);
            btnBuscarTamaño.Name = "btnBuscarTamaño";
            btnBuscarTamaño.Size = new Size(57, 29);
            btnBuscarTamaño.TabIndex = 118;
            btnBuscarTamaño.Text = "Buscar";
            btnBuscarTamaño.UseVisualStyleBackColor = true;
            // 
            // txbIdTamaño
            // 
            txbIdTamaño.Enabled = false;
            txbIdTamaño.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdTamaño.Location = new Point(484, 171);
            txbIdTamaño.Name = "txbIdTamaño";
            txbIdTamaño.Size = new Size(46, 29);
            txbIdTamaño.TabIndex = 120;
            txbIdTamaño.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTamaño
            // 
            cboTamaño.DropDownHeight = 300;
            cboTamaño.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTamaño.DropDownWidth = 100;
            cboTamaño.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboTamaño.FormattingEnabled = true;
            cboTamaño.IntegralHeight = false;
            cboTamaño.ItemHeight = 21;
            cboTamaño.Items.AddRange(new object[] { "11", "22", "33", "44", "55", "66", "77", "88", "99" });
            cboTamaño.Location = new Point(536, 171);
            cboTamaño.Name = "cboTamaño";
            cboTamaño.Size = new Size(84, 29);
            cboTamaño.TabIndex = 4;
            cboTamaño.TextChanged += cboTamaño_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(475, 171);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 121;
            label1.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(413, 173);
            label9.Name = "label9";
            label9.Size = new Size(67, 21);
            label9.TabIndex = 116;
            label9.Text = "Tamaño:";
            // 
            // lblContenedor
            // 
            lblContenedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblContenedor.AutoSize = true;
            lblContenedor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblContenedor.ForeColor = SystemColors.ControlText;
            lblContenedor.Location = new Point(55, 556);
            lblContenedor.Name = "lblContenedor";
            lblContenedor.Size = new Size(95, 21);
            lblContenedor.TabIndex = 123;
            lblContenedor.Text = "Contenedor:";
            // 
            // btnTodoContenedor
            // 
            btnTodoContenedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTodoContenedor.Enabled = false;
            btnTodoContenedor.Location = new Point(768, 553);
            btnTodoContenedor.Name = "btnTodoContenedor";
            btnTodoContenedor.Size = new Size(57, 29);
            btnTodoContenedor.TabIndex = 125;
            btnTodoContenedor.Text = "Activos";
            btnTodoContenedor.UseVisualStyleBackColor = true;
            // 
            // btnBuscarContenedor
            // 
            btnBuscarContenedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBuscarContenedor.Enabled = false;
            btnBuscarContenedor.Location = new Point(705, 553);
            btnBuscarContenedor.Name = "btnBuscarContenedor";
            btnBuscarContenedor.Size = new Size(57, 29);
            btnBuscarContenedor.TabIndex = 124;
            btnBuscarContenedor.Text = "Buscar";
            btnBuscarContenedor.UseVisualStyleBackColor = true;
            // 
            // txbIdContenedor
            // 
            txbIdContenedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbIdContenedor.Enabled = false;
            txbIdContenedor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdContenedor.Location = new Point(156, 553);
            txbIdContenedor.Name = "txbIdContenedor";
            txbIdContenedor.Size = new Size(73, 29);
            txbIdContenedor.TabIndex = 126;
            txbIdContenedor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboContenedor
            // 
            cboContenedor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cboContenedor.DropDownHeight = 300;
            cboContenedor.DropDownWidth = 500;
            cboContenedor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboContenedor.FormattingEnabled = true;
            cboContenedor.IntegralHeight = false;
            cboContenedor.ItemHeight = 21;
            cboContenedor.Location = new Point(235, 553);
            cboContenedor.Name = "cboContenedor";
            cboContenedor.Size = new Size(464, 29);
            cboContenedor.TabIndex = 122;
            cboContenedor.TextUpdate += cboContenedor_TextUpdate;
            // 
            // lblContenedorObli
            // 
            lblContenedorObli.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblContenedorObli.AutoSize = true;
            lblContenedorObli.ForeColor = Color.Crimson;
            lblContenedorObli.Location = new Point(147, 556);
            lblContenedorObli.Name = "lblContenedorObli";
            lblContenedorObli.Size = new Size(12, 15);
            lblContenedorObli.TabIndex = 127;
            lblContenedorObli.Text = "*";
            // 
            // lblTarima
            // 
            lblTarima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTarima.AutoSize = true;
            lblTarima.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTarima.ForeColor = SystemColors.ControlText;
            lblTarima.Location = new Point(55, 591);
            lblTarima.Name = "lblTarima";
            lblTarima.Size = new Size(59, 21);
            lblTarima.TabIndex = 129;
            lblTarima.Text = "Tarima:";
            // 
            // btnTodoTarima
            // 
            btnTodoTarima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnTodoTarima.Enabled = false;
            btnTodoTarima.Location = new Point(768, 588);
            btnTodoTarima.Name = "btnTodoTarima";
            btnTodoTarima.Size = new Size(57, 29);
            btnTodoTarima.TabIndex = 131;
            btnTodoTarima.Text = "Activos";
            btnTodoTarima.UseVisualStyleBackColor = true;
            // 
            // btnBuscarTarima
            // 
            btnBuscarTarima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBuscarTarima.Enabled = false;
            btnBuscarTarima.Location = new Point(705, 588);
            btnBuscarTarima.Name = "btnBuscarTarima";
            btnBuscarTarima.Size = new Size(57, 29);
            btnBuscarTarima.TabIndex = 130;
            btnBuscarTarima.Text = "Buscar";
            btnBuscarTarima.UseVisualStyleBackColor = true;
            // 
            // txbIdTarima
            // 
            txbIdTarima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txbIdTarima.Enabled = false;
            txbIdTarima.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdTarima.Location = new Point(156, 588);
            txbIdTarima.Name = "txbIdTarima";
            txbIdTarima.Size = new Size(73, 29);
            txbIdTarima.TabIndex = 132;
            txbIdTarima.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTarima
            // 
            cboTarima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cboTarima.DropDownHeight = 300;
            cboTarima.DropDownWidth = 500;
            cboTarima.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboTarima.FormattingEnabled = true;
            cboTarima.IntegralHeight = false;
            cboTarima.ItemHeight = 21;
            cboTarima.Location = new Point(235, 588);
            cboTarima.Name = "cboTarima";
            cboTarima.Size = new Size(464, 29);
            cboTarima.TabIndex = 128;
            cboTarima.TextUpdate += cboTarima_TextUpdate;
            // 
            // lblTarimaObli
            // 
            lblTarimaObli.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTarimaObli.AutoSize = true;
            lblTarimaObli.ForeColor = Color.Crimson;
            lblTarimaObli.Location = new Point(147, 591);
            lblTarimaObli.Name = "lblTarimaObli";
            lblTarimaObli.Size = new Size(12, 15);
            lblTarimaObli.TabIndex = 133;
            lblTarimaObli.Text = "*";
            // 
            // lblTipoContenedor
            // 
            lblTipoContenedor.AutoSize = true;
            lblTipoContenedor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipoContenedor.Location = new Point(2, 119);
            lblTipoContenedor.Name = "lblTipoContenedor";
            lblTipoContenedor.Size = new Size(147, 21);
            lblTipoContenedor.TabIndex = 134;
            lblTipoContenedor.Text = "Tipo de contenedor:";
            // 
            // btnTodos
            // 
            btnTodos.Location = new Point(626, 116);
            btnTodos.Name = "btnTodos";
            btnTodos.Size = new Size(57, 29);
            btnTodos.TabIndex = 136;
            btnTodos.Text = "Todos";
            btnTodos.UseVisualStyleBackColor = true;
            btnTodos.Click += btnTodos_Click;
            // 
            // txbIdTipoContenedor
            // 
            txbIdTipoContenedor.Enabled = false;
            txbIdTipoContenedor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdTipoContenedor.Location = new Point(156, 116);
            txbIdTipoContenedor.Name = "txbIdTipoContenedor";
            txbIdTipoContenedor.Size = new Size(46, 29);
            txbIdTipoContenedor.TabIndex = 137;
            txbIdTipoContenedor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTipoContenedor
            // 
            cboTipoContenedor.DropDownHeight = 300;
            cboTipoContenedor.DropDownWidth = 500;
            cboTipoContenedor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboTipoContenedor.FormattingEnabled = true;
            cboTipoContenedor.IntegralHeight = false;
            cboTipoContenedor.ItemHeight = 21;
            cboTipoContenedor.Location = new Point(208, 116);
            cboTipoContenedor.Name = "cboTipoContenedor";
            cboTipoContenedor.Size = new Size(412, 29);
            cboTipoContenedor.TabIndex = 135;
            cboTipoContenedor.TextChanged += cboTipoContenedor_TextChanged;
            // 
            // lblObligatorioTipoContenedor
            // 
            lblObligatorioTipoContenedor.AutoSize = true;
            lblObligatorioTipoContenedor.ForeColor = Color.Crimson;
            lblObligatorioTipoContenedor.Location = new Point(148, 116);
            lblObligatorioTipoContenedor.Name = "lblObligatorioTipoContenedor";
            lblObligatorioTipoContenedor.Size = new Size(12, 15);
            lblObligatorioTipoContenedor.TabIndex = 138;
            lblObligatorioTipoContenedor.Text = "*";
            // 
            // FrmPlanTrabajoAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 659);
            Controls.Add(lblTipoContenedor);
            Controls.Add(btnTodos);
            Controls.Add(txbIdTipoContenedor);
            Controls.Add(cboTipoContenedor);
            Controls.Add(lblObligatorioTipoContenedor);
            Controls.Add(lblTarima);
            Controls.Add(btnTodoTarima);
            Controls.Add(btnBuscarTarima);
            Controls.Add(txbIdTarima);
            Controls.Add(cboTarima);
            Controls.Add(lblTarimaObli);
            Controls.Add(lblContenedor);
            Controls.Add(btnTodoContenedor);
            Controls.Add(btnBuscarContenedor);
            Controls.Add(txbIdContenedor);
            Controls.Add(cboContenedor);
            Controls.Add(lblContenedorObli);
            Controls.Add(btnTodoTamaño);
            Controls.Add(btnBuscarTamaño);
            Controls.Add(txbIdTamaño);
            Controls.Add(cboTamaño);
            Controls.Add(label1);
            Controls.Add(label9);
            Controls.Add(dtpFechaPlan);
            Controls.Add(lblVPC);
            Controls.Add(txbVPC);
            Controls.Add(dgvPrograma);
            Controls.Add(btnIdProgramaSel);
            Controls.Add(lblCuadrilla);
            Controls.Add(btnTodoCuadrilla);
            Controls.Add(btnBuscarCuadrilla);
            Controls.Add(txbIdCuadrilla);
            Controls.Add(cboCuadrilla);
            Controls.Add(lblLote);
            Controls.Add(btnTodoLote);
            Controls.Add(btnBuscarLote);
            Controls.Add(txbIdLote);
            Controls.Add(cboLote);
            Controls.Add(lblIdPrograma);
            Controls.Add(txbIdPrograma);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(label2);
            MaximizeBox = false;
            MinimumSize = new Size(768, 507);
            Name = "FrmPlanTrabajoAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir Plan de trabajo";
            FormClosing += FrmPlanTrabajoAñadir_FormClosing;
            Load += FrmPlanTrabajoAñadir_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrograma).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        public Label lblTitulo;
        public TextBox txbId;
        private Label lblObliId;
        private Label lblIdPrograma;
        private Label lblLote;
        private Button btnTodoLote;
        private Button btnBuscarLote;
        public TextBox txbIdLote;
        private ComboBox cboLote;
        private Label lblCuadrilla;
        private Button btnTodoCuadrilla;
        private Button btnBuscarCuadrilla;
        public TextBox txbIdCuadrilla;
        private ComboBox cboCuadrilla;
        private Label label5;
        private Label lblDistribuidor;
        private Button btnTodoDistribuidor;
        private Button btnBuscarDistribuidor;
        public TextBox txbIdDistribuidor;
        private ComboBox cboDistribuidor;
        private Label lblColorVariedad;
        public TextBox txbIdColorVariedad;
        private ComboBox cboColorVariedad;
        private Label label2;
        private Label label6;
        private Label label8;
        public TextBox txbIdPrograma;
        private Label label7;
        private Button btnTodoTamaño;
        private Button btnBuscarTamaño;
        public TextBox txbIdTamaño;
        private ComboBox cboTamaño;
        private Label label9;
        private Button btnIdProgramaSel;
        private Label label4;
        public DataGridView dgvPrograma;
        private Label lblNotaDani;
        public TextBox txbLibras;
        private Label lblLibras;
        private Label lblVPC;
        public TextBox txbVPC;
        private MaskedTextBox maskedTextBox1;
        private Label label11;
        public DateTimePicker dtpFechaPlan;
        private Label label1;
        private Label lblContenedor;
        private Button btnTodoContenedor;
        private Button btnBuscarContenedor;
        public TextBox txbIdContenedor;
        private ComboBox cboContenedor;
        private Label lblContenedorObli;
        private Label lblTarima;
        private Button btnTodoTarima;
        private Button btnBuscarTarima;
        public TextBox txbIdTarima;
        private ComboBox cboTarima;
        private Label lblTarimaObli;
        private Label lblTipoContenedor;
        private Button btnTodos;
        public TextBox txbIdTipoContenedor;
        private ComboBox cboTipoContenedor;
        private Label lblObligatorioTipoContenedor;
    }
}
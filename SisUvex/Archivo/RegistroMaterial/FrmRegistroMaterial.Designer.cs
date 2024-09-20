namespace SisUvex.Archivo.RegistroMaterial
{
    partial class FrmRegistroMaterial
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
            lblTitulo = new Label();
            lblFecha = new Label();
            btnTodoProveedor = new Button();
            btnBuscarProveedor = new Button();
            cboProveedor = new ComboBox();
            lblProveedor = new Label();
            btnBuscarTipoMat = new Button();
            txbIdTipoMat = new TextBox();
            cboTipoMat = new ComboBox();
            lblTipoMat = new Label();
            btnTodoMaterial = new Button();
            btnBuscarMaterial = new Button();
            txbIdMaterial = new TextBox();
            cboMaterial = new ComboBox();
            lblMaterial = new Label();
            txbCantidad = new TextBox();
            lblCantidad = new Label();
            dgvMateriales = new DataGridView();
            Código = new DataGridViewTextBoxColumn();
            Item = new DataGridViewTextBoxColumn();
            idMaterial = new DataGridViewTextBoxColumn();
            NombrMaterial = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Unidad = new DataGridViewTextBoxColumn();
            Ubicacion = new DataGridViewTextBoxColumn();
            idLote = new DataGridViewTextBoxColumn();
            NombreLote = new DataGridViewTextBoxColumn();
            Folio = new DataGridViewTextBoxColumn();
            FechaRegistro = new DataGridViewTextBoxColumn();
            Proveedor = new DataGridViewTextBoxColumn();
            Linea = new DataGridViewTextBoxColumn();
            Chofer = new DataGridViewTextBoxColumn();
            Caja = new DataGridViewTextBoxColumn();
            Placas = new DataGridViewTextBoxColumn();
            Observaciones = new DataGridViewTextBoxColumn();
            btnAñadir = new Button();
            dtpFecha = new DateTimePicker();
            txbId = new TextBox();
            lblId = new Label();
            lblCampo = new Label();
            cboCampo = new ComboBox();
            btnEliminarSel = new Button();
            txbCaja = new TextBox();
            lblCaja = new Label();
            lblPlacas = new Label();
            txbPlacas = new TextBox();
            lblChofer = new Label();
            txbChofer = new TextBox();
            txbUnidad = new TextBox();
            lblLote = new Label();
            cboLote = new ComboBox();
            btnTodoLote = new Button();
            btnBuscarLote = new Button();
            txbIdLote = new TextBox();
            btnModificarSel = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnTodoLineaTran = new Button();
            btnBuscarLineaTran = new Button();
            cboLineaTran = new ComboBox();
            lblLineaTran = new Label();
            txbItem = new TextBox();
            lblItem = new Label();
            txbFolio = new TextBox();
            lblFolio = new Label();
            txbObservaciones = new TextBox();
            lblObservaciones = new Label();
            lblObliTipoMaterial = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(289, 31);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Registro de materiales";
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha.Location = new Point(642, 16);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 21);
            lblFecha.TabIndex = 56;
            lblFecha.Text = "Fecha:";
            // 
            // btnTodoProveedor
            // 
            btnTodoProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTodoProveedor.Location = new Point(760, 149);
            btnTodoProveedor.Name = "btnTodoProveedor";
            btnTodoProveedor.Size = new Size(54, 29);
            btnTodoProveedor.TabIndex = 7;
            btnTodoProveedor.Text = "Todo";
            btnTodoProveedor.UseVisualStyleBackColor = true;
            btnTodoProveedor.Click += btnTodoProveedor_Click;
            // 
            // btnBuscarProveedor
            // 
            btnBuscarProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarProveedor.Location = new Point(700, 149);
            btnBuscarProveedor.Name = "btnBuscarProveedor";
            btnBuscarProveedor.Size = new Size(54, 29);
            btnBuscarProveedor.TabIndex = 6;
            btnBuscarProveedor.Text = "Buscar";
            btnBuscarProveedor.UseVisualStyleBackColor = true;
            btnBuscarProveedor.Click += btnBuscarProveedor_Click;
            // 
            // cboProveedor
            // 
            cboProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboProveedor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboProveedor.FormattingEnabled = true;
            cboProveedor.ItemHeight = 21;
            cboProveedor.Location = new Point(114, 149);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(579, 29);
            cboProveedor.TabIndex = 5;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblProveedor.Location = new Point(23, 157);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(85, 21);
            lblProveedor.TabIndex = 94;
            lblProveedor.Text = "Proveedor:";
            // 
            // btnBuscarTipoMat
            // 
            btnBuscarTipoMat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarTipoMat.Location = new Point(701, 352);
            btnBuscarTipoMat.Name = "btnBuscarTipoMat";
            btnBuscarTipoMat.Size = new Size(54, 29);
            btnBuscarTipoMat.TabIndex = 15;
            btnBuscarTipoMat.Text = "Buscar";
            btnBuscarTipoMat.UseVisualStyleBackColor = true;
            btnBuscarTipoMat.Click += btnBuscarTipoMat_Click;
            // 
            // txbIdTipoMat
            // 
            txbIdTipoMat.Enabled = false;
            txbIdTipoMat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdTipoMat.Location = new Point(142, 351);
            txbIdTipoMat.Name = "txbIdTipoMat";
            txbIdTipoMat.Size = new Size(43, 29);
            txbIdTipoMat.TabIndex = 100;
            txbIdTipoMat.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTipoMat
            // 
            cboTipoMat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboTipoMat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboTipoMat.FormattingEnabled = true;
            cboTipoMat.ItemHeight = 21;
            cboTipoMat.Location = new Point(191, 351);
            cboTipoMat.Name = "cboTipoMat";
            cboTipoMat.Size = new Size(502, 29);
            cboTipoMat.TabIndex = 14;
            cboTipoMat.TextChanged += cboTipoMat_TextChanged;
            cboTipoMat.MouseClick += cboTipoMat_MouseClick;
            // 
            // lblTipoMat
            // 
            lblTipoMat.AutoSize = true;
            lblTipoMat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipoMat.Location = new Point(11, 354);
            lblTipoMat.Name = "lblTipoMat";
            lblTipoMat.Size = new Size(125, 21);
            lblTipoMat.TabIndex = 99;
            lblTipoMat.Text = "Tipo de material:";
            // 
            // btnTodoMaterial
            // 
            btnTodoMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTodoMaterial.Location = new Point(761, 386);
            btnTodoMaterial.Name = "btnTodoMaterial";
            btnTodoMaterial.Size = new Size(54, 29);
            btnTodoMaterial.TabIndex = 18;
            btnTodoMaterial.Text = "Todo";
            btnTodoMaterial.UseVisualStyleBackColor = true;
            btnTodoMaterial.Click += btnTodoMaterial_Click;
            // 
            // btnBuscarMaterial
            // 
            btnBuscarMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarMaterial.Location = new Point(701, 386);
            btnBuscarMaterial.Name = "btnBuscarMaterial";
            btnBuscarMaterial.Size = new Size(54, 29);
            btnBuscarMaterial.TabIndex = 17;
            btnBuscarMaterial.Text = "Buscar";
            btnBuscarMaterial.UseVisualStyleBackColor = true;
            btnBuscarMaterial.Click += btnBuscarMaterial_Click;
            // 
            // txbIdMaterial
            // 
            txbIdMaterial.Enabled = false;
            txbIdMaterial.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdMaterial.Location = new Point(142, 386);
            txbIdMaterial.Name = "txbIdMaterial";
            txbIdMaterial.Size = new Size(76, 29);
            txbIdMaterial.TabIndex = 105;
            txbIdMaterial.TextAlign = HorizontalAlignment.Center;
            txbIdMaterial.TextChanged += txbIdMaterial_TextChanged;
            // 
            // cboMaterial
            // 
            cboMaterial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMaterial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboMaterial.FormattingEnabled = true;
            cboMaterial.ItemHeight = 21;
            cboMaterial.Location = new Point(224, 385);
            cboMaterial.Name = "cboMaterial";
            cboMaterial.Size = new Size(469, 29);
            cboMaterial.TabIndex = 16;
            cboMaterial.TextChanged += cboMaterial_TextChanged;
            cboMaterial.MouseClick += cboMaterial_MouseClick;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaterial.Location = new Point(66, 389);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(70, 21);
            lblMaterial.TabIndex = 104;
            lblMaterial.Text = "Material:";
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbCantidad.Location = new Point(142, 421);
            txbCantidad.MaxLength = 11;
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(183, 29);
            txbCantidad.TabIndex = 19;
            txbCantidad.TextChanged += txbCantidad_TextChanged;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidad.Location = new Point(61, 424);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(75, 21);
            lblCantidad.TabIndex = 107;
            lblCantidad.Text = "Cantidad:";
            // 
            // dgvMateriales
            // 
            dgvMateriales.AllowUserToAddRows = false;
            dgvMateriales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMateriales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMateriales.BorderStyle = BorderStyle.Fixed3D;
            dgvMateriales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMateriales.Columns.AddRange(new DataGridViewColumn[] { Código, Item, idMaterial, NombrMaterial, Cantidad, Unidad, Ubicacion, idLote, NombreLote, Folio, FechaRegistro, Proveedor, Linea, Chofer, Caja, Placas, Observaciones });
            dgvMateriales.EnableHeadersVisualStyles = false;
            dgvMateriales.Location = new Point(11, 557);
            dgvMateriales.Name = "dgvMateriales";
            dgvMateriales.ReadOnly = true;
            dgvMateriales.RowHeadersVisible = false;
            dgvMateriales.RowTemplate.Height = 25;
            dgvMateriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMateriales.Size = new Size(802, 136);
            dgvMateriales.TabIndex = 132;
            dgvMateriales.CellContentClick += dgvMateriales_CellContentClick;
            // 
            // Código
            // 
            Código.HeaderText = "Código";
            Código.Name = "Código";
            Código.ReadOnly = true;
            // 
            // Item
            // 
            Item.HeaderText = "Item";
            Item.Name = "Item";
            Item.ReadOnly = true;
            // 
            // idMaterial
            // 
            idMaterial.HeaderText = "idMaterial";
            idMaterial.Name = "idMaterial";
            idMaterial.ReadOnly = true;
            // 
            // NombrMaterial
            // 
            NombrMaterial.HeaderText = "Nombre material";
            NombrMaterial.Name = "NombrMaterial";
            NombrMaterial.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Unidad
            // 
            Unidad.HeaderText = "Unidad";
            Unidad.Name = "Unidad";
            Unidad.ReadOnly = true;
            // 
            // Ubicacion
            // 
            Ubicacion.HeaderText = "Ubicación";
            Ubicacion.Name = "Ubicacion";
            Ubicacion.ReadOnly = true;
            // 
            // idLote
            // 
            idLote.HeaderText = "id lote";
            idLote.Name = "idLote";
            idLote.ReadOnly = true;
            // 
            // NombreLote
            // 
            NombreLote.HeaderText = "Nombre lote";
            NombreLote.Name = "NombreLote";
            NombreLote.ReadOnly = true;
            // 
            // Folio
            // 
            Folio.HeaderText = "Folio";
            Folio.Name = "Folio";
            Folio.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            FechaRegistro.HeaderText = "Fecha";
            FechaRegistro.Name = "FechaRegistro";
            FechaRegistro.ReadOnly = true;
            // 
            // Proveedor
            // 
            Proveedor.HeaderText = "Proveedor";
            Proveedor.Name = "Proveedor";
            Proveedor.ReadOnly = true;
            // 
            // Linea
            // 
            Linea.HeaderText = "Línea";
            Linea.Name = "Linea";
            Linea.ReadOnly = true;
            // 
            // Chofer
            // 
            Chofer.HeaderText = "Chofer";
            Chofer.Name = "Chofer";
            Chofer.ReadOnly = true;
            // 
            // Caja
            // 
            Caja.HeaderText = "Caja";
            Caja.Name = "Caja";
            Caja.ReadOnly = true;
            // 
            // Placas
            // 
            Placas.HeaderText = "Placas";
            Placas.Name = "Placas";
            Placas.ReadOnly = true;
            // 
            // Observaciones
            // 
            Observaciones.HeaderText = "Observaciones";
            Observaciones.Name = "Observaciones";
            Observaciones.ReadOnly = true;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(474, 421);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(64, 29);
            btnAñadir.TabIndex = 20;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFecha.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(699, 12);
            dtpFecha.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpFecha.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(114, 27);
            dtpFecha.TabIndex = 26;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            dtpFecha.Enter += dtpFecha_Enter;
            dtpFecha.Leave += dtpFecha_Leave;
            // 
            // txbId
            // 
            txbId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(517, 10);
            txbId.Name = "txbId";
            txbId.Size = new Size(119, 29);
            txbId.TabIndex = 142;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(485, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 143;
            lblId.Text = "id:";
            // 
            // lblCampo
            // 
            lblCampo.AutoSize = true;
            lblCampo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCampo.Location = new Point(23, 46);
            lblCampo.Name = "lblCampo";
            lblCampo.Size = new Size(63, 21);
            lblCampo.TabIndex = 145;
            lblCampo.Text = "Campo:";
            // 
            // cboCampo
            // 
            cboCampo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCampo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboCampo.FormattingEnabled = true;
            cboCampo.ItemHeight = 21;
            cboCampo.Items.AddRange(new object[] { "Don Luis", "San Andrés", "20s", "40s", "Espárrago" });
            cboCampo.Location = new Point(92, 43);
            cboCampo.MaxLength = 15;
            cboCampo.Name = "cboCampo";
            cboCampo.Size = new Size(296, 29);
            cboCampo.TabIndex = 0;
            // 
            // btnEliminarSel
            // 
            btnEliminarSel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminarSel.Location = new Point(676, 524);
            btnEliminarSel.Name = "btnEliminarSel";
            btnEliminarSel.Size = new Size(139, 27);
            btnEliminarSel.TabIndex = 23;
            btnEliminarSel.Text = "Eliminiar seleccionado";
            btnEliminarSel.UseVisualStyleBackColor = true;
            btnEliminarSel.Click += btnEliminarSel_Click;
            // 
            // txbCaja
            // 
            txbCaja.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbCaja.Location = new Point(176, 266);
            txbCaja.MaxLength = 15;
            txbCaja.Name = "txbCaja";
            txbCaja.Size = new Size(233, 29);
            txbCaja.TabIndex = 12;
            // 
            // lblCaja
            // 
            lblCaja.AutoSize = true;
            lblCaja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaja.Location = new Point(127, 269);
            lblCaja.Name = "lblCaja";
            lblCaja.Size = new Size(43, 21);
            lblCaja.TabIndex = 148;
            lblCaja.Text = "Caja:";
            // 
            // lblPlacas
            // 
            lblPlacas.AutoSize = true;
            lblPlacas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlacas.Location = new Point(114, 304);
            lblPlacas.Name = "lblPlacas";
            lblPlacas.Size = new Size(56, 21);
            lblPlacas.TabIndex = 150;
            lblPlacas.Text = "Placas:";
            // 
            // txbPlacas
            // 
            txbPlacas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbPlacas.Location = new Point(176, 301);
            txbPlacas.MaxLength = 15;
            txbPlacas.Name = "txbPlacas";
            txbPlacas.Size = new Size(233, 29);
            txbPlacas.TabIndex = 13;
            // 
            // lblChofer
            // 
            lblChofer.AutoSize = true;
            lblChofer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblChofer.Location = new Point(110, 234);
            lblChofer.Name = "lblChofer";
            lblChofer.Size = new Size(60, 21);
            lblChofer.TabIndex = 152;
            lblChofer.Text = "Chofer:";
            // 
            // txbChofer
            // 
            txbChofer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbChofer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbChofer.Location = new Point(176, 231);
            txbChofer.MaxLength = 50;
            txbChofer.Name = "txbChofer";
            txbChofer.Size = new Size(345, 29);
            txbChofer.TabIndex = 11;
            // 
            // txbUnidad
            // 
            txbUnidad.Enabled = false;
            txbUnidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbUnidad.Location = new Point(331, 421);
            txbUnidad.Name = "txbUnidad";
            txbUnidad.Size = new Size(137, 29);
            txbUnidad.TabIndex = 153;
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLote.Location = new Point(23, 81);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(43, 21);
            lblLote.TabIndex = 155;
            lblLote.Text = "Lote:";
            // 
            // cboLote
            // 
            cboLote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboLote.FormattingEnabled = true;
            cboLote.ItemHeight = 21;
            cboLote.Items.AddRange(new object[] { "DON LUIS", "SAN ANDRES" });
            cboLote.Location = new Point(127, 78);
            cboLote.Name = "cboLote";
            cboLote.Size = new Size(566, 29);
            cboLote.TabIndex = 1;
            cboLote.TextChanged += cboLote_TextChanged;
            cboLote.MouseClick += cboLote_MouseClick;
            // 
            // btnTodoLote
            // 
            btnTodoLote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTodoLote.Location = new Point(759, 78);
            btnTodoLote.Name = "btnTodoLote";
            btnTodoLote.Size = new Size(54, 29);
            btnTodoLote.TabIndex = 3;
            btnTodoLote.Text = "Todo";
            btnTodoLote.UseVisualStyleBackColor = true;
            btnTodoLote.Click += btnTodoLote_Click;
            // 
            // btnBuscarLote
            // 
            btnBuscarLote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarLote.Location = new Point(699, 78);
            btnBuscarLote.Name = "btnBuscarLote";
            btnBuscarLote.Size = new Size(54, 29);
            btnBuscarLote.TabIndex = 2;
            btnBuscarLote.Text = "Buscar";
            btnBuscarLote.UseVisualStyleBackColor = true;
            btnBuscarLote.Click += btnBuscarLote_Click;
            // 
            // txbIdLote
            // 
            txbIdLote.Enabled = false;
            txbIdLote.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdLote.Location = new Point(72, 78);
            txbIdLote.Name = "txbIdLote";
            txbIdLote.Size = new Size(49, 29);
            txbIdLote.TabIndex = 190;
            txbIdLote.TextAlign = HorizontalAlignment.Center;
            // 
            // btnModificarSel
            // 
            btnModificarSel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificarSel.Location = new Point(531, 524);
            btnModificarSel.Name = "btnModificarSel";
            btnModificarSel.Size = new Size(139, 27);
            btnModificarSel.TabIndex = 22;
            btnModificarSel.Text = "Modificar seleccionado";
            btnModificarSel.UseVisualStyleBackColor = true;
            btnModificarSel.Click += btnModificarSel_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(671, 699);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(69, 27);
            btnGuardar.TabIndex = 25;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(746, 699);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(69, 27);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnTodoLineaTran
            // 
            btnTodoLineaTran.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTodoLineaTran.Location = new Point(760, 196);
            btnTodoLineaTran.Name = "btnTodoLineaTran";
            btnTodoLineaTran.Size = new Size(54, 29);
            btnTodoLineaTran.TabIndex = 10;
            btnTodoLineaTran.Text = "Todo";
            btnTodoLineaTran.UseVisualStyleBackColor = true;
            btnTodoLineaTran.Click += btnTodoLineaTran_Click;
            // 
            // btnBuscarLineaTran
            // 
            btnBuscarLineaTran.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarLineaTran.Location = new Point(700, 196);
            btnBuscarLineaTran.Name = "btnBuscarLineaTran";
            btnBuscarLineaTran.Size = new Size(54, 29);
            btnBuscarLineaTran.TabIndex = 9;
            btnBuscarLineaTran.Text = "Buscar";
            btnBuscarLineaTran.UseVisualStyleBackColor = true;
            btnBuscarLineaTran.Click += btnBuscarLineaTran_Click;
            // 
            // cboLineaTran
            // 
            cboLineaTran.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboLineaTran.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboLineaTran.FormattingEnabled = true;
            cboLineaTran.ItemHeight = 21;
            cboLineaTran.Location = new Point(176, 196);
            cboLineaTran.Name = "cboLineaTran";
            cboLineaTran.Size = new Size(517, 29);
            cboLineaTran.TabIndex = 8;
            // 
            // lblLineaTran
            // 
            lblLineaTran.AutoSize = true;
            lblLineaTran.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLineaTran.Location = new Point(23, 204);
            lblLineaTran.Name = "lblLineaTran";
            lblLineaTran.Size = new Size(147, 21);
            lblLineaTran.TabIndex = 197;
            lblLineaTran.Text = "Línea de transporte:";
            // 
            // txbItem
            // 
            txbItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txbItem.Enabled = false;
            txbItem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbItem.Location = new Point(517, 43);
            txbItem.Name = "txbItem";
            txbItem.Size = new Size(40, 29);
            txbItem.TabIndex = 198;
            txbItem.TextAlign = HorizontalAlignment.Center;
            // 
            // lblItem
            // 
            lblItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblItem.AutoSize = true;
            lblItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblItem.Location = new Point(467, 46);
            lblItem.Name = "lblItem";
            lblItem.Size = new Size(44, 21);
            lblItem.TabIndex = 199;
            lblItem.Text = "item:";
            // 
            // txbFolio
            // 
            txbFolio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbFolio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbFolio.Location = new Point(187, 114);
            txbFolio.MaxLength = 20;
            txbFolio.Name = "txbFolio";
            txbFolio.Size = new Size(296, 29);
            txbFolio.TabIndex = 4;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFolio.Location = new Point(23, 117);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(158, 21);
            lblFolio.TabIndex = 201;
            lblFolio.Text = "Folio documentación:";
            // 
            // txbObservaciones
            // 
            txbObservaciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbObservaciones.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbObservaciones.Location = new Point(11, 489);
            txbObservaciones.MaxLength = 200;
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.Size = new Size(804, 29);
            txbObservaciones.TabIndex = 21;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblObservaciones.Location = new Point(12, 465);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(115, 21);
            lblObservaciones.TabIndex = 203;
            lblObservaciones.Text = "Observaciones:";
            // 
            // lblObliTipoMaterial
            // 
            lblObliTipoMaterial.AutoSize = true;
            lblObliTipoMaterial.ForeColor = Color.Crimson;
            lblObliTipoMaterial.Location = new Point(133, 386);
            lblObliTipoMaterial.Name = "lblObliTipoMaterial";
            lblObliTipoMaterial.Size = new Size(12, 15);
            lblObliTipoMaterial.TabIndex = 204;
            lblObliTipoMaterial.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(133, 421);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 205;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(72, 43);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 206;
            label2.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(178, 114);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 207;
            label3.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(507, 9);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 208;
            label4.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(507, 43);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 209;
            label5.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(689, 12);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 210;
            label6.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Crimson;
            label7.Location = new Point(466, 421);
            label7.Name = "label7";
            label7.Size = new Size(12, 15);
            label7.TabIndex = 211;
            label7.Text = "*";
            // 
            // FrmRegistroMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 738);
            Controls.Add(dtpFecha);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblObservaciones);
            Controls.Add(txbObservaciones);
            Controls.Add(lblFolio);
            Controls.Add(txbFolio);
            Controls.Add(lblItem);
            Controls.Add(txbItem);
            Controls.Add(btnTodoLineaTran);
            Controls.Add(btnBuscarLineaTran);
            Controls.Add(cboLineaTran);
            Controls.Add(lblLineaTran);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificarSel);
            Controls.Add(btnTodoLote);
            Controls.Add(btnBuscarLote);
            Controls.Add(txbIdLote);
            Controls.Add(lblLote);
            Controls.Add(cboLote);
            Controls.Add(txbUnidad);
            Controls.Add(lblChofer);
            Controls.Add(txbChofer);
            Controls.Add(lblPlacas);
            Controls.Add(txbPlacas);
            Controls.Add(lblCaja);
            Controls.Add(txbCaja);
            Controls.Add(btnEliminarSel);
            Controls.Add(lblCampo);
            Controls.Add(cboCampo);
            Controls.Add(lblId);
            Controls.Add(txbId);
            Controls.Add(btnAñadir);
            Controls.Add(dgvMateriales);
            Controls.Add(lblCantidad);
            Controls.Add(txbCantidad);
            Controls.Add(btnTodoMaterial);
            Controls.Add(btnBuscarMaterial);
            Controls.Add(txbIdMaterial);
            Controls.Add(cboMaterial);
            Controls.Add(lblMaterial);
            Controls.Add(btnBuscarTipoMat);
            Controls.Add(txbIdTipoMat);
            Controls.Add(cboTipoMat);
            Controls.Add(lblTipoMat);
            Controls.Add(btnTodoProveedor);
            Controls.Add(btnBuscarProveedor);
            Controls.Add(cboProveedor);
            Controls.Add(lblProveedor);
            Controls.Add(lblFecha);
            Controls.Add(lblTitulo);
            Controls.Add(lblObliTipoMaterial);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label7);
            MinimumSize = new Size(843, 777);
            Name = "FrmRegistroMaterial";
            Text = "FrmRegistroMaterial";
            Load += FrmRegistroMaterial_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMateriales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitulo;
        private Label lblFecha;
        private Button btnTodoProveedor;
        private Button btnBuscarProveedor;
        private ComboBox cboProveedor;
        private Label lblProveedor;
        private Button btnBuscarTipoMat;
        public TextBox txbIdTipoMat;
        private Label lblTipoMat;
        private Button btnTodoMaterial;
        private Button btnBuscarMaterial;
        public TextBox txbIdMaterial;
        private ComboBox cboMaterial;
        private Label lblMaterial;
        public TextBox txbCantidad;
        private Label lblCantidad;
        private Label lblRegistrosEntre;
        private Label lblY;
        private Button btnAñadir;
        private Button btnBuscar;
        private DateTimePicker dtpFechaBusqueda2;
        private DateTimePicker dtpFechaBusqueda1;
        private DateTimePicker dtpFecha;
        public TextBox txbId;
        private Label lblId;
        private Label lblCampo;
        private ComboBox cboCampo;
        private Button btnEliminarSel;
        public TextBox txbCaja;
        private Label lblCaja;
        private Label lblPlacas;
        public TextBox txbPlacas;
        private Label lblChofer;
        public TextBox txbChofer;
        public TextBox txbUnidad;
        private Label lblLote;
        private ComboBox cboLote;
        private Button btnTodoLote;
        private Button btnBuscarLote;
        public TextBox txbIdLote;
        private Button btnModificarSel;
        private Button btnGuardar;
        private Button btnCancelar;
        public ComboBox cboTipoMat;
        private Button btnTodoLineaTran;
        private Button btnBuscarLineaTran;
        private ComboBox cboLineaTran;
        private Label lblLineaTran;
        public TextBox txbItem;
        private Label lblItem;
        public TextBox txbFolio;
        private Label lblFolio;
        public TextBox txbObservaciones;
        private Label lblObservaciones;
        public DataGridView dgvCatalogo;
        public DataGridView dgvMateriales;
        private DataGridViewTextBoxColumn Código;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn idMaterial;
        private DataGridViewTextBoxColumn NombrMaterial;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Unidad;
        private DataGridViewTextBoxColumn Ubicacion;
        private DataGridViewTextBoxColumn idLote;
        private DataGridViewTextBoxColumn NombreLote;
        private DataGridViewTextBoxColumn Folio;
        private DataGridViewTextBoxColumn FechaRegistro;
        private DataGridViewTextBoxColumn Proveedor;
        private DataGridViewTextBoxColumn Linea;
        private DataGridViewTextBoxColumn Chofer;
        private DataGridViewTextBoxColumn Caja;
        private DataGridViewTextBoxColumn Placas;
        private DataGridViewTextBoxColumn Observaciones;
        private Label lblObliTipoMaterial;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
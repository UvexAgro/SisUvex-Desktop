
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto
{
    partial class FrmManifiestoAñadir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManifiestoAñadir));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblLinea = new Label();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            btnTodoLinea = new Button();
            btnBuscarLinea = new Button();
            txbIdLinea = new TextBox();
            cboLinea = new ComboBox();
            lblObliId = new Label();
            cboActivo = new ComboBox();
            Mercado = new Label();
            dtpFecha = new DateTimePicker();
            lblObservaciones = new Label();
            txbObservaciones = new RichTextBox();
            cboManifiestoVirtual = new ComboBox();
            btnBorrarPallet = new Button();
            btnAñadirPallet = new Button();
            label15 = new Label();
            txbIdPallet = new TextBox();
            txbSello3 = new TextBox();
            txbSello2 = new TextBox();
            label14 = new Label();
            txbSello1 = new TextBox();
            cboGrados = new ComboBox();
            label13 = new Label();
            txbGrados = new TextBox();
            label12 = new Label();
            txbPosicion = new TextBox();
            label11 = new Label();
            txbChismografo = new TextBox();
            label10 = new Label();
            cboSegundoMedio = new ComboBox();
            label9 = new Label();
            cboMedioTransporte = new ComboBox();
            btnTodoCaja = new Button();
            btnBuscarCaja = new Button();
            btnTodoTroque = new Button();
            btnBuscarTroque = new Button();
            btnTodoChofer = new Button();
            btnBuscarChofer = new Button();
            txbIdCaja = new TextBox();
            cboCaja = new ComboBox();
            label5 = new Label();
            txbIdTroque = new TextBox();
            cboTroque = new ComboBox();
            label6 = new Label();
            txbIdChofer = new TextBox();
            cboChofer = new ComboBox();
            label8 = new Label();
            label4 = new Label();
            txbOrden = new TextBox();
            lblVisa = new Label();
            txbBooking = new TextBox();
            spnHoraSalida = new MaskedTextBox();
            btnTodoDistribuidor = new Button();
            btnBuscarDistribuidor = new Button();
            txbIdDistribuidor = new TextBox();
            cboDistribuidor = new ComboBox();
            label3 = new Label();
            btnTodoConsignatario = new Button();
            btnBuscarConsignatario = new Button();
            txbIdConsignatario = new TextBox();
            cboConsignatario = new ComboBox();
            label16 = new Label();
            btnTodoCiudadDestino = new Button();
            btnBuscarCiudadDestino = new Button();
            btnTodoCiudadCruce = new Button();
            btnBuscarCiudadCruce = new Button();
            btnTodoProductor = new Button();
            btnBuscarProductor = new Button();
            btnTodoAgenciaMX = new Button();
            btnBuscarAgenciaMX = new Button();
            btnTodoAgenciaUS = new Button();
            btnBuscarAgenciaUS = new Button();
            txbIdCiudadDestino = new TextBox();
            cboCiudadDestino = new ComboBox();
            lblCiudadDestino = new Label();
            txbIdCiudadCruce = new TextBox();
            cboCiudadCruce = new ComboBox();
            lblCiudadCruce = new Label();
            txbIdProductor = new TextBox();
            cboProductor = new ComboBox();
            lblProductor = new Label();
            txbIdAgenciaUS = new TextBox();
            cboAgenciaUS = new ComboBox();
            lblAgenciaUS = new Label();
            txbIdAgenciaMX = new TextBox();
            cboAgenciaMX = new ComboBox();
            lblAcenciaMX = new Label();
            label17 = new Label();
            label18 = new Label();
            cboTipoEmbarque = new ComboBox();
            label7 = new Label();
            txbEmbarcador = new TextBox();
            label19 = new Label();
            txbOperador = new TextBox();
            chkRechazado = new CheckBox();
            dgvListado = new DataGridView();
            lblPosicionPal = new Label();
            txbPosicionPal = new TextBox();
            printManifestBtn = new Button();
            txbDieselLiters = new TextBox();
            lblDieselInvoice = new Label();
            txbDieselInvoice = new TextBox();
            lblDieselLiters = new Label();
            chkBoxPackingList = new CheckBox();
            label1 = new Label();
            txbFitosanitario = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(10, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(227, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir Manifiesto";
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Microsoft Sans Serif", 9F);
            lblLinea.Location = new Point(10, 317);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(116, 15);
            lblLinea.TabIndex = 1;
            lblLinea.Text = "Línea de transporte:";
            lblLinea.TextAlign = ContentAlignment.TopRight;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Microsoft Sans Serif", 9F);
            txbId.Location = new Point(53, 42);
            txbId.Name = "txbId";
            txbId.Size = new Size(61, 21);
            txbId.TabIndex = 5;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Microsoft Sans Serif", 9F);
            lblId.Location = new Point(27, 44);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelar.Location = new Point(684, 652);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(64, 25);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAceptar.Location = new Point(614, 652);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(64, 25);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnTodoLinea
            // 
            btnTodoLinea.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoLinea.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoLinea.Enabled = false;
            btnTodoLinea.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoLinea.Location = new Point(433, 314);
            btnTodoLinea.Name = "btnTodoLinea";
            btnTodoLinea.Size = new Size(23, 23);
            btnTodoLinea.TabIndex = 32;
            btnTodoLinea.UseVisualStyleBackColor = true;
            btnTodoLinea.Click += btnTodoLinea_Click;
            // 
            // btnBuscarLinea
            // 
            btnBuscarLinea.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarLinea.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarLinea.Enabled = false;
            btnBuscarLinea.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarLinea.Location = new Point(409, 314);
            btnBuscarLinea.Name = "btnBuscarLinea";
            btnBuscarLinea.Size = new Size(23, 23);
            btnBuscarLinea.TabIndex = 31;
            btnBuscarLinea.UseVisualStyleBackColor = true;
            btnBuscarLinea.Click += btnBuscarLinea_Click;
            // 
            // txbIdLinea
            // 
            txbIdLinea.Enabled = false;
            txbIdLinea.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdLinea.Location = new Point(129, 315);
            txbIdLinea.Name = "txbIdLinea";
            txbIdLinea.Size = new Size(37, 21);
            txbIdLinea.TabIndex = 34;
            txbIdLinea.TextAlign = HorizontalAlignment.Center;
            txbIdLinea.TextChanged += txbIdLinea_TextChanged;
            // 
            // cboLinea
            // 
            cboLinea.Font = new Font("Microsoft Sans Serif", 9F);
            cboLinea.FormattingEnabled = true;
            cboLinea.ItemHeight = 15;
            cboLinea.Location = new Point(171, 314);
            cboLinea.Name = "cboLinea";
            cboLinea.Size = new Size(235, 23);
            cboLinea.TabIndex = 30;
            cboLinea.TextChanged += cboLinea_TextChanged;
            cboLinea.MouseClick += cboLinea_MouseClick;
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.Font = new Font("Microsoft Sans Serif", 9F);
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(41, 42);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 13;
            lblObliId.Text = "*";
            // 
            // cboActivo
            // 
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivo.Font = new Font("Microsoft Sans Serif", 9F);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(335, 13);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(37, 23);
            cboActivo.TabIndex = 36;
            // 
            // Mercado
            // 
            Mercado.AutoSize = true;
            Mercado.Font = new Font("Microsoft Sans Serif", 9F);
            Mercado.Location = new Point(294, 18);
            Mercado.Name = "Mercado";
            Mercado.Size = new Size(41, 15);
            Mercado.TabIndex = 230;
            Mercado.Text = "Activo:";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Microsoft Sans Serif", 9F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(342, 43);
            dtpFecha.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpFecha.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(75, 21);
            dtpFecha.TabIndex = 229;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Microsoft Sans Serif", 9F);
            lblObservaciones.Location = new Point(35, 512);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(91, 15);
            lblObservaciones.TabIndex = 228;
            lblObservaciones.Text = "Observaciones:";
            lblObservaciones.TextAlign = ContentAlignment.TopRight;
            // 
            // txbObservaciones
            // 
            txbObservaciones.Font = new Font("Microsoft Sans Serif", 9F);
            txbObservaciones.Location = new Point(129, 512);
            txbObservaciones.MaxLength = 200;
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.Size = new Size(314, 111);
            txbObservaciones.TabIndex = 227;
            txbObservaciones.Text = "";
            // 
            // cboManifiestoVirtual
            // 
            cboManifiestoVirtual.DropDownStyle = ComboBoxStyle.DropDownList;
            cboManifiestoVirtual.Enabled = false;
            cboManifiestoVirtual.Font = new Font("Microsoft Sans Serif", 9F);
            cboManifiestoVirtual.FormattingEnabled = true;
            cboManifiestoVirtual.Items.AddRange(new object[] { "No", "Sí" });
            cboManifiestoVirtual.Location = new Point(423, 44);
            cboManifiestoVirtual.Name = "cboManifiestoVirtual";
            cboManifiestoVirtual.Size = new Size(42, 23);
            cboManifiestoVirtual.TabIndex = 226;
            // 
            // btnBorrarPallet
            // 
            btnBorrarPallet.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnBorrarPallet.Image = Properties.Resources.basuraIcon16;
            btnBorrarPallet.ImageAlign = ContentAlignment.MiddleRight;
            btnBorrarPallet.Location = new Point(606, 45);
            btnBorrarPallet.Name = "btnBorrarPallet";
            btnBorrarPallet.Size = new Size(23, 23);
            btnBorrarPallet.TabIndex = 225;
            btnBorrarPallet.TextAlign = ContentAlignment.TopCenter;
            btnBorrarPallet.UseVisualStyleBackColor = true;
            btnBorrarPallet.Click += btnBorrarPallet_Click;
            // 
            // btnAñadirPallet
            // 
            btnAñadirPallet.Font = new Font("Microsoft Sans Serif", 9F);
            btnAñadirPallet.Image = Properties.Resources.mas_16;
            btnAñadirPallet.ImageAlign = ContentAlignment.BottomRight;
            btnAñadirPallet.Location = new Point(574, 45);
            btnAñadirPallet.Name = "btnAñadirPallet";
            btnAñadirPallet.Size = new Size(23, 23);
            btnAñadirPallet.TabIndex = 224;
            btnAñadirPallet.TextAlign = ContentAlignment.TopRight;
            btnAñadirPallet.UseVisualStyleBackColor = true;
            btnAñadirPallet.Click += btnAñadirPallet_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 8.25F);
            label15.Location = new Point(494, 33);
            label15.Name = "label15";
            label15.Size = new Size(38, 13);
            label15.TabIndex = 223;
            label15.Text = "N. pal:";
            // 
            // txbIdPallet
            // 
            txbIdPallet.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdPallet.Location = new Point(496, 46);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(47, 21);
            txbIdPallet.TabIndex = 222;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // txbSello3
            // 
            txbSello3.Font = new Font("Microsoft Sans Serif", 9F);
            txbSello3.Location = new Point(341, 489);
            txbSello3.MaxLength = 10;
            txbSello3.Name = "txbSello3";
            txbSello3.Size = new Size(102, 21);
            txbSello3.TabIndex = 220;
            txbSello3.TextAlign = HorizontalAlignment.Center;
            // 
            // txbSello2
            // 
            txbSello2.Font = new Font("Microsoft Sans Serif", 9F);
            txbSello2.Location = new Point(236, 489);
            txbSello2.MaxLength = 10;
            txbSello2.Name = "txbSello2";
            txbSello2.Size = new Size(102, 21);
            txbSello2.TabIndex = 219;
            txbSello2.TextAlign = HorizontalAlignment.Center;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 9F);
            label14.Location = new Point(80, 492);
            label14.Name = "label14";
            label14.Size = new Size(44, 15);
            label14.TabIndex = 218;
            label14.Text = "Sellos:";
            label14.TextAlign = ContentAlignment.TopRight;
            // 
            // txbSello1
            // 
            txbSello1.Font = new Font("Microsoft Sans Serif", 9F);
            txbSello1.Location = new Point(129, 489);
            txbSello1.MaxLength = 10;
            txbSello1.Name = "txbSello1";
            txbSello1.Size = new Size(102, 21);
            txbSello1.TabIndex = 217;
            txbSello1.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrados
            // 
            cboGrados.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrados.Font = new Font("Microsoft Sans Serif", 9F);
            cboGrados.FormattingEnabled = true;
            cboGrados.Items.AddRange(new object[] { "F", "C", "K" });
            cboGrados.Location = new Point(406, 465);
            cboGrados.Name = "cboGrados";
            cboGrados.Size = new Size(33, 23);
            cboGrados.TabIndex = 216;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9F);
            label13.Location = new Point(323, 468);
            label13.Name = "label13";
            label13.Size = new Size(50, 15);
            label13.TabIndex = 215;
            label13.Text = "Grados:";
            // 
            // txbGrados
            // 
            txbGrados.Font = new Font("Microsoft Sans Serif", 9F);
            txbGrados.Location = new Point(372, 465);
            txbGrados.MaxLength = 3;
            txbGrados.Name = "txbGrados";
            txbGrados.Size = new Size(28, 21);
            txbGrados.TabIndex = 214;
            txbGrados.TextAlign = HorizontalAlignment.Center;
            txbGrados.KeyPress += txbGrados_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F);
            label12.Location = new Point(234, 468);
            label12.Name = "label12";
            label12.Size = new Size(57, 15);
            label12.TabIndex = 213;
            label12.Text = "Posición:";
            // 
            // txbPosicion
            // 
            txbPosicion.Font = new Font("Microsoft Sans Serif", 9F);
            txbPosicion.Location = new Point(289, 467);
            txbPosicion.MaxLength = 2;
            txbPosicion.Name = "txbPosicion";
            txbPosicion.Size = new Size(32, 21);
            txbPosicion.TabIndex = 212;
            txbPosicion.TextAlign = HorizontalAlignment.Center;
            txbPosicion.KeyPress += txbPosicion_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9F);
            label11.Location = new Point(45, 468);
            label11.Name = "label11";
            label11.Size = new Size(80, 15);
            label11.TabIndex = 211;
            label11.Text = "Chismógrafo:";
            label11.TextAlign = ContentAlignment.TopRight;
            // 
            // txbChismografo
            // 
            txbChismografo.Font = new Font("Microsoft Sans Serif", 9F);
            txbChismografo.Location = new Point(129, 465);
            txbChismografo.MaxLength = 20;
            txbChismografo.Name = "txbChismografo";
            txbChismografo.Size = new Size(102, 21);
            txbChismografo.TabIndex = 210;
            txbChismografo.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F);
            label10.Location = new Point(26, 443);
            label10.Name = "label10";
            label10.Size = new Size(98, 15);
            label10.TabIndex = 209;
            label10.Text = "Segundo medio:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // cboSegundoMedio
            // 
            cboSegundoMedio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSegundoMedio.Font = new Font("Microsoft Sans Serif", 9F);
            cboSegundoMedio.FormattingEnabled = true;
            cboSegundoMedio.Items.AddRange(new object[] { "", "TRAILER", "CAJA REFRIGERADA", "CONTENEDOR", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboSegundoMedio.Location = new Point(129, 440);
            cboSegundoMedio.Name = "cboSegundoMedio";
            cboSegundoMedio.Size = new Size(211, 23);
            cboSegundoMedio.TabIndex = 208;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(6, 418);
            label9.Name = "label9";
            label9.Size = new Size(120, 15);
            label9.TabIndex = 207;
            label9.Text = "Medio de transporte:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // cboMedioTransporte
            // 
            cboMedioTransporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMedioTransporte.Font = new Font("Microsoft Sans Serif", 9F);
            cboMedioTransporte.FormattingEnabled = true;
            cboMedioTransporte.Items.AddRange(new object[] { "", "TRAILER", "CONTENEDOR", "CAJA REFRIGERADA", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboMedioTransporte.Location = new Point(129, 415);
            cboMedioTransporte.Name = "cboMedioTransporte";
            cboMedioTransporte.Size = new Size(211, 23);
            cboMedioTransporte.TabIndex = 206;
            // 
            // btnTodoCaja
            // 
            btnTodoCaja.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoCaja.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoCaja.Enabled = false;
            btnTodoCaja.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoCaja.Location = new Point(433, 390);
            btnTodoCaja.Name = "btnTodoCaja";
            btnTodoCaja.Size = new Size(23, 23);
            btnTodoCaja.TabIndex = 197;
            btnTodoCaja.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCaja
            // 
            btnBuscarCaja.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarCaja.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarCaja.Enabled = false;
            btnBuscarCaja.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarCaja.Location = new Point(409, 390);
            btnBuscarCaja.Name = "btnBuscarCaja";
            btnBuscarCaja.Size = new Size(23, 23);
            btnBuscarCaja.TabIndex = 196;
            btnBuscarCaja.UseVisualStyleBackColor = true;
            // 
            // btnTodoTroque
            // 
            btnTodoTroque.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoTroque.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoTroque.Enabled = false;
            btnTodoTroque.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoTroque.Location = new Point(433, 365);
            btnTodoTroque.Name = "btnTodoTroque";
            btnTodoTroque.Size = new Size(23, 23);
            btnTodoTroque.TabIndex = 195;
            btnTodoTroque.UseVisualStyleBackColor = true;
            // 
            // btnBuscarTroque
            // 
            btnBuscarTroque.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarTroque.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarTroque.Enabled = false;
            btnBuscarTroque.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarTroque.Location = new Point(409, 365);
            btnBuscarTroque.Name = "btnBuscarTroque";
            btnBuscarTroque.Size = new Size(23, 23);
            btnBuscarTroque.TabIndex = 194;
            btnBuscarTroque.UseVisualStyleBackColor = true;
            // 
            // btnTodoChofer
            // 
            btnTodoChofer.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoChofer.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoChofer.Enabled = false;
            btnTodoChofer.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoChofer.Location = new Point(433, 339);
            btnTodoChofer.Name = "btnTodoChofer";
            btnTodoChofer.Size = new Size(23, 23);
            btnTodoChofer.TabIndex = 193;
            btnTodoChofer.UseVisualStyleBackColor = true;
            // 
            // btnBuscarChofer
            // 
            btnBuscarChofer.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarChofer.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarChofer.Enabled = false;
            btnBuscarChofer.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarChofer.Location = new Point(409, 339);
            btnBuscarChofer.Name = "btnBuscarChofer";
            btnBuscarChofer.Size = new Size(23, 23);
            btnBuscarChofer.TabIndex = 191;
            btnBuscarChofer.UseVisualStyleBackColor = true;
            // 
            // txbIdCaja
            // 
            txbIdCaja.Enabled = false;
            txbIdCaja.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCaja.Location = new Point(129, 390);
            txbIdCaja.Name = "txbIdCaja";
            txbIdCaja.Size = new Size(37, 21);
            txbIdCaja.TabIndex = 205;
            txbIdCaja.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCaja
            // 
            cboCaja.Font = new Font("Microsoft Sans Serif", 9F);
            cboCaja.FormattingEnabled = true;
            cboCaja.ItemHeight = 15;
            cboCaja.Location = new Point(171, 390);
            cboCaja.Name = "cboCaja";
            cboCaja.Size = new Size(235, 23);
            cboCaja.TabIndex = 189;
            cboCaja.TextChanged += cboCaja_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F);
            label5.Location = new Point(88, 393);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 204;
            label5.Text = "Caja:";
            // 
            // txbIdTroque
            // 
            txbIdTroque.Enabled = false;
            txbIdTroque.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTroque.Location = new Point(129, 365);
            txbIdTroque.Name = "txbIdTroque";
            txbIdTroque.Size = new Size(37, 21);
            txbIdTroque.TabIndex = 203;
            txbIdTroque.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTroque
            // 
            cboTroque.Font = new Font("Microsoft Sans Serif", 9F);
            cboTroque.FormattingEnabled = true;
            cboTroque.ItemHeight = 15;
            cboTroque.Location = new Point(171, 365);
            cboTroque.Name = "cboTroque";
            cboTroque.Size = new Size(235, 23);
            cboTroque.TabIndex = 188;
            cboTroque.TextChanged += cboTroque_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F);
            label6.Location = new Point(76, 368);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 202;
            label6.Text = "Troque:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdChofer
            // 
            txbIdChofer.Enabled = false;
            txbIdChofer.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdChofer.Location = new Point(129, 339);
            txbIdChofer.Name = "txbIdChofer";
            txbIdChofer.Size = new Size(37, 21);
            txbIdChofer.TabIndex = 199;
            txbIdChofer.TextAlign = HorizontalAlignment.Center;
            // 
            // cboChofer
            // 
            cboChofer.Font = new Font("Microsoft Sans Serif", 9F);
            cboChofer.FormattingEnabled = true;
            cboChofer.ItemHeight = 15;
            cboChofer.Location = new Point(171, 339);
            cboChofer.Name = "cboChofer";
            cboChofer.Size = new Size(235, 23);
            cboChofer.TabIndex = 187;
            cboChofer.TextChanged += cboChofer_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F);
            label8.Location = new Point(78, 342);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 198;
            label8.Text = "Chofer:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(20, 270);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 185;
            label4.Text = "Orden de compra:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txbOrden
            // 
            txbOrden.Font = new Font("Microsoft Sans Serif", 9F);
            txbOrden.Location = new Point(129, 267);
            txbOrden.MaxLength = 30;
            txbOrden.Name = "txbOrden";
            txbOrden.Size = new Size(211, 21);
            txbOrden.TabIndex = 184;
            // 
            // lblVisa
            // 
            lblVisa.AutoSize = true;
            lblVisa.Font = new Font("Microsoft Sans Serif", 9F);
            lblVisa.Location = new Point(68, 247);
            lblVisa.Name = "lblVisa";
            lblVisa.Size = new Size(55, 15);
            lblVisa.TabIndex = 183;
            lblVisa.Text = "Booking:";
            lblVisa.TextAlign = ContentAlignment.TopRight;
            // 
            // txbBooking
            // 
            txbBooking.Font = new Font("Microsoft Sans Serif", 9F);
            txbBooking.Location = new Point(129, 244);
            txbBooking.MaxLength = 30;
            txbBooking.Name = "txbBooking";
            txbBooking.Size = new Size(211, 21);
            txbBooking.TabIndex = 182;
            // 
            // spnHoraSalida
            // 
            spnHoraSalida.Font = new Font("Microsoft Sans Serif", 9F);
            spnHoraSalida.Location = new Point(228, 44);
            spnHoraSalida.Mask = "00:00";
            spnHoraSalida.Name = "spnHoraSalida";
            spnHoraSalida.Size = new Size(38, 21);
            spnHoraSalida.TabIndex = 181;
            spnHoraSalida.ValidatingType = typeof(DateTime);
            // 
            // btnTodoDistribuidor
            // 
            btnTodoDistribuidor.BackgroundImage = (Image)resources.GetObject("btnTodoDistribuidor.BackgroundImage");
            btnTodoDistribuidor.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoDistribuidor.Enabled = false;
            btnTodoDistribuidor.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoDistribuidor.Location = new Point(433, 68);
            btnTodoDistribuidor.Name = "btnTodoDistribuidor";
            btnTodoDistribuidor.Size = new Size(23, 23);
            btnTodoDistribuidor.TabIndex = 178;
            btnTodoDistribuidor.UseVisualStyleBackColor = true;
            // 
            // btnBuscarDistribuidor
            // 
            btnBuscarDistribuidor.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarDistribuidor.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarDistribuidor.Enabled = false;
            btnBuscarDistribuidor.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarDistribuidor.Location = new Point(409, 68);
            btnBuscarDistribuidor.Name = "btnBuscarDistribuidor";
            btnBuscarDistribuidor.Size = new Size(23, 23);
            btnBuscarDistribuidor.TabIndex = 177;
            btnBuscarDistribuidor.UseVisualStyleBackColor = true;
            // 
            // txbIdDistribuidor
            // 
            txbIdDistribuidor.Enabled = false;
            txbIdDistribuidor.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDistribuidor.Location = new Point(129, 68);
            txbIdDistribuidor.Name = "txbIdDistribuidor";
            txbIdDistribuidor.Size = new Size(37, 21);
            txbIdDistribuidor.TabIndex = 180;
            txbIdDistribuidor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.Font = new Font("Microsoft Sans Serif", 9F);
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.ItemHeight = 15;
            cboDistribuidor.Location = new Point(171, 68);
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(235, 23);
            cboDistribuidor.TabIndex = 176;
            cboDistribuidor.TextChanged += cboDistribuidor_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.Location = new Point(51, 70);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 179;
            label3.Text = "Distribuidor:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // btnTodoConsignatario
            // 
            btnTodoConsignatario.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoConsignatario.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoConsignatario.Enabled = false;
            btnTodoConsignatario.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoConsignatario.Location = new Point(433, 93);
            btnTodoConsignatario.Name = "btnTodoConsignatario";
            btnTodoConsignatario.Size = new Size(23, 23);
            btnTodoConsignatario.TabIndex = 173;
            btnTodoConsignatario.UseVisualStyleBackColor = true;
            // 
            // btnBuscarConsignatario
            // 
            btnBuscarConsignatario.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarConsignatario.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarConsignatario.Enabled = false;
            btnBuscarConsignatario.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarConsignatario.Location = new Point(409, 93);
            btnBuscarConsignatario.Name = "btnBuscarConsignatario";
            btnBuscarConsignatario.Size = new Size(23, 23);
            btnBuscarConsignatario.TabIndex = 172;
            btnBuscarConsignatario.UseVisualStyleBackColor = true;
            // 
            // txbIdConsignatario
            // 
            txbIdConsignatario.Enabled = false;
            txbIdConsignatario.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdConsignatario.Location = new Point(129, 93);
            txbIdConsignatario.Name = "txbIdConsignatario";
            txbIdConsignatario.Size = new Size(37, 21);
            txbIdConsignatario.TabIndex = 175;
            txbIdConsignatario.TextAlign = HorizontalAlignment.Center;
            // 
            // cboConsignatario
            // 
            cboConsignatario.Font = new Font("Microsoft Sans Serif", 9F);
            cboConsignatario.FormattingEnabled = true;
            cboConsignatario.ItemHeight = 15;
            cboConsignatario.Location = new Point(171, 93);
            cboConsignatario.Name = "cboConsignatario";
            cboConsignatario.Size = new Size(235, 23);
            cboConsignatario.TabIndex = 171;
            cboConsignatario.TextChanged += cboConsignatario_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 9F);
            label16.Location = new Point(39, 95);
            label16.Name = "label16";
            label16.Size = new Size(86, 15);
            label16.TabIndex = 174;
            label16.Text = "Consignatario:";
            label16.TextAlign = ContentAlignment.TopRight;
            // 
            // btnTodoCiudadDestino
            // 
            btnTodoCiudadDestino.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoCiudadDestino.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoCiudadDestino.Enabled = false;
            btnTodoCiudadDestino.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoCiudadDestino.Location = new Point(433, 218);
            btnTodoCiudadDestino.Name = "btnTodoCiudadDestino";
            btnTodoCiudadDestino.Size = new Size(23, 23);
            btnTodoCiudadDestino.TabIndex = 160;
            btnTodoCiudadDestino.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCiudadDestino
            // 
            btnBuscarCiudadDestino.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarCiudadDestino.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarCiudadDestino.Enabled = false;
            btnBuscarCiudadDestino.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarCiudadDestino.Location = new Point(409, 218);
            btnBuscarCiudadDestino.Name = "btnBuscarCiudadDestino";
            btnBuscarCiudadDestino.Size = new Size(23, 23);
            btnBuscarCiudadDestino.TabIndex = 159;
            btnBuscarCiudadDestino.UseVisualStyleBackColor = true;
            // 
            // btnTodoCiudadCruce
            // 
            btnTodoCiudadCruce.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoCiudadCruce.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoCiudadCruce.Enabled = false;
            btnTodoCiudadCruce.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoCiudadCruce.Location = new Point(433, 193);
            btnTodoCiudadCruce.Name = "btnTodoCiudadCruce";
            btnTodoCiudadCruce.Size = new Size(23, 23);
            btnTodoCiudadCruce.TabIndex = 158;
            btnTodoCiudadCruce.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCiudadCruce
            // 
            btnBuscarCiudadCruce.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarCiudadCruce.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarCiudadCruce.Enabled = false;
            btnBuscarCiudadCruce.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarCiudadCruce.Location = new Point(409, 193);
            btnBuscarCiudadCruce.Name = "btnBuscarCiudadCruce";
            btnBuscarCiudadCruce.Size = new Size(23, 23);
            btnBuscarCiudadCruce.TabIndex = 157;
            btnBuscarCiudadCruce.UseVisualStyleBackColor = true;
            // 
            // btnTodoProductor
            // 
            btnTodoProductor.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoProductor.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoProductor.Enabled = false;
            btnTodoProductor.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoProductor.Location = new Point(433, 118);
            btnTodoProductor.Name = "btnTodoProductor";
            btnTodoProductor.Size = new Size(23, 23);
            btnTodoProductor.TabIndex = 156;
            btnTodoProductor.UseVisualStyleBackColor = true;
            // 
            // btnBuscarProductor
            // 
            btnBuscarProductor.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarProductor.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarProductor.Enabled = false;
            btnBuscarProductor.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarProductor.Location = new Point(409, 118);
            btnBuscarProductor.Name = "btnBuscarProductor";
            btnBuscarProductor.Size = new Size(23, 23);
            btnBuscarProductor.TabIndex = 155;
            btnBuscarProductor.UseVisualStyleBackColor = true;
            // 
            // btnTodoAgenciaMX
            // 
            btnTodoAgenciaMX.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoAgenciaMX.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoAgenciaMX.Enabled = false;
            btnTodoAgenciaMX.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoAgenciaMX.Location = new Point(433, 168);
            btnTodoAgenciaMX.Name = "btnTodoAgenciaMX";
            btnTodoAgenciaMX.Size = new Size(23, 23);
            btnTodoAgenciaMX.TabIndex = 154;
            btnTodoAgenciaMX.UseVisualStyleBackColor = true;
            // 
            // btnBuscarAgenciaMX
            // 
            btnBuscarAgenciaMX.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarAgenciaMX.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarAgenciaMX.Enabled = false;
            btnBuscarAgenciaMX.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarAgenciaMX.Location = new Point(409, 168);
            btnBuscarAgenciaMX.Name = "btnBuscarAgenciaMX";
            btnBuscarAgenciaMX.Size = new Size(23, 23);
            btnBuscarAgenciaMX.TabIndex = 152;
            btnBuscarAgenciaMX.UseVisualStyleBackColor = true;
            // 
            // btnTodoAgenciaUS
            // 
            btnTodoAgenciaUS.BackgroundImage = Properties.Resources.Imagen6;
            btnTodoAgenciaUS.BackgroundImageLayout = ImageLayout.Stretch;
            btnTodoAgenciaUS.Enabled = false;
            btnTodoAgenciaUS.Font = new Font("Microsoft Sans Serif", 9F);
            btnTodoAgenciaUS.Location = new Point(433, 143);
            btnTodoAgenciaUS.Name = "btnTodoAgenciaUS";
            btnTodoAgenciaUS.Size = new Size(23, 23);
            btnTodoAgenciaUS.TabIndex = 153;
            btnTodoAgenciaUS.UseVisualStyleBackColor = true;
            // 
            // btnBuscarAgenciaUS
            // 
            btnBuscarAgenciaUS.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnBuscarAgenciaUS.BackgroundImageLayout = ImageLayout.Stretch;
            btnBuscarAgenciaUS.Enabled = false;
            btnBuscarAgenciaUS.Font = new Font("Microsoft Sans Serif", 9F);
            btnBuscarAgenciaUS.Location = new Point(409, 143);
            btnBuscarAgenciaUS.Name = "btnBuscarAgenciaUS";
            btnBuscarAgenciaUS.Size = new Size(23, 23);
            btnBuscarAgenciaUS.TabIndex = 151;
            btnBuscarAgenciaUS.UseVisualStyleBackColor = true;
            // 
            // txbIdCiudadDestino
            // 
            txbIdCiudadDestino.Enabled = false;
            txbIdCiudadDestino.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCiudadDestino.Location = new Point(129, 218);
            txbIdCiudadDestino.Name = "txbIdCiudadDestino";
            txbIdCiudadDestino.Size = new Size(37, 21);
            txbIdCiudadDestino.TabIndex = 170;
            txbIdCiudadDestino.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCiudadDestino
            // 
            cboCiudadDestino.Font = new Font("Microsoft Sans Serif", 9F);
            cboCiudadDestino.FormattingEnabled = true;
            cboCiudadDestino.ItemHeight = 15;
            cboCiudadDestino.Location = new Point(171, 218);
            cboCiudadDestino.Name = "cboCiudadDestino";
            cboCiudadDestino.Size = new Size(235, 23);
            cboCiudadDestino.TabIndex = 150;
            cboCiudadDestino.TextChanged += cboCiudadDestino_TextChanged;
            // 
            // lblCiudadDestino
            // 
            lblCiudadDestino.AutoSize = true;
            lblCiudadDestino.Font = new Font("Microsoft Sans Serif", 9F);
            lblCiudadDestino.Location = new Point(33, 221);
            lblCiudadDestino.Name = "lblCiudadDestino";
            lblCiudadDestino.Size = new Size(92, 15);
            lblCiudadDestino.TabIndex = 169;
            lblCiudadDestino.Text = "Ciudad destino:";
            lblCiudadDestino.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdCiudadCruce
            // 
            txbIdCiudadCruce.Enabled = false;
            txbIdCiudadCruce.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCiudadCruce.Location = new Point(129, 193);
            txbIdCiudadCruce.Name = "txbIdCiudadCruce";
            txbIdCiudadCruce.Size = new Size(37, 21);
            txbIdCiudadCruce.TabIndex = 168;
            txbIdCiudadCruce.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCiudadCruce
            // 
            cboCiudadCruce.Font = new Font("Microsoft Sans Serif", 9F);
            cboCiudadCruce.FormattingEnabled = true;
            cboCiudadCruce.ItemHeight = 15;
            cboCiudadCruce.Location = new Point(171, 193);
            cboCiudadCruce.Name = "cboCiudadCruce";
            cboCiudadCruce.Size = new Size(235, 23);
            cboCiudadCruce.TabIndex = 149;
            cboCiudadCruce.TextChanged += cboCiudadCruce_TextChanged;
            // 
            // lblCiudadCruce
            // 
            lblCiudadCruce.AutoSize = true;
            lblCiudadCruce.Font = new Font("Microsoft Sans Serif", 9F);
            lblCiudadCruce.Location = new Point(43, 196);
            lblCiudadCruce.Name = "lblCiudadCruce";
            lblCiudadCruce.Size = new Size(82, 15);
            lblCiudadCruce.TabIndex = 167;
            lblCiudadCruce.Text = "Ciudad cruce:";
            lblCiudadCruce.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdProductor
            // 
            txbIdProductor.Enabled = false;
            txbIdProductor.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdProductor.Location = new Point(129, 118);
            txbIdProductor.Name = "txbIdProductor";
            txbIdProductor.Size = new Size(37, 21);
            txbIdProductor.TabIndex = 166;
            txbIdProductor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboProductor
            // 
            cboProductor.Font = new Font("Microsoft Sans Serif", 9F);
            cboProductor.FormattingEnabled = true;
            cboProductor.ItemHeight = 15;
            cboProductor.Location = new Point(171, 118);
            cboProductor.Name = "cboProductor";
            cboProductor.Size = new Size(235, 23);
            cboProductor.TabIndex = 148;
            cboProductor.TextChanged += cboProductor_TextChanged;
            // 
            // lblProductor
            // 
            lblProductor.AutoSize = true;
            lblProductor.Font = new Font("Microsoft Sans Serif", 9F);
            lblProductor.Location = new Point(60, 121);
            lblProductor.Name = "lblProductor";
            lblProductor.Size = new Size(63, 15);
            lblProductor.TabIndex = 165;
            lblProductor.Text = "Productor:";
            lblProductor.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdAgenciaUS
            // 
            txbIdAgenciaUS.Enabled = false;
            txbIdAgenciaUS.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgenciaUS.Location = new Point(129, 143);
            txbIdAgenciaUS.Name = "txbIdAgenciaUS";
            txbIdAgenciaUS.Size = new Size(37, 21);
            txbIdAgenciaUS.TabIndex = 164;
            txbIdAgenciaUS.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgenciaUS
            // 
            cboAgenciaUS.Font = new Font("Microsoft Sans Serif", 9F);
            cboAgenciaUS.FormattingEnabled = true;
            cboAgenciaUS.ItemHeight = 15;
            cboAgenciaUS.Location = new Point(171, 143);
            cboAgenciaUS.Name = "cboAgenciaUS";
            cboAgenciaUS.Size = new Size(235, 23);
            cboAgenciaUS.TabIndex = 146;
            cboAgenciaUS.TextChanged += cboAgenciaUS_TextChanged;
            // 
            // lblAgenciaUS
            // 
            lblAgenciaUS.AutoSize = true;
            lblAgenciaUS.Font = new Font("Microsoft Sans Serif", 9F);
            lblAgenciaUS.Location = new Point(49, 146);
            lblAgenciaUS.Name = "lblAgenciaUS";
            lblAgenciaUS.Size = new Size(74, 15);
            lblAgenciaUS.TabIndex = 163;
            lblAgenciaUS.Text = "Agencia US:";
            lblAgenciaUS.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdAgenciaMX
            // 
            txbIdAgenciaMX.Enabled = false;
            txbIdAgenciaMX.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgenciaMX.Location = new Point(129, 168);
            txbIdAgenciaMX.Name = "txbIdAgenciaMX";
            txbIdAgenciaMX.Size = new Size(37, 21);
            txbIdAgenciaMX.TabIndex = 162;
            txbIdAgenciaMX.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgenciaMX
            // 
            cboAgenciaMX.Font = new Font("Microsoft Sans Serif", 9F);
            cboAgenciaMX.FormattingEnabled = true;
            cboAgenciaMX.ItemHeight = 15;
            cboAgenciaMX.Location = new Point(171, 168);
            cboAgenciaMX.Name = "cboAgenciaMX";
            cboAgenciaMX.Size = new Size(235, 23);
            cboAgenciaMX.TabIndex = 147;
            cboAgenciaMX.TextChanged += cboAgenciaMX_TextChanged;
            // 
            // lblAcenciaMX
            // 
            lblAcenciaMX.AutoSize = true;
            lblAcenciaMX.Font = new Font("Microsoft Sans Serif", 9F);
            lblAcenciaMX.Location = new Point(47, 171);
            lblAcenciaMX.Name = "lblAcenciaMX";
            lblAcenciaMX.Size = new Size(76, 15);
            lblAcenciaMX.TabIndex = 161;
            lblAcenciaMX.Text = "Agencia MX:";
            lblAcenciaMX.TextAlign = ContentAlignment.TopRight;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 9F);
            label17.Location = new Point(266, 48);
            label17.Name = "label17";
            label17.Size = new Size(80, 15);
            label17.TabIndex = 145;
            label17.Text = "Fecha salida:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 9F);
            label18.Location = new Point(155, 47);
            label18.Name = "label18";
            label18.Size = new Size(73, 15);
            label18.TabIndex = 144;
            label18.Text = "Hora salida:";
            // 
            // cboTipoEmbarque
            // 
            cboTipoEmbarque.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoEmbarque.Font = new Font("Microsoft Sans Serif", 9F);
            cboTipoEmbarque.FormattingEnabled = true;
            cboTipoEmbarque.Items.AddRange(new object[] { "E", "N" });
            cboTipoEmbarque.Location = new Point(118, 42);
            cboTipoEmbarque.Name = "cboTipoEmbarque";
            cboTipoEmbarque.Size = new Size(37, 23);
            cboTipoEmbarque.TabIndex = 142;
            cboTipoEmbarque.TextChanged += cboTipoEmbarque_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F);
            label7.Location = new Point(46, 655);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 234;
            label7.Text = "Embarcador:";
            // 
            // txbEmbarcador
            // 
            txbEmbarcador.Font = new Font("Microsoft Sans Serif", 9F);
            txbEmbarcador.Location = new Point(129, 652);
            txbEmbarcador.MaxLength = 20;
            txbEmbarcador.Name = "txbEmbarcador";
            txbEmbarcador.Size = new Size(102, 21);
            txbEmbarcador.TabIndex = 233;
            txbEmbarcador.TextAlign = HorizontalAlignment.Center;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 9F);
            label19.Location = new Point(262, 659);
            label19.Name = "label19";
            label19.Size = new Size(62, 15);
            label19.TabIndex = 236;
            label19.Text = "Operador:";
            // 
            // txbOperador
            // 
            txbOperador.Font = new Font("Microsoft Sans Serif", 9F);
            txbOperador.Location = new Point(320, 656);
            txbOperador.MaxLength = 20;
            txbOperador.Name = "txbOperador";
            txbOperador.Size = new Size(102, 21);
            txbOperador.TabIndex = 235;
            txbOperador.TextAlign = HorizontalAlignment.Center;
            // 
            // chkRechazado
            // 
            chkRechazado.AutoSize = true;
            chkRechazado.Font = new Font("Microsoft Sans Serif", 9F);
            chkRechazado.Location = new Point(376, 17);
            chkRechazado.Name = "chkRechazado";
            chkRechazado.Size = new Size(89, 19);
            chkRechazado.TabIndex = 237;
            chkRechazado.Text = "Rechazado";
            chkRechazado.UseVisualStyleBackColor = true;
            // 
            // dgvListado
            // 
            dgvListado.AllowUserToAddRows = false;
            dgvListado.AllowUserToDeleteRows = false;
            dgvListado.AllowUserToResizeRows = false;
            dgvListado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgvListado.BackgroundColor = SystemColors.ControlLightLight;
            dgvListado.BorderStyle = BorderStyle.Fixed3D;
            dgvListado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvListado.EnableHeadersVisualStyles = false;
            dgvListado.ImeMode = ImeMode.NoControl;
            dgvListado.Location = new Point(462, 71);
            dgvListado.MultiSelect = false;
            dgvListado.Name = "dgvListado";
            dgvListado.ReadOnly = true;
            dgvListado.RightToLeft = RightToLeft.No;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvListado.RowHeadersVisible = false;
            dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListado.Size = new Size(455, 576);
            dgvListado.TabIndex = 238;
            dgvListado.CellFormatting += dgvListado_CellFormatting;
            // 
            // lblPosicionPal
            // 
            lblPosicionPal.AutoSize = true;
            lblPosicionPal.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblPosicionPal.Location = new Point(544, 33);
            lblPosicionPal.Name = "lblPosicionPal";
            lblPosicionPal.Size = new Size(28, 13);
            lblPosicionPal.TabIndex = 239;
            lblPosicionPal.Text = "Pos:";
            // 
            // txbPosicionPal
            // 
            txbPosicionPal.Font = new Font("Microsoft Sans Serif", 9F);
            txbPosicionPal.Location = new Point(546, 46);
            txbPosicionPal.MaxLength = 2;
            txbPosicionPal.Name = "txbPosicionPal";
            txbPosicionPal.Size = new Size(26, 21);
            txbPosicionPal.TabIndex = 240;
            // 
            // printManifestBtn
            // 
            printManifestBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            printManifestBtn.Location = new Point(544, 652);
            printManifestBtn.Name = "printManifestBtn";
            printManifestBtn.Size = new Size(64, 25);
            printManifestBtn.TabIndex = 241;
            printManifestBtn.Text = "Imprimir";
            printManifestBtn.UseVisualStyleBackColor = true;
            printManifestBtn.Click += printManifestBtn_Click;
            // 
            // txbDieselLiters
            // 
            txbDieselLiters.Font = new Font("Microsoft Sans Serif", 9F);
            txbDieselLiters.Location = new Point(320, 629);
            txbDieselLiters.MaxLength = 15;
            txbDieselLiters.Name = "txbDieselLiters";
            txbDieselLiters.Size = new Size(102, 21);
            txbDieselLiters.TabIndex = 244;
            txbDieselLiters.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDieselInvoice
            // 
            lblDieselInvoice.AutoSize = true;
            lblDieselInvoice.Font = new Font("Microsoft Sans Serif", 9F);
            lblDieselInvoice.Location = new Point(53, 632);
            lblDieselInvoice.Name = "lblDieselInvoice";
            lblDieselInvoice.Size = new Size(73, 15);
            lblDieselInvoice.TabIndex = 243;
            lblDieselInvoice.Text = "Folio diesel:";
            lblDieselInvoice.TextAlign = ContentAlignment.TopRight;
            // 
            // txbDieselInvoice
            // 
            txbDieselInvoice.Font = new Font("Microsoft Sans Serif", 9F);
            txbDieselInvoice.Location = new Point(129, 629);
            txbDieselInvoice.MaxLength = 15;
            txbDieselInvoice.Name = "txbDieselInvoice";
            txbDieselInvoice.Size = new Size(102, 21);
            txbDieselInvoice.TabIndex = 242;
            txbDieselInvoice.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDieselLiters
            // 
            lblDieselLiters.AutoSize = true;
            lblDieselLiters.Font = new Font("Microsoft Sans Serif", 9F);
            lblDieselLiters.Location = new Point(246, 632);
            lblDieselLiters.Name = "lblDieselLiters";
            lblDieselLiters.Size = new Size(76, 15);
            lblDieselLiters.TabIndex = 245;
            lblDieselLiters.Text = "Litros diesel:";
            lblDieselLiters.TextAlign = ContentAlignment.TopRight;
            // 
            // chkBoxPackingList
            // 
            chkBoxPackingList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkBoxPackingList.AutoSize = true;
            chkBoxPackingList.Location = new Point(462, 654);
            chkBoxPackingList.Name = "chkBoxPackingList";
            chkBoxPackingList.Size = new Size(81, 17);
            chkBoxPackingList.TabIndex = 246;
            chkBoxPackingList.Text = "PackingList";
            chkBoxPackingList.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.Location = new Point(46, 294);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 248;
            label1.Text = "Fitosanitario:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // txbFitosanitario
            // 
            txbFitosanitario.Font = new Font("Microsoft Sans Serif", 9F);
            txbFitosanitario.Location = new Point(129, 291);
            txbFitosanitario.MaxLength = 30;
            txbFitosanitario.Name = "txbFitosanitario";
            txbFitosanitario.Size = new Size(211, 21);
            txbFitosanitario.TabIndex = 247;
            // 
            // FrmManifiestoAñadir
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 683);
            Controls.Add(chkBoxPackingList);
            Controls.Add(printManifestBtn);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(txbFitosanitario);
            Controls.Add(txbDieselLiters);
            Controls.Add(lblDieselInvoice);
            Controls.Add(txbDieselInvoice);
            Controls.Add(txbPosicionPal);
            Controls.Add(lblPosicionPal);
            Controls.Add(txbPosicion);
            Controls.Add(dgvListado);
            Controls.Add(chkRechazado);
            Controls.Add(txbOperador);
            Controls.Add(label7);
            Controls.Add(txbEmbarcador);
            Controls.Add(Mercado);
            Controls.Add(dtpFecha);
            Controls.Add(lblObservaciones);
            Controls.Add(txbObservaciones);
            Controls.Add(cboManifiestoVirtual);
            Controls.Add(btnBorrarPallet);
            Controls.Add(btnAñadirPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(txbSello3);
            Controls.Add(txbSello2);
            Controls.Add(label14);
            Controls.Add(txbSello1);
            Controls.Add(cboGrados);
            Controls.Add(txbGrados);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txbChismografo);
            Controls.Add(label10);
            Controls.Add(cboSegundoMedio);
            Controls.Add(label9);
            Controls.Add(cboMedioTransporte);
            Controls.Add(btnTodoCaja);
            Controls.Add(btnBuscarCaja);
            Controls.Add(btnTodoTroque);
            Controls.Add(btnBuscarTroque);
            Controls.Add(btnTodoChofer);
            Controls.Add(btnBuscarChofer);
            Controls.Add(txbIdCaja);
            Controls.Add(cboCaja);
            Controls.Add(label5);
            Controls.Add(txbIdTroque);
            Controls.Add(cboTroque);
            Controls.Add(label6);
            Controls.Add(txbIdChofer);
            Controls.Add(cboChofer);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(txbOrden);
            Controls.Add(lblVisa);
            Controls.Add(txbBooking);
            Controls.Add(spnHoraSalida);
            Controls.Add(btnTodoDistribuidor);
            Controls.Add(btnBuscarDistribuidor);
            Controls.Add(txbIdDistribuidor);
            Controls.Add(cboDistribuidor);
            Controls.Add(label3);
            Controls.Add(btnTodoConsignatario);
            Controls.Add(btnBuscarConsignatario);
            Controls.Add(txbIdConsignatario);
            Controls.Add(cboConsignatario);
            Controls.Add(label16);
            Controls.Add(btnTodoCiudadDestino);
            Controls.Add(btnBuscarCiudadDestino);
            Controls.Add(btnTodoCiudadCruce);
            Controls.Add(btnBuscarCiudadCruce);
            Controls.Add(btnTodoProductor);
            Controls.Add(btnBuscarProductor);
            Controls.Add(btnTodoAgenciaMX);
            Controls.Add(btnBuscarAgenciaMX);
            Controls.Add(btnTodoAgenciaUS);
            Controls.Add(btnBuscarAgenciaUS);
            Controls.Add(txbIdCiudadDestino);
            Controls.Add(cboCiudadDestino);
            Controls.Add(lblCiudadDestino);
            Controls.Add(txbIdCiudadCruce);
            Controls.Add(cboCiudadCruce);
            Controls.Add(lblCiudadCruce);
            Controls.Add(txbIdProductor);
            Controls.Add(cboProductor);
            Controls.Add(lblProductor);
            Controls.Add(txbIdAgenciaUS);
            Controls.Add(cboAgenciaUS);
            Controls.Add(lblAgenciaUS);
            Controls.Add(txbIdAgenciaMX);
            Controls.Add(cboAgenciaMX);
            Controls.Add(lblAcenciaMX);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(cboTipoEmbarque);
            Controls.Add(cboActivo);
            Controls.Add(lblLinea);
            Controls.Add(btnTodoLinea);
            Controls.Add(btnBuscarLinea);
            Controls.Add(txbIdLinea);
            Controls.Add(cboLinea);
            Controls.Add(txbId);
            Controls.Add(lblTitulo);
            Controls.Add(lblObliId);
            Controls.Add(lblId);
            Controls.Add(label15);
            Controls.Add(label19);
            Controls.Add(lblDieselLiters);
            Controls.Add(label13);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            MaximizeBox = false;
            MinimumSize = new Size(834, 722);
            Name = "FrmManifiestoAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir Manifiesto";
            FormClosing += FrmManifiestoAñadir_FormClosing;
            Load += FrmManifiestoAñadir_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblLinea;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        public Label lblTitulo;
        public TextBox txbId;
        private Button btnTodoLinea;
        private Button btnBuscarLinea;
        public TextBox txbIdLinea;
        private ComboBox cboLinea;
        private Label lblObliId;
        public ComboBox cboActivo;
        private Label Mercado;
        private Label lblObservaciones;
        public ComboBox cboManifiestoVirtual;
        private Button btnBorrarPallet;
        private Button btnAñadirPallet;
        private Label label15;
        public TextBox txbIdPallet;
        public TextBox txbSello3;
        public TextBox txbSello2;
        private Label label14;
        public TextBox txbSello1;
        public ComboBox cboGrados;
        private Label label13;
        public TextBox txbGrados;
        private Label label12;
        public TextBox txbPosicion;
        private Label label11;
        public TextBox txbChismografo;
        private Label label10;
        public ComboBox cboSegundoMedio;
        private Label label9;
        public ComboBox cboMedioTransporte;
        private Button btnTodoCaja;
        private Button btnBuscarCaja;
        private Button btnTodoTroque;
        private Button btnBuscarTroque;
        private Button btnTodoChofer;
        private Button btnBuscarChofer;
        public TextBox txbIdCaja;
        private ComboBox cboCaja;
        private Label label5;
        public TextBox txbIdTroque;
        private ComboBox cboTroque;
        private Label label6;
        public TextBox txbIdChofer;
        public ComboBox cboChofer;
        private Label label8;
        private Label label4;
        public TextBox txbOrden;
        private Label lblVisa;
        public TextBox txbBooking;
        public MaskedTextBox spnHoraSalida;
        private Button btnTodoDistribuidor;
        private Button btnBuscarDistribuidor;
        public TextBox txbIdDistribuidor;
        private ComboBox cboDistribuidor;
        private Label label3;
        private Button btnTodoConsignatario;
        private Button btnBuscarConsignatario;
        public TextBox txbIdConsignatario;
        private ComboBox cboConsignatario;
        private Label label16;
        private Button btnTodoCiudadDestino;
        private Button btnBuscarCiudadDestino;
        private Button btnTodoCiudadCruce;
        private Button btnBuscarCiudadCruce;
        private Button btnTodoProductor;
        private Button btnBuscarProductor;
        private Button btnTodoAgenciaMX;
        private Button btnBuscarAgenciaMX;
        private Button btnTodoAgenciaUS;
        private Button btnBuscarAgenciaUS;
        public TextBox txbIdCiudadDestino;
        private ComboBox cboCiudadDestino;
        private Label lblCiudadDestino;
        public TextBox txbIdCiudadCruce;
        private ComboBox cboCiudadCruce;
        private Label lblCiudadCruce;
        public TextBox txbIdProductor;
        private ComboBox cboProductor;
        private Label lblProductor;
        public TextBox txbIdAgenciaUS;
        public ComboBox cboAgenciaUS;
        private Label lblAgenciaUS;
        public TextBox txbIdAgenciaMX;
        public ComboBox cboAgenciaMX;
        private Label lblAcenciaMX;
        private Label label17;
        private Label label18;
        public ComboBox cboTipoEmbarque;
        private Label label7;
        public TextBox txbEmbarcador;
        private Label label19;
        public TextBox txbOperador;
        public DateTimePicker dtpFecha;
        public RichTextBox txbObservaciones;
        public CheckBox chkRechazado;
        public DataGridView dgvListado;
        private Label lblPosicionPal;
        public TextBox txbPosicionPal;
        private Button printManifestBtn;
        public TextBox txbDieselLiters;
        private Label lblDieselInvoice;
        public TextBox txbDieselInvoice;
        private Label lblDieselLiters;
        private CheckBox chkBoxPackingList;
        private Label label1;
        public TextBox txbFitosanitario;
    }
}
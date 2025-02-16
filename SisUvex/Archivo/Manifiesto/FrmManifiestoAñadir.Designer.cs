
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblLinea = new Label();
            txbId = new TextBox();
            lblId = new Label();
            btnCancel = new Button();
            btnAccept = new Button();
            btnRemovedTransportLine = new Button();
            btnSearchTransportLine = new Button();
            txbIdTransportLine = new TextBox();
            cboTransportLine = new ComboBox();
            lblObliId = new Label();
            cboActive = new ComboBox();
            Mercado = new Label();
            dtpDate = new DateTimePicker();
            lblObservaciones = new Label();
            txbObservations = new RichTextBox();
            btnRemovePallet = new Button();
            btnAddPallet = new Button();
            label15 = new Label();
            txbIdPallet = new TextBox();
            txbSeal3 = new TextBox();
            txbSeal2 = new TextBox();
            label14 = new Label();
            txbSeal1 = new TextBox();
            cboTemperatureUnit = new ComboBox();
            label13 = new Label();
            txbTemperature = new TextBox();
            label12 = new Label();
            txbTermoPosition = new TextBox();
            label11 = new Label();
            txbTermograph = new TextBox();
            label10 = new Label();
            cboTransportType = new ComboBox();
            label9 = new Label();
            cboTransportVehicle = new ComboBox();
            btnRemovedFreightContainer = new Button();
            btnSearchFreightContainer = new Button();
            btnRemovedTruck = new Button();
            btnSearchTruck = new Button();
            btnRemovedDriver = new Button();
            btnSearchDriver = new Button();
            txbIdFreightContainer = new TextBox();
            cboFreightContainer = new ComboBox();
            label5 = new Label();
            txbIdTruck = new TextBox();
            cboTruck = new ComboBox();
            label6 = new Label();
            txbIdDriver = new TextBox();
            cboDriver = new ComboBox();
            label8 = new Label();
            label4 = new Label();
            txbPurchaseOrder = new TextBox();
            lblVisa = new Label();
            txbBooking = new TextBox();
            spnHour = new MaskedTextBox();
            btnRemovedDistributor = new Button();
            btnSearchDistributor = new Button();
            txbIdDistributor = new TextBox();
            cboDistributor = new ComboBox();
            label3 = new Label();
            btnRemovedConsignee = new Button();
            btnSearchConsignee = new Button();
            txbIdConsignee = new TextBox();
            cboConsignee = new ComboBox();
            label16 = new Label();
            btnRemovedCityDestination = new Button();
            btnSearchCityDestination = new Button();
            btnRemovedCityCrossPoint = new Button();
            btnSearchCityCrossPoint = new Button();
            btnRemovedGrower = new Button();
            btnSearchGrower = new Button();
            btnRemovedAgencyMX = new Button();
            btnSearchAgencyMX = new Button();
            btnRemovedAgencyUS = new Button();
            btnSearchAgencyUS = new Button();
            txbIdCityDestination = new TextBox();
            cboCityDestination = new ComboBox();
            lblCiudadDestino = new Label();
            txbIdCityCrossPoint = new TextBox();
            cboCityCrossPoint = new ComboBox();
            lblCiudadCruce = new Label();
            txbIdGrower = new TextBox();
            cboGrower = new ComboBox();
            lblProductor = new Label();
            txbIdAgencyUS = new TextBox();
            cboAgencyUS = new ComboBox();
            lblAgenciaUS = new Label();
            txbIdAgencyMX = new TextBox();
            cboAgencyMX = new ComboBox();
            lblAcenciaMX = new Label();
            label17 = new Label();
            label18 = new Label();
            cboManifestType = new ComboBox();
            label7 = new Label();
            txbNameShipper = new TextBox();
            label19 = new Label();
            txbNameOperator = new TextBox();
            chkRejected = new CheckBox();
            dgvPalletList = new DataGridView();
            lblPosicionPal = new Label();
            txbPalletPosition = new TextBox();
            btnPrintManifest = new Button();
            txbDieselLiters = new TextBox();
            lblDieselInvoice = new Label();
            txbDieselInvoice = new TextBox();
            lblDieselLiters = new Label();
            chkBoxPackingList = new CheckBox();
            label1 = new Label();
            txbPhytosanitary = new TextBox();
            button1 = new Button();
            cboSeason = new ComboBox();
            label2 = new Label();
            txbIdSeason = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPalletList).BeginInit();
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
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(684, 652);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 25);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancelar_Click;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(614, 652);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(64, 25);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAceptar_Click;
            // 
            // btnRemovedTransportLine
            // 
            btnRemovedTransportLine.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedTransportLine.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedTransportLine.Enabled = false;
            btnRemovedTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedTransportLine.Location = new Point(433, 314);
            btnRemovedTransportLine.Name = "btnRemovedTransportLine";
            btnRemovedTransportLine.Size = new Size(23, 23);
            btnRemovedTransportLine.TabIndex = 32;
            btnRemovedTransportLine.UseVisualStyleBackColor = true;
            btnRemovedTransportLine.Click += btnTodoLinea_Click;
            // 
            // btnSearchTransportLine
            // 
            btnSearchTransportLine.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchTransportLine.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchTransportLine.Enabled = false;
            btnSearchTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchTransportLine.Location = new Point(409, 314);
            btnSearchTransportLine.Name = "btnSearchTransportLine";
            btnSearchTransportLine.Size = new Size(23, 23);
            btnSearchTransportLine.TabIndex = 31;
            btnSearchTransportLine.UseVisualStyleBackColor = true;
            btnSearchTransportLine.Click += btnBuscarLinea_Click;
            // 
            // txbIdTransportLine
            // 
            txbIdTransportLine.Enabled = false;
            txbIdTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTransportLine.Location = new Point(129, 315);
            txbIdTransportLine.Name = "txbIdTransportLine";
            txbIdTransportLine.Size = new Size(37, 21);
            txbIdTransportLine.TabIndex = 34;
            txbIdTransportLine.TextAlign = HorizontalAlignment.Center;
            txbIdTransportLine.TextChanged += txbIdLinea_TextChanged;
            // 
            // cboTransportLine
            // 
            cboTransportLine.Font = new Font("Microsoft Sans Serif", 9F);
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.ItemHeight = 15;
            cboTransportLine.Location = new Point(171, 314);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(235, 23);
            cboTransportLine.TabIndex = 30;
            cboTransportLine.TextChanged += cboLinea_TextChanged;
            cboTransportLine.MouseClick += cboLinea_MouseClick;
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
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Microsoft Sans Serif", 9F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(309, 5);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(37, 23);
            cboActive.TabIndex = 36;
            // 
            // Mercado
            // 
            Mercado.AutoSize = true;
            Mercado.Font = new Font("Microsoft Sans Serif", 9F);
            Mercado.Location = new Point(268, 10);
            Mercado.Name = "Mercado";
            Mercado.Size = new Size(41, 15);
            Mercado.TabIndex = 230;
            Mercado.Text = "Activo:";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Microsoft Sans Serif", 9F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(342, 43);
            dtpDate.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(75, 21);
            dtpDate.TabIndex = 229;
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
            // txbObservations
            // 
            txbObservations.Font = new Font("Microsoft Sans Serif", 9F);
            txbObservations.Location = new Point(129, 512);
            txbObservations.MaxLength = 200;
            txbObservations.Name = "txbObservations";
            txbObservations.Size = new Size(314, 111);
            txbObservations.TabIndex = 227;
            txbObservations.Text = "";
            // 
            // btnRemovePallet
            // 
            btnRemovePallet.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnRemovePallet.Image = Properties.Resources.basuraIcon16;
            btnRemovePallet.ImageAlign = ContentAlignment.MiddleRight;
            btnRemovePallet.Location = new Point(572, 47);
            btnRemovePallet.Name = "btnRemovePallet";
            btnRemovePallet.Size = new Size(23, 23);
            btnRemovePallet.TabIndex = 225;
            btnRemovePallet.TextAlign = ContentAlignment.TopCenter;
            btnRemovePallet.UseVisualStyleBackColor = true;
            btnRemovePallet.Click += btnBorrarPallet_Click;
            // 
            // btnAddPallet
            // 
            btnAddPallet.Font = new Font("Microsoft Sans Serif", 9F);
            btnAddPallet.Image = Properties.Resources.mas_16;
            btnAddPallet.ImageAlign = ContentAlignment.BottomRight;
            btnAddPallet.Location = new Point(540, 47);
            btnAddPallet.Name = "btnAddPallet";
            btnAddPallet.Size = new Size(23, 23);
            btnAddPallet.TabIndex = 224;
            btnAddPallet.TextAlign = ContentAlignment.TopRight;
            btnAddPallet.UseVisualStyleBackColor = true;
            btnAddPallet.Click += btnAñadirPallet_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 8.25F);
            label15.Location = new Point(460, 35);
            label15.Name = "label15";
            label15.Size = new Size(38, 13);
            label15.TabIndex = 223;
            label15.Text = "N. pal:";
            // 
            // txbIdPallet
            // 
            txbIdPallet.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdPallet.Location = new Point(462, 48);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(47, 21);
            txbIdPallet.TabIndex = 222;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // txbSeal3
            // 
            txbSeal3.Font = new Font("Microsoft Sans Serif", 9F);
            txbSeal3.Location = new Point(341, 489);
            txbSeal3.MaxLength = 10;
            txbSeal3.Name = "txbSeal3";
            txbSeal3.Size = new Size(102, 21);
            txbSeal3.TabIndex = 220;
            txbSeal3.TextAlign = HorizontalAlignment.Center;
            // 
            // txbSeal2
            // 
            txbSeal2.Font = new Font("Microsoft Sans Serif", 9F);
            txbSeal2.Location = new Point(236, 489);
            txbSeal2.MaxLength = 10;
            txbSeal2.Name = "txbSeal2";
            txbSeal2.Size = new Size(102, 21);
            txbSeal2.TabIndex = 219;
            txbSeal2.TextAlign = HorizontalAlignment.Center;
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
            // txbSeal1
            // 
            txbSeal1.Font = new Font("Microsoft Sans Serif", 9F);
            txbSeal1.Location = new Point(129, 489);
            txbSeal1.MaxLength = 10;
            txbSeal1.Name = "txbSeal1";
            txbSeal1.Size = new Size(102, 21);
            txbSeal1.TabIndex = 217;
            txbSeal1.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTemperatureUnit
            // 
            cboTemperatureUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTemperatureUnit.Font = new Font("Microsoft Sans Serif", 9F);
            cboTemperatureUnit.FormattingEnabled = true;
            cboTemperatureUnit.Items.AddRange(new object[] { "F", "C", "K" });
            cboTemperatureUnit.Location = new Point(406, 465);
            cboTemperatureUnit.Name = "cboTemperatureUnit";
            cboTemperatureUnit.Size = new Size(33, 23);
            cboTemperatureUnit.TabIndex = 216;
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
            // txbTemperature
            // 
            txbTemperature.Font = new Font("Microsoft Sans Serif", 9F);
            txbTemperature.Location = new Point(372, 465);
            txbTemperature.MaxLength = 3;
            txbTemperature.Name = "txbTemperature";
            txbTemperature.Size = new Size(28, 21);
            txbTemperature.TabIndex = 214;
            txbTemperature.TextAlign = HorizontalAlignment.Center;
            txbTemperature.KeyPress += txbGrados_KeyPress;
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
            // txbTermoPosition
            // 
            txbTermoPosition.Font = new Font("Microsoft Sans Serif", 9F);
            txbTermoPosition.Location = new Point(289, 467);
            txbTermoPosition.MaxLength = 2;
            txbTermoPosition.Name = "txbTermoPosition";
            txbTermoPosition.Size = new Size(32, 21);
            txbTermoPosition.TabIndex = 212;
            txbTermoPosition.TextAlign = HorizontalAlignment.Center;
            txbTermoPosition.KeyPress += txbPosicion_KeyPress;
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
            // txbTermograph
            // 
            txbTermograph.Font = new Font("Microsoft Sans Serif", 9F);
            txbTermograph.Location = new Point(129, 465);
            txbTermograph.MaxLength = 20;
            txbTermograph.Name = "txbTermograph";
            txbTermograph.Size = new Size(102, 21);
            txbTermograph.TabIndex = 210;
            txbTermograph.TextAlign = HorizontalAlignment.Center;
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
            // cboTransportType
            // 
            cboTransportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportType.Font = new Font("Microsoft Sans Serif", 9F);
            cboTransportType.FormattingEnabled = true;
            cboTransportType.Items.AddRange(new object[] { "", "TRAILER", "CAJA REFRIGERADA", "CONTENEDOR", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboTransportType.Location = new Point(129, 440);
            cboTransportType.Name = "cboTransportType";
            cboTransportType.Size = new Size(211, 23);
            cboTransportType.TabIndex = 208;
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
            // cboTransportVehicle
            // 
            cboTransportVehicle.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportVehicle.Font = new Font("Microsoft Sans Serif", 9F);
            cboTransportVehicle.FormattingEnabled = true;
            cboTransportVehicle.Items.AddRange(new object[] { "", "TRAILER", "CONTENEDOR", "CAJA REFRIGERADA", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboTransportVehicle.Location = new Point(129, 415);
            cboTransportVehicle.Name = "cboTransportVehicle";
            cboTransportVehicle.Size = new Size(211, 23);
            cboTransportVehicle.TabIndex = 206;
            // 
            // btnRemovedFreightContainer
            // 
            btnRemovedFreightContainer.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedFreightContainer.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedFreightContainer.Enabled = false;
            btnRemovedFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedFreightContainer.Location = new Point(433, 390);
            btnRemovedFreightContainer.Name = "btnRemovedFreightContainer";
            btnRemovedFreightContainer.Size = new Size(23, 23);
            btnRemovedFreightContainer.TabIndex = 197;
            btnRemovedFreightContainer.UseVisualStyleBackColor = true;
            // 
            // btnSearchFreightContainer
            // 
            btnSearchFreightContainer.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchFreightContainer.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchFreightContainer.Enabled = false;
            btnSearchFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchFreightContainer.Location = new Point(409, 390);
            btnSearchFreightContainer.Name = "btnSearchFreightContainer";
            btnSearchFreightContainer.Size = new Size(23, 23);
            btnSearchFreightContainer.TabIndex = 196;
            btnSearchFreightContainer.UseVisualStyleBackColor = true;
            // 
            // btnRemovedTruck
            // 
            btnRemovedTruck.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedTruck.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedTruck.Enabled = false;
            btnRemovedTruck.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedTruck.Location = new Point(433, 365);
            btnRemovedTruck.Name = "btnRemovedTruck";
            btnRemovedTruck.Size = new Size(23, 23);
            btnRemovedTruck.TabIndex = 195;
            btnRemovedTruck.UseVisualStyleBackColor = true;
            // 
            // btnSearchTruck
            // 
            btnSearchTruck.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchTruck.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchTruck.Enabled = false;
            btnSearchTruck.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchTruck.Location = new Point(409, 365);
            btnSearchTruck.Name = "btnSearchTruck";
            btnSearchTruck.Size = new Size(23, 23);
            btnSearchTruck.TabIndex = 194;
            btnSearchTruck.UseVisualStyleBackColor = true;
            // 
            // btnRemovedDriver
            // 
            btnRemovedDriver.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedDriver.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedDriver.Enabled = false;
            btnRemovedDriver.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedDriver.Location = new Point(433, 339);
            btnRemovedDriver.Name = "btnRemovedDriver";
            btnRemovedDriver.Size = new Size(23, 23);
            btnRemovedDriver.TabIndex = 193;
            btnRemovedDriver.UseVisualStyleBackColor = true;
            // 
            // btnSearchDriver
            // 
            btnSearchDriver.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDriver.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDriver.Enabled = false;
            btnSearchDriver.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchDriver.Location = new Point(409, 339);
            btnSearchDriver.Name = "btnSearchDriver";
            btnSearchDriver.Size = new Size(23, 23);
            btnSearchDriver.TabIndex = 191;
            btnSearchDriver.UseVisualStyleBackColor = true;
            // 
            // txbIdFreightContainer
            // 
            txbIdFreightContainer.Enabled = false;
            txbIdFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdFreightContainer.Location = new Point(129, 390);
            txbIdFreightContainer.Name = "txbIdFreightContainer";
            txbIdFreightContainer.Size = new Size(37, 21);
            txbIdFreightContainer.TabIndex = 205;
            txbIdFreightContainer.TextAlign = HorizontalAlignment.Center;
            // 
            // cboFreightContainer
            // 
            cboFreightContainer.Font = new Font("Microsoft Sans Serif", 9F);
            cboFreightContainer.FormattingEnabled = true;
            cboFreightContainer.ItemHeight = 15;
            cboFreightContainer.Location = new Point(171, 390);
            cboFreightContainer.Name = "cboFreightContainer";
            cboFreightContainer.Size = new Size(235, 23);
            cboFreightContainer.TabIndex = 189;
            cboFreightContainer.TextChanged += cboCaja_TextChanged;
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
            // txbIdTruck
            // 
            txbIdTruck.Enabled = false;
            txbIdTruck.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdTruck.Location = new Point(129, 365);
            txbIdTruck.Name = "txbIdTruck";
            txbIdTruck.Size = new Size(37, 21);
            txbIdTruck.TabIndex = 203;
            txbIdTruck.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTruck
            // 
            cboTruck.Font = new Font("Microsoft Sans Serif", 9F);
            cboTruck.FormattingEnabled = true;
            cboTruck.ItemHeight = 15;
            cboTruck.Location = new Point(171, 365);
            cboTruck.Name = "cboTruck";
            cboTruck.Size = new Size(235, 23);
            cboTruck.TabIndex = 188;
            cboTruck.TextChanged += cboTroque_TextChanged;
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
            // txbIdDriver
            // 
            txbIdDriver.Enabled = false;
            txbIdDriver.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDriver.Location = new Point(129, 339);
            txbIdDriver.Name = "txbIdDriver";
            txbIdDriver.Size = new Size(37, 21);
            txbIdDriver.TabIndex = 199;
            txbIdDriver.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDriver
            // 
            cboDriver.Font = new Font("Microsoft Sans Serif", 9F);
            cboDriver.FormattingEnabled = true;
            cboDriver.ItemHeight = 15;
            cboDriver.Location = new Point(171, 339);
            cboDriver.Name = "cboDriver";
            cboDriver.Size = new Size(235, 23);
            cboDriver.TabIndex = 187;
            cboDriver.TextChanged += cboChofer_TextChanged;
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
            // txbPurchaseOrder
            // 
            txbPurchaseOrder.Font = new Font("Microsoft Sans Serif", 9F);
            txbPurchaseOrder.Location = new Point(129, 267);
            txbPurchaseOrder.MaxLength = 30;
            txbPurchaseOrder.Name = "txbPurchaseOrder";
            txbPurchaseOrder.Size = new Size(211, 21);
            txbPurchaseOrder.TabIndex = 184;
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
            // spnHour
            // 
            spnHour.Font = new Font("Microsoft Sans Serif", 9F);
            spnHour.Location = new Point(228, 44);
            spnHour.Mask = "00:00";
            spnHour.Name = "spnHour";
            spnHour.Size = new Size(38, 21);
            spnHour.TabIndex = 181;
            spnHour.ValidatingType = typeof(DateTime);
            // 
            // btnRemovedDistributor
            // 
            btnRemovedDistributor.BackgroundImage = (Image)resources.GetObject("btnRemovedDistributor.BackgroundImage");
            btnRemovedDistributor.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedDistributor.Enabled = false;
            btnRemovedDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedDistributor.Location = new Point(433, 68);
            btnRemovedDistributor.Name = "btnRemovedDistributor";
            btnRemovedDistributor.Size = new Size(23, 23);
            btnRemovedDistributor.TabIndex = 178;
            btnRemovedDistributor.UseVisualStyleBackColor = true;
            // 
            // btnSearchDistributor
            // 
            btnSearchDistributor.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchDistributor.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchDistributor.Enabled = false;
            btnSearchDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchDistributor.Location = new Point(409, 68);
            btnSearchDistributor.Name = "btnSearchDistributor";
            btnSearchDistributor.Size = new Size(23, 23);
            btnSearchDistributor.TabIndex = 177;
            btnSearchDistributor.UseVisualStyleBackColor = true;
            // 
            // txbIdDistributor
            // 
            txbIdDistributor.Enabled = false;
            txbIdDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdDistributor.Location = new Point(129, 68);
            txbIdDistributor.Name = "txbIdDistributor";
            txbIdDistributor.Size = new Size(37, 21);
            txbIdDistributor.TabIndex = 180;
            txbIdDistributor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistributor
            // 
            cboDistributor.Font = new Font("Microsoft Sans Serif", 9F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 15;
            cboDistributor.Location = new Point(171, 68);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(235, 23);
            cboDistributor.TabIndex = 176;
            cboDistributor.TextChanged += cboDistribuidor_TextChanged;
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
            // btnRemovedConsignee
            // 
            btnRemovedConsignee.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedConsignee.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedConsignee.Enabled = false;
            btnRemovedConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedConsignee.Location = new Point(433, 93);
            btnRemovedConsignee.Name = "btnRemovedConsignee";
            btnRemovedConsignee.Size = new Size(23, 23);
            btnRemovedConsignee.TabIndex = 173;
            btnRemovedConsignee.UseVisualStyleBackColor = true;
            // 
            // btnSearchConsignee
            // 
            btnSearchConsignee.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchConsignee.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchConsignee.Enabled = false;
            btnSearchConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchConsignee.Location = new Point(409, 93);
            btnSearchConsignee.Name = "btnSearchConsignee";
            btnSearchConsignee.Size = new Size(23, 23);
            btnSearchConsignee.TabIndex = 172;
            btnSearchConsignee.UseVisualStyleBackColor = true;
            // 
            // txbIdConsignee
            // 
            txbIdConsignee.Enabled = false;
            txbIdConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdConsignee.Location = new Point(129, 93);
            txbIdConsignee.Name = "txbIdConsignee";
            txbIdConsignee.Size = new Size(37, 21);
            txbIdConsignee.TabIndex = 175;
            txbIdConsignee.TextAlign = HorizontalAlignment.Center;
            // 
            // cboConsignee
            // 
            cboConsignee.Font = new Font("Microsoft Sans Serif", 9F);
            cboConsignee.FormattingEnabled = true;
            cboConsignee.ItemHeight = 15;
            cboConsignee.Location = new Point(171, 93);
            cboConsignee.Name = "cboConsignee";
            cboConsignee.Size = new Size(235, 23);
            cboConsignee.TabIndex = 171;
            cboConsignee.TextChanged += cboConsignatario_TextChanged;
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
            // btnRemovedCityDestination
            // 
            btnRemovedCityDestination.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedCityDestination.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedCityDestination.Enabled = false;
            btnRemovedCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedCityDestination.Location = new Point(433, 218);
            btnRemovedCityDestination.Name = "btnRemovedCityDestination";
            btnRemovedCityDestination.Size = new Size(23, 23);
            btnRemovedCityDestination.TabIndex = 160;
            btnRemovedCityDestination.UseVisualStyleBackColor = true;
            // 
            // btnSearchCityDestination
            // 
            btnSearchCityDestination.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchCityDestination.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchCityDestination.Enabled = false;
            btnSearchCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchCityDestination.Location = new Point(409, 218);
            btnSearchCityDestination.Name = "btnSearchCityDestination";
            btnSearchCityDestination.Size = new Size(23, 23);
            btnSearchCityDestination.TabIndex = 159;
            btnSearchCityDestination.UseVisualStyleBackColor = true;
            // 
            // btnRemovedCityCrossPoint
            // 
            btnRemovedCityCrossPoint.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedCityCrossPoint.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedCityCrossPoint.Enabled = false;
            btnRemovedCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedCityCrossPoint.Location = new Point(433, 193);
            btnRemovedCityCrossPoint.Name = "btnRemovedCityCrossPoint";
            btnRemovedCityCrossPoint.Size = new Size(23, 23);
            btnRemovedCityCrossPoint.TabIndex = 158;
            btnRemovedCityCrossPoint.UseVisualStyleBackColor = true;
            // 
            // btnSearchCityCrossPoint
            // 
            btnSearchCityCrossPoint.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchCityCrossPoint.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchCityCrossPoint.Enabled = false;
            btnSearchCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchCityCrossPoint.Location = new Point(409, 193);
            btnSearchCityCrossPoint.Name = "btnSearchCityCrossPoint";
            btnSearchCityCrossPoint.Size = new Size(23, 23);
            btnSearchCityCrossPoint.TabIndex = 157;
            btnSearchCityCrossPoint.UseVisualStyleBackColor = true;
            // 
            // btnRemovedGrower
            // 
            btnRemovedGrower.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedGrower.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedGrower.Enabled = false;
            btnRemovedGrower.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedGrower.Location = new Point(433, 118);
            btnRemovedGrower.Name = "btnRemovedGrower";
            btnRemovedGrower.Size = new Size(23, 23);
            btnRemovedGrower.TabIndex = 156;
            btnRemovedGrower.UseVisualStyleBackColor = true;
            // 
            // btnSearchGrower
            // 
            btnSearchGrower.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchGrower.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchGrower.Enabled = false;
            btnSearchGrower.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchGrower.Location = new Point(409, 118);
            btnSearchGrower.Name = "btnSearchGrower";
            btnSearchGrower.Size = new Size(23, 23);
            btnSearchGrower.TabIndex = 155;
            btnSearchGrower.UseVisualStyleBackColor = true;
            // 
            // btnRemovedAgencyMX
            // 
            btnRemovedAgencyMX.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedAgencyMX.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedAgencyMX.Enabled = false;
            btnRemovedAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedAgencyMX.Location = new Point(433, 168);
            btnRemovedAgencyMX.Name = "btnRemovedAgencyMX";
            btnRemovedAgencyMX.Size = new Size(23, 23);
            btnRemovedAgencyMX.TabIndex = 154;
            btnRemovedAgencyMX.UseVisualStyleBackColor = true;
            // 
            // btnSearchAgencyMX
            // 
            btnSearchAgencyMX.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchAgencyMX.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchAgencyMX.Enabled = false;
            btnSearchAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchAgencyMX.Location = new Point(409, 168);
            btnSearchAgencyMX.Name = "btnSearchAgencyMX";
            btnSearchAgencyMX.Size = new Size(23, 23);
            btnSearchAgencyMX.TabIndex = 152;
            btnSearchAgencyMX.UseVisualStyleBackColor = true;
            // 
            // btnRemovedAgencyUS
            // 
            btnRemovedAgencyUS.BackgroundImage = Properties.Resources.Imagen6;
            btnRemovedAgencyUS.BackgroundImageLayout = ImageLayout.Stretch;
            btnRemovedAgencyUS.Enabled = false;
            btnRemovedAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            btnRemovedAgencyUS.Location = new Point(433, 143);
            btnRemovedAgencyUS.Name = "btnRemovedAgencyUS";
            btnRemovedAgencyUS.Size = new Size(23, 23);
            btnRemovedAgencyUS.TabIndex = 153;
            btnRemovedAgencyUS.UseVisualStyleBackColor = true;
            // 
            // btnSearchAgencyUS
            // 
            btnSearchAgencyUS.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnSearchAgencyUS.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearchAgencyUS.Enabled = false;
            btnSearchAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            btnSearchAgencyUS.Location = new Point(409, 143);
            btnSearchAgencyUS.Name = "btnSearchAgencyUS";
            btnSearchAgencyUS.Size = new Size(23, 23);
            btnSearchAgencyUS.TabIndex = 151;
            btnSearchAgencyUS.UseVisualStyleBackColor = true;
            // 
            // txbIdCityDestination
            // 
            txbIdCityDestination.Enabled = false;
            txbIdCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCityDestination.Location = new Point(129, 218);
            txbIdCityDestination.Name = "txbIdCityDestination";
            txbIdCityDestination.Size = new Size(37, 21);
            txbIdCityDestination.TabIndex = 170;
            txbIdCityDestination.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCityDestination
            // 
            cboCityDestination.Font = new Font("Microsoft Sans Serif", 9F);
            cboCityDestination.FormattingEnabled = true;
            cboCityDestination.ItemHeight = 15;
            cboCityDestination.Location = new Point(171, 218);
            cboCityDestination.Name = "cboCityDestination";
            cboCityDestination.Size = new Size(235, 23);
            cboCityDestination.TabIndex = 150;
            cboCityDestination.TextChanged += cboCiudadDestino_TextChanged;
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
            // txbIdCityCrossPoint
            // 
            txbIdCityCrossPoint.Enabled = false;
            txbIdCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdCityCrossPoint.Location = new Point(129, 193);
            txbIdCityCrossPoint.Name = "txbIdCityCrossPoint";
            txbIdCityCrossPoint.Size = new Size(37, 21);
            txbIdCityCrossPoint.TabIndex = 168;
            txbIdCityCrossPoint.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCityCrossPoint
            // 
            cboCityCrossPoint.Font = new Font("Microsoft Sans Serif", 9F);
            cboCityCrossPoint.FormattingEnabled = true;
            cboCityCrossPoint.ItemHeight = 15;
            cboCityCrossPoint.Location = new Point(171, 193);
            cboCityCrossPoint.Name = "cboCityCrossPoint";
            cboCityCrossPoint.Size = new Size(235, 23);
            cboCityCrossPoint.TabIndex = 149;
            cboCityCrossPoint.TextChanged += cboCiudadCruce_TextChanged;
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
            // txbIdGrower
            // 
            txbIdGrower.Enabled = false;
            txbIdGrower.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdGrower.Location = new Point(129, 118);
            txbIdGrower.Name = "txbIdGrower";
            txbIdGrower.Size = new Size(37, 21);
            txbIdGrower.TabIndex = 166;
            txbIdGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrower
            // 
            cboGrower.Font = new Font("Microsoft Sans Serif", 9F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 15;
            cboGrower.Location = new Point(171, 118);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(235, 23);
            cboGrower.TabIndex = 148;
            cboGrower.TextChanged += cboProductor_TextChanged;
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
            // txbIdAgencyUS
            // 
            txbIdAgencyUS.Enabled = false;
            txbIdAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgencyUS.Location = new Point(129, 143);
            txbIdAgencyUS.Name = "txbIdAgencyUS";
            txbIdAgencyUS.Size = new Size(37, 21);
            txbIdAgencyUS.TabIndex = 164;
            txbIdAgencyUS.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgencyUS
            // 
            cboAgencyUS.Font = new Font("Microsoft Sans Serif", 9F);
            cboAgencyUS.FormattingEnabled = true;
            cboAgencyUS.ItemHeight = 15;
            cboAgencyUS.Location = new Point(171, 143);
            cboAgencyUS.Name = "cboAgencyUS";
            cboAgencyUS.Size = new Size(235, 23);
            cboAgencyUS.TabIndex = 146;
            cboAgencyUS.TextChanged += cboAgenciaUS_TextChanged;
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
            // txbIdAgencyMX
            // 
            txbIdAgencyMX.Enabled = false;
            txbIdAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdAgencyMX.Location = new Point(129, 168);
            txbIdAgencyMX.Name = "txbIdAgencyMX";
            txbIdAgencyMX.Size = new Size(37, 21);
            txbIdAgencyMX.TabIndex = 162;
            txbIdAgencyMX.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgencyMX
            // 
            cboAgencyMX.Font = new Font("Microsoft Sans Serif", 9F);
            cboAgencyMX.FormattingEnabled = true;
            cboAgencyMX.ItemHeight = 15;
            cboAgencyMX.Location = new Point(171, 168);
            cboAgencyMX.Name = "cboAgencyMX";
            cboAgencyMX.Size = new Size(235, 23);
            cboAgencyMX.TabIndex = 147;
            cboAgencyMX.TextChanged += cboAgenciaMX_TextChanged;
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
            // cboManifestType
            // 
            cboManifestType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboManifestType.Font = new Font("Microsoft Sans Serif", 9F);
            cboManifestType.FormattingEnabled = true;
            cboManifestType.Items.AddRange(new object[] { "E", "N" });
            cboManifestType.Location = new Point(118, 42);
            cboManifestType.Name = "cboManifestType";
            cboManifestType.Size = new Size(37, 23);
            cboManifestType.TabIndex = 142;
            cboManifestType.TextChanged += cboTipoEmbarque_TextChanged;
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
            // txbNameShipper
            // 
            txbNameShipper.Font = new Font("Microsoft Sans Serif", 9F);
            txbNameShipper.Location = new Point(129, 652);
            txbNameShipper.MaxLength = 20;
            txbNameShipper.Name = "txbNameShipper";
            txbNameShipper.Size = new Size(102, 21);
            txbNameShipper.TabIndex = 233;
            txbNameShipper.TextAlign = HorizontalAlignment.Center;
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
            // txbNameOperator
            // 
            txbNameOperator.Font = new Font("Microsoft Sans Serif", 9F);
            txbNameOperator.Location = new Point(320, 656);
            txbNameOperator.MaxLength = 20;
            txbNameOperator.Name = "txbNameOperator";
            txbNameOperator.Size = new Size(102, 21);
            txbNameOperator.TabIndex = 235;
            txbNameOperator.TextAlign = HorizontalAlignment.Center;
            // 
            // chkRejected
            // 
            chkRejected.AutoSize = true;
            chkRejected.Font = new Font("Microsoft Sans Serif", 9F);
            chkRejected.Location = new Point(697, 4);
            chkRejected.Name = "chkRejected";
            chkRejected.Size = new Size(89, 19);
            chkRejected.TabIndex = 237;
            chkRejected.Text = "Rechazado";
            chkRejected.UseVisualStyleBackColor = true;
            // 
            // dgvPalletList
            // 
            dgvPalletList.AllowUserToAddRows = false;
            dgvPalletList.AllowUserToDeleteRows = false;
            dgvPalletList.AllowUserToResizeRows = false;
            dgvPalletList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPalletList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgvPalletList.BackgroundColor = SystemColors.ControlLightLight;
            dgvPalletList.BorderStyle = BorderStyle.Fixed3D;
            dgvPalletList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPalletList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPalletList.EnableHeadersVisualStyles = false;
            dgvPalletList.ImeMode = ImeMode.NoControl;
            dgvPalletList.Location = new Point(463, 71);
            dgvPalletList.MultiSelect = false;
            dgvPalletList.Name = "dgvPalletList";
            dgvPalletList.ReadOnly = true;
            dgvPalletList.RightToLeft = RightToLeft.No;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPalletList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPalletList.RowHeadersVisible = false;
            dgvPalletList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPalletList.Size = new Size(352, 576);
            dgvPalletList.TabIndex = 238;
            dgvPalletList.CellFormatting += dgvListado_CellFormatting;
            // 
            // lblPosicionPal
            // 
            lblPosicionPal.AutoSize = true;
            lblPosicionPal.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblPosicionPal.Location = new Point(510, 35);
            lblPosicionPal.Name = "lblPosicionPal";
            lblPosicionPal.Size = new Size(28, 13);
            lblPosicionPal.TabIndex = 239;
            lblPosicionPal.Text = "Pos:";
            // 
            // txbPalletPosition
            // 
            txbPalletPosition.Font = new Font("Microsoft Sans Serif", 9F);
            txbPalletPosition.Location = new Point(512, 48);
            txbPalletPosition.MaxLength = 2;
            txbPalletPosition.Name = "txbPalletPosition";
            txbPalletPosition.Size = new Size(26, 21);
            txbPalletPosition.TabIndex = 240;
            // 
            // btnPrintManifest
            // 
            btnPrintManifest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrintManifest.Location = new Point(544, 652);
            btnPrintManifest.Name = "btnPrintManifest";
            btnPrintManifest.Size = new Size(64, 25);
            btnPrintManifest.TabIndex = 241;
            btnPrintManifest.Text = "Imprimir";
            btnPrintManifest.UseVisualStyleBackColor = true;
            btnPrintManifest.Click += printManifestBtn_Click;
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
            chkBoxPackingList.Location = new Point(463, 657);
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
            // txbPhytosanitary
            // 
            txbPhytosanitary.Font = new Font("Microsoft Sans Serif", 9F);
            txbPhytosanitary.Location = new Point(129, 291);
            txbPhytosanitary.MaxLength = 30;
            txbPhytosanitary.Name = "txbPhytosanitary";
            txbPhytosanitary.Size = new Size(211, 21);
            txbPhytosanitary.TabIndex = 247;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Font = new Font("Microsoft Sans Serif", 9F);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.BottomRight;
            button1.Location = new Point(792, 2);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 249;
            button1.TextAlign = ContentAlignment.TopRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Enabled = false;
            cboSeason.Font = new Font("Microsoft Sans Serif", 9F);
            cboSeason.FormattingEnabled = true;
            cboSeason.Items.AddRange(new object[] { "E", "N" });
            cboSeason.Location = new Point(460, 4);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(148, 23);
            cboSeason.TabIndex = 361;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(349, 8);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 362;
            label2.Text = "Temporada:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdSeason
            // 
            txbIdSeason.Enabled = false;
            txbIdSeason.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdSeason.Location = new Point(429, 5);
            txbIdSeason.Name = "txbIdSeason";
            txbIdSeason.Size = new Size(27, 21);
            txbIdSeason.TabIndex = 363;
            txbIdSeason.TextAlign = HorizontalAlignment.Center;
            // 
            // FrmManifiestoAñadir
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 683);
            Controls.Add(txbIdSeason);
            Controls.Add(cboSeason);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(chkBoxPackingList);
            Controls.Add(btnPrintManifest);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(txbPhytosanitary);
            Controls.Add(txbDieselLiters);
            Controls.Add(lblDieselInvoice);
            Controls.Add(txbDieselInvoice);
            Controls.Add(txbPalletPosition);
            Controls.Add(lblPosicionPal);
            Controls.Add(txbTermoPosition);
            Controls.Add(dgvPalletList);
            Controls.Add(chkRejected);
            Controls.Add(txbNameOperator);
            Controls.Add(label7);
            Controls.Add(txbNameShipper);
            Controls.Add(Mercado);
            Controls.Add(dtpDate);
            Controls.Add(lblObservaciones);
            Controls.Add(txbObservations);
            Controls.Add(btnRemovePallet);
            Controls.Add(btnAddPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(txbSeal3);
            Controls.Add(txbSeal2);
            Controls.Add(label14);
            Controls.Add(txbSeal1);
            Controls.Add(cboTemperatureUnit);
            Controls.Add(txbTemperature);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txbTermograph);
            Controls.Add(label10);
            Controls.Add(cboTransportType);
            Controls.Add(label9);
            Controls.Add(cboTransportVehicle);
            Controls.Add(btnRemovedFreightContainer);
            Controls.Add(btnSearchFreightContainer);
            Controls.Add(btnRemovedTruck);
            Controls.Add(btnSearchTruck);
            Controls.Add(btnRemovedDriver);
            Controls.Add(btnSearchDriver);
            Controls.Add(txbIdFreightContainer);
            Controls.Add(cboFreightContainer);
            Controls.Add(label5);
            Controls.Add(txbIdTruck);
            Controls.Add(cboTruck);
            Controls.Add(label6);
            Controls.Add(txbIdDriver);
            Controls.Add(cboDriver);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(txbPurchaseOrder);
            Controls.Add(lblVisa);
            Controls.Add(txbBooking);
            Controls.Add(spnHour);
            Controls.Add(btnRemovedDistributor);
            Controls.Add(btnSearchDistributor);
            Controls.Add(txbIdDistributor);
            Controls.Add(cboDistributor);
            Controls.Add(label3);
            Controls.Add(btnRemovedConsignee);
            Controls.Add(btnSearchConsignee);
            Controls.Add(txbIdConsignee);
            Controls.Add(cboConsignee);
            Controls.Add(label16);
            Controls.Add(btnRemovedCityDestination);
            Controls.Add(btnSearchCityDestination);
            Controls.Add(btnRemovedCityCrossPoint);
            Controls.Add(btnSearchCityCrossPoint);
            Controls.Add(btnRemovedGrower);
            Controls.Add(btnSearchGrower);
            Controls.Add(btnRemovedAgencyMX);
            Controls.Add(btnSearchAgencyMX);
            Controls.Add(btnRemovedAgencyUS);
            Controls.Add(btnSearchAgencyUS);
            Controls.Add(txbIdCityDestination);
            Controls.Add(cboCityDestination);
            Controls.Add(lblCiudadDestino);
            Controls.Add(txbIdCityCrossPoint);
            Controls.Add(cboCityCrossPoint);
            Controls.Add(lblCiudadCruce);
            Controls.Add(txbIdGrower);
            Controls.Add(cboGrower);
            Controls.Add(lblProductor);
            Controls.Add(txbIdAgencyUS);
            Controls.Add(cboAgencyUS);
            Controls.Add(lblAgenciaUS);
            Controls.Add(txbIdAgencyMX);
            Controls.Add(cboAgencyMX);
            Controls.Add(lblAcenciaMX);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(cboManifestType);
            Controls.Add(cboActive);
            Controls.Add(lblLinea);
            Controls.Add(btnRemovedTransportLine);
            Controls.Add(btnSearchTransportLine);
            Controls.Add(txbIdTransportLine);
            Controls.Add(cboTransportLine);
            Controls.Add(txbId);
            Controls.Add(lblTitulo);
            Controls.Add(lblObliId);
            Controls.Add(lblId);
            Controls.Add(label15);
            Controls.Add(label19);
            Controls.Add(lblDieselLiters);
            Controls.Add(label13);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(834, 722);
            Name = "FrmManifiestoAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir Manifiesto";
            FormClosing += FrmManifiestoAñadir_FormClosing;
            Load += FrmManifiestoAñadir_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPalletList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblLinea;
        private Label lblId;
        private Button btnCancel;
        private Button btnAccept;
        public Label lblTitulo;
        public TextBox txbId;
        private Button btnRemovedTransportLine;
        private Button btnSearchTransportLine;
        public TextBox txbIdTransportLine;
        private ComboBox cboTransportLine;
        private Label lblObliId;
        public ComboBox cboActive;
        private Label Mercado;
        private Label lblObservaciones;
        private Button btnRemovePallet;
        private Button btnAddPallet;
        private Label label15;
        public TextBox txbIdPallet;
        public TextBox txbSeal3;
        public TextBox txbSeal2;
        private Label label14;
        public TextBox txbSeal1;
        public ComboBox cboTemperatureUnit;
        private Label label13;
        public TextBox txbTemperature;
        private Label label12;
        public TextBox txbTermoPosition;
        private Label label11;
        public TextBox txbTermograph;
        private Label label10;
        public ComboBox cboTransportType;
        private Label label9;
        public ComboBox cboTransportVehicle;
        private Button btnRemovedFreightContainer;
        private Button btnSearchFreightContainer;
        private Button btnRemovedTruck;
        private Button btnSearchTruck;
        private Button btnRemovedDriver;
        private Button btnSearchDriver;
        public TextBox txbIdFreightContainer;
        private ComboBox cboFreightContainer;
        private Label label5;
        public TextBox txbIdTruck;
        private ComboBox cboTruck;
        private Label label6;
        public TextBox txbIdDriver;
        public ComboBox cboDriver;
        private Label label8;
        private Label label4;
        public TextBox txbPurchaseOrder;
        private Label lblVisa;
        public TextBox txbBooking;
        public MaskedTextBox spnHour;
        private Button btnRemovedDistributor;
        private Button btnSearchDistributor;
        public TextBox txbIdDistributor;
        private ComboBox cboDistributor;
        private Label label3;
        private Button btnRemovedConsignee;
        private Button btnSearchConsignee;
        public TextBox txbIdConsignee;
        private ComboBox cboConsignee;
        private Label label16;
        private Button btnRemovedCityDestination;
        private Button btnSearchCityDestination;
        private Button btnRemovedCityCrossPoint;
        private Button btnSearchCityCrossPoint;
        private Button btnRemovedGrower;
        private Button btnSearchGrower;
        private Button btnRemovedAgencyMX;
        private Button btnSearchAgencyMX;
        private Button btnRemovedAgencyUS;
        private Button btnSearchAgencyUS;
        public TextBox txbIdCityDestination;
        private ComboBox cboCityDestination;
        private Label lblCiudadDestino;
        public TextBox txbIdCityCrossPoint;
        private ComboBox cboCityCrossPoint;
        private Label lblCiudadCruce;
        public TextBox txbIdGrower;
        private ComboBox cboGrower;
        private Label lblProductor;
        public TextBox txbIdAgencyUS;
        public ComboBox cboAgencyUS;
        private Label lblAgenciaUS;
        public TextBox txbIdAgencyMX;
        public ComboBox cboAgencyMX;
        private Label lblAcenciaMX;
        private Label label17;
        private Label label18;
        public ComboBox cboManifestType;
        private Label label7;
        public TextBox txbNameShipper;
        private Label label19;
        public TextBox txbNameOperator;
        public DateTimePicker dtpDate;
        public RichTextBox txbObservations;
        public CheckBox chkRejected;
        public DataGridView dgvPalletList;
        private Label lblPosicionPal;
        public TextBox txbPalletPosition;
        private Button btnPrintManifest;
        public TextBox txbDieselLiters;
        private Label lblDieselInvoice;
        public TextBox txbDieselInvoice;
        private Label lblDieselLiters;
        private CheckBox chkBoxPackingList;
        private Label label1;
        public TextBox txbPhytosanitary;
        private Button button1;
        public ComboBox cboSeason;
        private Label label2;
        public TextBox txbIdSeason;
    }
}
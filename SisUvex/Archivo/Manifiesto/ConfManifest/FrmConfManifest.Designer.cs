namespace SisUvex.Archivo.Manifiesto.ConfManifest
{
    partial class FrmConfManifest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfManifest));
            btnAccept = new Button();
            btnCancel = new Button();
            label3 = new Label();
            lblTitle = new Label();
            label1 = new Label();
            chbPrintMaping = new CheckBox();
            chbPrintManifest = new CheckBox();
            cboTransportType = new ComboBox();
            cboTransportVehicle = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            label20 = new Label();
            cboSeason = new ComboBox();
            label2 = new Label();
            cboTemperatureUnit = new ComboBox();
            label13 = new Label();
            chbPrintPackingList = new CheckBox();
            txbIdSeason = new TextBox();
            nudTemperature = new NumericUpDown();
            txbManifestFolderPath = new TextBox();
            label4 = new Label();
            btnManifestFolderPath = new Button();
            txbIdMarket = new TextBox();
            cboMarket = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudTemperature).BeginInit();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(124, 433);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(64, 25);
            btnAccept.TabIndex = 395;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(194, 433);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 25);
            btnCancel.TabIndex = 394;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label3.Location = new Point(76, 44);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 393;
            label3.Text = "Datos por defecto";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 12F);
            lblTitle.Location = new Point(21, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(231, 23);
            lblTitle.TabIndex = 392;
            lblTitle.Text = "Configuración manifiesto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label1.Location = new Point(58, 292);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 391;
            label1.Text = "Documentos a imprimir";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // chbPrintMaping
            // 
            chbPrintMaping.AutoSize = true;
            chbPrintMaping.Font = new Font("Microsoft Sans Serif", 9F);
            chbPrintMaping.Location = new Point(15, 327);
            chbPrintMaping.Name = "chbPrintMaping";
            chbPrintMaping.Size = new Size(137, 19);
            chbPrintMaping.TabIndex = 389;
            chbPrintMaping.Text = "Mapa de posiciones";
            chbPrintMaping.UseVisualStyleBackColor = true;
            // 
            // chbPrintManifest
            // 
            chbPrintManifest.AutoSize = true;
            chbPrintManifest.Font = new Font("Microsoft Sans Serif", 9F);
            chbPrintManifest.Location = new Point(15, 310);
            chbPrintManifest.Name = "chbPrintManifest";
            chbPrintManifest.Size = new Size(83, 19);
            chbPrintManifest.TabIndex = 388;
            chbPrintManifest.Text = "Manifiesto";
            chbPrintManifest.UseVisualStyleBackColor = true;
            // 
            // cboTransportType
            // 
            cboTransportType.Font = new Font("Microsoft Sans Serif", 9F);
            cboTransportType.FormattingEnabled = true;
            cboTransportType.Items.AddRange(new object[] { "", "TRAILER", "CAJA REFRIGERADA", "CONTENEDOR", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboTransportType.Location = new Point(13, 250);
            cboTransportType.Name = "cboTransportType";
            cboTransportType.Size = new Size(246, 23);
            cboTransportType.TabIndex = 386;
            // 
            // cboTransportVehicle
            // 
            cboTransportVehicle.Font = new Font("Microsoft Sans Serif", 9F);
            cboTransportVehicle.FormattingEnabled = true;
            cboTransportVehicle.Items.AddRange(new object[] { "", "TRAILER", "CONTENEDOR", "CAJA REFRIGERADA", "TRACTO CAMION", "CAMIONETA", "BARCO", "AVION", "TERRESTRE AEREO", "MARITIMO AEREO", "TERRESTRE MARITIMO" });
            cboTransportVehicle.Location = new Point(13, 206);
            cboTransportVehicle.Name = "cboTransportVehicle";
            cboTransportVehicle.Size = new Size(246, 23);
            cboTransportVehicle.TabIndex = 384;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F);
            label10.Location = new Point(11, 234);
            label10.Name = "label10";
            label10.Size = new Size(98, 15);
            label10.TabIndex = 387;
            label10.Text = "Segundo medio:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F);
            label9.Location = new Point(11, 190);
            label9.Name = "label9";
            label9.Size = new Size(120, 15);
            label9.TabIndex = 385;
            label9.Text = "Medio de transporte:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 9F);
            label20.Location = new Point(11, 59);
            label20.Name = "label20";
            label20.Size = new Size(59, 15);
            label20.TabIndex = 383;
            label20.Text = "Mercado:";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Microsoft Sans Serif", 9F);
            cboSeason.FormattingEnabled = true;
            cboSeason.Items.AddRange(new object[] { "E", "N" });
            cboSeason.Location = new Point(47, 121);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(212, 23);
            cboSeason.TabIndex = 380;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(11, 103);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 381;
            label2.Text = "Temporada:";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // cboTemperatureUnit
            // 
            cboTemperatureUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTemperatureUnit.Font = new Font("Microsoft Sans Serif", 9.5F);
            cboTemperatureUnit.FormattingEnabled = true;
            cboTemperatureUnit.Items.AddRange(new object[] { "F", "C", "K" });
            cboTemperatureUnit.Location = new Point(63, 164);
            cboTemperatureUnit.Name = "cboTemperatureUnit";
            cboTemperatureUnit.Size = new Size(33, 24);
            cboTemperatureUnit.TabIndex = 379;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9F);
            label13.Location = new Point(11, 147);
            label13.Name = "label13";
            label13.Size = new Size(50, 15);
            label13.TabIndex = 378;
            label13.Text = "Grados:";
            // 
            // chbPrintPackingList
            // 
            chbPrintPackingList.AutoSize = true;
            chbPrintPackingList.Font = new Font("Microsoft Sans Serif", 9F);
            chbPrintPackingList.Location = new Point(15, 344);
            chbPrintPackingList.Name = "chbPrintPackingList";
            chbPrintPackingList.Size = new Size(88, 19);
            chbPrintPackingList.TabIndex = 390;
            chbPrintPackingList.Text = "Packing list";
            chbPrintPackingList.UseVisualStyleBackColor = true;
            // 
            // txbIdSeason
            // 
            txbIdSeason.Enabled = false;
            txbIdSeason.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Bold);
            txbIdSeason.Location = new Point(13, 121);
            txbIdSeason.Name = "txbIdSeason";
            txbIdSeason.Size = new Size(28, 22);
            txbIdSeason.TabIndex = 396;
            txbIdSeason.TextAlign = HorizontalAlignment.Center;
            // 
            // nudTemperature
            // 
            nudTemperature.BorderStyle = BorderStyle.FixedSingle;
            nudTemperature.Font = new Font("Segoe UI", 9.5F);
            nudTemperature.Location = new Point(13, 164);
            nudTemperature.Name = "nudTemperature";
            nudTemperature.Size = new Size(45, 24);
            nudTemperature.TabIndex = 397;
            nudTemperature.TextAlign = HorizontalAlignment.Right;
            // 
            // txbManifestFolderPath
            // 
            txbManifestFolderPath.Location = new Point(13, 391);
            txbManifestFolderPath.Name = "txbManifestFolderPath";
            txbManifestFolderPath.Size = new Size(214, 23);
            txbManifestFolderPath.TabIndex = 398;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(11, 375);
            label4.Name = "label4";
            label4.Size = new Size(146, 15);
            label4.TabIndex = 399;
            label4.Text = "Ruta carpeta manifiestos:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // btnManifestFolderPath
            // 
            btnManifestFolderPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnManifestFolderPath.Image = Properties.Resources.fileIcon16;
            btnManifestFolderPath.Location = new Point(233, 390);
            btnManifestFolderPath.Name = "btnManifestFolderPath";
            btnManifestFolderPath.Size = new Size(26, 26);
            btnManifestFolderPath.TabIndex = 400;
            btnManifestFolderPath.UseVisualStyleBackColor = true;
            btnManifestFolderPath.Click += btnManifestFolderPath_Click;
            // 
            // txbIdMarket
            // 
            txbIdMarket.Enabled = false;
            txbIdMarket.Font = new Font("Microsoft Sans Serif", 9F);
            txbIdMarket.Location = new Point(12, 79);
            txbIdMarket.Name = "txbIdMarket";
            txbIdMarket.Size = new Size(29, 21);
            txbIdMarket.TabIndex = 403;
            txbIdMarket.TextAlign = HorizontalAlignment.Center;
            // 
            // cboMarket
            // 
            cboMarket.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarket.Font = new Font("Microsoft Sans Serif", 8.5F);
            cboMarket.FormattingEnabled = true;
            cboMarket.Location = new Point(47, 79);
            cboMarket.Name = "cboMarket";
            cboMarket.Size = new Size(213, 21);
            cboMarket.TabIndex = 401;
            // 
            // FrmConfManifest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 470);
            Controls.Add(txbIdMarket);
            Controls.Add(cboMarket);
            Controls.Add(btnManifestFolderPath);
            Controls.Add(txbManifestFolderPath);
            Controls.Add(nudTemperature);
            Controls.Add(txbIdSeason);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(chbPrintMaping);
            Controls.Add(chbPrintManifest);
            Controls.Add(cboTransportType);
            Controls.Add(cboTransportVehicle);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label20);
            Controls.Add(cboSeason);
            Controls.Add(label2);
            Controls.Add(cboTemperatureUnit);
            Controls.Add(label13);
            Controls.Add(chbPrintPackingList);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConfManifest";
            Text = "Configuración manifiesto";
            Load += FrmConfManifest_Load;
            ((System.ComponentModel.ISupportInitialize)nudTemperature).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        private Label label3;
        public Label lblTitle;
        private Label label1;
        public CheckBox chbPrintMaping;
        public CheckBox chbPrintManifest;
        public ComboBox cboTransportType;
        public ComboBox cboTransportVehicle;
        private Label label10;
        private Label label9;
        private Label label20;
        public ComboBox cboSeason;
        private Label label2;
        public ComboBox cboTemperatureUnit;
        private Label label13;
        public CheckBox chbPrintPackingList;
        public TextBox txbIdSeason;
        private NumericUpDown nudTemperature;
        private TextBox txbManifestFolderPath;
        private Label label4;
        private Button btnManifestFolderPath;
        public TextBox txbIdMarket;
        public ComboBox cboMarket;
    }
}
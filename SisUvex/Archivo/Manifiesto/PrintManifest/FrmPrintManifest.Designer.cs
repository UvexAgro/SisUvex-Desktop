namespace SisUvex.Archivo.Manifiesto.PrintManifest
{
    partial class FrmPrintManifest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintManifest));
            txbIdMarket = new TextBox();
            spnHour = new MaskedTextBox();
            label18 = new Label();
            cboMarket = new ComboBox();
            txbId = new TextBox();
            lblTitle = new Label();
            lblId = new Label();
            dtpDate = new DateTimePicker();
            label17 = new Label();
            label20 = new Label();
            txbIdTemplate = new TextBox();
            cboTemplate = new ComboBox();
            label21 = new Label();
            label1 = new Label();
            tglShowSize = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            tglManifest = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label2 = new Label();
            tglManifestPerFarm = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txbManifestFolderPath = new TextBox();
            label6 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            tglExcelLayout = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            tglMapping = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            tglPrintPackingList = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            label7 = new Label();
            btnChangePath = new Button();
            SuspendLayout();
            // 
            // txbIdMarket
            // 
            txbIdMarket.Enabled = false;
            txbIdMarket.Font = new Font("Microsoft Sans Serif", 12F);
            txbIdMarket.Location = new Point(102, 72);
            txbIdMarket.Name = "txbIdMarket";
            txbIdMarket.Size = new Size(37, 26);
            txbIdMarket.TabIndex = 365;
            txbIdMarket.TextAlign = HorizontalAlignment.Center;
            // 
            // spnHour
            // 
            spnHour.Enabled = false;
            spnHour.Font = new Font("Microsoft Sans Serif", 12F);
            spnHour.Location = new Point(411, 40);
            spnHour.Mask = "00:00";
            spnHour.Name = "spnHour";
            spnHour.Size = new Size(48, 26);
            spnHour.TabIndex = 367;
            spnHour.ValidatingType = typeof(DateTime);
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 12F);
            label18.Location = new Point(365, 43);
            label18.Name = "label18";
            label18.Size = new Size(48, 20);
            label18.TabIndex = 370;
            label18.Text = "Hora:";
            // 
            // cboMarket
            // 
            cboMarket.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarket.Enabled = false;
            cboMarket.Font = new Font("Microsoft Sans Serif", 12F);
            cboMarket.FormattingEnabled = true;
            cboMarket.Location = new Point(140, 71);
            cboMarket.Name = "cboMarket";
            cboMarket.Size = new Size(189, 28);
            cboMarket.TabIndex = 366;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Microsoft Sans Serif", 12F);
            txbId.ForeColor = Color.SteelBlue;
            txbId.Location = new Point(102, 40);
            txbId.Name = "txbId";
            txbId.Size = new Size(66, 26);
            txbId.TabIndex = 362;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Image = Properties.Resources.addFileIcon16;
            lblTitle.ImageAlign = ContentAlignment.MiddleLeft;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 20);
            lblTitle.TabIndex = 368;
            lblTitle.Text = "Descargar documetos";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Microsoft Sans Serif", 12F);
            lblId.Location = new Point(18, 43);
            lblId.Name = "lblId";
            lblId.Size = new Size(86, 20);
            lblId.TabIndex = 369;
            lblId.Text = "Manifiesto:";
            // 
            // dtpDate
            // 
            dtpDate.Enabled = false;
            dtpDate.Font = new Font("Microsoft Sans Serif", 12F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(237, 40);
            dtpDate.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(113, 26);
            dtpDate.TabIndex = 364;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 12F);
            label17.Location = new Point(179, 43);
            label17.Name = "label17";
            label17.Size = new Size(58, 20);
            label17.TabIndex = 371;
            label17.Text = "Fecha:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 12F);
            label20.Location = new Point(29, 75);
            label20.Name = "label20";
            label20.Size = new Size(75, 20);
            label20.TabIndex = 373;
            label20.Text = "Mercado:";
            // 
            // txbIdTemplate
            // 
            txbIdTemplate.Enabled = false;
            txbIdTemplate.Font = new Font("Microsoft Sans Serif", 12F);
            txbIdTemplate.Location = new Point(102, 105);
            txbIdTemplate.Name = "txbIdTemplate";
            txbIdTemplate.Size = new Size(37, 26);
            txbIdTemplate.TabIndex = 381;
            txbIdTemplate.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTemplate
            // 
            cboTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTemplate.Font = new Font("Microsoft Sans Serif", 12F);
            cboTemplate.FormattingEnabled = true;
            cboTemplate.ItemHeight = 20;
            cboTemplate.Location = new Point(140, 104);
            cboTemplate.Name = "cboTemplate";
            cboTemplate.Size = new Size(235, 28);
            cboTemplate.TabIndex = 382;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 12F);
            label21.Location = new Point(37, 107);
            label21.Name = "label21";
            label21.Size = new Size(67, 20);
            label21.TabIndex = 383;
            label21.Text = "Plantilla:";
            label21.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F);
            label1.Location = new Point(143, 140);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 384;
            label1.Text = "Mostrar tamaño";
            // 
            // tglShowSize
            // 
            tglShowSize.AnimationSpeed = 4;
            tglShowSize.Appearance = Appearance.Button;
            tglShowSize.BackColor = Color.Transparent;
            tglShowSize.BorderColor = Color.Empty;
            tglShowSize.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglShowSize.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglShowSize.Location = new Point(101, 138);
            tglShowSize.MinimumSize = new Size(20, 10);
            tglShowSize.Name = "tglShowSize";
            tglShowSize.OffBackColor = Color.LightGray;
            tglShowSize.OnBackColor = Color.FromArgb(92, 53, 142);
            tglShowSize.Size = new Size(38, 25);
            tglShowSize.TabIndex = 385;
            tglShowSize.Text = "toggleButton1";
            tglShowSize.ThumbInset = 1;
            tglShowSize.ToggleColor = Color.White;
            tglShowSize.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglShowSize.UseVisualStyleBackColor = false;
            // 
            // tglManifest
            // 
            tglManifest.AnimationSpeed = 4;
            tglManifest.Appearance = Appearance.Button;
            tglManifest.BackColor = Color.Transparent;
            tglManifest.BorderColor = Color.Empty;
            tglManifest.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglManifest.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglManifest.Location = new Point(101, 169);
            tglManifest.MinimumSize = new Size(20, 10);
            tglManifest.Name = "tglManifest";
            tglManifest.OffBackColor = Color.LightGray;
            tglManifest.OnBackColor = Color.FromArgb(92, 53, 142);
            tglManifest.Size = new Size(38, 25);
            tglManifest.TabIndex = 387;
            tglManifest.Text = "toggleButton2";
            tglManifest.ThumbInset = 1;
            tglManifest.ToggleColor = Color.White;
            tglManifest.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglManifest.UseVisualStyleBackColor = false;
            tglManifest.CheckedChanged += tglManifest_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F);
            label2.Location = new Point(143, 171);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 386;
            label2.Text = "Manifiesto";
            // 
            // tglManifestPerFarm
            // 
            tglManifestPerFarm.AnimationSpeed = 4;
            tglManifestPerFarm.Appearance = Appearance.Button;
            tglManifestPerFarm.BackColor = Color.Transparent;
            tglManifestPerFarm.BorderColor = Color.Empty;
            tglManifestPerFarm.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglManifestPerFarm.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglManifestPerFarm.Location = new Point(101, 200);
            tglManifestPerFarm.MinimumSize = new Size(20, 10);
            tglManifestPerFarm.Name = "tglManifestPerFarm";
            tglManifestPerFarm.OffBackColor = Color.LightGray;
            tglManifestPerFarm.OnBackColor = Color.FromArgb(92, 53, 142);
            tglManifestPerFarm.Size = new Size(38, 25);
            tglManifestPerFarm.TabIndex = 389;
            tglManifestPerFarm.Text = "toggleButton3";
            tglManifestPerFarm.ThumbInset = 1;
            tglManifestPerFarm.ToggleColor = Color.White;
            tglManifestPerFarm.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglManifestPerFarm.UseVisualStyleBackColor = false;
            tglManifestPerFarm.CheckedChanged += tglManifestPerFarm_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F);
            label3.Location = new Point(143, 202);
            label3.Name = "label3";
            label3.Size = new Size(161, 20);
            label3.TabIndex = 388;
            label3.Text = "Manifiesto por campo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F);
            label4.Location = new Point(143, 264);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 390;
            label4.Text = "Excel layout";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F);
            label5.Location = new Point(143, 233);
            label5.Name = "label5";
            label5.Size = new Size(150, 20);
            label5.TabIndex = 392;
            label5.Text = "Mapa de posiciones";
            // 
            // txbManifestFolderPath
            // 
            txbManifestFolderPath.Enabled = false;
            txbManifestFolderPath.Font = new Font("Microsoft Sans Serif", 12F);
            txbManifestFolderPath.Location = new Point(18, 342);
            txbManifestFolderPath.Name = "txbManifestFolderPath";
            txbManifestFolderPath.Size = new Size(410, 26);
            txbManifestFolderPath.TabIndex = 401;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F);
            label6.Location = new Point(15, 321);
            label6.Name = "label6";
            label6.Size = new Size(220, 20);
            label6.TabIndex = 402;
            label6.Text = "Ruta descarga en la carpeta*:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(283, 380);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(85, 30);
            btnAccept.TabIndex = 405;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(374, 380);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 30);
            btnCancel.TabIndex = 404;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // tglExcelLayout
            // 
            tglExcelLayout.AnimationSpeed = 4;
            tglExcelLayout.Appearance = Appearance.Button;
            tglExcelLayout.BackColor = Color.Transparent;
            tglExcelLayout.BorderColor = Color.Empty;
            tglExcelLayout.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglExcelLayout.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglExcelLayout.Location = new Point(101, 262);
            tglExcelLayout.MinimumSize = new Size(20, 10);
            tglExcelLayout.Name = "tglExcelLayout";
            tglExcelLayout.OffBackColor = Color.LightGray;
            tglExcelLayout.OnBackColor = Color.FromArgb(92, 53, 142);
            tglExcelLayout.Size = new Size(38, 25);
            tglExcelLayout.TabIndex = 407;
            tglExcelLayout.Text = "toggleButton4";
            tglExcelLayout.ThumbInset = 1;
            tglExcelLayout.ToggleColor = Color.White;
            tglExcelLayout.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglExcelLayout.UseVisualStyleBackColor = false;
            // 
            // tglMapping
            // 
            tglMapping.AnimationSpeed = 4;
            tglMapping.Appearance = Appearance.Button;
            tglMapping.BackColor = Color.Transparent;
            tglMapping.BorderColor = Color.Empty;
            tglMapping.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglMapping.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglMapping.Location = new Point(101, 231);
            tglMapping.MinimumSize = new Size(20, 10);
            tglMapping.Name = "tglMapping";
            tglMapping.OffBackColor = Color.LightGray;
            tglMapping.OnBackColor = Color.FromArgb(92, 53, 142);
            tglMapping.Size = new Size(38, 25);
            tglMapping.TabIndex = 406;
            tglMapping.Text = "toggleButton5";
            tglMapping.ThumbInset = 1;
            tglMapping.ToggleColor = Color.White;
            tglMapping.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglMapping.UseVisualStyleBackColor = false;
            // 
            // tglPrintPackingList
            // 
            tglPrintPackingList.AnimationSpeed = 4;
            tglPrintPackingList.Appearance = Appearance.Button;
            tglPrintPackingList.BackColor = Color.Transparent;
            tglPrintPackingList.BorderColor = Color.Empty;
            tglPrintPackingList.FocusBackColor = Color.FromArgb(202, 167, 243);
            tglPrintPackingList.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tglPrintPackingList.Location = new Point(102, 293);
            tglPrintPackingList.MinimumSize = new Size(20, 10);
            tglPrintPackingList.Name = "tglPrintPackingList";
            tglPrintPackingList.OffBackColor = Color.LightGray;
            tglPrintPackingList.OnBackColor = Color.FromArgb(92, 53, 142);
            tglPrintPackingList.Size = new Size(38, 25);
            tglPrintPackingList.TabIndex = 409;
            tglPrintPackingList.Text = "toggleButton6";
            tglPrintPackingList.ThumbInset = 1;
            tglPrintPackingList.ToggleColor = Color.White;
            tglPrintPackingList.ToggleShape = Cuadro_de_herramientas.ToggleButtonShape.RoundedRectangle;
            tglPrintPackingList.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F);
            label7.Location = new Point(144, 295);
            label7.Name = "label7";
            label7.Size = new Size(94, 20);
            label7.TabIndex = 408;
            label7.Text = "Packing List";
            // 
            // btnChangePath
            // 
            btnChangePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnChangePath.Image = Properties.Resources.fileIcon16;
            btnChangePath.Location = new Point(430, 341);
            btnChangePath.Name = "btnChangePath";
            btnChangePath.Size = new Size(29, 28);
            btnChangePath.TabIndex = 410;
            btnChangePath.UseVisualStyleBackColor = true;
            btnChangePath.Click += btnChangePath_Click;
            // 
            // FrmPrintManifest
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 422);
            Controls.Add(btnChangePath);
            Controls.Add(tglPrintPackingList);
            Controls.Add(label7);
            Controls.Add(tglExcelLayout);
            Controls.Add(tglMapping);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbManifestFolderPath);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tglManifestPerFarm);
            Controls.Add(label3);
            Controls.Add(tglManifest);
            Controls.Add(label2);
            Controls.Add(tglShowSize);
            Controls.Add(label1);
            Controls.Add(txbIdTemplate);
            Controls.Add(cboTemplate);
            Controls.Add(label21);
            Controls.Add(txbIdMarket);
            Controls.Add(spnHour);
            Controls.Add(label18);
            Controls.Add(cboMarket);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(dtpDate);
            Controls.Add(label17);
            Controls.Add(label20);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPrintManifest";
            Text = "Descargar documentos manifiesto";
            Load += FrmPrintManifest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txbIdMarket;
        public MaskedTextBox spnHour;
        private Label label18;
        public ComboBox cboMarket;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblId;
        public DateTimePicker dtpDate;
        private Label label17;
        private Label label20;
        public TextBox txbIdTemplate;
        public ComboBox cboTemplate;
        private Label label21;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnAccept;
        private Button btnCancel;
        private Label label7;
        public Cuadro_de_herramientas.ToggleButton tglShowSize;
        public Cuadro_de_herramientas.ToggleButton tglManifest;
        public Cuadro_de_herramientas.ToggleButton tglManifestPerFarm;
        public TextBox txbManifestFolderPath;
        public Cuadro_de_herramientas.ToggleButton tglExcelLayout;
        public Cuadro_de_herramientas.ToggleButton tglMapping;
        public Cuadro_de_herramientas.ToggleButton tglPrintPackingList;
        private Button btnChangePath;
    }
}

namespace SisUvex.Assets.Vehicle.Vehicle
{
    partial class FrmVehicleAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVehicleAdd));
            label4 = new Label();
            txbEcoNumber = new TextBox();
            label1 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            cboActive = new ComboBox();
            txbComments = new TextBox();
            label8 = new Label();
            txbMake = new TextBox();
            label5 = new Label();
            txbSerialNumber = new TextBox();
            label3 = new Label();
            lblTitle = new Label();
            txbId = new TextBox();
            lblObliName = new Label();
            label6 = new Label();
            lblMarket = new Label();
            label2 = new Label();
            lblName = new Label();
            lblId = new Label();
            cboPrefix = new ComboBox();
            label7 = new Label();
            txbYear = new TextBox();
            txbModel = new TextBox();
            label9 = new Label();
            txbPlates = new TextBox();
            label10 = new Label();
            chbGrowerRemoved = new CheckBox();
            txbIdGrower = new TextBox();
            cboGrower = new ComboBox();
            label12 = new Label();
            txbIdVehicleType = new TextBox();
            cboVehicleType = new ComboBox();
            label11 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 151);
            label4.Name = "label4";
            label4.Size = new Size(111, 21);
            label4.TabIndex = 154;
            label4.Text = "N° económico:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // txbEcoNumber
            // 
            txbEcoNumber.Font = new Font("Segoe UI", 12F);
            txbEcoNumber.Location = new Point(129, 148);
            txbEcoNumber.MaxLength = 12;
            txbEcoNumber.Name = "txbEcoNumber";
            txbEcoNumber.Size = new Size(119, 29);
            txbEcoNumber.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(119, 148);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 155;
            label1.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(369, 393);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 14;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(450, 393);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(240, 43);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 16;
            // 
            // txbComments
            // 
            txbComments.Font = new Font("Segoe UI", 12F);
            txbComments.Location = new Point(129, 323);
            txbComments.MaxLength = 200;
            txbComments.Name = "txbComments";
            txbComments.Size = new Size(396, 29);
            txbComments.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(23, 326);
            label8.Name = "label8";
            label8.Size = new Size(102, 21);
            label8.TabIndex = 149;
            label8.Text = "Comentarios:";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // txbMake
            // 
            txbMake.Font = new Font("Segoe UI", 12F);
            txbMake.Location = new Point(129, 218);
            txbMake.MaxLength = 20;
            txbMake.Name = "txbMake";
            txbMake.Size = new Size(155, 29);
            txbMake.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(68, 221);
            label5.Name = "label5";
            label5.Size = new Size(56, 21);
            label5.TabIndex = 147;
            label5.Text = "Marca:";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // txbSerialNumber
            // 
            txbSerialNumber.Font = new Font("Segoe UI", 12F);
            txbSerialNumber.Location = new Point(129, 288);
            txbSerialNumber.MaxLength = 50;
            txbSerialNumber.Name = "txbSerialNumber";
            txbSerialNumber.Size = new Size(396, 29);
            txbSerialNumber.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(77, 291);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 145;
            label3.Text = "Serie:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 31);
            lblTitle.TabIndex = 143;
            lblTitle.Text = "Añadir vehículo";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(129, 43);
            txbId.Name = "txbId";
            txbId.Size = new Size(43, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(119, 115);
            lblObliName.Margin = new Padding(0);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 140;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(120, 43);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 142;
            label6.Text = "*";
            // 
            // lblMarket
            // 
            lblMarket.AutoSize = true;
            lblMarket.Font = new Font("Segoe UI", 12F);
            lblMarket.Location = new Point(178, 46);
            lblMarket.Name = "lblMarket";
            lblMarket.Size = new Size(56, 21);
            lblMarket.TabIndex = 139;
            lblMarket.Text = "Activo:";
            lblMarket.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(231, 44);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 141;
            label2.Text = "*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(65, 116);
            lblName.Name = "lblName";
            lblName.Size = new Size(58, 21);
            lblName.TabIndex = 137;
            lblName.Text = "Prefijo:";
            lblName.TextAlign = ContentAlignment.TopRight;
            lblName.Click += lblName_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(98, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 138;
            lblId.Text = "Id:";
            lblId.TextAlign = ContentAlignment.TopRight;
            // 
            // cboPrefix
            // 
            cboPrefix.Font = new Font("Segoe UI", 12F);
            cboPrefix.FormattingEnabled = true;
            cboPrefix.Location = new Point(129, 113);
            cboPrefix.MaxLength = 8;
            cboPrefix.Name = "cboPrefix";
            cboPrefix.Size = new Size(119, 29);
            cboPrefix.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(290, 221);
            label7.Name = "label7";
            label7.Size = new Size(41, 21);
            label7.TabIndex = 157;
            label7.Text = "Año:";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // txbYear
            // 
            txbYear.Font = new Font("Segoe UI", 12F);
            txbYear.Location = new Point(337, 218);
            txbYear.MaxLength = 4;
            txbYear.Name = "txbYear";
            txbYear.Size = new Size(54, 29);
            txbYear.TabIndex = 7;
            // 
            // txbModel
            // 
            txbModel.Font = new Font("Segoe UI", 12F);
            txbModel.Location = new Point(129, 253);
            txbModel.MaxLength = 20;
            txbModel.Name = "txbModel";
            txbModel.Size = new Size(155, 29);
            txbModel.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(57, 256);
            label9.Name = "label9";
            label9.Size = new Size(66, 21);
            label9.TabIndex = 160;
            label9.Text = "Modelo:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // txbPlates
            // 
            txbPlates.Font = new Font("Segoe UI", 12F);
            txbPlates.Location = new Point(129, 183);
            txbPlates.MaxLength = 10;
            txbPlates.Name = "txbPlates";
            txbPlates.Size = new Size(155, 29);
            txbPlates.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(67, 186);
            label10.Name = "label10";
            label10.Size = new Size(56, 21);
            label10.TabIndex = 162;
            label10.Text = "Placas:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // chbGrowerRemoved
            // 
            chbGrowerRemoved.Appearance = Appearance.Button;
            chbGrowerRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbGrowerRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbGrowerRemoved.Font = new Font("Segoe UI", 10F);
            chbGrowerRemoved.Location = new Point(486, 358);
            chbGrowerRemoved.Name = "chbGrowerRemoved";
            chbGrowerRemoved.Size = new Size(39, 29);
            chbGrowerRemoved.TabIndex = 13;
            chbGrowerRemoved.Text = "     ";
            chbGrowerRemoved.UseVisualStyleBackColor = true;
            // 
            // txbIdGrower
            // 
            txbIdGrower.Enabled = false;
            txbIdGrower.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdGrower.Location = new Point(129, 358);
            txbIdGrower.Name = "txbIdGrower";
            txbIdGrower.Size = new Size(43, 29);
            txbIdGrower.TabIndex = 11;
            txbIdGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.Font = new Font("Segoe UI", 12F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 21;
            cboGrower.Location = new Point(178, 358);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(302, 29);
            cboGrower.TabIndex = 12;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(41, 361);
            label12.Name = "label12";
            label12.Size = new Size(82, 21);
            label12.TabIndex = 476;
            label12.Text = "Productor:";
            label12.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdVehicleType
            // 
            txbIdVehicleType.Enabled = false;
            txbIdVehicleType.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdVehicleType.Location = new Point(129, 78);
            txbIdVehicleType.Name = "txbIdVehicleType";
            txbIdVehicleType.Size = new Size(43, 29);
            txbIdVehicleType.TabIndex = 1;
            txbIdVehicleType.TextAlign = HorizontalAlignment.Center;
            // 
            // cboVehicleType
            // 
            cboVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVehicleType.Font = new Font("Segoe UI", 12F);
            cboVehicleType.FormattingEnabled = true;
            cboVehicleType.ItemHeight = 21;
            cboVehicleType.Location = new Point(178, 78);
            cboVehicleType.Name = "cboVehicleType";
            cboVehicleType.Size = new Size(302, 29);
            cboVehicleType.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(80, 81);
            label11.Name = "label11";
            label11.Size = new Size(43, 21);
            label11.TabIndex = 480;
            label11.Text = "Tipo:";
            label11.TextAlign = ContentAlignment.TopRight;
            // 
            // FrmVehicleAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 433);
            Controls.Add(txbIdVehicleType);
            Controls.Add(cboVehicleType);
            Controls.Add(label11);
            Controls.Add(chbGrowerRemoved);
            Controls.Add(txbIdGrower);
            Controls.Add(cboGrower);
            Controls.Add(label12);
            Controls.Add(txbPlates);
            Controls.Add(label10);
            Controls.Add(txbModel);
            Controls.Add(label9);
            Controls.Add(txbYear);
            Controls.Add(label7);
            Controls.Add(cboPrefix);
            Controls.Add(label4);
            Controls.Add(txbEcoNumber);
            Controls.Add(label1);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(cboActive);
            Controls.Add(txbComments);
            Controls.Add(label8);
            Controls.Add(txbMake);
            Controls.Add(label5);
            Controls.Add(txbSerialNumber);
            Controls.Add(label3);
            Controls.Add(lblTitle);
            Controls.Add(txbId);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblMarket);
            Controls.Add(label2);
            Controls.Add(lblName);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVehicleAdd";
            Text = "Añadir vehículo";
            Load += FrmVehicleAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        public TextBox txbEcoNumber;
        private Label label1;
        private Button btnAccept;
        private Button btnCancel;
        public ComboBox cboActive;
        public TextBox txbComments;
        private Label label8;
        public TextBox txbMake;
        private Label label5;
        public TextBox txbSerialNumber;
        private Label label3;
        public Label lblTitle;
        public TextBox txbId;
        private Label lblObliName;
        private Label label6;
        private Label lblMarket;
        private Label label2;
        private Label lblName;
        private Label lblId;
        public ComboBox cboPrefix;
        private Label label7;
        public TextBox txbYear;
        public TextBox txbModel;
        private Label label9;
        public TextBox txbPlates;
        private Label label10;
        public CheckBox chbGrowerRemoved;
        public TextBox txbIdGrower;
        public ComboBox cboGrower;
        private Label label12;
        public TextBox txbIdVehicleType;
        public ComboBox cboVehicleType;
        private Label label11;
    }
}
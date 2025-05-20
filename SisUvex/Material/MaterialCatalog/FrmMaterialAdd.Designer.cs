namespace SisUvex.Material.MaterialCatalog
{
    partial class FrmMaterialAdd
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
                cls.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialAdd));
            chbCategoryRemoved = new CheckBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbIdColor = new TextBox();
            cboColor = new ComboBox();
            lblColor = new Label();
            txbIdCategory = new TextBox();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            cboActive = new ComboBox();
            txbId = new TextBox();
            txbName = new TextBox();
            lblName = new Label();
            lblTitle = new Label();
            lblObliName = new Label();
            label6 = new Label();
            lblId = new Label();
            lblMarket = new Label();
            label2 = new Label();
            chbDistributorRemoved = new CheckBox();
            txbIdDistributor = new TextBox();
            cboDistributor = new ComboBox();
            label1 = new Label();
            pbxMaterial = new PictureBox();
            txbIdMaterialType = new TextBox();
            cboMaterialType = new ComboBox();
            label5 = new Label();
            label7 = new Label();
            label4 = new Label();
            txbIdUnit = new TextBox();
            cboUnit = new ComboBox();
            label10 = new Label();
            txbQuant = new TextBox();
            label9 = new Label();
            btnPictureAdd = new Button();
            chbImageBack = new CheckBox();
            chbImageFront = new CheckBox();
            chbImageUp = new CheckBox();
            chbImageDown = new CheckBox();
            btnRefreshImages = new Button();
            btnDeleteImage = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxMaterial).BeginInit();
            SuspendLayout();
            // 
            // chbCategoryRemoved
            // 
            chbCategoryRemoved.Appearance = Appearance.Button;
            chbCategoryRemoved.AutoSize = true;
            chbCategoryRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbCategoryRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbCategoryRemoved.Font = new Font("Segoe UI", 10F);
            chbCategoryRemoved.Location = new Point(553, 263);
            chbCategoryRemoved.Name = "chbCategoryRemoved";
            chbCategoryRemoved.Size = new Size(39, 29);
            chbCategoryRemoved.TabIndex = 9;
            chbCategoryRemoved.Text = "     ";
            chbCategoryRemoved.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(436, 368);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 22;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(517, 368);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbIdColor
            // 
            txbIdColor.Enabled = false;
            txbIdColor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdColor.Location = new Point(112, 332);
            txbIdColor.Name = "txbIdColor";
            txbIdColor.Size = new Size(43, 29);
            txbIdColor.TabIndex = 13;
            txbIdColor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboColor
            // 
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.Font = new Font("Segoe UI", 12F);
            cboColor.FormattingEnabled = true;
            cboColor.ItemHeight = 21;
            cboColor.Location = new Point(161, 333);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(388, 29);
            cboColor.TabIndex = 14;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 12F);
            lblColor.Location = new Point(56, 334);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(51, 21);
            lblColor.TabIndex = 92;
            lblColor.Text = "Color:";
            lblColor.TextAlign = ContentAlignment.TopRight;
            // 
            // txbIdCategory
            // 
            txbIdCategory.Enabled = false;
            txbIdCategory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdCategory.Location = new Point(112, 262);
            txbIdCategory.Name = "txbIdCategory";
            txbIdCategory.Size = new Size(43, 29);
            txbIdCategory.TabIndex = 7;
            txbIdCategory.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 12F);
            cboCategory.FormattingEnabled = true;
            cboCategory.ItemHeight = 21;
            cboCategory.Location = new Point(161, 263);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(388, 29);
            cboCategory.TabIndex = 8;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 12F);
            lblCategory.Location = new Point(27, 265);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(80, 21);
            lblCategory.TabIndex = 90;
            lblCategory.Text = "Categoría:";
            lblCategory.TextAlign = ContentAlignment.TopRight;
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(264, 122);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(51, 29);
            cboActive.TabIndex = 0;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(112, 121);
            txbId.Name = "txbId";
            txbId.Size = new Size(84, 29);
            txbId.TabIndex = 71;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(112, 192);
            txbName.MaxLength = 200;
            txbName.Name = "txbName";
            txbName.Size = new Size(437, 29);
            txbName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(28, 194);
            lblName.Name = "lblName";
            lblName.Size = new Size(79, 21);
            lblName.TabIndex = 84;
            lblName.Text = "Concepto:";
            lblName.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 31);
            lblTitle.TabIndex = 83;
            lblTitle.Text = "Añadir material";
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(103, 194);
            lblObliName.Margin = new Padding(0);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 87;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(103, 121);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 96;
            label6.Text = "*";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(81, 123);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 85;
            lblId.Text = "Id:";
            lblId.TextAlign = ContentAlignment.TopRight;
            // 
            // lblMarket
            // 
            lblMarket.AutoSize = true;
            lblMarket.Font = new Font("Segoe UI", 12F);
            lblMarket.Location = new Point(202, 125);
            lblMarket.Name = "lblMarket";
            lblMarket.Size = new Size(56, 21);
            lblMarket.TabIndex = 86;
            lblMarket.Text = "Activo:";
            lblMarket.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(255, 123);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 89;
            label2.Text = "*";
            // 
            // chbDistributorRemoved
            // 
            chbDistributorRemoved.Appearance = Appearance.Button;
            chbDistributorRemoved.AutoSize = true;
            chbDistributorRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbDistributorRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbDistributorRemoved.Font = new Font("Segoe UI", 10F);
            chbDistributorRemoved.Location = new Point(553, 298);
            chbDistributorRemoved.Name = "chbDistributorRemoved";
            chbDistributorRemoved.Size = new Size(39, 29);
            chbDistributorRemoved.TabIndex = 12;
            chbDistributorRemoved.Text = "     ";
            chbDistributorRemoved.UseVisualStyleBackColor = true;
            // 
            // txbIdDistributor
            // 
            txbIdDistributor.Enabled = false;
            txbIdDistributor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdDistributor.Location = new Point(112, 297);
            txbIdDistributor.Name = "txbIdDistributor";
            txbIdDistributor.Size = new Size(43, 29);
            txbIdDistributor.TabIndex = 10;
            txbIdDistributor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboDistributor
            // 
            cboDistributor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistributor.Font = new Font("Segoe UI", 12F);
            cboDistributor.FormattingEnabled = true;
            cboDistributor.ItemHeight = 21;
            cboDistributor.Location = new Point(161, 298);
            cboDistributor.Name = "cboDistributor";
            cboDistributor.Size = new Size(388, 29);
            cboDistributor.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(11, 300);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 100;
            label1.Text = "Distribuidor:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // pbxMaterial
            // 
            pbxMaterial.BorderStyle = BorderStyle.FixedSingle;
            pbxMaterial.Location = new Point(417, 19);
            pbxMaterial.Name = "pbxMaterial";
            pbxMaterial.Size = new Size(132, 132);
            pbxMaterial.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMaterial.TabIndex = 107;
            pbxMaterial.TabStop = false;
            // 
            // txbIdMaterialType
            // 
            txbIdMaterialType.Enabled = false;
            txbIdMaterialType.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdMaterialType.Location = new Point(112, 157);
            txbIdMaterialType.Name = "txbIdMaterialType";
            txbIdMaterialType.Size = new Size(43, 29);
            txbIdMaterialType.TabIndex = 1;
            txbIdMaterialType.TextAlign = HorizontalAlignment.Center;
            txbIdMaterialType.TextChanged += txbIdMaterialType_TextChanged;
            // 
            // cboMaterialType
            // 
            cboMaterialType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterialType.Font = new Font("Segoe UI", 12F);
            cboMaterialType.FormattingEnabled = true;
            cboMaterialType.ItemHeight = 21;
            cboMaterialType.Location = new Point(161, 158);
            cboMaterialType.Name = "cboMaterialType";
            cboMaterialType.Size = new Size(388, 29);
            cboMaterialType.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(103, 157);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 458;
            label5.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(64, 161);
            label7.Name = "label7";
            label7.Size = new Size(43, 21);
            label7.TabIndex = 457;
            label7.Text = "Tipo:";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(296, 227);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 464;
            label4.Text = "*";
            // 
            // txbIdUnit
            // 
            txbIdUnit.Enabled = false;
            txbIdUnit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdUnit.Location = new Point(305, 227);
            txbIdUnit.Name = "txbIdUnit";
            txbIdUnit.Size = new Size(43, 29);
            txbIdUnit.TabIndex = 5;
            txbIdUnit.TextAlign = HorizontalAlignment.Center;
            // 
            // cboUnit
            // 
            cboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnit.Font = new Font("Segoe UI", 12F);
            cboUnit.FormattingEnabled = true;
            cboUnit.ItemHeight = 21;
            cboUnit.Location = new Point(354, 227);
            cboUnit.Name = "cboUnit";
            cboUnit.Size = new Size(195, 29);
            cboUnit.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(236, 230);
            label10.Name = "label10";
            label10.Size = new Size(63, 21);
            label10.TabIndex = 462;
            label10.Text = "Unidad:";
            label10.TextAlign = ContentAlignment.TopRight;
            // 
            // txbQuant
            // 
            txbQuant.Font = new Font("Segoe UI", 12F);
            txbQuant.Location = new Point(112, 227);
            txbQuant.MaxLength = 10;
            txbQuant.Name = "txbQuant";
            txbQuant.Size = new Size(118, 29);
            txbQuant.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(32, 230);
            label9.Name = "label9";
            label9.Size = new Size(75, 21);
            label9.TabIndex = 460;
            label9.Text = "Cantidad:";
            label9.TextAlign = ContentAlignment.TopRight;
            // 
            // btnPictureAdd
            // 
            btnPictureAdd.Image = Properties.Resources.addImageIcon16;
            btnPictureAdd.Location = new Point(555, 131);
            btnPictureAdd.Name = "btnPictureAdd";
            btnPictureAdd.Size = new Size(22, 22);
            btnPictureAdd.TabIndex = 19;
            btnPictureAdd.UseVisualStyleBackColor = true;
            btnPictureAdd.Click += btnPictureAdd_Click;
            // 
            // chbImageBack
            // 
            chbImageBack.Appearance = Appearance.Button;
            chbImageBack.BackgroundImageLayout = ImageLayout.Stretch;
            chbImageBack.Font = new Font("Segoe UI", 8.25F);
            chbImageBack.Location = new Point(555, 47);
            chbImageBack.Name = "chbImageBack";
            chbImageBack.Size = new Size(65, 25);
            chbImageBack.TabIndex = 16;
            chbImageBack.Text = "Atrás";
            chbImageBack.TextAlign = ContentAlignment.MiddleCenter;
            chbImageBack.UseVisualStyleBackColor = true;
            chbImageBack.Click += chbImageBack_Click;
            // 
            // chbImageFront
            // 
            chbImageFront.Appearance = Appearance.Button;
            chbImageFront.BackgroundImageLayout = ImageLayout.Stretch;
            chbImageFront.Font = new Font("Segoe UI", 8.25F);
            chbImageFront.Location = new Point(555, 19);
            chbImageFront.Name = "chbImageFront";
            chbImageFront.Size = new Size(65, 25);
            chbImageFront.TabIndex = 15;
            chbImageFront.Text = "Frente";
            chbImageFront.TextAlign = ContentAlignment.MiddleCenter;
            chbImageFront.UseVisualStyleBackColor = true;
            chbImageFront.Click += chbImageFront_Click;
            // 
            // chbImageUp
            // 
            chbImageUp.Appearance = Appearance.Button;
            chbImageUp.BackgroundImageLayout = ImageLayout.Stretch;
            chbImageUp.Font = new Font("Segoe UI", 8.25F);
            chbImageUp.Location = new Point(555, 103);
            chbImageUp.Name = "chbImageUp";
            chbImageUp.Size = new Size(65, 25);
            chbImageUp.TabIndex = 18;
            chbImageUp.Text = "Arriba";
            chbImageUp.TextAlign = ContentAlignment.MiddleCenter;
            chbImageUp.UseVisualStyleBackColor = true;
            chbImageUp.Click += chbImageUp_Click;
            // 
            // chbImageDown
            // 
            chbImageDown.Appearance = Appearance.Button;
            chbImageDown.BackgroundImageLayout = ImageLayout.Stretch;
            chbImageDown.Font = new Font("Segoe UI", 8.25F);
            chbImageDown.Location = new Point(555, 75);
            chbImageDown.Name = "chbImageDown";
            chbImageDown.Size = new Size(65, 25);
            chbImageDown.TabIndex = 17;
            chbImageDown.Text = "Abajo";
            chbImageDown.TextAlign = ContentAlignment.MiddleCenter;
            chbImageDown.UseVisualStyleBackColor = true;
            chbImageDown.Click += chbImageDown_Click;
            // 
            // btnRefreshImages
            // 
            btnRefreshImages.Image = Properties.Resources.reiniciarMini;
            btnRefreshImages.Location = new Point(576, 131);
            btnRefreshImages.Margin = new Padding(0);
            btnRefreshImages.Name = "btnRefreshImages";
            btnRefreshImages.Size = new Size(22, 22);
            btnRefreshImages.TabIndex = 20;
            btnRefreshImages.UseVisualStyleBackColor = true;
            btnRefreshImages.Click += btnRefreshImages_Click;
            // 
            // btnDeleteImage
            // 
            btnDeleteImage.Image = Properties.Resources.basuraIcon16;
            btnDeleteImage.Location = new Point(597, 131);
            btnDeleteImage.Margin = new Padding(0);
            btnDeleteImage.Name = "btnDeleteImage";
            btnDeleteImage.Size = new Size(22, 22);
            btnDeleteImage.TabIndex = 21;
            btnDeleteImage.UseVisualStyleBackColor = true;
            btnDeleteImage.Click += btnDeleteImage_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(104, 298);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 472;
            label3.Text = "*";
            // 
            // FrmMaterialAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 407);
            Controls.Add(btnDeleteImage);
            Controls.Add(btnRefreshImages);
            Controls.Add(chbImageUp);
            Controls.Add(chbImageDown);
            Controls.Add(chbImageBack);
            Controls.Add(chbImageFront);
            Controls.Add(btnPictureAdd);
            Controls.Add(txbIdUnit);
            Controls.Add(cboUnit);
            Controls.Add(label10);
            Controls.Add(txbQuant);
            Controls.Add(label9);
            Controls.Add(txbIdMaterialType);
            Controls.Add(cboMaterialType);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(pbxMaterial);
            Controls.Add(chbDistributorRemoved);
            Controls.Add(txbIdDistributor);
            Controls.Add(cboDistributor);
            Controls.Add(chbCategoryRemoved);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbIdColor);
            Controls.Add(cboColor);
            Controls.Add(txbIdCategory);
            Controls.Add(cboCategory);
            Controls.Add(cboActive);
            Controls.Add(txbId);
            Controls.Add(txbName);
            Controls.Add(lblTitle);
            Controls.Add(lblObliName);
            Controls.Add(label6);
            Controls.Add(lblMarket);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblColor);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Controls.Add(lblId);
            Controls.Add(label3);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMaterialAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir material";
            Load += FrmMaterialAdd_Load;
            ((System.ComponentModel.ISupportInitialize)pbxMaterial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CheckBox chbCategoryRemoved;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbIdColor;
        public ComboBox cboColor;
        private Label lblColor;
        public TextBox txbIdCategory;
        public ComboBox cboCategory;
        private Label lblCategory;
        public ComboBox cboActive;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblName;
        public Label lblTitle;
        private Label lblObliName;
        private Label label6;
        private Label lblId;
        private Label lblMarket;
        private Label label2;
        public CheckBox chbDistributorRemoved;
        public TextBox txbIdDistributor;
        public ComboBox cboDistributor;
        private Label label1;
        private PictureBox pictureBox1;
        public TextBox txbIdMaterialType;
        public ComboBox cboMaterialType;
        private Label label5;
        private Label label7;
        private Label label4;
        public TextBox txbIdUnit;
        public ComboBox cboUnit;
        private Label label10;
        public TextBox txbQuant;
        private Label label9;
        private Button btnPictureAdd;
        public PictureBox pbxMaterial;
        public CheckBox chbImageBack;
        public CheckBox chbImageFront;
        public CheckBox chbImageUp;
        public CheckBox chbImageDown;
        private Button btnRefreshImages;
        private Button btnDeleteImage;
        private Label label3;
    }
}
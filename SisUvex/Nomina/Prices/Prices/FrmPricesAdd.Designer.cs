namespace SisUvex.Nomina.Prices.Prices
{
    partial class FrmPricesAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPricesAdd));
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            txbDescription = new TextBox();
            lblDescription = new Label();
            lblTitle = new Label();
            lblId = new Label();
            lblObliCom = new Label();
            nudPriceFieldNormal = new NumericUpDown();
            lblFieldNormal = new Label();
            gpbField = new GroupBox();
            nudPriceFieldOver = new NumericUpDown();
            label1 = new Label();
            groupBox1 = new GroupBox();
            nudPriceFacilityOver = new NumericUpDown();
            lblFacilityOver = new Label();
            nudPriceFacilityNormal = new NumericUpDown();
            lblFacilityNormal = new Label();
            ((System.ComponentModel.ISupportInitialize)nudPriceFieldNormal).BeginInit();
            gpbField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceFieldOver).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceFacilityOver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFacilityNormal).BeginInit();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(339, 212);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 6;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(420, 212);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(449, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbDescription
            // 
            txbDescription.Font = new Font("Segoe UI", 12F);
            txbDescription.Location = new Point(115, 55);
            txbDescription.MaxLength = 25;
            txbDescription.Name = "txbDescription";
            txbDescription.Size = new Size(380, 29);
            txbDescription.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F);
            lblDescription.Location = new Point(15, 58);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(94, 21);
            lblDescription.TabIndex = 15;
            lblDescription.Text = "Descripción:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(177, 31);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "Añadir precio";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(421, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 18;
            lblId.Text = "Id:";
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(469, 55);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 23;
            lblObliCom.Text = "*";
            // 
            // nudPriceFieldNormal
            // 
            nudPriceFieldNormal.DecimalPlaces = 2;
            nudPriceFieldNormal.Font = new Font("Segoe UI", 12F);
            nudPriceFieldNormal.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPriceFieldNormal.Location = new Point(132, 28);
            nudPriceFieldNormal.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPriceFieldNormal.Name = "nudPriceFieldNormal";
            nudPriceFieldNormal.Size = new Size(76, 29);
            nudPriceFieldNormal.TabIndex = 2;
            nudPriceFieldNormal.TextAlign = HorizontalAlignment.Right;
            // 
            // lblFieldNormal
            // 
            lblFieldNormal.AutoSize = true;
            lblFieldNormal.Font = new Font("Segoe UI", 12F);
            lblFieldNormal.Location = new Point(6, 30);
            lblFieldNormal.Name = "lblFieldNormal";
            lblFieldNormal.Size = new Size(120, 21);
            lblFieldNormal.TabIndex = 25;
            lblFieldNormal.Text = "Horario normal:";
            // 
            // gpbField
            // 
            gpbField.Controls.Add(nudPriceFieldOver);
            gpbField.Controls.Add(label1);
            gpbField.Controls.Add(nudPriceFieldNormal);
            gpbField.Controls.Add(lblFieldNormal);
            gpbField.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gpbField.Location = new Point(15, 90);
            gpbField.Name = "gpbField";
            gpbField.Size = new Size(229, 110);
            gpbField.TabIndex = 26;
            gpbField.TabStop = false;
            gpbField.Text = "Precios en campo";
            // 
            // nudPriceFieldOver
            // 
            nudPriceFieldOver.DecimalPlaces = 2;
            nudPriceFieldOver.Font = new Font("Segoe UI", 12F);
            nudPriceFieldOver.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPriceFieldOver.Location = new Point(132, 63);
            nudPriceFieldOver.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPriceFieldOver.Name = "nudPriceFieldOver";
            nudPriceFieldOver.Size = new Size(76, 29);
            nudPriceFieldOver.TabIndex = 3;
            nudPriceFieldOver.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(22, 65);
            label1.Name = "label1";
            label1.Size = new Size(104, 21);
            label1.TabIndex = 27;
            label1.Text = "Horario extra:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nudPriceFacilityOver);
            groupBox1.Controls.Add(lblFacilityOver);
            groupBox1.Controls.Add(nudPriceFacilityNormal);
            groupBox1.Controls.Add(lblFacilityNormal);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(266, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(229, 110);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Precios en empaque";
            // 
            // nudPriceFacilityOver
            // 
            nudPriceFacilityOver.DecimalPlaces = 2;
            nudPriceFacilityOver.Font = new Font("Segoe UI", 12F);
            nudPriceFacilityOver.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPriceFacilityOver.Location = new Point(132, 63);
            nudPriceFacilityOver.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPriceFacilityOver.Name = "nudPriceFacilityOver";
            nudPriceFacilityOver.Size = new Size(76, 29);
            nudPriceFacilityOver.TabIndex = 5;
            nudPriceFacilityOver.TextAlign = HorizontalAlignment.Right;
            // 
            // lblFacilityOver
            // 
            lblFacilityOver.AutoSize = true;
            lblFacilityOver.Font = new Font("Segoe UI", 12F);
            lblFacilityOver.Location = new Point(22, 65);
            lblFacilityOver.Name = "lblFacilityOver";
            lblFacilityOver.Size = new Size(104, 21);
            lblFacilityOver.TabIndex = 27;
            lblFacilityOver.Text = "Horario extra:";
            // 
            // nudPriceFacilityNormal
            // 
            nudPriceFacilityNormal.DecimalPlaces = 2;
            nudPriceFacilityNormal.Font = new Font("Segoe UI", 12F);
            nudPriceFacilityNormal.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPriceFacilityNormal.Location = new Point(132, 28);
            nudPriceFacilityNormal.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPriceFacilityNormal.Name = "nudPriceFacilityNormal";
            nudPriceFacilityNormal.Size = new Size(76, 29);
            nudPriceFacilityNormal.TabIndex = 4;
            nudPriceFacilityNormal.TextAlign = HorizontalAlignment.Right;
            // 
            // lblFacilityNormal
            // 
            lblFacilityNormal.AutoSize = true;
            lblFacilityNormal.Font = new Font("Segoe UI", 12F);
            lblFacilityNormal.Location = new Point(6, 30);
            lblFacilityNormal.Name = "lblFacilityNormal";
            lblFacilityNormal.Size = new Size(120, 21);
            lblFacilityNormal.TabIndex = 25;
            lblFacilityNormal.Text = "Horario normal:";
            // 
            // FrmPricesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 257);
            Controls.Add(groupBox1);
            Controls.Add(gpbField);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(txbDescription);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(lblObliCom);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPricesAdd";
            Text = "Añadir precio";
            Load += FrmPricesAdd_Load;
            ((System.ComponentModel.ISupportInitialize)nudPriceFieldNormal).EndInit();
            gpbField.ResumeLayout(false);
            gpbField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceFieldOver).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriceFacilityOver).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPriceFacilityNormal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public TextBox txbDescription;
        private Label lblDescription;
        public Label lblTitle;
        private Label lblId;
        private Label lblObliCom;
        private Label lblFieldNormal;
        private GroupBox gpbField;
        private Label label1;
        private GroupBox groupBox1;
        private Label lblFacilityOver;
        private Label lblFacilityNormal;
        public NumericUpDown nudPriceFieldNormal;
        public NumericUpDown nudPriceFieldOver;
        public NumericUpDown nudPriceFacilityOver;
        public NumericUpDown nudPriceFacilityNormal;
    }
}
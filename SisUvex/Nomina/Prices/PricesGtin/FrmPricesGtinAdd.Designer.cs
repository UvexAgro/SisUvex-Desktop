namespace SisUvex.Nomina.Prices.PricesGtin
{
    partial class FrmPricesGtinAdd
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
            lblTitle = new Label();
            txbId = new TextBox();
            lblPrice = new Label();
            txbDescription = new TextBox();
            gpbField = new GroupBox();
            txbFieldOver = new TextBox();
            txbFieldNormal = new TextBox();
            label1 = new Label();
            lblFieldNormal = new Label();
            gpbFacility = new GroupBox();
            txbFacilityOver = new TextBox();
            txbFacilityNormal = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dgvPricesGtinAdd = new DataGridView();
            btnAccept = new Button();
            btnCancel = new Button();
            gpbField.SuspendLayout();
            gpbFacility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPricesGtinAdd).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(410, 31);
            lblTitle.TabIndex = 28;
            lblTitle.Text = "Asignar precio a productos GTIN";
            // 
            // txbId
            // 
            txbId.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbId.Location = new Point(73, 46);
            txbId.Name = "txbId";
            txbId.ReadOnly = true;
            txbId.Size = new Size(29, 24);
            txbId.TabIndex = 29;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblPrice.Location = new Point(12, 49);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(55, 18);
            lblPrice.TabIndex = 30;
            lblPrice.Text = "Precio:";
            // 
            // txbDescription
            // 
            txbDescription.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbDescription.Location = new Point(108, 46);
            txbDescription.MaxLength = 25;
            txbDescription.Name = "txbDescription";
            txbDescription.ReadOnly = true;
            txbDescription.Size = new Size(543, 24);
            txbDescription.TabIndex = 32;
            // 
            // gpbField
            // 
            gpbField.Controls.Add(txbFieldOver);
            gpbField.Controls.Add(txbFieldNormal);
            gpbField.Controls.Add(label1);
            gpbField.Controls.Add(lblFieldNormal);
            gpbField.Font = new Font("Microsoft Sans Serif", 11.25F);
            gpbField.Location = new Point(12, 76);
            gpbField.Name = "gpbField";
            gpbField.Size = new Size(356, 55);
            gpbField.TabIndex = 33;
            gpbField.TabStop = false;
            gpbField.Text = "Precios en campo";
            // 
            // txbFieldOver
            // 
            txbFieldOver.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFieldOver.Location = new Point(286, 19);
            txbFieldOver.MaxLength = 25;
            txbFieldOver.Name = "txbFieldOver";
            txbFieldOver.ReadOnly = true;
            txbFieldOver.Size = new Size(61, 24);
            txbFieldOver.TabIndex = 35;
            // 
            // txbFieldNormal
            // 
            txbFieldNormal.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFieldNormal.Location = new Point(118, 19);
            txbFieldNormal.MaxLength = 25;
            txbFieldNormal.Name = "txbFieldNormal";
            txbFieldNormal.ReadOnly = true;
            txbFieldNormal.Size = new Size(61, 24);
            txbFieldNormal.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(185, 20);
            label1.Name = "label1";
            label1.Size = new Size(104, 21);
            label1.TabIndex = 27;
            label1.Text = "Horario extra:";
            // 
            // lblFieldNormal
            // 
            lblFieldNormal.AutoSize = true;
            lblFieldNormal.Font = new Font("Segoe UI", 12F);
            lblFieldNormal.Location = new Point(2, 20);
            lblFieldNormal.Name = "lblFieldNormal";
            lblFieldNormal.Size = new Size(120, 21);
            lblFieldNormal.TabIndex = 25;
            lblFieldNormal.Text = "Horario normal:";
            // 
            // gpbFacility
            // 
            gpbFacility.Controls.Add(txbFacilityOver);
            gpbFacility.Controls.Add(txbFacilityNormal);
            gpbFacility.Controls.Add(label2);
            gpbFacility.Controls.Add(label3);
            gpbFacility.Font = new Font("Microsoft Sans Serif", 11.25F);
            gpbFacility.Location = new Point(374, 76);
            gpbFacility.Name = "gpbFacility";
            gpbFacility.Size = new Size(356, 55);
            gpbFacility.TabIndex = 36;
            gpbFacility.TabStop = false;
            gpbFacility.Text = "Precios en empaque";
            // 
            // txbFacilityOver
            // 
            txbFacilityOver.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFacilityOver.Location = new Point(286, 19);
            txbFacilityOver.MaxLength = 25;
            txbFacilityOver.Name = "txbFacilityOver";
            txbFacilityOver.ReadOnly = true;
            txbFacilityOver.Size = new Size(61, 24);
            txbFacilityOver.TabIndex = 35;
            // 
            // txbFacilityNormal
            // 
            txbFacilityNormal.Font = new Font("Microsoft Sans Serif", 11.25F);
            txbFacilityNormal.Location = new Point(118, 19);
            txbFacilityNormal.MaxLength = 25;
            txbFacilityNormal.Name = "txbFacilityNormal";
            txbFacilityNormal.ReadOnly = true;
            txbFacilityNormal.Size = new Size(61, 24);
            txbFacilityNormal.TabIndex = 34;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(185, 20);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 27;
            label2.Text = "Horario extra:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(2, 20);
            label3.Name = "label3";
            label3.Size = new Size(120, 21);
            label3.TabIndex = 25;
            label3.Text = "Horario normal:";
            // 
            // dgvPricesGtinAdd
            // 
            dgvPricesGtinAdd.AllowUserToAddRows = false;
            dgvPricesGtinAdd.AllowUserToDeleteRows = false;
            dgvPricesGtinAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPricesGtinAdd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dgvPricesGtinAdd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPricesGtinAdd.BackgroundColor = SystemColors.ControlLightLight;
            dgvPricesGtinAdd.BorderStyle = BorderStyle.Fixed3D;
            dgvPricesGtinAdd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPricesGtinAdd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPricesGtinAdd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPricesGtinAdd.EnableHeadersVisualStyles = false;
            dgvPricesGtinAdd.ImeMode = ImeMode.NoControl;
            dgvPricesGtinAdd.Location = new Point(12, 137);
            dgvPricesGtinAdd.Name = "dgvPricesGtinAdd";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPricesGtinAdd.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPricesGtinAdd.RowHeadersVisible = false;
            dgvPricesGtinAdd.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPricesGtinAdd.RowTemplate.Height = 25;
            dgvPricesGtinAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPricesGtinAdd.Size = new Size(718, 498);
            dgvPricesGtinAdd.TabIndex = 41;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(12, 644);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 82;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(93, 644);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 81;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmPricesGtinAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 685);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(dgvPricesGtinAdd);
            Controls.Add(gpbFacility);
            Controls.Add(gpbField);
            Controls.Add(txbDescription);
            Controls.Add(txbId);
            Controls.Add(lblPrice);
            Controls.Add(lblTitle);
            Name = "FrmPricesGtinAdd";
            Text = "Asignar precio a productos GTIN";
            Load += FrmPricesGtinAdd_Load;
            gpbField.ResumeLayout(false);
            gpbField.PerformLayout();
            gpbFacility.ResumeLayout(false);
            gpbFacility.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPricesGtinAdd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label lblTitle;
        public TextBox txbId;
        private Label lblPrice;
        public TextBox txbDescription;
        private GroupBox gpbField;
        private Label label1;
        private Label lblFieldNormal;
        public TextBox txbFieldOver;
        public TextBox txbFieldNormal;
        private GroupBox gpbFacility;
        public TextBox txbFacilityOver;
        public TextBox txbFacilityNormal;
        private Label label2;
        private Label label3;
        public DataGridView dgvPricesGtinAdd;
        private Button btnAccept;
        private Button btnCancel;
    }
}
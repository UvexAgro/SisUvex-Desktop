namespace SisUvex.Material.Warehouses
{
    partial class FrmMaterialWarehousesAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialWarehousesAdd));
            cboMarket = new ComboBox();
            txbId = new TextBox();
            txbName = new TextBox();
            lblObliName = new Label();
            label6 = new Label();
            lblMarket = new Label();
            label2 = new Label();
            lblName = new Label();
            lblId = new Label();
            lblTitle = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            btnBuscarCodigo = new Button();
            SuspendLayout();
            // 
            // cboMarket
            // 
            cboMarket.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMarket.Font = new Font("Segoe UI", 12F);
            cboMarket.FormattingEnabled = true;
            cboMarket.Items.AddRange(new object[] { "E", "N" });
            cboMarket.Location = new Point(240, 44);
            cboMarket.Name = "cboMarket";
            cboMarket.Size = new Size(43, 29);
            cboMarket.TabIndex = 98;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(88, 43);
            txbId.Name = "txbId";
            txbId.Size = new Size(84, 29);
            txbId.TabIndex = 97;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(88, 78);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(437, 29);
            txbName.TabIndex = 99;
            // 
            // lblObliName
            // 
            lblObliName.AutoSize = true;
            lblObliName.ForeColor = Color.Crimson;
            lblObliName.Location = new Point(79, 80);
            lblObliName.Margin = new Padding(0);
            lblObliName.Name = "lblObliName";
            lblObliName.Size = new Size(12, 15);
            lblObliName.TabIndex = 103;
            lblObliName.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(79, 43);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 105;
            label6.Text = "*";
            // 
            // lblMarket
            // 
            lblMarket.AutoSize = true;
            lblMarket.Font = new Font("Segoe UI", 12F);
            lblMarket.Location = new Point(178, 47);
            lblMarket.Name = "lblMarket";
            lblMarket.Size = new Size(56, 21);
            lblMarket.TabIndex = 102;
            lblMarket.Text = "Activo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(231, 45);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 104;
            label2.Text = "*";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(12, 81);
            lblName.Name = "lblName";
            lblName.Size = new Size(71, 21);
            lblName.TabIndex = 100;
            lblName.Text = "Nombre:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(57, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 101;
            lblId.Text = "Id:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 31);
            lblTitle.TabIndex = 106;
            lblTitle.Text = "Añadir almacén";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(119, 142);
            textBox1.MaxLength = 50;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(375, 29);
            textBox1.TabIndex = 107;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(108, 145);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 109;
            label1.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(101, 21);
            label3.TabIndex = 108;
            label3.Text = "Responsable:";
            // 
            // btnBuscarCodigo
            // 
            btnBuscarCodigo.Font = new Font("Segoe UI", 14F);
            btnBuscarCodigo.Image = Properties.Resources.BuscarLupa1;
            btnBuscarCodigo.Location = new Point(497, 141);
            btnBuscarCodigo.Name = "btnBuscarCodigo";
            btnBuscarCodigo.Size = new Size(31, 31);
            btnBuscarCodigo.TabIndex = 110;
            btnBuscarCodigo.UseVisualStyleBackColor = true;
            // 
            // FrmWarehousesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 185);
            Controls.Add(btnBuscarCodigo);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(lblTitle);
            Controls.Add(cboMarket);
            Controls.Add(txbId);
            Controls.Add(txbName);
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
            Name = "FrmWarehousesAdd";
            Text = "Añadir almacén";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboMarket;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblObliName;
        private Label label6;
        private Label lblMarket;
        private Label label2;
        private Label lblName;
        private Label lblId;
        public Label lblTitle;
        public TextBox textBox1;
        private Label label1;
        private Label label3;
        private Button btnBuscarCodigo;
    }
}
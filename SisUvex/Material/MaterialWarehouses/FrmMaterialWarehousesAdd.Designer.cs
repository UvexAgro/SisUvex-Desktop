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
            cboActive = new ComboBox();
            txbId = new TextBox();
            txbName = new TextBox();
            lblObliName = new Label();
            label6 = new Label();
            lblMarket = new Label();
            label2 = new Label();
            lblName = new Label();
            lblId = new Label();
            lblTitle = new Label();
            txbEmployeeName = new TextBox();
            label3 = new Label();
            btnSearchEmployee = new Button();
            txbIdEmployee = new TextBox();
            btnAccept = new Button();
            btnCancel = new Button();
            label4 = new Label();
            label5 = new Label();
            btnLoadEmployee = new Button();
            SuspendLayout();
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(226, 43);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(54, 29);
            cboActive.TabIndex = 98;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(88, 43);
            txbId.Name = "txbId";
            txbId.Size = new Size(70, 29);
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
            lblMarket.Location = new Point(164, 46);
            lblMarket.Name = "lblMarket";
            lblMarket.Size = new Size(56, 21);
            lblMarket.TabIndex = 102;
            lblMarket.Text = "Activo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(217, 44);
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
            // txbEmployeeName
            // 
            txbEmployeeName.Enabled = false;
            txbEmployeeName.Font = new Font("Segoe UI", 12F);
            txbEmployeeName.Location = new Point(151, 204);
            txbEmployeeName.MaxLength = 50;
            txbEmployeeName.Name = "txbEmployeeName";
            txbEmployeeName.Size = new Size(374, 29);
            txbEmployeeName.TabIndex = 107;
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
            // btnSearchEmployee
            // 
            btnSearchEmployee.Font = new Font("Segoe UI", 14F);
            btnSearchEmployee.Image = Properties.Resources.BuscarLupa1;
            btnSearchEmployee.Location = new Point(290, 168);
            btnSearchEmployee.Margin = new Padding(0);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(32, 32);
            btnSearchEmployee.TabIndex = 110;
            btnSearchEmployee.UseVisualStyleBackColor = true;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // txbIdEmployee
            // 
            txbIdEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdEmployee.Location = new Point(172, 169);
            txbIdEmployee.Margin = new Padding(3, 3, 0, 3);
            txbIdEmployee.Name = "txbIdEmployee";
            txbIdEmployee.Size = new Size(87, 29);
            txbIdEmployee.TabIndex = 111;
            txbIdEmployee.TextChanged += txbIdEmployee_TextChanged;
            txbIdEmployee.KeyPress += txbIdEmployee_KeyPress;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(372, 239);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 112;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(453, 239);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 113;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 172);
            label4.Margin = new Padding(3, 0, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(157, 21);
            label4.TabIndex = 114;
            label4.Text = "Código de empleado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(12, 207);
            label5.Margin = new Padding(3, 0, 0, 0);
            label5.Name = "label5";
            label5.Size = new Size(136, 21);
            label5.TabIndex = 115;
            label5.Text = "Nombre empledo:";
            // 
            // btnLoadEmployee
            // 
            btnLoadEmployee.BackgroundImage = Properties.Resources.guardarIcon32;
            btnLoadEmployee.BackgroundImageLayout = ImageLayout.Stretch;
            btnLoadEmployee.Font = new Font("Segoe UI", 14F);
            btnLoadEmployee.Location = new Point(259, 168);
            btnLoadEmployee.Margin = new Padding(0);
            btnLoadEmployee.Name = "btnLoadEmployee";
            btnLoadEmployee.Size = new Size(32, 32);
            btnLoadEmployee.TabIndex = 116;
            btnLoadEmployee.UseVisualStyleBackColor = true;
            btnLoadEmployee.Click += btnLoadEmployee_Click;
            // 
            // FrmMaterialWarehousesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 279);
            Controls.Add(btnLoadEmployee);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbIdEmployee);
            Controls.Add(btnSearchEmployee);
            Controls.Add(txbEmployeeName);
            Controls.Add(label3);
            Controls.Add(lblTitle);
            Controls.Add(cboActive);
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
            Name = "FrmMaterialWarehousesAdd";
            Text = "Añadir almacén";
            Load += FrmMaterialWarehousesAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboActive;
        public TextBox txbId;
        public TextBox txbName;
        private Label lblObliName;
        private Label label6;
        private Label lblMarket;
        private Label label2;
        private Label lblName;
        private Label lblId;
        public Label lblTitle;
        public TextBox txbEmployeeName;
        private Label label3;
        private Button btnSearchEmployee;
        public TextBox txbIdEmployee;
        private Button btnAccept;
        private Button btnCancel;
        private Label label4;
        private Label label5;
        private Button btnLoadEmployee;
    }
}
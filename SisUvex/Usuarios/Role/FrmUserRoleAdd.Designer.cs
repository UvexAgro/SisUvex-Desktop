namespace SisUvex.Usuarios.Role
{
    partial class FrmUserRoleAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserRoleAdd));
            lblNombre = new Label();
            cboActive = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            lblTitle = new Label();
            lblId = new Label();
            lblObliId = new Label();
            txbName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblActivo = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            pnlChbPrintLabels = new Panel();
            pnlChbViewCatalogs = new Panel();
            pnlChbEditCatalogs = new Panel();
            pnlChbCreateRecords = new Panel();
            pnlChbProductionReports = new Panel();
            pnlChbCostReports = new Panel();
            pnlChbAudit = new Panel();
            label10 = new Label();
            pnlTgbOwnFilter = new Panel();
            label11 = new Label();
            pnlChbSysAdmin = new Panel();
            label12 = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(11, 55);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(116, 21);
            lblNombre.TabIndex = 104;
            lblNombre.Text = "Nombre del rol";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(281, 12);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 12;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(259, 316);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 10;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(336, 316);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(365, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 13;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(132, 31);
            lblTitle.TabIndex = 97;
            lblTitle.Text = "Añadir rol";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(333, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 99;
            lblId.Text = "Id:";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(356, 12);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 100;
            lblObliId.Text = "*";
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(14, 74);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(397, 29);
            txbName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(6, 74);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 105;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(270, 12);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 103;
            label2.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(219, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 102;
            lblActivo.Text = "Activo: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(56, 130);
            label3.Name = "label3";
            label3.Size = new Size(141, 21);
            label3.TabIndex = 106;
            label3.Text = "Imprimir etiquetas:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(56, 157);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 107;
            label4.Text = "Ver catálogos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(56, 184);
            label5.Name = "label5";
            label5.Size = new Size(146, 21);
            label5.TabIndex = 108;
            label5.Text = "Modificar catálogos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(56, 211);
            label6.Name = "label6";
            label6.Size = new Size(113, 21);
            label6.TabIndex = 109;
            label6.Text = "Crear registros";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(56, 238);
            label7.Name = "label7";
            label7.Size = new Size(154, 21);
            label7.TabIndex = 110;
            label7.Text = "Reportes producción";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(56, 265);
            label8.Name = "label8";
            label8.Size = new Size(120, 21);
            label8.TabIndex = 111;
            label8.Text = "Reportes costos";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(56, 292);
            label9.Name = "label9";
            label9.Size = new Size(74, 21);
            label9.TabIndex = 112;
            label9.Text = "Auditoria";
            // 
            // pnlChbPrintLabels
            // 
            pnlChbPrintLabels.Location = new Point(14, 130);
            pnlChbPrintLabels.Name = "pnlChbPrintLabels";
            pnlChbPrintLabels.Size = new Size(36, 21);
            pnlChbPrintLabels.TabIndex = 1;
            // 
            // pnlChbViewCatalogs
            // 
            pnlChbViewCatalogs.Location = new Point(14, 157);
            pnlChbViewCatalogs.Name = "pnlChbViewCatalogs";
            pnlChbViewCatalogs.Size = new Size(36, 21);
            pnlChbViewCatalogs.TabIndex = 2;
            // 
            // pnlChbEditCatalogs
            // 
            pnlChbEditCatalogs.Location = new Point(14, 184);
            pnlChbEditCatalogs.Name = "pnlChbEditCatalogs";
            pnlChbEditCatalogs.Size = new Size(36, 21);
            pnlChbEditCatalogs.TabIndex = 3;
            // 
            // pnlChbCreateRecords
            // 
            pnlChbCreateRecords.Location = new Point(14, 211);
            pnlChbCreateRecords.Name = "pnlChbCreateRecords";
            pnlChbCreateRecords.Size = new Size(36, 21);
            pnlChbCreateRecords.TabIndex = 4;
            // 
            // pnlChbProductionReports
            // 
            pnlChbProductionReports.Location = new Point(14, 238);
            pnlChbProductionReports.Name = "pnlChbProductionReports";
            pnlChbProductionReports.Size = new Size(36, 21);
            pnlChbProductionReports.TabIndex = 5;
            // 
            // pnlChbCostReports
            // 
            pnlChbCostReports.Location = new Point(14, 265);
            pnlChbCostReports.Name = "pnlChbCostReports";
            pnlChbCostReports.Size = new Size(36, 21);
            pnlChbCostReports.TabIndex = 6;
            // 
            // pnlChbAudit
            // 
            pnlChbAudit.Location = new Point(14, 292);
            pnlChbAudit.Name = "pnlChbAudit";
            pnlChbAudit.Size = new Size(36, 21);
            pnlChbAudit.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(10, 106);
            label10.Name = "label10";
            label10.Size = new Size(79, 21);
            label10.TabIndex = 115;
            label10.Text = "Permisos";
            // 
            // pnlTgbOwnFilter
            // 
            pnlTgbOwnFilter.Location = new Point(259, 130);
            pnlTgbOwnFilter.Name = "pnlTgbOwnFilter";
            pnlTgbOwnFilter.Size = new Size(36, 21);
            pnlTgbOwnFilter.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(301, 130);
            label11.Name = "label11";
            label11.Size = new Size(110, 21);
            label11.TabIndex = 116;
            label11.Text = "Filtros propios";
            // 
            // pnlChbSysAdmin
            // 
            pnlChbSysAdmin.Location = new Point(14, 319);
            pnlChbSysAdmin.Name = "pnlChbSysAdmin";
            pnlChbSysAdmin.Size = new Size(36, 21);
            pnlChbSysAdmin.TabIndex = 8;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(56, 319);
            label12.Name = "label12";
            label12.Size = new Size(188, 21);
            label12.TabIndex = 115;
            label12.Text = "Administrador de sistema";
            // 
            // FrmUserRoleAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 361);
            Controls.Add(pnlChbSysAdmin);
            Controls.Add(pnlTgbOwnFilter);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(pnlChbAudit);
            Controls.Add(pnlChbCostReports);
            Controls.Add(pnlChbProductionReports);
            Controls.Add(pnlChbCreateRecords);
            Controls.Add(pnlChbEditCatalogs);
            Controls.Add(pnlChbViewCatalogs);
            Controls.Add(pnlChbPrintLabels);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cboActive);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(txbName);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblActivo);
            Controls.Add(lblNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmUserRoleAdd";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Añadir rol";
            Load += FrmUserRoleAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        public ComboBox cboActive;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblId;
        private Label lblObliId;
        public TextBox txbName;
        private Label label1;
        private Label label2;
        private Label lblActivo;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Panel pnlChbPrintLabels;
        private Panel pnlChbViewCatalogs;
        private Panel pnlChbEditCatalogs;
        private Panel pnlChbCreateRecords;
        private Panel pnlChbProductionReports;
        private Panel pnlChbCostReports;
        private Panel pnlChbAudit;
        private Label label10;
        private Panel pnlTgbOwnFilter;
        private Label label11;
        private CheckBox checkBox1;
        private Panel pnlChbSysAdmin;
        private Label label12;
    }
}
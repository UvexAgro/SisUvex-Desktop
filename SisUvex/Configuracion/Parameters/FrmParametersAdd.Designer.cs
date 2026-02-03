namespace SisUvex.Configuracion.Parameters
{
    partial class FrmParametersAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParametersAdd));
            txbDetail = new TextBox();
            lblDireccion = new Label();
            cboActive = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbName = new TextBox();
            lblNombre = new Label();
            lblTitle = new Label();
            lblActivo = new Label();
            lblObliCom = new Label();
            txbIdType = new TextBox();
            cboType = new ComboBox();
            label5 = new Label();
            label7 = new Label();
            label1 = new Label();
            label2 = new Label();
            cboDataType = new ComboBox();
            label3 = new Label();
            txbId = new TextBox();
            label4 = new Label();
            label6 = new Label();
            lblDataTypeExample = new Label();
            pnlInputHost = new Panel();
            btnIdEdit = new Button();
            label8 = new Label();
            SuspendLayout();
            // 
            // txbDetail
            // 
            txbDetail.Font = new Font("Segoe UI", 12F);
            txbDetail.Location = new Point(108, 116);
            txbDetail.MaxLength = 50;
            txbDetail.Name = "txbDetail";
            txbDetail.Size = new Size(486, 29);
            txbDetail.TabIndex = 1;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(10, 119);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(94, 21);
            lblDireccion.TabIndex = 64;
            lblDireccion.Text = "Descripción:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(548, 12);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 6;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(438, 244);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(519, 244);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(269, 81);
            txbName.MaxLength = 30;
            txbName.Name = "txbName";
            txbName.Size = new Size(325, 29);
            txbName.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(195, 84);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 60;
            lblNombre.Text = "Nombre:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(227, 31);
            lblTitle.TabIndex = 59;
            lblTitle.Text = "Añadir parámetro";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(492, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 62;
            lblActivo.Text = "Activo: ";
            // 
            // lblObliCom
            // 
            lblObliCom.AutoSize = true;
            lblObliCom.ForeColor = Color.Crimson;
            lblObliCom.Location = new Point(261, 81);
            lblObliCom.Name = "lblObliCom";
            lblObliCom.Size = new Size(12, 15);
            lblObliCom.TabIndex = 63;
            lblObliCom.Text = "*";
            // 
            // txbIdType
            // 
            txbIdType.Enabled = false;
            txbIdType.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdType.Location = new Point(108, 46);
            txbIdType.MaxLength = 2;
            txbIdType.Name = "txbIdType";
            txbIdType.Size = new Size(46, 29);
            txbIdType.TabIndex = 7;
            txbIdType.TextAlign = HorizontalAlignment.Center;
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.Font = new Font("Segoe UI", 12F);
            cboType.FormattingEnabled = true;
            cboType.ItemHeight = 21;
            cboType.Location = new Point(160, 47);
            cboType.Name = "cboType";
            cboType.Size = new Size(434, 29);
            cboType.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(99, 46);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 462;
            label5.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(61, 50);
            label7.Name = "label7";
            label7.Size = new Size(43, 21);
            label7.TabIndex = 461;
            label7.Text = "Tipo:";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(55, 211);
            label1.Name = "label1";
            label1.Size = new Size(49, 21);
            label1.TabIndex = 464;
            label1.Text = "Valor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(99, 151);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 468;
            label2.Text = "*";
            // 
            // cboDataType
            // 
            cboDataType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDataType.Font = new Font("Segoe UI", 12F);
            cboDataType.FormattingEnabled = true;
            cboDataType.ItemHeight = 21;
            cboDataType.Location = new Point(108, 152);
            cboDataType.Name = "cboDataType";
            cboDataType.Size = new Size(178, 29);
            cboDataType.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(61, 155);
            label3.Name = "label3";
            label3.Size = new Size(43, 21);
            label3.TabIndex = 467;
            label3.Text = "Tipo:";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(108, 81);
            txbId.MaxLength = 3;
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 9;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(78, 84);
            label4.Name = "label4";
            label4.Size = new Size(26, 21);
            label4.TabIndex = 470;
            label4.Text = "Id:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(99, 81);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 471;
            label6.Text = "*";
            // 
            // lblDataTypeExample
            // 
            lblDataTypeExample.AutoSize = true;
            lblDataTypeExample.Font = new Font("Segoe UI", 12F);
            lblDataTypeExample.ForeColor = SystemColors.ControlDarkDark;
            lblDataTypeExample.Location = new Point(110, 184);
            lblDataTypeExample.Name = "lblDataTypeExample";
            lblDataTypeExample.Size = new Size(25, 21);
            lblDataTypeExample.TabIndex = 472;
            lblDataTypeExample.Text = "Ej:";
            lblDataTypeExample.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlInputHost
            // 
            pnlInputHost.Location = new Point(108, 209);
            pnlInputHost.Name = "pnlInputHost";
            pnlInputHost.Size = new Size(486, 29);
            pnlInputHost.TabIndex = 3;
            // 
            // btnIdEdit
            // 
            btnIdEdit.Image = Properties.Resources.editPencilIcon16;
            btnIdEdit.Location = new Point(160, 82);
            btnIdEdit.Name = "btnIdEdit";
            btnIdEdit.Size = new Size(29, 29);
            btnIdEdit.TabIndex = 10;
            btnIdEdit.UseVisualStyleBackColor = true;
            btnIdEdit.Click += btnIdEdit_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Crimson;
            label8.Location = new Point(99, 209);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 473;
            label8.Text = "*";
            // 
            // FrmParametersAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 288);
            Controls.Add(btnIdEdit);
            Controls.Add(pnlInputHost);
            Controls.Add(txbId);
            Controls.Add(cboDataType);
            Controls.Add(txbIdType);
            Controls.Add(cboType);
            Controls.Add(txbDetail);
            Controls.Add(cboActive);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbName);
            Controls.Add(lblDataTypeExample);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(lblObliCom);
            Controls.Add(label7);
            Controls.Add(lblDireccion);
            Controls.Add(lblNombre);
            Controls.Add(lblTitle);
            Controls.Add(lblActivo);
            Controls.Add(label8);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(622, 327);
            MinimizeBox = false;
            MinimumSize = new Size(622, 327);
            Name = "FrmParametersAdd";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "FrmParametersAdd";
            Load += FrmParametersAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public TextBox txbDetail;
        private Label lblDireccion;
        public ComboBox cboActive;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbName;
        private Label lblNombre;
        public Label lblTitle;
        private Label lblActivo;
        private Label lblObliCom;
        public TextBox txbIdType;
        public ComboBox cboType;
        private Label label5;
        private Label label7;
        private Label label1;
        public TextBox txbValue;
        private Label label2;
        public ComboBox cboDataType;
        private Label label3;
        public TextBox txbId;
        private Label label4;
        private Label label6;
        public Label lblDataTypeExample;
        public Panel pnlInputHost;
        private Button btnIdEdit;
        private Label label8;
    }
}
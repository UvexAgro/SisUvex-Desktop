namespace SisUvex.Catalogos.Driver
{
    partial class FrmDriverAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDriverAdd));
            lblFecha = new Label();
            lblVisa = new Label();
            txbVisa = new TextBox();
            lblLicencia = new Label();
            txbLicense = new TextBox();
            lblApellido = new Label();
            txbLastNames = new TextBox();
            lblNombre = new Label();
            cboActive = new ComboBox();
            txbIdTransportLine = new TextBox();
            cboTransportLine = new ComboBox();
            lblObliLinea = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            lblId = new Label();
            lblObliId = new Label();
            txbName = new TextBox();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            lblActivo = new Label();
            lblLinea = new Label();
            txbId = new TextBox();
            dtpBirthday = new DateTimePicker();
            chbTransportLineRemoved = new CheckBox();
            btnTransportLineSearch = new Button();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 12F);
            lblFecha.Location = new Point(6, 226);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(155, 21);
            lblFecha.TabIndex = 83;
            lblFecha.Text = "Fecha de nacimiento:";
            // 
            // lblVisa
            // 
            lblVisa.AutoSize = true;
            lblVisa.Font = new Font("Segoe UI", 12F);
            lblVisa.Location = new Point(41, 191);
            lblVisa.Name = "lblVisa";
            lblVisa.Size = new Size(42, 21);
            lblVisa.TabIndex = 82;
            lblVisa.Text = "Visa:";
            // 
            // txbVisa
            // 
            txbVisa.Font = new Font("Segoe UI", 12F);
            txbVisa.Location = new Point(89, 188);
            txbVisa.MaxLength = 30;
            txbVisa.Name = "txbVisa";
            txbVisa.Size = new Size(406, 29);
            txbVisa.TabIndex = 8;
            // 
            // lblLicencia
            // 
            lblLicencia.AutoSize = true;
            lblLicencia.Font = new Font("Segoe UI", 12F);
            lblLicencia.Location = new Point(15, 156);
            lblLicencia.Name = "lblLicencia";
            lblLicencia.Size = new Size(68, 21);
            lblLicencia.TabIndex = 81;
            lblLicencia.Text = "Licencia:";
            // 
            // txbLicense
            // 
            txbLicense.Font = new Font("Segoe UI", 12F);
            txbLicense.Location = new Point(89, 153);
            txbLicense.MaxLength = 20;
            txbLicense.Name = "txbLicense";
            txbLicense.Size = new Size(406, 29);
            txbLicense.TabIndex = 7;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F);
            lblApellido.Location = new Point(6, 121);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(77, 21);
            lblApellido.TabIndex = 79;
            lblApellido.Text = "Apellidos:";
            // 
            // txbLastNames
            // 
            txbLastNames.Font = new Font("Segoe UI", 12F);
            txbLastNames.Location = new Point(89, 118);
            txbLastNames.MaxLength = 30;
            txbLastNames.Name = "txbLastNames";
            txbLastNames.Size = new Size(406, 29);
            txbLastNames.TabIndex = 6;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 86);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 77;
            lblNombre.Text = "Nombre:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(441, 13);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 12;
            // 
            // txbIdTransportLine
            // 
            txbIdTransportLine.Enabled = false;
            txbIdTransportLine.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdTransportLine.Location = new Point(165, 48);
            txbIdTransportLine.Name = "txbIdTransportLine";
            txbIdTransportLine.Size = new Size(46, 29);
            txbIdTransportLine.TabIndex = 1;
            txbIdTransportLine.TextAlign = HorizontalAlignment.Center;
            // 
            // cboTransportLine
            // 
            cboTransportLine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTransportLine.Font = new Font("Segoe UI", 12F);
            cboTransportLine.FormattingEnabled = true;
            cboTransportLine.ItemHeight = 21;
            cboTransportLine.Location = new Point(217, 48);
            cboTransportLine.Name = "cboTransportLine";
            cboTransportLine.Size = new Size(278, 29);
            cboTransportLine.TabIndex = 2;
            // 
            // lblObliLinea
            // 
            lblObliLinea.AutoSize = true;
            lblObliLinea.ForeColor = Color.Crimson;
            lblObliLinea.Location = new Point(156, 48);
            lblObliLinea.Name = "lblObliLinea";
            lblObliLinea.Size = new Size(12, 15);
            lblObliLinea.TabIndex = 74;
            lblObliLinea.Text = "*";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(415, 257);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 10;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(496, 257);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(179, 31);
            lblTitle.TabIndex = 57;
            lblTitle.Text = "Añadir chofer";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(493, 16);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 66;
            lblId.Text = "Id:";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(516, 13);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 73;
            lblObliId.Text = "*";
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(89, 83);
            txbName.MaxLength = 30;
            txbName.Name = "txbName";
            txbName.Size = new Size(406, 29);
            txbName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(81, 118);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 80;
            label3.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(81, 83);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 78;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(430, 13);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 76;
            label2.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(379, 16);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 75;
            lblActivo.Text = "Activo: ";
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Segoe UI", 12F);
            lblLinea.Location = new Point(12, 51);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(147, 21);
            lblLinea.TabIndex = 59;
            lblLinea.Text = "Línea de transporte:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(525, 13);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 0;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpBirthday
            // 
            dtpBirthday.CalendarFont = new Font("Segoe UI", 12F);
            dtpBirthday.CustomFormat = "dd 'de'MMMM 'de' yyyy";
            dtpBirthday.Font = new Font("Segoe UI", 12F);
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.Location = new Point(165, 223);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(217, 29);
            dtpBirthday.TabIndex = 9;
            // 
            // chbTransportLineRemoved
            // 
            chbTransportLineRemoved.Appearance = Appearance.Button;
            chbTransportLineRemoved.AutoSize = true;
            chbTransportLineRemoved.BackgroundImage = Properties.Resources.Imagen6;
            chbTransportLineRemoved.BackgroundImageLayout = ImageLayout.Stretch;
            chbTransportLineRemoved.Font = new Font("Segoe UI", 10F);
            chbTransportLineRemoved.Location = new Point(500, 48);
            chbTransportLineRemoved.Name = "chbTransportLineRemoved";
            chbTransportLineRemoved.Size = new Size(39, 29);
            chbTransportLineRemoved.TabIndex = 3;
            chbTransportLineRemoved.Text = "     ";
            chbTransportLineRemoved.UseVisualStyleBackColor = true;
            // 
            // btnTransportLineSearch
            // 
            btnTransportLineSearch.BackgroundImage = Properties.Resources.buscarIcon32;
            btnTransportLineSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnTransportLineSearch.Location = new Point(542, 48);
            btnTransportLineSearch.Name = "btnTransportLineSearch";
            btnTransportLineSearch.Size = new Size(29, 29);
            btnTransportLineSearch.TabIndex = 4;
            btnTransportLineSearch.UseVisualStyleBackColor = true;
            btnTransportLineSearch.Click += btnTransportLineSearch_Click;
            // 
            // FrmDriverAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 298);
            Controls.Add(chbTransportLineRemoved);
            Controls.Add(btnTransportLineSearch);
            Controls.Add(dtpBirthday);
            Controls.Add(lblFecha);
            Controls.Add(lblVisa);
            Controls.Add(txbVisa);
            Controls.Add(lblLicencia);
            Controls.Add(txbLicense);
            Controls.Add(lblApellido);
            Controls.Add(txbLastNames);
            Controls.Add(lblNombre);
            Controls.Add(cboActive);
            Controls.Add(txbIdTransportLine);
            Controls.Add(cboTransportLine);
            Controls.Add(lblObliLinea);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            Controls.Add(txbName);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblActivo);
            Controls.Add(lblLinea);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDriverAdd";
            Text = "Añadir conductor";
            Load += FrmDriverAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblFecha;
        private Label lblVisa;
        public TextBox txbVisa;
        private Label lblLicencia;
        public TextBox txbLicense;
        private Label lblApellido;
        public TextBox txbLastNames;
        private Label lblNombre;
        public ComboBox cboActive;
        public TextBox txbIdTransportLine;
        private Label lblObliLinea;
        private Button btnAccept;
        private Button btnCancel;
        public Label lblTitle;
        private Label lblId;
        private Label lblObliId;
        public TextBox txbName;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label lblActivo;
        private Label lblLinea;
        public TextBox txbId;
        public CheckBox chbTransportLineRemoved;
        public Button btnTransportLineSearch;
        public DateTimePicker dtpBirthday;
        public ComboBox cboTransportLine;
    }
}
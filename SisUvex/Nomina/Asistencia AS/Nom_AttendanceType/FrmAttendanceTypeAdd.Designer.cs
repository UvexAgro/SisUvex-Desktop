namespace SisUvex.Nomina.Asistencia_AS.Nom_AttendanceType
{
    partial class FrmAttendanceTypeAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAttendanceTypeAdd));
            lblTitulo = new Label();
            lblId = new Label();
            txbId = new TextBox();
            lblActivo = new Label();
            cboActive = new ComboBox();
            lblNombre = new Label();
            lblReqNombre = new Label();
            txbName = new TextBox();
            lblPrefijo = new Label();
            lblReqPrefijo = new Label();
            txbPrefix = new TextBox();
            lblTipo = new Label();
            cboIsAbsence = new ComboBox();
            lblColor = new Label();
            pnlColor = new Panel();
            btnSelectColor = new Button();
            txbColor = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(236, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Tipo de asistencia";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(12, 54);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 1;
            lblId.Text = "Id:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(40, 51);
            txbId.Name = "txbId";
            txbId.Size = new Size(50, 29);
            txbId.TabIndex = 2;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(105, 54);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(56, 21);
            lblActivo.TabIndex = 3;
            lblActivo.Text = "Activo:";
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(173, 51);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(70, 29);
            cboActive.TabIndex = 4;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 93);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            // 
            // lblReqNombre
            // 
            lblReqNombre.AutoSize = true;
            lblReqNombre.ForeColor = Color.Crimson;
            lblReqNombre.Location = new Point(82, 90);
            lblReqNombre.Name = "lblReqNombre";
            lblReqNombre.Size = new Size(12, 15);
            lblReqNombre.TabIndex = 6;
            lblReqNombre.Text = "*";
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F);
            txbName.Location = new Point(92, 90);
            txbName.MaxLength = 200;
            txbName.Name = "txbName";
            txbName.Size = new Size(280, 29);
            txbName.TabIndex = 7;
            // 
            // lblPrefijo
            // 
            lblPrefijo.AutoSize = true;
            lblPrefijo.Font = new Font("Segoe UI", 12F);
            lblPrefijo.Location = new Point(25, 128);
            lblPrefijo.Name = "lblPrefijo";
            lblPrefijo.Size = new Size(58, 21);
            lblPrefijo.TabIndex = 8;
            lblPrefijo.Text = "Prefijo:";
            // 
            // lblReqPrefijo
            // 
            lblReqPrefijo.AutoSize = true;
            lblReqPrefijo.ForeColor = Color.Crimson;
            lblReqPrefijo.Location = new Point(82, 125);
            lblReqPrefijo.Name = "lblReqPrefijo";
            lblReqPrefijo.Size = new Size(12, 15);
            lblReqPrefijo.TabIndex = 9;
            lblReqPrefijo.Text = "*";
            // 
            // txbPrefix
            // 
            txbPrefix.Font = new Font("Segoe UI", 12F);
            txbPrefix.Location = new Point(92, 125);
            txbPrefix.MaxLength = 6;
            txbPrefix.Name = "txbPrefix";
            txbPrefix.Size = new Size(80, 29);
            txbPrefix.TabIndex = 10;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 12F);
            lblTipo.Location = new Point(40, 163);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(43, 21);
            lblTipo.TabIndex = 11;
            lblTipo.Text = "Tipo:";
            // 
            // cboIsAbsence
            // 
            cboIsAbsence.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIsAbsence.Font = new Font("Segoe UI", 12F);
            cboIsAbsence.FormattingEnabled = true;
            cboIsAbsence.Items.AddRange(new object[] { "Asistencia", "Inasistencia" });
            cboIsAbsence.Location = new Point(92, 160);
            cboIsAbsence.Name = "cboIsAbsence";
            cboIsAbsence.Size = new Size(140, 29);
            cboIsAbsence.TabIndex = 12;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Segoe UI", 12F);
            lblColor.Location = new Point(32, 198);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(51, 21);
            lblColor.TabIndex = 13;
            lblColor.Text = "Color:";
            // 
            // pnlColor
            // 
            pnlColor.BorderStyle = BorderStyle.Fixed3D;
            pnlColor.Location = new Point(92, 195);
            pnlColor.Name = "pnlColor";
            pnlColor.Size = new Size(40, 29);
            pnlColor.TabIndex = 14;
            // 
            // btnSelectColor
            // 
            btnSelectColor.Font = new Font("Segoe UI", 9F);
            btnSelectColor.Location = new Point(140, 195);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.Size = new Size(160, 29);
            btnSelectColor.TabIndex = 15;
            btnSelectColor.Text = "Seleccionar color...";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Click += btnSelectColor_Click;
            // 
            // txbColor
            // 
            txbColor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbColor.Location = new Point(308, 195);
            txbColor.Name = "txbColor";
            txbColor.ReadOnly = true;
            txbColor.Size = new Size(80, 29);
            txbColor.TabIndex = 16;
            txbColor.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(297, 240);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 17;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(378, 240);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAttendanceTypeAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 285);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(txbId);
            Controls.Add(lblActivo);
            Controls.Add(cboActive);
            Controls.Add(lblNombre);
            Controls.Add(txbName);
            Controls.Add(lblPrefijo);
            Controls.Add(txbPrefix);
            Controls.Add(lblTipo);
            Controls.Add(cboIsAbsence);
            Controls.Add(lblColor);
            Controls.Add(pnlColor);
            Controls.Add(btnSelectColor);
            Controls.Add(txbColor);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(lblReqNombre);
            Controls.Add(lblReqPrefijo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAttendanceTypeAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tipo de asistencia";
            Load += FrmAttendanceTypeAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitulo;
        private Label lblId;
        public TextBox txbId;
        private Label lblActivo;
        public ComboBox cboActive;
        private Label lblNombre;
        private Label lblReqNombre;
        public TextBox txbName;
        private Label lblPrefijo;
        private Label lblReqPrefijo;
        public TextBox txbPrefix;
        private Label lblTipo;
        public ComboBox cboIsAbsence;
        private Label lblColor;
        public Panel pnlColor;
        private Button btnSelectColor;
        public TextBox txbColor;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}

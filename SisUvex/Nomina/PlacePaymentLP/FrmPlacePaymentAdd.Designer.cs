using System.Drawing;
using System.Windows.Forms;

namespace SisUvex.Nomina.PlacePaymentLP
{
    partial class FrmPlacePaymentAdd
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlacePaymentAdd));
            cboActive = new ComboBox();
            label4 = new Label();
            lblActivo = new Label();
            txbIdSeason = new TextBox();
            cboSeason = new ComboBox();
            label3 = new Label();
            txbName = new TextBox();
            txbIdContractor = new TextBox();
            cboContractor = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            txbId = new TextBox();
            lblTitle = new Label();
            lblObliId = new Label();
            lblContractor = new Label();
            label1 = new Label();
            lblId = new Label();
            chbActiveContractor = new CheckBox();
            txbSisName = new TextBox();
            label2 = new Label();
            chbActiveWorkGroup = new CheckBox();
            txbIdWorkGroup = new TextBox();
            cboWorkGroup = new ComboBox();
            label5 = new Label();
            lblGrower = new Label();
            txbIdGrower = new TextBox();
            cboGrower = new ComboBox();
            label6 = new Label();
            tgbOrderList = new SisUvex.Cuadro_de_herramientas.ToggleButton();
            SuspendLayout();
            // 
            // cboActive
            // 
            cboActive.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActive.Font = new Font("Segoe UI", 12F);
            cboActive.FormattingEnabled = true;
            cboActive.Items.AddRange(new object[] { "No", "Sí" });
            cboActive.Location = new Point(445, 46);
            cboActive.Name = "cboActive";
            cboActive.Size = new Size(46, 29);
            cboActive.TabIndex = 112;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(434, 46);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 114;
            label4.Text = "*";
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(383, 49);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 113;
            lblActivo.Text = "Activo: ";
            // 
            // txbIdSeason
            // 
            txbIdSeason.Enabled = false;
            txbIdSeason.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdSeason.Location = new Point(119, 151);
            txbIdSeason.Name = "txbIdSeason";
            txbIdSeason.Size = new Size(46, 29);
            txbIdSeason.TabIndex = 100;
            txbIdSeason.TextAlign = HorizontalAlignment.Center;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.Font = new Font("Segoe UI", 12F);
            cboSeason.FormattingEnabled = true;
            cboSeason.ItemHeight = 21;
            cboSeason.Location = new Point(171, 151);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(275, 29);
            cboSeason.TabIndex = 101;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(27, 154);
            label3.Name = "label3";
            label3.Size = new Size(90, 21);
            label3.TabIndex = 110;
            label3.Text = "Temporada:";
            // 
            // txbName
            // 
            txbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbName.Location = new Point(171, 81);
            txbName.MaxLength = 50;
            txbName.Name = "txbName";
            txbName.Size = new Size(320, 29);
            txbName.TabIndex = 95;
            // 
            // txbIdContractor
            // 
            txbIdContractor.Enabled = false;
            txbIdContractor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdContractor.Location = new Point(119, 186);
            txbIdContractor.Name = "txbIdContractor";
            txbIdContractor.Size = new Size(46, 29);
            txbIdContractor.TabIndex = 96;
            txbIdContractor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.Font = new Font("Segoe UI", 12F);
            cboContractor.FormattingEnabled = true;
            cboContractor.ItemHeight = 21;
            cboContractor.Location = new Point(171, 186);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(275, 29);
            cboContractor.TabIndex = 97;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Location = new Point(335, 322);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 29);
            btnAccept.TabIndex = 102;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(416, 322);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 103;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(171, 46);
            txbId.Name = "txbId";
            txbId.Size = new Size(63, 29);
            txbId.TabIndex = 94;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Black", 16F);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(301, 31);
            lblTitle.TabIndex = 104;
            lblTitle.Text = "Modificar lugar de pago";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(162, 46);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 107;
            lblObliId.Text = "*";
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Font = new Font("Segoe UI", 12F);
            lblContractor.Location = new Point(28, 189);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(89, 21);
            lblContractor.TabIndex = 105;
            lblContractor.Text = "Contratista:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(94, 84);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 109;
            label1.Text = "Nombre:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(139, 52);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 106;
            lblId.Text = "Id:";
            // 
            // chbActiveContractor
            // 
            chbActiveContractor.Appearance = Appearance.Button;
            chbActiveContractor.AutoSize = true;
            chbActiveContractor.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveContractor.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveContractor.Font = new Font("Segoe UI", 10F);
            chbActiveContractor.Location = new Point(452, 186);
            chbActiveContractor.Name = "chbActiveContractor";
            chbActiveContractor.Size = new Size(39, 29);
            chbActiveContractor.TabIndex = 98;
            chbActiveContractor.Text = "     ";
            chbActiveContractor.UseVisualStyleBackColor = true;
            // 
            // txbSisName
            // 
            txbSisName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbSisName.Location = new Point(171, 116);
            txbSisName.MaxLength = 30;
            txbSisName.Name = "txbSisName";
            txbSisName.Size = new Size(320, 29);
            txbSisName.TabIndex = 115;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(37, 119);
            label2.Name = "label2";
            label2.Size = new Size(128, 21);
            label2.TabIndex = 116;
            label2.Text = "Nombre sistema:";
            // 
            // chbActiveWorkGroup
            // 
            chbActiveWorkGroup.Appearance = Appearance.Button;
            chbActiveWorkGroup.AutoSize = true;
            chbActiveWorkGroup.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveWorkGroup.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveWorkGroup.Font = new Font("Segoe UI", 10F);
            chbActiveWorkGroup.Location = new Point(452, 221);
            chbActiveWorkGroup.Name = "chbActiveWorkGroup";
            chbActiveWorkGroup.Size = new Size(39, 29);
            chbActiveWorkGroup.TabIndex = 119;
            chbActiveWorkGroup.Text = "     ";
            chbActiveWorkGroup.UseVisualStyleBackColor = true;
            // 
            // txbIdWorkGroup
            // 
            txbIdWorkGroup.Enabled = false;
            txbIdWorkGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdWorkGroup.Location = new Point(119, 221);
            txbIdWorkGroup.Name = "txbIdWorkGroup";
            txbIdWorkGroup.Size = new Size(46, 29);
            txbIdWorkGroup.TabIndex = 117;
            txbIdWorkGroup.TextAlign = HorizontalAlignment.Center;
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.Font = new Font("Segoe UI", 12F);
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.ItemHeight = 21;
            cboWorkGroup.Location = new Point(171, 221);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(275, 29);
            cboWorkGroup.TabIndex = 118;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(38, 224);
            label5.Name = "label5";
            label5.Size = new Size(75, 21);
            label5.TabIndex = 120;
            label5.Text = "Cuadrilla:";
            // 
            // lblGrower
            // 
            lblGrower.AutoSize = true;
            lblGrower.Font = new Font("Segoe UI", 12F);
            lblGrower.Location = new Point(40, 259);
            lblGrower.Name = "lblGrower";
            lblGrower.Size = new Size(79, 21);
            lblGrower.TabIndex = 121;
            lblGrower.Text = "Productor";
            // 
            // txbIdGrower
            // 
            txbIdGrower.Enabled = false;
            txbIdGrower.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdGrower.Location = new Point(119, 256);
            txbIdGrower.Name = "txbIdGrower";
            txbIdGrower.Size = new Size(46, 29);
            txbIdGrower.TabIndex = 122;
            txbIdGrower.TextAlign = HorizontalAlignment.Center;
            // 
            // cboGrower
            // 
            cboGrower.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrower.Font = new Font("Segoe UI", 12F);
            cboGrower.FormattingEnabled = true;
            cboGrower.ItemHeight = 21;
            cboGrower.Location = new Point(171, 256);
            cboGrower.Name = "cboGrower";
            cboGrower.Size = new Size(275, 29);
            cboGrower.TabIndex = 123;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 294);
            label6.Name = "label6";
            label6.Size = new Size(150, 21);
            label6.TabIndex = 124;
            label6.Text = "Priorizar en listados:";
            // 
            // tgbOrderList
            // 
            tgbOrderList.AnimationSpeed = 4;
            tgbOrderList.Appearance = Appearance.Button;
            tgbOrderList.BackColor = Color.Transparent;
            tgbOrderList.FocusBackColor = Color.FromArgb(202, 167, 243);
            tgbOrderList.FocusBorderColor = Color.FromArgb(92, 53, 142);
            tgbOrderList.Location = new Point(171, 291);
            tgbOrderList.MinimumSize = new Size(20, 10);
            tgbOrderList.Name = "tgbOrderList";
            tgbOrderList.OffBackColor = Color.LightGray;
            tgbOrderList.OnBackColor = Color.FromArgb(92, 53, 142);
            tgbOrderList.Size = new Size(52, 27);
            tgbOrderList.TabIndex = 125;
            tgbOrderList.ToggleColor = Color.White;
            tgbOrderList.UseVisualStyleBackColor = false;
            // 
            // FrmPlacePaymentAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 363);
            Controls.Add(tgbOrderList);
            Controls.Add(label6);
            Controls.Add(cboGrower);
            Controls.Add(txbIdGrower);
            Controls.Add(lblGrower);
            Controls.Add(cboActive);
            Controls.Add(label4);
            Controls.Add(lblActivo);
            Controls.Add(chbActiveWorkGroup);
            Controls.Add(txbIdWorkGroup);
            Controls.Add(cboWorkGroup);
            Controls.Add(label5);
            Controls.Add(txbSisName);
            Controls.Add(label2);
            Controls.Add(chbActiveContractor);
            Controls.Add(txbIdSeason);
            Controls.Add(cboSeason);
            Controls.Add(label3);
            Controls.Add(txbName);
            Controls.Add(txbIdContractor);
            Controls.Add(cboContractor);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(txbId);
            Controls.Add(lblTitle);
            Controls.Add(lblObliId);
            Controls.Add(lblContractor);
            Controls.Add(label1);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmPlacePaymentAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar lugar de pago";
            Load += FrmPlacePaymentAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ComboBox cboActive;
        private Label label4;
        private Label lblActivo;
        public TextBox txbIdSeason;
        public ComboBox cboSeason;
        private Label label3;
        public TextBox txbName;
        public TextBox txbIdContractor;
        public ComboBox cboContractor;
        private Button btnAccept;
        private Button btnCancel;
        public TextBox txbId;
        public Label lblTitle;
        private Label lblObliId;
        private Label lblContractor;
        private Label label1;
        private Label lblId;
        public CheckBox chbActiveContractor;
        public TextBox txbSisName;
        private Label label2;
        public CheckBox chbActiveWorkGroup;
        public TextBox txbIdWorkGroup;
        public ComboBox cboWorkGroup;
        private Label label5;
        private Label lblGrower;
        public TextBox txbIdGrower;
        public ComboBox cboGrower;
        private Label label6;
        public SisUvex.Cuadro_de_herramientas.ToggleButton tgbOrderList;
    }
}

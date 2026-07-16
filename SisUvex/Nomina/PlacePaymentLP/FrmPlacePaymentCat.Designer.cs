using System.Drawing;
using System.Windows.Forms;

namespace SisUvex.Nomina.PlacePaymentLP
{
    partial class FrmPlacePaymentCat
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlacePaymentCat));
            lblContractor = new Label();
            cboContractor = new ComboBox();
            chbActiveContractor = new CheckBox();
            lblSeason = new Label();
            cboSeason = new ComboBox();
            lblWorkGroup = new Label();
            cboWorkGroup = new ComboBox();
            chbActiveWorkGroup = new CheckBox();
            chbRemoved = new CheckBox();
            dgvCatalog = new DataGridView();
            btnRemove = new Button();
            btnRecover = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            btnPriorizeOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            SuspendLayout();
            // 
            // lblContractor
            // 
            lblContractor.AutoSize = true;
            lblContractor.Location = new Point(13, 9);
            lblContractor.Name = "lblContractor";
            lblContractor.Size = new Size(65, 15);
            lblContractor.TabIndex = 20;
            lblContractor.Text = "Contratista";
            // 
            // cboContractor
            // 
            cboContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContractor.FormattingEnabled = true;
            cboContractor.Location = new Point(80, 6);
            cboContractor.Name = "cboContractor";
            cboContractor.Size = new Size(200, 23);
            cboContractor.TabIndex = 0;
            // 
            // chbActiveContractor
            // 
            chbActiveContractor.Appearance = Appearance.Button;
            chbActiveContractor.AutoSize = true;
            chbActiveContractor.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveContractor.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveContractor.Location = new Point(282, 5);
            chbActiveContractor.Name = "chbActiveContractor";
            chbActiveContractor.Size = new Size(32, 25);
            chbActiveContractor.TabIndex = 1;
            chbActiveContractor.Text = "     ";
            chbActiveContractor.UseVisualStyleBackColor = true;
            // 
            // lblSeason
            // 
            lblSeason.AutoSize = true;
            lblSeason.Location = new Point(335, 9);
            lblSeason.Name = "lblSeason";
            lblSeason.Size = new Size(67, 15);
            lblSeason.TabIndex = 21;
            lblSeason.Text = "Temporada";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(403, 6);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(200, 23);
            cboSeason.TabIndex = 2;
            // 
            // lblWorkGroup
            // 
            lblWorkGroup.AutoSize = true;
            lblWorkGroup.Location = new Point(621, 9);
            lblWorkGroup.Name = "lblWorkGroup";
            lblWorkGroup.Size = new Size(54, 15);
            lblWorkGroup.TabIndex = 22;
            lblWorkGroup.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(677, 6);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(220, 23);
            cboWorkGroup.TabIndex = 3;
            // 
            // chbActiveWorkGroup
            // 
            chbActiveWorkGroup.Appearance = Appearance.Button;
            chbActiveWorkGroup.AutoSize = true;
            chbActiveWorkGroup.BackgroundImage = Properties.Resources.Imagen6;
            chbActiveWorkGroup.BackgroundImageLayout = ImageLayout.Stretch;
            chbActiveWorkGroup.Location = new Point(899, 5);
            chbActiveWorkGroup.Name = "chbActiveWorkGroup";
            chbActiveWorkGroup.Size = new Size(32, 25);
            chbActiveWorkGroup.TabIndex = 4;
            chbActiveWorkGroup.Text = "     ";
            chbActiveWorkGroup.UseVisualStyleBackColor = true;
            // 
            // chbRemoved
            // 
            chbRemoved.Appearance = Appearance.Button;
            chbRemoved.Location = new Point(94, 35);
            chbRemoved.Name = "chbRemoved";
            chbRemoved.Size = new Size(75, 23);
            chbRemoved.TabIndex = 12;
            chbRemoved.Text = "Eliminados";
            chbRemoved.TextAlign = ContentAlignment.MiddleCenter;
            chbRemoved.UseVisualStyleBackColor = true;
            chbRemoved.CheckedChanged += chbRemoved_CheckedChanged;
            // 
            // dgvCatalog
            // 
            dgvCatalog.AllowUserToAddRows = false;
            dgvCatalog.AllowUserToDeleteRows = false;
            dgvCatalog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCatalog.BackgroundColor = SystemColors.ControlLightLight;
            dgvCatalog.BorderStyle = BorderStyle.Fixed3D;
            dgvCatalog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCatalog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCatalog.EnableHeadersVisualStyles = false;
            dgvCatalog.ImeMode = ImeMode.NoControl;
            dgvCatalog.Location = new Point(12, 64);
            dgvCatalog.Name = "dgvCatalog";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCatalog.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCatalog.RowHeadersVisible = false;
            dgvCatalog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalog.Size = new Size(960, 374);
            dgvCatalog.TabIndex = 15;
            dgvCatalog.CellMouseDoubleClick += dgvCatalog_CellMouseDoubleClick;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(175, 35);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 13;
            btnRemove.Text = "Eliminar";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnRecover
            // 
            btnRecover.Location = new Point(256, 35);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 14;
            btnRecover.Text = "Recuperar";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(13, 35);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 11;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(523, 35);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Visible = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnPriorizeOrder
            // 
            btnPriorizeOrder.Location = new Point(337, 35);
            btnPriorizeOrder.Name = "btnPriorizeOrder";
            btnPriorizeOrder.Size = new Size(180, 23);
            btnPriorizeOrder.TabIndex = 16;
            btnPriorizeOrder.Text = "Priorizar / quitar prioridad";
            btnPriorizeOrder.UseVisualStyleBackColor = true;
            btnPriorizeOrder.Click += btnPriorizeOrder_Click;
            // 
            // FrmPlacePaymentCat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 450);
            Controls.Add(btnPriorizeOrder);
            Controls.Add(lblContractor);
            Controls.Add(cboContractor);
            Controls.Add(chbActiveContractor);
            Controls.Add(cboSeason);
            Controls.Add(lblWorkGroup);
            Controls.Add(cboWorkGroup);
            Controls.Add(chbActiveWorkGroup);
            Controls.Add(chbRemoved);
            Controls.Add(dgvCatalog);
            Controls.Add(btnRemove);
            Controls.Add(btnRecover);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(lblSeason);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPlacePaymentCat";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Catálogo lugares de pago";
            WindowState = FormWindowState.Maximized;
            Load += FrmPlacePaymentCat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContractor;
        public ComboBox cboContractor;
        public CheckBox chbActiveContractor;
        private Label lblSeason;
        public ComboBox cboSeason;
        private Label lblWorkGroup;
        public ComboBox cboWorkGroup;
        public CheckBox chbActiveWorkGroup;
        public CheckBox chbRemoved;
        public DataGridView dgvCatalog;
        private Button btnRemove;
        private Button btnRecover;
        private Button btnModify;
        private Button btnAdd;
        public Button btnPriorizeOrder;
    }
}

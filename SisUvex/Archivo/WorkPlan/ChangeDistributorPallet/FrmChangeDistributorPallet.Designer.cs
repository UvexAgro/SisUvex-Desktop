namespace SisUvex.Archivo.WorkPlan.ChangeDistributorPallet
{
    partial class FrmChangeDistributorPallet
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangeDistributorPallet));
            nudCopiasEtiqueta = new NumericUpDown();
            lblCopiasEtiqueta = new Label();
            cboSeason = new ComboBox();
            label8 = new Label();
            btnImprimir = new Button();
            chkInvertirEtiqueta = new CheckBox();
            cboDistribuidor = new ComboBox();
            lblDistribuidor = new Label();
            btnLimpiar = new Button();
            btnAccept = new Button();
            lblTitulo = new Label();
            btnQuit = new Button();
            btnAddPallet = new Button();
            dgvPallet = new DataGridView();
            txbIdPallet = new TextBox();
            lblIdPallet = new Label();
            chbAjustarColumnas = new CheckBox();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiqueta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPallet).BeginInit();
            SuspendLayout();
            // 
            // nudCopiasEtiqueta
            // 
            nudCopiasEtiqueta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nudCopiasEtiqueta.Font = new Font("Segoe UI", 10.5F);
            nudCopiasEtiqueta.Location = new Point(623, 448);
            nudCopiasEtiqueta.Margin = new Padding(4);
            nudCopiasEtiqueta.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudCopiasEtiqueta.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCopiasEtiqueta.Name = "nudCopiasEtiqueta";
            nudCopiasEtiqueta.Size = new Size(35, 26);
            nudCopiasEtiqueta.TabIndex = 108;
            nudCopiasEtiqueta.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCopiasEtiqueta
            // 
            lblCopiasEtiqueta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCopiasEtiqueta.AutoSize = true;
            lblCopiasEtiqueta.Font = new Font("Segoe UI", 6.75F);
            lblCopiasEtiqueta.Location = new Point(623, 473);
            lblCopiasEtiqueta.Margin = new Padding(4, 0, 4, 0);
            lblCopiasEtiqueta.Name = "lblCopiasEtiqueta";
            lblCopiasEtiqueta.Size = new Size(32, 12);
            lblCopiasEtiqueta.TabIndex = 107;
            lblCopiasEtiqueta.Text = "Copias";
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.DropDownWidth = 400;
            cboSeason.Enabled = false;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(565, 51);
            cboSeason.Margin = new Padding(4);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(260, 29);
            cboSeason.TabIndex = 105;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(565, 36);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(50, 12);
            label8.TabIndex = 106;
            label8.Text = "Temporada";
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImprimir.Image = Properties.Resources.imprimirIcon16;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(513, 446);
            btnImprimir.Margin = new Padding(4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Padding = new Padding(4, 0, 0, 0);
            btnImprimir.Size = new Size(102, 29);
            btnImprimir.TabIndex = 110;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextAlign = ContentAlignment.MiddleRight;
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // chkInvertirEtiqueta
            // 
            chkInvertirEtiqueta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkInvertirEtiqueta.AutoSize = true;
            chkInvertirEtiqueta.Location = new Point(662, 450);
            chkInvertirEtiqueta.Margin = new Padding(0);
            chkInvertirEtiqueta.Name = "chkInvertirEtiqueta";
            chkInvertirEtiqueta.Size = new Size(79, 25);
            chkInvertirEtiqueta.TabIndex = 109;
            chkInvertirEtiqueta.Text = "Invertir";
            chkInvertirEtiqueta.TextAlign = ContentAlignment.TopLeft;
            chkInvertirEtiqueta.UseVisualStyleBackColor = true;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cboDistribuidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistribuidor.DropDownWidth = 400;
            cboDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.Location = new Point(158, 446);
            cboDistribuidor.Margin = new Padding(4);
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(320, 29);
            cboDistribuidor.TabIndex = 93;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDistribuidor.Location = new Point(7, 449);
            lblDistribuidor.Margin = new Padding(4, 0, 4, 0);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(143, 21);
            lblDistribuidor.TabIndex = 99;
            lblDistribuidor.Text = "Distribuidor nuevo:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpiar.Location = new Point(200, 483);
            btnLimpiar.Margin = new Padding(4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(163, 32);
            btnLimpiar.TabIndex = 88;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(9, 483);
            btnAccept.Margin = new Padding(4);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(183, 32);
            btnAccept.TabIndex = 86;
            btnAccept.Text = "Cambiar Distribuidor";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(15, 13);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(372, 31);
            lblTitulo.TabIndex = 90;
            lblTitulo.Text = "Cambiar distribuidor a pallets";
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(244, 48);
            btnQuit.Margin = new Padding(4);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(166, 32);
            btnQuit.TabIndex = 80;
            btnQuit.Text = "Quitar seleeccionado";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnAddPallet
            // 
            btnAddPallet.Location = new Point(158, 48);
            btnAddPallet.Margin = new Padding(4);
            btnAddPallet.Name = "btnAddPallet";
            btnAddPallet.Size = new Size(78, 32);
            btnAddPallet.TabIndex = 79;
            btnAddPallet.Text = "Agregar";
            btnAddPallet.UseVisualStyleBackColor = true;
            btnAddPallet.Click += btnAddPallet_Click;
            // 
            // dgvPallet
            // 
            dgvPallet.AllowUserToAddRows = false;
            dgvPallet.AllowUserToDeleteRows = false;
            dgvPallet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPallet.BackgroundColor = SystemColors.ControlLightLight;
            dgvPallet.BorderStyle = BorderStyle.Fixed3D;
            dgvPallet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPallet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPallet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPallet.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPallet.EnableHeadersVisualStyles = false;
            dgvPallet.ImeMode = ImeMode.NoControl;
            dgvPallet.Location = new Point(11, 88);
            dgvPallet.Margin = new Padding(4);
            dgvPallet.Name = "dgvPallet";
            dgvPallet.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPallet.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPallet.RowHeadersVisible = false;
            dgvPallet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPallet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPallet.Size = new Size(814, 350);
            dgvPallet.TabIndex = 85;
            // 
            // txbIdPallet
            // 
            txbIdPallet.Location = new Point(65, 48);
            txbIdPallet.Margin = new Padding(4);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(84, 29);
            txbIdPallet.TabIndex = 78;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // lblIdPallet
            // 
            lblIdPallet.AutoSize = true;
            lblIdPallet.Location = new Point(12, 52);
            lblIdPallet.Margin = new Padding(4, 0, 4, 0);
            lblIdPallet.Name = "lblIdPallet";
            lblIdPallet.Size = new Size(50, 21);
            lblIdPallet.TabIndex = 89;
            lblIdPallet.Text = "Pallet:";
            // 
            // chbAjustarColumnas
            // 
            chbAjustarColumnas.Appearance = Appearance.Button;
            chbAjustarColumnas.Location = new Point(481, 49);
            chbAjustarColumnas.Name = "chbAjustarColumnas";
            chbAjustarColumnas.Padding = new Padding(0, 0, 0, 1);
            chbAjustarColumnas.Size = new Size(44, 31);
            chbAjustarColumnas.TabIndex = 116;
            chbAjustarColumnas.Text = ">|<";
            chbAjustarColumnas.TextAlign = ContentAlignment.MiddleRight;
            chbAjustarColumnas.UseVisualStyleBackColor = true;
            chbAjustarColumnas.CheckedChanged += chbAjustarColumnas_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 6.75F);
            label12.Location = new Point(482, 37);
            label12.Name = "label12";
            label12.Size = new Size(33, 12);
            label12.TabIndex = 115;
            label12.Text = "Ajustar";
            // 
            // FrmChangeDistributorPallet
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 528);
            Controls.Add(chbAjustarColumnas);
            Controls.Add(label12);
            Controls.Add(nudCopiasEtiqueta);
            Controls.Add(lblCopiasEtiqueta);
            Controls.Add(cboSeason);
            Controls.Add(label8);
            Controls.Add(btnImprimir);
            Controls.Add(chkInvertirEtiqueta);
            Controls.Add(cboDistribuidor);
            Controls.Add(lblDistribuidor);
            Controls.Add(btnLimpiar);
            Controls.Add(btnAccept);
            Controls.Add(lblTitulo);
            Controls.Add(btnQuit);
            Controls.Add(btnAddPallet);
            Controls.Add(dgvPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(lblIdPallet);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FrmChangeDistributorPallet";
            Text = "Cambiar distribuidor pallet";
            Load += FrmChangeDistributorPallet_Load;
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiqueta).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPallet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public NumericUpDown nudCopiasEtiqueta;
        private Label lblCopiasEtiqueta;
        public ComboBox cboSeason;
        private Label label8;
        private Button btnImprimir;
        public CheckBox chkInvertirEtiqueta;
        public ComboBox cboDistribuidor;
        private Label lblDistribuidor;
        private Button btnLimpiar;
        private Button btnAccept;
        public Label lblTitulo;
        private Button btnQuit;
        private Button btnAddPallet;
        public DataGridView dgvPallet;
        public TextBox txbIdPallet;
        private Label lblIdPallet;
        private CheckBox chbAjustarColumnas;
        private Label label12;
    }
}
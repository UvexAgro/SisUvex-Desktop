namespace SisUvex.Archivo.WorkPlan.ConvertPallet
{
    partial class FrmConvertPallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConvertPallet));
            lblTitulo = new Label();
            btnQuit = new Button();
            btnAddPallet = new Button();
            dgvPallet = new DataGridView();
            lblIdPallet = new Label();
            txbIdPallet = new TextBox();
            txbWorkPlan = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cboWorkPlan = new ComboBox();
            txbIdWorkPlan = new TextBox();
            btnAccept = new Button();
            btnLimpiar = new Button();
            btnCancel = new Button();
            txbDay = new TextBox();
            label6 = new Label();
            cboWorkGroup = new ComboBox();
            label7 = new Label();
            cboLot = new ComboBox();
            cboVariety = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            cboContainer = new ComboBox();
            cboDistribuidor = new ComboBox();
            lblDistribuidor = new Label();
            label5 = new Label();
            cboPresentacion = new ComboBox();
            cboSeason = new ComboBox();
            label8 = new Label();
            lblCopiasEtiqueta = new Label();
            nudCopiasEtiqueta = new NumericUpDown();
            chkInvertirEtiqueta = new CheckBox();
            btnImprimir = new Button();
            btnDuplicateWorkPlan = new Button();
            lblWorkGroupDuplicate = new Label();
            cboWorkGroupDuplicate = new ComboBox();
            btnClone = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPallet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiqueta).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 31);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "Convertir pallet";
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(230, 56);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(129, 23);
            btnQuit.TabIndex = 3;
            btnQuit.Text = "Quitar seleeccionado";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // btnAddPallet
            // 
            btnAddPallet.Location = new Point(163, 56);
            btnAddPallet.Name = "btnAddPallet";
            btnAddPallet.Size = new Size(61, 23);
            btnAddPallet.TabIndex = 2;
            btnAddPallet.Text = "Agregar";
            btnAddPallet.UseVisualStyleBackColor = true;
            btnAddPallet.Click += btnAddPallet_Click;
            // 
            // dgvPallet
            // 
            dgvPallet.AllowUserToAddRows = false;
            dgvPallet.AllowUserToDeleteRows = false;
            dgvPallet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPallet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dgvPallet.BackgroundColor = SystemColors.ControlLightLight;
            dgvPallet.BorderStyle = BorderStyle.Fixed3D;
            dgvPallet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPallet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPallet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPallet.EnableHeadersVisualStyles = false;
            dgvPallet.ImeMode = ImeMode.NoControl;
            dgvPallet.Location = new Point(12, 332);
            dgvPallet.Name = "dgvPallet";
            dgvPallet.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPallet.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPallet.RowHeadersVisible = false;
            dgvPallet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPallet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPallet.Size = new Size(776, 263);
            dgvPallet.TabIndex = 7;
            // 
            // lblIdPallet
            // 
            lblIdPallet.AutoSize = true;
            lblIdPallet.Location = new Point(50, 59);
            lblIdPallet.Name = "lblIdPallet";
            lblIdPallet.Size = new Size(39, 15);
            lblIdPallet.TabIndex = 13;
            lblIdPallet.Text = "Pallet:";
            // 
            // txbIdPallet
            // 
            txbIdPallet.Location = new Point(91, 56);
            txbIdPallet.MaxLength = 5;
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(66, 23);
            txbIdPallet.TabIndex = 0;
            txbIdPallet.KeyPress += txbIdPallet_KeyPress;
            // 
            // txbWorkPlan
            // 
            txbWorkPlan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbWorkPlan.Enabled = false;
            txbWorkPlan.Location = new Point(210, 85);
            txbWorkPlan.MaximumSize = new Size(900, 0);
            txbWorkPlan.MaxLength = 5;
            txbWorkPlan.Name = "txbWorkPlan";
            txbWorkPlan.Size = new Size(578, 23);
            txbWorkPlan.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 90);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 22;
            label1.Text = "Plan de trabajo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 253);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 23;
            label2.Text = "Plan de trabajo nuevo";
            // 
            // cboWorkPlan
            // 
            cboWorkPlan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboWorkPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkPlan.Font = new Font("Segoe UI", 9F);
            cboWorkPlan.FormattingEnabled = true;
            cboWorkPlan.Location = new Point(14, 269);
            cboWorkPlan.Margin = new Padding(1);
            cboWorkPlan.MaximumSize = new Size(900, 0);
            cboWorkPlan.Name = "cboWorkPlan";
            cboWorkPlan.Size = new Size(776, 23);
            cboWorkPlan.TabIndex = 6;
            // 
            // txbIdWorkPlan
            // 
            txbIdWorkPlan.Enabled = false;
            txbIdWorkPlan.Location = new Point(91, 85);
            txbIdWorkPlan.MaxLength = 5;
            txbIdWorkPlan.Name = "txbIdWorkPlan";
            txbIdWorkPlan.Size = new Size(41, 23);
            txbIdWorkPlan.TabIndex = 3;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(12, 601);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(127, 23);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Convertir pallets";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpiar.Location = new Point(282, 601);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(127, 23);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(147, 601);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txbDay
            // 
            txbDay.Enabled = false;
            txbDay.Location = new Point(134, 85);
            txbDay.MaxLength = 5;
            txbDay.Name = "txbDay";
            txbDay.Size = new Size(70, 23);
            txbDay.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(587, 179);
            label6.Name = "label6";
            label6.Size = new Size(40, 12);
            label6.TabIndex = 67;
            label6.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 400;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(587, 191);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(203, 23);
            cboWorkGroup.TabIndex = 60;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(587, 214);
            label7.Name = "label7";
            label7.Size = new Size(22, 12);
            label7.TabIndex = 66;
            label7.Text = "Lote";
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.DropDownWidth = 400;
            cboLot.FormattingEnabled = true;
            cboLot.Location = new Point(587, 226);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(203, 23);
            cboLot.TabIndex = 61;
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.DropDownWidth = 400;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(136, 226);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(203, 23);
            cboVariety.TabIndex = 57;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(136, 214);
            label3.Name = "label3";
            label3.Size = new Size(40, 12);
            label3.TabIndex = 64;
            label3.Text = "Variedad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(345, 179);
            label4.Name = "label4";
            label4.Size = new Size(52, 12);
            label4.TabIndex = 65;
            label4.Text = "Contenedor";
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.DropDownWidth = 400;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(345, 191);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(236, 23);
            cboContainer.TabIndex = 58;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistribuidor.DropDownWidth = 400;
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.Location = new Point(136, 191);
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(203, 23);
            cboDistribuidor.TabIndex = 56;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 6.75F);
            lblDistribuidor.Location = new Point(136, 179);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(50, 12);
            lblDistribuidor.TabIndex = 62;
            lblDistribuidor.Text = "Distribuidor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(345, 214);
            label5.Name = "label5";
            label5.Size = new Size(56, 12);
            label5.TabIndex = 63;
            label5.Text = "Presentación";
            // 
            // cboPresentacion
            // 
            cboPresentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentacion.DropDownWidth = 400;
            cboPresentacion.FormattingEnabled = true;
            cboPresentacion.Location = new Point(345, 226);
            cboPresentacion.Name = "cboPresentacion";
            cboPresentacion.Size = new Size(236, 23);
            cboPresentacion.TabIndex = 59;
            // 
            // cboSeason
            // 
            cboSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeason.DropDownWidth = 400;
            cboSeason.Enabled = false;
            cboSeason.FormattingEnabled = true;
            cboSeason.Location = new Point(585, 56);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(203, 23);
            cboSeason.TabIndex = 68;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(585, 41);
            label8.Name = "label8";
            label8.Size = new Size(50, 12);
            label8.TabIndex = 69;
            label8.Text = "Temporada";
            // 
            // lblCopiasEtiqueta
            // 
            lblCopiasEtiqueta.AutoSize = true;
            lblCopiasEtiqueta.Font = new Font("Segoe UI", 6.75F);
            lblCopiasEtiqueta.Location = new Point(102, 293);
            lblCopiasEtiqueta.Name = "lblCopiasEtiqueta";
            lblCopiasEtiqueta.Size = new Size(32, 12);
            lblCopiasEtiqueta.TabIndex = 70;
            lblCopiasEtiqueta.Text = "Copias";
            // 
            // nudCopiasEtiqueta
            // 
            nudCopiasEtiqueta.Location = new Point(103, 306);
            nudCopiasEtiqueta.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudCopiasEtiqueta.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCopiasEtiqueta.Name = "nudCopiasEtiqueta";
            nudCopiasEtiqueta.Size = new Size(27, 23);
            nudCopiasEtiqueta.TabIndex = 71;
            nudCopiasEtiqueta.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkInvertirEtiqueta
            // 
            chkInvertirEtiqueta.AutoSize = true;
            chkInvertirEtiqueta.Location = new Point(133, 311);
            chkInvertirEtiqueta.Margin = new Padding(0);
            chkInvertirEtiqueta.Name = "chkInvertirEtiqueta";
            chkInvertirEtiqueta.Size = new Size(63, 19);
            chkInvertirEtiqueta.TabIndex = 72;
            chkInvertirEtiqueta.Text = "Invertir";
            chkInvertirEtiqueta.TextAlign = ContentAlignment.TopLeft;
            chkInvertirEtiqueta.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            btnImprimir.Image = Properties.Resources.imprimirIcon16;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(18, 304);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(79, 26);
            btnImprimir.TabIndex = 73;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextAlign = ContentAlignment.MiddleRight;
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnDuplicateWorkPlan
            // 
            btnDuplicateWorkPlan.Location = new Point(186, 120);
            btnDuplicateWorkPlan.Name = "btnDuplicateWorkPlan";
            btnDuplicateWorkPlan.Size = new Size(85, 26);
            btnDuplicateWorkPlan.TabIndex = 74;
            btnDuplicateWorkPlan.Text = "Duplicar plan";
            btnDuplicateWorkPlan.UseVisualStyleBackColor = true;
            btnDuplicateWorkPlan.Click += btnDuplicar_Click;
            // 
            // lblWorkGroupDuplicate
            // 
            lblWorkGroupDuplicate.AutoSize = true;
            lblWorkGroupDuplicate.Font = new Font("Segoe UI", 6.75F);
            lblWorkGroupDuplicate.Location = new Point(277, 110);
            lblWorkGroupDuplicate.Name = "lblWorkGroupDuplicate";
            lblWorkGroupDuplicate.Size = new Size(66, 12);
            lblWorkGroupDuplicate.TabIndex = 76;
            lblWorkGroupDuplicate.Text = "Nueva cuadrilla";
            lblWorkGroupDuplicate.Visible = false;
            // 
            // cboWorkGroupDuplicate
            // 
            cboWorkGroupDuplicate.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroupDuplicate.DropDownWidth = 400;
            cboWorkGroupDuplicate.FormattingEnabled = true;
            cboWorkGroupDuplicate.Location = new Point(277, 122);
            cboWorkGroupDuplicate.Name = "cboWorkGroupDuplicate";
            cboWorkGroupDuplicate.Size = new Size(203, 23);
            cboWorkGroupDuplicate.TabIndex = 75;
            cboWorkGroupDuplicate.Visible = false;
            // 
            // btnClone
            // 
            btnClone.Location = new Point(486, 120);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(73, 26);
            btnClone.TabIndex = 77;
            btnClone.Text = "Completo";
            btnClone.UseVisualStyleBackColor = true;
            btnClone.Click += btnClone_Click;
            // 
            // FrmConvertPallet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 636);
            Controls.Add(btnClone);
            Controls.Add(lblWorkGroupDuplicate);
            Controls.Add(cboWorkGroupDuplicate);
            Controls.Add(btnDuplicateWorkPlan);
            Controls.Add(nudCopiasEtiqueta);
            Controls.Add(lblCopiasEtiqueta);
            Controls.Add(cboSeason);
            Controls.Add(label8);
            Controls.Add(btnImprimir);
            Controls.Add(chkInvertirEtiqueta);
            Controls.Add(label6);
            Controls.Add(cboWorkGroup);
            Controls.Add(label7);
            Controls.Add(cboLot);
            Controls.Add(cboVariety);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(cboContainer);
            Controls.Add(cboDistribuidor);
            Controls.Add(lblDistribuidor);
            Controls.Add(label5);
            Controls.Add(cboPresentacion);
            Controls.Add(txbDay);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(txbIdWorkPlan);
            Controls.Add(cboWorkPlan);
            Controls.Add(txbWorkPlan);
            Controls.Add(lblTitulo);
            Controls.Add(btnQuit);
            Controls.Add(btnAddPallet);
            Controls.Add(dgvPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblIdPallet);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmConvertPallet";
            Text = "Convertir pallet";
            Load += FrmConvertPallet_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPallet).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiqueta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTitulo;
        private Button btnQuit;
        private Button btnAddPallet;
        public DataGridView dgvPallet;
        private Label lblIdPallet;
        private Label label1;
        private Label label2;
        public ComboBox cboWorkPlan;
        public TextBox txbIdPallet;
        public TextBox txbIdWorkPlan;
        public TextBox txbWorkPlan;
        private Button btnAccept;
        private Button btnLimpiar;
        private Button btnCancel;
        public TextBox txbDay;
        private Label label6;
        public ComboBox cboWorkGroup;
        private Label label7;
        public ComboBox cboLot;
        public ComboBox cboVariety;
        private Label label3;
        private Label label4;
        public ComboBox cboContainer;
        public ComboBox cboDistribuidor;
        private Label lblDistribuidor;
        private Label label5;
        public ComboBox cboPresentacion;
        public ComboBox cboSeason;
        private Label label8;
        private Label lblCopiasEtiqueta;
        public NumericUpDown nudCopiasEtiqueta;
        public CheckBox chkInvertirEtiqueta;
        private Button btnImprimir;
        private Button btnDuplicateWorkPlan;
        private Label lblWorkGroupDuplicate;
        public ComboBox cboWorkGroupDuplicate;
        private Button btnClone;
    }
}
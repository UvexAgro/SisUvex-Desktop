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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            btnClone = new Button();
            lblWorkGroupDuplicate = new Label();
            cboWorkGroupDuplicate = new ComboBox();
            btnDuplicateWorkPlan = new Button();
            nudCopiasEtiqueta = new NumericUpDown();
            lblCopiasEtiqueta = new Label();
            cboSeason = new ComboBox();
            label8 = new Label();
            btnImprimir = new Button();
            chkInvertirEtiqueta = new CheckBox();
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
            btnLimpiar = new Button();
            btnCancel = new Button();
            btnAccept = new Button();
            lblTitulo = new Label();
            btnQuit = new Button();
            btnAddPallet = new Button();
            dgvPallet = new DataGridView();
            txbIdPallet = new TextBox();
            lblIdPallet = new Label();
            chbAjustarColumnas = new CheckBox();
            label12 = new Label();
            dgvGtines = new DataGridView();
            dgvGtinDistribuidor = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiqueta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPallet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGtines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGtinDistribuidor).BeginInit();
            SuspendLayout();
            // 
            // btnClone
            // 
            btnClone.Location = new Point(1156, 658);
            btnClone.Margin = new Padding(4);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(94, 36);
            btnClone.TabIndex = 114;
            btnClone.Text = "Completo";
            btnClone.UseVisualStyleBackColor = true;
            btnClone.Visible = false;
            // 
            // lblWorkGroupDuplicate
            // 
            lblWorkGroupDuplicate.AutoSize = true;
            lblWorkGroupDuplicate.Font = new Font("Segoe UI", 6.75F);
            lblWorkGroupDuplicate.Location = new Point(887, 644);
            lblWorkGroupDuplicate.Margin = new Padding(4, 0, 4, 0);
            lblWorkGroupDuplicate.Name = "lblWorkGroupDuplicate";
            lblWorkGroupDuplicate.Size = new Size(66, 12);
            lblWorkGroupDuplicate.TabIndex = 113;
            lblWorkGroupDuplicate.Text = "Nueva cuadrilla";
            lblWorkGroupDuplicate.Visible = false;
            // 
            // cboWorkGroupDuplicate
            // 
            cboWorkGroupDuplicate.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroupDuplicate.DropDownWidth = 400;
            cboWorkGroupDuplicate.FormattingEnabled = true;
            cboWorkGroupDuplicate.Location = new Point(887, 661);
            cboWorkGroupDuplicate.Margin = new Padding(4);
            cboWorkGroupDuplicate.Name = "cboWorkGroupDuplicate";
            cboWorkGroupDuplicate.Size = new Size(260, 29);
            cboWorkGroupDuplicate.TabIndex = 112;
            cboWorkGroupDuplicate.Visible = false;
            // 
            // btnDuplicateWorkPlan
            // 
            btnDuplicateWorkPlan.Location = new Point(770, 658);
            btnDuplicateWorkPlan.Margin = new Padding(4);
            btnDuplicateWorkPlan.Name = "btnDuplicateWorkPlan";
            btnDuplicateWorkPlan.Size = new Size(109, 36);
            btnDuplicateWorkPlan.TabIndex = 111;
            btnDuplicateWorkPlan.Text = "Duplicar plan";
            btnDuplicateWorkPlan.UseVisualStyleBackColor = true;
            // 
            // nudCopiasEtiqueta
            // 
            nudCopiasEtiqueta.Location = new Point(740, 607);
            nudCopiasEtiqueta.Margin = new Padding(4);
            nudCopiasEtiqueta.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudCopiasEtiqueta.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCopiasEtiqueta.Name = "nudCopiasEtiqueta";
            nudCopiasEtiqueta.Size = new Size(35, 29);
            nudCopiasEtiqueta.TabIndex = 108;
            nudCopiasEtiqueta.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCopiasEtiqueta
            // 
            lblCopiasEtiqueta.AutoSize = true;
            lblCopiasEtiqueta.Font = new Font("Segoe UI", 6.75F);
            lblCopiasEtiqueta.Location = new Point(738, 589);
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
            cboSeason.Location = new Point(753, 48);
            cboSeason.Margin = new Padding(4);
            cboSeason.Name = "cboSeason";
            cboSeason.Size = new Size(260, 29);
            cboSeason.TabIndex = 105;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 6.75F);
            label8.Location = new Point(753, 27);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(50, 12);
            label8.TabIndex = 106;
            label8.Text = "Temporada";
            // 
            // btnImprimir
            // 
            btnImprimir.Image = Properties.Resources.imprimirIcon16;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(630, 604);
            btnImprimir.Margin = new Padding(4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(102, 36);
            btnImprimir.TabIndex = 110;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextAlign = ContentAlignment.MiddleRight;
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // chkInvertirEtiqueta
            // 
            chkInvertirEtiqueta.AutoSize = true;
            chkInvertirEtiqueta.Location = new Point(778, 614);
            chkInvertirEtiqueta.Margin = new Padding(0);
            chkInvertirEtiqueta.Name = "chkInvertirEtiqueta";
            chkInvertirEtiqueta.Size = new Size(79, 25);
            chkInvertirEtiqueta.TabIndex = 109;
            chkInvertirEtiqueta.Text = "Invertir";
            chkInvertirEtiqueta.TextAlign = ContentAlignment.TopLeft;
            chkInvertirEtiqueta.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 6.75F);
            label6.Location = new Point(753, 705);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(40, 12);
            label6.TabIndex = 104;
            label6.Text = "Cuadrilla";
            // 
            // cboWorkGroup
            // 
            cboWorkGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkGroup.DropDownWidth = 400;
            cboWorkGroup.FormattingEnabled = true;
            cboWorkGroup.Location = new Point(753, 722);
            cboWorkGroup.Margin = new Padding(4);
            cboWorkGroup.Name = "cboWorkGroup";
            cboWorkGroup.Size = new Size(260, 29);
            cboWorkGroup.TabIndex = 97;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 6.75F);
            label7.Location = new Point(753, 754);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(22, 12);
            label7.TabIndex = 103;
            label7.Text = "Lote";
            // 
            // cboLot
            // 
            cboLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLot.DropDownWidth = 400;
            cboLot.FormattingEnabled = true;
            cboLot.Location = new Point(753, 771);
            cboLot.Margin = new Padding(4);
            cboLot.Name = "cboLot";
            cboLot.Size = new Size(260, 29);
            cboLot.TabIndex = 98;
            // 
            // cboVariety
            // 
            cboVariety.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariety.DropDownWidth = 400;
            cboVariety.FormattingEnabled = true;
            cboVariety.Location = new Point(174, 771);
            cboVariety.Margin = new Padding(4);
            cboVariety.Name = "cboVariety";
            cboVariety.Size = new Size(260, 29);
            cboVariety.TabIndex = 94;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6.75F);
            label3.Location = new Point(174, 754);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(40, 12);
            label3.TabIndex = 101;
            label3.Text = "Variedad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6.75F);
            label4.Location = new Point(442, 705);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(52, 12);
            label4.TabIndex = 102;
            label4.Text = "Contenedor";
            // 
            // cboContainer
            // 
            cboContainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboContainer.DropDownWidth = 400;
            cboContainer.FormattingEnabled = true;
            cboContainer.Location = new Point(442, 722);
            cboContainer.Margin = new Padding(4);
            cboContainer.Name = "cboContainer";
            cboContainer.Size = new Size(302, 29);
            cboContainer.TabIndex = 95;
            // 
            // cboDistribuidor
            // 
            cboDistribuidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistribuidor.DropDownWidth = 400;
            cboDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboDistribuidor.FormattingEnabled = true;
            cboDistribuidor.Location = new Point(173, 101);
            cboDistribuidor.Margin = new Padding(4);
            cboDistribuidor.Name = "cboDistribuidor";
            cboDistribuidor.Size = new Size(320, 29);
            cboDistribuidor.TabIndex = 93;
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDistribuidor.Location = new Point(22, 104);
            lblDistribuidor.Margin = new Padding(4, 0, 4, 0);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(143, 21);
            lblDistribuidor.TabIndex = 99;
            lblDistribuidor.Text = "Distribuidor nuevo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 6.75F);
            label5.Location = new Point(442, 754);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 12);
            label5.TabIndex = 100;
            label5.Text = "Presentación";
            // 
            // cboPresentacion
            // 
            cboPresentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPresentacion.DropDownWidth = 400;
            cboPresentacion.FormattingEnabled = true;
            cboPresentacion.Location = new Point(442, 771);
            cboPresentacion.Margin = new Padding(4);
            cboPresentacion.Name = "cboPresentacion";
            cboPresentacion.Size = new Size(302, 29);
            cboPresentacion.TabIndex = 96;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLimpiar.Location = new Point(357, 583);
            btnLimpiar.Margin = new Padding(4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(163, 32);
            btnLimpiar.TabIndex = 88;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(183, 583);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(163, 32);
            btnCancel.TabIndex = 87;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAccept.Location = new Point(9, 583);
            btnAccept.Margin = new Padding(4);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(163, 32);
            btnAccept.TabIndex = 86;
            btnAccept.Text = "Convertir pallets";
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
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvPallet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvPallet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgvPallet.DefaultCellStyle = dataGridViewCellStyle11;
            dgvPallet.EnableHeadersVisualStyles = false;
            dgvPallet.ImeMode = ImeMode.NoControl;
            dgvPallet.Location = new Point(9, 138);
            dgvPallet.Margin = new Padding(4);
            dgvPallet.Name = "dgvPallet";
            dgvPallet.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgvPallet.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgvPallet.RowHeadersVisible = false;
            dgvPallet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPallet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPallet.Size = new Size(1258, 437);
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
            chbAjustarColumnas.Location = new Point(526, 100);
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
            label12.Location = new Point(527, 88);
            label12.Name = "label12";
            label12.Size = new Size(33, 12);
            label12.TabIndex = 115;
            label12.Text = "Ajustar";
            // 
            // dgvGtines
            // 
            dgvGtines.AllowUserToAddRows = false;
            dgvGtines.AllowUserToDeleteRows = false;
            dgvGtines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGtines.BackgroundColor = SystemColors.ControlLightLight;
            dgvGtines.BorderStyle = BorderStyle.Fixed3D;
            dgvGtines.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = SystemColors.Control;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgvGtines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgvGtines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Window;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dgvGtines.DefaultCellStyle = dataGridViewCellStyle14;
            dgvGtines.EnableHeadersVisualStyles = false;
            dgvGtines.ImeMode = ImeMode.NoControl;
            dgvGtines.Location = new Point(9, 623);
            dgvGtines.Margin = new Padding(4);
            dgvGtines.Name = "dgvGtines";
            dgvGtines.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = SystemColors.Control;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dgvGtines.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dgvGtines.RowHeadersVisible = false;
            dgvGtines.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvGtines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGtines.Size = new Size(209, 164);
            dgvGtines.TabIndex = 117;
            // 
            // dgvGtinDistribuidor
            // 
            dgvGtinDistribuidor.AllowUserToAddRows = false;
            dgvGtinDistribuidor.AllowUserToDeleteRows = false;
            dgvGtinDistribuidor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvGtinDistribuidor.BackgroundColor = SystemColors.ControlLightLight;
            dgvGtinDistribuidor.BorderStyle = BorderStyle.Fixed3D;
            dgvGtinDistribuidor.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = SystemColors.Control;
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle16.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            dgvGtinDistribuidor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            dgvGtinDistribuidor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = SystemColors.Window;
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle17.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.False;
            dgvGtinDistribuidor.DefaultCellStyle = dataGridViewCellStyle17;
            dgvGtinDistribuidor.EnableHeadersVisualStyles = false;
            dgvGtinDistribuidor.ImeMode = ImeMode.NoControl;
            dgvGtinDistribuidor.Location = new Point(284, 623);
            dgvGtinDistribuidor.Margin = new Padding(4);
            dgvGtinDistribuidor.Name = "dgvGtinDistribuidor";
            dgvGtinDistribuidor.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = SystemColors.Control;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle18.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.True;
            dgvGtinDistribuidor.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            dgvGtinDistribuidor.RowHeadersVisible = false;
            dgvGtinDistribuidor.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvGtinDistribuidor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGtinDistribuidor.Size = new Size(831, 164);
            dgvGtinDistribuidor.TabIndex = 118;
            // 
            // FrmChangeDistributorPallet
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 823);
            Controls.Add(dgvGtinDistribuidor);
            Controls.Add(dgvGtines);
            Controls.Add(chbAjustarColumnas);
            Controls.Add(label12);
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
            Controls.Add(btnLimpiar);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(lblTitulo);
            Controls.Add(btnQuit);
            Controls.Add(btnAddPallet);
            Controls.Add(dgvPallet);
            Controls.Add(txbIdPallet);
            Controls.Add(lblIdPallet);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmChangeDistributorPallet";
            Text = "FrmChangeDistributorPallet";
            Load += FrmChangeDistributorPallet_Load;
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiqueta).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPallet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGtines).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGtinDistribuidor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClone;
        private Label lblWorkGroupDuplicate;
        public ComboBox cboWorkGroupDuplicate;
        private Button btnDuplicateWorkPlan;
        public NumericUpDown nudCopiasEtiqueta;
        private Label lblCopiasEtiqueta;
        public ComboBox cboSeason;
        private Label label8;
        private Button btnImprimir;
        public CheckBox chkInvertirEtiqueta;
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
        private Button btnLimpiar;
        private Button btnCancel;
        private Button btnAccept;
        public Label lblTitulo;
        private Button btnQuit;
        private Button btnAddPallet;
        public DataGridView dgvPallet;
        public TextBox txbIdPallet;
        private Label lblIdPallet;
        private CheckBox chbAjustarColumnas;
        private Label label12;
        public DataGridView dgvGtines;
        public DataGridView dgvGtinDistribuidor;
    }
}
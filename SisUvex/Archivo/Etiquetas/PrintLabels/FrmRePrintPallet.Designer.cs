namespace SisUvex.Archivo.Reimprimir
{
    partial class FrmRePrintPallet
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRePrintPallet));
            lblReprintPallet = new Label();
            label1 = new Label();
            txbRePrintCode = new TextBox();
            btnConsultar = new Button();
            gpbAcciones = new GroupBox();
            nudCopiasEtiquetas = new NumericUpDown();
            label3 = new Label();
            txbUpdateBoxes = new TextBox();
            button2 = new Button();
            chbRevesePalletTag = new CheckBox();
            chbFechaOmitidaPallet = new CheckBox();
            labelCopias = new Label();
            gpbDatosPallet = new GroupBox();
            scrollPalletInfo = new Panel();
            tablePalletInfo = new TableLayoutPanel();
            gpbEstiba = new GroupBox();
            dgvPalletsEstiba = new DataGridView();
            lblNotaEstiba = new Label();
            gpbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiquetas).BeginInit();
            gpbDatosPallet.SuspendLayout();
            scrollPalletInfo.SuspendLayout();
            gpbEstiba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPalletsEstiba).BeginInit();
            SuspendLayout();
            // 
            // lblReprintPallet
            // 
            lblReprintPallet.AutoSize = true;
            lblReprintPallet.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReprintPallet.Location = new Point(12, 9);
            lblReprintPallet.Name = "lblReprintPallet";
            lblReprintPallet.Size = new Size(315, 29);
            lblReprintPallet.TabIndex = 0;
            lblReprintPallet.Text = "Reimprimir etiqueta pallet";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F);
            label1.Location = new Point(33, 47);
            label1.Name = "label1";
            label1.Size = new Size(163, 29);
            label1.TabIndex = 1;
            label1.Text = "Código pallet:";
            // 
            // txbRePrintCode
            // 
            txbRePrintCode.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbRePrintCode.Location = new Point(190, 41);
            txbRePrintCode.Name = "txbRePrintCode";
            txbRePrintCode.Size = new Size(97, 39);
            txbRePrintCode.TabIndex = 2;
            txbRePrintCode.KeyDown += txbRePrintCode_KeyDown;
            // 
            // btnConsultar
            // 
            btnConsultar.Font = new Font("Segoe UI", 9.75F);
            btnConsultar.Image = Properties.Resources.buscarIcon32;
            btnConsultar.Location = new Point(290, 40);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(41, 41);
            btnConsultar.TabIndex = 3;
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // gpbAcciones
            // 
            gpbAcciones.Controls.Add(nudCopiasEtiquetas);
            gpbAcciones.Controls.Add(label3);
            gpbAcciones.Controls.Add(txbUpdateBoxes);
            gpbAcciones.Controls.Add(button2);
            gpbAcciones.Controls.Add(chbRevesePalletTag);
            gpbAcciones.Controls.Add(chbFechaOmitidaPallet);
            gpbAcciones.Controls.Add(labelCopias);
            gpbAcciones.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            gpbAcciones.Location = new Point(14, 87);
            gpbAcciones.Name = "gpbAcciones";
            gpbAcciones.Size = new Size(338, 104);
            gpbAcciones.TabIndex = 4;
            gpbAcciones.TabStop = false;
            gpbAcciones.Text = "Impresión y cajas (opcional)";
            // 
            // nudCopiasEtiquetas
            // 
            nudCopiasEtiquetas.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudCopiasEtiquetas.Location = new Point(115, 24);
            nudCopiasEtiquetas.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudCopiasEtiquetas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCopiasEtiquetas.Name = "nudCopiasEtiquetas";
            nudCopiasEtiquetas.Size = new Size(36, 39);
            nudCopiasEtiquetas.TabIndex = 1;
            nudCopiasEtiquetas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(25, 74);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 2;
            label3.Text = "Actualizar cajas";
            // 
            // txbUpdateBoxes
            // 
            txbUpdateBoxes.Font = new Font("Segoe UI", 9.75F);
            txbUpdateBoxes.Location = new Point(115, 69);
            txbUpdateBoxes.Name = "txbUpdateBoxes";
            txbUpdateBoxes.Size = new Size(36, 25);
            txbUpdateBoxes.TabIndex = 3;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.Image = Properties.Resources.imprimirIcon32;
            button2.Location = new Point(157, 23);
            button2.Name = "button2";
            button2.Size = new Size(41, 41);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // chbRevesePalletTag
            // 
            chbRevesePalletTag.AutoSize = true;
            chbRevesePalletTag.Font = new Font("Segoe UI", 9F);
            chbRevesePalletTag.Location = new Point(204, 23);
            chbRevesePalletTag.Name = "chbRevesePalletTag";
            chbRevesePalletTag.Size = new Size(109, 19);
            chbRevesePalletTag.TabIndex = 5;
            chbRevesePalletTag.Text = "Invertir etiqueta";
            chbRevesePalletTag.UseVisualStyleBackColor = true;
            // 
            // chbFechaOmitidaPallet
            // 
            chbFechaOmitidaPallet.AutoSize = true;
            chbFechaOmitidaPallet.Font = new Font("Segoe UI", 9F);
            chbFechaOmitidaPallet.Location = new Point(204, 45);
            chbFechaOmitidaPallet.Name = "chbFechaOmitidaPallet";
            chbFechaOmitidaPallet.Size = new Size(92, 19);
            chbFechaOmitidaPallet.TabIndex = 6;
            chbFechaOmitidaPallet.Text = "Omitir fecha";
            chbFechaOmitidaPallet.UseVisualStyleBackColor = true;
            // 
            // labelCopias
            // 
            labelCopias.AutoSize = true;
            labelCopias.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCopias.Location = new Point(7, 27);
            labelCopias.Name = "labelCopias";
            labelCopias.Size = new Size(109, 32);
            labelCopias.TabIndex = 0;
            labelCopias.Text = "Cantidad";
            // 
            // gpbDatosPallet
            // 
            gpbDatosPallet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gpbDatosPallet.Controls.Add(scrollPalletInfo);
            gpbDatosPallet.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            gpbDatosPallet.Location = new Point(14, 197);
            gpbDatosPallet.Name = "gpbDatosPallet";
            gpbDatosPallet.Padding = new Padding(8);
            gpbDatosPallet.Size = new Size(338, 490);
            gpbDatosPallet.TabIndex = 5;
            gpbDatosPallet.TabStop = false;
            gpbDatosPallet.Text = "Datos del pallet";
            // 
            // scrollPalletInfo
            // 
            scrollPalletInfo.AutoScroll = true;
            scrollPalletInfo.Controls.Add(tablePalletInfo);
            scrollPalletInfo.Dock = DockStyle.Fill;
            scrollPalletInfo.Location = new Point(8, 26);
            scrollPalletInfo.Name = "scrollPalletInfo";
            scrollPalletInfo.Size = new Size(322, 456);
            scrollPalletInfo.TabIndex = 0;
            // 
            // tablePalletInfo
            // 
            tablePalletInfo.AutoSize = true;
            tablePalletInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tablePalletInfo.ColumnCount = 2;
            tablePalletInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tablePalletInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePalletInfo.Dock = DockStyle.Top;
            tablePalletInfo.Location = new Point(0, 0);
            tablePalletInfo.Margin = new Padding(0);
            tablePalletInfo.Name = "tablePalletInfo";
            tablePalletInfo.Padding = new Padding(0, 0, 12, 0);
            tablePalletInfo.RowCount = 1;
            tablePalletInfo.RowStyles.Add(new RowStyle());
            tablePalletInfo.Size = new Size(322, 0);
            tablePalletInfo.TabIndex = 0;
            // 
            // gpbEstiba
            // 
            gpbEstiba.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbEstiba.Controls.Add(dgvPalletsEstiba);
            gpbEstiba.Controls.Add(lblNotaEstiba);
            gpbEstiba.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            gpbEstiba.Location = new Point(358, 197);
            gpbEstiba.Name = "gpbEstiba";
            gpbEstiba.Padding = new Padding(8);
            gpbEstiba.Size = new Size(534, 490);
            gpbEstiba.TabIndex = 6;
            gpbEstiba.TabStop = false;
            gpbEstiba.Text = "Pallets en estiba";
            // 
            // dgvPalletsEstiba
            // 
            dgvPalletsEstiba.AllowUserToAddRows = false;
            dgvPalletsEstiba.AllowUserToDeleteRows = false;
            dgvPalletsEstiba.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPalletsEstiba.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPalletsEstiba.BackgroundColor = SystemColors.Control;
            dgvPalletsEstiba.BorderStyle = BorderStyle.Fixed3D;
            dgvPalletsEstiba.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPalletsEstiba.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPalletsEstiba.ColumnHeadersHeight = 58;
            dgvPalletsEstiba.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPalletsEstiba.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPalletsEstiba.Dock = DockStyle.Fill;
            dgvPalletsEstiba.EnableHeadersVisualStyles = false;
            dgvPalletsEstiba.ImeMode = ImeMode.NoControl;
            dgvPalletsEstiba.Location = new Point(8, 45);
            dgvPalletsEstiba.Name = "dgvPalletsEstiba";
            dgvPalletsEstiba.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPalletsEstiba.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPalletsEstiba.RowHeadersVisible = false;
            dgvPalletsEstiba.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPalletsEstiba.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPalletsEstiba.Size = new Size(518, 437);
            dgvPalletsEstiba.TabIndex = 17;
            // 
            // lblNotaEstiba
            // 
            lblNotaEstiba.Dock = DockStyle.Top;
            lblNotaEstiba.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNotaEstiba.ForeColor = SystemColors.GrayText;
            lblNotaEstiba.Location = new Point(8, 26);
            lblNotaEstiba.Name = "lblNotaEstiba";
            lblNotaEstiba.Padding = new Padding(0, 0, 0, 4);
            lblNotaEstiba.Size = new Size(518, 19);
            lblNotaEstiba.TabIndex = 1;
            lblNotaEstiba.Text = "Misma información que vw_PackPalletCon para la estiba. Solo se reimprime el pallet buscado.";
            // 
            // FrmRePrintPallet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 699);
            Controls.Add(gpbEstiba);
            Controls.Add(gpbDatosPallet);
            Controls.Add(gpbAcciones);
            Controls.Add(btnConsultar);
            Controls.Add(txbRePrintCode);
            Controls.Add(label1);
            Controls.Add(lblReprintPallet);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(520, 560);
            Name = "FrmRePrintPallet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reimprimir pallet";
            Load += FrmRePrintPallet_Load;
            gpbAcciones.ResumeLayout(false);
            gpbAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCopiasEtiquetas).EndInit();
            gpbDatosPallet.ResumeLayout(false);
            scrollPalletInfo.ResumeLayout(false);
            scrollPalletInfo.PerformLayout();
            gpbEstiba.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPalletsEstiba).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReprintPallet;
        private Label label1;
        private TextBox txbRePrintCode;
        private Button btnConsultar;
        private GroupBox gpbAcciones;
        private Label labelCopias;
        private NumericUpDown nudCopiasEtiquetas;
        private Label label3;
        private TextBox txbUpdateBoxes;
        private Button button2;
        public CheckBox chbRevesePalletTag;
        public CheckBox chbFechaOmitidaPallet;
        private GroupBox gpbDatosPallet;
        private Panel scrollPalletInfo;
        private TableLayoutPanel tablePalletInfo;
        private GroupBox gpbEstiba;
        private Label lblNotaEstiba;
        public DataGridView dgvPalletsEstiba;
    }
}

namespace SisUvex.Nomina.Actualizar_datos_empelado
{
    partial class FrmActualizarDatosEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActualizarDatosEmpleados));
            txbExcelPath = new TextBox();
            ofdExcel = new OpenFileDialog();
            dgvEmployees = new DataGridView();
            btnNSS = new Button();
            btnRFC = new Button();
            btnLP = new Button();
            btnCURP = new Button();
            btnClear = new Button();
            btnExaminar = new Button();
            btnCP = new Button();
            btnSheets = new Button();
            cboSheets = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // txbExcelPath
            // 
            txbExcelPath.Enabled = false;
            txbExcelPath.Location = new Point(12, 12);
            txbExcelPath.Name = "txbExcelPath";
            txbExcelPath.Size = new Size(430, 23);
            txbExcelPath.TabIndex = 0;
            // 
            // ofdExcel
            // 
            ofdExcel.FileName = "ofdExcel";
            ofdExcel.Filter = "Archivos de Excel|*.xls;*.xlsx";
            ofdExcel.Title = "Seleccionar archivo de Excel";
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployees.BackgroundColor = SystemColors.Control;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(12, 99);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.Size = new Size(776, 339);
            dgvEmployees.TabIndex = 8;
            // 
            // btnNSS
            // 
            btnNSS.Enabled = false;
            btnNSS.Location = new Point(12, 70);
            btnNSS.Name = "btnNSS";
            btnNSS.Size = new Size(74, 23);
            btnNSS.TabIndex = 4;
            btnNSS.Text = "NSS";
            btnNSS.UseVisualStyleBackColor = true;
            btnNSS.Click += btnNSS_Click;
            // 
            // btnRFC
            // 
            btnRFC.Enabled = false;
            btnRFC.Location = new Point(92, 70);
            btnRFC.Name = "btnRFC";
            btnRFC.Size = new Size(74, 23);
            btnRFC.TabIndex = 5;
            btnRFC.Text = "RFC";
            btnRFC.UseVisualStyleBackColor = true;
            btnRFC.Click += btnRFC_Click;
            // 
            // btnLP
            // 
            btnLP.Enabled = false;
            btnLP.Location = new Point(172, 70);
            btnLP.Name = "btnLP";
            btnLP.Size = new Size(74, 23);
            btnLP.TabIndex = 6;
            btnLP.Text = "LP";
            btnLP.UseVisualStyleBackColor = true;
            btnLP.Click += btnLP_Click;
            // 
            // btnCURP
            // 
            btnCURP.Enabled = false;
            btnCURP.Location = new Point(252, 70);
            btnCURP.Name = "btnCURP";
            btnCURP.Size = new Size(74, 23);
            btnCURP.TabIndex = 7;
            btnCURP.Text = "CURP";
            btnCURP.UseVisualStyleBackColor = true;
            btnCURP.Click += btnCURP_Click;
            // 
            // btnClear
            // 
            btnClear.Image = Properties.Resources.limpiarIcon16;
            btnClear.ImageAlign = ContentAlignment.TopLeft;
            btnClear.Location = new Point(412, 70);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(70, 23);
            btnClear.TabIndex = 3;
            btnClear.Text = "Limpiar";
            btnClear.TextAlign = ContentAlignment.TopRight;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExaminar
            // 
            btnExaminar.BackgroundImageLayout = ImageLayout.None;
            btnExaminar.Image = (Image)resources.GetObject("btnExaminar.Image");
            btnExaminar.ImageAlign = ContentAlignment.TopLeft;
            btnExaminar.Location = new Point(448, 12);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(80, 24);
            btnExaminar.TabIndex = 1;
            btnExaminar.Text = "Examinar";
            btnExaminar.TextAlign = ContentAlignment.MiddleRight;
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // btnCP
            // 
            btnCP.Enabled = false;
            btnCP.Location = new Point(332, 70);
            btnCP.Name = "btnCP";
            btnCP.Size = new Size(74, 23);
            btnCP.TabIndex = 8;
            btnCP.Text = "CP";
            btnCP.UseVisualStyleBackColor = true;
            btnCP.Click += btnCP_Click;
            // 
            // btnSheets
            // 
            btnSheets.Image = Properties.Resources.guardarIcon16;
            btnSheets.ImageAlign = ContentAlignment.MiddleLeft;
            btnSheets.Location = new Point(307, 40);
            btnSheets.Name = "btnSheets";
            btnSheets.Padding = new Padding(3, 0, 3, 0);
            btnSheets.Size = new Size(100, 25);
            btnSheets.TabIndex = 16;
            btnSheets.Text = "Cargar hoja";
            btnSheets.TextAlign = ContentAlignment.MiddleRight;
            btnSheets.UseVisualStyleBackColor = true;
            btnSheets.Click += btnSheets_Click;
            // 
            // cboSheets
            // 
            cboSheets.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSheets.FormattingEnabled = true;
            cboSheets.Location = new Point(12, 41);
            cboSheets.Name = "cboSheets";
            cboSheets.Size = new Size(289, 23);
            cboSheets.TabIndex = 15;
            // 
            // FrmActualizarDatosEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSheets);
            Controls.Add(cboSheets);
            Controls.Add(btnCP);
            Controls.Add(btnExaminar);
            Controls.Add(btnClear);
            Controls.Add(btnCURP);
            Controls.Add(btnLP);
            Controls.Add(btnRFC);
            Controls.Add(btnNSS);
            Controls.Add(dgvEmployees);
            Controls.Add(txbExcelPath);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmActualizarDatosEmpleados";
            Text = "Actualizar datos empleados";
            WindowState = FormWindowState.Maximized;
            Load += FrmActualizarDatosEmpleados_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbExcelPath;
        private OpenFileDialog ofdExcel;
        private DataGridView dgvEmployees;
        private Button btnNSS;
        private Button btnRFC;
        private Button btnLP;
        private Button btnCURP;
        private Button btnClear;
        private Button btnExaminar;
        private Button btnCP;
        private Button btnSheets;
        private ComboBox cboSheets;
    }
}
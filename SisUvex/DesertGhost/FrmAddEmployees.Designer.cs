namespace SisUvex.DesertGhost
{
    partial class FrmAddEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEmployees));
            btnExaminar = new Button();
            btnLimpiar = new Button();
            dgvEmployees = new DataGridView();
            txbExcelPath = new TextBox();
            ofdExcel = new OpenFileDialog();
            btnGuardarEmpleados = new Button();
            cboSheets = new ComboBox();
            btnSheets = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // btnExaminar
            // 
            btnExaminar.Image = Properties.Resources.excelIcon16;
            btnExaminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnExaminar.Location = new Point(503, 12);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Padding = new Padding(3, 0, 3, 0);
            btnExaminar.Size = new Size(86, 23);
            btnExaminar.TabIndex = 1;
            btnExaminar.Text = "Examinar";
            btnExaminar.TextAlign = ContentAlignment.MiddleRight;
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Image = Properties.Resources.limpiarIcon16;
            btnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.Location = new Point(158, 70);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Padding = new Padding(3, 0, 3, 0);
            btnLimpiar.Size = new Size(77, 23);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
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
            dgvEmployees.Size = new Size(853, 339);
            dgvEmployees.TabIndex = 4;
            // 
            // txbExcelPath
            // 
            txbExcelPath.Enabled = false;
            txbExcelPath.Location = new Point(12, 12);
            txbExcelPath.Name = "txbExcelPath";
            txbExcelPath.Size = new Size(485, 23);
            txbExcelPath.TabIndex = 0;
            // 
            // ofdExcel
            // 
            ofdExcel.FileName = "ofdExcel";
            ofdExcel.Filter = "Archivos de Excel|*.xls;*.xlsx";
            ofdExcel.Title = "Seleccionar archivo de Excel";
            // 
            // btnGuardarEmpleados
            // 
            btnGuardarEmpleados.Image = (Image)resources.GetObject("btnGuardarEmpleados.Image");
            btnGuardarEmpleados.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarEmpleados.Location = new Point(12, 70);
            btnGuardarEmpleados.Name = "btnGuardarEmpleados";
            btnGuardarEmpleados.Padding = new Padding(3, 0, 3, 0);
            btnGuardarEmpleados.Size = new Size(140, 23);
            btnGuardarEmpleados.TabIndex = 3;
            btnGuardarEmpleados.Text = "Guardar empleados";
            btnGuardarEmpleados.TextAlign = ContentAlignment.MiddleRight;
            btnGuardarEmpleados.UseVisualStyleBackColor = true;
            btnGuardarEmpleados.Click += btnGuardarEmpleados_Click;
            // 
            // cboSheets
            // 
            cboSheets.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSheets.FormattingEnabled = true;
            cboSheets.Location = new Point(12, 41);
            cboSheets.Name = "cboSheets";
            cboSheets.Size = new Size(289, 23);
            cboSheets.TabIndex = 13;
            // 
            // btnSheets
            // 
            btnSheets.Image = Properties.Resources.guardarIcon16;
            btnSheets.ImageAlign = ContentAlignment.MiddleLeft;
            btnSheets.Location = new Point(307, 40);
            btnSheets.Name = "btnSheets";
            btnSheets.Padding = new Padding(3, 0, 3, 0);
            btnSheets.Size = new Size(100, 25);
            btnSheets.TabIndex = 14;
            btnSheets.Text = "Cargar hoja";
            btnSheets.TextAlign = ContentAlignment.MiddleRight;
            btnSheets.UseVisualStyleBackColor = true;
            btnSheets.Click += btnSheets_Click;
            // 
            // FrmAddEmployees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 450);
            Controls.Add(btnSheets);
            Controls.Add(cboSheets);
            Controls.Add(btnGuardarEmpleados);
            Controls.Add(btnExaminar);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvEmployees);
            Controls.Add(txbExcelPath);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAddEmployees";
            Text = "Cargar empleados Desert Ghost";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExaminar;
        private Button btnLimpiar;
        private DataGridView dgvEmployees;
        private TextBox txbExcelPath;
        private OpenFileDialog ofdExcel;
        private Button btnGuardarEmpleados;
        private ComboBox cboSheets;
        private Button btnSheets;
    }
}
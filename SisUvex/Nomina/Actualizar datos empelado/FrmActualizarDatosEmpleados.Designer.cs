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
            textBox1 = new TextBox();
            btnCargarArchivos = new Button();
            ofdExcel = new OpenFileDialog();
            dataGridView = new DataGridView();
            btnNSS = new Button();
            btnRFC = new Button();
            btnLP = new Button();
            btnCURP = new Button();
            btnLimpiar = new Button();
            btnExaminar = new Button();
            btnCP = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(430, 23);
            textBox1.TabIndex = 0;
            // 
            // btnCargarArchivos
            // 
            btnCargarArchivos.Location = new Point(524, 12);
            btnCargarArchivos.Name = "btnCargarArchivos";
            btnCargarArchivos.Size = new Size(70, 23);
            btnCargarArchivos.TabIndex = 2;
            btnCargarArchivos.Text = "Cargar";
            btnCargarArchivos.UseVisualStyleBackColor = true;
            btnCargarArchivos.Click += btnAbrirArchivos_Click;
            // 
            // ofdExcel
            // 
            ofdExcel.FileName = "ofdExcel";
            ofdExcel.Filter = "Archivos de Excel|*.xls;*.xlsx";
            ofdExcel.Title = "Seleccionar archivo de Excel";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 70);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Size = new Size(776, 368);
            dataGridView.TabIndex = 8;
            // 
            // btnNSS
            // 
            btnNSS.Enabled = false;
            btnNSS.Location = new Point(12, 41);
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
            btnRFC.Location = new Point(92, 41);
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
            btnLP.Location = new Point(172, 41);
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
            btnCURP.Location = new Point(252, 41);
            btnCURP.Name = "btnCURP";
            btnCURP.Size = new Size(74, 23);
            btnCURP.TabIndex = 7;
            btnCURP.Text = "CURP";
            btnCURP.UseVisualStyleBackColor = true;
            btnCURP.Click += btnCURP_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(600, 13);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(70, 23);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnExaminar
            // 
            btnExaminar.Location = new Point(448, 12);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(70, 23);
            btnExaminar.TabIndex = 1;
            btnExaminar.Text = "Examinar";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // btnCP
            // 
            btnCP.Enabled = false;
            btnCP.Location = new Point(332, 41);
            btnCP.Name = "btnCP";
            btnCP.Size = new Size(74, 23);
            btnCP.TabIndex = 8;
            btnCP.Text = "CP";
            btnCP.UseVisualStyleBackColor = true;
            btnCP.Click += btnCP_Click;
            // 
            // FrmActualizarDatosEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCP);
            Controls.Add(btnExaminar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCURP);
            Controls.Add(btnLP);
            Controls.Add(btnRFC);
            Controls.Add(btnNSS);
            Controls.Add(dataGridView);
            Controls.Add(btnCargarArchivos);
            Controls.Add(textBox1);
            Name = "FrmActualizarDatosEmpleados";
            Text = "Actualizar datos empleados";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnCargarArchivos;
        private OpenFileDialog ofdExcel;
        private DataGridView dataGridView;
        private Button btnNSS;
        private Button btnRFC;
        private Button btnLP;
        private Button btnCURP;
        private Button btnLimpiar;
        private Button btnExaminar;
        private Button btnCP;
    }
}
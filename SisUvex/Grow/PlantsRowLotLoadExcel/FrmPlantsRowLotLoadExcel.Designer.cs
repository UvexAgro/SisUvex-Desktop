namespace SisUvex.Grow.PlantsRowLotLoadExcel
{
    partial class FrmPlantsRowLotLoadExcel
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
            btnUpdatePlants = new Button();
            dataGridView = new DataGridView();
            btnExaminar = new Button();
            btnLimpiar = new Button();
            btnCargarArchivos = new Button();
            txbFile = new TextBox();
            ofdExcel = new OpenFileDialog();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnUpdatePlants
            // 
            btnUpdatePlants.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdatePlants.Location = new Point(12, 415);
            btnUpdatePlants.Name = "btnUpdatePlants";
            btnUpdatePlants.Size = new Size(125, 23);
            btnUpdatePlants.TabIndex = 16;
            btnUpdatePlants.Text = "Actualizar plantas";
            btnUpdatePlants.UseVisualStyleBackColor = true;
            btnUpdatePlants.Click += btnUpdatePlants_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 42);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Size = new Size(776, 367);
            dataGridView.TabIndex = 15;
            // 
            // btnExaminar
            // 
            btnExaminar.Location = new Point(448, 12);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(70, 23);
            btnExaminar.TabIndex = 12;
            btnExaminar.Text = "Examinar";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(600, 13);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(70, 23);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCargarArchivos
            // 
            btnCargarArchivos.Location = new Point(524, 12);
            btnCargarArchivos.Name = "btnCargarArchivos";
            btnCargarArchivos.Size = new Size(70, 23);
            btnCargarArchivos.TabIndex = 13;
            btnCargarArchivos.Text = "Cargar";
            btnCargarArchivos.UseVisualStyleBackColor = true;
            btnCargarArchivos.Click += btnCargarArchivos_Click;
            // 
            // txbFile
            // 
            txbFile.Location = new Point(12, 12);
            txbFile.Name = "txbFile";
            txbFile.Size = new Size(430, 23);
            txbFile.TabIndex = 11;
            // 
            // ofdExcel
            // 
            ofdExcel.FileName = "ofdExcel";
            ofdExcel.Filter = "Archivos de Excel|*.xls;*.xlsx";
            ofdExcel.Title = "Seleccionar archivo de Excel";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            progressBar1.Location = new Point(143, 415);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(299, 23);
            progressBar1.TabIndex = 17;
            // 
            // FrmPlantsRowLotLoadExcel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar1);
            Controls.Add(btnUpdatePlants);
            Controls.Add(dataGridView);
            Controls.Add(btnExaminar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCargarArchivos);
            Controls.Add(txbFile);
            Name = "FrmPlantsRowLotLoadExcel";
            Text = "FrmPlantsRowLotLoadExcel";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdatePlants;
        private DataGridView dataGridView;
        private Button btnExaminar;
        private Button btnLimpiar;
        private Button btnCargarArchivos;
        private TextBox txbFile;
        private OpenFileDialog ofdExcel;
        private ProgressBar progressBar1;
    }
}
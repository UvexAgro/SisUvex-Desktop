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
            btnExaminar = new Button();
            btnLimpiar = new Button();
            dataGridView = new DataGridView();
            textBox1 = new TextBox();
            ofdExcel = new OpenFileDialog();
            btnGuardarEmpleados = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnExaminar
            // 
            btnExaminar.Location = new Point(448, 12);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(70, 23);
            btnExaminar.TabIndex = 13;
            btnExaminar.Text = "Examinar";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(600, 13);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(70, 23);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
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
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(853, 368);
            dataGridView.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(430, 23);
            textBox1.TabIndex = 9;
            // 
            // ofdExcel
            // 
            ofdExcel.FileName = "ofdExcel";
            ofdExcel.Filter = "Archivos de Excel|*.xls;*.xlsx";
            ofdExcel.Title = "Seleccionar archivo de Excel";
            // 
            // btnGuardarEmpleados
            // 
            btnGuardarEmpleados.Location = new Point(12, 41);
            btnGuardarEmpleados.Name = "btnGuardarEmpleados";
            btnGuardarEmpleados.Size = new Size(131, 23);
            btnGuardarEmpleados.TabIndex = 14;
            btnGuardarEmpleados.Text = "Guardar empleados";
            btnGuardarEmpleados.UseVisualStyleBackColor = true;
            btnGuardarEmpleados.Click += btnGuardarEmpleados_Click;
            // 
            // FrmAddEmployees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 450);
            Controls.Add(btnGuardarEmpleados);
            Controls.Add(btnExaminar);
            Controls.Add(btnLimpiar);
            Controls.Add(dataGridView);
            Controls.Add(textBox1);
            Name = "FrmAddEmployees";
            Text = "FrmAddEmployees";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExaminar;
        private Button btnLimpiar;
        private DataGridView dataGridView;
        private TextBox textBox1;
        private OpenFileDialog ofdExcel;
        private Button btnGuardarEmpleados;
    }
}
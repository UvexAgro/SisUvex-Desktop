namespace SisUvex.Catalogos.Nomina
{
    partial class REPORTECOMEDOR
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btnFiltrar = new Button();
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFin = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            btnExportarExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(754, 283);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(28, 21);
            label1.Name = "label1";
            label1.Size = new Size(253, 24);
            label1.TabIndex = 1;
            label1.Text = "REPORTE DE COMEDOR";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFiltrar.Location = new Point(549, 62);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(104, 23);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "FILTRAR";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Location = new Point(549, 6);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(217, 23);
            dateTimePickerInicio.TabIndex = 3;
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Location = new Point(549, 35);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(217, 23);
            dateTimePickerFin.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(430, 11);
            label2.Name = "label2";
            label2.Size = new Size(95, 16);
            label2.TabIndex = 5;
            label2.Text = "Fecha Inicial";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(430, 40);
            label3.Name = "label3";
            label3.Size = new Size(88, 16);
            label3.TabIndex = 6;
            label3.Text = "Fecha Final";
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportarExcel.Location = new Point(675, 62);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(91, 23);
            btnExportarExcel.TabIndex = 7;
            btnExportarExcel.Text = "EXPORTAR";
            btnExportarExcel.UseVisualStyleBackColor = true;
            btnExportarExcel.Click += btnExportar_Click;
            // 
            // REPORTECOMEDOR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 386);
            Controls.Add(btnExportarExcel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dateTimePickerFin);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(btnFiltrar);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            MaximumSize = new Size(794, 425);
            MinimumSize = new Size(794, 425);
            Name = "REPORTECOMEDOR";
            Text = "REPORTECOMEDOR";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button btnFiltrar;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFin;
        private Label label2;
        private Label label3;
        private Button btnExportarExcel;
    }
}
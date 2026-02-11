namespace SisUvex.Nomina.Nom_semAutomatizada
{
	partial class FrmSemiAutomatedPayroll
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
			lblLote = new Label();
			lblReferencia = new Label();
			dtpFecha = new DateTimePicker();
			txtReferencia = new TextBox();
			cmbLote = new ComboBox();
			lbencabezado = new Label();
			dataGridView1 = new DataGridView();
			btnCVS = new Button();
			btnExcel = new Button();
			btncargar = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// lblLote
			// 
			lblLote.AutoSize = true;
			lblLote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblLote.Location = new Point(83, 182);
			lblLote.Name = "lblLote";
			lblLote.Size = new Size(47, 21);
			lblLote.TabIndex = 0;
			lblLote.Text = "Lote :";
			// 
			// lblReferencia
			// 
			lblReferencia.AutoSize = true;
			lblReferencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblReferencia.Location = new Point(83, 244);
			lblReferencia.Name = "lblReferencia";
			lblReferencia.Size = new Size(90, 21);
			lblReferencia.TabIndex = 1;
			lblReferencia.Text = "Referencia :";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(83, 88);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(260, 23);
			dtpFecha.TabIndex = 2;
			// 
			// txtReferencia
			// 
			txtReferencia.Location = new Point(208, 240);
			txtReferencia.Multiline = true;
			txtReferencia.Name = "txtReferencia";
			txtReferencia.Size = new Size(135, 25);
			txtReferencia.TabIndex = 3;
			// 
			// cmbLote
			// 
			cmbLote.FormattingEnabled = true;
			cmbLote.Location = new Point(208, 184);
			cmbLote.Name = "cmbLote";
			cmbLote.Size = new Size(135, 23);
			cmbLote.TabIndex = 4;
			// 
			// lbencabezado
			// 
			lbencabezado.AutoSize = true;
			lbencabezado.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lbencabezado.Location = new Point(258, 9);
			lbencabezado.Name = "lbencabezado";
			lbencabezado.Size = new Size(345, 32);
			lbencabezado.TabIndex = 5;
			lbencabezado.Text = "Generar Reporte de Esparrago";
			// 
			// dataGridView1
			// 
			dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(48, 350);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(829, 288);
			dataGridView1.TabIndex = 6;
			// 
			// btnCVS
			// 
			btnCVS.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCVS.Location = new Point(680, 115);
			btnCVS.Name = "btnCVS";
			btnCVS.Size = new Size(131, 39);
			btnCVS.TabIndex = 7;
			btnCVS.Text = "CSV";
			btnCVS.UseVisualStyleBackColor = true;
			btnCVS.Click += btnCVS_Click;
			// 
			// btnExcel
			// 
			btnExcel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnExcel.Location = new Point(680, 193);
			btnExcel.Name = "btnExcel";
			btnExcel.Size = new Size(131, 40);
			btnExcel.TabIndex = 8;
			btnExcel.Text = "Excel";
			btnExcel.UseVisualStyleBackColor = true;
			// 
			// btncargar
			// 
			btncargar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btncargar.Location = new Point(680, 306);
			btncargar.Name = "btncargar";
			btncargar.Size = new Size(131, 38);
			btncargar.TabIndex = 9;
			btncargar.Text = "Cargar Datos";
			btncargar.UseVisualStyleBackColor = true;
			// 
			// FrmSemiAutomatedPayroll
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(922, 660);
			Controls.Add(btncargar);
			Controls.Add(btnExcel);
			Controls.Add(btnCVS);
			Controls.Add(dataGridView1);
			Controls.Add(lbencabezado);
			Controls.Add(cmbLote);
			Controls.Add(txtReferencia);
			Controls.Add(dtpFecha);
			Controls.Add(lblReferencia);
			Controls.Add(lblLote);
			Name = "FrmSemiAutomatedPayroll";
			Text = "FrmSemiAutomatedPayroll";
			Load += FrmSemiAutomatedPayroll_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblLote;
		private Label lblReferencia;
		private Label lbencabezado;
		private Button btnCVS;
		private Button btnExcel;
		private Button btncargar;
		public DateTimePicker dtpFecha;
		public TextBox txtReferencia;
		public ComboBox cmbLote;
		public DataGridView dataGridView1;
	}
}
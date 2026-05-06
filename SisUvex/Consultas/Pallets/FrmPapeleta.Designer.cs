namespace SisUvex.Consultas.Pallets
{
	partial class FrmPapeleta
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPapeleta));
			btnInvoice = new Button();
			label6 = new Label();
			txbInvoice = new TextBox();
			label1 = new Label();
			dgvConsulta = new DataGridView();
			label2 = new Label();
			btnActualizar = new Button();
			txbPapeleta = new TextBox();
			label3 = new Label();
			dtpFecha = new DateTimePicker();
			label4 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvConsulta).BeginInit();
			SuspendLayout();
			// 
			// btnInvoice
			// 
			btnInvoice.BackgroundImage = Properties.Resources.BuscarLupa1;
			btnInvoice.BackgroundImageLayout = ImageLayout.Stretch;
			btnInvoice.Location = new Point(138, 112);
			btnInvoice.Name = "btnInvoice";
			btnInvoice.Size = new Size(23, 23);
			btnInvoice.TabIndex = 33;
			btnInvoice.UseVisualStyleBackColor = true;
			btnInvoice.Click += btnInvoice_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label6.Location = new Point(12, 112);
			label6.Name = "label6";
			label6.Size = new Size(39, 17);
			label6.TabIndex = 34;
			label6.Text = "Folio:";
			// 
			// txbInvoice
			// 
			txbInvoice.Location = new Point(57, 111);
			txbInvoice.MaxLength = 5;
			txbInvoice.Name = "txbInvoice";
			txbInvoice.Size = new Size(75, 23);
			txbInvoice.TabIndex = 32;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(85, 9);
			label1.Name = "label1";
			label1.Size = new Size(211, 21);
			label1.TabIndex = 35;
			label1.Text = "Modificar Folio de Papeleta";
			// 
			// dgvConsulta
			// 
			dgvConsulta.AllowUserToAddRows = false;
			dgvConsulta.AllowUserToDeleteRows = false;
			dgvConsulta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvConsulta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvConsulta.BackgroundColor = SystemColors.Control;
			dgvConsulta.BorderStyle = BorderStyle.None;
			dgvConsulta.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvConsulta.ColumnHeadersHeight = 58;
			dgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvConsulta.EnableHeadersVisualStyles = false;
			dgvConsulta.ImeMode = ImeMode.NoControl;
			dgvConsulta.Location = new Point(14, 175);
			dgvConsulta.Name = "dgvConsulta";
			dgvConsulta.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvConsulta.RowHeadersVisible = false;
			dgvConsulta.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvConsulta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvConsulta.Size = new Size(350, 123);
			dgvConsulta.TabIndex = 36;
			dgvConsulta.CellContentClick += dgvConsulta_CellContentClick;
			dgvConsulta.CurrentCellDirtyStateChanged += dgvConsulta_CurrentCellDirtyStateChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F);
			label2.Location = new Point(12, 157);
			label2.Name = "label2";
			label2.Size = new Size(79, 15);
			label2.TabIndex = 37;
			label2.Text = "Lista de pallet";
			// 
			// btnActualizar
			// 
			btnActualizar.Location = new Point(282, 310);
			btnActualizar.Name = "btnActualizar";
			btnActualizar.Size = new Size(75, 23);
			btnActualizar.TabIndex = 38;
			btnActualizar.Text = "Actualizar";
			btnActualizar.UseVisualStyleBackColor = true;
			btnActualizar.Click += btnActualizar_Click;
			// 
			// txbPapeleta
			// 
			txbPapeleta.Location = new Point(94, 310);
			txbPapeleta.MaxLength = 5;
			txbPapeleta.Name = "txbPapeleta";
			txbPapeleta.Size = new Size(75, 23);
			txbPapeleta.TabIndex = 39;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9F);
			label3.Location = new Point(14, 314);
			label3.Name = "label3";
			label3.Size = new Size(74, 15);
			label3.TabIndex = 40;
			label3.Text = "Nuevo Folio:";
			// 
			// dtpFecha
			// 
			dtpFecha.Location = new Point(57, 62);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(230, 23);
			dtpFecha.TabIndex = 42;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label4.Location = new Point(12, 62);
			label4.Name = "label4";
			label4.Size = new Size(44, 17);
			label4.TabIndex = 43;
			label4.Text = "Fecha:";
			// 
			// FrmPapeleta
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(369, 351);
			Controls.Add(label4);
			Controls.Add(dtpFecha);
			Controls.Add(label3);
			Controls.Add(txbPapeleta);
			Controls.Add(btnActualizar);
			Controls.Add(label2);
			Controls.Add(dgvConsulta);
			Controls.Add(label1);
			Controls.Add(btnInvoice);
			Controls.Add(label6);
			Controls.Add(txbInvoice);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmPapeleta";
			Text = "Papeleta";
			Load += FrmPapeleta_Load;
			((System.ComponentModel.ISupportInitialize)dgvConsulta).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnInvoice;
		private Label label6;
		public TextBox txbInvoice;
		private Label label1;
		public DataGridView dgvConsulta;
		private Label label2;
		private Button btnActualizar;
		public TextBox txbPapeleta;
		private Label label3;
		public DateTimePicker dtpFecha;
		private Label label4;
	}
}
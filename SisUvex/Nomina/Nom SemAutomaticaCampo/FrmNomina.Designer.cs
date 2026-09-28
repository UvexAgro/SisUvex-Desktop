namespace SisUvex.Nomina.Nom_SemAutomaticaCampo
{
	partial class FrmNomina
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNomina));
			dgvNomina = new DataGridView();
			label1 = new Label();
			panel1 = new Panel();
			label2 = new Label();
			pictureBox1 = new PictureBox();
			label4 = new Label();
			label3 = new Label();
			dtpFecha = new DateTimePicker();
			btnConsultar = new Button();
			txbReferencia = new TextBox();
			txbDestajo = new TextBox();
			txbJornada = new TextBox();
			label9 = new Label();
			label8 = new Label();
			btnCSV = new Button();
			label7 = new Label();
			panel6 = new Panel();
			label10 = new Label();
			tabNomina = new TabPage();
			tabPage2 = new TabPage();
			tabPage3 = new TabPage();
			tabControl2 = new TabControl();
			tbpNomina = new TabPage();
			btnSeleccionar = new Button();
			tabPage4 = new TabPage();
			tabPage1 = new TabPage();
			cboSemana = new ComboBox();
			label6 = new Label();
			cboLugarPago = new ComboBox();
			label11 = new Label();
			cboCuadrillaRevisar = new ComboBox();
			label5 = new Label();
			splitNomina = new SplitContainer();
			pnlCSV = new Panel();
			lblCuadrillas = new Label();
			lbCSV = new ListBox();
			label12 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvNomina).BeginInit();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel6.SuspendLayout();
			tabControl2.SuspendLayout();
			tbpNomina.SuspendLayout();
			tabPage4.SuspendLayout();
			tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitNomina).BeginInit();
			splitNomina.Panel2.SuspendLayout();
			splitNomina.SuspendLayout();
			pnlCSV.SuspendLayout();
			SuspendLayout();
			// 
			// dgvNomina
			// 
			dgvNomina.AllowUserToAddRows = false;
			dgvNomina.AllowUserToDeleteRows = false;
			dgvNomina.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvNomina.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvNomina.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dgvNomina.BackgroundColor = SystemColors.ControlLightLight;
			dgvNomina.BorderStyle = BorderStyle.Fixed3D;
			dgvNomina.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvNomina.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvNomina.ColumnHeadersHeight = 29;
			dgvNomina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgvNomina.EnableHeadersVisualStyles = false;
			dgvNomina.ImeMode = ImeMode.NoControl;
			dgvNomina.Location = new Point(3, 51);
			dgvNomina.Name = "dgvNomina";
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgvNomina.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvNomina.RowHeadersVisible = false;
			dgvNomina.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dgvNomina.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvNomina.Size = new Size(1509, 723);
			dgvNomina.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = SystemColors.ControlLightLight;
			label1.Location = new Point(180, 16);
			label1.Name = "label1";
			label1.Size = new Size(462, 65);
			label1.TabIndex = 0;
			label1.Text = "NOMINA GENERAL";
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel1.BackColor = Color.FromArgb(35, 103, 149);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(12, 6);
			panel1.Name = "panel1";
			panel1.Size = new Size(1819, 140);
			panel1.TabIndex = 5;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = SystemColors.ControlLightLight;
			label2.Location = new Point(180, 91);
			label2.Name = "label2";
			label2.Size = new Size(381, 32);
			label2.TabIndex = 2;
			label2.Text = "Consulta general de nómina diaria";
			// 
			// pictureBox1
			// 
			pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
			pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
			pictureBox1.Location = new Point(33, 16);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(100, 107);
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.ForeColor = Color.FromArgb(31, 95, 145);
			label4.Location = new Point(424, 51);
			label4.Name = "label4";
			label4.Size = new Size(67, 17);
			label4.TabIndex = 2;
			label4.Text = "Cuadrilla :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label3.ForeColor = Color.FromArgb(31, 95, 145);
			label3.Location = new Point(17, 50);
			label3.Name = "label3";
			label3.Size = new Size(50, 17);
			label3.TabIndex = 1;
			label3.Text = "Fecha :";
			// 
			// dtpFecha
			// 
			dtpFecha.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dtpFecha.Location = new Point(73, 45);
			dtpFecha.Name = "dtpFecha";
			dtpFecha.Size = new Size(288, 25);
			dtpFecha.TabIndex = 0;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
			// 
			// btnConsultar
			// 
			btnConsultar.BackColor = Color.White;
			btnConsultar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnConsultar.ForeColor = Color.Black;
			btnConsultar.Image = (Image)resources.GetObject("btnConsultar.Image");
			btnConsultar.ImageAlign = ContentAlignment.MiddleLeft;
			btnConsultar.Location = new Point(760, 38);
			btnConsultar.Name = "btnConsultar";
			btnConsultar.Padding = new Padding(25, 0, 25, 0);
			btnConsultar.Size = new Size(165, 40);
			btnConsultar.TabIndex = 8;
			btnConsultar.Text = "Consultar";
			btnConsultar.TextAlign = ContentAlignment.MiddleRight;
			btnConsultar.UseVisualStyleBackColor = false;
			btnConsultar.Click += btnConsultar_Click;
			// 
			// txbReferencia
			// 
			txbReferencia.Location = new Point(86, 43);
			txbReferencia.Name = "txbReferencia";
			txbReferencia.Size = new Size(100, 27);
			txbReferencia.TabIndex = 13;
			// 
			// txbDestajo
			// 
			txbDestajo.Location = new Point(518, 43);
			txbDestajo.Name = "txbDestajo";
			txbDestajo.Size = new Size(100, 27);
			txbDestajo.TabIndex = 12;
			// 
			// txbJornada
			// 
			txbJornada.Location = new Point(295, 43);
			txbJornada.Name = "txbJornada";
			txbJornada.Size = new Size(100, 27);
			txbJornada.TabIndex = 11;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label9.ForeColor = Color.FromArgb(31, 95, 145);
			label9.Location = new Point(452, 49);
			label9.Name = "label9";
			label9.Size = new Size(60, 17);
			label9.TabIndex = 10;
			label9.Text = "Destajo :";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label8.ForeColor = Color.FromArgb(31, 95, 145);
			label8.Location = new Point(226, 49);
			label8.Name = "label8";
			label8.Size = new Size(63, 17);
			label8.TabIndex = 9;
			label8.Text = "Jornada :";
			// 
			// btnCSV
			// 
			btnCSV.BackColor = SystemColors.ControlLightLight;
			btnCSV.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCSV.ForeColor = Color.Black;
			btnCSV.Image = (Image)resources.GetObject("btnCSV.Image");
			btnCSV.ImageAlign = ContentAlignment.MiddleLeft;
			btnCSV.Location = new Point(667, 36);
			btnCSV.Name = "btnCSV";
			btnCSV.Padding = new Padding(35, 0, 35, 0);
			btnCSV.Size = new Size(165, 40);
			btnCSV.TabIndex = 8;
			btnCSV.Text = "CSV";
			btnCSV.TextAlign = ContentAlignment.MiddleRight;
			btnCSV.UseVisualStyleBackColor = false;
			btnCSV.Click += btnCSV_Click;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.FromArgb(31, 95, 145);
			label7.Location = new Point(7, 48);
			label7.Name = "label7";
			label7.Size = new Size(77, 17);
			label7.TabIndex = 2;
			label7.Text = "Referencia :";
			// 
			// panel6
			// 
			panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel6.BackColor = Color.FromArgb(35, 103, 149);
			panel6.Controls.Add(label10);
			panel6.Location = new Point(3, 0);
			panel6.Name = "panel6";
			panel6.Size = new Size(1509, 48);
			panel6.TabIndex = 8;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label10.ForeColor = Color.White;
			label10.Location = new Point(3, 8);
			label10.Name = "label10";
			label10.Size = new Size(199, 30);
			label10.TabIndex = 0;
			label10.Text = "Listado de Nomina";
			// 
			// tabNomina
			// 
			tabNomina.Location = new Point(4, 30);
			tabNomina.Name = "tabNomina";
			tabNomina.Padding = new Padding(3);
			tabNomina.Size = new Size(432, 48);
			tabNomina.TabIndex = 0;
			tabNomina.Text = "Nomina";
			tabNomina.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Location = new Point(4, 30);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(432, 48);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			tabPage3.Location = new Point(4, 30);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new Padding(3);
			tabPage3.Size = new Size(432, 48);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "tabPage3";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			tabControl2.Controls.Add(tbpNomina);
			tabControl2.Controls.Add(tabPage4);
			tabControl2.Controls.Add(tabPage1);
			tabControl2.DrawMode = TabDrawMode.OwnerDrawFixed;
			tabControl2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			tabControl2.ItemSize = new Size(150, 40);
			tabControl2.Location = new Point(12, 152);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabControl2.Size = new Size(1049, 162);
			tabControl2.TabIndex = 10;
			tabControl2.DrawItem += tabControl2_DrawItem;
			tabControl2.SelectedIndexChanged += tabControl2_SelectedIndexChanged;
			// 
			// tbpNomina
			// 
			tbpNomina.BackColor = Color.FromArgb(236, 243, 249);
			tbpNomina.Controls.Add(btnSeleccionar);
			tbpNomina.Controls.Add(btnConsultar);
			tbpNomina.Controls.Add(label3);
			tbpNomina.Controls.Add(dtpFecha);
			tbpNomina.Controls.Add(label4);
			tbpNomina.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			tbpNomina.ForeColor = Color.FromArgb(31, 95, 145);
			tbpNomina.Location = new Point(4, 44);
			tbpNomina.Name = "tbpNomina";
			tbpNomina.Padding = new Padding(3);
			tbpNomina.Size = new Size(1041, 114);
			tbpNomina.TabIndex = 0;
			tbpNomina.Text = "NOMINA";
			// 
			// btnSeleccionar
			// 
			btnSeleccionar.BackColor = Color.White;
			btnSeleccionar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnSeleccionar.ForeColor = Color.Black;
			btnSeleccionar.Image = (Image)resources.GetObject("btnSeleccionar.Image");
			btnSeleccionar.ImageAlign = ContentAlignment.MiddleLeft;
			btnSeleccionar.Location = new Point(497, 38);
			btnSeleccionar.Name = "btnSeleccionar";
			btnSeleccionar.Padding = new Padding(20, 0, 30, 0);
			btnSeleccionar.Size = new Size(199, 40);
			btnSeleccionar.TabIndex = 9;
			btnSeleccionar.Text = "Seleccionar";
			btnSeleccionar.TextAlign = ContentAlignment.MiddleRight;
			btnSeleccionar.UseVisualStyleBackColor = false;
			btnSeleccionar.Click += btnSeleccionar_Click;
			// 
			// tabPage4
			// 
			tabPage4.BackColor = Color.FromArgb(236, 243, 249);
			tabPage4.Controls.Add(btnCSV);
			tabPage4.Controls.Add(txbDestajo);
			tabPage4.Controls.Add(label9);
			tabPage4.Controls.Add(txbReferencia);
			tabPage4.Controls.Add(txbJornada);
			tabPage4.Controls.Add(label7);
			tabPage4.Controls.Add(label8);
			tabPage4.Location = new Point(4, 44);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new Padding(3);
			tabPage4.Size = new Size(1041, 114);
			tabPage4.TabIndex = 1;
			tabPage4.Text = "CSV";
			// 
			// tabPage1
			// 
			tabPage1.BackColor = Color.FromArgb(236, 243, 249);
			tabPage1.Controls.Add(cboSemana);
			tabPage1.Controls.Add(label6);
			tabPage1.Controls.Add(cboLugarPago);
			tabPage1.Controls.Add(label11);
			tabPage1.Controls.Add(cboCuadrillaRevisar);
			tabPage1.Controls.Add(label5);
			tabPage1.Location = new Point(4, 44);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(1041, 114);
			tabPage1.TabIndex = 2;
			tabPage1.Text = "REVISAR";
			// 
			// cboSemana
			// 
			cboSemana.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			cboSemana.FormattingEnabled = true;
			cboSemana.Location = new Point(9, 54);
			cboSemana.Name = "cboSemana";
			cboSemana.Size = new Size(256, 25);
			cboSemana.TabIndex = 11;
			cboSemana.SelectedIndexChanged += cboSemana_SelectedIndexChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.ForeColor = Color.FromArgb(31, 95, 145);
			label6.Location = new Point(9, 34);
			label6.Name = "label6";
			label6.Size = new Size(63, 17);
			label6.TabIndex = 10;
			label6.Text = "Semana :";
			// 
			// cboLugarPago
			// 
			cboLugarPago.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			cboLugarPago.FormattingEnabled = true;
			cboLugarPago.Location = new Point(689, 54);
			cboLugarPago.Name = "cboLugarPago";
			cboLugarPago.Size = new Size(256, 25);
			cboLugarPago.TabIndex = 7;
			cboLugarPago.SelectedIndexChanged += cboLugarPago_SelectedIndexChanged;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label11.ForeColor = Color.FromArgb(31, 95, 145);
			label11.Location = new Point(693, 34);
			label11.Name = "label11";
			label11.Size = new Size(103, 17);
			label11.TabIndex = 6;
			label11.Text = "Lugar de Pago :";
			// 
			// cboCuadrillaRevisar
			// 
			cboCuadrillaRevisar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			cboCuadrillaRevisar.FormattingEnabled = true;
			cboCuadrillaRevisar.Location = new Point(391, 54);
			cboCuadrillaRevisar.Name = "cboCuadrillaRevisar";
			cboCuadrillaRevisar.Size = new Size(189, 25);
			cboCuadrillaRevisar.TabIndex = 5;
			cboCuadrillaRevisar.SelectedIndexChanged += cboCuadrillaRevisar_SelectedIndexChanged;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label5.ForeColor = Color.FromArgb(31, 95, 145);
			label5.Location = new Point(391, 34);
			label5.Name = "label5";
			label5.Size = new Size(67, 17);
			label5.TabIndex = 4;
			label5.Text = "Cuadrilla :";
			// 
			// splitNomina
			// 
			splitNomina.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitNomina.Location = new Point(12, 329);
			splitNomina.Name = "splitNomina";
			// 
			// splitNomina.Panel2
			// 
			splitNomina.Panel2.Controls.Add(panel6);
			splitNomina.Panel2.Controls.Add(dgvNomina);
			splitNomina.Size = new Size(1819, 777);
			splitNomina.SplitterDistance = 300;
			splitNomina.TabIndex = 11;
			// 
			// pnlCSV
			// 
			pnlCSV.Controls.Add(lblCuadrillas);
			pnlCSV.Controls.Add(lbCSV);
			pnlCSV.Controls.Add(label12);
			pnlCSV.Location = new Point(1067, 152);
			pnlCSV.Name = "pnlCSV";
			pnlCSV.Size = new Size(764, 171);
			pnlCSV.TabIndex = 12;
			// 
			// lblCuadrillas
			// 
			lblCuadrillas.AutoSize = true;
			lblCuadrillas.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCuadrillas.Location = new Point(139, 7);
			lblCuadrillas.Name = "lblCuadrillas";
			lblCuadrillas.Size = new Size(0, 17);
			lblCuadrillas.TabIndex = 12;
			// 
			// lbCSV
			// 
			lbCSV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lbCSV.BackColor = Color.FromArgb(236, 243, 249);
			lbCSV.BorderStyle = BorderStyle.FixedSingle;
			lbCSV.ColumnWidth = 200;
			lbCSV.FormattingEnabled = true;
			lbCSV.HorizontalScrollbar = true;
			lbCSV.ItemHeight = 15;
			lbCSV.Location = new Point(3, 40);
			lbCSV.MultiColumn = true;
			lbCSV.Name = "lbCSV";
			lbCSV.Size = new Size(758, 122);
			lbCSV.TabIndex = 11;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label12.ForeColor = Color.FromArgb(31, 95, 145);
			label12.Location = new Point(3, 6);
			label12.Name = "label12";
			label12.Size = new Size(132, 17);
			label12.TabIndex = 10;
			label12.Text = "Cuadrilla con un csv:";
			// 
			// FrmNomina
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(244, 247, 251);
			ClientSize = new Size(1843, 1118);
			Controls.Add(pnlCSV);
			Controls.Add(splitNomina);
			Controls.Add(tabControl2);
			Controls.Add(panel1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FrmNomina";
			Text = "Nomina de Campo";
			Load += FrmNomina_Load;
			((System.ComponentModel.ISupportInitialize)dgvNomina).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			tabControl2.ResumeLayout(false);
			tbpNomina.ResumeLayout(false);
			tbpNomina.PerformLayout();
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			splitNomina.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitNomina).EndInit();
			splitNomina.ResumeLayout(false);
			pnlCSV.ResumeLayout(false);
			pnlCSV.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		public DataGridView dgvNomina;
		private Label label1;
		private Panel panel1;
		private PictureBox pictureBox1;
		private Label label2;
		private Label label4;
		private Label label3;
		private DateTimePicker dateTimePicker1;
		private Button btnConsultar;
		private Button btnCSV;
		private Label label7;
		private TextBox textBox3;
		private TextBox textBox2;
		private Label label9;
		private Label label8;
		public TextBox txbDestajo;
		public TextBox txbReferencia;
		public TextBox txbJornada;
		public DateTimePicker dtpFecha;
		private Panel panel6;
		private Label label10;
		private TabControl tabControl1;
		private TabPage tabNomina;
		private TabPage tabPage2;
		private TabPage tabPage3;
		private TabPage tcNomina;
		private TabControl tabControl2;
		public TabPage tbpNomina;
		private TabPage tabPage4;
		private TabPage tabPage1;
		private Button btnSeleccionar;
		public ComboBox cboLugarPago;
		private Label label11;
		public ComboBox cboCuadrillaRevisar;
		private Label label5;
		public ComboBox cboSemana;
		private Label label6;
		private Panel panel2;
		private SplitContainer splitContainer1;
		private SplitContainer splitNomina;
		private Label label12;
		public ListBox lbCSV;
		private ListBox listBox1;
		public Label lblCuadrillas;
		public Panel pnlCSV;
	}
}
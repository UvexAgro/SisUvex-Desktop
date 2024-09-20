namespace SisUvex.Archivo.Reestibado
{
    partial class FrmReestibado
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
            txbIdPallet = new TextBox();
            lblTitulo = new Label();
            lblPallet = new Label();
            lblVariedad = new Label();
            lblPresentacion = new Label();
            lblContenedor = new Label();
            lblDistribuidor = new Label();
            lblTamaño = new Label();
            lblCajasIniciales = new Label();
            lblFecha = new Label();
            lblPlanDeTrabajo = new Label();
            lblCuadrilla = new Label();
            lblPrograma = new Label();
            lblLote = new Label();
            lblLibras = new Label();
            nudCajasFinal = new NumericUpDown();
            btnReestibar = new Button();
            lblPapeleta = new Label();
            btnPallet = new Button();
            lblIdPallet = new Label();
            cboMotivo = new ComboBox();
            lblCajasFinal = new Label();
            lblMotivo = new Label();
            lblManifiesto = new Label();
            ((System.ComponentModel.ISupportInitialize)nudCajasFinal).BeginInit();
            SuspendLayout();
            // 
            // txbIdPallet
            // 
            txbIdPallet.Location = new Point(12, 63);
            txbIdPallet.Name = "txbIdPallet";
            txbIdPallet.Size = new Size(112, 23);
            txbIdPallet.TabIndex = 0;
            txbIdPallet.TextChanged += txbIdPallet_TextChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(7, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(206, 31);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Reestibar pallet";
            // 
            // lblPallet
            // 
            lblPallet.AutoSize = true;
            lblPallet.Location = new Point(12, 45);
            lblPallet.Name = "lblPallet";
            lblPallet.Size = new Size(97, 15);
            lblPallet.TabIndex = 2;
            lblPallet.Text = "Código de pallet:";
            // 
            // lblVariedad
            // 
            lblVariedad.AutoSize = true;
            lblVariedad.Location = new Point(12, 134);
            lblVariedad.Name = "lblVariedad";
            lblVariedad.Size = new Size(58, 15);
            lblVariedad.TabIndex = 3;
            lblVariedad.Text = "Variedad: ";
            // 
            // lblPresentacion
            // 
            lblPresentacion.AutoSize = true;
            lblPresentacion.Location = new Point(12, 149);
            lblPresentacion.Name = "lblPresentacion";
            lblPresentacion.Size = new Size(81, 15);
            lblPresentacion.TabIndex = 4;
            lblPresentacion.Text = "Presentación: ";
            // 
            // lblContenedor
            // 
            lblContenedor.AutoSize = true;
            lblContenedor.Location = new Point(12, 164);
            lblContenedor.Name = "lblContenedor";
            lblContenedor.Size = new Size(76, 15);
            lblContenedor.TabIndex = 5;
            lblContenedor.Text = "Contenedor: ";
            // 
            // lblDistribuidor
            // 
            lblDistribuidor.AutoSize = true;
            lblDistribuidor.Location = new Point(12, 179);
            lblDistribuidor.Name = "lblDistribuidor";
            lblDistribuidor.Size = new Size(75, 15);
            lblDistribuidor.TabIndex = 6;
            lblDistribuidor.Text = "Distribuidor: ";
            // 
            // lblTamaño
            // 
            lblTamaño.AutoSize = true;
            lblTamaño.Location = new Point(12, 209);
            lblTamaño.Name = "lblTamaño";
            lblTamaño.Size = new Size(55, 15);
            lblTamaño.TabIndex = 7;
            lblTamaño.Text = "Tamaño: ";
            // 
            // lblCajasIniciales
            // 
            lblCajasIniciales.AutoSize = true;
            lblCajasIniciales.Location = new Point(12, 104);
            lblCajasIniciales.Name = "lblCajasIniciales";
            lblCajasIniciales.Size = new Size(86, 15);
            lblCajasIniciales.TabIndex = 8;
            lblCajasIniciales.Text = "Cajas iniciales: ";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 224);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(44, 15);
            lblFecha.TabIndex = 9;
            lblFecha.Text = "Fecha: ";
            // 
            // lblPlanDeTrabajo
            // 
            lblPlanDeTrabajo.AutoSize = true;
            lblPlanDeTrabajo.Location = new Point(12, 239);
            lblPlanDeTrabajo.Name = "lblPlanDeTrabajo";
            lblPlanDeTrabajo.Size = new Size(92, 15);
            lblPlanDeTrabajo.TabIndex = 10;
            lblPlanDeTrabajo.Text = "Plan de trabajo: ";
            // 
            // lblCuadrilla
            // 
            lblCuadrilla.AutoSize = true;
            lblCuadrilla.Location = new Point(12, 254);
            lblCuadrilla.Name = "lblCuadrilla";
            lblCuadrilla.Size = new Size(60, 15);
            lblCuadrilla.TabIndex = 11;
            lblCuadrilla.Text = "Cuadrilla: ";
            // 
            // lblPrograma
            // 
            lblPrograma.AutoSize = true;
            lblPrograma.Location = new Point(12, 269);
            lblPrograma.Name = "lblPrograma";
            lblPrograma.Size = new Size(65, 15);
            lblPrograma.TabIndex = 12;
            lblPrograma.Text = "Programa: ";
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Location = new Point(12, 194);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(36, 15);
            lblLote.TabIndex = 13;
            lblLote.Text = "Lote: ";
            // 
            // lblLibras
            // 
            lblLibras.AutoSize = true;
            lblLibras.Location = new Point(12, 119);
            lblLibras.Name = "lblLibras";
            lblLibras.Size = new Size(44, 15);
            lblLibras.TabIndex = 14;
            lblLibras.Text = "Libras: ";
            // 
            // nudCajasFinal
            // 
            nudCajasFinal.Location = new Point(159, 64);
            nudCajasFinal.Name = "nudCajasFinal";
            nudCajasFinal.Size = new Size(67, 23);
            nudCajasFinal.TabIndex = 15;
            // 
            // btnReestibar
            // 
            btnReestibar.Location = new Point(359, 62);
            btnReestibar.Name = "btnReestibar";
            btnReestibar.Size = new Size(63, 23);
            btnReestibar.TabIndex = 17;
            btnReestibar.Text = "Reestibar";
            btnReestibar.UseVisualStyleBackColor = true;
            btnReestibar.Click += btnReestibar_Click;
            // 
            // lblPapeleta
            // 
            lblPapeleta.AutoSize = true;
            lblPapeleta.Location = new Point(12, 284);
            lblPapeleta.Name = "lblPapeleta";
            lblPapeleta.Size = new Size(58, 15);
            lblPapeleta.TabIndex = 18;
            lblPapeleta.Text = "Papeleta: ";
            // 
            // btnPallet
            // 
            btnPallet.BackgroundImage = Properties.Resources.BuscarLupa1;
            btnPallet.BackgroundImageLayout = ImageLayout.Stretch;
            btnPallet.Location = new Point(125, 64);
            btnPallet.Name = "btnPallet";
            btnPallet.Size = new Size(23, 23);
            btnPallet.TabIndex = 22;
            btnPallet.UseVisualStyleBackColor = true;
            btnPallet.Click += btnPallet_Click;
            // 
            // lblIdPallet
            // 
            lblIdPallet.AutoSize = true;
            lblIdPallet.Location = new Point(12, 89);
            lblIdPallet.Name = "lblIdPallet";
            lblIdPallet.Size = new Size(42, 15);
            lblIdPallet.TabIndex = 23;
            lblIdPallet.Text = "Pallet: ";
            // 
            // cboMotivo
            // 
            cboMotivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMotivo.FormattingEnabled = true;
            cboMotivo.Items.AddRange(new object[] { "SOBRANTE", "CORTESÍA", "REEMPAQUE", "SINIESTRÓ", "FAILED" });
            cboMotivo.Location = new Point(232, 63);
            cboMotivo.Name = "cboMotivo";
            cboMotivo.Size = new Size(121, 23);
            cboMotivo.TabIndex = 24;
            cboMotivo.SelectedIndexChanged += cboMotivo_SelectedIndexChanged;
            // 
            // lblCajasFinal
            // 
            lblCajasFinal.AutoSize = true;
            lblCajasFinal.Location = new Point(159, 46);
            lblCajasFinal.Name = "lblCajasFinal";
            lblCajasFinal.Size = new Size(67, 15);
            lblCajasFinal.TabIndex = 16;
            lblCajasFinal.Text = "Cajas final: ";
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(232, 45);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(51, 15);
            lblMotivo.TabIndex = 25;
            lblMotivo.Text = "Motivo: ";
            // 
            // lblManifiesto
            // 
            lblManifiesto.AutoSize = true;
            lblManifiesto.Location = new Point(12, 299);
            lblManifiesto.Name = "lblManifiesto";
            lblManifiesto.Size = new Size(69, 15);
            lblManifiesto.TabIndex = 26;
            lblManifiesto.Text = "Manifiesto: ";
            // 
            // FrmReestibado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 324);
            Controls.Add(lblManifiesto);
            Controls.Add(lblMotivo);
            Controls.Add(cboMotivo);
            Controls.Add(lblIdPallet);
            Controls.Add(btnPallet);
            Controls.Add(lblPapeleta);
            Controls.Add(btnReestibar);
            Controls.Add(lblCajasFinal);
            Controls.Add(nudCajasFinal);
            Controls.Add(lblLibras);
            Controls.Add(lblLote);
            Controls.Add(lblPrograma);
            Controls.Add(lblCuadrilla);
            Controls.Add(lblPlanDeTrabajo);
            Controls.Add(lblFecha);
            Controls.Add(lblCajasIniciales);
            Controls.Add(lblTamaño);
            Controls.Add(lblDistribuidor);
            Controls.Add(lblContenedor);
            Controls.Add(lblPresentacion);
            Controls.Add(lblVariedad);
            Controls.Add(lblPallet);
            Controls.Add(lblTitulo);
            Controls.Add(txbIdPallet);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmReestibado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reestibado";
            Load += FrmReestibado_Load;
            ((System.ComponentModel.ISupportInitialize)nudCajasFinal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbIdPallet;
        public Label lblTitulo;
        private Label lblPallet;
        private Label lblVariedad;
        private Label lblPresentacion;
        private Label lblContenedor;
        private Label lblDistribuidor;
        private Label lblTamaño;
        private Label lblCajasIniciales;
        private Label lblFecha;
        private Label lblPlanDeTrabajo;
        private Label lblCuadrilla;
        private Label lblPrograma;
        private Label lblLote;
        private Label lblLibras;
        private NumericUpDown nudCajasFinal;
        private Button btnReestibar;
        private Label lblPapeleta;
        private Button btnPallet;
        private Label lblIdPallet;
        private ComboBox cboMotivo;
        private Label lblCajasFinal;
        private Label lblMotivo;
        private Label lblManifiesto;
    }
}
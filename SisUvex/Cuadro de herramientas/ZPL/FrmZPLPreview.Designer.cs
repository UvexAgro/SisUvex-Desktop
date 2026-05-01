namespace SisUvex.Cuadro_de_herramientas.ZPL
{
    partial class FrmZPLPreview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZPLPreview));
            splitMain = new SplitContainer();
            rtbZpl = new RichTextBox();
            pnlPreview = new Panel();
            pnlBarZoom = new Panel();
            flpZoom = new FlowLayoutPanel();
            lblZoomTitulo = new Label();
            btnZoomMenos = new Button();
            trackZoom = new TrackBar();
            btnZoomMas = new Button();
            lblZoomPct = new Label();
            btnZoom100 = new Button();
            pnlTop = new Panel();
            flpOpciones = new FlowLayoutPanel();
            lblDensidad = new Label();
            cboDpmm = new ComboBox();
            lblCalidad = new Label();
            cboCalidad = new ComboBox();
            lblAncho = new Label();
            nudAncho = new NumericUpDown();
            lblAlto = new Label();
            nudAlto = new NumericUpDown();
            lblUnidad = new Label();
            cboUnidad = new ComboBox();
            lblEtiquetaNum = new Label();
            nudEtiqueta = new NumericUpDown();
            lblDe = new Label();
            lblTotalEtiquetas = new Label();
            lblHost = new Label();
            txbApiHost = new TextBox();
            lblClaveApi = new Label();
            txbApiKey = new TextBox();
            lblImpresora = new Label();
            cboImpresora = new ComboBox();
            btnImprimirZpl = new Button();
            btnActualizarPreview = new Button();
            lblEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            pnlBarZoom.SuspendLayout();
            flpZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackZoom).BeginInit();
            pnlTop.SuspendLayout();
            flpOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAncho).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAlto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEtiqueta).BeginInit();
            SuspendLayout();
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 150);
            splitMain.Margin = new Padding(3, 2, 3, 2);
            splitMain.Name = "splitMain";
            splitMain.Orientation = Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(rtbZpl);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(pnlPreview);
            splitMain.Panel2.Controls.Add(pnlBarZoom);
            splitMain.Size = new Size(892, 519);
            splitMain.SplitterDistance = 221;
            splitMain.SplitterWidth = 3;
            splitMain.TabIndex = 0;
            // 
            // rtbZpl
            // 
            rtbZpl.AcceptsTab = true;
            rtbZpl.Dock = DockStyle.Fill;
            rtbZpl.Font = new Font("Consolas", 9F);
            rtbZpl.Location = new Point(0, 0);
            rtbZpl.Margin = new Padding(3, 2, 3, 2);
            rtbZpl.Name = "rtbZpl";
            rtbZpl.Size = new Size(892, 221);
            rtbZpl.TabIndex = 0;
            rtbZpl.Text = "^XA\n^FX Prueba SisUvex\n^FO50,50^FDHola ZPL^FS\n^XZ";
            rtbZpl.WordWrap = false;
            // 
            // pnlPreview
            // 
            pnlPreview.AutoSize = true;
            pnlPreview.BackColor = Color.White;
            pnlPreview.BorderStyle = BorderStyle.FixedSingle;
            pnlPreview.Dock = DockStyle.Fill;
            pnlPreview.Location = new Point(0, 0);
            pnlPreview.Margin = new Padding(3, 2, 3, 2);
            pnlPreview.Name = "pnlPreview";
            pnlPreview.Size = new Size(892, 262);
            pnlPreview.TabIndex = 0;
            // 
            // pnlBarZoom
            // 
            pnlBarZoom.Controls.Add(flpZoom);
            pnlBarZoom.Dock = DockStyle.Bottom;
            pnlBarZoom.Location = new Point(0, 262);
            pnlBarZoom.Margin = new Padding(3, 2, 3, 2);
            pnlBarZoom.Name = "pnlBarZoom";
            pnlBarZoom.Size = new Size(892, 33);
            pnlBarZoom.TabIndex = 1;
            // 
            // flpZoom
            // 
            flpZoom.Controls.Add(lblZoomTitulo);
            flpZoom.Controls.Add(btnZoomMenos);
            flpZoom.Controls.Add(trackZoom);
            flpZoom.Controls.Add(btnZoomMas);
            flpZoom.Controls.Add(lblZoomPct);
            flpZoom.Controls.Add(btnZoom100);
            flpZoom.Dock = DockStyle.Fill;
            flpZoom.Location = new Point(0, 0);
            flpZoom.Margin = new Padding(0);
            flpZoom.Name = "flpZoom";
            flpZoom.Padding = new Padding(7, 6, 7, 4);
            flpZoom.Size = new Size(892, 33);
            flpZoom.TabIndex = 0;
            flpZoom.WrapContents = false;
            // 
            // lblZoomTitulo
            // 
            lblZoomTitulo.AutoSize = true;
            lblZoomTitulo.Location = new Point(10, 10);
            lblZoomTitulo.Margin = new Padding(3, 4, 7, 2);
            lblZoomTitulo.Name = "lblZoomTitulo";
            lblZoomTitulo.Size = new Size(42, 15);
            lblZoomTitulo.TabIndex = 0;
            lblZoomTitulo.Text = "Zoom:";
            lblZoomTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnZoomMenos
            // 
            btnZoomMenos.Location = new Point(62, 8);
            btnZoomMenos.Margin = new Padding(3, 2, 4, 2);
            btnZoomMenos.Name = "btnZoomMenos";
            btnZoomMenos.Size = new Size(32, 21);
            btnZoomMenos.TabIndex = 1;
            btnZoomMenos.Text = "−";
            btnZoomMenos.UseVisualStyleBackColor = true;
            // 
            // trackZoom
            // 
            trackZoom.AutoSize = false;
            trackZoom.LargeChange = 25;
            trackZoom.Location = new Point(101, 8);
            trackZoom.Margin = new Padding(3, 2, 7, 2);
            trackZoom.Maximum = 400;
            trackZoom.Minimum = 25;
            trackZoom.Name = "trackZoom";
            trackZoom.Size = new Size(298, 27);
            trackZoom.SmallChange = 5;
            trackZoom.TabIndex = 2;
            trackZoom.TickFrequency = 25;
            trackZoom.Value = 100;
            // 
            // btnZoomMas
            // 
            btnZoomMas.Location = new Point(409, 8);
            btnZoomMas.Margin = new Padding(3, 2, 7, 2);
            btnZoomMas.Name = "btnZoomMas";
            btnZoomMas.Size = new Size(32, 21);
            btnZoomMas.TabIndex = 3;
            btnZoomMas.Text = "+";
            btnZoomMas.UseVisualStyleBackColor = true;
            // 
            // lblZoomPct
            // 
            lblZoomPct.AutoSize = true;
            lblZoomPct.Location = new Point(451, 10);
            lblZoomPct.Margin = new Padding(3, 4, 10, 2);
            lblZoomPct.MinimumSize = new Size(46, 0);
            lblZoomPct.Name = "lblZoomPct";
            lblZoomPct.Size = new Size(46, 15);
            lblZoomPct.TabIndex = 4;
            lblZoomPct.Text = "100 %";
            lblZoomPct.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnZoom100
            // 
            btnZoom100.AutoSize = true;
            btnZoom100.Location = new Point(510, 8);
            btnZoom100.Margin = new Padding(3, 2, 3, 2);
            btnZoom100.Name = "btnZoom100";
            btnZoom100.Size = new Size(96, 25);
            btnZoom100.TabIndex = 5;
            btnZoom100.Text = "Ajustar 100 %";
            btnZoom100.UseVisualStyleBackColor = true;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(flpOpciones);
            pnlTop.Controls.Add(lblEstado);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 2, 3, 2);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(892, 150);
            pnlTop.TabIndex = 1;
            // 
            // flpOpciones
            // 
            flpOpciones.AutoScroll = true;
            flpOpciones.Controls.Add(lblDensidad);
            flpOpciones.Controls.Add(cboDpmm);
            flpOpciones.Controls.Add(lblCalidad);
            flpOpciones.Controls.Add(cboCalidad);
            flpOpciones.Controls.Add(lblAncho);
            flpOpciones.Controls.Add(nudAncho);
            flpOpciones.Controls.Add(lblAlto);
            flpOpciones.Controls.Add(nudAlto);
            flpOpciones.Controls.Add(lblUnidad);
            flpOpciones.Controls.Add(cboUnidad);
            flpOpciones.Controls.Add(lblEtiquetaNum);
            flpOpciones.Controls.Add(nudEtiqueta);
            flpOpciones.Controls.Add(lblDe);
            flpOpciones.Controls.Add(lblTotalEtiquetas);
            flpOpciones.Controls.Add(lblHost);
            flpOpciones.Controls.Add(txbApiHost);
            flpOpciones.Controls.Add(lblClaveApi);
            flpOpciones.Controls.Add(txbApiKey);
            flpOpciones.Controls.Add(lblImpresora);
            flpOpciones.Controls.Add(cboImpresora);
            flpOpciones.Controls.Add(btnActualizarPreview);
            flpOpciones.Controls.Add(btnImprimirZpl);
            flpOpciones.Dock = DockStyle.Fill;
            flpOpciones.Location = new Point(0, 0);
            flpOpciones.Margin = new Padding(3, 2, 3, 2);
            flpOpciones.Name = "flpOpciones";
            flpOpciones.Padding = new Padding(7, 6, 7, 3);
            flpOpciones.Size = new Size(892, 124);
            flpOpciones.TabIndex = 0;
            // 
            // lblDensidad
            // 
            lblDensidad.AutoSize = true;
            lblDensidad.Location = new Point(10, 9);
            lblDensidad.Margin = new Padding(3, 3, 3, 6);
            lblDensidad.Name = "lblDensidad";
            lblDensidad.Size = new Size(59, 15);
            lblDensidad.TabIndex = 0;
            lblDensidad.Text = "Densidad:";
            lblDensidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboDpmm
            // 
            cboDpmm.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDpmm.FormattingEnabled = true;
            cboDpmm.Location = new Point(75, 6);
            cboDpmm.Margin = new Padding(3, 0, 10, 3);
            cboDpmm.Name = "cboDpmm";
            cboDpmm.Size = new Size(140, 23);
            cboDpmm.TabIndex = 1;
            // 
            // lblCalidad
            // 
            lblCalidad.AutoSize = true;
            lblCalidad.Location = new Point(228, 9);
            lblCalidad.Margin = new Padding(3, 3, 3, 6);
            lblCalidad.Name = "lblCalidad";
            lblCalidad.Size = new Size(50, 15);
            lblCalidad.TabIndex = 2;
            lblCalidad.Text = "Calidad:";
            // 
            // cboCalidad
            // 
            cboCalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCalidad.FormattingEnabled = true;
            cboCalidad.Location = new Point(284, 6);
            cboCalidad.Margin = new Padding(3, 0, 10, 3);
            cboCalidad.Name = "cboCalidad";
            cboCalidad.Size = new Size(106, 23);
            cboCalidad.TabIndex = 3;
            // 
            // lblAncho
            // 
            lblAncho.AutoSize = true;
            lblAncho.Location = new Point(403, 9);
            lblAncho.Margin = new Padding(3, 3, 3, 6);
            lblAncho.Name = "lblAncho";
            lblAncho.Size = new Size(45, 15);
            lblAncho.TabIndex = 4;
            lblAncho.Text = "Ancho:";
            // 
            // nudAncho
            // 
            nudAncho.DecimalPlaces = 3;
            nudAncho.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            nudAncho.Location = new Point(454, 6);
            nudAncho.Margin = new Padding(3, 0, 7, 3);
            nudAncho.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudAncho.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            nudAncho.Name = "nudAncho";
            nudAncho.Size = new Size(79, 23);
            nudAncho.TabIndex = 5;
            nudAncho.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // lblAlto
            // 
            lblAlto.AutoSize = true;
            lblAlto.Location = new Point(543, 9);
            lblAlto.Margin = new Padding(3, 3, 3, 6);
            lblAlto.Name = "lblAlto";
            lblAlto.Size = new Size(32, 15);
            lblAlto.TabIndex = 6;
            lblAlto.Text = "Alto:";
            // 
            // nudAlto
            // 
            nudAlto.DecimalPlaces = 3;
            nudAlto.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            nudAlto.Location = new Point(581, 6);
            nudAlto.Margin = new Padding(3, 0, 7, 3);
            nudAlto.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudAlto.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            nudAlto.Name = "nudAlto";
            nudAlto.Size = new Size(79, 23);
            nudAlto.TabIndex = 7;
            nudAlto.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // lblUnidad
            // 
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new Point(670, 9);
            lblUnidad.Margin = new Padding(3, 3, 3, 6);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(48, 15);
            lblUnidad.TabIndex = 8;
            lblUnidad.Text = "Unidad:";
            // 
            // cboUnidad
            // 
            cboUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnidad.FormattingEnabled = true;
            cboUnidad.Location = new Point(724, 6);
            cboUnidad.Margin = new Padding(3, 0, 10, 3);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new Size(88, 23);
            cboUnidad.TabIndex = 9;
            // 
            // lblEtiquetaNum
            // 
            lblEtiquetaNum.AutoSize = true;
            lblEtiquetaNum.Location = new Point(10, 38);
            lblEtiquetaNum.Margin = new Padding(3, 6, 3, 6);
            lblEtiquetaNum.Name = "lblEtiquetaNum";
            lblEtiquetaNum.Size = new Size(97, 15);
            lblEtiquetaNum.TabIndex = 10;
            lblEtiquetaNum.Text = "Mostrar etiqueta:";
            // 
            // nudEtiqueta
            // 
            nudEtiqueta.Location = new Point(113, 35);
            nudEtiqueta.Margin = new Padding(3, 3, 4, 3);
            nudEtiqueta.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudEtiqueta.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEtiqueta.Name = "nudEtiqueta";
            nudEtiqueta.Size = new Size(52, 23);
            nudEtiqueta.TabIndex = 11;
            nudEtiqueta.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDe
            // 
            lblDe.AutoSize = true;
            lblDe.Location = new Point(172, 38);
            lblDe.Margin = new Padding(3, 6, 4, 6);
            lblDe.Name = "lblDe";
            lblDe.Size = new Size(20, 15);
            lblDe.TabIndex = 12;
            lblDe.Text = "de";
            // 
            // lblTotalEtiquetas
            // 
            lblTotalEtiquetas.AutoSize = true;
            lblTotalEtiquetas.Location = new Point(199, 38);
            lblTotalEtiquetas.Margin = new Padding(3, 6, 14, 6);
            lblTotalEtiquetas.Name = "lblTotalEtiquetas";
            lblTotalEtiquetas.Size = new Size(12, 15);
            lblTotalEtiquetas.TabIndex = 13;
            lblTotalEtiquetas.Text = "?";
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(228, 38);
            lblHost.Margin = new Padding(3, 6, 3, 6);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(56, 15);
            lblHost.TabIndex = 14;
            lblHost.Text = "Host API:";
            // 
            // txbApiHost
            // 
            txbApiHost.Location = new Point(290, 35);
            txbApiHost.Margin = new Padding(3, 3, 10, 3);
            txbApiHost.Name = "txbApiHost";
            txbApiHost.PlaceholderText = "api.labelary.com (vacío = público)";
            txbApiHost.Size = new Size(246, 23);
            txbApiHost.TabIndex = 15;
            // 
            // lblClaveApi
            // 
            lblClaveApi.AutoSize = true;
            lblClaveApi.Location = new Point(549, 38);
            lblClaveApi.Margin = new Padding(3, 6, 3, 6);
            lblClaveApi.Name = "lblClaveApi";
            lblClaveApi.Size = new Size(60, 15);
            lblClaveApi.TabIndex = 16;
            lblClaveApi.Text = "Clave API:";
            // 
            // txbApiKey
            // 
            txbApiKey.Location = new Point(615, 35);
            txbApiKey.Margin = new Padding(3, 3, 7, 3);
            txbApiKey.Name = "txbApiKey";
            txbApiKey.PasswordChar = '●';
            txbApiKey.PlaceholderText = "opcional";
            txbApiKey.Size = new Size(176, 23);
            txbApiKey.TabIndex = 17;
            // 
            // lblImpresora
            // 
            lblImpresora.AutoSize = true;
            lblImpresora.Location = new Point(801, 38);
            lblImpresora.Margin = new Padding(3, 6, 3, 6);
            lblImpresora.Name = "lblImpresora";
            lblImpresora.Size = new Size(63, 15);
            lblImpresora.TabIndex = 18;
            lblImpresora.Text = "Impresora:";
            // 
            // cboImpresora
            // 
            cboImpresora.FormattingEnabled = true;
            cboImpresora.Location = new Point(10, 64);
            cboImpresora.Margin = new Padding(3, 3, 10, 3);
            cboImpresora.Name = "cboImpresora";
            cboImpresora.Size = new Size(298, 23);
            cboImpresora.TabIndex = 19;
            // 
            // btnImprimirZpl
            // 
            btnImprimirZpl.AutoSize = true;
            btnImprimirZpl.Location = new Point(489, 63);
            btnImprimirZpl.Margin = new Padding(3, 2, 7, 3);
            btnImprimirZpl.Name = "btnImprimirZpl";
            btnImprimirZpl.Size = new Size(105, 25);
            btnImprimirZpl.TabIndex = 20;
            btnImprimirZpl.Text = "Imprimir ZPL";
            btnImprimirZpl.UseVisualStyleBackColor = true;
            // 
            // btnActualizarPreview
            // 
            btnActualizarPreview.AutoSize = true;
            btnActualizarPreview.Location = new Point(321, 63);
            btnActualizarPreview.Margin = new Padding(3, 2, 7, 3);
            btnActualizarPreview.Name = "btnActualizarPreview";
            btnActualizarPreview.Size = new Size(158, 25);
            btnActualizarPreview.TabIndex = 21;
            btnActualizarPreview.Text = "Actualizar vista previa";
            btnActualizarPreview.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            lblEstado.AutoEllipsis = true;
            lblEstado.Dock = DockStyle.Bottom;
            lblEstado.Location = new Point(0, 124);
            lblEstado.Name = "lblEstado";
            lblEstado.Padding = new Padding(7, 3, 7, 3);
            lblEstado.Size = new Size(892, 26);
            lblEstado.TabIndex = 1;
            lblEstado.Text = " ";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmZPLPreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 669);
            Controls.Add(splitMain);
            Controls.Add(pnlTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(702, 385);
            Name = "FrmZPLPreview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vista previa ZPL (Zebra)";
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            pnlBarZoom.ResumeLayout(false);
            flpZoom.ResumeLayout(false);
            flpZoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackZoom).EndInit();
            pnlTop.ResumeLayout(false);
            flpOpciones.ResumeLayout(false);
            flpOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAncho).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAlto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEtiqueta).EndInit();
            ResumeLayout(false);
        }

        private SplitContainer splitMain;
        private RichTextBox rtbZpl;
        internal Panel pnlPreview;
        private Panel pnlBarZoom;
        private FlowLayoutPanel flpZoom;
        private Label lblZoomTitulo;
        private Button btnZoomMenos;
        private TrackBar trackZoom;
        private Button btnZoomMas;
        private Label lblZoomPct;
        private Button btnZoom100;
        private Panel pnlTop;
        private FlowLayoutPanel flpOpciones;
        private Label lblEstado;
        private Label lblDensidad;
        private ComboBox cboDpmm;
        private Label lblCalidad;
        private ComboBox cboCalidad;
        private Label lblAncho;
        private NumericUpDown nudAncho;
        private Label lblAlto;
        private NumericUpDown nudAlto;
        private Label lblUnidad;
        private ComboBox cboUnidad;
        private Label lblEtiquetaNum;
        private NumericUpDown nudEtiqueta;
        private Label lblDe;
        private Label lblTotalEtiquetas;
        private Label lblHost;
        private TextBox txbApiHost;
        private Label lblClaveApi;
        private TextBox txbApiKey;
        private Label lblImpresora;
        private ComboBox cboImpresora;
        private Button btnImprimirZpl;
        private Button btnActualizarPreview;
    }
}

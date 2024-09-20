namespace SisUvex.Catalogos.Distribuidor
{
    partial class FrmDistribuidorAñadir
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
            lblTitulo = new Label();
            lblNombre = new Label();
            txbNombre = new TextBox();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            lblActivo = new Label();
            cboActivo = new ComboBox();
            txbDireccion = new TextBox();
            lblDireccion = new Label();
            txbCiudad = new TextBox();
            lblCiudad = new Label();
            txbRFC = new TextBox();
            lblRFC = new Label();
            txbTelefono = new TextBox();
            lblTelefono = new Label();
            cboMercado = new ComboBox();
            lblMercado = new Label();
            txbIdAgenciaMX = new TextBox();
            cboAgenciaMX = new ComboBox();
            lblAcenciaMX = new Label();
            txbIdAgenciaUS = new TextBox();
            cboAgenciaUS = new ComboBox();
            lblAgenciaUS = new Label();
            txbIdProductor = new TextBox();
            cboProductor = new ComboBox();
            lblProductor = new Label();
            txbIdCiudadDestino = new TextBox();
            cboCiudadDestino = new ComboBox();
            lblCiudadDestino = new Label();
            txbIdCiudadCruce = new TextBox();
            cboCiudadCruce = new ComboBox();
            lblCiudadCruce = new Label();
            btnBuscarAgenciaUS = new Button();
            btnTodoAgenciaUS = new Button();
            btnTodoAgenciaMX = new Button();
            btnBuscarAgenciaMX = new Button();
            btnTodoProductor = new Button();
            btnBuscarProductor = new Button();
            btnTodoCiudadCruce = new Button();
            btnBuscarCiudadCruce = new Button();
            btnTodoCiudadDestino = new Button();
            btnBuscarCiudadDestino = new Button();
            lblObliNombre = new Label();
            label1 = new Label();
            label2 = new Label();
            txbNombreCorto = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(239, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir distribuidor";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F);
            lblNombre.Location = new Point(12, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 21);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Font = new Font("Segoe UI", 12F);
            txbNombre.Location = new Point(89, 55);
            txbNombre.MaxLength = 50;
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(591, 29);
            txbNombre.TabIndex = 0;
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbId.Location = new Point(635, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 5;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F);
            lblId.Location = new Point(607, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(608, 444);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(527, 444);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F);
            lblActivo.Location = new Point(498, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 10;
            lblActivo.Text = "Activo: ";
            // 
            // cboActivo
            // 
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivo.Font = new Font("Segoe UI", 12F);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(554, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 21;
            // 
            // txbDireccion
            // 
            txbDireccion.Font = new Font("Segoe UI", 12F);
            txbDireccion.Location = new Point(90, 125);
            txbDireccion.MaxLength = 100;
            txbDireccion.Name = "txbDireccion";
            txbDireccion.Size = new Size(591, 29);
            txbDireccion.TabIndex = 1;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 12F);
            lblDireccion.Location = new Point(13, 128);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(78, 21);
            lblDireccion.TabIndex = 12;
            lblDireccion.Text = "Direccion:";
            // 
            // txbCiudad
            // 
            txbCiudad.Font = new Font("Segoe UI", 12F);
            txbCiudad.Location = new Point(90, 160);
            txbCiudad.MaxLength = 50;
            txbCiudad.Name = "txbCiudad";
            txbCiudad.Size = new Size(471, 29);
            txbCiudad.TabIndex = 2;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Font = new Font("Segoe UI", 12F);
            lblCiudad.Location = new Point(13, 163);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(62, 21);
            lblCiudad.TabIndex = 14;
            lblCiudad.Text = "Ciudad:";
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Segoe UI", 12F);
            txbRFC.Location = new Point(90, 195);
            txbRFC.MaxLength = 15;
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(268, 29);
            txbRFC.TabIndex = 3;
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 12F);
            lblRFC.Location = new Point(13, 198);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(41, 21);
            lblRFC.TabIndex = 16;
            lblRFC.Text = "RFC:";
            // 
            // txbTelefono
            // 
            txbTelefono.Font = new Font("Segoe UI", 12F);
            txbTelefono.Location = new Point(90, 230);
            txbTelefono.MaxLength = 13;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(268, 29);
            txbTelefono.TabIndex = 4;
            txbTelefono.KeyPress += txbTelefono_KeyPress;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F);
            lblTelefono.Location = new Point(13, 233);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 21);
            lblTelefono.TabIndex = 18;
            lblTelefono.Text = "Telefono:";
            // 
            // cboMercado
            // 
            cboMercado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMercado.Font = new Font("Segoe UI", 12F);
            cboMercado.FormattingEnabled = true;
            cboMercado.Items.AddRange(new object[] { "E", "N" });
            cboMercado.Location = new Point(449, 12);
            cboMercado.Name = "cboMercado";
            cboMercado.Size = new Size(43, 29);
            cboMercado.TabIndex = 20;
            // 
            // lblMercado
            // 
            lblMercado.AutoSize = true;
            lblMercado.Font = new Font("Segoe UI", 12F);
            lblMercado.Location = new Point(376, 15);
            lblMercado.Name = "lblMercado";
            lblMercado.Size = new Size(78, 21);
            lblMercado.TabIndex = 20;
            lblMercado.Text = "Mercado: ";
            // 
            // txbIdAgenciaMX
            // 
            txbIdAgenciaMX.Enabled = false;
            txbIdAgenciaMX.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdAgenciaMX.Location = new Point(125, 300);
            txbIdAgenciaMX.Name = "txbIdAgenciaMX";
            txbIdAgenciaMX.Size = new Size(43, 29);
            txbIdAgenciaMX.TabIndex = 24;
            txbIdAgenciaMX.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgenciaMX
            // 
            cboAgenciaMX.Font = new Font("Segoe UI", 12F);
            cboAgenciaMX.FormattingEnabled = true;
            cboAgenciaMX.ItemHeight = 21;
            cboAgenciaMX.Location = new Point(174, 301);
            cboAgenciaMX.Name = "cboAgenciaMX";
            cboAgenciaMX.Size = new Size(388, 29);
            cboAgenciaMX.TabIndex = 6;
            cboAgenciaMX.TextChanged += cboAgenciaMX_TextChanged;
            cboAgenciaMX.MouseClick += cboAgenciaMX_MouseClick;
            // 
            // lblAcenciaMX
            // 
            lblAcenciaMX.AutoSize = true;
            lblAcenciaMX.Font = new Font("Segoe UI", 12F);
            lblAcenciaMX.Location = new Point(13, 303);
            lblAcenciaMX.Name = "lblAcenciaMX";
            lblAcenciaMX.Size = new Size(95, 21);
            lblAcenciaMX.TabIndex = 22;
            lblAcenciaMX.Text = "Agencia MX:";
            // 
            // txbIdAgenciaUS
            // 
            txbIdAgenciaUS.Enabled = false;
            txbIdAgenciaUS.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdAgenciaUS.Location = new Point(125, 265);
            txbIdAgenciaUS.Name = "txbIdAgenciaUS";
            txbIdAgenciaUS.Size = new Size(43, 29);
            txbIdAgenciaUS.TabIndex = 27;
            txbIdAgenciaUS.TextAlign = HorizontalAlignment.Center;
            // 
            // cboAgenciaUS
            // 
            cboAgenciaUS.Font = new Font("Segoe UI", 12F);
            cboAgenciaUS.FormattingEnabled = true;
            cboAgenciaUS.ItemHeight = 21;
            cboAgenciaUS.Location = new Point(174, 266);
            cboAgenciaUS.Name = "cboAgenciaUS";
            cboAgenciaUS.Size = new Size(388, 29);
            cboAgenciaUS.TabIndex = 5;
            cboAgenciaUS.TextChanged += cboAgenciaUS_TextChanged;
            cboAgenciaUS.MouseClick += cboAgenciaUS_MouseClick;
            // 
            // lblAgenciaUS
            // 
            lblAgenciaUS.AutoSize = true;
            lblAgenciaUS.Font = new Font("Segoe UI", 12F);
            lblAgenciaUS.Location = new Point(13, 269);
            lblAgenciaUS.Name = "lblAgenciaUS";
            lblAgenciaUS.Size = new Size(92, 21);
            lblAgenciaUS.TabIndex = 25;
            lblAgenciaUS.Text = "Agencia US:";
            // 
            // txbIdProductor
            // 
            txbIdProductor.Enabled = false;
            txbIdProductor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdProductor.Location = new Point(125, 335);
            txbIdProductor.Name = "txbIdProductor";
            txbIdProductor.Size = new Size(43, 29);
            txbIdProductor.TabIndex = 30;
            txbIdProductor.TextAlign = HorizontalAlignment.Center;
            // 
            // cboProductor
            // 
            cboProductor.Font = new Font("Segoe UI", 12F);
            cboProductor.FormattingEnabled = true;
            cboProductor.ItemHeight = 21;
            cboProductor.Location = new Point(174, 336);
            cboProductor.Name = "cboProductor";
            cboProductor.Size = new Size(388, 29);
            cboProductor.TabIndex = 7;
            cboProductor.TextChanged += cboProductor_TextChanged;
            cboProductor.MouseClick += cboProductor_MouseClick;
            // 
            // lblProductor
            // 
            lblProductor.AutoSize = true;
            lblProductor.Font = new Font("Segoe UI", 12F);
            lblProductor.Location = new Point(13, 339);
            lblProductor.Name = "lblProductor";
            lblProductor.Size = new Size(82, 21);
            lblProductor.TabIndex = 28;
            lblProductor.Text = "Productor:";
            // 
            // txbIdCiudadDestino
            // 
            txbIdCiudadDestino.Enabled = false;
            txbIdCiudadDestino.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdCiudadDestino.Location = new Point(125, 405);
            txbIdCiudadDestino.Name = "txbIdCiudadDestino";
            txbIdCiudadDestino.Size = new Size(43, 29);
            txbIdCiudadDestino.TabIndex = 36;
            txbIdCiudadDestino.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCiudadDestino
            // 
            cboCiudadDestino.Font = new Font("Segoe UI", 12F);
            cboCiudadDestino.FormattingEnabled = true;
            cboCiudadDestino.ItemHeight = 21;
            cboCiudadDestino.Location = new Point(174, 406);
            cboCiudadDestino.Name = "cboCiudadDestino";
            cboCiudadDestino.Size = new Size(388, 29);
            cboCiudadDestino.TabIndex = 9;
            cboCiudadDestino.TextChanged += cboCiudadDestino_TextChanged;
            cboCiudadDestino.MouseClick += cboCiudadDestino_MouseClick;
            // 
            // lblCiudadDestino
            // 
            lblCiudadDestino.AutoSize = true;
            lblCiudadDestino.Font = new Font("Segoe UI", 12F);
            lblCiudadDestino.Location = new Point(13, 408);
            lblCiudadDestino.Name = "lblCiudadDestino";
            lblCiudadDestino.Size = new Size(117, 21);
            lblCiudadDestino.TabIndex = 34;
            lblCiudadDestino.Text = "Ciudad destino:";
            // 
            // txbIdCiudadCruce
            // 
            txbIdCiudadCruce.Enabled = false;
            txbIdCiudadCruce.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txbIdCiudadCruce.Location = new Point(125, 370);
            txbIdCiudadCruce.Name = "txbIdCiudadCruce";
            txbIdCiudadCruce.Size = new Size(43, 29);
            txbIdCiudadCruce.TabIndex = 33;
            txbIdCiudadCruce.TextAlign = HorizontalAlignment.Center;
            // 
            // cboCiudadCruce
            // 
            cboCiudadCruce.Font = new Font("Segoe UI", 12F);
            cboCiudadCruce.FormattingEnabled = true;
            cboCiudadCruce.ItemHeight = 21;
            cboCiudadCruce.Location = new Point(174, 371);
            cboCiudadCruce.Name = "cboCiudadCruce";
            cboCiudadCruce.Size = new Size(388, 29);
            cboCiudadCruce.TabIndex = 8;
            cboCiudadCruce.TextChanged += cboCiudadCruce_TextChanged;
            cboCiudadCruce.MouseClick += cboCiudadCruce_MouseClick;
            // 
            // lblCiudadCruce
            // 
            lblCiudadCruce.AutoSize = true;
            lblCiudadCruce.Font = new Font("Segoe UI", 12F);
            lblCiudadCruce.Location = new Point(13, 372);
            lblCiudadCruce.Name = "lblCiudadCruce";
            lblCiudadCruce.Size = new Size(103, 21);
            lblCiudadCruce.TabIndex = 31;
            lblCiudadCruce.Text = "Ciudad cruce:";
            // 
            // btnBuscarAgenciaUS
            // 
            btnBuscarAgenciaUS.Location = new Point(568, 265);
            btnBuscarAgenciaUS.Name = "btnBuscarAgenciaUS";
            btnBuscarAgenciaUS.Size = new Size(54, 29);
            btnBuscarAgenciaUS.TabIndex = 12;
            btnBuscarAgenciaUS.Text = "Buscar";
            btnBuscarAgenciaUS.UseVisualStyleBackColor = true;
            btnBuscarAgenciaUS.Click += btnBuscarAgenciaUS_Click;
            // 
            // btnTodoAgenciaUS
            // 
            btnTodoAgenciaUS.Location = new Point(628, 265);
            btnTodoAgenciaUS.Name = "btnTodoAgenciaUS";
            btnTodoAgenciaUS.Size = new Size(54, 29);
            btnTodoAgenciaUS.TabIndex = 13;
            btnTodoAgenciaUS.Text = "Todo";
            btnTodoAgenciaUS.UseVisualStyleBackColor = true;
            btnTodoAgenciaUS.Click += btnTodoAgenciaUS_Click;
            // 
            // btnTodoAgenciaMX
            // 
            btnTodoAgenciaMX.Location = new Point(628, 300);
            btnTodoAgenciaMX.Name = "btnTodoAgenciaMX";
            btnTodoAgenciaMX.Size = new Size(54, 29);
            btnTodoAgenciaMX.TabIndex = 14;
            btnTodoAgenciaMX.Text = "Todo";
            btnTodoAgenciaMX.UseVisualStyleBackColor = true;
            btnTodoAgenciaMX.Click += btnTodoAgenciaMX_Click;
            // 
            // btnBuscarAgenciaMX
            // 
            btnBuscarAgenciaMX.Location = new Point(568, 300);
            btnBuscarAgenciaMX.Name = "btnBuscarAgenciaMX";
            btnBuscarAgenciaMX.Size = new Size(54, 29);
            btnBuscarAgenciaMX.TabIndex = 13;
            btnBuscarAgenciaMX.Text = "Buscar";
            btnBuscarAgenciaMX.UseVisualStyleBackColor = true;
            btnBuscarAgenciaMX.Click += btnBuscarAgenciaMX_Click;
            // 
            // btnTodoProductor
            // 
            btnTodoProductor.Location = new Point(628, 335);
            btnTodoProductor.Name = "btnTodoProductor";
            btnTodoProductor.Size = new Size(54, 29);
            btnTodoProductor.TabIndex = 16;
            btnTodoProductor.Text = "Todo";
            btnTodoProductor.UseVisualStyleBackColor = true;
            btnTodoProductor.Click += btnTodoProductor_Click;
            // 
            // btnBuscarProductor
            // 
            btnBuscarProductor.Location = new Point(568, 335);
            btnBuscarProductor.Name = "btnBuscarProductor";
            btnBuscarProductor.Size = new Size(54, 29);
            btnBuscarProductor.TabIndex = 15;
            btnBuscarProductor.Text = "Buscar";
            btnBuscarProductor.UseVisualStyleBackColor = true;
            btnBuscarProductor.Click += btnBuscarProductor_Click;
            // 
            // btnTodoCiudadCruce
            // 
            btnTodoCiudadCruce.Location = new Point(628, 370);
            btnTodoCiudadCruce.Name = "btnTodoCiudadCruce";
            btnTodoCiudadCruce.Size = new Size(54, 29);
            btnTodoCiudadCruce.TabIndex = 18;
            btnTodoCiudadCruce.Text = "Todo";
            btnTodoCiudadCruce.UseVisualStyleBackColor = true;
            btnTodoCiudadCruce.Click += btnTodoCiudadCruce_Click;
            // 
            // btnBuscarCiudadCruce
            // 
            btnBuscarCiudadCruce.Location = new Point(568, 370);
            btnBuscarCiudadCruce.Name = "btnBuscarCiudadCruce";
            btnBuscarCiudadCruce.Size = new Size(54, 29);
            btnBuscarCiudadCruce.TabIndex = 17;
            btnBuscarCiudadCruce.Text = "Buscar";
            btnBuscarCiudadCruce.UseVisualStyleBackColor = true;
            btnBuscarCiudadCruce.Click += btnBuscarCiudadCruce_Click;
            // 
            // btnTodoCiudadDestino
            // 
            btnTodoCiudadDestino.Location = new Point(628, 405);
            btnTodoCiudadDestino.Name = "btnTodoCiudadDestino";
            btnTodoCiudadDestino.Size = new Size(54, 29);
            btnTodoCiudadDestino.TabIndex = 21;
            btnTodoCiudadDestino.Text = "Todo";
            btnTodoCiudadDestino.UseVisualStyleBackColor = true;
            btnTodoCiudadDestino.Click += btnTodoCiudadDestino_Click;
            // 
            // btnBuscarCiudadDestino
            // 
            btnBuscarCiudadDestino.Location = new Point(568, 405);
            btnBuscarCiudadDestino.Name = "btnBuscarCiudadDestino";
            btnBuscarCiudadDestino.Size = new Size(54, 29);
            btnBuscarCiudadDestino.TabIndex = 19;
            btnBuscarCiudadDestino.Text = "Buscar";
            btnBuscarCiudadDestino.UseVisualStyleBackColor = true;
            btnBuscarCiudadDestino.Click += btnBuscarCiudadDestino_Click;
            // 
            // lblObliNombre
            // 
            lblObliNombre.AutoSize = true;
            lblObliNombre.ForeColor = Color.Crimson;
            lblObliNombre.Location = new Point(4, 58);
            lblObliNombre.Name = "lblObliNombre";
            lblObliNombre.Size = new Size(12, 15);
            lblObliNombre.TabIndex = 37;
            lblObliNombre.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(368, 16);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 38;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(490, 15);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 39;
            label2.Text = "*";
            // 
            // txbNombreCorto
            // 
            txbNombreCorto.Font = new Font("Segoe UI", 12F);
            txbNombreCorto.Location = new Point(129, 90);
            txbNombreCorto.MaxLength = 10;
            txbNombreCorto.Name = "txbNombreCorto";
            txbNombreCorto.Size = new Size(229, 29);
            txbNombreCorto.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 93);
            label3.Name = "label3";
            label3.Size = new Size(111, 21);
            label3.TabIndex = 41;
            label3.Text = "Nombre corto:";
            // 
            // FrmDistribuidorAñadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 486);
            Controls.Add(txbNombreCorto);
            Controls.Add(label3);
            Controls.Add(btnTodoCiudadDestino);
            Controls.Add(btnBuscarCiudadDestino);
            Controls.Add(btnTodoCiudadCruce);
            Controls.Add(btnBuscarCiudadCruce);
            Controls.Add(btnTodoProductor);
            Controls.Add(btnBuscarProductor);
            Controls.Add(btnTodoAgenciaMX);
            Controls.Add(btnBuscarAgenciaMX);
            Controls.Add(btnTodoAgenciaUS);
            Controls.Add(btnBuscarAgenciaUS);
            Controls.Add(txbIdCiudadDestino);
            Controls.Add(cboCiudadDestino);
            Controls.Add(lblCiudadDestino);
            Controls.Add(txbIdCiudadCruce);
            Controls.Add(cboCiudadCruce);
            Controls.Add(lblCiudadCruce);
            Controls.Add(txbIdProductor);
            Controls.Add(cboProductor);
            Controls.Add(lblProductor);
            Controls.Add(txbIdAgenciaUS);
            Controls.Add(cboAgenciaUS);
            Controls.Add(lblAgenciaUS);
            Controls.Add(txbIdAgenciaMX);
            Controls.Add(cboAgenciaMX);
            Controls.Add(lblAcenciaMX);
            Controls.Add(cboMercado);
            Controls.Add(txbTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txbRFC);
            Controls.Add(lblRFC);
            Controls.Add(txbCiudad);
            Controls.Add(lblCiudad);
            Controls.Add(txbDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(cboActivo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(txbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblActivo);
            Controls.Add(lblMercado);
            Controls.Add(label1);
            Controls.Add(lblObliNombre);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDistribuidorAñadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir distribuidor";
            FormClosing += FrmDistribuidorAñadir_FormClosing;
            Load += FrmDistribuidorAñadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombre;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblDireccion;
        private Label lblActivo;
        public Label lblTitulo;
        public TextBox txbNombre;
        public TextBox txbId;
        public ComboBox cboActivo;
        public TextBox txbDireccion;
        public TextBox txbCiudad;
        private Label lblCiudad;
        public TextBox txbRFC;
        private Label lblRFC;
        public TextBox txbTelefono;
        private Label lblTelefono;
        public ComboBox cboMercado;
        private Label lblMercado;
        public TextBox txbIdAgenciaMX;
        private Label lblAcenciaMX;
        public TextBox txbIdAgenciaUS;
        private Label lblAgenciaUS;
        public TextBox txbIdProductor;
        private ComboBox cboProductor;
        private Label lblProductor;
        public TextBox txbIdCiudadDestino;
        private ComboBox cboCiudadDestino;
        private Label lblCiudadDestino;
        public TextBox txbIdCiudadCruce;
        private ComboBox cboCiudadCruce;
        private Label lblCiudadCruce;
        private Button btnBuscarAgenciaUS;
        private Button btnTodoAgenciaUS;
        private Button btnTodoAgenciaMX;
        private Button btnBuscarAgenciaMX;
        private Button btnTodoProductor;
        private Button btnBuscarProductor;
        private Button btnTodoCiudadCruce;
        private Button btnBuscarCiudadCruce;
        private Button btnTodoCiudadDestino;
        private Button btnBuscarCiudadDestino;
        private Label lblObliNombre;
        private Label label1;
        private Label label2;
        public ComboBox cboAgenciaUS;
        public ComboBox cboAgenciaMX;
        public TextBox txbNombreCorto;
        private Label label3;
    }
}
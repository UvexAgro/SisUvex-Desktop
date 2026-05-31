namespace SisUvex.Archivo.MixtearPallets
{
    partial class FrmReestibaPallet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpInfoPallet = new GroupBox();
            grpReestiba = new GroupBox();
            lblCajasNueva = new Label();
            numCajas = new NumericUpDown();
            lblSobrantesTxt = new Label();
            txbCajasSobrantes = new TextBox();
            lblPositionTxt = new Label();
            cboPosition = new ComboBox();
            lblPosInfo = new Label();
            lblSobrantesInfo = new Label();
            lblTipoTxt = new Label();
            cboTipo = new ComboBox();
            lblDescripcion = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            grpReestiba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCajas).BeginInit();
            SuspendLayout();
            // 
            // grpInfoPallet
            // 
            grpInfoPallet.Location = new Point(12, 10);
            grpInfoPallet.Name = "grpInfoPallet";
            grpInfoPallet.Size = new Size(676, 50);
            grpInfoPallet.TabIndex = 0;
            grpInfoPallet.TabStop = false;
            grpInfoPallet.Text = "Información del pallet";
            // 
            // grpReestiba
            // 
            grpReestiba.Controls.Add(lblCajasNueva);
            grpReestiba.Controls.Add(numCajas);
            grpReestiba.Controls.Add(lblSobrantesTxt);
            grpReestiba.Controls.Add(txbCajasSobrantes);
            grpReestiba.Controls.Add(lblPositionTxt);
            grpReestiba.Controls.Add(cboPosition);
            grpReestiba.Controls.Add(lblPosInfo);
            grpReestiba.Controls.Add(lblSobrantesInfo);
            grpReestiba.Controls.Add(lblTipoTxt);
            grpReestiba.Controls.Add(cboTipo);
            grpReestiba.Controls.Add(lblDescripcion);
            grpReestiba.Location = new Point(12, 68);
            grpReestiba.Name = "grpReestiba";
            grpReestiba.Size = new Size(676, 230);
            grpReestiba.TabIndex = 1;
            grpReestiba.TabStop = false;
            grpReestiba.Text = "Configuración de la reestiba";
            // 
            // lblCajasNueva
            // 
            lblCajasNueva.AutoSize = true;
            lblCajasNueva.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCajasNueva.Location = new Point(12, 28);
            lblCajasNueva.Name = "lblCajasNueva";
            lblCajasNueva.Size = new Size(155, 15);
            lblCajasNueva.TabIndex = 0;
            lblCajasNueva.Text = "Cajas para el pallet original:";
            // 
            // numCajas
            // 
            numCajas.Location = new Point(192, 25);
            numCajas.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numCajas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCajas.Name = "numCajas";
            numCajas.Size = new Size(39, 23);
            numCajas.TabIndex = 0;
            numCajas.TextAlign = HorizontalAlignment.Right;
            numCajas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numCajas.TextChanged += numCajas_TextChanged;
            numCajas.ValueChanged += numCajas_ValueChanged;
            // 
            // lblSobrantesTxt
            // 
            lblSobrantesTxt.AutoSize = true;
            lblSobrantesTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSobrantesTxt.Location = new Point(12, 62);
            lblSobrantesTxt.Name = "lblSobrantesTxt";
            lblSobrantesTxt.Size = new Size(174, 15);
            lblSobrantesTxt.TabIndex = 1;
            lblSobrantesTxt.Text = "Cajas sobrantes (nuevo pallet):";
            // 
            // txbCajasSobrantes
            // 
            txbCajasSobrantes.Enabled = false;
            txbCajasSobrantes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txbCajasSobrantes.ForeColor = Color.DarkGreen;
            txbCajasSobrantes.Location = new Point(192, 59);
            txbCajasSobrantes.Name = "txbCajasSobrantes";
            txbCajasSobrantes.Size = new Size(39, 23);
            txbCajasSobrantes.TabIndex = 1;
            txbCajasSobrantes.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPositionTxt
            // 
            lblPositionTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPositionTxt.Location = new Point(6, 172);
            lblPositionTxt.Name = "lblPositionTxt";
            lblPositionTxt.Size = new Size(303, 18);
            lblPositionTxt.TabIndex = 5;
            lblPositionTxt.Text = "¿Mantener el mismo Rack/Manifiesto del original?";
            // 
            // cboPosition
            // 
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPosition.Enabled = false;
            cboPosition.Items.AddRange(new object[] { "No", "Sí" });
            cboPosition.Location = new Point(12, 191);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(49, 23);
            cboPosition.TabIndex = 3;
            // 
            // lblPosInfo
            // 
            lblPosInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPosInfo.ForeColor = Color.DarkRed;
            lblPosInfo.Location = new Point(67, 194);
            lblPosInfo.Name = "lblPosInfo";
            lblPosInfo.Size = new Size(603, 18);
            lblPosInfo.TabIndex = 6;
            lblPosInfo.Visible = false;
            // 
            // lblSobrantesInfo
            // 
            lblSobrantesInfo.AutoSize = true;
            lblSobrantesInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblSobrantesInfo.ForeColor = Color.Gray;
            lblSobrantesInfo.Location = new Point(237, 64);
            lblSobrantesInfo.Name = "lblSobrantesInfo";
            lblSobrantesInfo.Size = new Size(59, 13);
            lblSobrantesInfo.TabIndex = 2;
            lblSobrantesInfo.Text = "(calculado)";
            // 
            // lblTipoTxt
            // 
            lblTipoTxt.AutoSize = true;
            lblTipoTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoTxt.Location = new Point(12, 95);
            lblTipoTxt.Name = "lblTipoTxt";
            lblTipoTxt.Size = new Size(99, 15);
            lblTipoTxt.TabIndex = 3;
            lblTipoTxt.Text = "Tipo de reestiba:";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Location = new Point(12, 114);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(174, 23);
            cboTipo.TabIndex = 2;
            cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDescripcion.ForeColor = Color.Gray;
            lblDescripcion.Location = new Point(6, 140);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(658, 32);
            lblDescripcion.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(0, 120, 215);
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(12, 321);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(90, 28);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(108, 321);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 28);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmReestibaPallet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 361);
            Controls.Add(grpInfoPallet);
            Controls.Add(grpReestiba);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmReestibaPallet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reestibar Pallet";
            Load += FrmReestibaPallet_Load;
            grpReestiba.ResumeLayout(false);
            grpReestiba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCajas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox      grpInfoPallet;
        private GroupBox      grpReestiba;
        private Label         lblCajasNueva;
        private NumericUpDown numCajas;
        private Label         lblSobrantesTxt;
        private TextBox       txbCajasSobrantes;
        private Label         lblSobrantesInfo;
        private Label         lblTipoTxt;
        private ComboBox      cboTipo;
        private Label         lblPositionTxt;
        private ComboBox      cboPosition;
        private Label         lblPosInfo;
        private Label         lblDescripcion;
        private Button        btnConfirmar;
        private Button        btnCancelar;
    }
}

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
            lblPalletTxt = new Label();
            lblPalletVal = new Label();
            lblCajasTxt = new Label();
            lblCajasActVal = new Label();
            lblProgramaTxt = new Label();
            lblProgramaVal = new Label();
            lblEstibaTxt = new Label();
            lblEstibaVal = new Label();
            grpReestiba = new GroupBox();
            lblCajasNueva = new Label();
            numCajas = new NumericUpDown();
            lblSobrantesTxt = new Label();
            txbCajasSobrantes = new TextBox();
            lblSobrantesInfo = new Label();
            lblTipoTxt = new Label();
            cboTipo = new ComboBox();
            lblDescripcion = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            grpInfoPallet.SuspendLayout();
            grpReestiba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCajas).BeginInit();
            SuspendLayout();
            // 
            // grpInfoPallet
            // 
            grpInfoPallet.Controls.Add(lblPalletTxt);
            grpInfoPallet.Controls.Add(lblPalletVal);
            grpInfoPallet.Controls.Add(lblCajasTxt);
            grpInfoPallet.Controls.Add(lblCajasActVal);
            grpInfoPallet.Controls.Add(lblProgramaTxt);
            grpInfoPallet.Controls.Add(lblProgramaVal);
            grpInfoPallet.Controls.Add(lblEstibaTxt);
            grpInfoPallet.Controls.Add(lblEstibaVal);
            grpInfoPallet.Location = new Point(12, 10);
            grpInfoPallet.Name = "grpInfoPallet";
            grpInfoPallet.Size = new Size(370, 130);
            grpInfoPallet.TabIndex = 0;
            grpInfoPallet.TabStop = false;
            grpInfoPallet.Text = "Información del pallet";
            // 
            // lblPalletTxt
            // 
            lblPalletTxt.AutoSize = true;
            lblPalletTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPalletTxt.Location = new Point(12, 28);
            lblPalletTxt.Name = "lblPalletTxt";
            lblPalletTxt.Size = new Size(41, 15);
            lblPalletTxt.TabIndex = 0;
            lblPalletTxt.Text = "Pallet:";
            // 
            // lblPalletVal
            // 
            lblPalletVal.AutoSize = true;
            lblPalletVal.Location = new Point(110, 28);
            lblPalletVal.Name = "lblPalletVal";
            lblPalletVal.Size = new Size(19, 15);
            lblPalletVal.TabIndex = 1;
            lblPalletVal.Text = "—";
            // 
            // lblCajasTxt
            // 
            lblCajasTxt.AutoSize = true;
            lblCajasTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCajasTxt.Location = new Point(12, 56);
            lblCajasTxt.Name = "lblCajasTxt";
            lblCajasTxt.Size = new Size(85, 15);
            lblCajasTxt.TabIndex = 2;
            lblCajasTxt.Text = "Cajas actuales:";
            // 
            // lblCajasActVal
            // 
            lblCajasActVal.AutoSize = true;
            lblCajasActVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCajasActVal.ForeColor = Color.DarkBlue;
            lblCajasActVal.Location = new Point(110, 56);
            lblCajasActVal.Name = "lblCajasActVal";
            lblCajasActVal.Size = new Size(19, 15);
            lblCajasActVal.TabIndex = 3;
            lblCajasActVal.Text = "—";
            // 
            // lblProgramaTxt
            // 
            lblProgramaTxt.AutoSize = true;
            lblProgramaTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProgramaTxt.Location = new Point(12, 84);
            lblProgramaTxt.Name = "lblProgramaTxt";
            lblProgramaTxt.Size = new Size(104, 15);
            lblProgramaTxt.TabIndex = 4;
            lblProgramaTxt.Text = "Programa (GTIN):";
            // 
            // lblProgramaVal
            // 
            lblProgramaVal.AutoSize = true;
            lblProgramaVal.Location = new Point(110, 84);
            lblProgramaVal.Name = "lblProgramaVal";
            lblProgramaVal.Size = new Size(19, 15);
            lblProgramaVal.TabIndex = 5;
            lblProgramaVal.Text = "—";
            // 
            // lblEstibaTxt
            // 
            lblEstibaTxt.AutoSize = true;
            lblEstibaTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstibaTxt.Location = new Point(12, 110);
            lblEstibaTxt.Name = "lblEstibaTxt";
            lblEstibaTxt.Size = new Size(78, 15);
            lblEstibaTxt.TabIndex = 6;
            lblEstibaTxt.Text = "Estiba actual:";
            // 
            // lblEstibaVal
            // 
            lblEstibaVal.AutoSize = true;
            lblEstibaVal.Location = new Point(110, 110);
            lblEstibaVal.Name = "lblEstibaVal";
            lblEstibaVal.Size = new Size(19, 15);
            lblEstibaVal.TabIndex = 7;
            lblEstibaVal.Text = "—";
            // 
            // grpReestiba
            // 
            grpReestiba.Controls.Add(lblCajasNueva);
            grpReestiba.Controls.Add(numCajas);
            grpReestiba.Controls.Add(lblSobrantesTxt);
            grpReestiba.Controls.Add(txbCajasSobrantes);
            grpReestiba.Controls.Add(lblTipoTxt);
            grpReestiba.Controls.Add(cboTipo);
            grpReestiba.Controls.Add(lblDescripcion);
            grpReestiba.Controls.Add(lblSobrantesInfo);
            grpReestiba.Location = new Point(12, 150);
            grpReestiba.Name = "grpReestiba";
            grpReestiba.Size = new Size(370, 185);
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
            numCajas.Location = new Point(189, 25);
            numCajas.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numCajas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCajas.Name = "numCajas";
            numCajas.Size = new Size(43, 23);
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
            txbCajasSobrantes.Location = new Point(189, 59);
            txbCajasSobrantes.Name = "txbCajasSobrantes";
            txbCajasSobrantes.Size = new Size(43, 23);
            txbCajasSobrantes.TabIndex = 1;
            txbCajasSobrantes.TextAlign = HorizontalAlignment.Right;
            // 
            // lblSobrantesInfo
            // 
            lblSobrantesInfo.AutoSize = true;
            lblSobrantesInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblSobrantesInfo.ForeColor = Color.Gray;
            lblSobrantesInfo.Location = new Point(202, 66);
            lblSobrantesInfo.Name = "lblSobrantesInfo";
            lblSobrantesInfo.Size = new Size(92, 13);
            lblSobrantesInfo.TabIndex = 2;
            lblSobrantesInfo.Text = "           (calculado)";
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
            cboTipo.Size = new Size(340, 23);
            cboTipo.TabIndex = 2;
            cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDescripcion.ForeColor = Color.Gray;
            lblDescripcion.Location = new Point(12, 144);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(340, 32);
            lblDescripcion.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(0, 120, 215);
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(197, 348);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(90, 28);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(295, 348);
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
            ClientSize = new Size(394, 390);
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
            grpInfoPallet.ResumeLayout(false);
            grpInfoPallet.PerformLayout();
            grpReestiba.ResumeLayout(false);
            grpReestiba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCajas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox        grpInfoPallet;
        private Label           lblPalletTxt;
        private Label           lblPalletVal;
        private Label           lblCajasTxt;
        private Label           lblCajasActVal;
        private Label           lblProgramaTxt;
        private Label           lblProgramaVal;
        private Label           lblEstibaTxt;
        private Label           lblEstibaVal;
        private GroupBox        grpReestiba;
        private Label           lblCajasNueva;
        private NumericUpDown   numCajas;
        private Label           lblSobrantesTxt;
        private TextBox         txbCajasSobrantes;
        private Label           lblSobrantesInfo;
        private Label           lblTipoTxt;
        private ComboBox        cboTipo;
        private Label           lblDescripcion;
        private Button          btnConfirmar;
        private Button          btnCancelar;
    }
}

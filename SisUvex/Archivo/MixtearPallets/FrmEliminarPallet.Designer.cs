namespace SisUvex.Archivo.MixtearPallets
{
    partial class FrmEliminarPallet
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
            lblTipoTxt = new Label();
            cboTipo = new ComboBox();
            lblDescripcion = new Label();
            lblAdvertencia = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
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
            // lblTipoTxt
            // 
            lblTipoTxt.AutoSize = true;
            lblTipoTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoTxt.Location = new Point(12, 68);
            lblTipoTxt.Name = "lblTipoTxt";
            lblTipoTxt.Size = new Size(299, 15);
            lblTipoTxt.TabIndex = 1;
            lblTipoTxt.Text = "Eliminar como (opciones que dejan el pallet inactivo):";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Location = new Point(12, 88);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(186, 23);
            cboTipo.TabIndex = 2;
            cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDescripcion.ForeColor = Color.Gray;
            lblDescripcion.Location = new Point(12, 116);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(676, 28);
            lblDescripcion.TabIndex = 3;
            // 
            // lblAdvertencia
            // 
            lblAdvertencia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAdvertencia.ForeColor = Color.DarkOrange;
            lblAdvertencia.Location = new Point(12, 148);
            lblAdvertencia.Name = "lblAdvertencia";
            lblAdvertencia.Size = new Size(676, 18);
            lblAdvertencia.TabIndex = 4;
            lblAdvertencia.Text = "⚠  El pallet quedará INACTIVO permanentemente en la base de datos.";
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(192, 0, 0);
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(12, 169);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(90, 28);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Eliminar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(108, 169);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 28);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEliminarPallet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 207);
            Controls.Add(grpInfoPallet);
            Controls.Add(lblTipoTxt);
            Controls.Add(cboTipo);
            Controls.Add(lblDescripcion);
            Controls.Add(lblAdvertencia);
            Controls.Add(btnConfirmar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEliminarPallet";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Eliminar Pallet";
            Load += FrmEliminarPallet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpInfoPallet;
        private Label    lblTipoTxt;
        private ComboBox cboTipo;
        private Label    lblDescripcion;
        private Label    lblAdvertencia;
        private Button   btnConfirmar;
        private Button   btnCancelar;
    }
}

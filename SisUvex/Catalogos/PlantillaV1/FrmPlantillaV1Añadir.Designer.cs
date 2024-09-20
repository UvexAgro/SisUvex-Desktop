using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace SisUvex.Catalogos.PlantillaV1
{
    partial class FrmPlantillaV1Añadir
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
            lblLinea = new Label();
            txbId = new TextBox();
            lblId = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            btnTodoLinea = new Button();
            btnBuscarLinea = new Button();
            txbIdLinea = new TextBox();
            cboLinea = new ComboBox();
            lblObliContratista = new Label();
            lblObliId = new Label();
            cboActivo = new ComboBox();
            lblActivo = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Black", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(9, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(179, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir plantillaV1";
            // 
            // lblLinea
            // 
            lblLinea.AutoSize = true;
            lblLinea.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLinea.Location = new Point(9, 87);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(147, 21);
            lblLinea.TabIndex = 1;
            lblLinea.Text = "Línea de transporte:";
            // 
            // txbId
            // 
            txbId.Enabled = false;
            txbId.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbId.Location = new Point(572, 12);
            txbId.Name = "txbId";
            txbId.Size = new Size(46, 29);
            txbId.TabIndex = 5;
            txbId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(540, 15);
            lblId.Name = "lblId";
            lblId.Size = new Size(26, 21);
            lblId.TabIndex = 6;
            lblId.Text = "Id:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(543, 119);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(462, 119);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 29);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnTodoLinea
            // 
            btnTodoLinea.Location = new Point(561, 85);
            btnTodoLinea.Name = "btnTodoLinea";
            btnTodoLinea.Size = new Size(57, 29);
            btnTodoLinea.TabIndex = 32;
            btnTodoLinea.Text = "Activos";
            btnTodoLinea.UseVisualStyleBackColor = true;
            btnTodoLinea.Click += btnTodoLinea_Click;
            // 
            // btnBuscarLinea
            // 
            btnBuscarLinea.Location = new Point(498, 85);
            btnBuscarLinea.Name = "btnBuscarLinea";
            btnBuscarLinea.Size = new Size(57, 29);
            btnBuscarLinea.TabIndex = 31;
            btnBuscarLinea.Text = "Buscar";
            btnBuscarLinea.UseVisualStyleBackColor = true;
            btnBuscarLinea.Click += btnBuscarLinea_Click;
            // 
            // txbIdLinea
            // 
            txbIdLinea.Enabled = false;
            txbIdLinea.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbIdLinea.Location = new Point(162, 84);
            txbIdLinea.Name = "txbIdLinea";
            txbIdLinea.Size = new Size(46, 29);
            txbIdLinea.TabIndex = 34;
            txbIdLinea.TextAlign = HorizontalAlignment.Center;
            // 
            // cboLinea
            // 
            cboLinea.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboLinea.FormattingEnabled = true;
            cboLinea.ItemHeight = 21;
            cboLinea.Location = new Point(214, 84);
            cboLinea.Name = "cboLinea";
            cboLinea.Size = new Size(278, 29);
            cboLinea.TabIndex = 30;
            cboLinea.TextChanged += cboLinea_TextChanged;
            cboLinea.MouseClick += cboLinea_MouseClick;
            // 
            // lblObliContratista
            // 
            lblObliContratista.AutoSize = true;
            lblObliContratista.ForeColor = Color.Crimson;
            lblObliContratista.Location = new Point(95, 84);
            lblObliContratista.Name = "lblObliContratista";
            lblObliContratista.Size = new Size(12, 15);
            lblObliContratista.TabIndex = 35;
            lblObliContratista.Text = "*";
            // 
            // lblObliId
            // 
            lblObliId.AutoSize = true;
            lblObliId.ForeColor = Color.Crimson;
            lblObliId.Location = new Point(563, 12);
            lblObliId.Name = "lblObliId";
            lblObliId.Size = new Size(12, 15);
            lblObliId.TabIndex = 13;
            lblObliId.Text = "*";
            // 
            // cboActivo
            // 
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboActivo.FormattingEnabled = true;
            cboActivo.Items.AddRange(new object[] { "No", "Sí" });
            cboActivo.Location = new Point(488, 12);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(46, 29);
            cboActivo.TabIndex = 36;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblActivo.Location = new Point(426, 15);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(60, 21);
            lblActivo.TabIndex = 40;
            lblActivo.Text = "Activo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(418, 15);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 41;
            label2.Text = "*";
            // 
            // FrmPlantillaV1Añadir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 370);
            Controls.Add(lblActivo);
            Controls.Add(label2);
            Controls.Add(cboActivo);
            Controls.Add(lblLinea);
            Controls.Add(btnTodoLinea);
            Controls.Add(btnBuscarLinea);
            Controls.Add(txbIdLinea);
            Controls.Add(cboLinea);
            Controls.Add(lblObliContratista);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txbId);
            Controls.Add(lblTitulo);
            Controls.Add(lblId);
            Controls.Add(lblObliId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPlantillaV1Añadir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir plantillaV1";
            FormClosing += FrmPlantillaV1Añadir_FormClosing;
            Load += FrmPlantillaV1Añadir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblLinea;
        private Label lblId;
        private Button btnCancelar;
        private Button btnAceptar;
        public Label lblTitulo;
        public TextBox txbId;
        private Button btnTodoLinea;
        private Button btnBuscarLinea;
        public TextBox txbIdLinea;
        private ComboBox cboLinea;
        private Label lblObliContratista;
        private Label lblObliId;
        public ComboBox cboActivo;
        private Label lblActivo;
        private Label label2;
    }
}
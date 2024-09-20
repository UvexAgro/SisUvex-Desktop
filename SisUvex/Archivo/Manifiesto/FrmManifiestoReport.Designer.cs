namespace SisUvex.Archivo.Manifiesto
{
    partial class FrmManifiestoReport
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
            rptManifiesto = new Microsoft.Reporting.WinForms.ReportViewer();
            tableAdapterManager1 = new PalletsManifiestoTableAdapters.TableAdapterManager();
            SuspendLayout();
            // 
            // rptManifiesto
            // 
            rptManifiesto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rptManifiesto.Location = new Point(0, 0);
            rptManifiesto.Name = "ReportViewer";
            rptManifiesto.ServerReport.BearerToken = null;
            rptManifiesto.Size = new Size(786, 459);
            rptManifiesto.TabIndex = 0;
            // 
            // tableAdapterManager1
            // 
            tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            tableAdapterManager1.Connection = null;
            tableAdapterManager1.UpdateOrder = PalletsManifiestoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FrmManifiestoReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 479);
            Controls.Add(rptManifiesto);
            Name = "FrmManifiestoReport";
            Text = "FrmManifiestoReport";
            Load += FrmManifiestoReport_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptManifiesto;
        private PalletsManifiestoTableAdapters.TableAdapterManager tableAdapterManager1;
    }
}
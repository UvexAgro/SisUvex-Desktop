using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto.PrintManifest
{
    internal partial class FrmPrintManifest : Form
    {
        public ClsPrintManifest? cls = null;
        public FrmPrintManifest(string idManifest, string? idTemplate)
        {
            InitForm(idManifest, idTemplate);
        }
        public FrmPrintManifest(string idManifest)
        {
            InitForm(idManifest, null);
        }

        public void InitForm(string idManifest, string? idTemplate)
        {
            cls ??= new();
            cls.frm ??= this;

            cls.SetManifest(idManifest);
            cls.SetIdTemplate(idTemplate);

            InitializeComponent();
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnPrintDocuments(txbId.Text);
        }

        private void FrmPrintManifest_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }

        private void btnChangePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Seleccione la carpeta de destino para los manifiestos finales";
            folderBrowserDialog.ShowDialog();
            cls.finalManifestsFolderPath = folderBrowserDialog.SelectedPath;
            txbManifestFolderPath.Text = cls.finalManifestsFolderPath;
        }

        private void tglManifest_CheckedChanged(object sender, EventArgs e)
        {
            if (tglManifest.Checked)
                tglManifestPerFarm.Checked = false;
        }

        private void tglManifestPerFarm_CheckedChanged(object sender, EventArgs e)
        {
            if (tglManifestPerFarm.Checked)
                tglManifest.Checked = false;
        }
    }
}

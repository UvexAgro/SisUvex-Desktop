using DocumentFormat.OpenXml.Drawing;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.WorkGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto
{
    internal partial class FrmManifestAdd : Form
    {
        public ClsManifest cls;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmManifestAdd()
        {
            InitializeComponent();

            cls ??= new ClsManifest();
            cls._frmAdd ??= this;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void FrmManifestAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();

        }

        private void chbRemovedDistributor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPallet_Click(object sender, EventArgs e)
        {
            AddPalletToList();
        }

        private void btnRemovePallet_Click(object sender, EventArgs e)
        {
            cls.BtnRemovePallet();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddPalletToList();
                e.Handled = true;
            }
        }
        private void txbPalletPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddPalletToList();
                e.Handled = true;
            }
        }

        private void AddPalletToList()
        {
            if (int.TryParse(txbPalletPosition.Text, out int Position))

                if (txbIdPallet.Text.IsNullOrEmpty())
                    System.Media.SystemSounds.Hand.Play();
                else
                    cls.BtnAddPallet();
        }

        private void btnMovePalletUp_Click(object sender, EventArgs e)
        {
            cls.BtnMovePalletUp();
        }

        private void btnMovePalletDown_Click(object sender, EventArgs e)
        {
            cls.BtnMovePalletDown();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintManifest_Click(object sender, EventArgs e)
        {
            if (txbId.Text != "")
            {
                //ClsPDFManifiesto pdf = new ClsPDFManifiesto();
                ClsPruebaManifiesto pdf = new ClsPruebaManifiesto();
                pdf.CreatePDFManifest(txbId.Text);
                ClsPDFLoadingMap pdfMap = new ClsPDFLoadingMap();
                pdfMap.CreatePDFMaping(txbId.Text);
            }
            else
            {
                MessageBox.Show("Debe guardar el manifiesto antes de imprimirlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbDieselLiters_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

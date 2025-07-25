﻿using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Archivo.Manifiesto.ManifestTemplates;
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
    public partial class FrmManifestCat : Form
    {
        ClsManifest cls;

        public FrmManifestCat()
        {
            InitializeComponent();

            cls ??= new ClsManifest();
            cls._frmCat ??= this;
        }

        private void FrmManifestCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            cls.SetDgvCatalog();
        }

        private void btnSearchManifest_Click(object sender, EventArgs e)
        {
            cls.btnSearchManifest(txbIdManifest.Text);
        }
        private void btnRemoved_Click(object sender, EventArgs e)
        {
            cls.btnShowRemoved();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.btnRemoveProcedure();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.btnRecoverProcedure();
        }


        private void txbIdManifest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cls.btnSearchManifest(txbIdManifest.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void btnConfigManifest_Click(object sender, EventArgs e)
        {
            FrmConfManifest frm = new FrmConfManifest();
            frm.ShowDialog();
        }

        private void btnTemplates_Click(object sender, EventArgs e)
        {
            FrmManifestTemplatesCat frm = new FrmManifestTemplatesCat();
            frm.MdiParent = this.MdiParent; // Set the MdiParent to the parent of the current form
            frm.Show();
        }

        private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void btnPrintManifest_Click(object sender, EventArgs e)
        {
            cls.BtnPrintManifestFrmCat();
        }
    }
}
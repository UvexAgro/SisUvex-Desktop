﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Material.MaterialProvider
{
    internal partial class FrmMaterialProviderCat : Form
    {
        public ClsMaterialProvider cls;
        public FrmMaterialProviderCat()
        {
            InitializeComponent();
        }

        private void FrmMaterialProviderCat_Load(object sender, EventArgs e)
        {
            cls ??= new ClsMaterialProvider();
            cls._frmCat ??= this;

            cls.BeginFormCat();
        }
        private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count != 0)
            {
                //metodo para abrir el formulario de modificar

                //dgv.UpdateCatalogAfterAddModify(_frmAdd.AddIsUpdate);
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count != 0)
            {
                cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString(), "0");
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count != 0)
            {
                cls.BtnActiveProcedure(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString(), "1");
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedProcedure();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();

            if (cls.IsAddUpdate)
            {
                cls.CloseFrmAddModify();

                cls.AddNewRowByIdInDGVCatalog();
            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();

            if (cls.IsAddUpdate)
            {
                cls.CloseFrmAddModify();

                cls.AddNewRowByIdInDGVCatalog();
            }
        }
    }
}
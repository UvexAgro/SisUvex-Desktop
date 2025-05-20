using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods;

namespace SisUvex.Material.MaterialRegister.Exit
{
    internal partial class FrmMaterialRegisterExitCat : Form
    {
        public ClsMaterialRegisterExit cls;
        public FrmMaterialRegisterExitCat()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterExitCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;
            cls.BeginFormCat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();

            //if (cls.IsAddUpdate)
            //    cls.AddNewRowByIdInDGVCatalog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            OpenFrmModifyFromCat();
        }

        private void OpenFrmModifyFromCat()
        {
            //if (dgvCatalog.SelectedRows.Count == 0)
            //{
            //    SystemSounds.Exclamation.Play();
            //    return;
            //}
            //cls.OpenFrmModify(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString());

            //if (cls.IsModifyUpdate)
            //    cls.ModifyRowByIdInDGVCatalog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //if (dgvCatalog.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = dgvCatalog.SelectedRows[0];

            //    cls.BtnDeleteSelectedRowFromDGV(selectedRow);
            //}
            //else
            //    SystemSounds.Exclamation.Play();
        }

        private void btnSearchFilters_Click(object sender, EventArgs e)
        {
            cls.BtnSearchFilter();
        }

        private void btnSearchBy_Click(object sender, EventArgs e)
        {
            cls.BtnSearchBy(txbSearchBy.Text);
        }

        private void btnFreightContainerSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("FreightContainer", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboFreightContainer, sel.SelectedValue);
            }
        }

        private void btnTransportLineSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("TransportLine", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboTransportLine, sel.SelectedValue);
            }
        }
    }
}

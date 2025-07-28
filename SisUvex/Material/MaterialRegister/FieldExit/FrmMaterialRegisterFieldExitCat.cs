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
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Material.MaterialRegister.FieldExit
{
    internal partial class FrmMaterialRegisterFieldExitCat : Form
    {
        public ClsMaterialRegisterFieldExit cls;
        public FrmMaterialRegisterFieldExitCat()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterFieldExitCat_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmCat ??= this;
            cls.BeginFormCat();
        }

        private void btnSearchFilters_Click(object sender, EventArgs e)
        {
            cls.BtnSearchFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();

            if (cls.IsAddUpdate)
                cls.AddNewRowByIdInDGVCatalog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            OpenFrmModifyFromCat();
        }
        private void dgvCatalog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenFrmModifyFromCat();
        }

        private void OpenFrmModifyFromCat()
        {
            if (dgvCatalog.SelectedRows.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                return;
            }
            cls.OpenFrmModify(dgvCatalog.Rows[dgvCatalog.SelectedRows[0].Index].Cells[ClsObject.Column.id].Value.ToString());

            if (cls.IsModifyUpdate)
                cls.ModifyRowByIdInDGVCatalog();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCatalog.SelectedRows[0];

                cls.BtnDeleteSelectedRowFromDGVCatalog(selectedRow);
            }
            else
                SystemSounds.Exclamation.Play();
        }

        private void btnSearchBy_Click(object sender, EventArgs e)
        {
            cls.BtnSearchBy(txbSearchBy.Text);
        }

        private void btnLotSearch_Click(object sender, EventArgs e)
        {
            cls.BtnLotCatalogSearch(cboVariety, cboLot);
        }

        private void btnVarietySearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("Variety", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboVariety, sel.SelectedValue);
            }
        }

        private void btnVehicleSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("Vehicle", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboVehicle, sel.SelectedValue);
            }
        }
    }
}

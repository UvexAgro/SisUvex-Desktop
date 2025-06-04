using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Material.MaterialRegister.FieldExit
{
    internal partial class FrmMaterialRegisterFieldExit : Form
    {
        public ClsMaterialRegisterFieldExit cls;
        public FrmMaterialRegisterFieldExit()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterFieldExit_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }

        private void btnMaterialSearch_Click(object sender, EventArgs e)
        {
            cls.BtnMaterialCatalogSearch(cboMaterialType, cboMaterial);
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            cls.BtnAddRowMaterialsInExit();
        }

        private void btnModifyMaterial_Click(object sender, EventArgs e)
        {
            cls.BtnModifyRowMaterialsSelected();
        }

        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            cls.BtnRemoveRowMaterialsInExit();
        }

        private void btnMaterialTypeSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("MaterialType", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboMaterialType, sel.SelectedValue);
            }
        }

        private void btnMaterialAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddMaterialCatalog();
        }

        private void btnWarehouseSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("WareHouses", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboWarehouse, sel.SelectedValue);
            }
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            cls.btnSearchEmployee();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cls.CloseFrmAddModify();
        }

        private void txbIdVehicleType_TextChanged(object sender, EventArgs e)
        {

        }

        private void chbImageFront_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageFront);
        }

        private void chbImageBack_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageBack);
        }

        private void chbImageDown_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageDown);
        }

        private void chbImageUp_Click(object sender, EventArgs e)
        {
            cls.ChbImagesClic(chbImageUp);
        }

        private void btnSearchDistributor_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("Distributor", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboDistributor, sel.SelectedValue);
            }
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

        private void btnLotSearch_Click(object sender, EventArgs e)
        {
            cls.BtnLotCatalogSearch(cboVariety, cboLot);
        }

        private void btnVehicleTypeSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("VehicleType", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboVehicleType, sel.SelectedValue);
            }
        }

        private void btnVehicleSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("Vehicle", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                DataTable? dtSearch = cboVehicle.DataSource as DataTable;

                string idVehicleType = dtSearch.GetValue(ClsObject.VehicleType.ColumnId, ClsObject.Column.id, sel.SelectedValue)?.ToString() ?? string.Empty;

                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboVehicleType, idVehicleType);

                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboVehicle, sel.SelectedValue);
            }
        }

        private void btnVehicleAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddVehicle();
        }
    }
}

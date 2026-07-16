using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Material.MaterialCatalog;

namespace SisUvex.Material.MaterialRegister.Entry
{
    internal partial class FrmMaterialRegisterEntry : Form
    {
        public ClsMaterialRegisterEntry cls;
        public FrmMaterialRegisterEntry()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterEntry_Load(object sender, EventArgs e)
        {
            cls ??= new ClsMaterialRegisterEntry();
            cls._frmAdd ??= this;

            cls.BeginFormAdd();
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            cls.btnSearchEmployee();
        }

        private void btnMaterialSearch_Click(object sender, EventArgs e)
        {
            cls.BtnMaterialCatalogSearch(cboMaterialType, cboMaterial);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            cls.BtnAddRowMaterialsInEntry();
        }

        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            cls.BtnRemoveRowMaterialsInEntry();
        }

        private void btnModifyMaterial_Click(object sender, EventArgs e)
        {
            cls.BtnModifyRowMaterialsSelected();
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

        private void btnMaterialAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddMaterialCatalog();
        }

        private void btnProviderAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddMaterialProvider();
        }

        private void btnTransportLineAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddTransportLine();
        }

        private void btnDriverAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddDriver();
        }
        private void btnFreightContainerAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddFreighContainer();
        }

        private void btnTransportLineSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("TransportLine", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboTransportLine, sel.SelectedValue);
            }
        }

        private void btnDriverSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("Driver", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboDriver, sel.SelectedValue);
            }
        }

        private void btnFreightContainerSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("FreightContainer", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboFreightContainer, sel.SelectedValue);
            }
        }

        private void btnProviderSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("MaterialProvider", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboProvider, sel.SelectedValue);
            }
        }

        private void btnSearchDistributor_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("Distributor", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboDistributor, sel.SelectedValue);
            }
        }

        private void btnGrowerSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("Grower", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboGrower, sel.SelectedValue);
            }
        }

        private void btnWarehouseSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("WareHouses", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboWarehouse, sel.SelectedValue);
            }
        }

        private void btnMaterialTypeSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new();

            sel.OpenSelectionForm("MaterialType", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboMaterialType, sel.SelectedValue);
            }
        }

    }
}
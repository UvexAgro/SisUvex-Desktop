using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;

namespace SisUvex.Material.MaterialRegister.Exit
{
    internal partial class FrmMaterialRegisterExit : Form
    {
        public ClsMaterialRegisterExit cls;
        public FrmMaterialRegisterExit()
        {
            InitializeComponent();
        }

        private void FrmMaterialRegisterExit_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }

        private void btnWarehouseSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("WareHouses", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboWarehouse, sel.SelectedValue);
            }
        }
        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            cls.btnSearchEmployee();
        }

        private void btnForeignDest_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();
            sel.OpenSelectionForm("ForeignDest", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboForeignDest, sel.SelectedValue);
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
        private void btnDriverSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("Driver", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboDriver, sel.SelectedValue);
            }
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

        private void btnMaterialTypeSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnMaterialSearch_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();
            sel.OpenSelectionForm("MaterialCatalog", "Código");

            if (!string.IsNullOrEmpty(sel.SelectedValue))
            {

                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboMaterialType, sel.SelectedValue.Substring(0, 2));
                ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboMaterial, sel.SelectedValue);
            }
            else
                cboMaterialType.SelectedIndex = 0;
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

        private void btnMaterialAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddMaterialCatalog();
        }
        private void btnForeignDestAdd_Click(object sender, EventArgs e)
        {
            cls.BtnAddForeignDest();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}
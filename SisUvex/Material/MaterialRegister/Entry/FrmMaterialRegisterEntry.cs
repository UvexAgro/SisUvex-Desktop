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
    }
}
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.WorkPlan
{
    internal partial class FrmWorkPlanCat : Form
    {
        ClsWorkPlan cls;
        public FrmWorkPlanCat(ClsWorkPlan clsClass)
        {
            InitializeComponent();
            cls = clsClass;
        }

        private void FrmWorkPlanCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cls.RemoveProcedure();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            cls.RecoverProcedure();
        }

        private void dgvCatalog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.BtnSearch();
        }

        public void chbRemoved_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbRemovedChecked();
        }
    }
}

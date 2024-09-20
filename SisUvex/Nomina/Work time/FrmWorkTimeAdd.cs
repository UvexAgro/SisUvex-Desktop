using SisUvex.Catalogos.GTIN;
using SisUvex.Catalogos.GTIN_UPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Work_time
{
    internal partial class FrmWorkTimeAdd : Form
    {
        ClsWorkTime cls;
        FrmWorkTimeCat frmCat;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmWorkTimeAdd(FrmWorkTimeCat frmCatalog, ClsWorkTime clsClass)
        {
            InitializeComponent();
            cls = clsClass;
            frmCat = frmCatalog;
        }

        private void FrmWorkTimeAdd_Load(object sender, EventArgs e)
        {
            dtpBeginNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndNormal.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpEndExtra.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            cls.BeginFormAdd();
        }

        private void btnAcept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
            if (AddIsUpdate)
                cls.LoadDgvCatalog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dtpDay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDay.Value > dtpBeginNormal.Value)
            {
                dtpBeginNormal.Value = dtpDay.Value;
            }
            dtpBeginNormal.MinDate = dtpDay.Value;
        }
        private void dtpBeginNormal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBeginNormal.Value > dtpEndNormal.Value)
            {
                dtpEndNormal.Value = dtpBeginNormal.Value;
            }
            dtpEndNormal.MinDate = dtpBeginNormal.Value;

        }
        private void dtpEndNormal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndNormal.Value > dtpEndExtra.Value)
            {
                dtpEndExtra.Value = dtpEndNormal.Value;
            }
            dtpEndExtra.MinDate = dtpEndNormal.Value;

        }
        private void dtpEndExtra_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}

using SisUvex.Catalogos.GTIN;
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
    internal partial class FrmWorkTimeCat : Form
    {
        ClsWorkTime cls;

        public FrmWorkTimeCat(ClsWorkTime clsClass)
        {
            InitializeComponent();
            cls = (clsClass);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cls.OpenFrmAdd();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void FrmWorkTimeCat_Load(object sender, EventArgs e)
        {
            cls.BeginFormCat();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.LoadDgvCatalog();
        }

        private void dgvCatalog_DoubleClick(object sender, EventArgs e)
        {
            cls.OpenFrmModify();
        }

        private void btnReportField_Click(object sender, EventArgs e)
        {
            cls.OpenFrmReport(1); //1 PARA REPORTE EN PRECIOS DE CAMPO
        }

        private void btnReportFacility_Click(object sender, EventArgs e)
        {
            cls.OpenFrmReport(2); //2 PARA REPORTE CON PRECIOS DE EMPAQUE
        }
    }
}

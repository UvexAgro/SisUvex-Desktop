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

namespace SisUvex.Nomina.Poda.Reporte_lineas
{
    public partial class FrmPayrollPruningReport : Form
    {
        ClsPayrollPruningReport cls;
        public FrmPayrollPruningReport()
        {
            InitializeComponent();
        }

        private void FrmPayrollPruningReport_Load(object sender, EventArgs e)
        {
            cls = new();
            cls.frm = this;
            cls.BeginFormCat();

            dtpDate1.Value = Convert.ToDateTime("2025-12-12"); //TEMPORAL PARA PRUEBAS
            cboWorkGroup.SelectedIndex = 4;
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(cboLot, "1050");
            //cboLot.SelectedIndex = ;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            cls.GenerateExcelReportWithPivot();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //cls.GenerateExcelReportWithoutPivot();   ///
            cls.GenerateExcelReportFlat();
        }
    }
}

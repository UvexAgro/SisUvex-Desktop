using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Comedores.DiningReports
{
    public partial class FrmDiningReport : Form
    {
        ClsDiningReports cls;
        public FrmDiningReport()
        {
            InitializeComponent();
        }

        private void FrmDiningReport_Load(object sender, EventArgs e)
        {
            cls = new ClsDiningReports();
            cls.frm = this;
            cls.LoadForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.SetDGVReportBeetweenDays();

            cls.SetDGVResume();

            if (!AreReportsTablesNull())
                dgvQuery.DataSource = cls.dtReport1;
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            cls.BtnSearchEmployee();
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            if (!AreReportsTablesNull())
                dgvQuery.DataSource = cls.dtReport1;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (!AreReportsTablesNull())
                dgvQuery.DataSource = cls.dtResume1;
        }

        private void txbIdEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls.BtnSearchEmployee();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!AreReportsTablesNull())
            cls.ExportDataGridViewExcel(dgvQuery);
        }

        private bool AreReportsTablesNull()
        {
            if (cls.dtReport1 == null || cls.dtResume1 == null)
            {
                System.Media.SystemSounds.Hand.Play();
                return true;
            }
            else
                return false;
        }
    }
}

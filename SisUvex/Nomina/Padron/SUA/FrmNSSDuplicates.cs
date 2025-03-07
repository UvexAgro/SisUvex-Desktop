using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Padron.SUA
{
    public partial class FrmNSSDuplicates : Form
    {
        public DataTable? dtNSSDuplicatesEmployees;
        public bool isDataValidated = false;
        public FrmNSSDuplicates()
        {
            InitializeComponent();
        }

        private void FrmNSSDuplicates_Load(object sender, EventArgs e)
        {
            if (dtNSSDuplicatesEmployees != null)
            {
                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                chkColumn.HeaderText = "Sel.";
                chkColumn.Name = "Sel.";
                chkColumn.FalseValue = false;
                chkColumn.TrueValue = true;
                chkColumn.Width = 50;
                dgvDuplicatesEmployees.Columns.Insert(0, chkColumn);

                dgvDuplicatesEmployees.DataSource = dtNSSDuplicatesEmployees;
            }
            else
            {
                isDataValidated = true;

                this.Close();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvDuplicatesEmployees.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["Sel."].Value) == true)
                .ToList();

            var nssValues = selectedRows
                .Select(row => Convert.ToInt64(row.Cells["NSS"].Value))
                .ToList();

            var duplicates = nssValues
                .GroupBy(nss => nss)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();

            if (duplicates.Any())
            {
                MessageBox.Show("Solo debe haber un emplempleado seleccionado por NSS.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                isDataValidated = true;
                this.Close();
            }
        }
    }
}

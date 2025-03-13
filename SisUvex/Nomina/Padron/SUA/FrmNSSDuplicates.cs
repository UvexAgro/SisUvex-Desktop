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
        public DataTable? dtEmployeesInput;
        private DataTable? dtNSSDuplicatesEmployees;
        public bool isDataValidated = false;
        public FrmNSSDuplicates()
        {
            InitializeComponent();
        }

        private void FrmNSSDuplicates_Load(object sender, EventArgs e)
        {
            if (dtEmployeesInput != null)
                dtNSSDuplicatesEmployees = FilterNSSDuplicatesRows(dtEmployeesInput);

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
            else //EN CASO DE QUE HABRA SIN DATOS
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
                List<string> uncheckedEmployeesCodes = GetUncheckedEmployeesCodes();

                RemoveListEmployeesFromInput(uncheckedEmployeesCodes);

                isDataValidated = true;

                this.Close();
            }
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            List<string> allEmployeesCodes = GetAllEmployeesCodes();

            RemoveListEmployeesFromInput(allEmployeesCodes);

            isDataValidated = true;

            this.Close();
        }

        private List<string> GetAllEmployeesCodes()
        {
            var allRows = dgvDuplicatesEmployees.Rows
                .Cast<DataGridViewRow>()
                .ToList();

            var employeeCodes = allRows
                .Select(row => row.Cells["Código"].Value.ToString())
                .ToList();

            return employeeCodes;
        }

        public DataTable FilterNSSDuplicatesRows(DataTable dtEmployees)
        {
            DataTable duplicatesRowsTable = dtEmployees.Clone(); // Clona la estructura del DataTable original

            foreach (DataRow row in dtEmployees.Rows)
            {
                if (int.TryParse(row["Repeticiones"].ToString(), out int repetidos) && repetidos > 1)
                {
                    duplicatesRowsTable.ImportRow(row);
                }
            }

            return duplicatesRowsTable;
        }

        private List<string> GetUncheckedEmployeesCodes()
        {
            var uncheckedRows = dgvDuplicatesEmployees.Rows
                .Cast<DataGridViewRow>()
                .Where(row => Convert.ToBoolean(row.Cells["Sel."].Value) == false)
                .ToList();

            var employeeCodes = uncheckedRows
                .Select(row => row.Cells["Código"].Value.ToString())
                .ToList();

            return employeeCodes;
        }

        private void RemoveListEmployeesFromInput(List<string> uncheckedEmployeesCodes)
        {
            if (dtEmployeesInput != null)
            {
                foreach (var code in uncheckedEmployeesCodes)
                {
                    var rowsToDelete = dtEmployeesInput.AsEnumerable()
                        .Where(row => row.Field<string>("Código") == code)
                        .ToList();

                    foreach (var row in rowsToDelete)
                    {
                        dtEmployeesInput.Rows.Remove(row);
                    }
                }
            }
        }
    }
}

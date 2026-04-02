using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    public partial class FrmPrintManifestPallets : Form
    {
        ClsPrintManifestPalletsList cls = new ClsPrintManifestPalletsList();
        private bool isHeaderCheckBoxClicked = false;
        private DataTable dtGridData = null;

        public FrmPrintManifestPallets()
        {
            InitializeComponent();
        }

        private void FrmPrintManifestPallets_Load(object sender, EventArgs e)
        {
            cboNumPallet.SelectedIndex = 0;
            cboPrinters.SelectedIndex = 0;
        }

        private void btnManifestAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateIdManifest())
                return;

            AddRowsFromManifest(txbIdManifest.Text);
            txbIdManifest.Clear();
            txbIdManifest.Focus();
        }

        private void btnPalletAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbIdPallet.Text))
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Ingresa el ID del pallet.", "Agregar Pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddRowsFromPallet(txbIdPallet.Text);
            txbIdPallet.Clear();
            txbIdPallet.Focus();
        }

        private void btnStowAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbIdStow.Text))
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Ingresa el ID del Stow.", "Agregar Stow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddRowsFromStow(txbIdStow.Text);
            txbIdStow.Clear();
            txbIdStow.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgvPallets.Rows.Count == 0)
                return;

            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas limpiar todas las filas?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dgvPallets.Rows.Clear();
                dgvPallets.Columns.Clear();
                dtGridData = null;
            }
        }

        private void AddRowsFromManifest(string idManifest)
        {
            DataTable dtData = cls.GetDTManifestPallets(idManifest);
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron pallets para el manifiesto especificado.", "Agregar Manifiesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            InitializeDataGridViewIfEmpty(dtData);
            AddRowsToDataGridView(dtData);
        }

        private void AddRowsFromPallet(string idPallet)
        {
            DataTable dtData = cls.GetDTPalletInfo(idPallet);
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró información para el pallet especificado.", "Agregar Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            InitializeDataGridViewIfEmpty(dtData);
            AddRowsToDataGridView(dtData);
        }

        private void AddRowsFromStow(string idStow)
        {
            DataTable dtData = cls.GetDTStowInfo(idStow);
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró información para el Stow especificado.", "Agregar Stow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            InitializeDataGridViewIfEmpty(dtData);
            AddRowsToDataGridView(dtData);
        }

        private void InitializeDataGridViewIfEmpty(DataTable dtData)
        {
            if (dgvPallets.Columns.Count == 0)
            {
                dtGridData = dtData.Clone();

                foreach (DataGridViewColumn col in dgvPallets.Columns)
                {
                    col.ReadOnly = col.Name == "Sel" ? false : true;
                }

                CreateColumnsFromDataTable(dtData);
                ConvertSelColumnToCheckbox();
                AddHeaderCheckbox();
            }
        }

        private void CreateColumnsFromDataTable(DataTable dtData)
        {
            dgvPallets.Columns.Clear();

            foreach (DataColumn column in dtData.Columns)
            {
                if (column.ColumnName == "Sel")
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = "Sel",
                        HeaderText = "Sel",
                        Width = 50,
                        FalseValue = 0,
                        TrueValue = 1
                    };
                    dgvPallets.Columns.Add(checkBoxColumn);
                }
                else
                {
                    DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn
                    {
                        Name = column.ColumnName,
                        HeaderText = column.ColumnName,
                        DataPropertyName = column.ColumnName,
                        ReadOnly = true
                    };
                    dgvPallets.Columns.Add(textColumn);
                }
            }
        }

        private void AddRowsToDataGridView(DataTable dtData)
        {
            foreach (DataRow row in dtData.Rows)
            {
                int newRowIndex = dgvPallets.Rows.Add();
                DataGridViewRow dgvRow = dgvPallets.Rows[newRowIndex];

                for (int i = 0; i < dgvRow.Cells.Count; i++)
                {
                    string columnName = dgvPallets.Columns[i].Name;

                    if (columnName == "Sel")
                    {
                        dgvRow.Cells[i].Value = true;
                    }
                    else if (row.Table.Columns.Contains(columnName))
                    {
                        dgvRow.Cells[i].Value = row[columnName] ?? "";
                    }
                }

                if (dtGridData != null)
                {
                    DataRow newDtRow = dtGridData.NewRow();
                    for (int i = 0; i < dtGridData.Columns.Count; i++)
                    {
                        if (row.Table.Columns.Contains(dtGridData.Columns[i].ColumnName))
                        {
                            newDtRow[i] = row[dtGridData.Columns[i].ColumnName] ?? DBNull.Value;
                        }
                    }
                    dtGridData.Rows.Add(newDtRow);
                }
            }
        }

        private void ConvertSelColumnToCheckbox()
        {
            if (dgvPallets.Columns.Count == 0)
                return;

            DataGridViewColumn selColumn = dgvPallets.Columns["Sel"];
            if (selColumn == null)
                return;

            selColumn.ReadOnly = false;
        }

        private void AddHeaderCheckbox()
        {
            DataGridViewColumn selColumn = dgvPallets.Columns["Sel"];
            if (selColumn == null)
                return;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            selColumn.HeaderCell.Style = headerStyle;
        }

        private void dgvPallets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn column = dgvPallets.Columns[e.ColumnIndex];
                if (column.Name == "Sel")
                {
                    isHeaderCheckBoxClicked = true;
                    bool allChecked = true;

                    foreach (DataGridViewRow row in dgvPallets.Rows)
                    {
                        if (row.Cells[e.ColumnIndex].Value is bool isChecked && !isChecked)
                        {
                            allChecked = false;
                            break;
                        }
                    }

                    foreach (DataGridViewRow row in dgvPallets.Rows)
                    {
                        row.Cells[e.ColumnIndex].Value = !allChecked;
                    }

                    isHeaderCheckBoxClicked = false;
                }
            }
        }

        private bool ValidateIdManifest()
        {
            if (string.IsNullOrWhiteSpace(txbIdManifest.Text) || txbIdManifest.Text.Length != 5)
            {
                SystemSounds.Beep.Play();
                return false;
            }
            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            cls.SetManifestPalletsPerPositionList(dgvPallets);
        }
    }
}

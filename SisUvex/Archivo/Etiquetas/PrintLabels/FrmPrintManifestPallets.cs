using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    public partial class FrmPrintManifestPallets : Form
    {
        ClsPrintManifestPalletsList cls = new ClsPrintManifestPalletsList();
        private bool isHeaderCheckBoxClicked = false;
        private bool _updatingSelectAll = false;
        private DataTable? dtGridData = null;

        public FrmPrintManifestPallets()
        {
            InitializeComponent();
        }

        private void FrmPrintManifestPallets_Load(object sender, EventArgs e)
        {
            cboNumPallet.SelectedIndex = 0;
            cboPrinters.SelectedIndex = 0;
            chbSeleccionarTodo.Checked = true;
            nudCopiasEtiquetas.Value = 1;
        }

        private bool AllPalletsInEstiba => cboNumPallet.SelectedIndex == 1;

        private void btnManifestAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateIdManifest())
                return;

            AddRowsFromManifest(txbIdManifest.Text.Trim());
            txbIdManifest.Clear();
            txbIdManifest.Focus();
        }

        private void btnPalletAdd_Click(object sender, EventArgs e)
        {
            List<string> palletIds = ParsePalletIds(txbIdPallet.Text);
            if (palletIds.Count == 0)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Ingresa uno o más IDs de pallet (solo enteros).", "Agregar Pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int added = 0;
            foreach (string idPallet in palletIds)
                added += AddRowsFromPallet(idPallet) ? 1 : 0;

            if (added == 0 && palletIds.Count > 0)
                MessageBox.Show("No se encontró información para los pallets especificados.", "Agregar Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txbIdPallet.Clear();
            txbIdPallet.Focus();
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
            DataTable dtData = cls.GetDTManifestPallets(idManifest, onePalletPerEstiba: !AllPalletsInEstiba);
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron pallets para el manifiesto especificado.", "Agregar Manifiesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            InitializeDataGridViewIfEmpty(dtData);
            AddRowsToDataGridView(dtData);
            ApplySelectAllToGrid();
        }

        private bool AddRowsFromPallet(string idPallet)
        {
            string normalizedId = NormalizePalletId(idPallet);
            if (string.IsNullOrEmpty(normalizedId))
                return false;

            DataTable dtData = cls.GetDTPalletInfo(normalizedId, allPalletsInEstiba: AllPalletsInEstiba);
            if (dtData == null || dtData.Rows.Count == 0)
                return false;

            InitializeDataGridViewIfEmpty(dtData);
            AddRowsToDataGridView(dtData);
            ApplySelectAllToGrid();
            return true;
        }

        private void InitializeDataGridViewIfEmpty(DataTable dtData)
        {
            dtData = ClsPrintManifestPalletsList.EnsureSelectionColumn(dtData);

            if (dgvPallets.Columns.Count == 0)
            {
                dtGridData = dtData.Clone();
                CreateColumnsFromDataTable(dtData);
                ConvertSelColumnToCheckbox();
                AddHeaderCheckbox();
            }
        }

        private void CreateColumnsFromDataTable(DataTable dtData)
        {
            dgvPallets.Columns.Clear();

            HashSet<string> added = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string[] leadingColumns = { "Sel", "Manifiesto", "Posicion" };

            foreach (string columnName in leadingColumns)
            {
                if (!dtData.Columns.Contains(columnName))
                    continue;

                AddColumnFromDataTable(dtData.Columns[columnName]!);
                added.Add(columnName);
            }

            foreach (DataColumn column in dtData.Columns)
            {
                if (added.Contains(column.ColumnName))
                    continue;

                AddColumnFromDataTable(column);
            }

            ApplyColumnOrderAndFormats();
        }

        private void AddColumnFromDataTable(DataColumn column)
        {
            if (column.ColumnName == "Sel")
            {
                dgvPallets.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    Name = "Sel",
                    HeaderText = "Sel",
                    Width = 50,
                    FalseValue = false,
                    TrueValue = true,
                    ThreeState = false
                });
                return;
            }

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn
            {
                Name = column.ColumnName,
                HeaderText = column.ColumnName,
                DataPropertyName = column.ColumnName,
                ReadOnly = true
            };

            if (column.ColumnName.Equals("Fecha", StringComparison.OrdinalIgnoreCase))
                textColumn.DefaultCellStyle.Format = "dd/MM/yy";

            dgvPallets.Columns.Add(textColumn);
        }

        private void ApplyColumnOrderAndFormats()
        {
            int displayIndex = 0;

            SetColumnDisplayIndex("Sel", displayIndex++);
            SetColumnDisplayIndex("Manifiesto", displayIndex++);
            SetColumnDisplayIndex("Posicion", displayIndex++);

            foreach (DataGridViewColumn col in dgvPallets.Columns
                .Cast<DataGridViewColumn>()
                .OrderBy(c => c.Index))
            {
                if (col.Name is "Sel" or "Manifiesto" or "Posicion")
                    continue;

                col.DisplayIndex = displayIndex++;
            }

            if (dgvPallets.Columns["Fecha"] is DataGridViewColumn fechaCol)
                fechaCol.DefaultCellStyle.Format = "dd/MM/yy";
        }

        private void SetColumnDisplayIndex(string columnName, int displayIndex)
        {
            if (dgvPallets.Columns[columnName] is DataGridViewColumn col)
                col.DisplayIndex = displayIndex;
        }

        private void AddRowsToDataGridView(DataTable dtData)
        {
            HashSet<string> existingPallets = GetExistingPalletIds();

            foreach (DataRow row in dtData.Rows)
            {
                string? palletId = row.Table.Columns.Contains("Pallet")
                    ? row["Pallet"]?.ToString()?.Trim()
                    : null;

                if (!string.IsNullOrEmpty(palletId) && existingPallets.Contains(palletId))
                    continue;

                int newRowIndex = dgvPallets.Rows.Add();
                DataGridViewRow dgvRow = dgvPallets.Rows[newRowIndex];

                for (int i = 0; i < dgvRow.Cells.Count; i++)
                {
                    string columnName = dgvPallets.Columns[i].Name;

                    if (columnName == "Sel")
                        dgvRow.Cells[i].Value = chbSeleccionarTodo.Checked;
                    else if (columnName.Equals("Fecha", StringComparison.OrdinalIgnoreCase)
                             && row.Table.Columns.Contains(columnName))
                        dgvRow.Cells[i].Value = NormalizeFechaValue(row[columnName]);
                    else if (row.Table.Columns.Contains(columnName))
                        dgvRow.Cells[i].Value = row[columnName] ?? "";
                }

                if (!string.IsNullOrEmpty(palletId))
                    existingPallets.Add(palletId);

                if (dtGridData != null)
                {
                    DataRow newDtRow = dtGridData.NewRow();
                    foreach (DataColumn col in dtGridData.Columns)
                    {
                        if (row.Table.Columns.Contains(col.ColumnName))
                            newDtRow[col.ColumnName] = row[col.ColumnName] ?? DBNull.Value;
                    }
                    dtGridData.Rows.Add(newDtRow);
                }
            }
        }

        private HashSet<string> GetExistingPalletIds()
        {
            HashSet<string> ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (dgvPallets.Columns["Pallet"] == null)
                return ids;

            int colIndex = dgvPallets.Columns["Pallet"].Index;
            foreach (DataGridViewRow row in dgvPallets.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string? id = row.Cells[colIndex].Value?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(id))
                    ids.Add(id);
            }

            return ids;
        }

        private void ConvertSelColumnToCheckbox()
        {
            if (dgvPallets.Columns.Count == 0)
                return;

            DataGridViewColumn? selColumn = dgvPallets.Columns["Sel"];
            if (selColumn == null)
                return;

            selColumn.ReadOnly = false;
        }

        private void AddHeaderCheckbox()
        {
            DataGridViewColumn? selColumn = dgvPallets.Columns["Sel"];
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
                        if (row.IsNewRow)
                            continue;

                        if (!ClsPrintManifestPalletsList.IsCheckboxChecked(row.Cells[e.ColumnIndex].Value))
                        {
                            allChecked = false;
                            break;
                        }
                    }

                    foreach (DataGridViewRow row in dgvPallets.Rows)
                    {
                        if (!row.IsNewRow)
                            row.Cells[e.ColumnIndex].Value = !allChecked;
                    }

                    isHeaderCheckBoxClicked = false;
                    SyncSelectAllCheckbox();
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
            if (!cls.SetManifestPalletsPerPositionList(dgvPallets))
                return;

            bool printSmallCode = cboPrinters.SelectedIndex == 1;
            bool reverseOrientation = chbRevesePalletTag.Checked;
            bool showDate = !chbFechaOmitidaPallet.Checked;
            int copies = (int)nudCopiasEtiquetas.Value;

            cls.PrintManifestPalletsList(copies, reverseOrientation, showDate, printSmallCode: printSmallCode);
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txbIdPallet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                PastePalletIdsFromClipboard();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnPalletAdd_Click(sender, e);
            }
        }

        private void PastePalletIdsFromClipboard()
        {
            string? clipboardText = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(clipboardText))
                return;

            List<string> ids = ParsePalletIds(clipboardText);
            if (ids.Count == 0)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("El contenido pegado no contiene IDs de pallet válidos (solo enteros).", "Pegar pallets", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txbIdPallet.Text = string.Join(Environment.NewLine, ids);
        }

        private static List<string> ParsePalletIds(string text)
        {
            List<string> ids = new List<string>();
            if (string.IsNullOrWhiteSpace(text))
                return ids;

            string[] tokens = Regex.Split(text.Trim(), @"[\r\n\t,;]+");
            foreach (string token in tokens)
            {
                string trimmed = token.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                if (!int.TryParse(trimmed, NumberStyles.Integer, CultureInfo.InvariantCulture, out _))
                    continue;

                string normalized = NormalizePalletId(trimmed);
                if (!string.IsNullOrEmpty(normalized) && !ids.Contains(normalized, StringComparer.OrdinalIgnoreCase))
                    ids.Add(normalized);
            }

            return ids;
        }

        private static string NormalizePalletId(string text)
        {
            string t = text.Trim();
            if (t.Length == 0)
                return string.Empty;

            if (int.TryParse(t, NumberStyles.Integer, CultureInfo.InvariantCulture, out int n))
                return n.ToString("D5", CultureInfo.InvariantCulture);

            return t;
        }

        private static object NormalizeFechaValue(object? value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;

            if (value is DateTime dt)
                return dt.Date;

            if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime parsed)
                || DateTime.TryParse(value.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
                return parsed.Date;

            return value;
        }

        private void chbAjustarColumnas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAjustarColumnas.Checked)
                dgvPallets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            else
                dgvPallets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void chbSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (_updatingSelectAll)
                return;

            ApplySelectAllToGrid();
        }

        private void ApplySelectAllToGrid()
        {
            if (dgvPallets.Columns["Sel"] == null)
                return;

            int selIndex = dgvPallets.Columns["Sel"].Index;
            bool selectAll = chbSeleccionarTodo.Checked;

            _updatingSelectAll = true;
            foreach (DataGridViewRow row in dgvPallets.Rows)
            {
                if (!row.IsNewRow)
                    row.Cells[selIndex].Value = selectAll;
            }
            _updatingSelectAll = false;
        }

        private void dgvPallets_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvPallets.IsCurrentCellDirty
                && dgvPallets.CurrentCell is DataGridViewCheckBoxCell
                && dgvPallets.Columns[dgvPallets.CurrentCell.ColumnIndex].Name == "Sel")
            {
                dgvPallets.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvPallets_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (_updatingSelectAll || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvPallets.Columns[e.ColumnIndex].Name != "Sel")
                return;

            SyncSelectAllCheckbox();
        }

        private void SyncSelectAllCheckbox()
        {
            if (dgvPallets.Columns["Sel"] == null)
                return;

            int selIndex = dgvPallets.Columns["Sel"].Index;
            bool allChecked = true;
            bool anyRow = false;

            foreach (DataGridViewRow row in dgvPallets.Rows)
            {
                if (row.IsNewRow)
                    continue;

                anyRow = true;
                if (!ClsPrintManifestPalletsList.IsCheckboxChecked(row.Cells[selIndex].Value))
                {
                    allChecked = false;
                    break;
                }
            }

            _updatingSelectAll = true;
            chbSeleccionarTodo.Checked = anyRow && allChecked;
            _updatingSelectAll = false;
        }

        private void txbIdManifest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnManifestAdd_Click(sender, e);
            }
        }
    }
}

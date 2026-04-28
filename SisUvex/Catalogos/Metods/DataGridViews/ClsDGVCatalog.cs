using NPOI.SS.UserModel;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Catalogos.Metods.DataGridViews
{
    internal class ClsDGVCatalog
    {
        public string idColumn = ClsObject.Column.id;
        public string id2Column = "id2"; //PARA CUANDO TIENE 2 IDs COMPUESTAS
        public string activeColumn = ClsObject.Column.active;
        private string activeColumnHide = ClsObject.Column.active + "2";
        List<string?> lsHideColumns = new();
        //public string queryCatalog;
        public DataGridView dgvCatalog;
        public DataTable dtCatalog;
        //public Button btnRemoved;

        /// <summary>Configuración de búsqueda <c>OR + LIKE</c> sobre <see cref="dtCatalog"/> (instancia vinculada a este DGV de catálogo).</summary>
        public CatalogDataViewTextSearch TextSearch { get; }

        ///===== LAS COLUMNAS ACTIVE Y ACTIVE2, la 1 es el que muestra y jala el valor para cambiar el color a rojo y verde, el active2 es para mantener el valor y para seguir mostrando la fila por ejemplo: si está mostrando solo "activos" pero la fila seleccionada se hizo "inactivo" sin esta columna se desapareceria de las filas mostradas, con esta columna lo sigue mostrando, para efectos prácticos y el usuario siga viendo esa fila y reconozca cual fue la modificada. ===///

        public ClsDGVCatalog(DataGridView dgvCatalog, DataTable dtCatalog)
        {
            this.dtCatalog = dtCatalog;
            this.dgvCatalog = dgvCatalog;
            TextSearch = new CatalogDataViewTextSearch(dtCatalog);
            this.dgvCatalog.DataSource = dtCatalog;

            if (dtCatalog.Columns.Contains(activeColumn))
                LoadDGVCatalogWithActiveColumn2();
        }

        public void LoadDGVCatalogWithActiveColumn2()
        {
            activeColumnHide = activeColumn + "2";

            HideActiveColumn2();

            SetFilterActivesOnly();

            DgvApplyCellFormattingEvent(dgvCatalog, activeColumn, idColumn);
        }

        public void AddHideColumn(string? columnName)
        {
            lsHideColumns.Add(columnName);
        }

        public void HideColumnsList()
        {
            foreach (string? columnName in lsHideColumns)
            {
                if (dgvCatalog.Columns.Contains(columnName))
                    dgvCatalog.Columns[columnName].Visible = false;
            }
        }

        public void SetColumnWidth(string columnName, int width)
        {
            SetColumnWidth(dgvCatalog, columnName, width);
        }
        public static void SetColumnWidth(DataGridView dgv, string columnName, int width)
        {
            if (dgv == null || !dgv.Columns.Contains(columnName))
                return;
            dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgv.Columns[columnName].Width = width;
        }
        private void HideActiveColumn2()
        {
            if (dgvCatalog.Columns.Contains(activeColumnHide))
                dgvCatalog.Columns[activeColumnHide].Visible = false;
            else
            {
                DataColumn dc = new DataColumn(activeColumnHide, typeof(string));
                dc.DefaultValue = "1";
                dtCatalog.Columns.Add(dc);
                dc.SetOrdinal(dtCatalog.Columns.Count - 1);

                dgvCatalog.Columns[activeColumnHide].Visible = false;
            }
        }

        public void SetFilterActivesOnly()
        {
            dtCatalog.DefaultView.RowFilter = $"{activeColumnHide} = '1'";
        }

        public void SetFilterNull()
        {
            dtCatalog.DefaultView.RowFilter = "";
        }

        public void CopyActiveValuesToHiddenColumn()
        {
            if (dtCatalog.Columns.Contains(activeColumnHide))
            {
                foreach (DataRow row in dtCatalog.Rows)
                {
                    row[activeColumnHide] = row[activeColumn];
                }
                dtCatalog.AcceptChanges();
            }
        }
        public void ChangeActiveCell(DataGridView? dgv, string activeValue)
        {
            //Este método evita que se recorran las filas en el dgv, ya que moviendole desde el dtCatalog si pasa eso
            if (dgv == null || dgv.Rows.Count == 0 || !dgv.Columns.Contains(activeColumn))
                return;

            dgv.SelectedRows[0].Cells[activeColumn].Value = activeValue;
        }

        public void ChangeActiveCell(string id, string activeValue)
        {
            DataRow[] rows = dtCatalog.Select($"{idColumn} = '{id}'");
            if (rows.Length > 0)
                rows[0][activeColumn] = activeValue;
            dtCatalog.AcceptChanges();
        }
        public void ChangeActiveCell(string id, string id2, string activeValue)
        { //SE OCUPA HABERLE DADO EL VALOR DE id2Column ANTERIORMENTE
            DataRow[] rows = dtCatalog.Select($"{idColumn} = '{id}' AND {id2Column} = '{id2}'");
            if (rows.Length > 0)
                rows[0][activeColumn] = activeValue;
            dtCatalog.AcceptChanges();
        }
        public void AddMultipleNewRowsToDGV(DataTable newRows)
        {
            foreach (DataRow newRow in newRows.Rows)
            {
                DataRow dr = dtCatalog.NewRow();
                foreach (DataColumn dc in dtCatalog.Columns)
                {
                    if (newRows.Columns.Contains(dc.ColumnName))
                    {
                        dr[dc.ColumnName] = newRow[dc.ColumnName];
                    }
                }
                if (dtCatalog.Columns.Contains(activeColumnHide))
                {
                    dr[activeColumnHide] = "1";
                }
                TextSearch.SetKeyForRowIfColumnExists(dr);
                dtCatalog.Rows.Add(dr);
            }
            dtCatalog.AcceptChanges();
        }

        public void AddNewRowToDGV(DataTable newRows)
        {
            foreach (DataRow newRow in newRows.Rows)
            {
                DataRow dr = dtCatalog.NewRow();
                foreach (DataColumn dc in dtCatalog.Columns)
                {
                    if (newRow.Table.Columns.Contains(dc.ColumnName))
                    {
                        dr[dc.ColumnName] = newRow[dc.ColumnName];
                    }
                }
                if (dtCatalog.Columns.Contains(activeColumnHide))
                {
                    dr[activeColumnHide] = "1";
                }
                TextSearch.SetKeyForRowIfColumnExists(dr);
                dtCatalog.Rows.Add(dr);

                SafeSelectRowInDGV(dr);
            }
            dtCatalog.AcceptChanges();
        }

        //public void ModifyIdRowInDGV(DataTable modifyRows)
        //{
        //    foreach (DataRow newRow in modifyRows.Rows)
        //    {
        //        DataRow[] existingRows = dtCatalog.Select($"{idColumn} = '{newRow[idColumn]}'");
        //        if (existingRows.Length > 0)
        //        {
        //            DataRow dr = existingRows[0];
        //            foreach (DataColumn dc in dtCatalog.Columns)
        //            {
        //                if (newRow.Table.Columns.Contains(dc.ColumnName))
        //                {
        //                    dr[dc.ColumnName] = newRow[dc.ColumnName];
        //                }
        //            }
        //            if (dtCatalog.Columns.Contains(activeColumnHide))
        //            {
        //                dr[activeColumnHide] = "1";
        //            }

        //            SafeSelectRowInDGV(dr);
        //        }
        //        else
        //        {
        //            DataRow dr = dtCatalog.NewRow();
        //            foreach (DataColumn dc in dtCatalog.Columns)
        //            {
        //                if (newRow.Table.Columns.Contains(dc.ColumnName))
        //                {
        //                    dr[dc.ColumnName] = newRow[dc.ColumnName];
        //                }
        //            }
        //            if (dtCatalog.Columns.Contains(activeColumnHide))
        //            {
        //                dr[activeColumnHide] = "1";
        //            }
        //            dtCatalog.Rows.Add(dr);

        //            SafeSelectRowInDGV(dr);
        //        }
        //    }
        //    dtCatalog.AcceptChanges();
        //}
        public void ModifyIdRowInDGV(DataTable modifyRows)
        {
            if (modifyRows.Rows.Count == 0) return;

            // Primero agrupamos las filas nuevas por ID para procesarlas por grupos
            var groupedRows = modifyRows.AsEnumerable()
                .GroupBy(row => row[idColumn].ToString())
                .ToList();

            foreach (var group in groupedRows)
            {
                string currentId = group.Key;
                DataRow[] existingRows = dtCatalog.Select($"{idColumn} = '{currentId}'");

                // Determinar la posición donde insertar (la primera coincidencia)
                int insertPosition = existingRows.Length > 0 ?
                    dtCatalog.Rows.IndexOf(existingRows[0]) :
                    dtCatalog.Rows.Count;

                // Eliminar todas las filas existentes con este ID
                foreach (DataRow existingRow in existingRows)
                {
                    dtCatalog.Rows.Remove(existingRow);
                }

                // Insertar todas las nuevas filas con este ID en la posición correcta
                int currentPosition = insertPosition;
                foreach (DataRow newRow in group)
                {
                    DataRow dr = dtCatalog.NewRow();

                    // Copiar los valores
                    foreach (DataColumn dc in dtCatalog.Columns)
                    {
                        if (newRow.Table.Columns.Contains(dc.ColumnName))
                        {
                            dr[dc.ColumnName] = newRow[dc.ColumnName];
                        }
                    }

                    if (dtCatalog.Columns.Contains(activeColumnHide))
                    {
                        dr[activeColumnHide] = "1";
                    }

                    TextSearch.SetKeyForRowIfColumnExists(dr);
                    // Insertar en la posición correcta
                    dtCatalog.Rows.InsertAt(dr, currentPosition);
                    currentPosition++;

                    SafeSelectRowInDGV(dr);
                }
            }

            dtCatalog.AcceptChanges();
        }


        public void ModifyIdRowInDGV_With2Ids(DataTable modifyRows) //PARA CUANDO TIENE 2 IDs COMPUESTAS
        {   //Darle el valor a id2Column antes de usar este método
            //Se cambió a este método para que use la función estática de Metods, ya que es un proceso más complejo y así se puede reutilizar en otros lugares sin necesidad de crear una instancia de ClsDGVCatalog
            Metods.ModifyIdRowInDGV_With2Ids(modifyRows, dtCatalog, idColumn, id2Column, activeColumnHide);
        }
        public static void DgvApplyCellFormattingEvent(DataGridView dataGridView)
        {
            DgvApplyCellFormattingEvent(dataGridView, ClsObject.Column.active, ClsObject.Column.id);
        }
        public static void DgvApplyCellFormattingEvent(DataGridView dataGridView, string activeColumnName, string idColumnName)
        {
            if (!dataGridView.Columns.Contains(activeColumnName))
                return;

            if (dataGridView.Columns.Contains(idColumnName)) // SI CONTIENE LA COLUMNA ID ("Código")
            {
                dataGridView.Columns[idColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //centrado

                dataGridView.Columns[activeColumnName].Visible = false; // Ocultar columna activos

                dataGridView.CellFormatting += (sender, e) =>
                {
                    if (dataGridView.Columns[e.ColumnIndex].Name == idColumnName)
                    {
                        DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                        if (row.Cells[activeColumnName].Value != null && row.Cells[activeColumnName].Value != DBNull.Value)
                        {

                            string activeValue = row.Cells[activeColumnName].Value.ToString() ?? "0";
                            bool isActive = activeValue == "1" || activeValue.Equals("true", StringComparison.OrdinalIgnoreCase);

                            e.CellStyle.BackColor = isActive ? Color.LightGreen : Color.Tomato;
                            e.CellStyle.ForeColor = isActive ? Color.DarkGreen : Color.DarkRed;
                            //e.CellStyle.SelectionBackColor = isActive ? Color.LightGreen : Color.Tomato;
                            //e.CellStyle.SelectionForeColor = isActive ? Color.DarkGreen : Color.DarkRed;

                            e.CellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold); //Negritas/Bold
                        }
                    }
                };
            }
            else // SINO, MANTIENE LA COLUMNA ACTIVO DE COLORES
            {
                dataGridView.CellFormatting += (sender, e) =>
                {
                    if (dataGridView.Columns[e.ColumnIndex].Name == activeColumnName)
                    {
                        bool isChecked = false;

                        if (e.Value != null && e.Value != DBNull.Value)
                        {
                            string valueText = e.Value.ToString() ?? "0";
                            isChecked = valueText == "1" || valueText.Equals("true", StringComparison.OrdinalIgnoreCase);
                        }

                        e.CellStyle.BackColor = isChecked ? Color.LightGreen : Color.Tomato;
                        e.CellStyle.ForeColor = isChecked ? Color.Green : Color.Red;
                    }
                };

                // ==== COLUMNA ACTIVO CON CHECKBOX
                ConvertToCheckBoxColumn(dataGridView, activeColumnName);
            }
        }
        public static void DgvApplyCellFormattingEventSecundarySoftInactive(DataGridView dataGridView, string activeColumnName, string idColumnName)
        {
            if (!dataGridView.Columns.Contains(activeColumnName))
                return;

            if (dataGridView.Columns.Contains(idColumnName)) // SI CONTIENE LA COLUMNA ID ("Código")
            {
                dataGridView.Columns[activeColumnName].Visible = false; // Ocultar columna activos

                dataGridView.CellFormatting += (sender, e) =>
                {
                    if (dataGridView.Columns[e.ColumnIndex].Name == idColumnName)
                    {
                        DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                        if (row.Cells[activeColumnName].Value != null && row.Cells[activeColumnName].Value != DBNull.Value)
                        {

                            string activeValue = row.Cells[activeColumnName].Value.ToString() ?? "0";
                            bool isActive = activeValue == "1" || activeValue.Equals("true", StringComparison.OrdinalIgnoreCase);

                            if (!isActive)
                                e.CellStyle.BackColor = Color.MistyRose;

                            //if (!isActive)
                                //e.CellStyle.ForeColor = Color.DarkRed;

                                //e.CellStyle.SelectionBackColor = isActive ? Color.LightGreen : Color.Tomato;
                                //e.CellStyle.SelectionForeColor = isActive ? Color.DarkGreen : Color.DarkRed;

                                //e.CellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold); //Negritas/Bold
                        }
                    }
                };
            }
        }
        public static void ConvertToCheckBoxColumn(DataGridView dgv, string columnName)
        {
            var oldCol = dgv.Columns[columnName];

            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn
            {
                Name = oldCol.Name,
                HeaderText = oldCol.HeaderText,
                DataPropertyName = oldCol.DataPropertyName,
                TrueValue = "1",
                FalseValue = "0",
                Width = oldCol.Width
            };

            int index = oldCol.Index;
            dgv.Columns.RemoveAt(index);
            dgv.Columns.Insert(index, checkCol);
        }

        private void SafeSelectRowInDGV(DataRow dataRow)
        {
            if (dgvCatalog.Rows.Count == 0 || string.IsNullOrEmpty(idColumn))
                return;

            foreach (DataGridViewRow dgvRow in dgvCatalog.Rows)
            {
                if (dgvRow.Cells[idColumn].Value?.ToString() == dataRow[idColumn].ToString())
                {
                    DataGridViewCell visibleCell = dgvRow.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible); // Buscar la primera celda visible de la fila

                    if (visibleCell != null)
                    {
                        dgvCatalog.CurrentCell = visibleCell;
                        dgvRow.Selected = true;
                        dgvCatalog.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                    }

                    break;
                }
            }
        }
        public void DeleteRowInDGV(string id)
		{
			if (!dtCatalog.Columns.Contains(idColumn))
				return;

			DataRow[] rows = dtCatalog.Select($"{idColumn} = '{id}'");

			foreach (DataRow row in rows)
			{
				dtCatalog.Rows.Remove(row);
			}

			dtCatalog.AcceptChanges();
		}

        /// <summary>
        /// Búsqueda: añade columnas fuente con <see cref="AddColumn(s)"/>, luego
        /// <see cref="EnsureTextSearchKeyColumnWithAllRowKeys"/>, y usa <see cref="GetAlphanumericRowFilterExpression"/>
        /// (clave en columna <see cref="TextSearchKeyColumn"/>; equivale a concatenar, quitar no alfanuméricos y contener, p. ej. <c>77UA1Z</c> y <c>77-UA-1Z</c>).
        /// <see cref="GetRowFilterExpression(string)"/> sigue disponible para búsqueda OR+LIKE literal (sin clave de columna).
        /// </summary>
        public sealed class CatalogDataViewTextSearch
        {
            /// <summary>Columna interna en <see cref="DataTable"/>; oculta en DGV. Solo en memoria.</summary>
            public const string TextSearchKeyColumn = "__textSearchKey";

            private DataTable? _dataTable;
            private readonly List<string> _columnNames = new();
            private volatile bool _textSearchKeyColumnFullyPopulated;

            public CatalogDataViewTextSearch(DataTable dataTable) => _dataTable = dataTable;

            public void Bind(DataTable dataTable)
            {
                _dataTable = dataTable;
                _textSearchKeyColumnFullyPopulated = false;
            }

            public void AddColumn(string? columnName)
            {
                if (string.IsNullOrWhiteSpace(columnName))
                    return;
                if (!_columnNames.Contains(columnName))
                    _columnNames.Add(columnName);
            }

            public void AddColumns(params string[]? columnNames)
            {
                if (columnNames == null)
                    return;
                foreach (string? c in columnNames)
                    AddColumn(c);
            }

            public void ClearColumns() => _columnNames.Clear();

            /// <summary>Antes de aplicar <see cref="DataView.RowFilter"/> de negocio; solo limpia el filtro del <see cref="DataView"/>.</summary>
            public void ResetForRowFilterAfterTextSearch()
            {
                if (_dataTable == null)
                    return;
                _dataTable.DefaultView.RowFilter = string.Empty;
            }

            private void EnsureTextSearchKeyColumnExists()
            {
                if (_dataTable == null)
                    return;
                if (!_dataTable.Columns.Contains(TextSearchKeyColumn))
                {
                    var c = new DataColumn(TextSearchKeyColumn, typeof(string)) { DefaultValue = string.Empty, AllowDBNull = true };
                    _dataTable.Columns.Add(c);
                }
            }

            /// <summary>Crea la columna <see cref="TextSearchKeyColumn"/> (si hace falta) y rellena la clave alfanumérica de todas las filas.</summary>
            public void EnsureTextSearchKeyColumnWithAllRowKeys()
            {
                if (_dataTable == null)
                    return;
                EnsureTextSearchKeyColumnExists();
                PopulateTextSearchKeyForAllRowsSync();
            }

            private void PopulateTextSearchKeyForAllRowsSync()
            {
                if (_dataTable == null)
                    return;
                EnsureTextSearchKeyColumnExists();
                foreach (DataRow r in _dataTable.Rows)
                {
                    if (r.RowState != DataRowState.Deleted)
                        SetKeyForRow(r);
                }
                _dataTable.AcceptChanges();
                _textSearchKeyColumnFullyPopulated = true;
            }

            /// <summary>
            /// Crea la columna de clave (vacía) y rellenamiento completo <b>en otro hilo</b> (cálculo) + <see cref="Control.BeginInvoke(Delegate)"/>
            /// para asignar al <see cref="DataTable"/>. Evita congelar la UI con tablas muy grandes. Si aún no terminó, la búsqueda alfanumérica
            /// fuerza rellenado sincrónico. Si <paramref name="invokeTarget"/> es null, hace rellenado completo al momento.
            /// </summary>
            public void PopulateTextSearchKeyColumnInBackground(Control? invokeTarget)
            {
                if (_dataTable == null || _columnNames.Count == 0)
                {
                    _textSearchKeyColumnFullyPopulated = true;
                    return;
                }

                EnsureTextSearchKeyColumnExists();
                _textSearchKeyColumnFullyPopulated = false;

                if (invokeTarget == null)
                {
                    PopulateTextSearchKeyForAllRowsSync();
                    return;
                }

                if (invokeTarget.IsDisposed)
                {
                    PopulateTextSearchKeyForAllRowsSync();
                    return;
                }

                var table = _dataTable;
                int n = table.Rows.Count;
                var concats = new string?[n];
                for (int i = 0; i < n; i++)
                {
                    DataRow r = table.Rows[i];
                    if (r.RowState == DataRowState.Deleted)
                    {
                        concats[i] = null;
                        continue;
                    }
                    concats[i] = BuildRawConcatStringForKey(r);
                }

                _ = Task.Run(() =>
                {
                    var keys = new string[n];
                    for (int i = 0; i < n; i++)
                    {
                        if (string.IsNullOrEmpty(concats[i]))
                            keys[i] = string.Empty;
                        else
                            keys[i] = ToAlphanumericKey(concats[i]!);
                    }

                    void WriteKeys()
                    {
                        if (invokeTarget.IsDisposed)
                            return;
                        for (int i = 0; i < n; i++)
                        {
                            if (i >= table.Rows.Count)
                                break;
                            DataRow r = table.Rows[i];
                            if (r.RowState != DataRowState.Deleted)
                                r[TextSearchKeyColumn] = keys[i] ?? string.Empty;
                        }
                        table.AcceptChanges();
                        _textSearchKeyColumnFullyPopulated = true;
                    }

                    if (invokeTarget.IsDisposed)
                    {
                        return;
                    }

                    try
                    {
                        if (invokeTarget.IsHandleCreated)
                        {
                            invokeTarget.BeginInvoke((Action)WriteKeys);
                        }
                        else
                        {
                            void OnHandleCreated(object? s, EventArgs e)
                            {
                                invokeTarget.HandleCreated -= OnHandleCreated;
                                if (!invokeTarget.IsDisposed)
                                {
                                    try { invokeTarget.BeginInvoke((Action)WriteKeys); } catch { }
                                }
                            }
                            invokeTarget.HandleCreated += OnHandleCreated;
                        }
                    }
                    catch
                    {
                        // Sin UI válida, no bloquea.
                    }
                });
            }

            public void SetKeyForRowIfColumnExists(DataRow? row)
            {
                if (row == null || _dataTable == null || !row.Table.Columns.Contains(TextSearchKeyColumn))
                    return;
                SetKeyForRow(row);
            }

            public void SetKeyForRow(DataRow? row)
            {
                if (row == null || _dataTable == null || !row.Table.Columns.Contains(TextSearchKeyColumn))
                    return;
                row[TextSearchKeyColumn] = BuildAlphanumericKeyForRow(row);
            }

            private string BuildRawConcatStringForKey(DataRow r)
            {
                if (_columnNames.Count == 0)
                    return string.Empty;
                var all = new StringBuilder(128);
                foreach (string c in _columnNames)
                {
                    if (r.Table.Columns.Contains(c))
                        all.Append(CellAsString(r, c));
                }
                return all.ToString();
            }

            private string BuildAlphanumericKeyForRow(DataRow r) => ToAlphanumericKey(BuildRawConcatStringForKey(r));

            private string CellAsString(DataRow r, string column)
            {
                if (r == null || !r.Table.Columns.Contains(column))
                    return string.Empty;
                object? o = r[column];
                if (o == null || o == DBNull.Value)
                    return string.Empty;
                return o.ToString() ?? string.Empty;
            }

            /// <summary>Like normalizado sobre <see cref="TextSearchKeyColumn"/>; columnas añadidas. Si el rellenado en segundo plano no acabó, se completa aquí (sincrónico).</summary>
            public string GetAlphanumericRowFilterExpression(string? textToFilter)
            {
                if (string.IsNullOrWhiteSpace(textToFilter) || _dataTable == null
                    || _columnNames.Count == 0)
                    return string.Empty;
                if (!_textSearchKeyColumnFullyPopulated)
                    PopulateTextSearchKeyForAllRowsSync();
                if (!_dataTable.Columns.Contains(TextSearchKeyColumn))
                    return string.Empty;
                string n = ToAlphanumericKey(textToFilter);
                if (n.Length == 0)
                    return string.Empty;
                string pat = EscapeDataViewLikeLiteral(n);
                if (string.IsNullOrEmpty(pat))
                    return string.Empty;
                return "( [" + TextSearchKeyColumn + "] LIKE '*" + pat + "*' )";
            }

            /// <summary>Solo letras y números (mayúsculas); se usa para celdas, columna de clave y término de búsqueda.</summary>
            public static string ToAlphanumericKey(string? s)
            {
                if (string.IsNullOrEmpty(s))
                    return string.Empty;
                var sb = new StringBuilder(s.Length);
                foreach (char c in s)
                {
                    if (char.IsLetterOrDigit(c))
                        sb.Append(char.ToUpperInvariant(c));
                }
                return sb.ToString();
            }

            /// <summary>Expresión con paréntesis y OR de <c>LIKE '*término*'</c> (texto en celdas, sin clave alfanumérica).</summary>
            public string GetRowFilterExpression(string? textToFilter)
            {
                if (string.IsNullOrWhiteSpace(textToFilter) || _dataTable == null)
                    return string.Empty;

                string pat = EscapeDataViewLikeLiteral(textToFilter.Trim());
                if (string.IsNullOrEmpty(pat))
                    return string.Empty;

                var orClause = new StringBuilder();
                for (int i = 0; i < _columnNames.Count; i++)
                {
                    string col = _columnNames[i];
                    if (!_dataTable.Columns.Contains(col))
                        continue;
                    if (orClause.Length > 0)
                        orClause.Append(" OR ");
                    orClause.Append('[');
                    orClause.Append(col);
                    orClause.Append("] LIKE '*");
                    orClause.Append(pat);
                    orClause.Append("*'");
                }

                return orClause.Length == 0 ? string.Empty : "(" + orClause + ")";
            }

            /// <summary>
            /// Asigna <see cref="DataView.RowFilter"/> a la búsqueda. Si <paramref name="textToFilter"/> está vacío, no hace nada
            /// (el llamador debe poner su filtro base, p. ej. activos, línea).
            /// </summary>
            public void SetTextFilterToDefaultView(string? textToFilter)
            {
                if (string.IsNullOrWhiteSpace(textToFilter) || _dataTable == null)
                    return;
                string expr = GetRowFilterExpression(textToFilter);
                if (string.IsNullOrEmpty(expr))
                    return;
                _dataTable.DefaultView.RowFilter = expr;
            }

            private static string EscapeDataViewLikeLiteral(string? text)
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                var sb = new StringBuilder(text.Length);
                foreach (char ch in text)
                {
                    switch (ch)
                    {
                        case '*': sb.Append("[*]"); break;
                        case '?': sb.Append("[?]"); break;
                        case '#': sb.Append("[#]"); break;
                        case '[': sb.Append("[[]"); break;
                        case ']': sb.Append("[]]"); break;
                        case '\'': sb.Append("''"); break;
                        default: sb.Append(ch); break;
                    }
                }
                return sb.ToString();
            }
        }

        static public class Metods
        {
            public static void  ModifyIdRowInDGV(DataTable modifyRows, DataTable dtOriginal, string idColumn, string? activeColumnHide)
            {
                if (modifyRows.Rows.Count == 0) return;

                // Primero agrupamos las filas nuevas por ID para procesarlas por grupos
                var groupedRows = modifyRows.AsEnumerable()
                    .GroupBy(row => row[idColumn].ToString())
                    .ToList();

                foreach (var group in groupedRows)
                {
                    string currentId = group.Key;
                    DataRow[] existingRows = dtOriginal.Select($"{idColumn} = '{currentId}'");

                    // Determinar la posición donde insertar (la primera coincidencia)
                    int insertPosition = existingRows.Length > 0 ?
                        dtOriginal.Rows.IndexOf(existingRows[0]) :
                        dtOriginal.Rows.Count;

                    // Eliminar todas las filas existentes con este ID
                    foreach (DataRow existingRow in existingRows)
                    {
                        dtOriginal.Rows.Remove(existingRow);
                    }

                    // Insertar todas las nuevas filas con este ID en la posición correcta
                    int currentPosition = insertPosition;
                    foreach (DataRow newRow in group)
                    {
                        DataRow dr = dtOriginal.NewRow();

                        // Copiar los valores
                        foreach (DataColumn dc in dtOriginal.Columns)
                        {
                            if (newRow.Table.Columns.Contains(dc.ColumnName))
                            {
                                dr[dc.ColumnName] = newRow[dc.ColumnName];
                            }
                        }

                        if (activeColumnHide != null && dtOriginal.Columns.Contains(activeColumnHide))
                        {
                            dr[activeColumnHide] = "1";
                        }

                        // Insertar en la posición correcta
                        dtOriginal.Rows.InsertAt(dr, currentPosition);
                        currentPosition++;

                        //SafeSelectRowInDGV(dr);
                    }
                }

                dtOriginal.AcceptChanges();
            }

            public static void ModifyIdRowInDGV_With2Ids(DataTable modifyRows, DataTable dtOriginal, string idColumn1, string idColumn2, string? activeColumnHide) //PARA CUANDO TIENE 2 IDs COMPUESTAS
            {   //Darle el valor a id2Column antes de usar este método

                if (modifyRows == null || modifyRows.Rows.Count == 0) return;
                if (string.IsNullOrWhiteSpace(idColumn2)) return;

                // Validaciones básicas
                if (!dtOriginal.Columns.Contains(idColumn1))
                    throw new ArgumentException($"dtCatalog no contiene la columna '{idColumn1}'");

                if (!dtOriginal.Columns.Contains(idColumn2))
                    throw new ArgumentException($"dtCatalog no contiene la columna '{idColumn2}'");

                if (!modifyRows.Columns.Contains(idColumn1))
                    throw new ArgumentException($"modifyRows no contiene la columna '{idColumn1}'");

                if (!modifyRows.Columns.Contains(idColumn2))
                    throw new ArgumentException($"modifyRows no contiene la columna '{idColumn2}'");

                // Helper para evitar errores en DataTable.Select por comillas simples
                static string EscapeForSelect(string value) => (value ?? "").Replace("'", "''");

                // Agrupar por la combinación (idColumn + id2Column)
                var groupedRows = modifyRows.AsEnumerable()
                    .GroupBy(row => new
                    {
                        Id1 = row[idColumn1]?.ToString() ?? "",
                        Id2 = row[idColumn2]?.ToString() ?? ""
                    })
                    .ToList();

                foreach (var group in groupedRows)
                {
                    string currentId1 = group.Key.Id1;
                    string currentId2 = group.Key.Id2;

                    string filter =
                        $"{idColumn1} = '{EscapeForSelect(currentId1)}' AND {idColumn2} = '{EscapeForSelect(currentId2)}'";

                    DataRow[] existingRows = dtOriginal.Select(filter);

                    // Determinar la posición donde insertar (la primera coincidencia)
                    int insertPosition = existingRows.Length > 0
                        ? dtOriginal.Rows.IndexOf(existingRows[0])
                        : dtOriginal.Rows.Count;

                    // Eliminar todas las filas existentes con esta combinación de IDs
                    foreach (DataRow existingRow in existingRows)
                        dtOriginal.Rows.Remove(existingRow);

                    // Insertar todas las nuevas filas con esta combinación en la posición correcta
                    int currentPosition = insertPosition;

                    foreach (DataRow newRow in group)
                    {
                        DataRow dr = dtOriginal.NewRow();

                        // Copiar valores (solo columnas existentes en dtOriginal)
                        foreach (DataColumn dc in dtOriginal.Columns)
                        {
                            if (modifyRows.Columns.Contains(dc.ColumnName))
                                dr[dc.ColumnName] = newRow[dc.ColumnName];
                        }

                        if (activeColumnHide != null && dtOriginal.Columns.Contains(activeColumnHide))
                            dr[activeColumnHide] = "1";

                        dtOriginal.Rows.InsertAt(dr, currentPosition);
                        currentPosition++;

                        //SafeSelectRowInDGV(dr);
                    }
                }

                dtOriginal.AcceptChanges();
            }
        }
    }
}

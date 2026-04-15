using NPOI.SS.UserModel;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.DataGridViews
{
    internal class ClsDGVCatalog
    {
        public string idColumn = ClsObject.Column.id;
        public string id2Column = "id2"; //PARA CUANDO TIENE 2 IDs COMPUESTAS
        public string activeColumn = ClsObject.Column.active;
        private string activeColumnHide = ClsObject.Column.active + "2";
        //public string queryCatalog;
        public DataGridView dgvCatalog;
        public DataTable dtCatalog;
        //public Button btnRemoved;

        public ClsDGVCatalog(DataGridView dgvCatalog, DataTable dtCatalog)
        {
            this.dtCatalog = dtCatalog;

            this.dgvCatalog = dgvCatalog;
            this.dgvCatalog.DataSource = dtCatalog;

            if (dtCatalog.Columns.Contains(activeColumn))
                LoadDGVCatalogWithActiveColumn2();
        }

        public void LoadDGVCatalogWithActiveColumn2()
        {
            activeColumnHide = activeColumn + "2";

            HideActiveColumn2();

            SetFilterActivesOnly();

            DgvApplyCellFormattingEvent(dgvCatalog, activeColumn);
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

        public static void DgvApplyCellFormattingEvent(DataGridView dataGridView, string activeColumnName)
        {
            //dataGridView.CellFormatting += (sender, e) =>
            //{
            //    if (dataGridView.Columns[e.ColumnIndex].Name == activeColumnName)
            //    {
            //        bool isChecked = false;

            //        if (e.Value != null && e.Value != DBNull.Value)
            //        {
            //            string valueText = e.Value.ToString() ?? "0";
            //            isChecked = valueText == "1" || valueText.Equals("true", StringComparison.OrdinalIgnoreCase);
            //        }

            //        e.CellStyle.BackColor = isChecked ? Color.LightGreen : Color.Tomato;
            //        e.CellStyle.ForeColor = isChecked ? Color.Green : Color.Red;
            //    }
            //};

            //ConvertToCheckBoxColumn(dataGridView, activeColumnName);//Llama a este método para convertir la columna activeColumn en una columna de checkboxes

            dataGridView.CellFormatting += (sender, e) =>
            {
                if (dataGridView.Columns[e.ColumnIndex].Name == activeColumnName)
                {
                    if (e.Value.ToString() == "0")
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.Tomato;
                        e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                    if (e.Value.ToString() == "1")
                    {
                        e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                        e.CellStyle.ForeColor = System.Drawing.Color.Green;
                    }
                }
            };
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
                    dgvCatalog.CurrentCell = dgvRow.Cells[0];
                    dgvRow.Selected = true;
                    dgvCatalog.FirstDisplayedScrollingRowIndex = dgvRow.Index;
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

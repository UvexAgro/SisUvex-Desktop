using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Catalogos.Metods.DataGridViews
{
    internal class ClsDGVCatalog
    {
        public string idColumn = ClsObject.Column.id;
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
            {
                rows[0][activeColumn] = activeValue;
            }
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
        public static void DgvApplyCellFormattingEvent(DataGridView dataGridView, string activeColumnName)
        {
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
    }
}

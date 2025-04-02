using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
        public Button btnRemoved;

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

                int rowIndex = dtCatalog.Rows.IndexOf(dr);
                dgvCatalog.CurrentCell = dgvCatalog.Rows[rowIndex].Cells[0];
            }
            dtCatalog.AcceptChanges();
        }

        public void ModifyIdRowInDGV(DataTable modifyRows)
        {
            foreach (DataRow newRow in modifyRows.Rows)
            {
                DataRow[] existingRows = dtCatalog.Select($"{idColumn} = '{newRow[idColumn]}'");
                if (existingRows.Length > 0)
                {
                    DataRow dr = existingRows[0];
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
                    // Focus on the modified row
                    int rowIndex = dtCatalog.Rows.IndexOf(dr);
                    dgvCatalog.CurrentCell = dgvCatalog.Rows[rowIndex].Cells[0];
                }
                else
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
                    // Focus on the new row
                    int rowIndex = dtCatalog.Rows.IndexOf(dr);
                    dgvCatalog.CurrentCell = dgvCatalog.Rows[rowIndex].Cells[0];
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
    }
}

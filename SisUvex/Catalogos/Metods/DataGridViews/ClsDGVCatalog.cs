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
        public string activeColumnHide = ClsObject.Column.active + "2";
        public string queryCatalog;
        public DataTable dtCatalog;
        public DataTable dtCatalogActives;
        public DataGridView dgvCatalog;
        public Button btnRemoved;

        public void LoadDGVCatalog_ActiveColumn2()
        {
            HideActiveColumn2();

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

        public void ChangeActiveColumn(string id, string activeValue)
        {
            DataRow[] rows = dtCatalog.Select($"{idColumn} = '{id}'");
            if (rows.Length > 0)
            {
                rows[0][activeColumn] = activeValue;
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

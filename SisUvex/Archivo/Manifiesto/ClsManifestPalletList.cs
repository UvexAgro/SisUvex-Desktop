using Microsoft.Data.SqlClient.DataClassification;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsManifestPalletList
    {
        public string columnPosition = "Posicion";
        public DataGridView dataGridView;
        string qryPal = " SELECT Activo, Posicion, Pallet, Mix, Estiba, Cajas, Contenedor, CONVERT(float, Libras) AS [Lbs], CONCAT_WS(' ', Pre, Presentación, Pos) AS [Presentación], VarCorto AS [Variedad], Etiqueta AS [Distribuidor], Tamaño, Lote, CONVERT(DATE, Fecha) AS [Fecha], [Plan], Programa AS [GTIN], Manifiesto, Rack FROM vw_PackPalletDetails ";
        public int GetNextPalletPosition()
        {
            int maxPosition = 0;
            if (dataGridView.Rows.Count > 0)
            {
                int indiceColumn = dataGridView.Columns[columnPosition].Index;
                foreach (DataGridViewRow fila in dataGridView.Rows)
                {
                    if (int.TryParse(fila.Cells[indiceColumn].Value.ToString(), out int value))
                    {
                        if (value > maxPosition)
                            maxPosition = value;
                    }
                }
            }
            maxPosition++;

            return maxPosition;
        }

        public void AddColumnsToDGVPalletList()
        {
            dataGridView.Columns.Add(columnPosition, columnPosition);
            dataGridView.Columns.Add("Pallet", "Pallet");
            dataGridView.Columns.Add("Estiba", "Estiba");
            dataGridView.Columns.Add("Mix", "Mix");
            dataGridView.Columns.Add("Cajas", "Cajas");
            dataGridView.Columns.Add("Contenedor", "Contenedor");
            dataGridView.Columns.Add("Lbs", "Lbs");
            dataGridView.Columns.Add("Tamaño", "Tamaño");
            dataGridView.Columns.Add("Presentación", "Presentación");
            dataGridView.Columns.Add("Variedad", "Variedad");
            dataGridView.Columns.Add("Distribuidor", "Distribuidor");
            dataGridView.Columns.Add("Lote", "Lote");
            dataGridView.Columns.Add("Fecha", "Fecha");
            dataGridView.Columns.Add("Plan", "Plan");
            dataGridView.Columns.Add("GTIN", "GTIN");


            dataGridView.Columns[columnPosition].ValueType = typeof(int);
            dataGridView.Columns[columnPosition].DefaultCellStyle.Format = "00";

            dataGridView.Columns[columnPosition].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["Fecha"].DefaultCellStyle.Format = "MMM-dd";
            dataGridView.Columns["Pallet"].DefaultCellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Bold);
            dataGridView.Columns["Cajas"].DefaultCellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Bold);
        }

        public bool AddPalletToDGVPalletList(string idPallet, int position)
        {
            string qryWherePallet = " WHERE Pallet = @idPallet ";

            Dictionary<string, object> idPalParameter = new()
            {
                { "@idPallet", idPallet }
            };

            DataTable dtPallet = ClsQuerysDB.ExecuteParameterizedQuery(qryPal + qryWherePallet, idPalParameter);

            if (!IsPalletValid(dtPallet))
                return false;

            string? idSwotage = dtPallet.Rows[0]["Estiba"].ToString();

            if (!string.IsNullOrEmpty(idSwotage)) //AÑADIR PALLET
            {
                string qryWhereStowage = " WHERE Estiba = @idStowage ";

                Dictionary<string, object> idStowageParameter = new()
                {
                    { "@idStowage", idSwotage }
                };

                dtPallet = ClsQuerysDB.ExecuteParameterizedQuery(qryPal + qryWhereStowage, idStowageParameter);
            }

            foreach (DataRow row in dtPallet.Rows) //Añadirle la posición del txbPosition
            {
                row["Posicion"] = position;
            }

            MovePalletsPositions(position, 1);

            AddDTPalletToDGVList(dtPallet);

            return true;
        }

        private void AddDTPalletToDGVList(DataTable dtPallets)
        {
            int position = int.Parse(dtPallets.Rows[0]["Posicion"].ToString());
            List<DataGridViewRow> rowsToInsert = new List<DataGridViewRow>();

            foreach (DataRow row in dtPallets.Rows)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, row["Posicion"], row["Pallet"], row["Estiba"], row["Mix"], row["Cajas"], row["Contenedor"], row["Lbs"], row["Tamaño"], row["Presentación"], row["Variedad"], row["Distribuidor"], row["Lote"], row["Fecha"], row["Plan"], row["GTIN"]);
                rowsToInsert.Add(newRow);
            }

            int insertIndex = dataGridView.Rows.Cast<DataGridViewRow>().Where(r => int.Parse(r.Cells["Posicion"].Value.ToString()) == position - 1).LastOrDefault()?.Index + 1 ?? 0;

            foreach (var newRow in rowsToInsert)
            {
                dataGridView.Rows.Insert(insertIndex, newRow);
                insertIndex++;
            }
        }

        public void MovePalletsPositions(int palletPosition, int unit)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (int.TryParse(row.Cells["Posicion"].Value.ToString(), out int comparePosition) && comparePosition >= 1 && comparePosition >= palletPosition)
                {
                    comparePosition = comparePosition + unit;
                    row.Cells["Posicion"].Value = comparePosition;
                }
            }
        }

        public void RemovePalletFromDGVPalletList()
        {
            if (dataGridView.Rows.Count > 0)
            {
                int selectedPosition = int.Parse(dataGridView.SelectedRows[0].Cells["Posicion"].Value.ToString());

                var rowsToRemove = dataGridView.Rows.Cast<DataGridViewRow>()
                    .Where(row => int.Parse(row.Cells["Posicion"].Value.ToString()) == selectedPosition)
                    .ToList();

                foreach (var row in rowsToRemove)
                {
                    dataGridView.Rows.Remove(row);
                }

                MovePalletsPositions(selectedPosition, -1);
            }
        }

        public bool IsPalletValid(DataTable dtPallet)
        {
            if (dtPallet.Rows.Count == 0)
            {
                System.Media.SystemSounds.Beep.Play();
                return false;
            }

            string? palletId = dtPallet.Rows[0]["Pallet"].ToString();

            if (string.IsNullOrEmpty(palletId))
            {
                System.Media.SystemSounds.Beep.Play();
                return false;
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Pallet"].Value.ToString() == palletId)
                {
                    System.Media.SystemSounds.Beep.Play();
                    return false;
                }
            }

            string? idManifest = dtPallet.Rows[0]["Manifiesto"].ToString();

            if (!string.IsNullOrEmpty(idManifest))
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("El pallet ya se encuentra en el manifiesto: " + idManifest, "Pallet en manifiesto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            string? idRack = dtPallet.Rows[0]["Rack"].ToString();

            if (!string.IsNullOrEmpty(idRack))
            {
                System.Media.SystemSounds.Beep.Play();
                DialogResult result = MessageBox.Show("El pallet ya se encuentra en el rack: " + idRack + ". ¿Desea sacarlo del rack?", "Pallet en rack", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return false;
            }

            string? active = dtPallet.Rows[0]["Activo"].ToString();

            if (active != "1") //QUE NO ESTÉ DESACTIVADO
            {
                System.Media.SystemSounds.Beep.Play();
                return false;
            }

            return true;
        }
        public void MoveUpSelectedPalletPosition()
        {
            if (dataGridView.SelectedRows.Count == 0)
                return;

            if (!int.TryParse(dataGridView.SelectedRows[0].Cells["Posicion"].Value.ToString(), out int selectedPosition))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            int selectedIndex = dataGridView.SelectedRows[0].Index;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!int.TryParse(row.Cells["Posicion"].Value.ToString(), out int comparePosition))
                    continue;

                if (comparePosition == selectedPosition + 1)
                {
                    row.Cells["Posicion"].Value = selectedPosition;
                }
                else if (comparePosition == selectedPosition)
                {
                    row.Cells["Posicion"].Value = selectedPosition + 1;
                }
            }
        }
        public void MoveDownSelectedPalletPosition()
        {
            if (dataGridView.SelectedRows.Count == 0)
                return;

            if (!int.TryParse(dataGridView.SelectedRows[0].Cells["Posicion"].Value.ToString(), out int selectedPosition) || selectedPosition <= 1)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            int selectedIndex = dataGridView.SelectedRows[0].Index;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!int.TryParse(row.Cells["Posicion"].Value.ToString(), out int comparePosition))
                    continue;

                if (comparePosition == selectedPosition - 1)
                {
                    row.Cells["Posicion"].Value = selectedPosition;
                }
                else if (comparePosition == selectedPosition)
                {
                    row.Cells["Posicion"].Value = selectedPosition - 1;
                }
            }
        }
    }
}

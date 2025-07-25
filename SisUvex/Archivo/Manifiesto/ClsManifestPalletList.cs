﻿using Microsoft.Data.SqlClient.DataClassification;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Catalogos.Metods;
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
        public static string columnPosition = "Posicion";
        private const string cIdDistributor = ClsObject.Distributor.ColumnId;
        public DataGridView dataGridView;
        string qryPal = $" SELECT Activo, Posicion AS [{columnPosition}], Pallet, Mix, Estiba, Cajas, Contenedor, CONVERT(float, Libras) AS [Lbs], CONCAT_WS(' ', Pre, Presentación, Pos) AS [Presentación], VarCorto AS [Variedad], Etiqueta AS [Distribuidor], Tamaño, Lote, CONVERT(DATE, Fecha) AS [Fecha], [Plan], Programa AS [GTIN], Manifiesto, Rack, gtn.id_distributor AS [{cIdDistributor}] FROM vw_PackPalletDetails vw JOIN Pack_GTIN gtn ON gtn.id_GTIN = vw.Programa ";
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
            dataGridView.Columns.Add(cIdDistributor, cIdDistributor);

            //dataGridView.Columns[cIdDistributor].Visible = false;

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
                row[columnPosition] = position;
            }

            MovePalletsPositions(position, 1);

            AddDTPalletsToDGVList(dtPallet);

            return true;
        }

        private void AddDTPalletsToDGVList(DataTable dtPallets)
        {
            if (dtPallets.Rows.Count == 0)
                return;

            int position = int.Parse(dtPallets.Rows[0][columnPosition].ToString());
            List<DataGridViewRow> rowsToInsert = new List<DataGridViewRow>();

            foreach (DataRow row in dtPallets.Rows)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView, row[columnPosition], row["Pallet"], row["Estiba"], row["Mix"], row["Cajas"], row["Contenedor"], row["Lbs"], row["Tamaño"], row["Presentación"], row["Variedad"], row["Distribuidor"], row["Lote"], row["Fecha"], row["Plan"], row["GTIN"], row[cIdDistributor]);
                rowsToInsert.Add(newRow);
            }

            int insertIndex = dataGridView.Rows.Cast<DataGridViewRow>().Where(r => int.Parse(r.Cells[columnPosition].Value.ToString()) == position - 1).LastOrDefault()?.Index + 1 ?? 0;

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
                if (int.TryParse(row.Cells[columnPosition].Value.ToString(), out int comparePosition) && comparePosition >= 1 && comparePosition >= palletPosition)
                {
                    comparePosition = comparePosition + unit;
                    row.Cells[columnPosition].Value = comparePosition;
                }
            }
        }

        public void RemovePalletFromDGVPalletList()
        {
            if (dataGridView.Rows.Count > 0)
            {
                int selectedPosition = int.Parse(dataGridView.SelectedRows[0].Cells[columnPosition].Value.ToString());

                var rowsToRemove = dataGridView.Rows.Cast<DataGridViewRow>()
                    .Where(row => int.Parse(row.Cells[columnPosition].Value.ToString()) == selectedPosition)
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

            if (!int.TryParse(dataGridView.SelectedRows[0].Cells[columnPosition].Value.ToString(), out int selectedPosition))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            int selectedIndex = dataGridView.SelectedRows[0].Index;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!int.TryParse(row.Cells[columnPosition].Value.ToString(), out int comparePosition))
                    continue;

                if (comparePosition == selectedPosition + 1)
                {
                    row.Cells[columnPosition].Value = selectedPosition;
                }
                else if (comparePosition == selectedPosition)
                {
                    row.Cells[columnPosition].Value = selectedPosition + 1;
                }
            }
        }

        public void MoveDownSelectedPalletPosition()
        {
            if (dataGridView.SelectedRows.Count == 0)
                return;

            if (!int.TryParse(dataGridView.SelectedRows[0].Cells[columnPosition].Value.ToString(), out int selectedPosition) || selectedPosition <= 1)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            int selectedIndex = dataGridView.SelectedRows[0].Index;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!int.TryParse(row.Cells[columnPosition].Value.ToString(), out int comparePosition))
                    continue;

                if (comparePosition == selectedPosition - 1)
                {
                    row.Cells[columnPosition].Value = selectedPosition;
                }
                else if (comparePosition == selectedPosition)
                {
                    row.Cells[columnPosition].Value = selectedPosition - 1;
                }
            }
        }

        public void AddManifestPalletsToDGVPalletList(string? idManifest)
        {
            if(string.IsNullOrEmpty(idManifest))
                return;
            
            string qryWherePallet = $" WHERE Manifiesto = @idManifest ORDER BY Posicion, Mix";

            Dictionary<string, object> idPalParameter = new()
            {
                { "@idManifest", idManifest }
            };

            DataTable dtManifestPallets = ClsQuerysDB.ExecuteParameterizedQuery(qryPal + qryWherePallet, idPalParameter);

            AddDTPalletsToDGVList(dtManifestPallets);
        }

        public bool ValidateIdDistributorInPallets(string idDistributor)
        {
            if (string.IsNullOrEmpty(idDistributor)) //PORQUE SE PERMITE NO TENER DISTRUBUIDOR SELECCIONADO
                return true;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[cIdDistributor].Value != null)
                    {
                        if (!row.Cells[cIdDistributor].Value.ToString().Equals(idDistributor))
                        {
                            System.Media.SystemSounds.Beep.Play();
                            DialogResult result = MessageBox.Show(
                                "El distribuidor del manifiesto es diferente al distribuidor del pallet (o pallets).\n\n ¿Desea guardarlo aún así?",
                                "Distribuidor en pallets",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation);

                            if (result == DialogResult.No)
                                return false;
                            else
                                return true;
                        }
                    }
                }
            }
            return true;
        }
    }
}

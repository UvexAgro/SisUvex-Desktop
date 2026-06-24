using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsPrintManifestPalletsList
    {
        List<string?> lsPallets;

        public bool SetManifestPalletsPerPositionList(DataGridView dgvPallets)
        {
            lsPallets = new List<string?>();

            if (dgvPallets == null || dgvPallets.Rows.Count == 0)
            {
                MessageBox.Show("No hay pallets cargados en la grilla.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            int selColumnIndex = -1;
            if (dgvPallets.Columns["Sel"] != null)
                selColumnIndex = dgvPallets.Columns["Sel"].Index;

            if (selColumnIndex == -1)
            {
                MessageBox.Show("No se encontró la columna 'Sel'.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int palletColumnIndex = -1;
            if (dgvPallets.Columns["Pallet"] != null)
                palletColumnIndex = dgvPallets.Columns["Pallet"].Index;

            if (palletColumnIndex == -1)
            {
                MessageBox.Show("No se encontró la columna 'Pallet'.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool hasSelectedRows = false;

            foreach (DataGridViewRow row in dgvPallets.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (IsCheckboxChecked(row.Cells[selColumnIndex].Value))
                {
                    hasSelectedRows = true;
                    object palletValue = row.Cells[palletColumnIndex].Value;
                    if (palletValue != null && palletValue != DBNull.Value)
                        lsPallets.Add(palletValue.ToString()?.Trim());
                }
            }

            if (!hasSelectedRows)
            {
                MessageBox.Show("Debes seleccionar al menos un pallet.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// La columna Sel puede almacenar bool o 0/1 según FalseValue/TrueValue del DataGridViewCheckBoxColumn.
        /// </summary>
        public static bool IsCheckboxChecked(object? value)
        {
            if (value == null || value == DBNull.Value)
                return false;

            if (value is bool b)
                return b;

            if (value is int i)
                return i != 0;

            if (value is long l)
                return l != 0;

            string text = value.ToString()?.Trim() ?? string.Empty;
            if (text.Length == 0)
                return false;

            if (text == "1" || text.Equals("true", StringComparison.OrdinalIgnoreCase))
                return true;

            if (text == "0" || text.Equals("false", StringComparison.OrdinalIgnoreCase))
                return false;

            return bool.TryParse(text, out bool parsed) && parsed;
        }

        public void PrintManifestPalletsList(int copies, bool reverseOrientation, bool showDate, bool printSmallCode)
        {
            if (lsPallets == null || lsPallets.Count == 0)
            {
                MessageBox.Show("No hay pallets para imprimir.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (printSmallCode)
                PrintSmallCodeLabels(copies, reverseOrientation, showDate);
            else
                PrintLargePalletLabels(copies, reverseOrientation, showDate);
        }

        private void PrintLargePalletLabels(int copies, bool reverseOrientation, bool showDate)
        {
            foreach (string? idPallet in lsPallets)
            {
                if (!string.IsNullOrWhiteSpace(idPallet))
                    ClsReprintPallet.ReprintPalletTag(idPallet, copies, reverseOrientation, showDate);
            }
        }

        private void PrintSmallCodeLabels(int copies, bool reverseOrientation, bool showDate)
        {
            ClsGenerateStringZplPalletTag genPallet = new ClsGenerateStringZplPalletTag();
            ClsPrintPtiTag print = new ClsPrintPtiTag();

            foreach ((string? leftId, string? rightId) in BuildSmallCodeStripPairs(copies))
                PrintSmallCodeStrip(genPallet, print, leftId, rightId, reverseOrientation, showDate);
        }

        /// <summary>
        /// Arma pares izquierda/derecha para tiras 4x1 (2 etiquetas 2x1).
        /// </summary>
        private IEnumerable<(string? LeftId, string? RightId)> BuildSmallCodeStripPairs(int copies)
        {
            List<string> selected = lsPallets!
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .Select(id => id!.Trim())
                .ToList();

            if (copies == 1)
            {
                for (int i = 0; i < selected.Count; i += 2)
                {
                    string left = selected[i];
                    string? right = i + 1 < selected.Count ? selected[i + 1] : null;
                    yield return (left, right);
                }
                yield break;
            }

            foreach (string idPallet in selected)
            {
                if (copies % 2 == 0)
                {
                    for (int i = 0; i < copies; i += 2)
                        yield return (idPallet, idPallet);
                }
                else
                {
                    for (int i = 0; i < copies; i += 2)
                    {
                        if (i + 1 < copies)
                            yield return (idPallet, idPallet);
                        else
                            yield return (idPallet, null);
                    }
                }
            }
        }

        private void PrintSmallCodeStrip(
            ClsGenerateStringZplPalletTag genPallet,
            ClsPrintPtiTag print,
            string? idPallet1,
            string? idPallet2,
            bool reverseOrientation,
            bool showDate)
        {
            if (string.IsNullOrWhiteSpace(idPallet1))
                return;

            if (!ClsReprintPallet.TryGetPalletPrintData(idPallet1, out string workPlan1, out int boxes1))
                return;

            ETagInfo eTagInfo1 = new ETagInfo();
            eTagInfo1.SetTagInfo(workPlan1);
            eTagInfo1.showDate = showDate;

            string? idPalletRight = null;
            ETagInfo? eTagInfo2 = null;
            int boxes2 = 0;

            if (!string.IsNullOrWhiteSpace(idPallet2))
            {
                if (ClsReprintPallet.TryGetPalletPrintData(idPallet2, out string workPlan2, out boxes2))
                {
                    idPalletRight = idPallet2;
                    eTagInfo2 = new ETagInfo();
                    eTagInfo2.SetTagInfo(workPlan2);
                    eTagInfo2.showDate = showDate;
                }
            }

            string zpl = genPallet.GenerateSmallCodeStrip(
                idPallet1, eTagInfo1, boxes1,
                idPalletRight, eTagInfo2, boxes2,
                reverseOrientation,
                isReprint: true);

            print.SendToPrintSmallPalletCodeTag(zpl);
        }

        public DataTable GetDTManifestPallets(string idManifest, bool onePalletPerEstiba)
        {
            string qry = "SELECT * FROM vw_PackPalletCon WHERE Manifiesto = @idManifest ORDER BY Posicion";
            var parameters = new Dictionary<string, object> { { "@idManifest", idManifest } };
            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (onePalletPerEstiba)
                dt = FilterOnePalletPerEstiba(dt);

            return EnsureSelectionColumn(dt);
        }

        public DataTable GetDTPalletInfo(string idPallet, bool allPalletsInEstiba)
        {
            string qry = "SELECT * FROM vw_PackPalletCon WHERE Pallet = @idPallet ORDER BY Posicion";
            var parameters = new Dictionary<string, object> { { "@idPallet", idPallet } };
            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);

            if (dt.Rows.Count == 0)
                return dt;

            if (allPalletsInEstiba && dt.Columns.Contains("Estiba"))
            {
                string? estiba = dt.Rows[0]["Estiba"]?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(estiba))
                {
                    string qryEstiba = "SELECT * FROM vw_PackPalletCon WHERE Estiba = @estiba ORDER BY Posicion";
                    var pEstiba = new Dictionary<string, object> { { "@estiba", estiba } };
                    dt = ClsQuerysDB.ExecuteParameterizedQuery(qryEstiba, pEstiba);
                }
            }

            return EnsureSelectionColumn(dt);
        }

        public static DataTable EnsureSelectionColumn(DataTable dt)
        {
            if (dt == null)
                return new DataTable();

            if (!dt.Columns.Contains("Sel"))
            {
                dt.Columns.Add("Sel", typeof(bool));
                dt.Columns["Sel"]!.SetOrdinal(0);
            }

            foreach (DataRow row in dt.Rows)
                row["Sel"] = true;

            return dt;
        }

        private static DataTable FilterOnePalletPerEstiba(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0 || !dt.Columns.Contains("Estiba"))
                return dt;

            DataTable filtered = dt.Clone();
            HashSet<string> seenEstibas = new HashSet<string>();

            foreach (DataRow row in dt.Rows)
            {
                string estiba = row["Estiba"]?.ToString()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(estiba))
                {
                    filtered.ImportRow(row);
                    continue;
                }

                if (seenEstibas.Add(estiba))
                    filtered.ImportRow(row);
            }

            return filtered;
        }
    }
}

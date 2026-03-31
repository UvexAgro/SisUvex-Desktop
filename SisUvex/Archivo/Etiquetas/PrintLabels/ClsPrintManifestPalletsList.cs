using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsPrintManifestPalletsList
    {
        ETagInfo eTag;
        List<string?> lsPallets;

        public void SetManifestPalletsPerPositionList(DataGridView dgvPallets)
        {
            lsPallets = new List<string?>();

            if (dgvPallets == null || dgvPallets.Rows.Count == 0)
            {
                MessageBox.Show("No hay pallets cargados en la grilla.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selColumnIndex = -1;
            if (dgvPallets.Columns["Sel"] != null)
            {
                selColumnIndex = dgvPallets.Columns["Sel"].Index;
            }

            if (selColumnIndex == -1)
            {
                MessageBox.Show("No se encontró la columna 'Sel'.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int palletColumnIndex = -1;
            if (dgvPallets.Columns["Pallet"] != null)
            {
                palletColumnIndex = dgvPallets.Columns["Pallet"].Index;
            }

            if (palletColumnIndex == -1)
            {
                MessageBox.Show("No se encontró la columna 'Pallet'.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool hasSelectedRows = false;

            foreach (DataGridViewRow row in dgvPallets.Rows)
            {
                if (row.Cells[selColumnIndex].Value != null && (bool)row.Cells[selColumnIndex].Value)
                {
                    hasSelectedRows = true;
                    object palletValue = row.Cells[palletColumnIndex].Value;
                    if (palletValue != null && palletValue != DBNull.Value)
                    {
                        lsPallets.Add(palletValue.ToString());
                    }
                }
            }

            if (!hasSelectedRows)
            {
                MessageBox.Show("Debes seleccionar al menos un pallet.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        public void PrintManifestPalletsList(int copies, bool reverseOrientation, bool showDate)
        {
            if (lsPallets == null || lsPallets.Count == 0)
            {
                MessageBox.Show("No hay pallets para imprimir.", "Imprimir listado de pallets en manifiesto.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (string? idPallet in lsPallets)
            {
                if (!string.IsNullOrEmpty(idPallet))
                {
                    ClsReprintPallet.ReprintPalletTag(idPallet, copies, reverseOrientation, true);
                    //MessageBox.Show("clic para siguiente");
                }
            }
        }

        public DataTable GetDTManifestPallets(string idManifest)
        {
            string qry = $"SELECT * FROM vw_PackPalletsManifest WHERE Manifiesto = '{idManifest}' ORDER BY Pos";

            return ClsQuerysDB.GetDataTable(qry);
        }

        public DataTable GetDTPalletInfo(string idPallet)
        {
            string qry = $"SELECT * FROM vw_PackPalletsManifest WHERE id_pallet = '{idPallet}' ORDER BY Pos";

            return ClsQuerysDB.GetDataTable(qry);
        }

        public DataTable GetDTStowInfo(string idStow)
        {
            string qry = $"SELECT * FROM vw_PackPalletsManifest WHERE id_stow = '{idStow}' ORDER BY Pos";

            return ClsQuerysDB.GetDataTable(qry);
        }
    }
}

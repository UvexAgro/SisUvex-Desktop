using Microsoft.IdentityModel.Tokens;
using SisUvex.Archivo.WorkPlan.ConvertPallet;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.WorkPlan.ChangeDistributorPallet
{
    internal class ClsChangeDistributorPallet
    {
        SQLControl sql = new SQLControl();
        public FrmChangeDistributorPallet frm;
        DataTable? dtCboWorkPlan = null;
        DataTable? dtPalletList = null;
        bool palletGridConditionalFormatApplied;
        /// <summary>Coincide con el ValueMember del combo Lote (id_lote|id_variedad).</summary>
        const string ColumnLotCboKey = "lotCboKey";
        const string dateQuery = " REPLACE(FORMAT(wpl.d_workDay, 'MMM-dd', 'es-ES'), '.', '') ";
        const string queryPallet = Pallet.QuerySelectBaseWithStowage;
        public void BeginForm()
        {
            ClsComboBoxes.CboLoadActives(frm.cboSeason, Season.CboWithDates);
            ClsComboBoxes.CboLoadActives(frm.cboDistribuidor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboPresentacion, Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboContainer, Container.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboWorkGroupDuplicate, WorkGroup.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboLot, Lot.Cbo);

            List<(ComboBox Cbo, string IdColumnFilter)> lsWGDep = new();
            lsWGDep.Add((frm.cboSeason, Season.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroup, null, lsWGDep);

            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboWorkGroupDuplicate, null, lsWGDep); //<-- cboWorkGroup de duplicar 

            List<(ComboBox Cbo, string IdColumnFilter)> lsLotDep = new();
            lsLotDep.Add((frm.cboVariety, Variety.ColumnId));
            ClsComboBoxes.Events.CboApplyEventFilterAllForOne(frm.cboLot, null, lsLotDep);

            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbIdPallet);

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboSeason, "08"); // Temporada por defecto

            InitPalletDataGridSchema();
        }
        public void BtnAddPallet(string idPal)
        {
            string idPallet = ClsValues.FormatZeros(idPal, "00000");
            if (frm.dgvPallet.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["Pallet"].Value?.ToString() == idPallet))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            DataTable dtPallet = ClsQuerysDB.GetDataTable(queryPallet + " WHERE vw.Pallet = '" + idPallet + "' ");

            if (dtPallet.Rows.Count < 1)
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string estiba = dtPallet.Rows[0]["Estiba"].ToString();

            if (dtPallet.Rows.Count > 0)
            {
                DataRow newRow = dtPalletList.NewRow();
                newRow.ItemArray = dtPallet.Rows[0].ItemArray;
                dtPalletList.Rows.InsertAt(newRow, 0);
            }
            else
            {
                SystemSounds.Exclamation.Play();

                MessageBox.Show($"El pallet pertenece a un plan de trabajo diferente.", "Convertir pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            frm.txbIdPallet.Focus();
            frm.txbIdPallet.SelectAll();
        }
        public void BtnQuitPallet()
        {
            if (frm.dgvPallet.SelectedRows.Count > 0)
            {
                dtPalletList.Rows.RemoveAt(frm.dgvPallet.SelectedRows[0].Index);

                //if (dtPalletList.Rows.Count == 0)
                //{
                //    ClearFields();
                //}
            }
        }
        void InitPalletDataGridSchema()
        {
            dtPalletList = ClsQuerysDB.GetDataTable($"{queryPallet.Trim()} WHERE 1 = 0");
            frm.dgvPallet.DataSource = dtPalletList;
            ApplyPalletGridPresentation();
        }
        void EnsurePalletGridConditionalFormat()
        {
            if (palletGridConditionalFormatApplied)
                return;
            if (!frm.dgvPallet.Columns.Contains(Pallet.ColumnActive))
                return;

            //ClsDGVCatalog.DgvApplyConditionalRowFormat(frm.dgvPallet, Pallet.ColumnActive, "0", ClsDGVCatalog.CellFormat.soft_inactive);
            palletGridConditionalFormatApplied = true;
        }

        void ApplyPalletGridPresentation()
        {
            Pallet.HideJoinedIdColumns(frm.dgvPallet);
            EnsurePalletGridConditionalFormat();
        }

        private List<string?> GetUniqueGtinValues()
        {
            return ClsDGVValues.GetUniqueColumnValues(frm.dgvPallet, ClsObject.Gtin.ColumnId);
        }
        
        public void pruebaGTIN()
        {
            ShowValuesInDGV(frm.dgvGtines, GetUniqueGtinValues());
        }
        private static void ShowValuesInDGV(DataGridView dgv, List<string?> values)
        {
            DataTable dt = new();

            dt.Columns.Add("Value", typeof(string));

            foreach (string? value in values)
            {
                DataRow row = dt.NewRow();
                row["Value"] = value;
                dt.Rows.Add(row);
            }

            dgv.DataSource = dt;
        }
    }
}

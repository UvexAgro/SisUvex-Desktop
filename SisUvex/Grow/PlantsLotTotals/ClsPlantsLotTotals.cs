
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System.Data;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Grow.PlantsLotTotals
{
    internal class ClsPlantsLotTotals
    {
        public FrmPlantsLotTotals frm;
        DataView? dvLotsList;
        const string cIdFarm = Farm.ColumnId, cFarm = Farm.ColumnName, cIdVariety = Variety.ColumnId, cVariety = Variety.ColumnName, cIdFormation = "idFormation", cFormation = "Tipo Formación", cIdRootStock = "idPatron", cRootStock = "Patron", cUserUpdate = "Modificó", cDateUpdate = "Última modificación", cIdLot = Lot.ColumnId, cLot = Lot.ColumnName, cIdCultivo = Crop.ColumnId, cCultivo = Crop.ColumnName;

        public void BeginFormCat()
        {
            frm.WindowState = FormWindowState.Maximized;

            SetControls();
        }

        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(frm.cboFarm, Farm.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboCrop, Crop.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboVariety, Variety.Cbo);

            List<Tuple<ComboBox, CheckBox?, string>> cboCropDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboCropDepends.Add(new Tuple<ComboBox, CheckBox?, string>(frm.cboVariety, frm.chbVarietyActives, Crop.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(frm.cboCrop, cboCropDepends, null);

            dvLotsList = ClsQuerysDB.GetDataTable(Lot.QueryCbo).DefaultView; //Para el filtro por variedad.

            ClsComboBoxes.CboApplyClickEvent(frm.cboVariety, frm.chbVarietyActives);
        }

        public void BtnLoadDgv()
        {
            string where = " 1=1 ";
            if (frm.cboVariety.SelectedIndex > 0)
            {
                string idVariety = frm.cboVariety.SelectedValue?.ToString() ?? string.Empty;
                where += $" AND T.id_variety = '{idVariety}' ";
            }
            if (frm.cboFarm.SelectedIndex > 0)
            {
                string idFarm = frm.cboFarm.SelectedValue?.ToString() ?? string.Empty;
                where += $" AND lot.id_farm = '{idFarm}' ";
            }
            if (frm.cboCrop.SelectedIndex > 0) {
                string idCrop = frm.cboCrop.SelectedValue?.ToString() ?? string.Empty;
                where += $" AND vrt.id_crop = '{idCrop}' ";
            }

            if (string.IsNullOrWhiteSpace(where)) return;
            DataTable dt = ClsQuerysDB.GetDataTable(GetQueryTotalLot2(where));
            frm.dgvLotTotals.DataSource = dt;

            ShowOrHideColumns(false);
        }
        private List<string> ListColumnsToHide()
        {
            List<string> values = new List<string>();
            values.Add(cIdVariety);
            //values.Add(cVariety);
            //values.Add(cUserUpdate);
            //values.Add(cDateUpdate);
            values.Add(cIdLot);
            //values.Add(cLot);
            values.Add(cIdCultivo);
            //values.Add(cCultivo);
            values.Add(cIdFarm);
            values.Add(cFarm);

            return values;
        }
        public void ShowOrHideColumns(bool show)
        {
            foreach (string columnName in ListColumnsToHide())
            {
                if (frm.dgvLotTotals.Columns.Contains(columnName))
                    frm.dgvLotTotals.Columns[columnName].Visible = show;
            }
        }
        private string GetQueryTotalLot2(string where)
        {
            return @$"SELECT
                            frm.id_farm                     AS [{cIdFarm}],
                            frm.v_farmName                  AS [{cFarm}],
                            vrt.id_crop                     AS [{cIdCultivo}],
                            crop.v_nameCrop                 AS [{cCultivo}],
                            T.id_lot                        AS [{cIdLot}],
                            lot.v_nameLot                   AS [{cLot}],
                            T.id_variety                    AS [{cIdVariety}],
                            vrt.v_nameComercial             AS [{cVariety}],
                            MIN(T.n_lotLine)                AS [Inicio],
                            MAX(T.n_lotLine)                AS [Final],
                            SUM(T.n_plannedPlants)          AS [Totales],
                            SUM(T.n_actualPlants)           AS [Activas],
                            SUM(T.n_failedPlants)           AS [Fallas],
                            SUM(T.n_formationStagePlants)   AS [Formación],
                            FORMAT(MAX(ISNULL(T.d_update, T.d_create)), 'dd-MM-yyyy') AS [U. Actualización],
                            U.LastUser
                        FROM Grow_PlantsRowLot T
                            LEFT JOIN Pack_Variety  vrt ON vrt.id_variety = T.id_variety
                            LEFT JOIN Pack_Crop     crop ON crop.id_crop = vrt.id_crop
                            LEFT JOIN Pack_Lot      lot ON lot.id_lot = T.id_lot AND lot.id_variety = T.id_variety
                            LEFT JOIN Grow_Farm     frm ON frm.id_farm = lot.id_farm
                        --
                        OUTER APPLY
                        (
                            SELECT TOP 1 ISNULL(userUpdate, userCreate) AS LastUser
                            FROM Grow_PlantsRowLot
                            WHERE id_lot = T.id_lot
                            ORDER BY ISNULL(d_update, d_create) DESC
                        ) U

                        WHERE {where}

                        GROUP BY frm.id_farm, frm.v_farmName, T.id_lot, lot.v_nameLot, U.LastUser, crop.v_nameCrop, vrt.v_nameComercial, vrt.id_crop, T.id_variety
                        
                        ORDER BY T.id_lot, [Inicio];";
        }
    }
}

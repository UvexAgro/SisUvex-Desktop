using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using System.Configuration;
using System.Data;
using static iText.Layout.Borders.Border;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Grow.PlantsRowLot
{
    internal class ClsPlantsRowLotView
    {
        public FrmPlantsRowLotView frm;
        DataView? dvLotsList;
        DataTable? dtCboLot;
        string cIdVariety = Variety.ColumnId, cVariety = Variety.ColumnName, cIdFormation = "idFormation", cFormation = "Tipo Formación", cIdRootStock = "idPatron", cRootStock = "Patron", cUserUpdate = "Modificó", cDateUpdate = "Última modificación", cIdLot = Lot.ColumnId, cLotName = Lot.ColumnName;
        public void BeginFormCat()
        {
            frm.WindowState = FormWindowState.Maximized;

            SetControls();

            ClearLotLabels();
        }

        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(frm.cboFarm, Farm.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboCrop, Crop.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboVariety, Variety.Cbo);
            CboLoadActivesLot(frm.cboLot, Lot.CboOnlyNameLotPlantTracking); //Se va a trabajar con el DT

            List<Tuple<ComboBox, CheckBox?, string>> cboCropDepends = new List<Tuple<ComboBox, CheckBox?, string>>();
            cboCropDepends.Add(new Tuple<ComboBox, CheckBox?, string>(frm.cboVariety, frm.chbVarietyActives, Crop.ColumnId));
            ClsComboBoxes.CboApplyEventCboSelectedValueChangedWithCboDependensColumn(frm.cboCrop, cboCropDepends, null);

            dvLotsList = ClsQuerysDB.GetDataTable(Lot.QueryCbo).DefaultView; //Para el filtro por variedad.

            ClsComboBoxes.CboApplyClickEvent(frm.cboVariety, frm.chbVarietyActives);

            frm.cboVariety.SelectedValueChanged += (s, e) => SetDtLots();
            frm.cboFarm.SelectedValueChanged += (s, e) => SetDtLots();
            frm.chbLotActives.CheckedChanged += (s, e) => SetDtLots();
        }

        private void CboLoadActivesLot(ComboBox cboLot, string LotCatalogName)
        {// Es el mismo metodo de ClsComboBoxes.CboLoadActives pero ajustado para este cboLot
            dtCboLot = ClsComboBoxes.GetCboCatalogDataTable(LotCatalogName);
            if (dtCboLot.Columns.Contains(Column.active))
                dtCboLot.DefaultView.RowFilter = $"{Column.active} = '1'";
            ClsComboBoxes.LoadComboBoxDataSource(cboLot, dtCboLot);
        }

        public void SetDtLots()
        {
            if (dtCboLot == null || dvLotsList == null) return;

            string dtCboLotFilter = " 1=1 ";

            if (frm.cboVariety.SelectedIndex < 1)
                dvLotsList.RowFilter = ""; // sin filtro
            else
            {
                string idVariety = frm.cboVariety.SelectedValue?.ToString() ?? string.Empty;

                dvLotsList.RowFilter = $"{Variety.ColumnId} = '{idVariety}'";

                // 4) Sacar ids de lotes filtrados
                List<string?> ids = dvLotsList.Cast<DataRowView>().Select(r => r[Lot.ColumnId]?.ToString()).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

                // 5) Aplicar filtro IN al DataTable de plantas
                if (ids.Any())
                {
                    // escapar comillas por seguridad
                    var safeIds = ids.Select(x => x.Replace("'", "''")).ToList();

                    dtCboLotFilter += $" AND {Column.id} IN ('{string.Join("','", safeIds)}')";
                }
                else
                {
                    dtCboLotFilter = " 1=0 ";
                }
            }

            if (!frm.chbLotActives.Checked) //Mostrar o no activos por CheckBox Lotes
                dtCboLotFilter += $" AND {Column.active} = '1' ";

            if (frm.cboFarm.SelectedIndex > 0) //Filtrar por campo
            {
                string idFarm = frm.cboFarm.SelectedValue?.ToString() ?? string.Empty;
                dtCboLotFilter += $" AND {Farm.ColumnId} = '{idFarm}' ";
            }

            dtCboLotFilter += $" OR {frm.cboLot.DisplayMember} = '{ClsComboBoxes.textSelect}' "; //Dejarle el "---Seleccionar---" siempre

            dtCboLot.DefaultView.RowFilter = dtCboLotFilter;
        }

        public void BtnLoadPlantsLot()
        {
            string idLot = frm.cboLot.SelectedValue?.ToString() ?? string.Empty;

            SetLabelsLotInfo(idLot);

            SetDgvLotPlants(idLot);
        }

        private void SetLabelsLotInfo(string idLot)
        {
            DataTable dtLabels = ClsQuerysDB.GetDataTable(GetQueryTotalLot(idLot));

            if (dtLabels == null || dtLabels.Rows.Count == 0)
            {
                ClearLotLabels(); // opcional
                return;
            }

            DataRow r = dtLabels.Rows[0];

            frm.lblIdLot.Text = r["Lot"]?.ToString() ?? "";
            frm.lblNameLot.Text = (string)frm.cboLot.GetColumnValue(Lot.ColumnName); //Lo jala del combobox
            frm.lblStart.Text = r["StartLine"]?.ToString() ?? "";
            frm.lblFinal.Text = r["EndLine"]?.ToString() ?? "";

            frm.lblPlantsTotal.Text = r["Total_Plants"].ToString() ?? "";
            frm.lblPlantsEfective.Text = r["Actual_Plants"].ToString() ?? "";
            frm.lblPlantsFail.Text = r["Failed_Plants"].ToString() ?? "";
            frm.lblFormation.Text = r["Formation_Stage_Plants"].ToString() ?? "";

            frm.lblLastUpdate.Text = r["LastUpdate"]?.ToString() ?? "";
            frm.lblUserUpdate.Text = r["LastUser"]?.ToString() ?? "";
        }

        private void SetDgvLotPlants(string idLot)
        {
            DataTable? dtLabels = ClsQuerysDB.GetDataTable(GetQueryPlantsLot(idLot));

            frm.dgvPlants.DataSource = dtLabels;

            ShowOrHideColumns(frm.chbShowOrHideColumns.Checked);
        }

        private string GetQueryTotalLot(string idLot)
        {
            return @$"   SELECT
                            T.id_lot AS Lot,
                            MIN(T.n_lotLine) AS StartLine,
                            MAX(T.n_lotLine) AS EndLine,
                            SUM(T.n_plannedPlants) AS Total_Plants,
                            SUM(T.n_actualPlants) AS Actual_Plants,
                            SUM(T.n_failedPlants) AS Failed_Plants,
                            SUM(T.n_formationStagePlants) AS Formation_Stage_Plants,
                            FORMAT(MAX(ISNULL(T.d_update, T.d_create)), 'yyyy-MMM-dd', 'es-MX') AS LastUpdate,
                            U.LastUser
                        FROM Grow_PlantsRowLot T
                        --
                        OUTER APPLY
                        (
                            SELECT TOP 1 ISNULL(userUpdate, userCreate) AS LastUser
                            FROM Grow_PlantsRowLot
                            WHERE id_lot = T.id_lot
                            ORDER BY ISNULL(d_update, d_create) DESC
                        ) U

                        WHERE T.id_lot = '{idLot}'

                        GROUP BY T.id_lot, U.LastUser;";
        }
        private List<string> ListColumnsToHide()
        {
            List<string> values = new List<string>();

            values.Add(cIdFormation);
            //values.Add(cFormation);
            values.Add(cIdRootStock);
            //values.Add(cRootStock);
            values.Add(cIdVariety);
            //values.Add(cVariety);
            values.Add(cUserUpdate);
            values.Add(cDateUpdate);
            values.Add(cIdLot);
            values.Add(cLotName);

            return values;
        }
        public void ShowOrHideColumns(bool show)
        {
            foreach (string columnName in ListColumnsToHide())
            {
                if (frm.dgvPlants.Columns.Contains(columnName))
                    frm.dgvPlants.Columns[columnName].Visible = show;
            }
        }
        private string GetQueryPlantsLot(string idLot)
        {
            return @$"   SELECT 
	                        grow.n_lotLine AS [Línea],
	                        grow.n_plannedPlants AS [Total],
	                        grow.n_actualPlants AS [Activas],
	                        grow.n_failedPlants AS [Fallas],
	                        grow.n_formationStagePlants AS [Formación],
	                        grow.id_formation AS [{cIdFormation}],
	                        frm.v_nameFormation AS [{cFormation}],
	                        grow.id_rootstock AS [{cIdRootStock}],
	                        rot.v_nameRootstock AS [{cRootStock}],
	                        grow.id_variety AS [{cIdVariety}],
	                        vrt.v_nameComercial AS [{cVariety}],
	                        ISNULL(grow.userUpdate, grow.userCreate) AS [{cUserUpdate}],
	                        ISNULL(grow.d_update, grow.d_create) AS [{cDateUpdate}],
	                        grow.id_lot AS [{cIdLot}],
	                        lot.v_nameLot AS [{cLotName}]

                        FROM Grow_PlantsRowLot grow
                        left JOIN Pack_Lot lot ON lot.id_lot = grow.id_lot AND lot.id_variety = grow.id_variety
                        left JOIN Pack_Variety vrt ON vrt.id_variety = grow.id_variety
                        LEFT JOIN Grow_FormationType frm ON frm.id_formation = grow.id_formation
                        LEFT JOIN Grow_Rootstock rot ON rot.id_rootstock = grow.id_rootstock
                        WHERE
	                        grow.id_lot = '{idLot}'
                        ORDER BY grow.id_lot, grow.n_lotLine";
        }
        private void ClearLotLabels()
        {
            frm.lblNameLot.Text = "";
            frm.lblIdLot.Text = "";
            frm.lblStart.Text = "";
            frm.lblFinal.Text = "";
            frm.lblPlantsTotal.Text = "";
            frm.lblPlantsEfective.Text = "";
            frm.lblPlantsFail.Text = "";
            frm.lblFormation.Text = "";
            frm.lblLastUpdate.Text = "";
            frm.lblUserUpdate.Text = "";
        }
    }
}
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
        DataView? _dvPlants;
        string _loadedCropId = "";
        string _loadedVarietyId = "";
        const string cIdVariety = Variety.ColumnId, cVariety = Variety.ColumnName, cIdFormation = "idFormation", cFormation = "Tipo Formación", cIdRootStock = "idPatron", cRootStock = "Patron", cUserUpdate = "Modificó", cDateUpdate = "Última modificación", cIdLot = Lot.ColumnId, cLotName = Lot.ColumnName, cIdCultivo = Crop.ColumnId, cCultivo = Crop.ColumnName;
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

            frm.chbDgvCrop.Enabled = false;
            frm.chbDgvVariety.Enabled = false;
            frm.chbDgvCrop.Checked = false;
            frm.chbDgvVariety.Checked = false;
            frm.chbDgvCrop.CheckedChanged += (s, e) => ApplyDgvPlantsFilter();
            frm.chbDgvVariety.CheckedChanged += (s, e) => ApplyDgvPlantsFilter();
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

            frm.dgvLotTotals.DataSource = ClsQuerysDB.GetDataTable(GetQueryTotalLot2(idLot));

            SetDgvLotPlants(idLot);


        }

        private void SetLabelsLotInfo(string idLot)
        {
            //DataTable dtLabels = ClsQuerysDB.GetDataTable(GetQueryTotalLot(idLot));

            //if (dtLabels == null || dtLabels.Rows.Count == 0)
            //{
                ClearLotLabels(); // opcional
            //    return;
            //}

            //DataRow r = dtLabels.Rows[0];

            //frm.lblIdLot.Text = r["Lot"]?.ToString() ?? "";
            frm.lblIdLot.Text = (string)frm.cboLot.GetColumnValue(Column.id);
            frm.lblNameLot.Text = (string)frm.cboLot.GetColumnValue(Lot.ColumnName); //Lo jala del combobox
            //frm.lblStart.Text = r["StartLine"]?.ToString() ?? "";
            //frm.lblFinal.Text = r["EndLine"]?.ToString() ?? "";

            //frm.lblPlantsTotal.Text = r["Total_Plants"].ToString() ?? "";
            //frm.lblPlantsEfective.Text = r["Actual_Plants"].ToString() ?? "";
            //frm.lblPlantsFail.Text = r["Failed_Plants"].ToString() ?? "";
            //frm.lblFormation.Text = r["Formation_Stage_Plants"].ToString() ?? "";

            //frm.lblLastUpdate.Text = r["LastUpdate"]?.ToString() ?? "";
            //frm.lblUserUpdate.Text = r["LastUser"]?.ToString() ?? "";
        }

        private void SetDgvLotPlants(string idLot)
        {
            DataTable? dt = ClsQuerysDB.GetDataTable(GetQueryPlantsLot(idLot));
            if (dt == null)
            {
                frm.dgvPlants.DataSource = null;
                _dvPlants = null;
                return;
            }

            _dvPlants = dt.DefaultView;
            frm.dgvPlants.DataSource = _dvPlants;

            _loadedCropId = frm.cboCrop.SelectedValue?.ToString() ?? "";
            _loadedVarietyId = frm.cboVariety.SelectedValue?.ToString() ?? "";

            bool multipleCrops = dt.AsEnumerable().Select(r => r[cIdCultivo]?.ToString()).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().Count() > 1;
            bool multipleVarieties = dt.AsEnumerable().Select(r => r[cIdVariety]?.ToString()).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().Count() > 1;

            frm.chbDgvCrop.Enabled = multipleCrops && frm.cboCrop.SelectedIndex > 0;
            frm.chbDgvVariety.Enabled = multipleVarieties && frm.cboVariety.SelectedIndex > 0;
            frm.chbDgvCrop.Checked = false;
            frm.chbDgvVariety.Checked = false;

            ApplyDgvPlantsFilter();
            ShowOrHideColumns(frm.chbShowOrHideColumns.Checked);
        }

        private void ApplyDgvPlantsFilter()
        {
            if (_dvPlants == null) return;

            var parts = new List<string>();
            if (!frm.chbDgvCrop.Checked && !string.IsNullOrWhiteSpace(_loadedCropId))
            {
                string safe = _loadedCropId.Replace("'", "''");
                parts.Add($"{cIdCultivo} = '{safe}'");
            }
            if (!frm.chbDgvVariety.Checked && !string.IsNullOrWhiteSpace(_loadedVarietyId))
            {
                string safe = _loadedVarietyId.Replace("'", "''");
                parts.Add($"{cIdVariety} = '{safe}'");
            }
            _dvPlants.RowFilter = parts.Count > 0 ? string.Join(" AND ", parts) : "";
        }

        private string GetQueryTotalLot(string idLot)
        {
            return @$"   SELECT
                            T.id_lot AS Lot,
                            MIN(T.n_lotLine) AS StartLine,
                            MAX(T.n_lotLine) AS EndLine,
                            SUM(T.n_plannedPlants) AS Target_Plants,
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
        private string GetQueryTotalLot2(string idLot)
        {
            return @$"SELECT
                            --T.id_lot                      AS [{cIdLot}],
                            crop.v_nameCrop                 AS [{cCultivo}],
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
                            LEFT JOIN Pack_Variety vrt ON vrt.id_variety = T.id_variety
                            LEFT JOIN Pack_Crop crop ON crop.id_crop = vrt.id_crop

                        --
                        OUTER APPLY
                        (
                            SELECT TOP 1 ISNULL(userUpdate, userCreate) AS LastUser
                            FROM Grow_PlantsRowLot
                            WHERE id_lot = T.id_lot
                            ORDER BY ISNULL(d_update, d_create) DESC
                        ) U

                        WHERE T.id_lot = '{idLot}'

                        GROUP BY T.id_lot, U.LastUser, crop.v_nameCrop, vrt.v_nameComercial
                        
                        ORDER BY Inicio;";
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
            values.Add(cIdCultivo);
            values.Add(cCultivo);

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
	                        grow.n_plannedPlants AS [Objetivo],
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
	                        lot.v_nameLot AS [{cLotName}],
	                        vrt.id_crop AS [{cIdCultivo}],
	                        crop.v_nameCrop AS [{cCultivo}]
                        FROM Grow_PlantsRowLot grow
                            left JOIN Pack_Lot lot ON lot.id_lot = grow.id_lot AND lot.id_variety = grow.id_variety
                            left JOIN Pack_Variety vrt ON vrt.id_variety = grow.id_variety
                            LEFT JOIN Grow_FormationType frm ON frm.id_formation = grow.id_formation
                            LEFT JOIN Grow_Rootstock rot ON rot.id_rootstock = grow.id_rootstock
                            LEFT JOIN Pack_Crop crop ON crop.id_crop = vrt.id_crop 
                        WHERE
	                        grow.id_lot = '{idLot}'
                        ORDER BY grow.id_lot, grow.n_lotLine";
        }
        private void ClearLotLabels()
        {
            frm.lblNameLot.Text = "";
            frm.lblIdLot.Text = "";
            //frm.lblStart.Text = "";
            //frm.lblFinal.Text = "";
            //frm.lblPlantsTotal.Text = "";
            //frm.lblPlantsEfective.Text = "";
            //frm.lblPlantsFail.Text = "";
            //frm.lblFormation.Text = "";
            //frm.lblLastUpdate.Text = "";
            //frm.lblUserUpdate.Text = "";
        }

        public void BtnGenerateExcelReport()
        {
            // Validar que haya datos cargados
            if (_dvPlants == null || _dvPlants.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show(
                    "No hay datos de plantas cargados para generar el reporte.\n\n" +
                    "Por favor, carga los datos del lote primero.",
                    "Sin datos",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information
                );
                return;
            }

            // Validar que haya un lote seleccionado
            if (frm.cboLot.SelectedIndex < 1)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Debe seleccionar un lote para generar el reporte.",
                    "Lote requerido",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning
                );
                return;
            }

            // Obtener idLot y nombre del lote
            string idLot = frm.cboLot.SelectedValue?.ToString() ?? string.Empty;
            string lotName = frm.cboLot.GetColumnValue(Lot.ColumnName)?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(idLot))
            {
                System.Windows.Forms.MessageBox.Show(
                    "No se pudo obtener el código del lote seleccionado.",
                    "Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error
                );
                return;
            }

            // Crear instancia de la clase de Excel y generar reporte.
            // Usar vista sin filtro para que la primera tabla muestre todas las líneas del lote (no lo filtrado en el DGV).
            DataView dvFullPlants = new DataView(_dvPlants.Table) { RowFilter = "" };
            ClsExcelPlantsRowLotView excelGenerator = new ClsExcelPlantsRowLotView();
            excelGenerator.GenerateExcelReport(dvFullPlants, idLot, lotName);
        }
    }
}
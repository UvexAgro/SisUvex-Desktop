using Org.BouncyCastle.Asn1.BC;
using SisUvex.Catalogos.Lot;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Grow.PlantsRowLot
{
    internal class ClsPlantsRowLotView
    {
        public FrmPlantsRowLotView frm;
        DataView? dvLotsList;
        DataTable? dtCboLot;
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

        public void SetDgvPlants()
        {
            string idLot = frm.cboLot.SelectedValue?.ToString() ?? string.Empty;
            MessageBox.Show($"Aquí se cargarían las plantas del lote con id: {idLot}");


        }
    }
}
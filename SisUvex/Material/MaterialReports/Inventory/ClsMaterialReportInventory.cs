using iText.Kernel.Pdf;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Material.MaterialReports.Inventory
{
    internal class ClsMaterialReportInventory
    {
        public FrmMaterialReportInventory frm;
        private string query;
        public void BeginForm()
        {
            ClsComboBoxes.CboLoadAll(frm.cboMaterialType, ClsObject.MaterialType.Cbo);

            ClsComboBoxes.CboLoadActives(frm.cboMaterial, ClsObject.MaterialCatalog.Cbo);

        }
        public void LoadInventory()
        {
            string qry = string.Empty;

            Dictionary<string, object> parameters = new();

            if (frm.cboMaterialType.SelectedIndex > 0)
            {
                qry += " AND mat.id_distributor = @idDistributor ";
                parameters.Add("@idDistributor", frm.cboMaterialType.SelectedValue);
            }

            if (frm.cboMaterial.SelectedIndex > 0)
            {
                qry += " AND mat.id_distributor = @idDistributor ";
                parameters.Add("@idGrower", frm.cboMaterial.SelectedValue);
            }

            frm.dgvQuery.DataSource = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
        }
    }
}

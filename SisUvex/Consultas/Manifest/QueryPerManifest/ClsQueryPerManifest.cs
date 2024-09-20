using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Consultas.Manifest.QueryPerManifest
{
    internal class ClsQueryPerManifest
    {
        public FrmQueryPerManifest frm;
        DataTable dtManifests = null;
        string whereQuery = " WHERE pal.id_manifest IS NOT NULL ";

        string qryPresentationPerDay = " SELECT man.id_manifest AS 'Manifiesto'," +
            " FORMAT(man.d_shipment, 'yy-MMM-dd') AS 'Fecha'," +
            " frc.v_ecoNumber AS 'Caja R.'," +
            " gro.v_nameGrower AS 'Productor'," +
            " dis.v_nameDistributor AS 'Distribuidor'," +
            " [var].v_nameComercial AS 'Variedad'," +
            " siz.v_sizeValue AS 'Tamaño'," +
            " con.v_nameContainer AS 'Contenedor'," +
            " CONCAT_WS(' ', gtn.v_preLabel, pre.v_namePresentation, gtn.v_postLabel) AS 'Presentación'," +
            " CAST(gtn.n_lbs AS FLOAT) AS 'Libras', SUM(pal.i_boxes) AS 'Cajas'," +
            " SUM(pal.n_kg) AS 'Kilos totales'" +
            " FROM Pack_Manifest man " +
            " LEFT JOIN dbo.Pack_FreightContainer AS frc ON frc.id_freightContainer = man.id_freightContainer " +
            " LEFT JOIN dbo.Pack_Grower AS gro ON gro.id_grower = man.id_grower LEFT JOIN dbo.Pack_Distributor AS dis ON dis.id_distributor = man.id_distributor " +
            " LEFT JOIN dbo.Pack_Pallet AS pal ON pal.id_manifest = man.id_manifest " +
            " LEFT JOIN dbo.Pack_WorkPlan AS wpl ON wpl.id_workPlan = pal.id_workPlan " +
            " LEFT JOIN dbo.Pack_WorkGroup AS wgp ON wgp.id_workGroup = wpl.id_workGroup " +
            " LEFT JOIN dbo.Pack_Contractor AS ctr ON ctr.id_contractor = wgp.id_contractor " +
            " LEFT JOIN dbo.Pack_Size AS siz ON siz.id_size = wpl.id_size " +
            " LEFT JOIN dbo.Pack_GTIN AS gtn ON gtn.id_GTIN = wpl.id_GTIN " +
            " LEFT JOIN dbo.Pack_Presentation AS pre ON pre.id_presentation = gtn.id_presentation " +
            " LEFT JOIN dbo.Pack_Container AS con ON con.id_container = gtn.id_container " +
            " LEFT JOIN dbo.Pack_Variety AS [var] ON [var].id_variety = gtn.id_variety " +
            " LEFT JOIN dbo.Pack_Price AS prc ON prc.id_price = gtn.id_price " +
            " LEFT JOIN dbo.Pack_PtiType AS pti ON pti.id_pti = gtn.id_pti " +
            " LEFT JOIN dbo.Pack_Lot AS lot ON lot.id_lot = wpl.id_lot AND lot.id_variety = gtn.id_variety " +
            " LEFT JOIN dbo.Pack_Crop AS cro ON cro.id_crop = [var].id_crop " +
            " LEFT JOIN dbo.Pack_Color AS col ON col.id_color = [var].id_color  ";

        string gpbPresentationPerDay = " GROUP BY man.d_shipment, dis.id_distributor, pre.id_presentation, [var].id_variety, dis.v_nameDistShort,con.v_nameContainer, gtn.n_lbs, gtn.v_preLabel, pre.v_namePresentation, [var].v_nameComercial, gtn.v_postLabel, dis.v_nameDistributor, man.id_manifest, frc.v_ecoNumber, gro.v_nameGrower, siz.v_sizeValue ";
        string orderBy = " ORDER BY man.id_manifest ";
        public void LoadForm()
        {
            ClsComboBoxes.CboLoadActives(frm.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboContainer, ClsObject.Container.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboGrower, ClsObject.Grower.Cbo);

            SetCatalogPresentationBeetweenDays();
        }

        public void SetCatalogPresentationBeetweenDays()
        {
            string where = whereQuery + " AND man.d_shipment BETWEEN '" + GetDay1() + "' AND '" + GetDay2() + "' ";

            if (frm.cboDistributor.SelectedIndex > 0)
                where += " AND dis.id_distributor = " + frm.cboDistributor.SelectedValue;

            if (frm.cboGrower.SelectedIndex > 0)
                where += " AND gro.id_grower = " + frm.cboGrower.SelectedValue;

            if (frm.cboContainer.SelectedIndex > 0)
                where += " AND con.id_container = " + frm.cboContainer.SelectedValue;

            if (frm.cboVariety.SelectedIndex > 0)
                where += " AND [var].id_variety = " + frm.cboVariety.SelectedValue;

            dtManifests = ClsQuerysDB.GetDataTable(qryPresentationPerDay + where + gpbPresentationPerDay + orderBy);
            frm.dgvQuery.DataSource = dtManifests;
        }

        private string GetDay1()
        {
            return frm.dtpDate1.Value.ToString("yyyy-MM-dd");
        }
        private string GetDay2()
        {
            return frm.dtpDate2.Value.ToString("yyyy-MM-dd");
        }

        public void BtnAll()
        {
            frm.cboDistributor.SelectedIndex = 0;
            frm.cboContainer.SelectedIndex = 0;
            frm.cboVariety.SelectedIndex = 0;
            frm.cboGrower.SelectedIndex = 0;
            frm.dtpDate1.Value = DateTime.Now;
            frm.dtpDate2.Value = DateTime.Now;
            SetCatalogPresentationBeetweenDays();
        }

        public void BtnManifest()
        {
            frm.cboContainer.SelectedIndex = 0;
            frm.cboDistributor.SelectedIndex = 0;
            frm.cboGrower.SelectedIndex = 0;
            frm.cboVariety.SelectedIndex = 0;

            string where = " WHERE man.id_manifest = '" + frm.txbManifest.Text;

            dtManifests = ClsQuerysDB.GetDataTable(qryPresentationPerDay + where + "' " + gpbPresentationPerDay + orderBy);
            frm.dgvQuery.DataSource = dtManifests;
        }
    }
}

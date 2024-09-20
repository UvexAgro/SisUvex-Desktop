using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Consultas.Manifest
{
    internal class ClsManifestQuery
    {
        public FrmManifestQuery frm;
        DataTable dtManifests = null;
        string whereQuery = " WHERE pal.id_manifest IS NOT NULL ";
        string qryPresentationPerDay = "SELECT dis.v_nameDistributor AS 'Distribuidor',\r\n\tCONCAT_WS(' ',con.v_nameContainer+FORMAT(gtn.n_lbs,'0'),gtn.v_preLabel,pre.v_namePresentation,[var].v_nameComercial,gtn.v_postLabel) AS 'Presentación',\r\n\tSUM(pal.i_boxes) Cajas\r\nFROM Pack_Pallet pal\r\n\tLEFT JOIN dbo.Pack_WorkPlan AS wpl ON wpl.id_workPlan = pal.id_workPlan\r\n\tLEFT JOIN dbo.Pack_WorkGroup AS wgp ON wgp.id_workGroup = wpl.id_workGroup \r\n\tLEFT JOIN dbo.Pack_Contractor AS ctr ON ctr.id_contractor = wgp.id_contractor \r\n\tLEFT JOIN dbo.Pack_Size AS siz ON siz.id_size = wpl.id_size \r\n\tLEFT JOIN dbo.Pack_GTIN AS gtn ON gtn.id_GTIN = wpl.id_GTIN \r\n\tLEFT JOIN dbo.Pack_Presentation AS pre ON pre.id_presentation = gtn.id_presentation \r\n\tLEFT JOIN dbo.Pack_Container AS con ON con.id_container = gtn.id_container \r\n\tLEFT JOIN dbo.Pack_Variety AS [var] ON [var].id_variety = gtn.id_variety \r\n\tLEFT JOIN dbo.Pack_Distributor AS dis ON dis.id_distributor = gtn.id_distributor \r\n\tLEFT JOIN dbo.Pack_Price AS prc ON prc.id_price = gtn.id_price \r\n\tLEFT JOIN dbo.Pack_PtiType AS pti ON pti.id_pti = gtn.id_pti \r\n\tLEFT JOIN dbo.Pack_Lot AS lot ON lot.id_lot = wpl.id_lot AND lot.id_variety = gtn.id_variety\r\n\tLEFT JOIN dbo.Pack_Crop AS cro ON cro.id_crop = [var].id_crop\r\n\tLEFT JOIN dbo.Pack_Color AS col ON col.id_color = [var].id_color ";
        string gpbPresentationPerDay = " GROUP BY  dis.v_nameDistShort,con.v_nameContainer, gtn.n_lbs, gtn.v_preLabel, pre.v_namePresentation, [var].v_nameComercial, gtn.v_postLabel, dis.v_nameDistributor ";

        public void LoadForm()
        {
            ClsComboBoxes.CboLoadActives(frm.cboDistributor, ClsObject.Distributor.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboPresentation, ClsObject.Presentation.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboVariety, ClsObject.Variety.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboGrower, ClsObject.Grower.Cbo);

            SetCatalogPresentationBeetweenDays();
        }

        public void SetCatalogPresentationBeetweenDays()
        {
            string where = whereQuery + " AND pal.d_packed BETWEEN '" + GetDay1() + "' AND '" + GetDay2() + "' ";

            if (frm.cboDistributor.SelectedIndex > 0)
                where += " AND dis.id_distributor = " + frm.cboDistributor.SelectedValue;

            if (frm.cboGrower.SelectedIndex > 0)
                where += " AND gro.id_grower = " + frm.cboGrower.SelectedValue;

            if (frm.cboPresentation.SelectedIndex > 0)
                where += " AND pre.id_presentation = " + frm.cboPresentation.SelectedValue;

            if (frm.cboVariety.SelectedIndex > 0)
                where += " AND [var].id_variety = " + frm.cboVariety.SelectedValue;

            dtManifests = ClsQuerysDB.GetDataTable(qryPresentationPerDay + where + gpbPresentationPerDay);
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
            frm.cboPresentation.SelectedIndex = 0;
            frm.cboGrower.SelectedIndex = 0;
            frm.cboVariety.SelectedIndex = 0;
            frm.dtpDate1.Value = DateTime.Now;
            frm.dtpDate2.Value = DateTime.Now;
            SetCatalogPresentationBeetweenDays();
        }

        public void BtnManifest()
        {
            frm.cboDistributor.SelectedIndex = 0;
            frm.cboPresentation.SelectedIndex = 0;
            frm.cboGrower.SelectedIndex = 0;
            frm.cboVariety.SelectedIndex = 0;

            string where = " WHERE pal.id_manifest = '" + frm.txbManifest.Text;

            dtManifests = ClsQuerysDB.GetDataTable(qryPresentationPerDay + where + "' "+ gpbPresentationPerDay);
            frm.dgvQuery.DataSource = dtManifests;
        }
    }
}

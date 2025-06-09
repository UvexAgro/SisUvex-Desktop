using System.Data;
using System.Media;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Nomina.Actualizar_datos_empelado;
using static SisUvex.Catalogos.Metods.ClsObject;


namespace SisUvex.Archivo.Etiquetas.PrintLabels
{
    internal class ClsPrintLabelsPtiPallets
    {

        public FrmPrintLabelsPtiPallets frm;
        private ClsPrintPtiTag print;
        public DataTable? dtWorkPlan;
        public ETagInfo eTagInfo = new ETagInfo();

        DataTable? dtLastPallets = null;
        string queryLastPallets = $"SELECT TOP(10) pal.id_pallet AS 'Pallet', pal.i_boxes AS 'Cajas', CONCAT(con.v_nameContainer,CAST(gtn.n_lbs AS float)) AS 'Contenedor', CONCAT_WS(' ', siz.v_sizeValue, gtn.v_preLabel, pre.v_namePresentation, gtn.v_postLabel) AS 'Presentación', [var].v_shortName AS 'Variedad', dis.v_nameDistShort AS 'Distribuidor', CONCAT_WS(' ', wgp.id_workGroup, ctr.v_nameContractor) AS 'Cuadrilla', CONCAT(lot.v_nameLot, ' (',lot.id_lot,')') AS 'Lote', pal.id_workPlan AS 'Plan' FROM dbo.Pack_Pallet AS pal LEFT JOIN dbo.Pack_WorkPlan AS wpl ON wpl.id_workPlan = pal.id_workPlan LEFT JOIN dbo.Pack_WorkGroup AS wgp ON wgp.id_workGroup = wpl.id_workGroup LEFT JOIN dbo.Pack_Contractor AS ctr ON ctr.id_contractor = wgp.id_contractor LEFT JOIN dbo.Pack_Size AS siz ON siz.id_size = wpl.id_size LEFT JOIN dbo.Pack_GTIN AS gtn ON gtn.id_GTIN = wpl.id_GTIN LEFT JOIN dbo.Pack_Distributor AS dis ON dis.id_distributor = gtn.id_distributor LEFT JOIN dbo.Pack_Presentation AS pre ON pre.id_presentation = gtn.id_presentation LEFT JOIN dbo.Pack_Container AS con ON con.id_container = gtn.id_container LEFT JOIN dbo.Pack_Variety AS [var] ON [var].id_variety = gtn.id_variety LEFT JOIN dbo.Pack_Price AS prc ON prc.id_price = gtn.id_price LEFT JOIN dbo.Pack_PtiType AS pti ON pti.id_pti = gtn.id_pti LEFT JOIN dbo.Pack_Lot AS lot ON lot.id_lot = wpl.id_lot AND lot.id_variety = gtn.id_variety LEFT JOIN dbo.Pack_Crop AS cro ON cro.id_crop = [var].id_crop LEFT JOIN dbo.Pack_Color AS col ON col.id_color = [var].id_color WHERE pal.userCreate = '{User.GetLastUser()}' ORDER BY id_pallet DESC";

        private const int timesPalletPrint = 2;
        
        private string GetFilterDayWG()
        {
            return $"{Column.active} = '1' AND {WorkGroup.ColumnId} = '{frm.cboWorkGroup.SelectedValue}' AND {ClsObject.WorkPlan.ColumnDate} = '{frm.dtpWorkDay.Value.ToString("yyyy-MM-dd")}' OR {Column.name} = '{ClsObject.String.SelectText}'";
        }

        public void LoadFormPrintLabels()
        {
            frm.cboWorkGroup.TextChanged -= (sender, e) => { };
            frm.cboWorkPlan.TextChanged -= (sender, e) => { };
            frm.dtpWorkDay.ValueChanged -= (sender, e) => { };

            ClsComboBoxes.CboLoadActives(frm.cboWorkGroup, WorkGroup.Cbo);
            
            dtWorkPlan = ClsComboBoxFiles.GetCboCatalogDataTable(ClsObject.WorkPlan.CboPresentation);
            dtWorkPlan.DefaultView.RowFilter = GetFilterDayWG();
            ClsComboBoxes.LoadComboBoxDataSource(frm.cboWorkPlan, dtWorkPlan);

            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbBoxesTotaL);
            ClsTextBoxes.TxbApplyKeyPressEventInt(frm.txbInvoice);
            ApplyEventComboBoxPrintLabels(frm.cboWorkGroup);
            ApplyEventDateTimePickerPrintLabels(frm.dtpWorkDay);
            ApplyEventComboBoxWorkPlanPrintLabels(frm.cboWorkPlan);
            
            LoadDgvLastPallets();
        }
        public void ApplyEventComboBoxPrintLabels(ComboBox comboBox)
        {
            comboBox.TextChanged += (sender, e) =>
            {
                dtWorkPlan.DefaultView.RowFilter = GetFilterDayWG();

                frm.cboWorkPlan.SelectedIndex = 0;

            };
        }
        public void ApplyEventDateTimePickerPrintLabels(DateTimePicker dateTimePicker)
        {
            dateTimePicker.ValueChanged += (sender, e) =>
            {
                dtWorkPlan.DefaultView.RowFilter = GetFilterDayWG();
                frm.cboWorkPlan.SelectedIndex = 0;
            }; 
        }
        public void ApplyEventComboBoxWorkPlanPrintLabels(ComboBox comboBox)
        {
            comboBox.TextChanged += (sender, e) =>
            {
                if (frm.cboWorkPlan.SelectedValue != null)
                    SetTagInfo(frm.cboWorkPlan.SelectedValue.ToString(), eTagInfo);
                    LoadTagInfoInLabelsForm();
            };
        }
        private void LoadTagInfoInLabelsForm()
        {
            frm.lblLotId.Text               = eTagInfo.idLot;
            frm.lblLotName.Text             = eTagInfo.nameLot;
            frm.lblVarietyName.Text         = eTagInfo.nameVariety;
            frm.lblColorName.Text           = eTagInfo.nameColor;
            frm.lblDistributorName.Text     = eTagInfo.nameDistributor;
            frm.lblDistributorAddress.Text  = eTagInfo.addressDistributor;
            frm.lblDistributorCity.Text     = eTagInfo.cityDistributor;
            frm.lblContainerName.Text       = eTagInfo.nameContainer;
            frm.lblLbsNum.Text              = eTagInfo.Lbs;
            frm.lblSizeName.Text            = eTagInfo.nameSize;
            frm.txbBoxesTotaL.Text          = eTagInfo.palletBoxes;
            frm.lblPtiId.Text               = eTagInfo.idPti;
            frm.lblPtiName.Text             = eTagInfo.namePti;
            frm.lblGtinNumber.Text          = eTagInfo.valueGTIN;
            frm.lblUpcNumber.Text           = eTagInfo.upcGTIN;
            frm.lblPluNumber.Text           = eTagInfo.PLU;

            string presentation = "";
            if (eTagInfo.preLabel.IsNullOrEmpty())
                presentation += eTagInfo.preLabel;
            presentation += eTagInfo.namePresentation;
            if (eTagInfo.postLabel.IsNullOrEmpty())
                presentation += eTagInfo.postLabel;
            frm.lblPresentationName.Text = presentation;
        }

        public void SetTagInfo(string idWorkPlan, ETagInfo eTag)
        {

            DataRow[] rows;
            rows = dtWorkPlan.Select($"{Column.id} = '{idWorkPlan}'");

            if (rows.Length > 0)
            {
                if (DateTime.TryParse(rows[0][ClsObject.WorkPlan.ColumnDate].ToString(), out DateTime dateWorkPlan))
                        eTag.dateWorkPlan = dateWorkPlan;
                    else
                        eTag.dateWorkPlan = null;

                eTag.nameProduct            = rows[0][Column.name].ToString();
                eTag.active                 = rows[0][Column.active].ToString();
                eTag.idWorkPlan             = rows[0][Column.id].ToString();
                eTag.idWorkGroup            = rows[0][WorkGroup.ColumnId].ToString();
                eTag.idLot                  = rows[0][Lot.ColumnId].ToString();
                eTag.nameLot                = rows[0][Lot.ColumnName].ToString();
                eTag.idVariety              = rows[0][Variety.ColumnId].ToString();
                eTag.nameVariety            = rows[0][Variety.ColumnName].ToString();
                eTag.scientisVarierty       = rows[0][Variety.ColumnScientis].ToString();
                eTag.shortNameVariety       = rows[0][Variety.ColumnShortName].ToString();
                eTag.idCrop                 = rows[0][Crop.ColumnId].ToString();
                eTag.nameCrop               = rows[0][Crop.ColumnName].ToString();
                eTag.idSize                 = rows[0][ClsObject.Size.ColumnId].ToString();
                eTag.nameSize               = rows[0][ClsObject.Size.ColumnName].ToString();
                eTag.idDistributor          = rows[0][Distributor.ColumnId].ToString();
                eTag.nameDistributor        = rows[0][Distributor.ColumnName].ToString();
                eTag.addressDistributor     = rows[0][Distributor.ColumnAddress].ToString();
                eTag.cityDistributor        = rows[0][Distributor.ColumnCity].ToString();
                eTag.shortNameDistributor   = rows[0][Distributor.ColumnShortName].ToString();
                eTag.idGTIN                 = rows[0][Gtin.ColumnId].ToString();
                eTag.valueGTIN              = rows[0][Gtin.ColumnName].ToString();
                eTag.upcGTIN                = rows[0][Gtin.ColumnUpc].ToString();
                eTag.PLU                    = rows[0][Gtin.ColumnPlu].ToString();
                eTag.idContainer            = rows[0][Container.ColumnId].ToString();
                eTag.nameContainer          = rows[0][Container.ColumnName].ToString();
                eTag.Lbs                    = ClsValues.RemoveTrailingZeros(rows[0][Gtin.ColumnLbs].ToString()); //Ej: de 10.00 a 10
                eTag.preLabel               = rows[0][Gtin.ColumnPreLabel].ToString();
                eTag.idPresentation         = rows[0][Presentation.ColumnId].ToString();
                eTag.namePresentation       = rows[0][Presentation.ColumnName].ToString();
                eTag.postLabel              = rows[0][Gtin.ColumnPostLabel].ToString();
                eTag.palletBoxes            = rows[0][Gtin.ColumnPalletBoxes].ToString();
                eTag.idPti                  = rows[0][Pti.ColumnId].ToString();
                eTag.namePti                = rows[0][Pti.ColumnName].ToString();
                eTag.idColor                = rows[0][ClsObject.Color.ColumnId].ToString();
                eTag.nameColor              = rows[0][ClsObject.Color.ColumnName].ToString();
                eTag.nameGenericColor       = rows[0][ClsObject.Color.ColumnGenericName].ToString();
                eTag.voicePickCode          = rows[0][ClsObject.WorkPlan.ColumnVpc].ToString();
                eTag.idContractor           = rows[0][Contractor.ColumnId].ToString();
                eTag.nameContractor         = rows[0][Contractor.ColumnName].ToString();
                eTag.growFarmName           = rows[0][GrowFarm.ColumnName].ToString();
                eTag.nameColorCanEn         = rows[0][ClsObject.Color.ColumnNameCanEn].ToString();
                eTag.nameColorCanFr         = rows[0][ClsObject.Color.ColumnNameCanFr].ToString();
            }
        }

        public void BtnPrintPtiTag()
        {
            if (IsInformationNeededToUpdate())
                return;

            if (frm.cboWorkPlan.SelectedIndex == 0)
                SystemSounds.Exclamation.Play();
            else
            {
                print = new ClsPrintPtiTag();
                print.SendToPrintPtiTag(eTagInfo, (int)frm.nudPtiTotal.Value, frm.chbReversePtiTag.Checked);
            }
        }
        public void BtnPrintPalletTag()
        {
            if (IsInformationNeededToUpdate())
                return;

            if (frm.cboWorkPlan.SelectedIndex == 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Seleccione un plan de trabajo.", "Impresión Etiquetas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int palletBoxes = int.Parse(frm.txbBoxesTotaL.Text);
                int cantityPallets = (int)frm.nudPalletTotal.Value;
                string invoice = frm.txbInvoice.Text;
                DateTime date = eTagInfo.dateWorkPlan ?? DateTime.Now;
                bool reverseOrientation = frm.chbRevesePalletTag.Checked;

                if (frm.nudPalletTotal.Text == string.Empty || frm.txbInvoice.Text.Length != 4)
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("Verifique papeleta o cantidad de pallets", "Impresión Etiquetas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {

                    for (int i = 0; i < cantityPallets; i++)
                    {
                        string idPallet = ClsPalletCreate.InsertPallet(palletBoxes, eTagInfo.idWorkPlan, date, invoice);
                        if (idPallet == string.Empty)
                        {
                            SystemSounds.Exclamation.Play();
                            MessageBox.Show("No se pudo crear el pallet.", "Error al crear el pallet");
                            return;
                        }
                        else
                        {//imprimir (se creó el pallet)
                            print = new ClsPrintPtiTag();
                            print.SendToPrintPalletTag(idPallet, eTagInfo, timesPalletPrint, palletBoxes, reverseOrientation);

                            AddNewRowToLastPallets(idPallet, palletBoxes.ToString());
                        }
                    }
                }

            }
        }
        private bool IsInformationNeededToUpdate()
        {
            if (ClsComboBoxFiles.IsInfoNeededToUpdate(ClsObject.WorkPlan.CboPresentation))
            {
                frm.cboWorkGroup.SelectedIndex = 0;
                frm.cboWorkPlan.SelectedIndex = 0;
                SystemSounds.Hand.Play();
                LoadFormPrintLabels();
                MessageBox.Show("Se actualizaron los datos para el plan de trabajo.", "Impresión Etiquetas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }
        public void LoadDgvLastPallets()
        {
            dtLastPallets = ClsQuerysDB.GetDataTable(queryLastPallets);
            frm.dgvLastUserPallet.DataSource = dtLastPallets;
        }
        private void AddNewRowToLastPallets(string idPallet, string boxes)
        {
            DataRow newRow = dtLastPallets.NewRow();
            newRow["Pallet"] = idPallet;
            newRow["Cajas"] = boxes;
            newRow["Contenedor"] = $"{eTagInfo.nameContainer}{eTagInfo.Lbs}";
            newRow["Presentación"] = $"{eTagInfo.nameSize} {eTagInfo.preLabel} {eTagInfo.namePresentation} {eTagInfo.postLabel}";
            newRow["Variedad"] = eTagInfo.shortNameVariety;
            newRow["Distribuidor"] = eTagInfo.shortNameDistributor;
            newRow["Cuadrilla"] = $"{eTagInfo.idWorkGroup} {eTagInfo.nameContractor}";
            newRow["Lote"] = $"{eTagInfo.nameLot} ({eTagInfo.idLot})";
            newRow["Plan"] = eTagInfo.idWorkPlan;

            dtLastPallets.Rows.InsertAt(newRow, 0);
        }

        public void ReprintSelectedPallet()
        {
            if (frm.dgvLastUserPallet.SelectedRows.Count > 0)
            {
                ETagInfo eTagInfoReprint = new ETagInfo();

                string selectedPallet = frm.dgvLastUserPallet.SelectedRows[0].Cells["Pallet"].Value.ToString();
                string selectedPlan = frm.dgvLastUserPallet.SelectedRows[0].Cells["Plan"].Value.ToString();
                int selectedBoxes = int.Parse(frm.dgvLastUserPallet.SelectedRows[0].Cells["Cajas"].Value.ToString());

                bool reverseOrientation = frm.chbReverseReprintPallet.Checked;


                DataRow[] rows = dtWorkPlan.Select($"{Column.id} = '{selectedPlan}'");

                if (rows.Length > 0)
                {
                    SetTagInfo(selectedPlan, eTagInfoReprint);
                    print = new ClsPrintPtiTag();

                    print.SendToPrintPalletTag(selectedPallet, eTagInfoReprint, timesPalletPrint, selectedBoxes, reverseOrientation);
                }
            }
        }

    }
}

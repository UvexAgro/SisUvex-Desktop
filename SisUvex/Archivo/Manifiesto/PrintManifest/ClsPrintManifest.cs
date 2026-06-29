using DocumentFormat.OpenXml.Wordprocessing;
using iText.Kernel.Pdf;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Archivo.Manifiesto.PrintManifest
{
    internal class ClsPrintManifest
    {
        public FrmPrintManifest? frm = null;
        public string? idManifest { get; set; }
        public DateTime date { get; set; }
        public string? hour { get; set; }
        public string? idMarket { get; set; }
        public string? idTemplate { get; set; }
        public string? disShortName { get; set; }
        public bool printManifest { get; set; }
        public bool printMaping { get; set; }
        public bool printPackingList { get; set; }
        public bool printManifestPerFarm { get; set; }
        public bool printShowSize { get; set; }
        public bool printExcelLayout { get; set; }
        public string manifestsFolderPath { get; set; }
        public string finalManifestsFolderPath { get; set; }
        ClsConfigManifest? confMan = null;
        public void BeginFormCat()
        {
            frm ??= new(idManifest, idTemplate);
            frm.cls ??= this;

            LoadControls();
        }
        private void LoadControls()
        {
            confMan = new();
            confMan.GetParameters();

            ClsComboBoxes.CboLoadActives(frm.cboMarket, Market.Cbo);
            ClsComboBoxes.CboLoadActives(frm.cboTemplate, ManifestTemplate.Cbo);

            frm.cboTemplate.SelectedIndexChanged += (s, e) => CboTemplateTextChangedEvent();
            ClsComboBoxes.CboApplyTextChangedEvent(frm.cboMarket, frm.txbIdMarket);

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboMarket, idMarket);

            SelectTglConfManifest();
            ClsComboBoxes.CboSelectIndexWithTextInValueMember(frm.cboTemplate, idTemplate);

            frm.txbId.Text = idManifest;
            frm.spnHour.Text = hour;
            frm.dtpDate.Value = date;

            GetFinalFolderManifestPath();
            frm.txbManifestFolderPath.Text = finalManifestsFolderPath;
        }
        public void SetManifest(string idManifest)
        {
            DataTable dt = ClsQuerysDB.GetDataTable("SELECT man.*, dis.v_nameDistShort FROM Pack_Manifest man LEFT JOIN Pack_Distributor dis ON dis.id_distributor = man.id_distributor WHERE id_manifest = '" + idManifest + "'");
            this.idManifest = (string?)dt.GetValue("id_manifest");
            hour = (string?)dt.GetValue("c_shipment");
            date = (DateTime)dt.GetValue("d_shipment");
            idMarket = (string?)dt.GetValue("id_Market");
            disShortName = (string?)dt.GetValue("v_nameDistShort");
        }

        public void SetIdTemplate(string? idTemplate)
        {
            this.idTemplate = idTemplate;
        }
        private void SelectTglConfManifest()
        {
            frm.tglShowSize.Checked = confMan.printShowSize;
            frm.tglManifest.Checked = confMan.printManifest;
            frm.tglManifestPerFarm.Checked = confMan.printManifestPerFarm;
            frm.tglMapping.Checked = confMan.printMaping;
            frm.tglExcelLayout.Checked = confMan.printExcelLayout;
            frm.tglPrintPackingList.Checked = confMan.printPackingList;
        }
        private static bool GetBool(object? value)
        {
            return value?.ToString() == "1";
        }
        private void CboTemplateTextChangedEvent()
        {
            if (frm.cboTemplate.SelectedIndex > 0)
            {
                frm.txbIdTemplate.Text = frm.cboTemplate.SelectedValue?.ToString();
                frm.tglShowSize.Checked = GetBool(frm.cboTemplate.GetColumnValue(ManifestTemplate.ColumnPrintShowSize));
                frm.tglManifest.Checked = GetBool(frm.cboTemplate.GetColumnValue(ManifestTemplate.ColumnPrintManifest));
                frm.tglManifestPerFarm.Checked = GetBool(frm.cboTemplate.GetColumnValue(ManifestTemplate.ColumnPrintManifestPerField));
                frm.tglMapping.Checked = GetBool(frm.cboTemplate.GetColumnValue(ManifestTemplate.ColumnPrintMaping));
                frm.tglExcelLayout.Checked = GetBool(frm.cboTemplate.GetColumnValue(ManifestTemplate.ColumnPrintExcelLayout));
                frm.tglPrintPackingList.Checked = GetBool(frm.cboTemplate.GetColumnValue(ManifestTemplate.ColumnPrintPackingList));
            }
            else
            {
                SelectTglConfManifest();
            }
        }

        private void GetFinalFolderManifestPath()
        {
            finalManifestsFolderPath = Path.Combine(confMan.manifestFolderPath, "Manifiestos", disShortName, idManifest);
        }

        private void SetPrintDocuments()
        {
            //idManifest = frm.mani //YA DEBE ESTA PUESTO AQUI
            printShowSize = frm.tglShowSize.Checked;
            printManifest = frm.tglManifest.Checked;
            printManifestPerFarm = frm.tglManifestPerFarm.Checked;
            printMaping = frm.tglMapping.Checked;
            printExcelLayout = frm.tglExcelLayout.Checked;
            printPackingList = frm.tglPrintPackingList.Checked;
            finalManifestsFolderPath = frm.txbManifestFolderPath.Text;
        }

        public void BtnPrintDocuments(string idManifest)
        {
            SetPrintDocuments();

            try
            {
                bool isPrint = false;

                if (string.IsNullOrEmpty(idManifest) || string.IsNullOrEmpty(finalManifestsFolderPath))
                {
                    SystemSounds.Exclamation.Play();
                    return;
                }


                //printShowSize //PENDIENTE

                if (printManifest || printManifestPerFarm)
                {
                    // ClsPDFManifest pdfManifest = new ClsPDFManifest();
                    ClsPruebaManifiesto pdf = new ClsPruebaManifiesto();

                    if (!printManifestPerFarm)
                        pdf.CreatePDFManifest(idManifest, finalManifestsFolderPath);
                    else
                        pdf.CreatePDFManifestTotalsPerLot(idManifest, finalManifestsFolderPath);

                    isPrint = true;
                }

                if (printMaping)
                {
                    ClsPDFLoadingMap pdfMap = new ClsPDFLoadingMap();
                    pdfMap.CreatePDFMaping(idManifest, finalManifestsFolderPath);

                    isPrint = true;
                }

                if (printExcelLayout)
                {
                    ClsManifestExcelLayout exl = new ClsManifestExcelLayout();
                    exl.CreateExcelLayout(idManifest, disShortName, finalManifestsFolderPath);

                    isPrint = true;
                }

                if (printPackingList)
                {
                    ClsPDFPackingList pdfPacking = new ClsPDFPackingList();
                    pdfPacking.CreatePDFPackingList(idManifest, finalManifestsFolderPath);

                    isPrint = true;
                }

                if (isPrint)
                    OpenManifestFolderPath(idManifest, finalManifestsFolderPath);
                else
                    SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private void PrintManifest(string idManifest, string folderPath)
        {
            try
            {
                if (!idManifest.IsNullOrEmpty())
                {
                    bool isPrint = false;

                    ClsConfigManifest conf = new ClsConfigManifest();
                    conf.GetParameters();

                    if (conf.printManifest)
                    {
                        // ClsPDFManifest pdfManifest = new ClsPDFManifest();
                        ClsPruebaManifiesto pdf = new ClsPruebaManifiesto();

                        if (!isManifestPerField)
                            pdf.CreatePDFManifest(idManifest, folderPath);
                        else
                            pdf.CreatePDFManifestTotalsPerLot(idManifest);

                        isPrint = true;
                    }

                    if (isExcelLayout)
                    {
                        ClsManifestExcelLayout exl = new ClsManifestExcelLayout();
                        exl.CreateExcelLayout(idManifest);

                        isPrint = true;
                    }

                    if (conf.printMaping)
                    {
                        ClsPDFLoadingMap pdfMap = new ClsPDFLoadingMap();
                        pdfMap.desktopPath = conf.manifestFolderPath;
                        pdfMap.CreatePDFMaping(idManifest);

                        isPrint = true;
                    }

                    //ClsPDFManifiesto pdf = new ClsPDFManifiesto();

                    if (conf.printPackingList)
                    {
                        ClsPDFPackingList pdfPacking = new ClsPDFPackingList();
                        pdfPacking.desktopPath = conf.manifestFolderPath;
                        pdfPacking.CreatePDFPackingList(idManifest);

                        isPrint = true;
                    }

                    if (isPrint)
                        OpenManifestFolderPath(idManifest);
                }
                else
                {
                    MessageBox.Show("Debe guardar el manifiesto antes de imprimirlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        */
        private void OpenManifestFolderPath(string idManifest, string folderPath)
        {
            string path = Path.Combine(folderPath);

            DialogResult result = MessageBox.Show($"Archivos guardados en: {path}\n\n¿Desea abrir la carpeta?",
                "Ruta de la carpeta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }
    }
}

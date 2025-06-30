using SisUvex.Archivo.Etiquetas.PrintLabels;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Catalogos.Metods;
using System.Data;
using System.Data.SqlClient;
using static SisUvex.Catalogos.Metods.ClsObject;
using SisUvex.Configuracion;

namespace SisUvex.Archivo.Reimprimir
{
    public partial class FrmRePrintPallet : Form
    {
       
        public FrmRePrintPallet()
        {
            InitializeComponent();
        }
        private ClsPrintPtiTag print;
        private ClsPalletCreate palletCreate;
        public DataTable? dtWorkPlan;
        ETagInfo eTagInfo = new ETagInfo();
        string idPallet;
        string update;

        private void button2_Click(object sender, EventArgs e)
        {
            SQLControl sql = new SQLControl();
            ClsPrintLabelsPtiPallets printPalletLabe = new ClsPrintLabelsPtiPallets();
            string workPlan;
            int palletBoxes;
            bool reverseOrientation = chbRevesePalletTag.Checked;
            idPallet = txbRePrintCode.Text.PadLeft(5,'0');

            try 
            {
                               
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT [Plan de Trabajo], Cajas FROM vw_PackPalletCon WHERE Pallet = @idPallet", sql.cnn);
                cmd.Parameters.AddWithValue("@idPallet", idPallet);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    workPlan = reader[0].ToString();
                    palletBoxes = Convert.ToInt32(reader[1].ToString());
                    //MessageBox.Show("Plan de trabajo: "+workPlan+"\n"+"Pallet: "+ idPallet, "REIMPRESION DE PALLET" );
                }
                else
                {
                    MessageBox.Show("No se encontró el pallet", "Error");
                    return;
                }


                SetTagInfo(workPlan);
                



                if (txbUpdateBoxes.Text == "")
                {
                    
                }
                else
                {
                    palletBoxes = Convert.ToInt32(txbUpdateBoxes.Text);
                    update = ClsPalletCreate.UpdatePallet(idPallet, palletBoxes);
                }

                print = new ClsPrintPtiTag();
                print.SendToPrintPalletTag(idPallet, eTagInfo, 2, palletBoxes, reverseOrientation, true);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmRePrintPallet_Load(object sender, EventArgs e)
        {
        }

        public void SetTagInfo(string idWorkPlan)
        {
            DataTable dtWorkPlan = ClsComboBoxFiles.GetCboCatalogDataTable(ClsObject.WorkPlan.CboPresentation);
            DataRow[] rows = dtWorkPlan.Select($"{Column.id} = '{idWorkPlan}'");

            if (rows.Length > 0)
            {
                if (DateTime.TryParse(rows[0][ClsObject.WorkPlan.ColumnDate].ToString(), out DateTime dateWorkPlan))
                    eTagInfo.dateWorkPlan = dateWorkPlan;
                else
                    eTagInfo.dateWorkPlan = null;

                eTagInfo.nameProduct = rows[0][Column.name].ToString();
                eTagInfo.active = rows[0][Column.active].ToString();
                eTagInfo.idWorkPlan = rows[0][Column.id].ToString();
                eTagInfo.idWorkGroup = rows[0][WorkGroup.ColumnId].ToString();
                eTagInfo.idLot = rows[0][Lot.ColumnId].ToString();
                eTagInfo.nameLot = rows[0][Lot.ColumnName].ToString();
                eTagInfo.idVariety = rows[0][Variety.ColumnId].ToString();
                eTagInfo.nameVariety = rows[0][Variety.ColumnName].ToString();
                eTagInfo.scientisVarierty = rows[0][Variety.ColumnScientis].ToString();
                eTagInfo.idCrop = rows[0][Crop.ColumnId].ToString();
                eTagInfo.nameCrop = rows[0][Crop.ColumnName].ToString();
                eTagInfo.idSize = rows[0][ClsObject.Size.ColumnId].ToString();
                eTagInfo.nameSize = rows[0][ClsObject.Size.ColumnName].ToString();
                eTagInfo.idDistributor = rows[0][Distributor.ColumnId].ToString();
                eTagInfo.nameDistributor = rows[0][Distributor.ColumnName].ToString();
                eTagInfo.addressDistributor = rows[0][Distributor.ColumnAddress].ToString();
                eTagInfo.cityDistributor = rows[0][Distributor.ColumnCity].ToString();
                eTagInfo.shortNameDistributor = rows[0][Distributor.ColumnShortName].ToString();
                eTagInfo.idGTIN = rows[0][Gtin.ColumnId].ToString();
                eTagInfo.valueGTIN = rows[0][Gtin.ColumnName].ToString();
                eTagInfo.upcGTIN = rows[0][Gtin.ColumnUpc].ToString();
                eTagInfo.PLU = rows[0][Gtin.ColumnPlu].ToString();
                eTagInfo.idContainer = rows[0][ClsObject.Container.ColumnId].ToString();
                eTagInfo.nameContainer = rows[0][ClsObject.Container.ColumnName].ToString();
                eTagInfo.Lbs = ClsValues.RemoveTrailingZeros(rows[0][Gtin.ColumnLbs].ToString()); //Ej: de 10.00 a 10
                eTagInfo.preLabel = rows[0][Gtin.ColumnPreLabel].ToString();
                eTagInfo.idPresentation = rows[0][Presentation.ColumnId].ToString();
                eTagInfo.namePresentation = rows[0][Presentation.ColumnName].ToString();
                eTagInfo.postLabel = rows[0][Gtin.ColumnPostLabel].ToString();
                eTagInfo.palletBoxes = rows[0][Gtin.ColumnPalletBoxes].ToString();
                eTagInfo.idPti = rows[0][Pti.ColumnId].ToString();
                eTagInfo.namePti = rows[0][Pti.ColumnName].ToString();
                eTagInfo.idColor = rows[0][ClsObject.Color.ColumnId].ToString();
                eTagInfo.nameColor = rows[0][ClsObject.Color.ColumnName].ToString();
                eTagInfo.voicePickCode = rows[0][ClsObject.WorkPlan.ColumnVpc].ToString();
                eTagInfo.idContractor = rows[0][Contractor.ColumnId].ToString();
                eTagInfo.nameContractor = rows[0][Contractor.ColumnName].ToString();
                eTagInfo.growFarmName = rows[0][GrowFarm.ColumnName].ToString(); // Added for grow farm name
            }
        }
    }
}

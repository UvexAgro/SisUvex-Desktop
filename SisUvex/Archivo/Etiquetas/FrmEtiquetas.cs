
using SisUvex.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Configuracion;

namespace SisUvex.Archivo.Etiquetas
{
    public partial class FrmEtiquetas : Form
    {

        string printDocument, printPTI, printPallet, printCode, print, superPrint, dateAlbertsons, voicePickCode, vpc, vPC1, vPC2, workPlan, idWorkGroup, workDay, idWorkPlan, printer, program;

        int boxNumber, jlDate;

        string selectedPrintPTI, selectedPrintPallet, selectedPrintCode, selectedPrintDoc, printerCode, printerPallet, printDoc, printerTag, cadenaTexto, printName;
        string lastPallet;


        PrintDocument pd = new PrintDocument();
        SQLControl sqlControl = new SQLControl();
        UniqueBox uniqueBox = new UniqueBox();
        TagHelper tagHelper = new TagHelper();
        LabelPti labelPti = new LabelPti();
        ClsConfPrinter confPrinter = new ClsConfPrinter();


        JulianCalendar julian = new JulianCalendar();

        palletTag pallet = new palletTag();
        PTITag pti = new PTITag();


        public FrmEtiquetas()
        {
            if (sqlControl.cnn.State == ConnectionState.Open)
            { sqlControl.cnn.Close(); }
            InitializeComponent();
            LoadWorkGroup();
            confPrinter.Leer();

        }

        private void LoadWorkGroup()
        {
            try
            {
                sqlControl.OpenConectionWrite();

                string query = "SELECT id_workGroup FROM [Pack_WorkGroup] WHERE c_active = '1'";
                SqlDataAdapter da = new SqlDataAdapter(query, sqlControl.cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Pack_WorkGroup");
                cmBoxWorkGroup.DisplayMember = "id_workGroup";
                cmBoxWorkGroup.ValueMember = "id_workGroup";
                cmBoxWorkGroup.DataSource = ds.Tables["Pack_WorkGroup"];


                idWorkGroup = cmBoxWorkGroup.GetItemText(this.cmBoxWorkGroup.SelectedItem);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR EN CARGA DE CUADRILLAS");
            }
            finally { sqlControl.CloseConectionWrite(); }

        }

        private void LoadWorkPlan()
        {
            try
            {
                if (sqlControl.cnn.State == ConnectionState.Open)
                { sqlControl.cnn.Close(); }

                workDay = dTPWorkDay.Value.ToString("yyyyMMdd");
                idWorkGroup = cmBoxWorkGroup.GetItemText(this.cmBoxWorkGroup.SelectedItem);

                string query = "SELECT  Pack_WorkPlan.id_workPlan, CONCAT (Pack_Material.v_nameMat,' ',Pack_Size.v_sizeValue) AS PRESENTACION " +
                    "FROM Pack_WorkPlan " +
                    "JOIN Pack_Program ON Pack_WorkPlan.id_program = Pack_Program.id_program " +
                    "JOIN Pack_GTIN ON Pack_GTIN.id_GTIN = Pack_Program.id_GTIN " +
                    "JOIN Pack_Material ON Pack_Material.id_material = Pack_GTIN.id_material_presentation " +
                    "JOIN Pack_WorkGroup ON Pack_WorkGroup.id_workGroup = Pack_WorkPlan.id_workGroup " +
                    "JOIN Pack_Size ON Pack_Size.id_size = Pack_WorkPlan.id_Size " +
                    "WHERE Pack_WorkGroup.id_workGroup = '" + idWorkGroup + "' AND Pack_WorkPlan.d_workDay = CAST('" + workDay + "' AS datetime2) AND Pack_WorkPlan.c_active ='1'";
                SqlDataAdapter da = new SqlDataAdapter(query, sqlControl.cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Pack_WorkPlan");
                cmBoxPrograma.DisplayMember = "PRESENTACION";
                cmBoxPrograma.ValueMember = "id_workPlan";
                cmBoxPrograma.DataSource = ds.Tables["Pack_WorkPlan"];
                cmBxIdWorkPlan.DisplayMember = "id_workPlan";
                cmBxIdWorkPlan.ValueMember = "id_workPlan";
                cmBxIdWorkPlan.DataSource = ds.Tables["Pack_WorkPlan"];
                idWorkPlan = cmBxIdWorkPlan.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR EN CARGA DE PLAN DE TRABAJO");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //dateAlbertsons = Convert.ToString(julian.GetDayOfYear(DateTime.Now));


            try
            {

                labelPti.PtiType = 1;
                labelPti.AddresDistributor1 = lblAdress1.Text;
                labelPti.AddresDistributor2 = lblAdress2.Text;
                labelPti.Crop = lblTagCrop.Text;
                labelPti.DateMonthDay = DateTime.Now.ToString("MMM dd");
                labelPti.DateShortUS = DateTime.Now.ToString("yyMMdd");
                labelPti.Distributor = lblTagClientDetail.Text;
                labelPti.Gtin = lblGtinDetails.Text;
                labelPti.Lote = lblTagLotCodeDetail.Text;
                labelPti.Pounds = lblTagWeightDetails.Text;
                labelPti.Presentation = lblTagPresentacionDetail.Text;
                labelPti.Size = lblFruitSize.Text;
                labelPti.Variety = lblTagVarietyDetail.Text;
                labelPti.VoicePickCode1 = vPC1;
                labelPti.VoicePickCode2 = vPC2;
                labelPti.Workgroup = cmBoxWorkGroup.Text;
                labelPti.Program = program;

                PrintCopies(Convert.ToInt32(copiesPTI.Value));

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void PrintCopies(int copies)
        {
            try
            {

                for (int i = 0; i < copies; i++)
                {
                    uniqueBox.CrearCajaEmpleado(cmBxIdWorkPlan.Text, User.GetUserName());
                    labelPti.Qrcode = uniqueBox.UniqueBoxqrCode;
                    labelPti.SuperPrint();

                    string message = labelPti.labelsZPLString;

                    confPrinter.Leer();

                    if (ClsConfPrinter.PrintTags.Length > 0)
                    {

                        PrintZPL(labelPti.labelsZPLString, ClsConfPrinter.PrintTags);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una impresora válida", "Impresora");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void PrintZPL(string superPrint, string printer)
        {
            pd.PrinterSettings = new PrinterSettings();
            pd.PrinterSettings.Copies = 1;
            pd.PrinterSettings.PrinterName = printer;

            if (printer.Length > 0)
            {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, superPrint);
            }
            else
            {
                MessageBox.Show("Seleccione una impresora válida", "Impresora");
            }
            superPrint = "";
        }


        public double ToJulianDate()
        {
            double julianDate;

            DateTime dt = DateTime.Now;

            julianDate = dt.ToOADate() + 2415018.5;

            return julianDate;

        }

        private int GetLastBox()
        {
            try
            {


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); return -1;
            }

            return boxNumber;
        }

        public void GetInfoWorkPlan(string workPlan)
        {

            try
            {

                sqlControl.OpenConectionWrite();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_GETInfoPTI", sqlControl.cnn);
                workDay = dTPWorkDay.Value.ToString("yyyy-MM-dd");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkPlan", workPlan);
                cmd.Parameters.AddWithValue("@workDay", workDay);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(dt);

                SqlDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {
                    lblGtinDetails.Text = reader["GTIN"].ToString();
                    lblTagLotCodeDetail.Text = reader["LOTE"].ToString();
                    lblTagLoteNameDetail.Text = reader["NAMELOTE"].ToString();
                    lblTagVarietyDetail.Text = reader["VARIEDAD"].ToString();
                    lblTagPresentacionDetail.Text = reader["PRESENTACION"].ToString();
                    lblTagWeightDetails.Text = reader["PESO"].ToString();
                    lblTagClientDetail.Text = reader["CLIENTE"].ToString();
                    lblAdress1.Text = reader["ADDRESS1"].ToString();
                    lblAdress2.Text = reader["ADDRESS2"].ToString();
                    lblUPCDetails.Text = reader["UPC"].ToString();
                    lblFruitSize.Text = reader["SIZE"].ToString();
                    lblTagCrop.Text = reader["CROP"].ToString();
                    vpc = reader["VPC"].ToString();
                    vPC1 = vpc.Substring(0, 2);
                    vPC2 = vpc.Substring(2, 2);
                    lblTagFoamDetails.Text = reader["FOAM"].ToString();
                    lblTagLidsDetails.Text = reader["LIDS"].ToString();
                    lblTagMicroDetails.Text = reader["LINER"].ToString();
                    lblTagLoteDetails.Text = reader["TAG"].ToString();
                    lblSleeve.Text = reader["CINTURON"].ToString();
                    lblTagSO2Details.Text = reader["CONSERVADOR"].ToString();
                    lblTagTotalBoxDetails.Text = reader["TOPPALLET"].ToString();
                    lblTagPalletDetails.Text = reader["PALLET"].ToString();
                    lblTagCajaDetail.Text = reader["CAJA"].ToString();
                    lblTagColor.Text = reader["COLOR"].ToString();
                    program = reader["PROGRAM"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlControl.CloseConectionWrite();
            }

        }

        private void cmBoxWorkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWorkPlan();
        }

        private void FrmEtiquetas_Load(object sender, EventArgs e)
        {

        }

        private void SplitVoicePickCode(String idWorkPlan)
        {
            vPC1 = tagHelper.GetVoicePickCode(idWorkPlan).ToString().Substring(0, 2);
            vPC2 = tagHelper.GetVoicePickCode(idWorkPlan).ToString().Substring(2, 2);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmBoxPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            idWorkPlan = cmBxIdWorkPlan.Text;
            GetInfoWorkPlan(idWorkPlan);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < copiesPallet.Value; i++)
            {
                CreatePallet();
            }
        }

        public void CreatePallet()
        {
            palletTag pt = new palletTag();

            PrintPallet printPallet = new PrintPallet();

            int boxes = 0; ;


            try
            {
                int boxTop = 0;


                if (txbTotalBox.Text.Length > 0)
                {

                    boxTop = Convert.ToInt32(txbTotalBox.Text);
                }

                if (boxTop > 0)
                {
                    boxes = boxTop;
                }
                else
                {
                    boxes = Convert.ToInt32(lblTagTotalBoxDetails.Text);
                }
                if (txbPaperWork.Text.Length > 0)
                {
                    printPallet.InsertPallet(boxes, cmBxIdWorkPlan.Text, dTPWorkDay.Value, User.GetUserName(), txbPaperWork.Text);



                    print = pt.PrintPalletString(printPallet.code, printPallet.variety, printPallet.distributor, printPallet.pounds, printPallet.presentation, printPallet.datePacking, printPallet.lote, printPallet.boxes);

                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = new PrinterSettings();
                    pd.PrinterSettings.Copies = 2;


                    for (int i = 0; i < pd.PrinterSettings.Copies; i++)
                    {
                        superPrint = superPrint + print;

                    }

                    if (ClsConfPrinter.PrintPallet.Length > 0)
                    {
                        pd.PrinterSettings.PrinterName = ClsConfPrinter.PrintPallet;
                        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, superPrint);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una impresora válida", "Impresora");
                    }
                    superPrint = "";
                } else
                {
                    MessageBox.Show("Ingrese el número de boleta", "Boleta");
                }

                dgvLastUserPallet.DataSource = Consulta();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        public DataTable Consulta()
        {

            DataTable dt = new DataTable();
            try
            {
                sqlControl.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT TOP (8) id_pallet FROM Pack_Pallet WHERE userCreate = '" + User.GetUserName() + "' ORDER BY id_pallet DESC", sqlControl.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ultimos pallets");
            }
            finally
            {
                sqlControl.CloseConectionWrite();
            }
            return dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvLastUserPallet.DataSource = Consulta();
        }

        private void cmBxIdWorkPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            idWorkPlan = cmBxIdWorkPlan.Text;
            GetInfoWorkPlan(idWorkPlan);
        }

        private void dgvLastUserPallet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLastUserPallet.DataSource = Consulta();
        }
    }

}




using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SisUvex.Archivo.Manifiesto
{
    public partial class FrmManifiestoReport : Form
    {
        SQLControl sql = new SQLControl();
        public FrmManifiestoReport()
        {
            InitializeComponent();
        }

        private void FrmManifiestoReport_Load(object sender, EventArgs e)
        {
            CargarInformeManifiesto();
        }
        private void CargarInformeManifiesto()
        {
            string idManifiesto = "S0038";

            string reportPath = "ManifestoPrincipal.rdlc";

            rptManifiesto.LocalReport.ReportPath = reportPath;

            ReportDataSource pallets = new ReportDataSource("dsPalletsManifiesto", PalletsManifiesto(idManifiesto));
            ReportDataSource totales = new ReportDataSource("dsTotalesManifiesto", TotalesManifiesto(idManifiesto));
            rptManifiesto.LocalReport.DataSources.Add(pallets);
            rptManifiesto.RefreshReport();

            rptManifiesto.LocalReport.DataSources.Add(totales);
            rptManifiesto.RefreshReport();


            //rptManifiesto.LocalReport.DataSources.Add(new ReportDataSource("dsPalletsManifiesto", PalletsManifiesto(idManifiesto)));
            //rptManifiesto.LocalReport.DataSources.Add(new ReportDataSource("dsTotalesManifiesto", TotalesManifiesto(idManifiesto)));

            ManifiestoInfo(idManifiesto);

            rptManifiesto.RefreshReport();
        }
        private DataTable PalletsManifiesto(string idManifiesto)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"select ROW_NUMBER() OVER (PARTITION BY Manifiesto ORDER BY Posicion, Mix) AS 'No.', Posicion, Mix, Estiba, CONCAT(EtiquetaContenedor,REPLACE(CAST(ROUND(Libras, 2) AS decimal(10, 2)), '.00', ''),' ',EtiquetaPresentacion) Descripción, Etiqueta, Tamaño, Variedad, idLote, Pallet from vw_PackPalletDetails where Manifiesto = '{idManifiesto}'", sql.cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Reporte: Pallets");
                return dt;
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }
        private DataTable TotalesManifiesto(string idManifiesto)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT COUNT(Posicion) Pallets, SUM(Cajas) Bultos, FORMAT(SUM([Libras pallet])/(2.20462),'N2') Kg, Descripción FROM (SELECT Posicion, Pallet, Cajas, [Libras pallet], CONCAT(EtiquetaContenedor,REPLACE(CAST(ROUND(Libras, 2) AS decimal(10, 2)), '.00', ''),' ',EtiquetaPresentacion,' ', Variedad) Descripción FROM vw_PackPalletDetails WHERE Manifiesto = '{idManifiesto}') TOTALES GROUP BY Descripción", sql.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Reporte: Totales");
            }

            finally
            {
                sql.CloseConectionWrite();
            }
            return dt;
        }

        private void ManifiestoInfo(string dgvId)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"select * from vw_PackManifestAllDetails where Manifiesto = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //EMBARCADOR / PRODUCTOR / GROWER
                    string Embarcador = dr.GetValue(dr.GetOrdinal("Productor")).ToString();
                    string EmbDireccion = dr.GetValue(dr.GetOrdinal("Gro Direccion")).ToString();
                    string EmbCiudad = dr.GetValue(dr.GetOrdinal("Gro Ciudad")).ToString();
                    string EmbRFC = dr.GetValue(dr.GetOrdinal("Gro RFC")).ToString();
                    string EmbTelefono = dr.GetValue(dr.GetOrdinal("Gro Telefono")).ToString();

                    //DISTRIBUIDOR / DISTRIBUTOR
                    string Distribuidor = dr.GetValue(dr.GetOrdinal("Distribuidor")).ToString();
                    string DisDireccion = dr.GetValue(dr.GetOrdinal("Dis Direccion")).ToString();
                    string DisCiudad = dr.GetValue(dr.GetOrdinal("Dis Ciudad")).ToString();
                    string DisRFC = dr.GetValue(dr.GetOrdinal("Dis RFC")).ToString();
                    string DisTelefono = dr.GetValue(dr.GetOrdinal("Dis Telefono")).ToString();

                    //LINEA DE TRANSPORTE / TRANSPORT LINE
                    string LineaTransporte = dr.GetValue(dr.GetOrdinal("Linea de transporte")).ToString();
                    string LinSCAC = dr.GetValue(dr.GetOrdinal("tln SCAC")).ToString();

                    var parameters = new Dictionary<string, string>
                    {
                        { "Embarcador", Embarcador},
                        { "EmbDireccion", EmbDireccion},
                        { "EmbCiudad", EmbCiudad},
                        { "EmbRFC", EmbRFC},
                        { "Distribuidor", Distribuidor},
                        { "DisDireccion", DisDireccion},
                        { "DisCiudad", DisCiudad},
                        { "DisRFC", DisRFC},
                        { "LineaTransporte", LineaTransporte},
                        { "LinSCAC", LinSCAC},
                    };

                    var reportParameters = parameters.Select(p => new ReportParameter(p.Key, p.Value)).ToArray();
                    rptManifiesto.LocalReport.SetParameters(reportParameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            
        }

        public string ConvertirValor(object valor)
        {
            if (valor == null)
            {
                return string.Empty;
            }
            else
            {
                return valor.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsQueryManifest
    {

        SQLControl sql = new SQLControl();
        //Datos generales de Manifiesto
        public string? manifestNumber { get; set; }
        public DateTime? manifestDate { get; set; }
        public TimeSpan? manifestShipmentTime { get; set; }
        public string? manifestSeal1 { get; set; }
        public string? manifestSeal2 { get; set; }
        public string? manifestSeal3 { get; set; }
        public string? manifestThermometer { get; set; }
        public string? manifestThermometerPosition { get; set; }
        public string? manifestPO { get; set; }
        public string? manifestBooking { get; set; }
        public string? manifestLiftDriver { get; set; }
        public string? manifestScannedBy { get; set; }
        public string? manifestVehiculeType { get; set; }
        public string? manifestTransportPlatformType { get; set; }
        public string? manifestStatus { get; set; }
        public string? manifestComments { get; set; }


        //Datos de Embarcador
        public string? shipperId { get; set; }
        public string? shipperName { get; set; }
        public string? shipperAddress { get; set; }
        public string? shipperCity { get; set; }
        public string? shipperRFC { get; set; }
        public string? shipperPhone { get; set; }
        public string? shipperGGN { get; set; }
        public string? shipperLogo { get; set; }

        //Datos de Distribuidor
        public string? distributorId { get; set; }
        public string? distributorName { get; set; }
        public string? distributorAddress { get; set; }
        public string? distributorCity { get; set; }
        public string? distributorTAXID { get; set; }
        public string? distributorPhone { get; set; }
        public string? distributorCountry { get; set; }
        public string? distributorShortName { get; set; }

        //Datos de Linea de Transporte
        public string? carrierId { get; set; }
        public string? carrierName { get; set; }
        public string? carrierSCAC { get; set; }
        public string? carrierSCAAT { get; set; }

        //Datos de troque
        public string? truckId { get; set; }
        public string? truckNoEco { get; set; }
        public string? truckPlateUS { get; set; }
        public string? truckPlateMX { get; set; }
        public string? truckBrand { get; set; }
        public string? truckModel { get; set; }

        //Datos de refrigeracion
        public string? thermoId { get; set; }
        public string? thermoNoEco { get; set; }
        public string? thermoPlateUS { get; set; }
        public string? thermoPlateMX { get; set; }
        public string? thermoTemperature { get; set; }
        public string? thermoUnitTemperature { get; set; }
        public string? thermoLength { get; set; }
        public string? thermoType { get; set; }

        //Datos de chofer
        public string? driverId { get; set; }
        public string? driverName { get; set; }
        public string? driverLicense { get; set; }
        public string? driverVisa { get; set; }
        public DateTime? driverBirthday { get; set; }

        //Datos Aduana Mexicana
        public string? customMXId { get; set; }
        public string? customMXName { get; set; }
        public string? customMXAddress { get; set; }
        public string? customMXCity { get; set; }
        public string? customMXCountry { get; set; }
        public string? customMXRFC { get; set; }

        //Datos Aduana Americana
        public string? customUSId { get; set; }
        public string? customUSName { get; set; }
        public string? customUSAddress { get; set; }
        public string? customUSCity { get; set; }
        public string? customUSCountry { get; set; }
        public string? customUSRFC { get; set; }

        //Puerto de cruce
        public string? idPort { get; set; }
        public string? vNamePort { get; set; }
        public string? vStatePort { get; set; }
        public string? vCountryPort { get; set; }

        //Entry port
        public string? idEntryPort { get; set; }
        public string? vNameEntryPort { get; set; }
        public string? vStateEntryPort { get; set; }
        public string? vCountryEntryPort { get; set; }

        //Datos consignatario
        public string? consigneeId { get; set; }
        public string? consigneeName { get; set; }
        public string? consigneeAddress { get; set; }
        public string? consigneeCity { get; set; }
        public string? consigneeTAXID { get; set; }
        public string? consigneePhone { get; set; }
        public string? consigneeCountry { get; set; }
        public string? consigneeStatus { get; set; }
        public DataTable? DetalleCarga { get; set; }
        public DataTable? TotalesCarga { get; set; }
        public DataTable? TotalesPorCampo { get; set; }

        public ClsQueryManifest()
        {
            DetalleCarga = new DataTable();
            TotalesCarga = new DataTable();
            TotalesPorCampo = new();
        }

        public void GetManifestData(string manifestNumber)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT * FROM vw_PackManifestAllDetails WHERE Manifiesto = @manifestNumber", sql.cnn);
                cmd.Parameters.AddWithValue("@manifestNumber", manifestNumber);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.manifestNumber = dr["Manifiesto"].ToString();
                    this.manifestDate = Convert.ToDateTime(dr["Fecha"]);
                    this.manifestShipmentTime = TimeSpan.Parse(dr["Hora"].ToString());
                    this.manifestSeal1 = dr["Sello1"].ToString();
                    this.manifestSeal2 = dr["Sello2"].ToString();
                    this.manifestSeal3 = dr["Sello3"].ToString();
                    this.manifestThermometer = dr["Termografo"].ToString();
                    this.manifestThermometerPosition = dr["Posicion termo"].ToString();
                    this.manifestPO = dr["Orden"].ToString();
                    this.manifestBooking = dr["Booking"].ToString();
                    this.manifestLiftDriver = dr["Montacarguista"].ToString();
                    this.manifestScannedBy = dr["Embarcador"].ToString();
                    this.manifestVehiculeType = dr["Vehiculo"].ToString();
                    this.manifestTransportPlatformType = dr["Tipo de transporte"].ToString();
                    this.manifestStatus = dr["Rechazada"].ToString();
                    this.manifestComments = dr["Observaciones"].ToString();
                    this.shipperId = dr["idGro"].ToString();
                    this.shipperName = dr["Productor"].ToString();
                    this.shipperAddress = dr["Gro Direccion"].ToString();
                    this.shipperCity = dr["Gro Ciudad"].ToString();
                    this.shipperRFC = dr["Gro RFC"].ToString();
                    this.shipperPhone = dr["Gro telefono"].ToString();
                    this.shipperLogo = dr["Logo"].ToString();
                    this.shipperGGN = dr["Gro GGN"].ToString();
                    this.distributorId = dr["idDis"].ToString();
                    this.distributorName = dr["Distribuidor"].ToString();
                    this.distributorAddress = dr["Dis Direccion"].ToString();
                    this.distributorCity = dr["Dis Ciudad"].ToString();
                    this.distributorTAXID = dr["Dis RFC"].ToString();
                    this.distributorPhone = dr["Dis telefono"].ToString();
                    this.distributorCountry = dr["Dis País"].ToString();
                    this.distributorShortName = dr["Dis Short"].ToString();
                    this.carrierId = dr["idTLn"].ToString();
                    this.carrierName = dr["Linea de transporte"].ToString();
                    this.carrierSCAC = dr["tln SCAC"].ToString();
                    this.carrierSCAAT = dr["tln CAAT"].ToString();
                    this.truckId = dr["idTru"].ToString();
                    this.truckNoEco = dr["tru Num eco"].ToString();
                    this.truckPlateUS = dr["tru Placas US"].ToString();
                    this.truckPlateMX = dr["tru Placas MX"].ToString();
                    this.truckBrand = dr["tru Marca"].ToString();
                    this.truckModel = dr["tru Modelo"].ToString();
                    this.thermoId = dr["idFco"].ToString();
                    this.thermoNoEco = dr["fco Num eco"].ToString();
                    this.thermoPlateUS = dr["fco Placas US"].ToString();
                    this.thermoPlateMX = dr["fco Placas MX"].ToString();
                    this.thermoTemperature = dr["Temperatura"].ToString();
                    this.thermoUnitTemperature = dr["Grados"].ToString();
                    this.thermoLength = dr["fco Pies"].ToString();
                    this.thermoType = dr["fco Tipo"].ToString();
                    this.driverId = dr["idDri"].ToString();
                    this.driverName = dr["Conductor"].ToString();
                    this.driverLicense = dr["dri Licencia"].ToString();
                    this.driverVisa = dr["dri Visa"].ToString();
                    if (DateTime.TryParse(dr["dri Nacimiento"].ToString(), out DateTime driverBirthday))
                    {
                        this.driverBirthday = driverBirthday;
                    }
                    this.customMXId = dr["idMXAg"].ToString();
                    this.customMXName = dr["Agencia nacional"].ToString();
                    this.customMXAddress = dr["agMX Direccion"].ToString();
                    this.customMXCity = dr["agMX Ciudad"].ToString();
                    this.customMXCountry = dr["agMX Pais"].ToString();
                    this.customMXRFC = dr["agMX RFC"].ToString();
                    this.customUSId = dr["idUSAg"].ToString();
                    this.customUSName = dr["Agencia extranjera"].ToString();
                    this.customUSAddress = dr["agUS Direccion"].ToString();
                    this.customUSCity = dr["agUS Ciudad"].ToString();
                    this.customUSCountry = dr["agUS Pais"].ToString();
                    this.customUSRFC = dr["agUS RFC"].ToString();
                    this.idPort = dr["idCitCr"].ToString();
                    this.vNamePort = dr["Ciudad cruce"].ToString();
                    this.vStatePort = dr["ctCrv Estado"].ToString();
                    this.vCountryPort = dr["ctCrv Pais"].ToString();
                    this.idEntryPort = dr["idCitDE"].ToString();
                    this.vNameEntryPort = dr["Ciudad destino"].ToString();
                    this.vStateEntryPort = dr["ctDe Estado"].ToString();
                    this.vCountryEntryPort = dr["ctDe Pais"].ToString();
                    this.consigneeId = dr["idCons"].ToString();
                    this.consigneeName = dr["Consignatario"].ToString();
                    this.consigneeAddress = dr["Cons Direccion"].ToString();
                    this.consigneeCity = dr["Cons City"].ToString();
                    this.consigneeTAXID = dr["Cons RFC"].ToString();
                    this.consigneePhone = dr["Consignatario"].ToString();
                    this.consigneeCountry = dr["Cons País"].ToString();
                    this.consigneeStatus = dr["Activo"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void GetManifestDetailData(string manifestNumber)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT * FROM vw_PackRemisionTableManifest WHERE Manifiesto = @manifestNumber", sql.cnn);
                cmd.Parameters.AddWithValue("@manifestNumber", manifestNumber);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DetalleCarga);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void GetManifestTotalData(string manifestNumber)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT * FROM vw_PackRemisionTotalTableManifest WHERE Manifiesto = @manifestNumber", sql.cnn);
                cmd.Parameters.AddWithValue("@manifestNumber", manifestNumber);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(TotalesCarga);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void GetManifestTotalPerField(string manifestNumber)
        {
            //try
            //{
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [vw_PackManifestTotalPerField] WHERE Manifiesto = @manifestNumber", sql.cnn);
                cmd.Parameters.AddWithValue("@manifestNumber", manifestNumber);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(TotalesPorCampo);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
                sql.CloseConectionWrite();
            //}
        }
    }
}

using System.Data.SqlClient;
using static SisUvex.Archivo.Manifiesto.EManifest;

namespace SisUvex.Archivo.Manifiesto
{
    internal class EManifest
    {
        public string? idManifest { get; set; }
        public string? idDistributor { get; set; }
        public string? idGrower { get; set; }
        public string? idUSAgencyTrade { get; set; }
        public string? idMXAgencyTrade { get; set; }
        public string? idTransportLine { get; set; }
        public string? idTruck { get; set; }
        public string? idFreightContainer { get; set; }
        public string? idDriver { get; set; }
        public string? idCityCrossPoint { get; set; }
        public string? idCityDestiny { get; set; }
        public string? seal1 { get; set; }
        public string? seal2 { get; set; }
        public string? seal3 { get; set; }
        public string? termograph { get; set; }
        public int? active { get; set; }
        public string? purchaseOrder { get; set; }
        public string? idConsignee { get; set; }
        public string? booking { get; set; }
        public DateTime? shipmentDate { get; set; }
        public string? shipmentHour { get; set; }
        public string? temperature { get; set; }
        public string? temperatureUnit { get; set; }
        public string? nameOperator { get; set; }
        public string? nameShipper { get; set; }
        public string? transportVehicle { get; set; }
        public string? transportType { get; set; }
        public string? rejected { get; set; }
        public string? observations { get; set; }
        public string? termoPosition { get; set; }
        public string? dieselInvoice { get; set; }
        public string? dieselLts { get; set; }
        public string? phytosanitary { get; set; }
        public string? idSeason { get; set; }

        public void SetManifest(string idManifest)
        {
            SQLControl sql = new SQLControl();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Manifest WHERE id_manifest = @idManifest", sql.cnn);
                cmd.Parameters.AddWithValue("@idManifest", idManifest);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    this.idManifest = dr.GetValue(dr.GetOrdinal("id_manifest")).ToString();
                    this.idDistributor = dr.GetValue(dr.GetOrdinal("id_distributor")).ToString();
                    this.idGrower = dr.GetValue(dr.GetOrdinal("id_grower")).ToString();
                    this.idUSAgencyTrade = dr.GetValue(dr.GetOrdinal("id_USAgencyTrade")).ToString();
                    this.idMXAgencyTrade = dr.GetValue(dr.GetOrdinal("id_MXAgencyTrade")).ToString();
                    this.idTransportLine = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    this.idTruck = dr.GetValue(dr.GetOrdinal("id_truck")).ToString();
                    this.idFreightContainer = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString();
                    this.idDriver = dr.GetValue(dr.GetOrdinal("id_driver")).ToString();
                    this.idCityCrossPoint = dr.GetValue(dr.GetOrdinal("id_cityCrossPoint")).ToString();
                    this.idCityDestiny = dr.GetValue(dr.GetOrdinal("id_cityDestiny")).ToString();
                    this.seal1 = dr.GetValue(dr.GetOrdinal("v_seal1")).ToString();
                    this.seal2 = dr.GetValue(dr.GetOrdinal("v_seal2")).ToString();
                    this.seal3 = dr.GetValue(dr.GetOrdinal("v_seal3")).ToString();
                    this.termograph = dr.GetValue(dr.GetOrdinal("v_termograph")).ToString();
                    this.active = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    this.purchaseOrder = dr.GetValue(dr.GetOrdinal("v_purchaseOrder")).ToString();
                    this.idConsignee = dr.GetValue(dr.GetOrdinal("id_consignee")).ToString();
                    this.booking = dr.GetValue(dr.GetOrdinal("v_booking")).ToString();
                    this.shipmentDate = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_shipment")).ToString());
                    this.shipmentHour = dr.GetValue(dr.GetOrdinal("c_shipment")).ToString();
                    this.temperature = dr.GetValue(dr.GetOrdinal("i_temperature")).ToString();
                    this.temperatureUnit = dr.GetValue(dr.GetOrdinal("c_temperatureUnit")).ToString();
                    this.nameOperator = dr.GetValue(dr.GetOrdinal("v_nameOperator")).ToString();
                    this.nameShipper = dr.GetValue(dr.GetOrdinal("v_nameShipper")).ToString();
                    this.transportVehicle = dr.GetValue(dr.GetOrdinal("v_transportVehicle")).ToString();
                    this.transportType = dr.GetValue(dr.GetOrdinal("v_transportType")).ToString();
                    this.rejected = dr.GetValue(dr.GetOrdinal("c_rejected")).ToString();
                    this.observations = dr.GetValue(dr.GetOrdinal("v_observations")).ToString();
                    this.termoPosition = dr.GetValue(dr.GetOrdinal("i_termoPosition")).ToString();
                    this.dieselInvoice = dr.GetValue(dr.GetOrdinal("v_diesel")).ToString();
                    this.dieselLts = dr.GetValue(dr.GetOrdinal("n_diesel")).ToString();
                    this.phytosanitary = dr.GetValue(dr.GetOrdinal("v_phytosanitary")).ToString();
                    this.idSeason = dr.GetValue(dr.GetOrdinal("id_season")).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al cargar manifiesto");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}

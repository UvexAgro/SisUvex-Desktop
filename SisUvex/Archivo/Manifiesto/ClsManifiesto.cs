
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using SisUvex.Catalogos;
namespace SisUvex.Archivo.Manifiesto
{
    internal class ClsManifiesto : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public FrmManifiestoCat frmCat;
        public DataTable CatalogoActualizar(bool Status)
        {
            DataTable dt = new DataTable();

            if (Status)
                dt = CatalogoActivos("0", frmCat.dtpDate1, frmCat.dtpDate2);
            else
                dt = CatalogoActivos("*", frmCat.dtpDate1, frmCat.dtpDate2);

            return dt;
        }
        public DataTable CatalogoActivos(string activo, DateTimePicker fecha1, DateTimePicker fecha2)
        {
            DataTable dt = new DataTable();
            try
            {
                string fecha1String = fecha1.Value.ToString("yyyy-MM-dd");
                string fecha2String = fecha2.Value.ToString("yyyy-MM-dd");

                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Manifiesto,Fecha, Hora, Distribuidor, Productor, [Agencia nacional], [Agencia extranjera], CONCAT([Ciudad destino],' ',[ctDe Estado]) [Ciudad destino], CONCAT([Ciudad cruce],' ',[ctCrv Estado]) [Ciudad cruce], Orden, Booking, Fitosanitario, [Linea de transporte], [tru Num eco] 'Troque', [tru Placas US] 'Placas US',[tru Placas MX] 'Placas MX', [fco Num eco] 'Caja', [fco Placas US] 'Placas US', [fco Placas MX] 'Placas MX', Conductor, Embarcador FROM vw_PackManifestAllDetails where Activo != '{activo}' and Fecha BETWEEN '{fecha1String}' AND '{fecha2String}' OR Fecha is null ORDER BY Manifiesto Desc", sql.cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo activos");
                return dt;
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public string AñadirManifiesto(string active, string manifestType, string idDistributor, string idConsignee, string idGrower, string idUSAgencyTrade, string idMXAgencyTrade, string idTransportLine, string idTruck, string idFreightContainer, string idDriver, string idCityCrossPoint, string idCityDestiny, string seal1, string seal2, string seal3, string termograph, string purchaseOrder, string idbooking, DateTime dShipment, string cShipment, string temperature, string temperatureUnit, string nameOperator, string nameShipper, string transportVehicle, string transportType, bool rejected, string observations, string termoPosicion, string dieselFolio, string dieselLitros, string fitosanitario)
        {
            string idManifiesto = string.Empty;
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackManifestAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@manifestType", manifestType.Substring(0,1));
                cmd.Parameters.AddWithValue("@idDistributor", ValorNull(idDistributor));
                cmd.Parameters.AddWithValue("@idConsignee", ValorNull(idConsignee));
                cmd.Parameters.AddWithValue("@idGrower", ValorNull(idGrower));
                cmd.Parameters.AddWithValue("@idUSAgencyTrade", ValorNull(idUSAgencyTrade));
                cmd.Parameters.AddWithValue("@idMXAgencyTrade", ValorNull(idMXAgencyTrade));
                cmd.Parameters.AddWithValue("@idTransportLine", ValorNull(idTransportLine));
                cmd.Parameters.AddWithValue("@idTruck", ValorNull(idTruck));
                cmd.Parameters.AddWithValue("@idFreightContainer", ValorNull(idFreightContainer));
                cmd.Parameters.AddWithValue("@idDriver", ValorNull(idDriver));
                cmd.Parameters.AddWithValue("@idCityCrossPoint", ValorNull(idCityCrossPoint));
                cmd.Parameters.AddWithValue("@idCityDestiny", ValorNull(idCityDestiny));
                cmd.Parameters.AddWithValue("@seal1", ValorNull(seal1));
                cmd.Parameters.AddWithValue("@seal2", ValorNull(seal2));
                cmd.Parameters.AddWithValue("@seal3", ValorNull(seal3));
                cmd.Parameters.AddWithValue("@termograph", ValorNull(termograph));
                cmd.Parameters.AddWithValue("@purchaseOrder", ValorNull(purchaseOrder));
                cmd.Parameters.AddWithValue("@booking", ValorNull(idbooking));
                cmd.Parameters.AddWithValue("@dShipment", dShipment.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@cShipment", SpnHoraVacioNull(cShipment));
                cmd.Parameters.AddWithValue("@temperature", ValorNull(temperature));
                cmd.Parameters.AddWithValue("@temperatureUnit", ValorNull(temperatureUnit));
                cmd.Parameters.AddWithValue("@nameOperator", ValorNull(nameOperator));
                cmd.Parameters.AddWithValue("@nameShipper", ValorNull(nameShipper));
                cmd.Parameters.AddWithValue("@transportVehicle", ValorNull(transportVehicle));
                cmd.Parameters.AddWithValue("@transportType", ValorNull(transportType));
                cmd.Parameters.AddWithValue("@rejected", Id00Null(Valor01CheckBox(rejected)));
                cmd.Parameters.AddWithValue("@observations", ValorNull(observations));
                cmd.Parameters.AddWithValue("@termoPosition", ValorNull(termoPosicion));
                cmd.Parameters.AddWithValue("@dieselInvoice", ValorNull(dieselFolio));
                cmd.Parameters.AddWithValue("@dieselLiters", ValorNull(dieselLitros));
                cmd.Parameters.AddWithValue("@phytosanitary", ValorNull(fitosanitario));

                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idManifiesto = (string)dr["id_manifest"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return idManifiesto;
        }

        public void ModificarManifiesto(string active, string idManifest, string idDistributor, string idConsignee, string idGrower, string idUSAgencyTrade, string idMXAgencyTrade, string idTransportLine, string idTruck, string idFreightContainer, string idDriver, string idCityCrossPoint, string idCityDestiny, string seal1, string seal2, string seal3, string termograph, string purchaseOrder, string idbooking, DateTime dShipment, string cShipment, string temperature, string temperatureUnit, string nameOperator, string nameShipper, string transportVehicle, string transportType, bool rejected, string observations, string termoPosicion, string dieselFolio, string dieselLitros, string fitosanitario)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackManifestModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@idManifest", idManifest);
                cmd.Parameters.AddWithValue("@idDistributor", ValorNull(idDistributor));
                cmd.Parameters.AddWithValue("@idConsignee", ValorNull(idConsignee));
                cmd.Parameters.AddWithValue("@idGrower", ValorNull(idGrower));
                cmd.Parameters.AddWithValue("@idUSAgencyTrade", ValorNull(idUSAgencyTrade));
                cmd.Parameters.AddWithValue("@idMXAgencyTrade", ValorNull(idMXAgencyTrade));
                cmd.Parameters.AddWithValue("@idTransportLine", ValorNull(idTransportLine));
                cmd.Parameters.AddWithValue("@idTruck", ValorNull(idTruck));
                cmd.Parameters.AddWithValue("@idFreightContainer", ValorNull(idFreightContainer));
                cmd.Parameters.AddWithValue("@idDriver", ValorNull(idDriver));
                cmd.Parameters.AddWithValue("@idCityCrossPoint", ValorNull(idCityCrossPoint));
                cmd.Parameters.AddWithValue("@idCityDestiny", ValorNull(idCityDestiny));
                cmd.Parameters.AddWithValue("@seal1", ValorNull(seal1));
                cmd.Parameters.AddWithValue("@seal2", ValorNull(seal2));
                cmd.Parameters.AddWithValue("@seal3", ValorNull(seal3));
                cmd.Parameters.AddWithValue("@termograph", ValorNull(termograph));
                cmd.Parameters.AddWithValue("@purchaseOrder", ValorNull(purchaseOrder));
                cmd.Parameters.AddWithValue("@booking", ValorNull(idbooking));
                cmd.Parameters.AddWithValue("@dShipment", dShipment.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@cShipment", SpnHoraVacioNull(cShipment));
                cmd.Parameters.AddWithValue("@temperature", ValorNull(temperature));
                cmd.Parameters.AddWithValue("@temperatureUnit", ValorNull(temperatureUnit));
                cmd.Parameters.AddWithValue("@nameOperator", ValorNull(nameOperator));
                cmd.Parameters.AddWithValue("@nameShipper", ValorNull(nameShipper));
                cmd.Parameters.AddWithValue("@transportVehicle", ValorNull(transportVehicle));
                cmd.Parameters.AddWithValue("@transportType", ValorNull(transportType));
                cmd.Parameters.AddWithValue("@rejected", Id00Null(Valor01CheckBox(rejected)));
                cmd.Parameters.AddWithValue("@observations", ValorNull(observations));
                cmd.Parameters.AddWithValue("@termoPosition", ValorNull(termoPosicion));
                cmd.Parameters.AddWithValue("@dieselInvoice", ValorNull(dieselFolio));
                cmd.Parameters.AddWithValue("@dieselLiters", ValorNull(dieselLitros));
                cmd.Parameters.AddWithValue("@phytosanitary", ValorNull(fitosanitario));

                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                cmd.ExecuteNonQuery();
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
        public void RecuperarManifiesto(string id)
        {

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverRecover", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo recuperar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }

        }

        public void EliminarManifiesto(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackDriverDelete", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo recuperar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public string SiguienteManifiesto(string mercado)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"(SELECT '{mercado}' + COALESCE(FORMAT(MAX(CAST(SUBSTRING(id_manifest, 2, LEN(id_manifest)) AS INT)) + 1, '0000'), '0001') AS 'Id' FROM Pack_Manifest WHERE LEFT(id_manifest,1) = '{mercado}')", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["Id"].ToString();
                }
                return "E0000";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
                return "E0000";
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }

        public void LlenarFormulario(string dgvId, ref ComboBox activo, ref TextBox id, ref ComboBox tipoEmbarque, ref TextBox idDistributor, ref TextBox idConsignee, ref TextBox idGrower, ref TextBox idUSAgencyTrade, ref TextBox idMXAgencyTrade, ref TextBox idTransportLine, ref TextBox idTruck, ref TextBox idFreightContainer, ref TextBox idDriver, ref TextBox idCityCrossPoint, ref TextBox idCityDestiny, ref TextBox seal1, ref TextBox seal2, ref TextBox seal3, ref TextBox termograph, ref TextBox purchaseOrder, ref TextBox idbooking, ref DateTimePicker dShipment, ref MaskedTextBox cShipment, ref TextBox temperature, ref ComboBox temperatureUnit, ref TextBox nameOperator, ref TextBox nameShipper, ref ComboBox transportVehicle, ref ComboBox transportType, ref CheckBox rejected, ref RichTextBox observations, ref TextBox termoPosition, ref TextBox dieselFolio, ref TextBox dieselCantidad, ref TextBox fitosanitario)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_Manifest WHERE id_manifest = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    activo.SelectedIndex = int.Parse(dr.GetValue(dr.GetOrdinal("c_active")).ToString());
                    tipoEmbarque.Text = dr.GetValue(dr.GetOrdinal("id_manifest")).ToString().Substring(0, 1);
                    id.Text = dr.GetValue(dr.GetOrdinal("id_manifest")).ToString();
                    idDistributor.Text = dr.GetValue(dr.GetOrdinal("id_distributor")).ToString();
                    idConsignee.Text = dr.GetValue(dr.GetOrdinal("id_consignee")).ToString();
                    idGrower.Text = dr.GetValue(dr.GetOrdinal("id_grower")).ToString();
                    idUSAgencyTrade.Text = dr.GetValue(dr.GetOrdinal("id_USAgencyTrade")).ToString();
                    idMXAgencyTrade.Text = dr.GetValue(dr.GetOrdinal("id_MXAgencyTrade")).ToString();
                    idTransportLine.Text = dr.GetValue(dr.GetOrdinal("id_transportLine")).ToString();
                    idTruck.Text = dr.GetValue(dr.GetOrdinal("id_truck")).ToString();
                    idFreightContainer.Text = dr.GetValue(dr.GetOrdinal("id_freightContainer")).ToString();
                    idDriver.Text = dr.GetValue(dr.GetOrdinal("id_driver")).ToString();
                    idCityCrossPoint.Text = dr.GetValue(dr.GetOrdinal("id_cityCrossPoint")).ToString();
                    idCityDestiny.Text = dr.GetValue(dr.GetOrdinal("id_cityDestiny")).ToString();
                    seal1.Text = dr.GetValue(dr.GetOrdinal("v_seal1")).ToString();
                    seal2.Text = dr.GetValue(dr.GetOrdinal("v_seal2")).ToString();
                    seal3.Text = dr.GetValue(dr.GetOrdinal("v_seal3")).ToString();
                    termograph.Text = dr.GetValue(dr.GetOrdinal("v_termograph")).ToString();
                    purchaseOrder.Text = dr.GetValue(dr.GetOrdinal("v_purchaseOrder")).ToString();
                    idbooking.Text = dr.GetValue(dr.GetOrdinal("v_booking")).ToString();

                    //dShipment.Value = dr.GetDateTime(dr.GetOrdinal("d_shipment"));
                    int dShipmentIndex = dr.GetOrdinal("d_shipment");
                    DateTime dShipmentValue = dr.IsDBNull(dShipmentIndex) ? DateTime.Now : dr.GetDateTime(dShipmentIndex);
                    dShipment.Value = dShipmentValue;

                    cShipment.Text = dr.GetValue(dr.GetOrdinal("c_shipment")).ToString();
                    temperature.Text = dr.GetValue(dr.GetOrdinal("i_temperature")).ToString();
                    temperatureUnit.Text = dr.GetValue(dr.GetOrdinal("c_temperatureUnit")).ToString();
                    nameOperator.Text = dr.GetValue(dr.GetOrdinal("v_nameOperator")).ToString();
                    nameShipper.Text = dr.GetValue(dr.GetOrdinal("v_nameShipper")).ToString();
                    transportVehicle.Text = dr.GetValue(dr.GetOrdinal("v_transportVehicle")).ToString();
                    transportType.Text = dr.GetValue(dr.GetOrdinal("v_transportType")).ToString();
                    rejected.Checked = ValorCheckbox(dr.GetValue(dr.GetOrdinal("c_rejected")).ToString());
                    observations.Text = dr.GetValue(dr.GetOrdinal("v_observations")).ToString();
                    termoPosition.Text = dr.GetValue(dr.GetOrdinal("i_termoPosition")).ToString();
                    dieselFolio.Text = dr.GetValue(dr.GetOrdinal("v_diesel")).ToString();
                    dieselCantidad.Text = dr.GetValue(dr.GetOrdinal("n_diesel")).ToString();
                    fitosanitario.Text = dr.GetValue(dr.GetOrdinal("v_phytosanitary")).ToString();
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

        public void CargarComboBoxes(List<ComboBox> c)
        {
            CboCargarEnBlanco(c[0], CboDistribuidor("","*"));
            CboCargarEnBlanco(c[1], CboConsignatario("", "*"));
            CboCargarEnBlanco(c[2], CboProductor("","*"));
            CboCargarEnBlanco(c[3], CboAgenciaUS("","*"));
            CboCargarEnBlanco(c[4], CboAgenciaMX("", "*"));
            CboCargarEnBlanco(c[5], CboCiudad("", "*"));
            CboCargarEnBlanco(c[6], CboCiudad("", "*"));
            CboCargarEnBlanco(c[7], CboLinea("", "*"));
        }

        public void CboManifiestoDistribuidor(TextBox idDistribuidor, ComboBox cboConsignatario, ComboBox cboProductor, ComboBox cboAgenciaUS, ComboBox cboAgenciaMX, ComboBox cboCiudadCruce, ComboBox cboCiudadDestino)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT top 1 cons.id_consignee 'Consignatario', dis.id_USAgencyTrade 'USAgencia', dis.id_MXAgencyTrade 'MXAgencia', dis.id_grower 'Productor', dis.id_cityCrossPoint 'CiudadCruce', dis.id_cityDestiny'CiudadDestino' FROM Pack_Distributor dis left JOIN Pack_Consignee cons ON dis.id_distributor = cons.id_distributor WHERE dis.id_distributor  = '{idDistribuidor.Text}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CboIndiceValueTexto(cboConsignatario, dr.GetValue(dr.GetOrdinal("Consignatario")).ToString());
                    CboIndiceValueTexto(cboProductor, dr.GetValue(dr.GetOrdinal("Productor")).ToString());
                    CboIndiceValueTexto(cboAgenciaUS, dr.GetValue(dr.GetOrdinal("USAgencia")).ToString());
                    CboIndiceValueTexto(cboAgenciaMX, dr.GetValue(dr.GetOrdinal("MXAgencia")).ToString());
                    CboIndiceValueTexto(cboCiudadCruce, dr.GetValue(dr.GetOrdinal("CiudadCruce")).ToString());
                    CboIndiceValueTexto(cboCiudadDestino, dr.GetValue(dr.GetOrdinal("CiudadDestino")).ToString());
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

        public bool ExisteIdPallet(string id)
        {
            int count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Pack_Pallet WHERE id_pallet = @id", sql.cnn);
                cmd.Parameters.AddWithValue("@id", FormatoCeros(id,"00000"));
                sql.OpenConectionWrite();
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo modificar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return count > 0;
        }
        #region PALLETS ----------------------------------------------------------------------------------
        public void AñadirPallet(DataGridView dgv, string idPallet, string idManifiesto, string posicion)
        {
            try
            {
                //string posicion = string.Empty;
                string pallet = string.Empty, mix = string.Empty, estiba = string.Empty, cajas = string.Empty, libras = string.Empty, presentacion = string.Empty, variedad = string.Empty, distribuidor = string.Empty, tamaño = string.Empty, lote = string.Empty, fecha = string.Empty, programa = string.Empty, plan = string.Empty, contenedor = string.Empty, manifiesto = string.Empty;
                sql.OpenConectionWrite();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT Posicion, Pallet, Mix, Estiba, Cajas, Libras, Presentación, Variedad, Distribuidor, Tamaño, Lote, Fecha, Programa, [Plan de Trabajo], Contenedor,  Manifiesto FROM vw_PackPalletCon WHERE Pallet = @idPallet", sql.cnn);
                cmd.Parameters.AddWithValue("@idPallet", idPallet);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    pallet = rd["Pallet"].ToString();
                    if (pallet.Length > 0)
                    {
                        //posicion = ObtenerSiguientePosicion(dgv);
                        posicion = InsertarPosicionPallet(dgv, posicion);
                        manifiesto = rd["Manifiesto"].ToString();
                        estiba = rd["Estiba"].ToString();
                        if (manifiesto.Length > 0 && manifiesto != idManifiesto)
                        {
                            MessageBox.Show($"El pallet {idPallet} está asignado al manifiesto {manifiesto}.");
                        }
                        else
                        {
                            if (estiba.Length > 0)
                            {
                                AñadirEstibaCompleta(dgv, estiba, posicion);
                            }
                            else
                            {
                                pallet = rd["Pallet"].ToString();
                                mix = rd["Mix"].ToString();
                                cajas = rd["Cajas"].ToString();
                                //
                                decimal librasDecimal;
                                decimal.TryParse(rd["Libras"].ToString(), out librasDecimal);
                                libras = librasDecimal.ToString("G29");
                                //
                                presentacion = rd["Presentación"].ToString();
                                variedad = rd["Variedad"].ToString();
                                distribuidor = rd["Distribuidor"].ToString();
                                tamaño = rd["Tamaño"].ToString();
                                lote = rd["Lote"].ToString();
                                fecha = rd["Fecha"].ToString().Substring(0, 10);
                                programa = rd["Programa"].ToString();
                                plan = rd["Plan de Trabajo"].ToString();
                                contenedor = rd["Contenedor"].ToString();
                                

                                dgv.Rows.Add(posicion, pallet, mix, estiba, cajas, libras, presentacion, variedad, distribuidor, tamaño, lote, fecha, programa, plan, contenedor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mixteada pallet");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void AñadirEstibaCompleta(DataGridView dgv, string idEstiba, string posicion)
        {
            SQLControl sql2 = new SQLControl();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Posicion, Pallet, Mix, Estiba, Cajas, Libras, Presentación, Variedad, Distribuidor, Tamaño, Lote, Fecha, Programa, [Plan de Trabajo], Contenedor,  Manifiesto FROM vw_PackPalletCon WHERE Estiba = @idEstiba ORDER BY Mix", sql2.cnn);
                sql2.OpenConectionWrite();
                cmd.Parameters.AddWithValue("@idEstiba", idEstiba);

                SqlDataReader rd = cmd.ExecuteReader();

                List<string> pallets = new List<string>();
                List<string> mixes = new List<string>();
                List<string> estibas = new List<string>();
                List<string> cajas = new List<string>();
                List<string> libras = new List<string>();
                List<string> presentaciones = new List<string>();
                List<string> variedades = new List<string>();
                List<string> distribuidores = new List<string>();
                List<string> tamanos = new List<string>();
                List<string> lotes = new List<string>();
                List<string> fechas = new List<string>();
                List<string> programas = new List<string>();
                List<string> planes = new List<string>();
                List<string> contenedores = new List<string>();


                while (rd.Read())
                {
                    string pallet = rd["Pallet"].ToString();
                    string mix = rd["Mix"].ToString();
                    string estiba = rd["Estiba"].ToString();
                    string caja = rd["Cajas"].ToString();
                    //
                    decimal librasDecimal;
                    decimal.TryParse(rd["Libras"].ToString(), out librasDecimal);
                    string libra = librasDecimal.ToString("G29");
                    //
                    string presentacion = rd["Presentación"].ToString();
                    string variedad = rd["Variedad"].ToString();
                    string distribuidor = rd["Distribuidor"].ToString();
                    string tamaño = rd["Tamaño"].ToString();
                    string lote = rd["Lote"].ToString();
                    string fecha = rd["Fecha"].ToString().Substring(0, 10);
                    string programa = rd["Programa"].ToString();
                    string plan = rd["Plan de Trabajo"].ToString();
                    string contenedor = rd["Contenedor"].ToString();



                    pallets.Add(pallet);
                    mixes.Add(mix);
                    estibas.Add(estiba);
                    cajas.Add(caja);
                    libras.Add(libra);
                    presentaciones.Add(presentacion);
                    variedades.Add(variedad);
                    distribuidores.Add(distribuidor);
                    tamanos.Add(tamaño);
                    lotes.Add(lote);
                    fechas.Add(fecha);
                    programas.Add(programa);
                    planes.Add(plan);
                    contenedores.Add(contenedor);

                }

                for (int i = 0; i < mixes.Count; i++)
                {
                    string pallet = pallets[i];
                    string mix = mixes[i];
                    string estiba = estibas[i];
                    string caja = cajas[i];
                    string libra = libras[i];
                    string presentacion = presentaciones[i];
                    string variedad = variedades[i];
                    string distribuidor = distribuidores[i];
                    string tamano = tamanos[i];
                    string lote = lotes[i];
                    string fecha = fechas[i];
                    string programa = programas[i];
                    string plan = planes[i];
                    string contenedor = contenedores[i];


                    dgv.Rows.Add(posicion, pallet, mix, estiba, caja, libra, presentacion, variedad, distribuidor, tamano, lote, fecha, programa, plan, contenedor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mixteada pallet");
            }
            finally
            {
                sql2.CloseConectionWrite();
            }

            //sql.CloseConectionWrite();
            //sql.OpenConectionWrite();
            
        }
        public void DgvColumnas(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = true;
            dgv.Columns.Add("Posicion", "Posicion");
            dgv.Columns.Add("Pallet", "Pallet");
            dgv.Columns.Add("Mix", "Mix");
            dgv.Columns.Add("Estiba", "Estiba");
            dgv.Columns.Add("Cajas", "Cajas");
            dgv.Columns.Add("Libras", "Libras");
            dgv.Columns.Add("Presentación", "Presentación");
            dgv.Columns.Add("Variedad", "Variedad");
            dgv.Columns.Add("Distribuidor", "Distribuidor");
            dgv.Columns.Add("Tamaño", "Tamaño");
            dgv.Columns.Add("Lote", "Lote");
            dgv.Columns.Add("Fecha", "Fecha");
            dgv.Columns.Add("Programa", "Programa");
            dgv.Columns.Add("Plan de Trabajo", "Plan de Trabajo");
            dgv.Columns.Add("Contenedor", "Contenedor");


            dgv.Columns["Pallet"].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);
            dgv.Columns["Cajas"].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);

        }
        public void AñadirPalletsManifiesto(DataGridView dgv, string idManifiesto)
        {
            SQLControl sql2 = new SQLControl();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Posicion, Pallet, Mix, Estiba, Cajas, Libras, Presentación, Variedad, Distribuidor, Tamaño, Lote, Fecha, Programa, [Plan de Trabajo], Contenedor FROM vw_PackPalletCon WHERE Manifiesto = @idManifiesto ORDER BY Posicion ,Mix", sql2.cnn);
                sql2.OpenConectionWrite();
                cmd.Parameters.AddWithValue("@idManifiesto", idManifiesto);

                SqlDataReader rd = cmd.ExecuteReader();

                List<string> posiciones = new List<string>();
                List<string> pallets = new List<string>();
                List<string> mixes = new List<string>();
                List<string> estibas = new List<string>();
                List<string> cajas = new List<string>();
                List<string> libras = new List<string>();
                List<string> presentaciones = new List<string>();
                List<string> variedades = new List<string>();
                List<string> distribuidores = new List<string>();
                List<string> tamanos = new List<string>();
                List<string> lotes = new List<string>();
                List<string> fechas = new List<string>();
                List<string> programas = new List<string>();
                List<string> planes = new List<string>();
                List<string> contenedores = new List<string>();


                while (rd.Read())
                {
                    string posicion = rd["Posicion"].ToString();
                    string pallet = rd["Pallet"].ToString();
                    string mix = rd["Mix"].ToString();
                    string estiba = rd["Estiba"].ToString();
                    string caja = rd["Cajas"].ToString();
                    decimal librasDecimal;
                    decimal.TryParse(rd["Libras"].ToString(), out librasDecimal);
                    string libra = librasDecimal.ToString("G29");
                    string presentacion = rd["Presentación"].ToString();
                    string variedad = rd["Variedad"].ToString();
                    string distribuidor = rd["Distribuidor"].ToString();
                    string tamaño = rd["Tamaño"].ToString();
                    string lote = rd["Lote"].ToString();
                    string fecha = rd["Fecha"].ToString().Substring(0, 10);
                    string programa = rd["Programa"].ToString();
                    string plan = rd["Plan de Trabajo"].ToString();
                    string contenedor = rd["Contenedor"].ToString();


                    posiciones.Add(FormatoCeros(posicion,"00"));
                    pallets.Add(pallet);
                    mixes.Add(mix);
                    estibas.Add(estiba);
                    cajas.Add(caja);
                    libras.Add(libra);
                    presentaciones.Add(presentacion);
                    variedades.Add(variedad);
                    distribuidores.Add(distribuidor);
                    tamanos.Add(tamaño);
                    lotes.Add(lote);
                    fechas.Add(fecha);
                    programas.Add(programa);
                    planes.Add(plan);
                    contenedores.Add(contenedor);
                }

                for (int i = 0; i < mixes.Count; i++)
                {
                    string posicion = posiciones[i];
                    string pallet = pallets[i];
                    string mix = mixes[i];
                    string estiba = estibas[i];
                    string caja = cajas[i];
                    string libra = libras[i];
                    string presentacion = presentaciones[i];
                    string variedad = variedades[i];
                    string distribuidor = distribuidores[i];
                    string tamano = tamanos[i];
                    string lote = lotes[i];
                    string fecha = fechas[i];
                    string programa = programas[i];
                    string plan = planes[i];
                    string contenedor = contenedores[i];


                    dgv.Rows.Add(posicion, pallet, mix, estiba, caja, libra, presentacion, variedad, distribuidor, tamano, lote, fecha, programa, plan, contenedor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mixteada pallet");
            }
            finally
            {
                sql2.CloseConectionWrite();
            }
        }
        public string ObtenerSiguientePosicion(DataGridView dataGridView)
        {
            int maximo = 0;
            if (dataGridView.Rows.Count > 0)
            {
                int indiceColumna = dataGridView.Columns["Posicion"].Index;
                foreach (DataGridViewRow fila in dataGridView.Rows)
                {
                    if (int.TryParse(fila.Cells[indiceColumna].Value.ToString(), out int valor))
                    {
                        if (valor > maximo)
                        {
                            maximo = valor;
                        }
                    }
                }
            }
            maximo++;
            return maximo.ToString("00");
        }
        public void BorrarPallet(DataGridView dgvListado)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                DataGridViewRow dgv = dgvListado.SelectedRows[0];
                string posicion = dgv.Cells["Posicion"].Value.ToString();
                string estiba = dgv.Cells["Estiba"].Value.ToString();
                if (estiba.Length > 0)
                {
                    BorrarPalletsEstiba(dgvListado, estiba);
                }
                else
                {
                    dgvListado.Rows.Remove(dgvListado.SelectedRows[0]);
                }

                ActualizarPosiciones(dgvListado, posicion);
            }
        }
        public void BorrarPalletsEstiba(DataGridView dataGridView, string valor)
        {
            if (dataGridView.Columns.Contains("Estiba"))
            {
                int indiceColumna = dataGridView.Columns["Estiba"].Index;
                for (int i = dataGridView.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow fila = dataGridView.Rows[i];
                    string valorEstiba = fila.Cells[indiceColumna].Value?.ToString();
                    if (valorEstiba == valor)
                    {
                        dataGridView.Rows.RemoveAt(i);
                    }
                }
            }
        }
        public void ActualizarPosiciones(DataGridView dgvListado, string Posicion)
        {
            if (dgvListado.Columns.Contains("Posicion"))
            {
                int indiceColumna = dgvListado.Columns["Posicion"].Index;
                foreach (DataGridViewRow fila in dgvListado.Rows)
                {
                    string Celda = fila.Cells[indiceColumna].Value?.ToString();

                    if (!string.IsNullOrEmpty(Celda))
                    {
                        int intCelda = int.Parse(Celda);
                        int intPosicion = int.Parse(Posicion);
                        if (intCelda > intPosicion)
                        {
                            int newPosicion = intCelda - 1;
                            fila.Cells[indiceColumna].Value = newPosicion.ToString("00");
                        }
                    }
                }
            }
        }
        public string InsertarPosicionPallet(DataGridView dgvListado, string posicion)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                if (dgvListado.Columns.Contains("Posicion"))
                {
                    string sigPos = ObtenerSiguientePosicion(dgvListado);
                    if (int.Parse(ValorCero(posicion)) < int.Parse(sigPos))
                    {
                        int indiceColumna = dgvListado.Columns["Posicion"].Index;
                        foreach (DataGridViewRow fila in dgvListado.Rows)
                        {
                            string Celda = fila.Cells[indiceColumna].Value?.ToString();

                            if (!string.IsNullOrEmpty(Celda))
                            {
                                if (int.Parse(Celda) >= int.Parse(posicion))
                                {
                                    int newPosicion = int.Parse(Celda) + 1;
                                    fila.Cells[indiceColumna].Value = newPosicion.ToString("00");
                                }
                            }
                        }
                    }
                    else
                    {
                        posicion = sigPos;
                    }
                }
            }
            return posicion;
        }
        public bool PalletRepetido(DataGridView dataGridView, string valor)
        {
            if (dataGridView.Columns.Contains("Pallet"))
            {
                int indiceColumna = dataGridView.Columns["Pallet"].Index;

                foreach (DataGridViewRow fila in dataGridView.Rows)
                {
                    string valorCelda = fila.Cells[indiceColumna].Value?.ToString();

                    if (!string.IsNullOrEmpty(valorCelda) && valorCelda == valor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ProcManifestAddPallets(DataGridView dgv, string idManifiesto)
        {
            ProcManifestDeletePallets(idManifiesto);
            try
            {
                sql.OpenConectionWrite();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string idPallet = row.Cells["Pallet"].Value.ToString();
                    string posicion = row.Cells["Posicion"].Value.ToString();

                    SqlCommand cmd = new SqlCommand("sp_PackManifestAddPallet", sql.cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idPallet", idPallet);
                    cmd.Parameters.AddWithValue("@position", posicion);
                    cmd.Parameters.AddWithValue("@idManifest", idManifiesto);
                    cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Pallets en manifiesto");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void ProcManifestDeletePallets(string idManifiesto)
        {
            try
            {
                sql.OpenConectionWrite();
                    SqlCommand cmd = new SqlCommand("UPDATE Pack_Pallet SET c_position = NULL, id_manifest = NULL, userUpdate = @userUpdate, d_update = CONVERT(DATE, SYSDATETIME()) WHERE id_manifest = @idManifest", sql.cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idManifest", idManifiesto);
                    cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                    cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Pallets en manifiesto");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        #endregion FIN PALLETS ---------------------------------------------------------------------------
    }
}
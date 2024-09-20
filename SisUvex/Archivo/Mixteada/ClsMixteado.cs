
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos;

namespace SisUvex.Archivo.Mixteada
{
    internal class ClsMixteado : ClsCatalogos
    {
        SQLControl sql = new SQLControl();

        
        public void AñadirPallet(DataGridView dgv, string idPallet)
        {
            if (!PalletRepetido(dgv, FormatoCeros(idPallet,"00000")))
            {
                try
                {
                    string pallet = string.Empty, mix = string.Empty, estiba = string.Empty, programa = string.Empty, cajas = string.Empty, libras = string.Empty, tamaño = string.Empty, presentacion = string.Empty, variedad = string.Empty, distribuidor = string.Empty, manifiesto = string.Empty, rack = string.Empty, fecha = string.Empty, lote = string.Empty, contenedor = string.Empty, lbsPallet = string.Empty, cajasPallet = string.Empty;
                    sql.OpenConectionWrite();
                    DataTable dt = new DataTable();
                    //SqlCommand cmd = new SqlCommand("SELECT Pallet, Mix, Estiba, Programa, Cajas, Libras, Tamaño, Presentación, Variedad, Distribuidor, Manifiesto, Rack, Fecha, Lote ,[Libras Pallet] ,Contenedor FROM vw_PackPalletCon WHERE Pallet = @idPallet", sql.cnn);
                    SqlCommand cmd = new SqlCommand("SELECT Pallet, Mix, Estiba, Programa, Cajas, Libras, Tamaño, Presentación, Variedad, Distribuidor, Manifiesto, Rack, Fecha, Lote ,[Libras Pallet] ,Contenedor, gtn.i_palletBoxes AS 'Cajas por pallet' FROM vw_PackPalletCon vpal LEFT JOIN gtn ON gtn.id_GTIN = vpal.Programa WHERE Pallet = @idPallet", sql.cnn);
                    cmd.Parameters.AddWithValue("@idPallet", idPallet);

                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //DataTable ds = new DataTable();
                    //da.Fill(dt);

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        pallet = rd["Pallet"].ToString();
                        mix = rd["Mix"].ToString();
                        estiba = rd["Estiba"].ToString();
                        programa = rd["Programa"].ToString();
                        cajas = rd["Cajas"].ToString();
                        libras = rd["Libras"].ToString();
                        tamaño = rd["Tamaño"].ToString();
                        presentacion = rd["Presentación"].ToString();
                        variedad = rd["Variedad"].ToString();
                        distribuidor = rd["Distribuidor"].ToString();
                        manifiesto = rd["Manifiesto"].ToString();
                        rack = rd["Rack"].ToString();
                        fecha = rd["Fecha"].ToString().Substring(0, 10);
                        lote = rd["Lote"].ToString();
                        contenedor = rd["Contenedor"].ToString();
                        lbsPallet = rd["Libras Pallet"].ToString();
                        cajasPallet = rd["Cajas por pallet"].ToString();
                    }
                    if (estiba.Length > 0)
                    {
                        DialogResult result = MessageBox.Show($"El pallet ya pertenece a la estiba {estiba}\n¿Desea agregarla?", "Reestibar pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            AñadirEstibaCompleta(dgv, estiba);
                        }
                        //else nada
                    }
                    else
                    {
                        if (pallet.Length > 0)
                        {
                            dgv.Rows.Add(pallet, mix, estiba, programa, cajas, libras, tamaño, presentacion, variedad, distribuidor, manifiesto, rack, fecha, lote, lbsPallet, contenedor, cajasPallet);
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
            
        }

        public void AñadirEstibaCompleta(DataGridView dgv, string idEstiba)
        {
            sql.CloseConectionWrite();
            sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT Pallet, Mix, Estiba, Programa, Cajas, Libras, Tamaño, Presentación, Variedad, Distribuidor, Manifiesto, Rack, Fecha, Lote ,[Libras Pallet] ,Contenedor, gtn.i_palletBoxes AS 'Cajas por pallet' FROM vw_PackPalletCon vpal LEFT JOIN gtn ON gtn.id_GTIN = vpal.Programa WHERE Estiba =  @idEstiba", sql.cnn);
                cmd.Parameters.AddWithValue("@idEstiba", idEstiba);

                SqlDataReader rd = cmd.ExecuteReader();

                List<string> pallets = new List<string>();
                List<string> mixes = new List<string>();
                List<string> estibas = new List<string>();
                List<string> programas = new List<string>();
                List<string> cajas = new List<string>();
                List<string> libras = new List<string>();
                List<string> tamanos = new List<string>();
                List<string> presentaciones = new List<string>();
                List<string> variedades = new List<string>();
                List<string> distribuidores = new List<string>();
                List<string> manifiestos = new List<string>();
                List<string> racks = new List<string>();
                List<string> fechas = new List<string>();
                List<string> lotes = new List<string>();
                List<string> contenedores = new List<string>();
                List<string> lbsPallets = new List<string>();
                List<string> cajasPallets = new List<string>();

                while (rd.Read())
                {
                    string pallet = rd["Pallet"].ToString();
                    string mix = rd["Mix"].ToString();
                    string estiba = rd["Estiba"].ToString();
                    string programa = rd["Programa"].ToString();
                    string caja = rd["Cajas"].ToString();
                    string libra = rd["Libras"].ToString();
                    string tamano = rd["Tamaño"].ToString();
                    string presentacion = rd["Presentación"].ToString();
                    string variedad = rd["Variedad"].ToString();
                    string distribuidor = rd["Distribuidor"].ToString();
                    string manifiesto = rd["Manifiesto"].ToString();
                    string rack = rd["Rack"].ToString();
                    string fecha = rd["Fecha"].ToString().Substring(0, 10);
                    string lote = rd["Lote"].ToString();
                    string contenedor = rd["Contenedor"].ToString();
                    string lbsPallet = rd["Libras Pallet"].ToString();
                    string cajasPallet = rd["Cajas por pallet"].ToString();


                pallets.Add(pallet);
                    mixes.Add(mix);
                    estibas.Add(estiba);
                    programas.Add(programa);
                    cajas.Add(caja);
                    libras.Add(libra);
                    tamanos.Add(tamano);
                    presentaciones.Add(presentacion);
                    variedades.Add(variedad);
                    distribuidores.Add(distribuidor);
                    manifiestos.Add(manifiesto);
                    racks.Add(rack);
                    fechas.Add(fecha);
                    lotes.Add(lote);
                    contenedores.Add(contenedor);
                    lbsPallets.Add(lbsPallet);
                    cajasPallets.Add(cajasPallet);
                }

                for (int i = 0; i < mixes.Count; i++)
                {
                    string pallet = pallets[i];
                    string mix = mixes[i];
                    string estiba = estibas[i];
                    string programa = programas[i];
                    string caja = cajas[i];
                    string libra = libras[i];
                    string tamano = tamanos[i];
                    string presentacion = presentaciones[i];
                    string variedad = variedades[i];
                    string distribuidor = distribuidores[i];
                    string manifiesto = manifiestos[i];
                    string rack = racks[i];
                    string fecha = fechas[i];
                    string lote = lotes[i];
                    string contenedor = contenedores[i];
                    string lbsPallet = lbsPallets[i];
                    string cajasPallet = cajasPallets[i];

                    dgv.Rows.Add(pallet, mix, estiba, programa, caja, libra, tamano, presentacion, variedad, distribuidor, manifiesto, rack, fecha, lote, lbsPallet, contenedor, cajasPallet);
                }
        }
        public void DgvColumnas(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = true;

            dgv.Columns.Add("Pallet", "Pallet");
            dgv.Columns.Add("Mix", "Mix");
            dgv.Columns.Add("Estiba", "Estiba");
            dgv.Columns.Add("Programa", "Programa");
            dgv.Columns.Add("Cajas", "Cajas");
            dgv.Columns.Add("Libras", "Libras");
            dgv.Columns.Add("Tamaño", "Tamaño");
            dgv.Columns.Add("Presentación", "Presentación");
            dgv.Columns.Add("Variedad", "Variedad");
            dgv.Columns.Add("Distribuidor", "Distribuidor");
            dgv.Columns.Add("Manifiesto", "Manifiesto");
            dgv.Columns.Add("Rack", "Rack");
            dgv.Columns.Add("Fecha", "Fecha");
            dgv.Columns.Add("Lote", "Lote");
            dgv.Columns.Add("Libras pallet", "Libras pallet");
            dgv.Columns.Add("Contenedor", "Contenedor");
            dgv.Columns.Add("Cajas por pallet", "Cajas por pallet");
        }
        public bool VerificarColumnaDiferente(DataGridView dataGridView, string nombreColumna)
        {
            int indiceColumna = dataGridView.Columns[nombreColumna].Index;

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                if (fila.Cells[indiceColumna].Value != null)
                {
                    string valorCelda = fila.Cells[indiceColumna].Value.ToString();

                    if (!valorCelda.Equals(dataGridView.Rows[0].Cells[indiceColumna].Value.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool VerificarNoVacio(DataGridView dataGridView, string nombreColumna)
        {
            int indiceColumna = dataGridView.Columns[nombreColumna].Index;

            string valorCelda = null;
            bool encontradoValor = false;

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                if (fila.Cells[indiceColumna].Value.ToString().Length > 0)
                //if (fila.Cells[indiceColumna].Value != null && !string.IsNullOrWhiteSpace(fila.Cells[indiceColumna].Value.ToString()))
                {
                    if (!encontradoValor)
                    {
                        valorCelda = fila.Cells[indiceColumna].Value.ToString();
                        encontradoValor = true;
                    }
                    else if (!valorCelda.Equals(fila.Cells[indiceColumna].Value.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool VerificarEstibaDiferente(DataGridView dataGridView)
        {
            int ind = dataGridView.Columns["Estiba"].Index;

            string celdaEvaluar = null;
            bool diferente = false;

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                string celdaFila = fila.Cells[ind].Value.ToString();
                if (celdaFila.Length > 0)
                {
                    if (!diferente)
                    {
                        celdaEvaluar = celdaFila;
                        diferente = true;
                    }
                    else if (celdaFila != celdaEvaluar)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string SumarCajas(DataGridView dgv)
        {
            int cajas = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Cajas"].Value != null)
                {
                    int suma;
                    if (int.TryParse(row.Cells["Cajas"].Value.ToString(), out suma))
                    {
                        cajas += suma;
                    }
                }
            }
            return cajas.ToString();
        }
        public void SeleccionarUltimo(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                int ultimaFila = dgv.Rows.Count - 1;
                dgv.CurrentCell = dgv.Rows[ultimaFila].Cells[0];
                dgv.Rows[ultimaFila].Cells[dgv.Columns.Count - 1].Selected = true;
            }
        }

        public void QuitarPallets(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgv.SelectedRows[0];
                string valorEstiba = filaSeleccionada.Cells["Estiba"].Value.ToString();

                if (!string.IsNullOrEmpty(valorEstiba) && valorEstiba.Length > 0)
                {
                    // Eliminar todas las filas que tienen el valor de Estiba
                    for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow fila = dgv.Rows[i];
                        if (fila.Cells["Estiba"].Value.ToString() == valorEstiba)
                        {
                            dgv.Rows.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    // Eliminar solo la fila seleccionada
                    dgv.Rows.Remove(filaSeleccionada);
                }
            }
        }

        public int CajasPorPalletMin(DataGridView dataGridView)
        {
            int valorMinimo = int.MaxValue;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Cajas por pallet"].Value != null)
                {
                    string valorCelda = row.Cells["Cajas por pallet"].Value.ToString();
                    int numero;
                    if (int.TryParse(valorCelda, out numero))
                    {
                        if (numero < valorMinimo)
                        {
                            valorMinimo = numero;
                        }
                    }
                }
            }
            return valorMinimo;
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
        public void MixtearPallets(DataGridView dgvPallet, string Cajas)
        {
            bool mixtear = true;
            int cajasProgramaMin = CajasPorPalletMin(dgvPallet);
            string advertencia = "";
            if (dgvPallet.RowCount > 1)
            {
                if(!VerificarNoVacio(dgvPallet, "Manifiesto"))
                { //diferente manifiesto
                    MessageBox.Show("Los pallets están en diferentes manifiestos, no se pueden mixtear.", "Mixteado pallet");
                    mixtear = false;
                }
                else
                {
                    if (!VerificarEstibaDiferente(dgvPallet))
                    {
                        DialogResult result = MessageBox.Show($"Los pallets a mixtear pertenecen a diferentes estibas\n\n¿Desea mixtearlos aún así?", "Mixteado pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            mixtear = false;
                        }
                        else if (result == DialogResult.Yes)
                        {
                            mixtear = true;
                        }
                    }
                    if(mixtear)
                    {
                        if (!VerificarColumnaDiferente(dgvPallet, "Programa"))
                        {
                            advertencia += "\n      -PROGRAMA";
                        }
                        if (!VerificarColumnaDiferente(dgvPallet, "Tamaño"))
                        {
                            advertencia += ", (TAMAÑO)";
                        }
                        if (!VerificarColumnaDiferente(dgvPallet, "Presentación"))
                        {
                            advertencia += ", (PRESENTACIÓN)";
                        }
                        if (!VerificarColumnaDiferente(dgvPallet, "Variedad"))
                        {
                            advertencia += ", (VARIEDAD)";
                        }
                        if (!VerificarColumnaDiferente(dgvPallet, "Distribuidor"))
                        {
                            advertencia += ", (DISTRIBUIDOR)";
                        }
                        if (!VerificarColumnaDiferente(dgvPallet, "Libras"))
                        {
                            advertencia += ", (LIBRAS (PESO))";
                        }
                        if (!VerificarColumnaDiferente(dgvPallet, "Contenedor"))
                        {
                            advertencia += ", (CONTENEDOR)";
                        }
                        if (!VerificarColumnaDiferente(dgvPallet, "Cajas por pallet"))
                        {
                            advertencia += ", (CAJAS POR PALLET)";
                        }
                        if (CajasPorPalletMin(dgvPallet) < int.Parse(Cajas))
                        {
                            advertencia += $"\n\n      -Las cajas del pallet mixteado ({Cajas}) son más que las cajas por pallet del programa ({cajasProgramaMin.ToString()}).";
                        }
                        if (advertencia.Length > 0)
                        {
                            DialogResult result = MessageBox.Show($"Los pallets a mixtear son diferentes en: \n{advertencia}\n\n¿Desea mixtearlos aún así?", "Mixteado pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                            {
                                mixtear = false;
                            }
                            else if (result == DialogResult.Yes)
                            {
                                mixtear = true;
                            }
                        }
                    }
                }
            }

            if (mixtear)
            {
                string idEstiba = ProcMixterPallets(dgvPallet);
                MessageBox.Show("Se mixtearon los pallets seleccionados en la estiba: "+idEstiba, "Mixteado pallet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPallet.Rows.Clear();
            }            
        }
        public string SiguienteEstiba()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT FORMAT(ISNULL(MAX(c_stowage) + 1, 1), '0000') AS 'Id' FROM Pack_Pallet", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["Id"].ToString();
                }
                return "0001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo Id siguiente");
                return "0000";
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }
        public string ProcMixterPallets( DataGridView dgv)
        {
            string sigEstiba = SiguienteEstiba();

            try
            {
                sql.OpenConectionWrite();
                int idMix = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    ++idMix;
                    string idPallet = row.Cells["Pallet"].Value.ToString();

                    SqlCommand cmd = new SqlCommand("sp_PackPalletAddStowage", sql.cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idPallet", idPallet);
                    cmd.Parameters.AddWithValue("@stowage", sigEstiba);
                    cmd.Parameters.AddWithValue("@intMixPallet", idMix);
                    cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                    cmd.ExecuteNonQuery();
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
            return sigEstiba;

        }
    }
}
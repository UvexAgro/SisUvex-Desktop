using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace SisUvex.Catalogos
{
    internal class ClsCatalogos
    {
        private SQLControl sql = new SQLControl();

        public string SpnHoraVacioNull(string entrada)
        {
            if (entrada == "  :")
            {
                return DBNull.Value.ToString();
            }
            else
            {
                return entrada;
            }
        }

        public string ConvertToNullable(string inputValue)
        {
            if (double.TryParse(inputValue, out double result) && result == 0)
            {
                return null;
            }

            return inputValue;
        }
        public string DuplicarDigitos(string numero)
        {
            if (numero.Length != 2)
            {
                throw new ArgumentException("El número debe tener exactamente dos dígitos.");
            }

            char primerDigito = numero[0];
            char segundoDigito = numero[1];

            string resultado = string.Concat(primerDigito, primerDigito, segundoDigito, segundoDigito);

            return resultado;
        }
        public bool String01aBool(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return false;
            }
            else if (valor == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LimpiarTextBox(Control control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
            }
        }
        public string SpnEsFechaObligatoria(MaskedTextBox spn)
        {
            string fechaTexto = spn.Text;
            DateTime fecha;

            if (string.IsNullOrEmpty(spn.Text.Replace("/", "")) || spn.Text.Replace("/", "") == "    ")
            {
                return "Fecha de plantación.\n";
            }

            if (!DateTime.TryParseExact(fechaTexto, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                return "Fecha de plantación (inválida).\n";
            }

            return "";
        }
        public string SpnEsFecha(MaskedTextBox spn)
        {
            string fechaTexto = spn.Text;
            DateTime fecha;

            if (string.IsNullOrEmpty(spn.Text.Replace("/", "")) || spn.Text.Replace("/", "") == "    ")
            {
                return "";
            }

            if (!DateTime.TryParseExact(fechaTexto, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                return "Fecha de plantación (inválida).\n";
            }

            return "";
        }
        public object ValorNullFecha(string texto)
        {
            if (texto == "  /  /")
            {
                return DBNull.Value; // Valor nulo para SQL Server
            }

            return texto;
        }

        #region CONSULTAS GENERICAS

        public string ObtenerDatoConsulta(string query)
        {
            string dato = string.Empty;

            try
            {
                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand(query, sql.cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        dato = reader[0].ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Obtener dato consulta.");
                return string.Empty;
            }
            finally
            {
                sql.CloseConectionWrite();
            }

            return dato;
        }

        #endregion FIN CONSULTAS GENERICAS

        #region CHECKBOX
        public string ValorCheckbox(bool valorCheckbox)
        {
            return valorCheckbox ? "1" : "0";
        }
        #endregion FIN CHECKBOX



                        #region TEXTBOX -------------------------------------------------------------------

        public string FormatoCeros(string numeroString, string formato)
        {
            string formatoLimpio = formato.Replace(".", string.Empty);

            string[] partes = formatoLimpio.Split('.');
            int longitudEntero = partes[0].Length;
            int longitudDecimal = partes.Length > 1 ? partes[1].Length : 0;

            string[] numeros = numeroString.Split('.');
            string parteEntera = numeros[0].PadLeft(longitudEntero, '0');
            string parteDecimal = numeros.Length > 1 ? numeros[1].PadRight(longitudDecimal, '0') : string.Empty;

            string resultado = parteEntera;

            if (longitudDecimal > 0)
            {
                resultado += "." + parteDecimal;
            }

            return resultado;
        }
        public object Id00Null(string numeroString)
        {
            int numeroEntero;

            if (int.TryParse(numeroString, out numeroEntero))
            {
                if (numeroEntero == 0)
                {
                    return DBNull.Value;
                }
            }
            return numeroString;

        }

        public void TxbFormatoNumeric(TextBox textBox, int maxNumero)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                int valor;
                if (int.TryParse(textBox.Text, out valor) && valor >= maxNumero)
                {
                    textBox.Text = string.Empty;
                }
            }
        }
        public void TxbTeclasEnteros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void TxbTeclasDecimales(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;

            }
        }

        public object ValorNull(string texto)
        {
            return string.IsNullOrEmpty(texto) ? DBNull.Value : (object)texto;
        }
        public string ValorCero(string texto)
        {
            return string.IsNullOrEmpty(texto) ? "0" : texto;
        }



        #endregion FIN TEXTBOX ------------------------------------------------------------

#region DATAGRIDVIEW ------------------------------------------------------s

        public void DataGridViewFormatoColumaActivo(DataGridView dataGridView, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Activo")
            {
                if (e.Value.ToString() == "0")
                {
                    e.CellStyle.BackColor = Color.Tomato;
                    e.CellStyle.ForeColor = Color.Red;
                }
                if (e.Value.ToString() == "1")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
        }

        public DataTable ConvertirDataGridViewADataTable(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Agregar columnas al DataTable
            foreach (DataGridViewColumn columna in dataGridView.Columns)
            {
                dataTable.Columns.Add(columna.HeaderText, typeof(string));
            }

            // Agregar filas al DataTable
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    dataRow[i] = fila.Cells[i].Value?.ToString();
                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        #endregion FIN DATAGRIDVIEW -----------------------------------------------

        #region CHECKBOX    -------------------------------------------------------
        public string Valor01CheckBox(bool valorCheckbox)
        {
            return valorCheckbox ? "1" : "0";
        }
        public bool ValorCheckbox(string valor)
        {
            if (valor == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion FIN CHECKBOX ---------------------------------------------------

        #region COMBOBOX ------------------------------------------------------------------
        public void CboSeleccionarConTexto(ComboBox cbo, string texto)
        {
            int indice = cbo.FindStringExact(texto);

            if (indice == -1)
            {
                cbo.Items.Add(texto);
                indice = cbo.Items.Count - 1;
            }
            cbo.SelectedIndex = indice;
        }

        public void CambiarEstadoEventosTextChanged(Form formulario, bool activar)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    if (activar)
                    {
                        comboBox.TextChanged += ComboBox_TextChanged;
                    }
                    else
                    {
                        comboBox.TextChanged -= ComboBox_TextChanged;
                    }
                }
            }
        }
        private static void ComboBox_TextChanged(object sender, EventArgs e)
        {
            //ESTE SOLO ESTA PARA QUE NO SE AFECTE AL DE ARRIBA
        }

        public string ConvertirFecha(string fecha)
        {
            DateTime dateTime;
            if (DateTime.TryParse(fecha, out dateTime))
            {
                string fechaConvertida = dateTime.ToString("yyyy-MM-dd");
                return fechaConvertida;
            }
            else
            {
                return string.Empty;
            }
        }
        public void CboIndiceValue(ComboBox cbo, TextBox txb)
        {
            if (cbo.Items.Count != 0 && txb.Text != string.Empty)
                for (int i = 0; i < cbo.Items.Count; i++)
                {
                    cbo.SelectedIndex = i;

                    if (cbo.SelectedValue.ToString() == txb.Text)
                    {
                        cbo.SelectedIndex = i;
                        return;
                    }
                }
        }
        public void CboIndiceValueTexto(ComboBox cbo, string texto)
        {
            if (cbo.Items.Count != 0 && texto != string.Empty)
                for (int i = 0; i < cbo.Items.Count; i++)
                {
                    cbo.SelectedIndex = i;

                    if (cbo.SelectedValue.ToString() == texto)
                    {
                        cbo.SelectedIndex = i;
                        return;
                    }
                }
        }
        public void CboIndiceValueTextChanged(ComboBox cbo, TextBox txb, EventHandler eventHandler)
        {
            cbo.TextChanged -= eventHandler;

            if (cbo.Items.Count != 0 && txb.Text != string.Empty)
                for (int i = 0; i < cbo.Items.Count; i++)
                {
                    cbo.SelectedIndex = i;

                    if (cbo.SelectedValue.ToString() == txb.Text)
                    {
                        cbo.TextChanged += eventHandler;
                        cbo.SelectedIndex = i;
                        return;
                    }
                }
        }
        public void CboCargarInicio(ComboBox c,DataTable d)
        {
            c.DataSource = d;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            if (c.Items.Count > 0)
            {
                if (c.DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    c.SelectedIndex = -1;
                    c.Text = "--Selecciona una opción--";
                }
                else
                {
                    try { c.SelectedIndex = 1; } catch { }
                    c.SelectedIndex = 0;
                }
            }
            
        }
        public string CboCargarEnBlanco(ComboBox c, DataTable d)
        {
            c.DataSource = d;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.SelectedIndex = -1;
            return string.Empty;
        }
        public void CboPrimerClic(ComboBox c)
        {
            if (c.Text == "--Selecciona una opción--")
            {
                c.SelectedIndex = -1;
                c.Text = "";
                c.DroppedDown = true;
            }
        }

        public string CboValueDelSeleccionado(ComboBox c)
        {
            if (c.SelectedIndex != -1 && c.SelectedValue.ToString() != "System.Data.DataRowView" && c.Text != "--Selecciona una opción--")
                return c.SelectedValue.ToString();
            else 
                return string.Empty;
        }

        public bool CboPertenece(ComboBox comboBox, string textoBuscado)
        {
            // Obtenemos el DataTable del DataSource del ComboBox
            if (comboBox.DataSource is DataTable dataTable)
            {
                // Verificamos si el DataTable contiene una columna llamada "Código"
                if (dataTable.Columns.Contains("Código"))
                {
                    // Recorremos cada fila del DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Verificamos si el valor del texto está presente en la columna "Código"
                        if (row["Código"].ToString() == textoBuscado)
                        {
                            return true; // Devolvemos verdadero si se encuentra el texto
                        }
                    }
                }
            }

            return false; // Devolvemos falso si no se encuentra el texto
        }
        public bool CboPerteneceYSelecciona(ComboBox c, string texto)
        {
            if (c.Items.Count != 0 && texto != string.Empty)
                for (int i = 0; i < c.Items.Count; i++)
                {
                    c.SelectedIndex = i;

                    if (c.SelectedValue.ToString() == texto)
                    {
                        c.SelectedIndex = i;
                        return true;
                    }
                }
            MessageBox.Show( c.SelectedIndex.ToString());
            return false;
        }
        #endregion FIN COMBOBOX ------------------------------------------------------------------

        #region DISTRIBUIDOR ---------------------------------------------------------------------
        public bool ActDis = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboDistribuidor(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_distributor 'Código', CONCAT(v_nameDistributor,' | ',id_distributor,' | (' ,c_active,')') 'Nombre' FROM Pack_Distributor WHERE c_active != '{activo}' OR id_distributor = '00') Distributor WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado distribuidor");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarDistribuidor(ComboBox c)
        {
            if(ActDis)
                c.DataSource = CboDistribuidor(c.Text,"0");
            else
                c.DataSource = CboDistribuidor(c.Text,"*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoDistribuidor(TextBox t, ComboBox c, Button b)
        {
            t.Text = string.Empty;
            if (ActDis)
                c.DataSource = CboDistribuidor("", "0");
            else
                c.DataSource = CboDistribuidor("", "*");
            
            ActDis = !ActDis;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActDis)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }
        #endregion FIN DISTRIBUIDOR ----------------------------------------------------------------------
        #region CONSIGNATARIO ---------------------------------------------------------------------
        public bool ActCons = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboConsignatario(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_consignee 'Código', CONCAT(v_nameConsignee,' | (',id_consignee,')') 'Nombre' FROM Pack_Consignee WHERE c_active != '{activo}') Consignee WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado distribuidor");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarConsignatario(ComboBox c)
        {
            if (ActCons)
                c.DataSource = CboConsignatario(c.Text, "0");
            else
                c.DataSource = CboConsignatario(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoConsignatario(TextBox t, ComboBox c, Button b)
        {
            t.Text = string.Empty;
            if (ActCons)
                c.DataSource = CboConsignatario("", "0");
            else
                c.DataSource = CboConsignatario("", "*");

            ActCons = !ActCons;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActCons)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }
        #endregion FIN CONSIGNATARIO ----------------------------------------------------------------------

        #region CHOFER ---------------------------------------------------------------------
        public bool ActCho = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboChofer(string texto, string activo, string idLinea)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM\r\n(SELECT id_driver 'Código', CONCAT(v_nameDriver,' ',v_lastNameDriver,' (',id_driver,')') 'Nombre' FROM Pack_Driver WHERE c_active != '{activo}' AND id_transportLine = '{idLinea}') Driver WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado distribuidor");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarChofer(ComboBox c,string idLinea)
        {
            if (ActCho)
                c.DataSource = CboChofer(c.Text, "0", idLinea);
            else
                c.DataSource = CboChofer(c.Text, "*", idLinea);

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoChofer(TextBox t, ComboBox c, Button b, string idLinea)
        {
            t.Text = string.Empty;
            if (ActCons)
                c.DataSource = CboChofer("", "0", idLinea);
            else
                c.DataSource = CboChofer("", "*", idLinea);

            ActCho = !ActCho;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActCho)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }
        #endregion FIN CHOFER ----------------------------------------------------------------------

        #region TROQUE ---------------------------------------------------------------------
        public bool ActTro = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboTroque(string texto, string activo, string idLinea)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM( SELECT id_truck AS 'Código', CONCAT(v_ecoNumber, CASE WHEN v_plateUS IS NOT NULL AND v_plateMX IS NOT NULL THEN CONCAT(' | ', v_plateUS, ' | ', v_plateMX)  WHEN v_plateUS IS NOT NULL THEN CONCAT(' | ', v_plateUS) WHEN v_plateMX IS NOT NULL THEN CONCAT(' | ', v_plateMX) ELSE '' END, ' | (',id_truck,')') AS 'Nombre' FROM Pack_Truck WHERE c_active != '{activo}' AND id_transportLine = '{idLinea}') Truck WHERE Nombre LIKE '%{texto}%'ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado distribuidor");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarTroque(ComboBox c, string idLinea)
        {
            if (ActCho)
                c.DataSource = CboTroque(c.Text, "0", idLinea);
            else
                c.DataSource = CboTroque(c.Text, "*", idLinea);

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoTroque(TextBox t, ComboBox c, Button b, string idLinea)
        {
            t.Text = string.Empty;
            if (ActCons)
                c.DataSource = CboTroque("", "0", idLinea);
            else
                c.DataSource = CboTroque("", "*", idLinea);

            ActTro = !ActTro;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActTro)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }
        #endregion FIN TROQUE ----------------------------------------------------------------------

        #region CAJA ---------------------------------------------------------------------
        public bool ActCaja = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboCaja(string texto, string activo, string idLinea)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM( SELECT id_freightContainer AS 'Código', CONCAT(v_ecoNumber, CASE WHEN v_plateUS IS NOT NULL AND v_plateMX IS NOT NULL THEN CONCAT(' | ', v_plateUS, ' | ', v_plateMX) WHEN v_plateUS IS NOT NULL THEN CONCAT(' | ', v_plateUS) WHEN v_plateMX IS NOT NULL THEN CONCAT(' | ', v_plateMX) ELSE '' END, ' | (',id_freightContainer,')') AS 'Nombre' FROM Pack_FreightContainer WHERE c_active != '{activo}' AND id_transportLine = '{idLinea}') Truck WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre ", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado distribuidor");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarCaja(ComboBox c, string idLinea)
        {
            if (ActCaja)
                c.DataSource = CboCaja(c.Text, "0", idLinea);
            else
                c.DataSource = CboCaja(c.Text, "*", idLinea);

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoCaja(TextBox t, ComboBox c, Button b, string idLinea)
        {
            t.Text = string.Empty;
            if (ActCaja)
                c.DataSource = CboCaja("", "0", idLinea);
            else
                c.DataSource = CboCaja("", "*", idLinea);

            ActCaja = !ActCaja;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActCaja)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }
        #endregion FIN CAJA ----------------------------------------------------------------------
        #region PRODUCTOR ------------------------------------------------------
        public bool ActPro = true; //TRUE TODOS, FALSE ACTIVOS

        public DataTable CboProductor(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_grower 'Código', CONCAT(v_nameGrower,' | ',id_grower,' | (',c_active,')') 'Nombre' FROM Pack_Grower WHERE c_active != '{activo}' OR id_grower = '00') Grower WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado productor");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarProductor(ComboBox c)
        {
            if (ActPro)
                c.DataSource = CboProductor(c.Text, "0");
            else
                c.DataSource = CboProductor(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoProductor(TextBox t, ComboBox c, Button b)
        {
            t.Text = string.Empty;
            if (ActPro)
                c.DataSource = CboProductor("", "0");
            else
                c.DataSource = CboProductor("", "*");

            ActPro = !ActPro;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActPro)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }

        #endregion FIN PRODUCTOR -----------------------------------------------

#region AGENCIA US --------------------------------------------------------
        public bool ActAgUS = true; //TRUE TODOS, FALSE ACTIVOS

        public DataTable CboAgenciaUS(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_agencyTrade 'Código', CONCAT(v_nameAgency,' | ',id_agencyTrade, ' | (',c_active, ')') 'Nombre' FROM Pack_AgencyTrade WHERE c_active != '{activo}' AND c_country = 'US' OR id_agencyTrade = '00') AgencyTrade WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado agencia extranjera");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void BtnBuscarAgenciaUS(ComboBox c)
        {
            if (ActAgUS)
                c.DataSource = CboAgenciaUS(c.Text, "0");
            else
                c.DataSource = CboAgenciaUS(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }

        public void BtnTodoAgenciaUS(TextBox t, ComboBox c, Button b)
        {
            t.Text = string.Empty;
            if (ActAgUS)
                c.DataSource = CboAgenciaUS("", "0");
            else
                c.DataSource = CboAgenciaUS("", "*");

            ActAgUS = !ActAgUS;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActAgUS)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }


        #endregion FIN AGENCIA US ------------------------------------------------------------------

#region AGENCIA MX -------------------------------------------------------------------------
        public bool ActAgMX = true; //TRUE TODOS, FALSE ACTIVOS

        public DataTable CboAgenciaMX(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_agencyTrade 'Código', CONCAT(v_nameAgency,' | ',id_agencyTrade, ' | (',c_active, ')') 'Nombre' FROM Pack_AgencyTrade WHERE c_active != '{activo}' AND c_country = 'MX' OR id_agencyTrade = '00') AgencyTrade WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado agencia nacional");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void BtnBuscarAgenciaMX(ComboBox c)
        {
            if (ActAgMX)
                c.DataSource = CboAgenciaMX(c.Text, "0");
            else
                c.DataSource = CboAgenciaMX(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }

        public void BtnTodoAgenciaMX(TextBox t, ComboBox c, Button b)
        {
            t.Text = string.Empty;
            if (ActAgMX)
                c.DataSource = CboAgenciaMX("", "0");
            else
                c.DataSource = CboAgenciaMX("", "*");

            ActAgMX = !ActAgMX;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActAgMX)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }

        #endregion FIN AGENCIA MX ------------------------------------------------------------------

#region CIUDAD -------------------------------------------------------------
        public bool ActCiu = true; //TRUE TODOS, FALSE ACTIVOS

        public DataTable CboCiudad(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_city 'Código', CONCAT(v_nameCity,', ',v_state,', ',v_country,' | ',id_city,' | (',c_active,')') 'Nombre' FROM Pack_City WHERE c_active != '{activo}' OR id_city = '000') City WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado ciudad");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarCiudad(ComboBox c)
        {
            if (ActCiu)
                c.DataSource = CboCiudad(c.Text, "0");
            else
                c.DataSource = CboCiudad(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoCiudad(TextBox t, ComboBox c, Button b)
        {
            t.Text = string.Empty;
            if (ActCiu)
                c.DataSource = CboCiudad("", "0");
            else
                c.DataSource = CboCiudad("", "*");

            ActCiu = !ActCiu;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }

            if (ActCiu)
                b.Text = "Activo";
            else
                b.Text = "Todo";
        }
        #endregion FIN CIUDAD ------------------------------------------------------

#region LÍNEA DE TRANSPORTE ---------------------------------------------------------------------
        public bool ActLin = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboLinea(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_transportLine 'Código', CONCAT(v_nameTransportLine, '	| ', id_transportLine, ' | (', c_active, ')') 'Nombre' FROM Pack_TransportLine WHERE c_active != '{activo}') TransportLine WHERE Nombre LIKE '%{texto}%'", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado línea de transporte");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarLinea(ComboBox c)
        {
            if (ActLin)
                c.DataSource = CboLinea(c.Text, "0");
            else
                c.DataSource = CboLinea(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public string BtnTodoLinea(ComboBox c)
        {
            string v = string.Empty;
            if (ActLin)
                c.DataSource = CboLinea("", "0");
            else
                c.DataSource = CboLinea("", "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            ActLin = !ActLin;
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            return v;
        }
        #endregion FIN DISTRIBUIDOR ----------------------------------------------------------------------

#region CONTRATISTA ---------------------------------------------------------------------
        public bool ActCon = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboContratista(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_contractor 'Código', CONCAT(v_nameContractor,' | ',id_contractor, ' | (',c_active,')') Nombre FROM Pack_Contractor WHERE c_active != '{activo}') Contractor WHERE Nombre LIKE '%{texto}%'", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado contratista");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarContratista(ComboBox c)
        {
            if (ActDis)
                c.DataSource = CboContratista(c.Text, "0");
            else
                c.DataSource = CboContratista(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public string BtnTodoContratista(ComboBox c)
        {
            string v = string.Empty;
            if (ActDis)
                c.DataSource = CboContratista("", "0");
            else
                c.DataSource = CboContratista("", "*");

            ActDis = !ActDis;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            return v;
        }
        #endregion FIN CONTRATISTA ----------------------------------------------------------------------

#region TIPO DE MATERIAL -------------------------------------------------------------------------
        public DataTable CboTipoMaterial(string texto)
        {
            DataSet ds = new DataSet();

            try
            {

                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_matType 'Código', CONCAT(v_nameMatType,' | ',id_matType) 'Nombre' FROM Pack_MaterialType) MaterialType WHERE Nombre LIKE '%{texto}%' order by Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado tipo de material");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public string BtnBuscarMatTipo(ComboBox c)
        {
            string v = string.Empty;
            c.DataSource = CboTipoMaterial(c.Text);
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            return v;
        }
        public string BtnTodoMatTipo(ComboBox c, EventHandler handler)
        {
            c.TextChanged += handler;
            string v = string.Empty;
            c.DataSource = CboTipoMaterial("");
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = -1;
               // c.SelectedValue = v;
            }
            c.Text = v;
            return v;
        }
        #endregion FIN TIPO MATERIAL ------------------------------------------------------------------

        #region TIPO DE MATERIAL QUE SEAN CONTENEDOR ---------------------------------------------------------
        public DataTable CboTipoMaterialContenedores(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_matType 'Código', CONCAT(v_nameMatType,' | ',id_matType) 'Nombre' FROM Pack_MaterialType WHERE c_bigCategory = 'C' ) MaterialType WHERE Nombre LIKE '%{texto}%' order by Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado tipo de material");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public string BtnBuscarMatTipoContenedores(ComboBox c)
        {
            string v = string.Empty;
            c.DataSource = CboTipoMaterialContenedores(c.Text);
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            return v;
        }
        public string BtnTodoMatTipoContenedores(ComboBox c, EventHandler handler)
        {
            c.TextChanged += handler;
            string v = string.Empty;
            c.DataSource = CboTipoMaterialContenedores("");
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = -1;
                // c.SelectedValue = v;
            }
            c.Text = v;
            return v;
        }


        #endregion FIN TIPO MATERIAL QUE SEAN CONTENEDOR -----------------------------------------------------

        #region COLOR ---------------------------------------------------------------------------------
        public DataTable CboColor(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_color 'Código', CONCAT(v_nameColor,' | ',id_color) 'Nombre' FROM Pack_Color) Color WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado color");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        #endregion FIN COLOR ------------------------------------------------------------------
        #region CULTIVO ---------------------------------------------------------------------------------
        public DataTable CboCultivo()
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_crop 'Código', CONCAT(v_nameCrop,' | ',id_crop) 'Nombre' FROM Pack_Crop) Cultivo ", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado cultivo");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        #endregion FIN CULTIVO ------------------------------------------------------------------

        #region UNIDAD -------------------------------------------------------------------------
        public DataTable CboUnidad(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_unit 'Código', CONCAT(v_nameUnit,' | ',id_unit) 'Nombre' FROM Pack_Unit) Unit WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado unidad");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public string TxbUnidad(string id)
        {
            if (id != string.Empty)
            {
                try
                {
                    sql.OpenConectionWrite();
                    SqlCommand c = new SqlCommand($"SELECT uni.v_nameUnit 'Nombre' FROM Pack_Material mat JOIN Pack_Unit uni ON uni.id_unit = mat.id_unit WHERE mat.id_material = @id", sql.cnn);
                    SqlDataAdapter da = new SqlDataAdapter(c);

                    c.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = c.ExecuteReader();

                    if (reader.Read())
                    {
                        id = reader["Nombre"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Obtener unidad");

                }
                finally
                {
                    sql.CloseConectionWrite();
                }
            }
            return id;
        }
        #endregion FIN UNIDAD ------------------------------------------------------------------

#region VARIEDAD -----------------------------------------------------------------------
        public bool ActVar = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboVariedad(string texto, string activo, string color)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_variety 'Código', CONCAT(v_nameComercial,' | ',id_variety,' | (',c_active,') | ',v_nameScientis) 'Nombre' FROM Pack_Variety WHERE c_active != '{activo}' OR id_color LIKE '%{color}%') Variety WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado variedad");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarVariedad(ComboBox c,string color)
        {
            if (ActVar)
                c.DataSource = CboVariedad(c.Text, "0",color);
            else
                c.DataSource = CboVariedad(c.Text, "*", color);

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public string BtnTodoVariedad(ComboBox c, string color)
        {
            string v = string.Empty;
            if (ActVar)
                c.DataSource = CboVariedad("", "0", color);
            else
                c.DataSource = CboVariedad("", "*", color);

            ActVar = !ActVar;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            return v;
        }
        #endregion FIN VARIEDAD ----------------------------------------------------------------------

#region MATERIAL -------------------------------------------------------------------------
        public DataTable CboMaterial(string idTipoMat, string material)
        {
            if (idTipoMat == string.Empty)
                idTipoMat = "";
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlCommand c = new SqlCommand($"SELECT Código, Nombre FROM (SELECT id_material 'Código', CONCAT(v_nameMat,' | ',id_material, ' | ', dis.v_nameDistributor) 'Nombre' FROM Pack_Material mat JOIN Pack_Distributor dis ON dis.id_distributor = mat.id_distributor) Material WHERE Nombre LIKE '%{idTipoMat}%' AND Nombre LIKE '%{material}%'", sql.cnn);
                //c.Parameters.AddWithValue("@idTipoMat", idTipoMat);
                //c.Parameters.AddWithValue("@material", material);
                SqlDataAdapter da = new SqlDataAdapter(c);

                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado tipo de material");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public string BtnBuscarMaterial(ComboBox c, string t)
        {
            string v;
            c.DataSource = CboMaterial(c.Text, t);
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            else
                v = string.Empty;
            return v;
        }
        public string BtnTodoMaterial(ComboBox c)
        {
            string v = string.Empty;
            c.DataSource = CboMaterial("","");
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
            }
            return v;
        }
        #endregion FIN MATERIAL ------------------------------------------------------------------

#region LOTE ---------------------------------------------------------------------------------
        public bool ActLot = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboLote(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT lot.id_lot AS 'Código',  CONCAT(lot.v_nameLot,' | ',lot.id_lot,' | ',var.v_nameComercial,CASE WHEN var.v_nameScientis IS NOT NULL THEN CONCAT(' (', var.v_nameScientis, ')') ELSE '' END) 'Nombre' FROM Pack_Lot lot JOIN Pack_variety var ON var.id_variety = lot.id_variety WHERE lot.c_active != '{activo}') Lot WHERE Nombre LIKE '%{texto}%'", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado lotes");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarLote(ComboBox c)
        {
            if (ActLot)
                c.DataSource = CboLote(c.Text, "0");
            else
                c.DataSource = CboLote(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public string BtnTodoLote(ComboBox c)
        {
            string v = string.Empty;
            if (ActLot)
                c.DataSource = CboLote("", "0");
            else
                c.DataSource = CboLote("", "*");

            ActLot = !ActLot;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            return v;
        }

        //-------------------- LOTE CON VARIEDAD
        public bool ActLotVar = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboLoteVariedad(string texto, string activo)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT CONCAT(lot.id_lot,'|',lot.id_variety) AS 'Código', CONCAT(lot.v_nameLot,' (',lot.id_lot,'|',lot.id_variety,')',[var].v_nameComercial,' ',  CASE WHEN [var].v_nameScientis IS NOT NULL AND [var].v_nameScientis != [var].v_nameComercial THEN CONCAT(' (', [var].v_nameScientis, ')') ELSE '' END) AS 'Nombre'  FROM Pack_Lot lot JOIN Pack_variety [var] ON [var].id_variety = lot.id_variety WHERE lot.c_active != '{activo}') Lot WHERE Nombre LIKE '%{texto}%'", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado lotes y variedad");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarLoteVariedad(ComboBox c)
        {
            if (ActLotVar)
                c.DataSource = CboLote(c.Text, "0");
            else
                c.DataSource = CboLote(c.Text, "*");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public string BtnTodoLoteVariedad(ComboBox c)
        {
            string v = string.Empty;
            if (ActLotVar)
                c.DataSource = CboLoteVariedad("", "0");
            else
                c.DataSource = CboLoteVariedad("", "*");

            ActLotVar = !ActLotVar;
            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                v = c.SelectedValue.ToString();
            }
            return v;
        }

        #endregion FIN LOTE

        #region MAT PROVEEDOR----------------------------------------------------------------
        public DataTable CboMatProveedor(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT v_supplier 'Nombre' FROM Pack_MaterialRecord WHERE v_supplier LIKE '%{texto}%' AND v_supplier IS NOT NULL GROUP BY v_supplier ORDER BY v_supplier", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado proveedor");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarMatProveedor(ComboBox c)
        {
            c.DataSource = CboMatProveedor(c.Text);
            c.DisplayMember = "Nombre";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoMatProveedor(ComboBox c)
        {
            c.DataSource = CboMatProveedor("");
            c.DisplayMember = "Nombre";
            c.DroppedDown = true;
            c.Text = string.Empty;
            c.Focus();
        }
        #endregion FIN PROVEEDOR------------------------------------------------------------------------

#region MAT LINEA DE TRANSPORTE ----------------------------------------------------------------
        public DataTable CboMatLineaTransporte(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT v_transportLine 'Nombre' FROM Pack_MaterialRecord WHERE v_transportLine LIKE '%{texto}%' AND v_transportLine IS NOT NULL GROUP BY v_transportLine ORDER BY v_transportLine\r\n", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado línea de transpoerte");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarMatLineaTransporte(ComboBox c)
        {
            c.DataSource = CboMatLineaTransporte(c.Text);
            c.DisplayMember = "Nombre";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoMatLineaTransporte(ComboBox c)
        {
            c.DataSource = CboMatLineaTransporte("");
            c.DisplayMember = "Nombre";
            c.DroppedDown = true;
            c.Text = string.Empty;
            c.Focus();
        }

        #endregion MAT LINEA DE TRANSPORTE ----------------------------------------------------------------

#region MATERIAL CONTENEDOR
        public bool ActMatCon = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboMaterialContenedor(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_material 'Código', CONCAT(mat.v_nameMat,' | ',mat.id_material, ' | ', dis.v_nameDistributor) 'Nombre' FROM Pack_Material mat JOIN Pack_Distributor dis ON dis.id_distributor = mat.id_distributor JOIN Pack_MaterialType mty ON mty.id_matType = mat.id_matType WHERE mty.c_bigCategory = 'C') Material WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado contenedor");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        //ESTOS DE ACA ABAJO NO ESTAN TERMINADOS (NO ESTAN MOFICADOS SOLO ESTAN COPIADOS Y PEGADOS DE OTRA PARTE)
        //public void BtnBuscarMaterialContenedor(ComboBox c, string color)
        //{
        //    if (ActMatCon)
        //        c.DataSource = CboMaterialContenedor(c.Text, "0", color);
        //    else
        //        c.DataSource = CboMaterialContenedor(c.Text, "*", color);

        //    c.DisplayMember = "Nombre";
        //    c.ValueMember = "Código";
        //    c.DroppedDown = true;
        //    c.Focus();
        //}
        //public string BtnTodoMaterialContenedor(ComboBox c, string color)
        //{
        //    string v = string.Empty;
        //    if (ActMatCon)
        //        c.DataSource = CboMaterialContenedor("", "0", color);
        //    else
        //        c.DataSource = CboMaterialContenedor("", "*", color);

        //    ActMatCon = !ActMatCon;
        //    c.DisplayMember = "Nombre";
        //    c.ValueMember = "Código";
        //    c.DroppedDown = true;
        //    c.Focus();
        //    if (c.Items.Count > 0)
        //    {
        //        c.SelectedIndex = 0;
        //        v = c.SelectedValue.ToString();
        //    }
        //    return v;
        //}


        #endregion MATERIAL CONTENEDOR

#region MATERIAL PRESENTACION
        public bool ActMatPre = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboMaterialPresentacion(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_material 'Código', CONCAT(mat.v_nameMat,' | ',mat.id_material, ' | ', dis.v_nameDistributor) 'Nombre' FROM Pack_Material mat JOIN Pack_Distributor dis ON dis.id_distributor = mat.id_distributor JOIN Pack_MaterialType mty ON mty.id_matType = mat.id_matType WHERE mty.c_bigCategory = 'P') Material WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado contenedor");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        //ESTOS DE ACA ABAJO NO ESTAN TERMINADOS (NO ESTAN MOFICADOS SOLO ESTAN COPIADOS Y PEGADOS DE OTRA PARTE)
        //public void BtnBuscarMaterialContenedor(ComboBox c, string color)
        //{
        //    if (ActMatCon)
        //        c.DataSource = CboMaterialContenedor(c.Text, "0", color);
        //    else
        //        c.DataSource = CboMaterialContenedor(c.Text, "*", color);

        //    c.DisplayMember = "Nombre";
        //    c.ValueMember = "Código";
        //    c.DroppedDown = true;
        //    c.Focus();
        //}
        //public string BtnTodoMaterialContenedor(ComboBox c, string color)
        //{
        //    string v = string.Empty;
        //    if (ActMatCon)
        //        c.DataSource = CboMaterialContenedor("", "0", color);
        //    else
        //        c.DataSource = CboMaterialContenedor("", "*", color);

        //    ActMatCon = !ActMatCon;
        //    c.DisplayMember = "Nombre";
        //    c.ValueMember = "Código";
        //    c.DroppedDown = true;
        //    c.Focus();
        //    if (c.Items.Count > 0)
        //    {
        //        c.SelectedIndex = 0;
        //        v = c.SelectedValue.ToString();
        //    }
        //    return v;
        //}


        #endregion MATERIAL CONTENEDOR

#region MATERIAL TARIMA ---------------------------------------------------------------------------
        public bool ActMatTar = true; //TRUE TODOS, FALSE ACTIVOS
        public DataTable CboMaterialTarima(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_material 'Código', CONCAT(mat.v_nameMat,' | ',mat.id_material, ' | ', dis.v_nameDistributor) 'Nombre' FROM Pack_Material mat JOIN Pack_Distributor dis ON dis.id_distributor = mat.id_distributor JOIN Pack_MaterialType mty ON mty.id_matType = mat.id_matType WHERE mty.c_bigCategory = 'T') Material WHERE Nombre LIKE '%{texto}%' ORDER BY Nombre", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado tarima");
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        #endregion FINAL MATERIAL TARIMA---------------------------------------------------------


#region CUADRILLA (GRUPO DE TRABAJO) -------------------------------------------------------------
        public DataTable CboCuadrilla(string texto)
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Código, Nombre FROM (SELECT id_workGroup AS 'Código', CONCAT(id_workGroup,COALESCE(' ('+con.v_nameContractor+')',NULL)) 'Nombre' FROM Pack_WorkGroup wgp LEFT JOIN Pack_Contractor con ON con.id_contractor = wgp.id_contractor WHERE wgp.c_active = '1') WorkGroup WHERE Nombre LIKE '%{texto}%' ", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado distribuidor");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnBuscarCuadrilla(ComboBox c)
        {
            c.DataSource = CboCuadrilla(c.Text);

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
        }
        public void BtnTodoCuadrilla(TextBox t, ComboBox c)
        {
            t.Text = string.Empty;
            c.DataSource = CboCuadrilla("");

            c.DisplayMember = "Nombre";
            c.ValueMember = "Código";
            c.DroppedDown = true;
            c.Focus();
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 0;
                t.Text = c.SelectedValue.ToString();
            }
        }

        #endregion CUADRILLA (GRUPO DE TRABAJO)-------------------------------------------

        #region TAMAÑO
        public DataTable CboTamaño()
        {
            DataSet ds = new DataSet();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT id_size 'Código', CONCAT(v_sizeValue,' | (',id_size,')') 'Nombre'  FROM Pack_Size WHERE c_active = 1", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado lotes");
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public string ValorNullEmptyZero(string valor)
        {
            decimal valorDecimal;
            if (string.IsNullOrEmpty(valor) || !decimal.TryParse(valor, out valorDecimal) || valorDecimal == 0)
            {
                return null;
            }
            else
            {
                return valor;
            }
        }
        public string ValorNullEmptyZeroEnBD(string valor)
        {
            decimal valorDecimal;
            if (string.IsNullOrEmpty(valor) || !decimal.TryParse(valor, out valorDecimal) || valorDecimal == 0)
            {
                return DBNull.Value.ToString();
            }
            else
            {
                return valor;
            }
        }
        #endregion FINREGION
    }
}

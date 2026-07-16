using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using System.Data;
using System.Data.SqlClient;
using System.Media;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Operacion
{
    internal class ClsCajasGranelRegistro : ClsCatalogos
    {
        private SQLControl sql = new SQLControl();
        public FrmCajasGranelRegistroCat frmCat;
        public FrmCajasGranelRegistro frmAdd;
        ClsControls controlList;
        ClsDGVCatalog dgv;
        DataTable? dtCatalog;
        public string titulo = "Registro de cajas a granel";
        string queryCatalogo = " SELECT vw.* FROM vw_Pack_BulkReception vw ";
        public bool IsAddOrModify = true, IsAddUpdate = false, IsModifyUpdate = false;
        public string? idAddModify;

        public void OpenFrmAdd()
        {
            idAddModify = null;
            IsAddOrModify = true;
            IsAddUpdate = false;
            frmAdd = new();
            frmAdd.cls = this;
            frmAdd.Text = "Añadir registro de granel";
            frmAdd.ShowDialog();
        }

        public void FrmAddModifyBegin()
        {
            LoadControlsAddModify();

            if (IsAddOrModify)
            {
                frmAdd.txbId.Text = ClsQuerysDB.GetData(" SELECT FORMAT(COALESCE(MAX(id_bulk), 0) +1, '00000') AS [Id] from Pack_BulkReception ");
            }
            else
            {
                frmAdd.txbKgTotales.Enabled = false;
                frmAdd.txbTaraTarima.Enabled = false;
                frmAdd.txbTaraCaja.Enabled = false;

                LlenarFormularioModificar(idAddModify);

                ClsComboBoxes.CboSelectIndexWithTextInValueMember(frmAdd.cboWorkGroup, frmAdd.txbIdWorkGroup);
            }
        }

        public void OpenFrmModify(string? idModify)
        {
            IsAddOrModify = false;
            IsModifyUpdate = false;

            if (string.IsNullOrEmpty(idModify))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No se ha seleccionado un registro de granel.", "Modificar registro de granel");
                return;
            }
            idAddModify = idModify;
            frmAdd = new();
            frmAdd.cls = this;
            frmAdd.Text = "Modificar registro de granel";
            frmAdd.ShowDialog();
        }

        public void LoadControlsAddModify()
        {
            frmAdd.cboTroque.DataSource = CboTroqueGranelRegistro();
            frmAdd.cboTroque.DisplayMember = "Nombre";
            frmAdd.cboTroque.SelectedIndex = -1;

            frmAdd.cboChofer.DataSource = CboChoferGranelRegistro();
            frmAdd.cboChofer.DisplayMember = "Nombre";
            frmAdd.cboChofer.SelectedIndex = -1;

            ClsComboBoxes.CboLoadActives(frmAdd.cboLote, ClsObject.Lot.Cbo);
            ClsComboBoxes.CboLoadActives(frmAdd.cboWorkGroup, ClsObject.WorkGroup.Cbo);

            ClsComboBoxes.CboApplyTextChangedEvent(frmAdd.cboLote, frmAdd.txbIdLote);
            ClsComboBoxes.CboApplyTextChangedEvent(frmAdd.cboWorkGroup, frmAdd.txbIdWorkGroup);
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(frmAdd.txbCajasRegistro);
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(frmAdd.txbKgTotales);
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(frmAdd.txbTaraTarima);
            ClsTextBoxes.TxbApplyKeyPressEventDecimal(frmAdd.txbTaraCaja);

            AddControlsToList();
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();
            controlList.ChangeHeadMessage("Para hacer un registro de granel se debe:\n");
            controlList.Add(frmAdd.txbPapeleta, "Introducir papeleta.");
            controlList.Add(frmAdd.txbKgTotales, "Introducir kilos totales.");
            controlList.Add(frmAdd.txbIdWorkGroup, "Seleccionar una cuadrilla.");
        }

        

        public void AddItemAlDGV()
        {
            decimal tKgTotalesNetos, tKgTotales = decimal.Parse(frmAdd.txbKgTotales.Text), tTaraTarima = decimal.Parse(frmAdd.txbTaraTarima.Text), tTaraCaja = decimal.Parse(frmAdd.txbTaraCaja.Text);
            decimal tCajasFila = decimal.Parse(frmAdd.txbCajasRegistro.Text), tCajasTotales = decimal.Parse(frmAdd.txbCajasTotales.Text);

            tKgTotalesNetos = tKgTotales - tTaraTarima - tTaraCaja * (tCajasTotales + tCajasFila);

            if (tKgTotalesNetos <= 0)
            {
                MessageBox.Show("Los kilogramos netos no pueden ser menores o iguales a cero", titulo);
                return;
            }

            if (frmAdd.dgvRegistros.Rows.Count == 0)
            {
                frmAdd._KgTotales = tKgTotales;
                frmAdd._TaraTarima = tTaraTarima;
                frmAdd._TaraCaja = tTaraCaja;
            }
            frmAdd._CajasFila = tCajasFila;

            frmAdd._CajasTotales += frmAdd._CajasFila;

            AlterKgTotalesNetos();

            frmAdd.dgvRegistros.Rows.Add(frmAdd.txbCajasRegistro.Text, "", frmAdd.txbIdLote.Text, frmAdd.cboLote.Text);

            frmAdd.txbKgNetos.Text = Math.Round(frmAdd._KgTotalesNetos, 2).ToString();

            AlterKgPorCaja();

            frmAdd.txbKgPorCaja.Text = Math.Round(frmAdd._KgPorCaja, 2).ToString();

            ActualizarKilogramosPorCaja();

            //dgv.Rows[dgv.Rows.Count - 1].Selected = true;

            frmAdd.txbCajasTotales.Text = frmAdd._CajasTotales.ToString();
            frmAdd.txbCajasRegistro.Text = string.Empty;
            frmAdd.txbKgTotales.Enabled = false;
            frmAdd.txbTaraTarima.Enabled = false;
            frmAdd.txbTaraCaja.Enabled = false;
            frmAdd.cboLote.Focus();
        }

        public void RemoveItemAlDGV()
        {
            if (frmAdd.dgvRegistros.SelectedRows.Count > 0)
            {
                DataGridViewCell celdaCajas = frmAdd.dgvRegistros.SelectedRows[0].Cells["Cajas"];
                frmAdd._CajasFila = decimal.Parse(celdaCajas.Value.ToString());

                frmAdd.dgvRegistros.Rows.RemoveAt(frmAdd.dgvRegistros.SelectedRows[0].Index);

                frmAdd._CajasTotales -= frmAdd._CajasFila;

                frmAdd.txbCajasTotales.Text = frmAdd._CajasTotales.ToString();

                AlterKgTotalesNetos();

                frmAdd.txbKgNetos.Text = Math.Round(frmAdd._KgTotalesNetos, 2).ToString();

                AlterKgPorCaja();

                frmAdd.txbKgPorCaja.Text = Math.Round(frmAdd._KgPorCaja, 2).ToString();

                ActualizarKilogramosPorCaja();
            }

            if (frmAdd._CajasTotales == 0) 
            {
                frmAdd.txbKgTotales.Enabled = true;
                frmAdd.txbTaraTarima.Enabled = true;
                frmAdd.txbTaraCaja.Enabled = true;
            }
        }
            
        public void ReiniciarValores()
        {
            frmAdd._KgTotalesNetos = 0;
            frmAdd._KgTotales = 0;
            frmAdd._TaraTarima = 0;
            frmAdd._TaraCaja = 0;
            frmAdd._CajasTotales = 0;
            frmAdd._CajasFila = 0;
            frmAdd._KgPorCaja = 0;
        }

        private void AlterKgTotalesNetos()
        {
            frmAdd._KgTotalesNetos = frmAdd._KgTotales - frmAdd._TaraTarima - frmAdd._TaraCaja * frmAdd._CajasTotales;
        }
        private void AlterKgPorCaja()
        {
            if (frmAdd._CajasTotales != 0)
                frmAdd._KgPorCaja = frmAdd._KgTotalesNetos / frmAdd._CajasTotales;
            else
                frmAdd._KgPorCaja = 0;
        }
        private void ActualizarKilogramosPorCaja()
        {
            foreach (DataGridViewRow row in frmAdd.dgvRegistros.Rows)
            {
                decimal cajas;

                if (decimal.TryParse(row.Cells["Cajas"].Value.ToString(), out cajas))
                {
                    decimal kilogramos = Math.Round(cajas * frmAdd._KgPorCaja,2);

                    row.Cells["Kilogramos"].Value = kilogramos;
                }
            }
        }
        public DataTable CboTroqueGranelRegistro()
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT v_truck 'Nombre' FROM Pack_BulkReception GROUP BY v_truck ORDER BY v_truck", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
                return ds.Tables["Nombre"];

            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public DataTable CboChoferGranelRegistro()
        {
            DataSet ds = new DataSet();

            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT v_driver 'Nombre' FROM Pack_BulkReception GROUP BY v_driver ORDER BY v_driver", sql.cnn);
                da.Fill(ds, "Nombre");
                sql.CloseConectionWrite();
                return ds.Tables["Nombre"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
                return ds.Tables["Nombre"];
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void BtnAccept()
        {
            if (!controlList.ValidateControls())
                return;

            if (IsAddOrModify)
            {
                AddProcedure();
                if (IsAddUpdate)
                {
                    frmAdd.txbId.Text = idAddModify;
                    MessageBox.Show($"Se ha agregado la salida con código: {idAddModify}", "Añadir salida de material");

                    frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo agregar la salida.", "Añadir salida de material");
                }
            }
            else
            {
                ModifyProcedure();

                if (IsModifyUpdate)
                {
                    MessageBox.Show($"Se ha modificado la salida con el código: {idAddModify}", "Modificar salida de material");

                    frmAdd.txbCajasTotales.Enabled = false; //ASI ESTABA AQUI ANTES
                    frmAdd.txbTaraCaja.Enabled = false;
                    frmAdd.txbTaraTarima.Enabled = false;

                    frmAdd.Close();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se pudo modificar la salida.", "Modificar salida de material");
                }
            }
        }
        public void AddProcedure()
        {
            var result = AddProcedureWithLots();
            IsAddUpdate = result.Item1;
            idAddModify = result.Item2;
        }
        public (bool, string?) AddProcedureWithLots()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.BeginTransaction();

                var (success, idBulkReception) = AddProcedure(sql);
                if (!success || idBulkReception == null)
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                if (!AddLots(sql, idBulkReception))
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                sql.transaction.Commit();
                return (true, idBulkReception);
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Añadir registro de granel");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public (bool, string?) AddProcedure(SQLControl sql)
        {
            decimal lbsNetPallet = decimal.Parse(frmAdd.txbKgNetos.Text) * 2.20462M;
            decimal lbsNetBox = decimal.Parse(frmAdd.txbKgPorCaja.Text) * 2.20462M;
            
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionAdd", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@invoice", frmAdd.txbPapeleta.Text);
                cmd.Parameters.AddWithValue("@position", frmAdd.cboPosicion.Text);
                cmd.Parameters.AddWithValue("@boxes", frmAdd.txbCajasTotales.Text);
                cmd.Parameters.AddWithValue("@harvested", frmAdd.dtpFecha.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@kgNetPallet", frmAdd.txbKgNetos.Text);
                cmd.Parameters.AddWithValue("@lbsNetPallet", lbsNetPallet);
                cmd.Parameters.AddWithValue("@kgNetBox", frmAdd.txbKgPorCaja.Text);
                cmd.Parameters.AddWithValue("@lbsNetBox", lbsNetBox);
                cmd.Parameters.AddWithValue("@kgTot", frmAdd.txbKgTotales.Text);
                cmd.Parameters.AddWithValue("@kgTarePallet", frmAdd.txbTaraTarima.Text);
                cmd.Parameters.AddWithValue("@kgTareBox", frmAdd.txbTaraCaja.Text);
                cmd.Parameters.AddWithValue("@truck", ClsValues.IfEmptyToDBNull(frmAdd.cboTroque.Text));
                cmd.Parameters.AddWithValue("@driver", ClsValues.IfEmptyToDBNull(frmAdd.cboChofer.Text));
                cmd.Parameters.AddWithValue("@idWorkGroup", frmAdd.txbIdWorkGroup.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                string? idBulkReception = null;
                if (dr.Read())
                {
                    idBulkReception = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                }
                dr.Close();

                return idBulkReception != null ? (true, idBulkReception) : (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir registro de granel");
                return (false, null);
            }
        }

        private bool AddLots(SQLControl sql, string idBulkReception)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionAddLots", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                int item = 0;
                foreach (DataGridViewRow row in frmAdd.dgvRegistros.Rows)
                {
                    item++;

                    string idLot = row.Cells["Lote"].Value.ToString().Substring(0, 4);
                    string idVariety = row.Cells["Lote"].Value.ToString().Substring(5, 2);
                    decimal boxes = decimal.Parse(row.Cells["Cajas"].Value.ToString());
                    decimal kgBox = decimal.Parse(row.Cells["Kilogramos"].Value.ToString());

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idBulk", idBulkReception);
                    cmd.Parameters.AddWithValue("@idLot", idLot);
                    cmd.Parameters.AddWithValue("@idVariety", idVariety);
                    cmd.Parameters.AddWithValue("@boxes", boxes);
                    cmd.Parameters.AddWithValue("@kgBox", kgBox);
                    cmd.Parameters.AddWithValue("@item", item.ToString("00"));

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al añadir registro de granel (Lotes)");
                return false;
            }
        }
        public void ModifyProcedure()
        {
            var result = ModifyProcedureWithLots();
            IsModifyUpdate = result.Item1;
            idAddModify = result.Item2;
        }
        public (bool, string?) ModifyProcedureWithLots()
        {
            SQLControl sql = new SQLControl();
            try
            {
                sql.OpenConectionWrite();
                sql.BeginTransaction();

                var (success, idBulkReception) = ModifyProcedure(sql);
                if (!success || idBulkReception == null)
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                if (!AddLots(sql, idBulkReception))
                {
                    sql.transaction.Rollback();
                    return (false, null);
                }

                sql.transaction.Commit();
                return (true, idBulkReception);
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Modificar registro de granel");
                return (false, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void LlenarFormulario(string idModify)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_BulkReception WHERE id_bulk = '{idModify}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idAddModify = dr.GetValue(dr.GetOrdinal("id_bulk")).ToString();
                    frmAdd.txbId.Text = idAddModify;
                    frmAdd.txbPapeleta.Text = dr.GetValue(dr.GetOrdinal("v_invoice")).ToString();
                    frmAdd.cboPosicion.Text = dr.GetValue(dr.GetOrdinal("c_position")).ToString();
                    frmAdd.dtpFecha.Value = DateTime.Parse(dr.GetValue(dr.GetOrdinal("d_harvested")).ToString());
                    frmAdd.txbCajasTotales.Text = dr.GetValue(dr.GetOrdinal("i_boxes")).ToString();
                    frmAdd.txbKgNetos.Text = dr.GetValue(dr.GetOrdinal("n_kgNetPallet")).ToString();
                    frmAdd.txbKgPorCaja.Text = dr.GetValue(dr.GetOrdinal("n_kgNetBox")).ToString();
                    frmAdd.txbKgTotales.Text = dr.GetValue(dr.GetOrdinal("n_kgTot")).ToString();
                    frmAdd.txbTaraTarima.Text = dr.GetValue(dr.GetOrdinal("n_kgTarePallet")).ToString();
                    frmAdd.txbTaraCaja.Text = dr.GetValue(dr.GetOrdinal("n_kgTareBox")).ToString();
                    frmAdd.cboTroque.Text = dr.GetValue(dr.GetOrdinal("v_truck")).ToString();
                    frmAdd.cboChofer.Text = dr.GetValue(dr.GetOrdinal("v_driver")).ToString();
                    frmAdd.txbIdWorkGroup.Text = dr.GetValue(dr.GetOrdinal("id_workGroup")).ToString();
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

        public void LlenarDGVCajas(string idModify)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT id_bulk AS 'Código', CONCAT(lot.id_lot,'|',lot.id_variety) AS 'Lote', CONCAT(lot.v_nameLot,' (',lot.id_lot,'|',lot.id_variety,') ',[var].v_nameComercial,' ',  CASE WHEN [var].v_nameScientis IS NOT NULL AND [var].v_nameScientis != [var].v_nameComercial THEN CONCAT(' (', [var].v_nameScientis, ')') ELSE '' END) AS 'Nombre', i_boxes 'Cajas', n_kg 'Kilogramos' FROM Pack_BulkReceptionLots blkL JOIN Pack_Lot lot ON lot.id_lot = blkL.id_lot  and blkL.id_variety = lot.id_variety JOIN Pack_Variety [var] ON [var].id_variety = blkL.id_variety WHERE id_bulk = '{idModify}'", sql.cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                frmAdd.dgvRegistros.Rows.Clear();

                foreach (DataRow fila in dt.Rows)
                {
                    string lote = fila["Lote"].ToString();
                    string nombre = fila["Nombre"].ToString();
                    decimal cajas = Convert.ToDecimal(fila["Cajas"]);
                    decimal kilogramos = Convert.ToDecimal(fila["Kilogramos"]);

                    frmAdd.dgvRegistros.Rows.Add(cajas, kilogramos, lote, nombre);
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

        public void LlenarFormularioModificar(string idModify)
        {
            LlenarFormulario(idModify);

            LlenarDGVCajas(idModify);

            frmAdd._KgTotales = decimal.Parse(frmAdd.txbKgTotales.Text);
            frmAdd._TaraTarima = decimal.Parse(frmAdd.txbTaraTarima.Text);
            frmAdd._TaraCaja = decimal.Parse(frmAdd.txbTaraCaja.Text);

            frmAdd._CajasTotales = decimal.Parse(frmAdd.txbCajasTotales.Text);
            frmAdd._KgPorCaja = decimal.Parse(frmAdd.txbKgPorCaja.Text);
            frmAdd._KgTotalesNetos = frmAdd._KgTotales - frmAdd._TaraTarima - frmAdd._TaraCaja * frmAdd._CajasTotales;
        }

        public bool IsFormModificar(TextBox idRegistro)
        {
            if (!string.IsNullOrEmpty(idRegistro.Text))
            {
                return true;
            }
            return false;
        }

        private (bool, string?) ModifyProcedure(SQLControl sql)
        {
            decimal lbsNetPallet = decimal.Parse(frmAdd.txbKgNetos.Text) * 2.20462M;
            decimal lbsNetBox = decimal.Parse(frmAdd.txbKgPorCaja.Text) * 2.20462M;

            try
            {
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionModify", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBulk", frmAdd.txbId.Text);
                cmd.Parameters.AddWithValue("@invoice", frmAdd.txbPapeleta.Text);
                cmd.Parameters.AddWithValue("@position", frmAdd.cboPosicion.Text);
                cmd.Parameters.AddWithValue("@boxes", frmAdd.txbCajasTotales.Text);
                cmd.Parameters.AddWithValue("@harvested", frmAdd.dtpFecha.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@kgNetPallet", frmAdd.txbKgNetos.Text);
                cmd.Parameters.AddWithValue("@lbsNetPallet", lbsNetPallet);
                cmd.Parameters.AddWithValue("@kgNetBox", frmAdd.txbKgPorCaja.Text);
                cmd.Parameters.AddWithValue("@lbsNetBox", lbsNetBox);
                cmd.Parameters.AddWithValue("@kgTot", frmAdd.txbKgTotales.Text);
                cmd.Parameters.AddWithValue("@kgTarePallet", frmAdd.txbTaraTarima.Text);
                cmd.Parameters.AddWithValue("@kgTareBox", frmAdd.txbTaraCaja.Text);
                cmd.Parameters.AddWithValue("@truck", ValorNull(frmAdd.cboTroque.Text));
                cmd.Parameters.AddWithValue("@driver", ValorNull(frmAdd.cboChofer.Text));
                cmd.Parameters.AddWithValue("@idWorkGroup", frmAdd.txbIdWorkGroup.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                SqlDataReader dr = cmd.ExecuteReader();
                string? idBulkRegister = null;
                if (dr.Read())
                {
                    idBulkRegister = dr.GetValue(dr.GetOrdinal("Id")).ToString();
                }
                dr.Close();

                return idBulkRegister != null ? (true, idBulkRegister) : (false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar registro de granel");
                return (false, null);
            }
        }

        public bool DeleteProcedure(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                sql.BeginTransaction();
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionDelete", sql.cnn, sql.transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBulk", id);

                cmd.ExecuteNonQuery();
                sql.transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                sql.transaction?.Rollback();
                MessageBox.Show(ex.ToString(), "Eliminar registro de granel");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void BtnDeleteSelectedRowFromDGVCatalog(DataGridViewRow selectedRow)
        {
            string? idMatOutputExit = selectedRow.Cells[Column.id].Value?.ToString();

            if (!string.IsNullOrEmpty(idMatOutputExit))
            {
                DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar el registro de granel {idMatOutputExit}?", "Eliminar registro de granel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                bool isDeleted = DeleteProcedure(idMatOutputExit);

                if (isDeleted)
                {
                    for (int i = frmCat.dgvCatalogo.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = frmCat.dgvCatalogo.Rows[i];
                        if (row.Cells[Column.id].Value?.ToString() == idMatOutputExit)
                        {
                            frmCat.dgvCatalogo.Rows.Remove(row);
                        }
                    }
                    MessageBox.Show($"Se ha eliminado el registro de granel con el código: {idMatOutputExit}", "Eliminar registro de granel");
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("No se eliminó el registro de granel.", "Eliminar registro de granel");
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("El código del registro de granel no es válido.", "Eliminar registro de granel");
            }
        }
        public void SetDgvCatalog()
        {
            dtCatalog = GetDTCatalogQueryWithFilter();
            dgv = new ClsDGVCatalog(frmCat.dgvCatalogo, dtCatalog);
            DgvHideColumnsToExitCatalog();
        }
        private void DgvHideColumnsToExitCatalog()
        {
            if (dtCatalog.Columns.Contains("id_lot"))
                frmCat.dgvCatalogo.Columns["id_lot"].Visible = false;
            if (dtCatalog.Columns.Contains("id_variety"))
                frmCat.dgvCatalogo.Columns["id_variety"].Visible = false;
            if (dtCatalog.Columns.Contains("id_workGroup"))
                frmCat.dgvCatalogo.Columns["id_workGroup"].Visible = false;
        }

        private DataTable GetDTCatalogQueryWithFilter()
        {
            Dictionary<string, object> parameters = new();
            
            string qry = queryCatalogo + $" WHERE vw.Fecha BETWEEN @date1 AND @date2 ";

            parameters.Add("@date1", frmCat.dtpFecha1.Value.ToString("yyyy-MM-dd"));
            parameters.Add("@date2", frmCat.dtpFecha2.Value.ToString("yyyy-MM-dd"));


            //[CAMBIOS PROXIMOS PARA AÑADIR CUADRILLA, LOTE, ETC]
            if (frmCat.cboLot.SelectedIndex > 0) //SACAR IDLOT Y VARIEDAD DEL cboLot
            {
                qry += " AND vw.id_lot = @idLot ";
                parameters.Add("@idLot", frmCat.cboLot.GetColumnValue(Lot.ColumnId));

                qry += " AND vw.id_variety = @idVariety ";
                parameters.Add("@idVariety", frmCat.cboLot.GetColumnValue(Variety.ColumnId));
            }
            else if (frmCat.cboVariety.SelectedIndex > 0) //SACAR idVariety solo si el cboLot no tiene nada seleccionado y esté si, para no intercalar
            {
                qry += " AND vw.id_variety = @idVariety ";
                parameters.Add("@idVariety", frmCat.cboVariety.SelectedValue.ToString());
            }

            if (frmCat.cboWorkGroup.SelectedIndex > 0) //SACAR idVariety solo si el cboLot no tiene nada seleccionado y esté si, para no intercalar
            {
                qry += " AND vw.id_workGroup = @idWorkGroup ";
                parameters.Add("@idWorkGroup", frmCat.cboWorkGroup.SelectedValue);
            }

            return ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
        }

        private void LoadControlsCat()
        {
            ClsComboBoxes.CboLoadActives(frmCat.cboLot, Lot.Cbo);
            ClsComboBoxes.CboLoadActives(frmCat.cboVariety, Variety.Cbo);
            ClsComboBoxes.CboLoadActives(frmCat.cboWorkGroup, WorkGroup.Cbo);

            ClsComboBoxes.CboApplyClickEvent(frmCat.cboLot, frmCat.chbLotRemoved);
            ClsComboBoxes.CboApplyClickEvent(frmCat.cboVariety, frmCat.chbVarietyRemoved);
            ClsComboBoxes.CboApplyClickEvent(frmCat.cboWorkGroup, frmCat.chbWorkGroupRemoved);
        }

        public void FrmCatLoad()
        {
            LoadControlsCat();

            SetDgvCatalog();
        }
        public void AddNewRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE vw.[{ClsObject.Column.id}] = '{idAddModify}'");

            dgv.AddNewRowToDGV(newIdRow);
        }

        public void ModifyRowByIdInDGVCatalog()
        {
            DataTable newIdRow = ClsQuerysDB.GetDataTable(queryCatalogo + $" WHERE vw.[{ClsObject.Column.id}] = '{idAddModify}'");

            dgv.ModifyIdRowInDGV(newIdRow);
        }

        public void BtnSearchInvoice(string invoice)
        {
            if (string.IsNullOrEmpty(invoice))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            string qry = queryCatalogo + " WHERE RIGHT(REPLICATE('0', 15) + CAST(vw.Papeleta AS VARCHAR), 15) = RIGHT(REPLICATE('0', 15) + CAST(@invoice AS VARCHAR), 15) ";
            Dictionary<string, object> parameters = new();
            parameters.Add("@invoice", invoice);
            dtCatalog = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
            dgv = new ClsDGVCatalog(frmCat.dgvCatalogo, dtCatalog);
            DgvHideColumnsToExitCatalog();
        }
    }
}
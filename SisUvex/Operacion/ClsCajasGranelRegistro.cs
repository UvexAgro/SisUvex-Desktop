using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos;
using DocumentFormat.OpenXml.Presentation;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq.Expressions;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.TextBoxes;

namespace SisUvex.Operacion
{
    internal class ClsCajasGranelRegistro : ClsCatalogos
    {
        private SQLControl sql = new SQLControl();
        public FrmCajasGranelRegistroCat frmCat;
        public FrmCajasGranelRegistro frmAdd;
        ClsControls controlList;
        public string titulo = "Registro de cajas a granel";

        public ClsCajasGranelRegistro()
        {
            frmCat = new FrmCajasGranelRegistroCat();
            frmCat.cls = this;
        }
        
        public void OpenAddForm()
        {
            frmAdd = new FrmCajasGranelRegistro();
            frmAdd.cls = this;
            frmAdd.Show();
        }

        public void OpenModifyForm()
        {
            if (frmCat.dgvCatalogo.SelectedRows.Count > 0)
            {
                string idRegistro = frmCat.dgvCatalogo.SelectedRows[0].Cells["Código"].Value.ToString();
                frmAdd = new FrmCajasGranelRegistro();
                frmAdd.cls = this;
                frmAdd.txbId.Text = idRegistro;
                frmAdd.Show();
            }
        }

        public void SetControls()
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
        public void AñadirRegistros()
        {
            if (frmAdd.dgvRegistros.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para guardar", titulo);
                return;
            }

            if (!controlList.ValidateControls())
                return;

            ProcRegistrosGeneral();
            foreach (DataGridViewRow row in frmAdd.dgvRegistros.Rows)
            {
                string idLot = row.Cells["Lote"].Value.ToString().Substring(0, 4);
                string idVariety = row.Cells["Lote"].Value.ToString().Substring(5, 2);
                decimal boxes = decimal.Parse(row.Cells["Cajas"].Value.ToString());
                decimal kgBox = decimal.Parse(row.Cells["Kilogramos"].Value.ToString());

                ProcAñadirRegistrosMenor(idLot, idVariety, boxes, kgBox);
            }

            frmCat.dgvCatalogo.DataSource = CatalogoActivos();

            frmAdd.Close();
        }

        public void ProcRegistrosGeneral()
        {
            decimal lbsNetPallet = decimal.Parse(frmAdd.txbKgNetos.Text) * 2.20462M;
            decimal lbsNetBox = decimal.Parse(frmAdd.txbKgPorCaja.Text) * 2.20462M;
            
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionAdd", sql.cnn);
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
                cmd.Parameters.AddWithValue("@truck", ValorNull(frmAdd.cboTroque.Text));
                cmd.Parameters.AddWithValue("@driver", ValorNull(frmAdd.cboChofer.Text));
                cmd.Parameters.AddWithValue("@idWorkGroup", frmAdd.txbIdWorkGroup.Text);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void ProcAñadirRegistrosMenor(string idLot, string idVariety, decimal boxes, decimal kgBox)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionLotAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.Parameters.AddWithValue("@idVariety", idVariety);
                cmd.Parameters.AddWithValue("@boxes", boxes);
                cmd.Parameters.AddWithValue("@kgBox", kgBox);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public DataTable CatalogoActivos()
        {
            string fecha = frmCat.dtpFecha.Value.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_Pack_BulkReception WHERE Fecha = '{fecha}'", sql.cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
                return dt;
            }

            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void LlenarFormulario()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_BulkReception WHERE id_bulk = '{frmAdd.txbId.Text}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    frmAdd.txbId.Text = dr.GetValue(dr.GetOrdinal("id_bulk")).ToString();
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

        public void LlenarDGVCajas()
        {
            try
            {
                string id = frmAdd.txbId.Text;
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT id_bulk AS 'Código', CONCAT(lot.id_lot,'|',lot.id_variety) AS 'Lote', CONCAT(lot.v_nameLot,' (',lot.id_lot,'|',lot.id_variety,') ',[var].v_nameComercial,' ',  CASE WHEN [var].v_nameScientis IS NOT NULL AND [var].v_nameScientis != [var].v_nameComercial THEN CONCAT(' (', [var].v_nameScientis, ')') ELSE '' END) AS 'Nombre', i_boxes 'Cajas', n_kg 'Kilogramos' FROM Pack_BulkReceptionLots blkL JOIN Pack_Lot lot ON lot.id_lot = blkL.id_lot  and blkL.id_variety = lot.id_variety JOIN Pack_Variety [var] ON [var].id_variety = blkL.id_variety WHERE id_bulk = '{id}'", sql.cnn);
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

        public void LlenarFormularioModificar()
        {
            LlenarFormulario();

            LlenarDGVCajas();

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

        public void ModificarRegistros()
        {
            if (frmAdd.dgvRegistros.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para modificar", titulo);
                return;
            }

            if (!controlList.ValidateControls())
                return;

            ProcRegistrosGeneralModificar();

            ProcEliminarRegistrosMenor();

            string id = frmAdd.txbId.Text;

            foreach (DataGridViewRow row in frmAdd.dgvRegistros.Rows)
            {
                string idLot = row.Cells["Lote"].Value.ToString().Substring(0, 4);
                string idVariety = row.Cells["Lote"].Value.ToString().Substring(5, 2);
                decimal boxes = decimal.Parse(row.Cells["Cajas"].Value.ToString());
                decimal kgBox = decimal.Parse(row.Cells["Kilogramos"].Value.ToString());

                ProcModificarRegistrosMenor(id, idLot, idVariety, boxes, kgBox);
            }

            frmAdd.txbCajasTotales.Enabled = false;
            frmAdd.txbTaraCaja.Enabled = false;
            frmAdd.txbTaraTarima.Enabled = false;

            frmCat.dgvCatalogo.DataSource = CatalogoActivos();

            frmAdd.Close();
        }

        private void ProcRegistrosGeneralModificar()
        {
            decimal lbsNetPallet = decimal.Parse(frmAdd.txbKgNetos.Text) * 2.20462M;
            decimal lbsNetBox = decimal.Parse(frmAdd.txbKgPorCaja.Text) * 2.20462M;

            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionModify", sql.cnn);
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

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void ProcModificarRegistrosMenor(string id, string idLot, string idVariety, decimal boxes, decimal kgBox)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionLotModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idBulk", id);
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.Parameters.AddWithValue("@idVariety", idVariety);
                cmd.Parameters.AddWithValue("@boxes", boxes);
                cmd.Parameters.AddWithValue("@kgBox", kgBox);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void ProcEliminarRegistrosMenor()
        {
            try
            {
                string id = frmAdd.txbId.Text;
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("DELETE FROM Pack_BulkReceptionLots WHERE id_bulk = @idBulk", sql.cnn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@idBulk", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void EliminarRegistroSeleccionado(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackBulkReceptionDelete", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBulk", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Registro eliminado.", "Eliminar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), titulo);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}
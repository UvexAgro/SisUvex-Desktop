using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Archivo.Etiquetas.LabelInterface;
using SisUvex.Catalogos;

namespace SisUvex.Archivo.Reestibado
{
    public partial class FrmReestibado : Form
    {
        SQLControl sql = new SQLControl();
        ClsReestibado cls = new ClsReestibado();
        string _Pallet = "Pallet: ", _Cajas = "Cajas: ", _Libras = "Libras: ", _Variedad = "Variedad: ", _Presentacion = "Presentación: ", _Contenedor = "Contenedor: ", _Distribuidor = "Distribuidor: ", _Lote = "Lote: ", _Tamaño = "Tamaño: ", _Fecha = "Fecha: ", _Plan = "Plan: ", _Cuadrilla = "Cuadrilla: ", _Programa = "Programa: ", _Papeleta = "Papeleta: ", _idPallet, _Manifiesto = "Manifiesto: ", idManifiesto;
        public FrmReestibado()
        {
            InitializeComponent();
        }
        private void txbIdPallet_TextChanged(object sender, EventArgs e)
        {
            nudCajasFinal.Value = 0;
        }
        private void btnPallet_Click(object sender, EventArgs e)
        {
            nudCajasFinal.Value = 0;
            cboMotivo.SelectedIndex = -1;
            txbIdPallet.Text = cls.FormatoCeros(txbIdPallet.Text, "00000");
            if (txbIdPallet.TextLength > 0)
            {
                _idPallet = txbIdPallet.Text;
                try
                {
                    sql.OpenConectionWrite();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("select * from vw_PackPalletCon WHERE Pallet = @idPallet", sql.cnn);
                    cmd.Parameters.AddWithValue("@idPallet", _idPallet);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    da.Fill(dt);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        idManifiesto = reader["Manifiesto"].ToString();
                        _idPallet = reader["Pallet"].ToString();
                        if (!cls.EnManifiesto(idManifiesto, _idPallet))
                        {
                            lblIdPallet.Text = _Pallet + _idPallet;
                            lblCajasIniciales.Text = _Cajas + reader["Cajas"].ToString();
                            lblLibras.Text = _Libras + reader["Libras"].ToString();
                            lblVariedad.Text = _Variedad + reader["Variedad"].ToString();
                            lblPresentacion.Text = _Presentacion + reader["Presentación"].ToString();
                            lblContenedor.Text = _Contenedor + reader["Contenedor"].ToString();
                            lblDistribuidor.Text = _Distribuidor + reader["Distribuidor"].ToString();
                            lblLote.Text = _Lote + reader["Lote"].ToString();
                            lblTamaño.Text = _Tamaño + reader["Tamaño"].ToString();
                            lblFecha.Text = _Fecha + reader["Fecha"].ToString().Substring(0, 10);
                            lblPlanDeTrabajo.Text = _Plan + reader["Plan de trabajo"].ToString();
                            lblCuadrilla.Text = _Cuadrilla + reader["Cuadrilla"].ToString();
                            lblPrograma.Text = _Programa + reader["Programa"].ToString();
                            lblPapeleta.Text = _Papeleta + reader["Papeleta"].ToString();
                            lblManifiesto.Text = _Manifiesto + idManifiesto;
                            nudCajasFinal.Maximum = int.Parse(reader["Cajas"].ToString()) - 1;
                        }
                        else
                        {
                            txbIdPallet.Text = string.Empty;
                            _idPallet = string.Empty;
                            idManifiesto = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Reestibado pallet");
                }
                finally
                {
                    sql.CloseConectionWrite();
                }
            }
        }
        private void btnReestibar_Click(object sender, EventArgs e)
        {
            //if (txbIdPallet.Text.Length == 5 && nudCajasFinal.Value > 0 && cboMotivo.SelectedIndex != -1)
            if (cboMotivo.SelectedIndex != -1 && txbIdPallet.Text.Length > 0)
            {

                if (nudCajasFinal.Value > 0)
                {
                    DialogResult result = MessageBox.Show($"¿Desea reestibar el pallet con {txbIdPallet.Text} con {nudCajasFinal.Value.ToString()} cajas finales y dejar el resto para {cboMotivo.Text}?", "Reestibar pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            sql.OpenConectionWrite();
                            SqlCommand cmd = new SqlCommand("sp_PackPalletReestiba", sql.cnn);
                            cmd.Parameters.AddWithValue("@idPallet", txbIdPallet.Text.PadLeft(5, '0'));
                            cmd.Parameters.AddWithValue("@boxes", Convert.ToInt32(nudCajasFinal.Value));
                            cmd.Parameters.AddWithValue("@user", User.GetUserName().ToString());
                            cmd.Parameters.AddWithValue("@restowing", cboMotivo.Text.ToString());

                            cmd.CommandType = CommandType.StoredProcedure;

                            DataTable dt = new DataTable();
                            //DataTable dt2 = new DataTable();

                            SqlDataAdapter da = new SqlDataAdapter(cmd);

                            da.Fill(dt);


                            string idPallet1 = "", Cajas1 = "", idPallet2 = "", Cajas2 = "";

                            if (dt.Rows.Count > 0)
                            {
                                idPallet1 = dt.Rows[0]["idPallet"].ToString();
                                Cajas1 = dt.Rows[0]["Cajas"].ToString();
                            }

                            if (dt.Rows.Count > 1)
                            {
                                idPallet2 = dt.Rows[1]["idPallet"].ToString();
                                Cajas2 = dt.Rows[1]["Cajas"].ToString();
                            }

                            MessageBox.Show($"Se ha reestibado el pallet: {idPallet1} con {Cajas1} cajas.\n y el pallet {idPallet2} con {Cajas2} para {cboMotivo.Text}", "Reestibado pallet");

                            txbIdPallet.Text = string.Empty;
                            lblIdPallet.Text = _Pallet;
                            lblCajasIniciales.Text = _Cajas;
                            lblLibras.Text = _Libras;
                            lblVariedad.Text = _Variedad;
                            lblPresentacion.Text = _Presentacion;
                            lblContenedor.Text = _Contenedor;
                            lblDistribuidor.Text = _Distribuidor;
                            lblLote.Text = _Lote;
                            lblTamaño.Text = _Tamaño;
                            lblFecha.Text = _Fecha;
                            lblPlanDeTrabajo.Text = _Plan;
                            lblCuadrilla.Text = _Cuadrilla;
                            lblPrograma.Text = _Programa;
                            lblPapeleta.Text = _Papeleta;
                            lblManifiesto.Text = _Manifiesto;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Reestibado pallet");
                        }
                        finally
                        {
                            sql.CloseConectionWrite();
                        }
                    }
                }
                else if (nudCajasFinal.Value == 0)
                {
                    DialogResult result = MessageBox.Show($"¿El pallet {txbIdPallet.Text} completo de {nudCajasFinal.Value.ToString()} cajas para {cboMotivo.Text}?", "Reestibar pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            sql.OpenConectionWrite();
                            SqlCommand cmd = new SqlCommand("UPDATE Pack_Pallet " +
                                "SET c_active = '0', id_rack = null, id_manifest = null, c_position = null, c_restowing = @restowing, userUpdate = @user, d_Update = GETDATE()" +
                                "WHERE id_Pallet = @idPallet ", sql.cnn);
                            cmd.Parameters.AddWithValue("@idPallet", txbIdPallet.Text.PadLeft(5, '0'));
                            cmd.Parameters.AddWithValue("@user", User.GetUserName().ToString());
                            cmd.Parameters.AddWithValue("@restowing", cboMotivo.Text.ToString().Substring(0, 2));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show($"El pallet: {txbIdPallet.Text.PadLeft(5, '0')} se ha cambiado completamente ha {cboMotivo.Text}", "Reestibado pallet");

                        }
                        catch
                        (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Reestibado pallet");
                        }
                        finally
                        {
                            sql.CloseConectionWrite();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Se debe:\n1.- Cargar los datos del pallet.\n2.- Seleccionar las cajas finales del pallet.\n");
                }
            }
            else
            {
                MessageBox.Show("¡Falta pallet o motivo!", "Reestibado pallet");
            }
        }
        private void FrmReestibado_Load(object sender, EventArgs e)
        {
            cboMotivo.SelectedIndex = -1;
        }

        private void cboMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

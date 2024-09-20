using System.Data;
using System.Data.SqlClient;
using SisUvex.Archivo.PlanTrabajo;

namespace SisUvex.Catalogos.PlanTrabajo
{
    internal class ClsPlanTrabajo : ClsCatalogos
    {
        SQLControl sql = new SQLControl();
        public DataTable CatalogoActualizar(string fecha1, string fecha2, bool Status)
        {
            DataTable dt = new DataTable();

            if (Status)
                dt = CatalogoDetallado(fecha1,fecha2, "0");
            else
                dt = CatalogoDetallado(fecha1, fecha2, "*");

            return dt;
        }
        public DataTable CatalogoDetallado(string fecha1, string fecha2, string activo)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM vw_PackWorkPlanCat where [Día de trabajo] BETWEEN '{fecha1}' AND '{fecha2}' AND Activo != '{activo}'", sql.cnn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo listado");
                return dt;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void AñadirPlanTrabajo(string idLot, string idCuadrilla, string idPrograma, string vpc, string fechaPlan, string tamaño, string idTarima, string idContenedor)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkPlanAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.Parameters.AddWithValue("@idWorkGroup", idCuadrilla);
                cmd.Parameters.AddWithValue("@idProgram", idPrograma);
                cmd.Parameters.AddWithValue("@voicePickCode", vpc);
                cmd.Parameters.AddWithValue("@workDay", fechaPlan);
                cmd.Parameters.AddWithValue("@idSize", tamaño);
                cmd.Parameters.AddWithValue("@idMatPallet", idTarima);
                cmd.Parameters.AddWithValue("@idMatContainer", idContenedor);
                cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public void ModificarPlanTrabajo(string id, string idLot, string idCuadrilla, string idPrograma, string vpc, string fechaPlan, string tamaño, string idPallet, string idContenedor)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkPlanModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.Parameters.AddWithValue("@idWorkGroup", idCuadrilla);
                cmd.Parameters.AddWithValue("@idProgram", idPrograma);
                cmd.Parameters.AddWithValue("@voicePickCode", vpc);
                cmd.Parameters.AddWithValue("@workDay", fechaPlan);
                cmd.Parameters.AddWithValue("@idSize", tamaño);
                cmd.Parameters.AddWithValue("@idMatPallet", idPallet);
                cmd.Parameters.AddWithValue("@idMatContainer", idContenedor);
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
        public string SiguientePlanTrabajo()
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(FORMAT(MAX(id_workPlan) + 1, '0000'), '0001') as 'Id' FROM Pack_WorkPlan", sql.cnn);
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

        public void LlenarFormulario(string dgvId, ref TextBox id, ref TextBox idLot, ref TextBox idCuadrilla, ref TextBox idPrograma, ref TextBox vpc, ref DateTimePicker fechaPlan, ref TextBox tamaño, ref TextBox idTarima, ref TextBox idContenedor)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Pack_WorkPlan WHERE id_workPlan = '{dgvId}'", sql.cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id.Text = dr.GetValue(dr.GetOrdinal("id_workPlan")).ToString(); 
                    idLot.Text = dr.GetValue(dr.GetOrdinal("id_lot")).ToString();
                    idCuadrilla.Text = dr.GetValue(dr.GetOrdinal("id_workGroup")).ToString();
                    idPrograma.Text = dr.GetValue(dr.GetOrdinal("id_program")).ToString();
                    vpc.Text = dr.GetValue(dr.GetOrdinal("c_voicePickCode")).ToString();
                    fechaPlan.Value = dr.GetDateTime(dr.GetOrdinal("d_workDay"));
                    tamaño.Text = dr.GetValue(dr.GetOrdinal("id_size")).ToString();
                    idTarima.Text = dr.GetValue(dr.GetOrdinal("id_material_pallet")).ToString();
                    idContenedor.Text = dr.GetValue(dr.GetOrdinal("id_material_container")).ToString();
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
            //LOTE
            CboCargarInicio(c[0], CboLote("", "*"));
            //CUADRILLA
            CboCargarInicio(c[1], CboCuadrilla(""));
            //TAMAÑO
            CboCargarEnBlanco(c[2], CboTamaño());
            //TARIMA
            CboCargarInicio(c[3], CboMaterialTarima(""));
            //CONTENEDOR
            CboCargarInicio(c[4], CboMaterialContenedor(""));

            CboCargarEnBlanco(c[5], CboTipoMaterialContenedores(""));
        }
        public DataTable CatalogoPrograma()
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT Programa, GTIN, Distribuidor, Variedad, Envase, Presentación, Libras, [Cajas pallet] FROM vw_PackProgramCat WHERE Activo = '1'", sql.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo programa en plan de trabajo");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return dt;
        }

        public DataTable CatalogoPrograma(string idLote)
        {
            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT vprg.Programa, vprg.GTIN, vprg.Distribuidor, vprg.Variedad, vprg.Envase, vprg.Presentación, vprg.Libras, vprg.[Cajas pallet] FROM vw_PackProgramCat vprg JOIN Pack_Program prg ON prg.id_program = vprg.Programa JOIN Pack_GTIN gtn ON gtn.id_GTIN = prg.id_GTIN WHERE Activo = '1' and gtn.id_variety = (SELECT id_variety FROM Pack_Lot WHERE id_lot = '{idLote}')", sql.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo programa en plan de trabajo");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return dt;
        }

        public DataTable CatalogoPrograma(string idLote, string idTipoContenedor)
        {
            string query = $"SELECT vprg.Programa, vprg.GTIN, vprg.Distribuidor, vprg.Variedad, vprg.Envase, vprg.Presentación, vprg.Libras, vprg.[Cajas pallet] FROM vw_PackProgramCat vprg JOIN Pack_Program prg ON prg.id_program = vprg.Programa JOIN Pack_GTIN gtn ON gtn.id_GTIN = prg.id_GTIN WHERE Activo = '1'";
            if (idLote.Length != 0)
            {
                query += $" and gtn.id_variety = (SELECT id_variety FROM Pack_Lot WHERE id_lot = '{idLote}')";
            }
            if (idTipoContenedor.Length != 0)
            {
                query += $" and gtn.id_matType_container = '{idTipoContenedor}'";
            }

            DataTable dt = new DataTable();
            try
            {
                sql.OpenConectionWrite();
                SqlDataAdapter da = new SqlDataAdapter(query, sql.cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo programa en plan de trabajo");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return dt;
        }

        public string GenerarVoicePickCode(string idProgram, string idLote, DateTime fecha)
        {
            string VPC = string.Empty, GTIN;
            if (idProgram.Length == 4 && idLote.Length == 4 && fecha > new DateTime(2000, 1, 1))
            {
                try
                {
                    sql.OpenConectionWrite();
                    SqlCommand cmd = new SqlCommand($"SELECT gtn.v_GTIN AS GTIN FROM Pack_Program prg JOIN Pack_GTIN gtn ON gtn.id_GTIN = prg.id_GTIN WHERE prg.id_program = '{idProgram}'", sql.cnn);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        GTIN = dr["GTIN"].ToString();

                        VPC = ClsVoicePickCode.Calculator(GTIN, idLote, fecha);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Generar Voice Pick Code");
                }
                finally
                {
                    sql.CloseConectionRead();
                }
            }
            return VPC;
        }

        public bool PlanDisponible(string idLote, string idPrograma, string idCuadrilla, string idTamaño, DateTime fecha)
        {
            bool disponible = false;
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 id_workPlan 'Plan' FROM Pack_WorkPlan WHERE d_workDay = @fecha AND id_program = @idPrograma AND id_workGroup = @idCuadrilla AND id_lot = @idLote AND id_size = @idTamaño", sql.cnn);
                cmd.Parameters.AddWithValue("@idLote", idLote);
                cmd.Parameters.AddWithValue("@idPrograma", idPrograma);
                cmd.Parameters.AddWithValue("@idCuadrilla", idCuadrilla);
                cmd.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idTamaño", idTamaño);
                string id = cmd.ExecuteScalar()?.ToString();
                if (id == null)
                {
                    disponible = true;
                }
                else
                {
                    MessageBox.Show("El plan de trabajo ya está asignado.\n                          Es: " + id);
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Verificar plan te trabajo existente");
            }
            finally
            {
                sql.CloseConectionRead();
            }
            return disponible;
        }

        public bool ProgramaEnListado(string idPrograma, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string valorCelda = row.Cells["Programa"].Value.ToString();
                if (valorCelda == idPrograma)
                {
                    return true;
                }
            }
            return false;
        }
        public void EliminarPlan(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkPlanDelete", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo eliminar");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
        public void RecuperarPlan(string id)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand("sp_PackWorkPlanRecover", sql.cnn);
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

        public string GetTipoContenedorConPrograma(string idPrograma)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new SqlCommand($"select gtn.id_matType_container as contenedor from Pack_Program prg join Pack_GTIN gtn on gtn.id_GTIN = prg.id_GTIN where prg.id_program = '{idPrograma}'", sql.cnn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["contenedor"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Obtener tipo de contenedor");
                return "";
            }
            finally
            {
                sql.CloseConectionRead();
            }
        }

        public void contenedorSeleccionado(string idPrograma, ref ComboBox cboContenedor)
        {
            DataTable tabla = new DataTable();
            string idTipoContenedor = GetTipoContenedorConPrograma(idPrograma);

            tabla = CboMaterialContenedor(idTipoContenedor);
            bool encontrado = false;
            if (cboContenedor.SelectedValue != null)
            {
                string idContenedor = cboContenedor.SelectedValue.ToString();

                encontrado = tabla.AsEnumerable().Any(row => row.Field<string>("Código") == idContenedor);   
            }

            if (!encontrado)
                CboCargarInicio(cboContenedor, tabla);
        }


    }
}
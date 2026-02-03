using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.Values;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SisUvex.Configuracion.Parameters
{
    internal class EParameters
    {        //ESTE ES DIFERENTE A COMO SE MANEJAN POR:
        // 1.- NO SE TIENE SU OBJETO EN ClsObject PARA PARAMETROS
        // 2.- LOS DATOS NO SE ALMACENAN EN EL XML COMO LOS DEMÁS CATÁLOGOS
        // 2.1.- LA CONSULTA/QUERY SE OBTIENE DE ESTOS STRINGS DIRECTAMENTE
        // 3.- NOMBRE DE COLUMNAS DEBEN SER LOS QUE ESTÉN AQUÍ

        // Tipos de parámetro (para combos / catálogos)
        public static string queryTypeParameters =
            $"SELECT id_typeParameter AS [{ClsObject.Column.id}], " +
            $"v_nameTypePara AS [{ClsObject.Column.name}] " +
            $"FROM Conf_TypeParameter " +
            $"ORDER BY v_nameTypePara";

        // Vista catálogo (recomendada para grid)
        public string queryParameters =
            "SELECT [Activo],[Tipo],[Código],[Nombre],[Detalle],[Valor] " +
            "FROM vw_ConfParameters";
        public string? idParameter { get; set; }        // CHAR(3)
        public string? idTypeParameter { get; set; }    // CHAR(2)
        public string? typeParameter { get; set; }      // (solo lectura/mostrar)
        public string? nameParameters { get; set; }     // VARCHAR(30)
        public string? detailParameter { get; set; }    // VARCHAR(50)
        public string? valueParameters { get; set; }    // VARCHAR(70)
        public int? active { get; set; }             // CHAR(1) -> '1'/'0'
        public string? dataTypeParameters { get; set; } // TIPO DE DATO DEL PARAMETRO (Text, Int, Decimal, Date, Time, DateTime, Bool)

        // PARA MODIFICAR: GUARDAR EL ID ORIGINAL (EN CASO DE QUE SE QUIERA CAMBIAR LOS IDS DEL PARAMETRO)
        public string? idOriginalParameter { get; set; }        // CHAR(3)
        public string? idOriginalTypeParameter { get; set; }    // CHAR(2)

        // =========================
        // SIGUIENTE ID (POR TIPO)
        // =========================
        public static string GetNextId(string? idTypeParameter)
        {
            string idType = string.IsNullOrWhiteSpace(idTypeParameter) ? "00" : idTypeParameter;

            // OJO: aquí el parámetro debe llamarse igual que en el query
            var parameters = new Dictionary<string, object>
            {
                { "@idTypeParameter", idType }
            };

            return ClsQuerysDB.GetStringExecuteParameterizedQuery(
                "SELECT FORMAT(COALESCE(MAX(id_parameter), 0) + 1, '000') " +
                "FROM Conf_Parameters WHERE id_typeParameter = @idTypeParameter",
                parameters
            );
        }

        //== VERIFICAR ID EXISTENTE
        public static bool ExistsId(string idParameter, string idTypeParameter)
        {
            // OJO: aquí los parámetros deben llamarse igual que en el query
            var parameters = new Dictionary<string, object>
            {
                { "@idParameter", idParameter },
                { "@idTypeParameter", idTypeParameter }
            };
            int count = int.Parse(ClsQuerysDB.GetStringExecuteParameterizedQuery("SELECT COUNT(*) FROM Conf_Parameters WHERE id_parameter = @idParameter AND id_typeParameter = @idTypeParameter", parameters));

            return count > 0;
        }
        //== VERIFICAR ID EXISTENTE PARA EL MODIFICAR (Y NO SEA IGUAL QUE AL ORIGINAL)
        public static bool ExistsIdForModify(string idParameter, string idTypeParameter, string idOriginalParameter, string idOriginalTypeParameter)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@idParameter", idParameter },
                { "@idTypeParameter", idTypeParameter },
                { "@idOriginalParameter", idOriginalParameter },
                { "@idOriginalTypeParameter", idOriginalTypeParameter }
            };
            int count = int.Parse(ClsQuerysDB.GetStringExecuteParameterizedQuery("SELECT COUNT(*) FROM Conf_Parameters WHERE id_parameter = @idParameter AND id_typeParameter = @idTypeParameter OR id_parameter = @idOriginalParameter AND id_typeParameter = @idOriginalTypeParameter", parameters));

            MessageBox.Show($"IDpar: {idParameter}\n" +
                            $"IdTyp: {idTypeParameter}\n" +
                            $"IdOriPar: {idOriginalParameter}\n" +
                            $"IdOriTyp: {idOriginalTypeParameter}\n" +
                            $"Count:" + count.ToString());
            return count > 1;
        }

        // =========================
        // OBTENER 1 REGISTRO
        // =========================
        public void GetParameter(string? idParameter, string? idTypeParameter)
        {
            if (string.IsNullOrWhiteSpace(idParameter))
                idParameter = "000";
            if (string.IsNullOrWhiteSpace(idTypeParameter))
                idTypeParameter = "00";

            SQLControl sql = new SQLControl();

            try
            {
                sql.OpenConectionWrite();

                // Traemos el registro desde la tabla + join para obtener el nombre del tipo
                string query =
                    "SELECT " +
                    "   par.id_parameter, " +
                    "   par.id_typeParameter, " +
                    "   typ.v_nameTypePara AS Tipo, " +
                    "   par.v_nameParameters, " +
                    "   par.v_DetailParameter, " +
                    "   par.v_valueParameters, " +
                    "   par.c_active, " +
                    "   par.v_dataType " +
                    "FROM Conf_Parameters par " +
                    "JOIN Conf_TypeParameter typ ON typ.id_typeParameter = par.id_typeParameter " +
                    "WHERE par.id_parameter = @idParameter AND par.id_typeParameter = @idTypeParameter";

                SqlCommand cmd = new SqlCommand(query, sql.cnn);
                cmd.Parameters.AddWithValue("@idParameter", idParameter);
                cmd.Parameters.AddWithValue("@idTypeParameter", idTypeParameter);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.idParameter = dr["id_parameter"]?.ToString();
                    this.idTypeParameter = dr["id_typeParameter"]?.ToString();
                    typeParameter = dr["Tipo"]?.ToString();

                    nameParameters = dr["v_nameParameters"]?.ToString();
                    detailParameter = dr["v_DetailParameter"]?.ToString();
                    valueParameters = dr["v_valueParameters"]?.ToString();
                    active = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("c_active")));
                    dataTypeParameters = dr.IsDBNull(dr.GetOrdinal("v_dataType")) ? "Text" : dr["v_dataType"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Parámetros");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        // =========================
        // AÑADIR (SP)
        // =========================
        public (bool, string?, string?, string?) AddProcedure()
        {
            SQLControl sql = new SQLControl();

            try
            {
                //SI NO SE ESPECIFICAN ID, NO SE PUEDE AÑADIR (NO SE AUTOGENERA YA QUE SE PUEDE METER MANUALMENTE)
                if (string.IsNullOrWhiteSpace(idTypeParameter) || string.IsNullOrWhiteSpace(idParameter)) 
                    return (false, null, null, null);

                if (active == null)
                    active = 1;

                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand("sp_ConfParametersAdd", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTypeParameter", idTypeParameter);
                cmd.Parameters.AddWithValue("@idParameter", idParameter);
                cmd.Parameters.AddWithValue("@nameParameter", nameParameters);
                cmd.Parameters.AddWithValue("@detailParameter", ClsValues.IfEmptyToDBNull(detailParameter));
                cmd.Parameters.AddWithValue("@valueParameter", ClsValues.IfEmptyToDBNull(valueParameters));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@dataType", dataTypeParameters);

                // Ahora tu SP devuelve: SELECT v_nameParameters ...
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string v_nameParameters = dr.GetValue(dr.GetOrdinal("v_nameParameters")).ToString();
                    string v_idParameter = dr.GetValue(dr.GetOrdinal("id_parameter")).ToString();
                    string v_idTypeParameter = dr.GetValue(dr.GetOrdinal("id_typeParameter")).ToString();
                    return (true, v_idParameter, v_idTypeParameter, v_nameParameters);
                }

                return (false, null, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Añadir parámetro");
                return (false, null, null, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        // =========================
        // MODIFICAR (SP)
        // =========================
        public (bool, string?, string?, string?) ModifyProcedure()
        {
            SQLControl sql = new SQLControl();

            try
            {
                //SI NO SE ESPECIFICAN ID, NO SE PUEDE AÑADIR
                if (string.IsNullOrWhiteSpace(idTypeParameter) || string.IsNullOrWhiteSpace(idParameter))
                    return (false, null, null, null);

                if (active == null)
                    active = 1;

                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand("sp_ConfParametersModify", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTypeParameter", idTypeParameter);
                cmd.Parameters.AddWithValue("@idParameter", idParameter);
                cmd.Parameters.AddWithValue("@idOriginalTypeParameter", idOriginalTypeParameter);
                cmd.Parameters.AddWithValue("@idOriginalParameter", idOriginalParameter);
                cmd.Parameters.AddWithValue("@nameParameter", nameParameters);
                cmd.Parameters.AddWithValue("@detailParameter", ClsValues.IfEmptyToDBNull(detailParameter));
                cmd.Parameters.AddWithValue("@valueParameter", ClsValues.IfEmptyToDBNull(valueParameters));
                cmd.Parameters.AddWithValue("@user", User.GetUserName());
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@dataType", dataTypeParameters);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string v_nameParameters = dr.GetValue(dr.GetOrdinal("v_nameParameters")).ToString();
                    string v_idParameter = dr.GetValue(dr.GetOrdinal("id_parameter")).ToString();
                    string v_idTypeParameter = dr.GetValue(dr.GetOrdinal("id_typeParameter")).ToString();
                    return (true, v_idParameter, v_idTypeParameter, v_nameParameters);
                }

                return (false, null, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Modificar parámetro");
                return (false, null, null, null);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        // =========================
        // CAMBIAR ACTIVO (SP)
        // =========================

        public static bool ActiveProcedure(string idParameter, string idTypeParameter, string active)
        {
            //ESTÁ ESTE METODO, PERO EN EL Formulario DEL Catálogo SE USARIA EL DE LA CLASE DGV
            SQLControl sql = new SQLControl();

            try
            {
                sql.OpenConectionWrite();

                SqlCommand cmd = new SqlCommand("sp_ConfParametersActive", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                // OJO: usa @id (char3) y @id2 (char2)
                cmd.Parameters.AddWithValue("@id", idParameter);
                cmd.Parameters.AddWithValue("@id2", idTypeParameter);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@user", User.GetUserName());

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Activos parámetro");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
    }
}

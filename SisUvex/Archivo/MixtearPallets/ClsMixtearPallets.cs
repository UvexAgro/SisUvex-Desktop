/*
 * ClsMixtearPallets.cs
 * ====================================================================================
 * Clase principal de lógica de negocio y acceso a datos para el módulo
 * "Mixtear Pallets en Estiba".
 *
 * RESPONSABILIDADES:
 *   1. Consultas a la base de datos (pallets individuales, estibas, tipos de reestiba).
 *   2. Operaciones de escritura (mixtear, reestibar, desestibar).
 *   3. Inicialización y manejo del DataGridView (columnas, inserción, eliminación).
 *   4. Validaciones de negocio antes del mixteo.
 *   5. Utilidades visuales (coloreado de advertencias en el grid).
 *
 * RELACIONES:
 *   - FrmMixtearPallets  → consume todos los métodos públicos de esta clase.
 *   - FrmReestibaPallet  → consume ObtenerTiposReestiba() y EjecutarReestiba().
 *   - EMixtearPallets    → modelos de datos que circulan entre las clases.
 *   - ClsCatalogos       → clase base con utilidades comunes del sistema.
 *   - ClsMixteado (legacy) → NO MODIFICAR; esta clase es el nuevo reemplazo.
 *
 * PROCEDIMIENTOS SQL UTILIZADOS:
 *   - sp_PackPalletAddStowage      → Mixtear un pallet a una estiba (loop por pallet)
 *   - sp_PackPalletDeleteStowage   → Desestibar todos los pallets de una estiba
 *   - sp_PackPalletReestiba        → Dividir/reestibar un pallet (procedimiento heredado)
 *
 * NOTA SOBRE REESTIBA:
 *   El procedimiento sp_PackPalletReestiba usa códigos de 2 chars ('SO','SI','RE','CO').
 *   TipoReestiba.CodigoHeredado retorna directamente TipoReestiba.Prefijo (v_prefix de DB).
 *   Agregar tipos en Pack_PalletUnstowType no requiere cambios en el código.
 *
 * ESCALABILIDAD:
 *   → Para agregar columnas al grid: editar ObtenerDefinicionColumnas().
 *   → Para agregar validaciones de negocio: agregar métodos en la región VALIDACIONES.
 *   → Para soportar nuevas tablas de trazabilidad: ampliar PalletInfo, QUERY_PALLET_BASE
 *     y MapearFilaAPalletInfo().
 * ====================================================================================
 */

using System.Data;
using System.Data.SqlClient;
using SisUvex.Catalogos;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Archivo.MixtearPallets
{
    /// <summary>
    /// Lógica de negocio y acceso a datos para el módulo de Mixtear Pallets en Estiba.
    /// Hereda ClsCatalogos para acceso a utilidades comunes (FormatoCeros, TxbTeclasEnteros, etc.).
    /// </summary>
    internal class ClsMixtearPallets : ClsCatalogos
    {
        private readonly SQLControl sql = new SQLControl();

        // ============================================================================
        #region DEFINICIÓN DE COLUMNAS DEL GRID
        // ============================================================================

        /// <summary>
        /// Metadatos que describen una columna del DataGridView.
        /// ESCALABILIDAD: Agregar propiedades (IsVisible, Format, etc.) según se necesite.
        /// </summary>
        internal class DefinicionColumna
        {
            /// <summary>Nombre clave usado internamente en el DataGridView (Columns["Nombre"])</summary>
            public string Nombre { get; set; } = string.Empty;

            /// <summary>Texto visible en el encabezado de la columna</summary>
            public string Encabezado { get; set; } = string.Empty;

            /// <summary>Ancho mínimo en píxeles: el usuario no podrá reducir por debajo de este valor</summary>
            public int AnchoMinimo { get; set; } = 60;

            /// <summary>
            /// Ancho inicial en píxeles al cargar el formulario.
            /// Debe ser ≥ AnchoMinimo. Con AutoSizeMode = None el usuario puede ajustarlo libremente.
            /// </summary>
            public int AnchoInicial { get; set; } = 0; // 0 = usar AnchoMinimo como fallback
        }

        /// <summary>
        /// Retorna la lista ordenada de columnas que se mostrarán en los DataGridViews de pallets.
        /// ESCALABILIDAD: Agregar, quitar o reordenar DefinicionColumna aquí para cambiar
        /// las columnas visibles. El orden aquí es el orden en el grid.
        /// Al agregar una columna nueva, también actualizar AgregarPalletAlGrid().
        /// </summary>
        private static List<DefinicionColumna> ObtenerDefinicionColumnas() => new()
        {
            // Columna               Encabezado          AnchoMin  AnchoInicial
            new() { Nombre = "Pallet",        Encabezado = "Pallet",       AnchoMinimo = 55,  AnchoInicial = 65  },
            new() { Nombre = "Mix",           Encabezado = "Mix",          AnchoMinimo = 40,  AnchoInicial = 55  },
            new() { Nombre = "Estiba",        Encabezado = "Estiba",       AnchoMinimo = 50,  AnchoInicial = 65  },
            new() { Nombre = "GTIN",          Encabezado = "GTIN",         AnchoMinimo = 70,  AnchoInicial = 80  },
            new() { Nombre = "Cajas",         Encabezado = "Cajas",        AnchoMinimo = 50,  AnchoInicial = 60  },
            new() { Nombre = "LibrasPallet",  Encabezado = "Lbs Pallet",   AnchoMinimo = 70,  AnchoInicial = 85  },
            new() { Nombre = "Tamaño",        Encabezado = "Tamaño",       AnchoMinimo = 55,  AnchoInicial = 65  },
            new() { Nombre = "Pre",           Encabezado = "Pre",          AnchoMinimo = 40,  AnchoInicial = 55  },
            new() { Nombre = "Presentacion",  Encabezado = "Presentación", AnchoMinimo = 85,  AnchoInicial = 140 },
            new() { Nombre = "Pos",           Encabezado = "Pos",          AnchoMinimo = 40,  AnchoInicial = 55  },
            new() { Nombre = "Variedad",      Encabezado = "Variedad",     AnchoMinimo = 85,  AnchoInicial = 160 },
            new() { Nombre = "Distribuidor",  Encabezado = "Distribuidor", AnchoMinimo = 85,  AnchoInicial = 120 },
            new() { Nombre = "Manifiesto",    Encabezado = "Manifiesto",   AnchoMinimo = 70,  AnchoInicial = 85  },
            new() { Nombre = "Rack",          Encabezado = "Rack",         AnchoMinimo = 50,  AnchoInicial = 65  },
            new() { Nombre = "Fecha",         Encabezado = "Fecha",        AnchoMinimo = 75,  AnchoInicial = 90  },
            new() { Nombre = "Lote",          Encabezado = "Lote",         AnchoMinimo = 75,  AnchoInicial = 110 },
            new() { Nombre = "Contenedor",    Encabezado = "Contenedor",   AnchoMinimo = 75,  AnchoInicial = 100 },
            new() { Nombre = "CajasPallet",   Encabezado = "Cjs/Pallet",   AnchoMinimo = 65,  AnchoInicial = 75  },
            // ─── Campos de trazabilidad adicional ───────────────────────────────────
            new() { Nombre = "Cultivo",       Encabezado = "Cultivo",      AnchoMinimo = 65,  AnchoInicial = 90  },
            new() { Nombre = "Cuadrilla",     Encabezado = "Cuadrilla",    AnchoMinimo = 85,  AnchoInicial = 130 },
            new() { Nombre = "Papeleta",      Encabezado = "Papeleta",     AnchoMinimo = 65,  AnchoInicial = 80  },
        };

        // Columnas que se evalúan para colorear advertencias en el grid.
        // ESCALABILIDAD: Agregar nombres de columna aquí para incluirlos en la evaluación visual.
        private static readonly string[] COLUMNAS_ADVERTENCIA =
            { "GTIN", "Tamaño", "Presentacion", "Variedad", "Distribuidor", "Contenedor", "Pre", "Pos" };

        #endregion

        // ============================================================================
        #region CONSULTAS A LA BASE DE DATOS
        // ============================================================================

        /// <summary>
        /// Query base para obtener pallets desde vw_PackPalletCon con datos del GTIN.
        /// Se agregan cláusulas WHERE en los métodos que la usan.
        /// ESCALABILIDAD: Añadir columnas del SELECT al ampliar PalletInfo.
        /// </summary>
        private const string QUERY_PALLET_BASE = @"
            SELECT
                vpal.Pallet,
                vpal.Mix,
                vpal.Estiba,
                vpal.GTIN,
                vpal.Cajas,
                vpal.Libras,
                vpal.[Libras pallet],
                vpal.Tamaño,
                vpal.Presentación,
                vpal.Variedad,
                vpal.Distribuidor,
                vpal.Manifiesto,
                vpal.Rack,
                vpal.Fecha,
                vpal.Lote,
                vpal.Contenedor,
                vpal.Cultivo,
                vpal.Cuadrilla,
                vpal.Papeleta,
                vpal.Pre,
                vpal.Pos,
                vpal.Caja,
                gtn.i_palletBoxes AS CajasPorPallet
            FROM vw_PackPalletCon vpal
            LEFT JOIN gtn ON gtn.id_GTIN = vpal.GTIN";

        /// <summary>
        /// Consulta un pallet por ID en la vista de pallets activos.
        /// Retorna null si el pallet no existe o no está activo.
        /// </summary>
        /// <param name="idPallet">ID formateado con ceros (ej. "00123")</param>
        public PalletInfo? ConsultarPallet(string idPallet)
        {
            string qry = QUERY_PALLET_BASE + " WHERE vpal.Pallet = @idPallet";
            var parameters = new Dictionary<string, object> { { "@idPallet", idPallet } };
            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
            return dt.Rows.Count > 0 ? MapearFilaAPalletInfo(dt.Rows[0]) : null;
        }

        /// <summary>
        /// Consulta todos los pallets activos pertenecientes a una estiba.
        /// Retorna lista vacía si la estiba no existe o no tiene pallets activos.
        /// </summary>
        /// <param name="idEstiba">ID de estiba formateado con ceros (ej. "0042")</param>
        public List<PalletInfo> ConsultarEstiba(string idEstiba)
        {
            string qry = QUERY_PALLET_BASE + " WHERE vpal.Estiba = @idEstiba ORDER BY vpal.Mix";
            var parameters = new Dictionary<string, object> { { "@idEstiba", idEstiba } };
            DataTable dt = ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
            return dt.Rows.Cast<DataRow>().Select(MapearFilaAPalletInfo).ToList();
        }

        /// <summary>
        /// Obtiene los tipos de reestiba activos desde Pack_PalletUnstowType.
        /// Usado por FrmReestibaPallet para cargar el ComboBox de tipos.
        /// </summary>
        public List<TipoReestiba> ObtenerTiposReestiba()
        {
            const string qry = @"
                SELECT id_unstowType, v_unstowTypeName, v_prefix, v_description,
                       c_active, c_activeInPallet
                FROM Pack_PalletUnstowType
                WHERE c_active = '1'
                ORDER BY id_unstowType";
            DataTable dt = ClsQuerysDB.GetDataTable(qry);
            return dt.Rows.Cast<DataRow>().Select(row => new TipoReestiba
            {
                IdTipo          = row["id_unstowType"].ToString()    ?? "",
                Nombre          = row["v_unstowTypeName"].ToString() ?? "",
                Prefijo         = row["v_prefix"].ToString()         ?? "",
                Descripcion     = row["v_description"].ToString()    ?? "",
                Activo          = row["c_active"].ToString()         == "1",
                NuevoPalletActivo = row["c_activeInPallet"].ToString() == "1"
            }).ToList();
        }

        /// <summary>
        /// Retorna el ID de la siguiente estiba disponible (MAX + 1 formateado a 4 dígitos).
        /// </summary>
        public string ObtenerSiguienteEstiba()
        {
            const string qry = "SELECT FORMAT(ISNULL(MAX(c_stowage) + 1, 1), '0000') AS Id FROM Pack_Pallet";
            string resultado = ClsQuerysDB.GetData(qry);
            return string.IsNullOrEmpty(resultado) ? "0001" : resultado;
        }

        /// <summary>
        /// Convierte una DataRow de vw_PackPalletCon a un modelo PalletInfo.
        /// ESCALABILIDAD: Al agregar columnas al QUERY_PALLET_BASE, mapearlas aquí.
        /// </summary>
        private static PalletInfo MapearFilaAPalletInfo(DataRow row)
        {
            string fecha = row["Fecha"]?.ToString() ?? "";
            return new PalletInfo
            {
                IdPallet      = row["Pallet"].ToString() ?? "",
                Mix           = row["Mix"].ToString() ?? "",
                Estiba        = row["Estiba"].ToString() ?? "",
                Programa      = row["GTIN"].ToString() ?? "",
                Cajas         = int.TryParse(row["Cajas"].ToString(), out int cjs) ? cjs : 0,
                LibrasPorCaja = decimal.TryParse(row["Libras"].ToString(), out decimal lbsCja) ? lbsCja : 0,
                LibrasPallet  = decimal.TryParse(row["Libras pallet"].ToString(), out decimal lbsPal) ? lbsPal : 0,
                Tamaño        = row["Tamaño"].ToString() ?? "",
                Presentacion  = row["Presentación"].ToString() ?? "",
                Variedad      = row["Variedad"].ToString() ?? "",
                Distribuidor  = row["Distribuidor"].ToString() ?? "",
                Manifiesto    = row["Manifiesto"].ToString() ?? "",
                Rack          = row["Rack"].ToString() ?? "",
                Fecha         = fecha.Length >= 10 ? fecha[..10] : fecha,
                Lote          = row["Lote"].ToString() ?? "",
                Contenedor    = row["Contenedor"].ToString() ?? "",
                Cultivo       = row["Cultivo"].ToString() ?? "",
                Cuadrilla     = row["Cuadrilla"].ToString() ?? "",
                Papeleta      = row["Papeleta"].ToString() ?? "",
                Pre           = row["Pre"].ToString() ?? "",
                Pos           = row["Pos"].ToString() ?? "",
                TipoCaja      = row["Caja"].ToString() ?? "",
                CajasPorPallet = int.TryParse(row["CajasPorPallet"].ToString(), out int cjsPal) ? cjsPal : 0,
            };
        }

        #endregion

        // ============================================================================
        #region OPERACIONES EN LA BASE DE DATOS
        // ============================================================================

        /// <summary>
        /// Desestiba un pallet individual (limpia c_stowage únicamente de ese pallet).
        /// Usado para la nueva funcionalidad de desestibar pallets del listado inferior.
        /// </summary>
        public bool EjecutarDesestibarPallet(string idPallet)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new(@"
                    UPDATE Pack_Pallet
                    SET   c_stowage  = NULL,
                          userUpdate = @user,
                          d_update   = CONVERT(DATE, SYSDATETIME())
                    WHERE id_pallet  = @idPallet", sql.cnn);
                cmd.Parameters.AddWithValue("@idPallet", idPallet);
                cmd.Parameters.AddWithValue("@user",     User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Desestibar Pallet – Error");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        /// <summary>
        /// Reestiba COMPLETA de un pallet: asigna el tipo/motivo al pallet original
        /// sin crear un pallet nuevo. El pallet conserva todas sus cajas.
        /// Si el tipo NO es SOBRANTE, el pallet queda inactivo.
        /// </summary>
        public ResultadoReestiba EjecutarReestibaCompleta(string idPallet, TipoReestiba tipo)
        {
            ResultadoReestiba resultado = new();
            try
            {
                string cActive = tipo.NuevoPalletActivo ? "1" : "0";
                sql.OpenConectionWrite();
                SqlCommand cmd = new(@"
                    UPDATE Pack_Pallet
                    SET   c_restowing = @restowing,
                          c_active    = @active,
                          userUpdate  = @user,
                          d_update    = CONVERT(DATE, SYSDATETIME())
                    WHERE id_pallet   = @idPallet", sql.cnn);
                cmd.Parameters.AddWithValue("@idPallet",  idPallet);
                cmd.Parameters.AddWithValue("@restowing", tipo.CodigoHeredado);
                cmd.Parameters.AddWithValue("@active",    cActive);
                cmd.Parameters.AddWithValue("@user",      User.GetUserName());
                cmd.ExecuteNonQuery();

                resultado.Exito            = true;
                resultado.IdPalletOriginal = idPallet;
                resultado.Mensaje =
                    $"Reestiba completa aplicada al pallet {idPallet}.\n" +
                    $"Tipo: {tipo.Nombre}.\n" +
                    (tipo.NuevoPalletActivo ? "El pallet sigue ACTIVO." : "El pallet quedó INACTIVO.");
            }
            catch (Exception ex)
            {
                resultado.Exito   = false;
                resultado.Mensaje = ex.Message;
                MessageBox.Show(ex.ToString(), "Reestiba Completa – Error");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return resultado;
        }

        /// <summary>
        /// Ejecuta el mixteo de todos los pallets del DataGridView en una nueva estiba.
        /// Llama a sp_PackPalletAddStowage en un loop por cada pallet.
        /// Retorna el ID de la nueva estiba, o string.Empty si falló.
        /// </summary>
        /// <param name="dgv">DataGridView dgvPallets con los pallets a mixtear</param>
        public string EjecutarMixtear(DataGridView dgv)
        {
            string nuevaEstiba = ObtenerSiguienteEstiba();
            try
            {
                sql.OpenConectionWrite();
                int posicion = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string idPallet = row.Cells["Pallet"].Value?.ToString() ?? "";
                    if (string.IsNullOrEmpty(idPallet)) continue;
                    ++posicion;

                    SqlCommand cmd = new("sp_PackPalletAddStowage", sql.cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idPallet",      idPallet);
                    cmd.Parameters.AddWithValue("@stowage",       nuevaEstiba);
                    cmd.Parameters.AddWithValue("@intMixPallet",  posicion);
                    cmd.Parameters.AddWithValue("@userUpdate",    User.GetUserName());
                    cmd.ExecuteNonQuery();
                }
                return nuevaEstiba;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mixtear Pallets – Error");
                return string.Empty;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        /// <summary>
        /// Ejecuta la reestiba (división) de un pallet.
        /// Llama a sp_PackPalletReestiba usando el prefijo de Pack_PalletUnstowType (v_prefix).
        /// El pallet original queda con cajasNuevas; se crea un pallet nuevo con las sobrantes.
        ///
        /// NOTA: sp_PackPalletReestiba retorna 2 registros: pallet original y nuevo.
        /// </summary>
        /// <param name="idPallet">ID del pallet a reestibar</param>
        /// <param name="cajasNuevas">Cajas que quedarán en el pallet ORIGINAL</param>
        /// <param name="tipo">Tipo de reestiba (provee Prefijo = v_prefix para c_restowing)</param>
        public ResultadoReestiba EjecutarReestiba(string idPallet, int cajasNuevas, TipoReestiba tipo)
        {
            ResultadoReestiba resultado = new();
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackPalletReestiba", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPallet",   idPallet);
                cmd.Parameters.AddWithValue("@boxes",      cajasNuevas);
                cmd.Parameters.AddWithValue("@user",       User.GetUserName());
                cmd.Parameters.AddWithValue("@restowing",  tipo.CodigoHeredado);

                using SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    resultado.IdPalletOriginal = rd["idPallet"].ToString() ?? "";
                    resultado.CajasOriginal    = int.TryParse(rd["Cajas"].ToString(), out int c1) ? c1 : 0;
                }
                if (rd.Read())
                {
                    resultado.IdPalletNuevo = rd["idPallet"].ToString() ?? "";
                    resultado.CajasNuevo    = int.TryParse(rd["Cajas"].ToString(), out int c2) ? c2 : 0;
                }

                resultado.Exito   = true;
                resultado.Mensaje =
                    $"Reestiba completada.\n" +
                    $"  Pallet {resultado.IdPalletOriginal}: {resultado.CajasOriginal} cajas.\n" +
                    $"  Nuevo pallet {resultado.IdPalletNuevo}: {resultado.CajasNuevo} cajas ({tipo.Nombre}).";
            }
            catch (Exception ex)
            {
                resultado.Exito   = false;
                resultado.Mensaje = ex.Message;
                MessageBox.Show(ex.ToString(), "Reestiba Pallet – Error");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
            return resultado;
        }

        /// <summary>
        /// Desestiba todos los pallets de una estiba (limpia c_stowage en Pack_Pallet).
        /// Llama a sp_PackPalletDeleteStowage.
        /// </summary>
        /// <param name="idEstiba">ID de la estiba a limpiar</param>
        public bool EjecutarDesestibar(string idEstiba)
        {
            try
            {
                sql.OpenConectionWrite();
                SqlCommand cmd = new("sp_PackPalletDeleteStowage", sql.cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idStowage",  idEstiba);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Desestibar – Error");
                return false;
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        #endregion

        // ============================================================================
        #region MANEJO DEL DATAGRIDVIEW
        // ============================================================================

        /// <summary>
        /// Inicializa las columnas del DataGridView con las definiciones de ObtenerDefinicionColumnas().
        /// Usar para dgvPallets y dgvDestibar.
        /// ESCALABILIDAD: Las columnas se controlan desde ObtenerDefinicionColumnas().
        /// </summary>
        public void InicializarColumnas(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // Evitar columnas duplicadas por nombres repetidos en la definición
            var nombresAgregados = new HashSet<string>();
            foreach (var def in ObtenerDefinicionColumnas())
            {
                if (nombresAgregados.Contains(def.Nombre)) continue;
                nombresAgregados.Add(def.Nombre);

                int anchoInicial = def.AnchoInicial > 0 ? def.AnchoInicial : def.AnchoMinimo;
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name         = def.Nombre,
                    HeaderText   = def.Encabezado,
                    MinimumWidth = def.AnchoMinimo,
                    Width        = anchoInicial,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None, // permite redimensionar a mano
                    ReadOnly     = true,
                    SortMode     = DataGridViewColumnSortMode.Automatic,
                });
            }
        }

        /// <summary>
        /// Agrega un PalletInfo al DataGridView si no está duplicado (por Pallet ID).
        /// Retorna false si el pallet ya existe en el grid.
        /// ESCALABILIDAD: Al agregar columnas en ObtenerDefinicionColumnas(), agregar
        /// el valor correspondiente en el array de dgv.Rows.Add() abajo.
        /// </summary>
        public bool AgregarPalletAlGrid(DataGridView dgv, PalletInfo pallet)
        {
            if (ExistePalletEnGrid(dgv, pallet.IdPallet)) return false;

            dgv.Rows.Add(
                pallet.IdPallet,       // Pallet
                pallet.Mix,            // Mix
                pallet.Estiba,         // Estiba
                pallet.Programa,       // GTIN
                pallet.Cajas,          // Cajas
                pallet.LibrasPallet,   // LibrasPallet
                pallet.Tamaño,         // Tamaño
                pallet.Pre,            // Pre
                pallet.Presentacion,   // Presentacion
                pallet.Pos,            // Pos
                pallet.Variedad,       // Variedad
                pallet.Distribuidor,   // Distribuidor
                pallet.Manifiesto,     // Manifiesto
                pallet.Rack,           // Rack
                pallet.Fecha,          // Fecha
                pallet.Lote,           // Lote
                pallet.Contenedor,     // Contenedor
                pallet.CajasPorPallet, // CajasPallet
                pallet.Cultivo,        // Cultivo
                pallet.Cuadrilla,      // Cuadrilla
                pallet.Papeleta        // Papeleta
            );
            return true;
        }

        /// <summary>
        /// Verifica si un pallet (por ID) ya existe en el DataGridView.
        /// </summary>
        public bool ExistePalletEnGrid(DataGridView dgv, string idPallet)
            => dgv.Rows.Cast<DataGridViewRow>()
                       .Any(r => r.Cells["Pallet"].Value?.ToString() == idPallet);

        /// <summary>
        /// Quita el pallet seleccionado del DataGridView.
        /// Si el pallet tiene estiba asignada, quita TODOS los pallets de esa estiba.
        /// </summary>
        public void QuitarPalletSeleccionado(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0) return;

            DataGridViewRow fila      = dgv.SelectedRows[0];
            string          estiba    = fila.Cells["Estiba"].Value?.ToString() ?? "";

            if (!string.IsNullOrEmpty(estiba))
            {
                // Quitar todos los pallets de esa estiba
                for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                {
                    if (dgv.Rows[i].Cells["Estiba"].Value?.ToString() == estiba)
                        dgv.Rows.RemoveAt(i);
                }
            }
            else
            {
                dgv.Rows.Remove(fila);
            }
        }

        /// <summary>
        /// Actualiza el número de cajas mostradas en el grid para el pallet con el ID dado.
        /// Usado tras ejecutar una reestiba para reflejar las cajas actualizadas.
        /// </summary>
        public void ActualizarCajasEnGrid(DataGridView dgv, string idPallet, int nuevasCajas)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Pallet"].Value?.ToString() == idPallet)
                {
                    row.Cells["Cajas"].Value = nuevasCajas;
                    break;
                }
            }
        }

        /// <summary>
        /// Extrae el PalletInfo de la fila seleccionada del DataGridView.
        /// Retorna null si no hay fila seleccionada.
        /// </summary>
        public PalletInfo? ObtenerPalletSeleccionado(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0) return null;
            DataGridViewRow row = dgv.SelectedRows[0];
            return new PalletInfo
            {
                IdPallet       = row.Cells["Pallet"].Value?.ToString() ?? "",
                Mix            = row.Cells["Mix"].Value?.ToString() ?? "",
                Estiba         = row.Cells["Estiba"].Value?.ToString() ?? "",
                Programa       = row.Cells["GTIN"].Value?.ToString() ?? "",
                Cajas          = int.TryParse(row.Cells["Cajas"].Value?.ToString(), out int cjs) ? cjs : 0,
                LibrasPallet   = decimal.TryParse(row.Cells["LibrasPallet"].Value?.ToString(), out decimal lbs) ? lbs : 0,
                CajasPorPallet = int.TryParse(row.Cells["CajasPallet"].Value?.ToString(), out int cjsPal) ? cjsPal : 0,
            };
        }

        /// <summary>
        /// Suma las cajas de todos los pallets en el DataGridView.
        /// </summary>
        public int SumarCajas(DataGridView dgv)
            => dgv.Rows.Cast<DataGridViewRow>()
                       .Sum(r => int.TryParse(r.Cells["Cajas"].Value?.ToString(), out int c) ? c : 0);

        /// <summary>
        /// Retorna el menor valor de CajasPorPallet (capacidad estándar del GTIN)
        /// entre todos los pallets del grid. Usado para validar excesos.
        /// Retorna 0 si el grid está vacío o no hay valores válidos.
        /// </summary>
        public int ObtenerCajasPorPalletMinimo(DataGridView dgv)
        {
            var valores = dgv.Rows.Cast<DataGridViewRow>()
                              .Select(r => r.Cells["CajasPallet"].Value?.ToString())
                              .Where(v => int.TryParse(v, out _))
                              .Select(int.Parse)
                              .ToList();
            return valores.Count > 0 ? valores.Min() : 0;
        }

        // ============================================================================
        // DEFERRED REESTIBA — Soporte para reestibas diferidas en el form de mixteo
        // ============================================================================

        /// <summary>
        /// Indica si un ID de pallet es temporal (deferred).
        /// Los IDs temporales se generan con prefijo "Res_" y nunca existen en la DB.
        /// </summary>
        public static bool EsIdDeferred(string id)
            => id.StartsWith("Res_", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Reemplaza todas las ocurrencias de idAntiguo en la columna "Pallet" de un grid
        /// con idNuevo. Usado para sustituir IDs temporales (Res_XXX) con IDs reales de DB
        /// después de ejecutar las reestibas diferidas.
        /// </summary>
        public static void ActualizarIdEnGrid(DataGridView dgv, string idAntiguo, string idNuevo)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Pallet"].Value?.ToString() == idAntiguo)
                {
                    row.Cells["Pallet"].Value = idNuevo;
                    // Quitar el fondo de color temporal (cyan) que diferencia los pallets deferred
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
            }
        }

        /// <summary>
        /// Ejecuta una lista de reestibas diferidas en orden, resolviendo referencias
        /// encadenadas (un deferred puede depender del resultado de otro anterior).
        ///
        /// Retorna un diccionario  idTemporal → idRealDB  para actualizar las grillas
        /// en el form después de la ejecución.
        ///
        /// ESCALABILIDAD:
        ///   Los deferred se ordenan por Orden, por lo que basta con agregar entradas
        ///   a la lista con el campo Orden correcto para que se ejecuten en secuencia.
        /// </summary>
        public Dictionary<string, string> EjecutarReesibasDeferred(List<ReestibaDeferred> reestibas)
        {
            // mapping: idTemporal → idRealDB (se va llenando según se ejecutan)
            var mapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var def in reestibas.OrderBy(r => r.Orden))
            {
                // Resolver el ID real del original (puede ser un temp ya mapeado)
                string realOrigId = def.IdPalletOriginalRef;
                if (EsIdDeferred(realOrigId)
                    && mapping.TryGetValue(realOrigId, out string? resuelto))
                    realOrigId = resuelto;

                if (def.EsCompleta)
                {
                    EjecutarReestibaCompleta(realOrigId, def.Tipo);
                    // No hay pallet nuevo → nada que mapear
                }
                else
                {
                    ResultadoReestiba res = EjecutarReestiba(
                        realOrigId, def.NuevasCajasOriginal, def.Tipo);

                    if (res.Exito && !string.IsNullOrEmpty(res.IdPalletNuevo))
                        mapping[def.IdPalletTemporal] = res.IdPalletNuevo;
                }
            }

            return mapping;
        }

        /// <summary>
        /// Elimina de dgvPallets la fila cuyo Pallet == idPallet.
        /// Usado tras una reestiba completa para quitar el pallet procesado.
        /// </summary>
        public void QuitarPalletPorId(DataGridView dgv, string idPallet)
        {
            for (int i = dgv.Rows.Count - 1; i >= 0; i--)
            {
                if (dgv.Rows[i].Cells["Pallet"].Value?.ToString() == idPallet)
                {
                    dgv.Rows.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Quita un pallet del formulario ELIMINÁNDOLO completamente (para pallets ingresados
        /// por error). Diferente a "mover a desestibar" que solo lo reubica.
        ///
        /// Reglas:
        ///   - Sin estiba asignada  → elimina SOLO la fila seleccionada del grid de origen.
        ///   - Con estiba asignada  → elimina TODOS los pallets de esa estiba de AMBOS grids
        ///     (grid1 y grid2), ya que la estiba como unidad debe limpiarse por completo.
        ///
        /// ESCALABILIDAD: Si en el futuro hay un tercer grid, agregar otro parámetro y
        /// llamar a EliminarPalletsPorEstiba para él también.
        /// </summary>
        public void QuitarPalletDeAmbosGrids(DataGridView grid1, DataGridView grid2,
            DataGridViewRow filaSeleccionada)
        {
            if (filaSeleccionada is null) return;

            string estiba = filaSeleccionada.Cells["Estiba"].Value?.ToString() ?? "";

            if (!string.IsNullOrEmpty(estiba))
            {
                // Estiba asignada → limpiar todos sus pallets en ambos grids
                EliminarPalletsPorEstiba(grid1, estiba);
                EliminarPalletsPorEstiba(grid2, estiba);
            }
            else
            {
                // Sin estiba → solo la fila seleccionada
                if (grid1.Rows.Contains(filaSeleccionada))
                    grid1.Rows.Remove(filaSeleccionada);
                else if (grid2.Rows.Contains(filaSeleccionada))
                    grid2.Rows.Remove(filaSeleccionada);
            }
        }

        /// <summary>Elimina de un grid todas las filas cuya columna Estiba == estiba.</summary>
        private static void EliminarPalletsPorEstiba(DataGridView dgv, string estiba)
        {
            var filas = dgv.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells["Estiba"].Value?.ToString() == estiba)
                .ToList();
            foreach (var f in filas)
                dgv.Rows.Remove(f);
        }

        /// <summary>
        /// Mueve el pallet seleccionado (o todos los de su estiba) desde 'origen' a 'destino'.
        /// No hace re-consulta a la DB: copia los valores de celda directamente.
        /// Usado por btnQuitPallet para enviar pallets al área de desestibar.
        /// </summary>
        public void MoverPalletSeleccionadoAGrid(DataGridView origen, DataGridView destino)
        {
            if (origen.SelectedRows.Count == 0) return;

            // Solo se mueve el pallet seleccionado, aunque pertenezca a una estiba.
            DataGridViewRow fila = origen.SelectedRows[0];
            CopiarFilaAGrid(fila, destino);
            if (origen.Rows.Contains(fila))
                origen.Rows.Remove(fila);
        }

        /// <summary>
        /// Copia todos los valores de celdas de una fila al DataGridView destino (sin duplicar).
        /// Ambos grids deben tener las mismas columnas (mismo InicializarColumnas).
        /// </summary>
        private void CopiarFilaAGrid(DataGridViewRow filaOrigen, DataGridView destino)
        {
            string idPallet = filaOrigen.Cells["Pallet"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(idPallet) || ExistePalletEnGrid(destino, idPallet)) return;

            object[] valores = new object[filaOrigen.Cells.Count];
            for (int i = 0; i < filaOrigen.Cells.Count; i++)
                valores[i] = filaOrigen.Cells[i].Value;

            destino.Rows.Add(valores);
        }

        /// <summary>
        /// Mueve el foco a la última fila del DataGridView.
        /// </summary>
        public void SeleccionarUltimaFila(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                int ultima = dgv.Rows.Count - 1;
                dgv.CurrentCell = dgv.Rows[ultima].Cells[0];
                dgv.Rows[ultima].Selected = true;
            }
        }

        #endregion

        // ============================================================================
        #region VALIDACIONES DE NEGOCIO
        // ============================================================================

        /// <summary>
        /// Compara un pallet NUEVO contra los pallets ya cargados en el grid.
        /// Retorna la lista de nombres de COLUMNA donde hay diferencias respecto a la primera fila.
        /// Retorna lista vacía si el grid está vacío (sin referencia) o si no hay diferencias.
        /// Usado ANTES de agregar el pallet, para mostrar una advertencia previa.
        /// ESCALABILIDAD: Agregar columnas a 'comparaciones' para ampliar la validación.
        /// </summary>
        public List<string> ObtenerDiferenciasPallet(DataGridView dgv, PalletInfo nuevoPallet)
        {
            if (dgv.Rows.Count == 0) return new List<string>();

            var fila0      = dgv.Rows[0];
            var diferencias = new List<string>();

            // Mapa columna → valor del nuevo pallet
            var comparaciones = new Dictionary<string, string>
            {
                { "GTIN",    nuevoPallet.Programa    },
                { "Tamaño",      nuevoPallet.Tamaño      },
                { "Presentacion",nuevoPallet.Presentacion},
                { "Variedad",    nuevoPallet.Variedad    },
                { "Distribuidor",nuevoPallet.Distribuidor},
                { "Contenedor",  nuevoPallet.Contenedor  },
            };

            foreach (var (columna, valorNuevo) in comparaciones)
            {
                if (!dgv.Columns.Contains(columna)) continue;
                string valorRef = fila0.Cells[columna].Value?.ToString() ?? "";
                // Solo reportar si ambos tienen valor y son distintos
                if (!string.IsNullOrEmpty(valorNuevo) && !string.IsNullOrEmpty(valorRef)
                    && valorNuevo != valorRef)
                    diferencias.Add(columna);
            }

            return diferencias;
        }

        /// <summary>
        /// Valida el contenido del grid antes de ejecutar el mixteo.
        ///
        /// REGLAS:
        ///   ERROR (bloquea): pallets de diferentes manifiestos.
        ///   ADVERTENCIA (pide confirmación): diferencias en Programa, Tamaño,
        ///     Presentación, Variedad, Distribuidor, Contenedor, CajasPorPallet,
        ///     estibas diferentes o total de cajas que excede el máximo del GTIN.
        ///
        /// ESCALABILIDAD: Agregar nuevas validaciones aquí sin modificar los callers.
        /// </summary>
        /// <param name="dgv">Grid con los pallets a mixtear</param>
        /// <param name="totalCajas">Total de cajas calculado (SumarCajas)</param>
        /// <param name="mensajeError">Mensaje de error bloqueante (vacío si no hay)</param>
        /// <param name="mensajeAdvertencia">Resumen de advertencias (vacío si no hay)</param>
        /// <returns>true si el mixteo puede continuar (con o sin advertencias)</returns>
        public bool ValidarParaMixtear(DataGridView dgv, int totalCajas,
            out string mensajeError, out string mensajeAdvertencia)
        {
            mensajeError       = string.Empty;
            mensajeAdvertencia = string.Empty;

            if (dgv.Rows.Count == 0)
            {
                mensajeError = "No hay pallets en la lista para mixtear.";
                return false;
            }

            // ── REGLA BLOQUEANTE: no se pueden mixtear pallets de manifiestos distintos ──
            if (HayValoresDiferentes(dgv, "Manifiesto"))
            {
                mensajeError =
                    "Los pallets pertenecen a diferentes manifiestos.\n" +
                    "No se puede realizar el mixteo con manifiestos distintos.";
                return false;
            }

            // ── ADVERTENCIAS: diferencias en campos relevantes ──────────────────────────
            var diferencias = new List<string>();

            if (HayValoresDiferentes(dgv, "GTIN"))     diferencias.Add("GTIN");
            if (HayValoresDiferentes(dgv, "Tamaño"))       diferencias.Add("TAMAÑO");
            if (HayValoresDiferentes(dgv, "Presentacion")) diferencias.Add("PRESENTACIÓN");
            if (HayValoresDiferentes(dgv, "Variedad"))     diferencias.Add("VARIEDAD");
            if (HayValoresDiferentes(dgv, "Distribuidor")) diferencias.Add("DISTRIBUIDOR");
            if (HayValoresDiferentes(dgv, "Contenedor"))   diferencias.Add("CONTENEDOR");
            if (HayValoresDiferentes(dgv, "CajasPallet"))  diferencias.Add("CAJAS/PALLET (GTIN)");

            // Advertencia: estibas distintas
            if (!TodasEstibasIguales(dgv))
                diferencias.Add("ESTIBAS DISTINTAS");

            // Advertencia: total de cajas excede la capacidad del GTIN
            int cajasMaxGtin = ObtenerCajasPorPalletMinimo(dgv);
            if (cajasMaxGtin > 0 && totalCajas > cajasMaxGtin)
                diferencias.Add($"TOTAL CAJAS ({totalCajas}) EXCEDE MÁXIMO DEL GTIN ({cajasMaxGtin})");

            if (diferencias.Count > 0)
                mensajeAdvertencia = "Los pallets difieren en:\n  • " + string.Join("\n  • ", diferencias);

            return true;
        }

        // ── Helpers privados de validación ────────────────────────────────────────────

        /// <summary>
        /// Retorna true si existen al menos dos valores no vacíos DISTINTOS en la columna.
        /// </summary>
        private static bool HayValoresDiferentes(DataGridView dgv, string columna)
        {
            string? primero = null;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string val = row.Cells[columna].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(val)) continue;
                if (primero is null) { primero = val; continue; }
                if (val != primero) return true;
            }
            return false;
        }

        /// <summary>
        /// Retorna true si todos los pallets con estiba asignada pertenecen a la MISMA estiba.
        /// Los pallets sin estiba no se consideran en la comparación.
        /// </summary>
        private static bool TodasEstibasIguales(DataGridView dgv)
        {
            string? primera = null;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string estiba = row.Cells["Estiba"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(estiba)) continue;
                if (primera is null) { primera = estiba; continue; }
                if (estiba != primera) return false;
            }
            return true;
        }

        #endregion

        // ============================================================================
        #region UTILIDADES VISUALES
        // ============================================================================

        /// <summary>
        /// Colorea las filas del grid que tienen valores distintos a la primera fila
        /// en alguna de las columnas de COLUMNAS_ADVERTENCIA.
        /// Filas "iguales" se muestran en blanco; filas "distintas" en amarillo claro.
        /// ESCALABILIDAD: Modificar COLUMNAS_ADVERTENCIA para cambiar qué se evalúa.
        /// </summary>
        public void AplicarColorAdvertencias(DataGridView dgv)
        {
            // Limpiar todos los estilos previos (fila y celda)
            foreach (DataGridViewRow r in dgv.Rows)
            {
                r.DefaultCellStyle.BackColor = Color.White;
                foreach (DataGridViewCell c in r.Cells)
                    c.Style.BackColor = Color.Empty; // hereda del padre
            }

            if (dgv.Rows.Count <= 1) return;

            // Columnas de advertencia que realmente existen en este grid
            var columnas = COLUMNAS_ADVERTENCIA.Where(col => dgv.Columns.Contains(col)).ToArray();

            // Row 0 = referencia; no se colorea (es el patrón)
            var referencia = columnas.ToDictionary(
                col => col,
                col => dgv.Rows[0].Cells[col].Value?.ToString() ?? "");

            // Comparar filas 1..N contra la referencia
            for (int i = 1; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row  = dgv.Rows[i];
                bool            fila = false;

                foreach (string col in columnas)
                {
                    bool diff = (row.Cells[col].Value?.ToString() ?? "") != referencia[col];

                    if (diff)
                    {
                        // Celda diferente → rojo suave  (prioridad sobre fondo de fila)
                        row.Cells[col].Style.BackColor = Color.FromArgb(255, 182, 182);
                        fila = true;
                    }
                    else
                    {
                        // Celda igual → hereda el fondo de fila (amarillo si hay otra diferencia)
                        row.Cells[col].Style.BackColor = Color.Empty;
                    }
                }

                // Toda la fila en amarillo si al menos una celda difiere
                row.DefaultCellStyle.BackColor = fila ? Color.LightYellow : Color.White;
            }
        }

        #endregion
    }
}
